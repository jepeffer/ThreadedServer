﻿using System;  
using System.Net;  
using System.Net.Sockets;  
using System.Text;  
using System.Threading;  
namespace ThreadedServer
{
    class Program
    {
        static void Main(string[] args)
        {
           Thread t1 = new Thread(delegate()
			   {
				Server myServer = new Server("127.0.0.1",5556);
				});
	
	// Start the thread	   
    	t1.Start();
    	Console.WriteLine("Server is up....!");	
    }
    }
    
}
