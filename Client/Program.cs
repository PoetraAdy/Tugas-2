using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var broadcaster = new UdpClient();
            var endPoint = new IPEndPoint(IPAddress.Broadcast, 4000);
            var data = Encoding.ASCII.GetBytes("PING");
            broadcaster.Send(data, data.Length, endPoint);
            while(true)
            {
                var rcvByte = broadcaster.Receive(ref endPoint);
                var rcvData = Encoding.ASCII.GetString(rcvByte, 0, rcvByte.Length);
                Console.WriteLine("Data from server: {0}", rcvData);
            }

            broadcaster.Close();
            Console.WriteLine(" ");
            Console.ReadLine();
        }
    }
}
