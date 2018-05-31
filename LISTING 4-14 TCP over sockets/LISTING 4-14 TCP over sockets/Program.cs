using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace LISTING_4_14_TCP_over_sockets
{
    class Program
    {
        #region Socket Code

        /// <summary>
        /// Socket used for all communications
        /// </summary>
        static Socket hostSocket = null;

        // Timeouts
        const int MESSAGE_TIMEOUT_MSECS = 10000;
        const int MAX_BUFFER_SIZE = 100000;

        /// <summary>
        /// Transfer flag shared for fetch operations. Note that this
        /// is not safe for multiple requests. If several read requests are placed
        /// simultaneously the synchronisation will fail.
        /// </summary>
        static ManualResetEvent transferDoneFlag = new ManualResetEvent(false);

        /// <summary>
        /// Open a connection to a TCP port
        /// Sets the value of hostSocket to the socket being used
        /// </summary>
        /// <param name="host">url of the host to connect to</param>
        /// <param name="port">TCP port to use</param>
        /// <returns>an empty string if successful, otherwise a text error message</returns>
        private static string ConnectTCP(string host, int port)
        {
            string response = "Connect timed out";

            DnsEndPoint hostEntry = new DnsEndPoint(host, port);

            hostSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Create a SocketAsyncEventArgs object to be used in the connection request
            SocketAsyncEventArgs socketEventArgs = new SocketAsyncEventArgs();
            socketEventArgs.RemoteEndPoint = hostEntry;

            // Inline event handler for the Completed event.
            // Note: This event handler was implemented inline in order to make this method self-contained.
            socketEventArgs.Completed += new EventHandler<SocketAsyncEventArgs>(delegate (object s, SocketAsyncEventArgs e)
            {
                if (e.SocketError == SocketError.Success)
                {
                    response = "";
                }
                else
                {
                    // Retrieve the result of this request
                    response = e.SocketError.ToString();
                    // Ensure the socket is flagged unavailable
                    hostSocket = null;
                }

                transferDoneFlag.Set();
            });

            transferDoneFlag.Reset();

            hostSocket.ConnectAsync(socketEventArgs);

            transferDoneFlag.WaitOne(MESSAGE_TIMEOUT_MSECS);
            return response;
        }

        /// <summary>
        /// Sends a message to an open TCP port
        /// Will return an error if the port has not been opened
        /// </summary>
        /// <param name="message">Text message to send</param>
        /// <returns>empty string if successful, otherwise a text error message</returns>
        private static string SendMessageTCP(string message)
        {
            if (hostSocket == null) return "Send socket not open";

            string response = "Connect timed out";

            SocketAsyncEventArgs socketEventArg = new SocketAsyncEventArgs();
            socketEventArg.RemoteEndPoint = hostSocket.RemoteEndPoint;

            // Add the data to be sent into the buffer
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            socketEventArg.SetBuffer(messageBytes, 0, messageBytes.Length);

            // Inline event handler for the Completed event.
            // Note: This event handler was implemented inline in order to make this method self-contained.
            socketEventArg.Completed += new EventHandler<SocketAsyncEventArgs>(delegate (object s, SocketAsyncEventArgs e)
            {
                if (e.SocketError == SocketError.Success)
                {
                    response = "";
                }
                else
                {
                    // Retrieve the result of this request
                    response = e.SocketError.ToString();
                    CloseTCP();
                }

                // Signal that the request is complete, unblocking the UI thread
                transferDoneFlag.Set();
            });

            transferDoneFlag.Reset();

            hostSocket.SendAsync(socketEventArg);

            transferDoneFlag.WaitOne(MESSAGE_TIMEOUT_MSECS);

            return response;
        }

        /// <summary>
        /// Receives a message from an open TCP port.
        /// </summary>
        /// <param name="message">message received, empty string if nothing received</param>
        /// <returns>empty string if successful, otherwise a text error message</returns>
        private static string ReceiveMessageTCP(out string message)
        {
            message = "";

            if (hostSocket == null) return "Send socket not open";

            string response = "Receive timed out";
            string result = "";

            SocketAsyncEventArgs socketEventArg = new SocketAsyncEventArgs();
            socketEventArg.RemoteEndPoint = hostSocket.RemoteEndPoint;

            // Create a buffer for the response
            byte[] responseBytes = new Byte[MAX_BUFFER_SIZE];
            socketEventArg.SetBuffer(responseBytes, 0, MAX_BUFFER_SIZE);

            // Bind a handler to the reply received event
            socketEventArg.Completed += new EventHandler<SocketAsyncEventArgs>(delegate (object s, SocketAsyncEventArgs e)
            {
                if (e.SocketError == SocketError.Success)
                {
                    response = "";
                    if (e.BytesTransferred > 0)
                    {
                        // Retrieve the data from the buffer
                        result = Encoding.UTF8.GetString(e.Buffer, e.Offset, e.BytesTransferred);
                        result = result.Trim('\0');
                    }
                }
                else
                {
                    response = e.SocketError.ToString();
                }

                transferDoneFlag.Set();
            });

            transferDoneFlag.Reset();

            hostSocket.ReceiveAsync(socketEventArg);

            transferDoneFlag.WaitOne(MESSAGE_TIMEOUT_MSECS);

            message = result;

            return response;
        }


        /// <summary>
        /// Closes an open connection
        /// </summary>
        static void CloseTCP()
        {
            if (hostSocket != null)
            {
                hostSocket.Close();
                hostSocket = null;
            }
        }

        #endregion

        private static string RequestWebPage(string url, string page, out string pageContent)
        {
            pageContent = "";

            // Set up the connectiopn
            string response = ConnectTCP(url, 80);

            if (response != "")
            {
                return response;
            }

            // Send the page request using the Get command
            response = SendMessageTCP("GET " + page + " HTTP/1.1\r\nHost: " + url + "\r\nConnection: Close\r\n\r\n");

            if (response != "")
            {
                CloseTCP();
                return response;
            }

            // Repeatedly ask the server for packets until we 
            // get an empty one sent back
            string wholePage = "";
            string fetchText;

            do
            {
                response = ReceiveMessageTCP(out fetchText);

                if (response != "")
                {
                    CloseTCP();
                    return response;
                }

                if (fetchText == "") break;

                // Note - this is prone to corrupt the data if a UTF8 value 
                // spans two bytes which are broken by a transfer
                // Use the byte transfer version to resolve this

                wholePage = wholePage + fetchText;
            } while (true);

            pageContent = wholePage;

            CloseTCP();

            return response;
        }

        static void Main(string[] args)
        {
            string response;
            string webPageText;

            response = RequestWebPage("http://bbc.co.uk", "", out webPageText);
            Console.WriteLine(response);
            Console.WriteLine(webPageText);
            Console.ReadKey();

            HttpWebRequest w = new HttpWebRequest
            WebRequest x = WebRequest.Create("url");
        }
    }
}
