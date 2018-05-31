using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace LISTING_4_13_UDP_over_sockets
{
    class Program
    {

        const int ECHO_PORT = 7;

        const int MAX_BUFFER_SIZE = 100000;

        const int MESSAGE_TIMEOUT_MSECS = 10000;

        static Socket hostSocket = hostSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        // Signaling object used to notify when an asynchronous operation is completed
        static ManualResetEvent transferDoneFlag = new ManualResetEvent(false);


        /// <summary>
        /// Send a message to a host using UDP
        /// </summary>
        /// <param name="message">message to send</param>
        /// <param name="hostUrl">Url of host</param>
        /// <param name="portNumber">number of port</param>
        /// <returns>empty string or error message</returns>
        public static string SendMessageUDP(string message, string hostUrl, int portNumber)
        {
            // String to hold the response message for a caller
            // to SendMessage
            string response = "Send Timed Out";

            // Create the argument object for this request
            SocketAsyncEventArgs socketEventArgs = new SocketAsyncEventArgs();

            // Make an endpoint that connects to the server
            IPAddress hostAddress;
            IPAddress.TryParse(hostUrl, out hostAddress);
            socketEventArgs.RemoteEndPoint = new IPEndPoint(hostAddress, portNumber);

            // Put the message into the buffer
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            socketEventArgs.SetBuffer(messageBytes, 0, messageBytes.Length);

            // Connect an event handler that runs when the request completes
            socketEventArgs.Completed += new EventHandler<SocketAsyncEventArgs>(delegate (object s, SocketAsyncEventArgs e)
            {
                if (e.SocketError == SocketError.Success)
                {
                    response = "";
                }
                else
                {
                    response = e.SocketError.ToString();
                }
                // Enable any threads waiting on this thread
                transferDoneFlag.Set();
            });

            // Clear the event, so that threads will block on it
            // until one of them sets the event
            transferDoneFlag.Reset();

            // Send the message
            hostSocket.SendToAsync(socketEventArgs);

            // Wait on the event
            // Will continue after the timeout or 
            // if a response is received
            transferDoneFlag.WaitOne(MESSAGE_TIMEOUT_MSECS);

            return response;
        }


        public static string ReceiveMessageUDP(int portNumber, out string result)
        {
            string response = "Receive Timed Out";
            string message = "";

            SocketAsyncEventArgs socketEventArgs = new SocketAsyncEventArgs();
            socketEventArgs.RemoteEndPoint = new IPEndPoint(IPAddress.Any, portNumber);

            // Create a buffer for the response
            byte[] responseBytes = new Byte[MAX_BUFFER_SIZE];
            socketEventArgs.SetBuffer(responseBytes, 0, MAX_BUFFER_SIZE);

            // Bind a handler to the reply received event
            socketEventArgs.Completed += new EventHandler<SocketAsyncEventArgs>(delegate (object s, SocketAsyncEventArgs e)
            {
                if (e.SocketError == SocketError.Success)
                {
                    response = "";
                    // Retrieve the data from the buffer
                    message = Encoding.UTF8.GetString(e.Buffer, e.Offset, e.BytesTransferred);
                    message = message.Trim('\0');
                }
                else
                {
                    response = e.SocketError.ToString();
                }

                // Unblock the UI thread
                transferDoneFlag.Set();
            });

            // Clear the event, so that threads will block on it
            // until one of them sets the event
            transferDoneFlag.Reset();

            // Make an asynchronous Receive request over the socket
            hostSocket.ReceiveFromAsync(socketEventArgs);

            // Block the thread for a maximum of TIMEOUT_MILLISECONDS milliseconds.
            // If no response comes back within this time then proceed
            transferDoneFlag.WaitOne(MESSAGE_TIMEOUT_MSECS);

            result = message;
            return response;
        }

        public static void DoWork()
        {
            while(true)
            {
                string result = "";
                Console.WriteLine(ReceiveMessageUDP(8081, out result));
            }

        }



        static void Main(string[] args)
        {
            Task newTask = new Task(() => DoWork());
            newTask.Start();
            Console.WriteLine(SendMessageUDP("hello world", "127.1.1.1", 8081));
            Console.ReadKey();
        }
    }
}
