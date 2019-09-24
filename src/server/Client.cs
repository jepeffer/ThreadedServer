using System.Net.Sockets;
using System;


public class Client
{
    TcpClient client;

    NetworkStream stream;
    Socket socket;


    public Client() { client = new TcpClient(); }

    public void threadStart(Object obj)
    {
        client = (TcpClient)obj;
        stream = client.GetStream();
    }
}