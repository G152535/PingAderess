using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.IO;
using System.Net;

namespace PingAdres
{
   class Program
   {
      static void Main(string[] args)
      {
         List<string> serversList = new List<string>
         {
            "google.com",
            "www.sdkpro.ru",
            "hrost8000.asuscomm.com",
            "10.8.0.1",
            "10.15.0.61",
            "10.15.0.121"
         };
         Console.WriteLine("Пингуем эти адреса");
         serversList.ForEach(i => Console.WriteLine(i)); 

         Console.WriteLine();

         Ping ping = new System.Net.NetworkInformation.Ping();
            PingReply pingReply = null;            

         foreach (string server in serversList)
         {
            try
            {
               pingReply = ping.Send(server);

               if (pingReply.Status != IPStatus.TimedOut)
               {
                  Console.WriteLine("Server= " + server); //server
                  Console.WriteLine("Address= " + pingReply.Address); //IP
                  Console.WriteLine("Status= " + pingReply.Status); //Статус
                  Console.WriteLine("RoundtripTime= " + pingReply.RoundtripTime); //Время ответа
                  Console.WriteLine("TTL= " + pingReply.Options.Ttl); //TTL
                  Console.WriteLine("Фрагментирование= " + pingReply.Options.DontFragment); //Фрагментирование
                  Console.WriteLine("Buffer.Length= " + pingReply.Buffer.Length); //Размер буфера
                  Console.WriteLine();
               }
               else
               {
                  Console.WriteLine(server); //server
                  Console.WriteLine(pingReply.Status);
                  Console.WriteLine();
               }
            }
            catch (Exception ex)
            {
               Console.WriteLine("Err-"+server+": "+ex.Message);
            }
         }//конец цикла         
         Console.ReadKey();
      }
   }
}
