using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace EchoServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            TcpListener serverSocket = new TcpListener(6789);
            serverSocket.Start();

            while(true)
            {
                Task.Run(() =>
                {
                    TcpClient tempSocket = serverSocket.AcceptTcpClient();
                    DoClient(tempSocket);
                });
            }
            //Console.WriteLine("server started witing for connection!");

            //TcpClient connectionSocket = serverSocket.AcceptTcpClient();
            ////Socket connectionSocket = serverSocket.AcceptSocket();
            //Console.WriteLine("Server activated");

            //DoClient(connectionSocket);

            //connectionSocket.Close();
            //serverSocket.Stop();
        }
        
        public static void DoClient(TcpClient socket)
        { 

            Stream ns = socket.GetStream();
            // Stream ns = new NetworkStream(connectionSocket);

            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; // enable automatic flushing

            string message = sr.ReadLine();
            string answer = "";
            while (message != null && message != "")
            {
                Console.WriteLine("Client: " + message);
                int first, second;
                var splitstring = message.Split(' ');
                first = Int32.Parse(splitstring[0]);
                second = Int32.Parse(splitstring[1]);
                answer = Convert.ToString(first + second);
                sw.WriteLine(answer);
                message = sr.ReadLine();
            }
            ns.Close();
        }
    }
}

