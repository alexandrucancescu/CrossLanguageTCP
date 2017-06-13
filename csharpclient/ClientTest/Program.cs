using System;
using System.Net.Sockets;
using System.Text;

namespace ClientTest
{
	class MainClass
	{
		static void chat(){

		}

		public static void Main(string[] args)
		{
			TcpClient connection;
			connection = new TcpClient("127.0.0.1", 4096);
			Console.WriteLine("Connection local!");


			NetworkStream ns = connection.GetStream();
			String message;

			while (true)
            {
                Console.Write("Message for Java: ");
                String toSend = Console.ReadLine();
                Writer.writeString(ns,toSend);
				message = Reader.readString(ns);

				Console.WriteLine("Reply from Java: "+message);
			}
		}
	}
}
