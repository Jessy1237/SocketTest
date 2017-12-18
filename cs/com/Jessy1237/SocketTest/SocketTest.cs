using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace com.Jessy1237.SocketTest
{
    class SocketTest
    {
        const int PORT_NO = 4014;
        const string SERVER_IP = "127.0.0.1";

        static void Main(string[] args)
        {
            //listen at the specified IP and port no.
            IPAddress localAdd = IPAddress.Parse(SERVER_IP);
            TcpListener listener = new TcpListener(localAdd, PORT_NO);
            Console.WriteLine("Listening...");
            listener.Start();

            string dataReceived = "";

            //incoming client connected
            TcpClient client = listener.AcceptTcpClient();

            Console.WriteLine("Accepted connection from " + client.Client.RemoteEndPoint.ToString());
            //loops reading for data
            while (true)
            {
                //get the incoming data through a network stream
                NetworkStream nwStream = client.GetStream();
                byte[] buffer = new byte[client.ReceiveBufferSize];

                //read incoming stream
                int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

                //convert the data received into a string
                dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Received : " + dataReceived);

                //ends the loop from receiving data
                if (dataReceived.Equals("done"))
                    break;

                //holds the loop until more data is available
                while (!nwStream.DataAvailable)
                {}
            }
            Console.WriteLine("Closing...");
            listener.Stop();
        }
    }
}
