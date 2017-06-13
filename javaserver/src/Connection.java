import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;

public class Connection implements Runnable{
	private DataOutputStream out;
	private DataInputStream in;
	
	public Connection(OutputStream outputStream,InputStream inputStream){
		out=new DataOutputStream(outputStream);
		in=new DataInputStream(inputStream);
	}
	
	@Override
	public void run() {
		try {
			while(true){
				String message= Reader.readString(in);
				System.out.println(message);
				Writer.writeString(out, "C# sent: "+message);
			}
		} catch (IOException e) {
			e.printStackTrace();
		} 
		
	}
}
