using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace ClientTest
{
	public class Writer
	{
		public static Boolean writeString(NetworkStream ns,String message)
		{
			var encoding = new UTF8Encoding(true);

            //converting to bytes from string
			byte[] buff = encoding.GetPreamble().Concat(encoding.GetBytes(message)).ToArray();

            //sending the size of the message first
            writeInt(ns,buff.Length);
			ns.Write(buff, 0, buff.Length);
			ns.Flush();
			return true;
		}

		public static Boolean writeInt(NetworkStream ns, int nr)
		{

			byte[] buffer = BitConverter.GetBytes(nr);
			if (BitConverter.IsLittleEndian)
				Array.Reverse(buffer);

			ns.Write(buffer,0,buffer.Length);
			ns.Flush();
			return true;
		}
	}
}
