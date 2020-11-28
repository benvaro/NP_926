using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Udp_fileClient
{
    class Program
    {
        const int port = 2020;
        static string host = "127.0.0.1";
        static void Main(string[] args)
        {
            Console.Title = "Client";
            var path = "winter.txt";
            #region Download from url
            //using (var webClient = new WebClient())
            //{
            //    var url = "https://images.pexels.com/photos/773594/pexels-photo-773594.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500";
            //    webClient.DownloadFile(url, path);
            //}

            #endregion
            var client = new UdpClient();

            SendHeaders(path, client);
           
            Console.ReadLine();
            client.Close();
        }

        private static void SendHeaders(string path, UdpClient client)
        {
            var fileName = Path.GetFileName(path);
            client.Send(Encoding.UTF8.GetBytes(fileName), fileName.Length, host, port);
            SendBody(path, client);
        }

        private static void SendBody(string path, UdpClient client)
        {
            var data = File.ReadAllBytes(path);
            client.Send(data, data.Length, host, port);
        }
    }
}
