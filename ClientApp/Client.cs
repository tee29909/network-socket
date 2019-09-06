using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = System.IO.File.ReadAllText(@"C:\Users\Master\Desktop\TCPIPAPP\a.txt");
            
            //Console.WriteLine(s);
            Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("192.168.0.13"), 8080);
            sck.Connect(endpoint);
            //Console.Write("Enter Message:");
           // string msg = Console.ReadLine();
            byte[] msgbuffer = Encoding.ASCII.GetBytes(s.ToLower());
            sck.Send(msgbuffer, 0, msgbuffer.Length, 0);

            byte[]  buffer = new byte[1024];
            int rec = sck.Receive(buffer, 0, buffer.Length, 0);
            Array.Resize(ref buffer, rec);
            Console.WriteLine("Received :{0}", Encoding.Default.GetString(buffer));
            sck.Close();
     
            Console.Read();
        }
    }
}
