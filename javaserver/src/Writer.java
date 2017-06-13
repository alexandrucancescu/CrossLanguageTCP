import java.io.DataOutputStream;
import java.io.IOException;
import java.nio.ByteBuffer;
import java.nio.charset.StandardCharsets;

public class Writer {
	public static boolean writeString(DataOutputStream out,String str) throws IOException{
		byte[] buff = str.getBytes(StandardCharsets.UTF_8);
		out.writeByte(buff.length);;
		out.write(buff);
		out.flush();
		return true;
	}
	
	private static byte[] intToBytes( final int i ) {
	    ByteBuffer bb = ByteBuffer.allocate(4); 
	    bb.putInt(i); 
	    return bb.array();
	}
	
	public static boolean writeInt(DataOutputStream out,Integer nr) throws IOException{
		byte[] buff=intToBytes(nr);
		out.write(buff);
		out.flush();
		return true;
	}
}
