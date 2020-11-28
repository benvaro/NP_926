using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Udp_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient server = new UdpClient(2020);
            IPEndPoint ep = null;
            Console.WriteLine("Wait...");
            var data = server.Receive(ref ep);
            Console.WriteLine("Got: " + Encoding.UTF8.GetString(data, 0, data.Length));
        }
    }
}
