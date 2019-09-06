using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPIPAPP
{
    class Program
    {
        static void Main(string[] args)
        {

            
            

            Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("192.168.0.1"), 1990);
            sck.Bind(endpoint);
            sck.Listen(10);
            Socket acc = sck.Accept();
            string message = "Hello";
            byte[] buffer = Encoding.ASCII.GetBytes(message);
            acc.Send(buffer, 0, buffer.Length, 0);


            buffer = new byte[1024];
            Console.WriteLine(buffer);
            int rec = acc.Receive(buffer, 0, buffer.Length, 0);
            Array.Resize(ref buffer, rec);
            Console.WriteLine("Received :{0}", Encoding.Default.GetString(buffer));
            if (Encoding.Default.GetString(buffer) != "")
            {
                System.IO.File.WriteAllText(@"C:\Users\Master\Desktop\TCPIPAPP\a_small.txt", Encoding.Default.GetString(buffer).ToLower());
            }
            
            sck.Close();
            acc.Close();
            Console.Read();
        }
    }
}
