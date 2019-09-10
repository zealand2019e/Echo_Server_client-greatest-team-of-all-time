using System;
using System.Net.Sockets;
using System.IO;

namespace EchoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World it is client!");
            Console.ReadLine();
            TcpClient clientSocket = new TcpClient("localhost", 6789);
            Stream ns = clientSocket.GetStream();
            while (true)
            {
                 //provides a Stream
                StreamReader sr = new StreamReader(ns);
                StreamWriter sw = new StreamWriter(ns);
                sw.AutoFlush = true; // enable automatic flushing

                string message = Console.ReadLine();
                sw.WriteLine(message);
                string serverAnswer = sr.ReadLine();
                Console.WriteLine("Server: " + serverAnswer);
            }

            ns.Close();

            clientSocket.Close();
        }
    }
}
