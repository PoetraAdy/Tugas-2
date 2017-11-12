using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TimerSend
{
    class Program
    {
        static void Main(string[] args)
        {
            const int listenPort = 4000;
            var serverAddr = new UdpClient(listenPort);
            var endPoint = new IPEndPoint(IPAddress.Any, listenPort);

            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for broadcast");
                    var rcvByte = serverAddr.Receive(ref endPoint);
                    Console.WriteLine("Receive a broadcast from {0}", endPoint.ToString());
                    var rcvData = Encoding.ASCII.GetString(rcvByte, 0, rcvByte.Length);
                    Console.WriteLine("Data from broadcast: {0}", rcvData);

                    while(true)
                    {
                        DateTime Waktuku = DateTime.Now;
                        string Timeku = Waktuku.ToString("hh:mm:ss");
                        var reply = Timeku;
                        var replyByte = Encoding.ASCII.GetBytes(reply);
                        serverAddr.Send(replyByte, replyByte.Length, endPoint);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            Console.WriteLine(" ");
            Console.ReadLine();
        }
    }
}
