import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;

public class Server {
	private ServerSocket server;
	
	public static void main(String[] args){
		Server serv=new Server();
		try {
			serv.start();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	
	
	
	public void start() throws IOException{
		server=new ServerSocket(4096);
		
		System.out.println("Waiting for user 1");
		Socket client1=server.accept();
		System.out.println("Connected to: "+client1.getInetAddress().getHostAddress() );
		
		Connection c1=new Connection(client1.getOutputStream(),client1.getInputStream());
		Thread t1=new Thread(c1);
		t1.start();
	}
}
