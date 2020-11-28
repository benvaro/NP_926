using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Udp_fileserver
{
    class Program
    {
        const int port = 2020;
        static void Main(string[] args)
        {
            Console.Title = "Server: " + port;
            Console.WriteLine("Wait...");
            var server = new UdpClient(port);

            IPEndPoint ep = null;

            var data = server.Receive(ref ep);
            var path = Encoding.UTF8.GetString(data);

            data = server.Receive(ref ep);
            File.WriteAllBytes(path, data);

            Console.WriteLine("Send ok..");
            Console.ReadLine();
            server.Close();
        }
    }
}
