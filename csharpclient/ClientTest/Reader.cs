using System;
using System.Net.Sockets;
using System.Text;

namespace ClientTest
{
	public class Reader
	{
		private static byte[] ReadFully(NetworkStream inputStream)
		{
            int size = inputStream.ReadByte();
			byte[] buffer = new byte[size];
			if (inputStream == null)
			{
				return null;
			}

			if (buffer == null)
			{
				return null;
			}

			int totalBytesRead = 0;
			int bytesLeft = buffer.Length;
			if (bytesLeft <= 0)
			{
				return null;
			}

			while (totalBytesRead < buffer.Length)
			{
				var bytesRead = inputStream.Read(buffer, totalBytesRead, bytesLeft);
				if (bytesRead > 0)
				{
					totalBytesRead += bytesRead;
					bytesLeft -= bytesRead;
				}
				else
				{
					return null;
				}
			}
			return buffer;
		}

		public static String readString(NetworkStream ns)
		{
			byte[] buffer = ReadFully(ns);
			if (buffer == null)
				return null;
			return Encoding.UTF8.GetString(buffer);
		}

		public static int readInt(NetworkStream ns)
		{
			byte[] buffer = ReadFully(ns);
			if (buffer == null)
				throw new Exception("Invalid byte buffer received");
			Array.Reverse(buffer);
			return BitConverter.ToInt32(buffer,0);
		}
			
}
}
