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
         List<string> serversList = new List<string>();         
         serversList.Add("google.com"); 
         
         serversList.Add("www.sdkpro.ru");

         serversList.Add("hrost8000.asuscomm.com");

         string Something = string.Join("   ", serversList);
         Console.WriteLine("Адреса для проверки = " + Something);

         Console.WriteLine();

         Ping ping = new System.Net.NetworkInformation.Ping();
            PingReply pingReply = null;
            

            foreach (string server in serversList)
            {

               try
               {
                  IPHostEntry hostInfo = Dns.Resolve(server);
                  Console.WriteLine("Пмнгуем hostInfo.HostName= " + hostInfo.HostName); //IP
               }
               catch (Exception ee)
               {
               Console.WriteLine(ee.Message);
               Console.WriteLine(server); //server
               Console.WriteLine(ee.Message);
               Console.WriteLine();
                  continue;
               }

            

              pingReply = ping.Send(server);

               if (pingReply.Status != IPStatus.TimedOut)
               {
               Console.WriteLine("Server= " + server); //server
               Console.WriteLine("Address= " + pingReply.Address); //IP
               Console.WriteLine("Status= " + pingReply.Status); //Статус
               Console.WriteLine("RoundtripTime= " + pingReply.RoundtripTime); //Время ответа
               Console.WriteLine("Options.Ttl= " + pingReply.Options.Ttl); //TTL
               Console.WriteLine("Options.DontFragment= " + pingReply.Options.DontFragment); //Фрагментирование
               Console.WriteLine("Buffer.Length= " + pingReply.Buffer.Length); //Размер буфера
               Console.WriteLine();
               }
               else
               {
               Console.WriteLine(server); //server
               Console.WriteLine(pingReply.Status);
               Console.WriteLine();
               
               }

             
            }//конец цикла
        

         
         Console.ReadKey();
      }
   }
}
