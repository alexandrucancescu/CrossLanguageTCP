import java.io.DataInputStream;
import java.io.IOException;
import java.nio.charset.StandardCharsets;

public class Reader {
	private static byte[] read(DataInputStream in) throws IOException{
		int size=in.readInt();
		System.out.println("Size of message: "+size);
		byte[] buffer=new byte[size];
		in.readFully(buffer);
		System.out.println("Read finished");
		return buffer;
	}
	
	public static String readString(DataInputStream in) throws IOException{
		byte[] buffer=read(in);
		
		return new String(buffer,StandardCharsets.UTF_8);
	}
	
	public static Integer readInt(DataInputStream in) throws IOException{
		return in.readInt();
	}
}
