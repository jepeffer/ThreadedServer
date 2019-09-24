using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class Server
{

	TcpListener tcpServer = null;

	public Server(string IPAddressIn, int portIn)
	{
		// Create the ip address object for the TCP Listener
		IPAddress ipAddress = IPAddress.Parse(IPAddressIn);
		tcpServer = new TcpListener(ipAddress, portIn);
		// Start listening for connections, pushing each connection to the queue until stop is called
		tcpServer.Start();

		StartListener();
	}

	protected void StartListener()
	{
		try
		{
			while (true)
			{
				Console.WriteLine("Waiting for a connection...");
				// Blocking call that returns a client that can be used to send/recieve data
				TcpClient tcpClient = tcpServer.AcceptTcpClient();
				Console.WriteLine("Connected!");

                Client client = new Client();
                Thread t = new Thread(new ParameterizedThreadStart(client.threadStart));
                t.Start(tcpClient);
            }
        }
		catch (SocketException e)
		{
			Console.WriteLine(e.ToString());
		}
	}
}
