using System;
using System.Net.Sockets;
using System.Text;

namespace Udp_client
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient client = new UdpClient("127.0.0.1", 2020);
            Console.WriteLine("Enter text to send: ");
            var message = Console.ReadLine();
            client.Send(Encoding.UTF8.GetBytes(message), message.Length);

            Console.ReadLine();
        }
    }
}
