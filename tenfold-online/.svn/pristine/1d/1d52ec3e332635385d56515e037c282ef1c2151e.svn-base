using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using Phoenix.Client.EventArgs;

namespace Phoenix.Client
{

    /// <summary>
    /// The client side of Phoenix.
    /// </summary>
    public class Client
    {

        #region variables

        /// <summary>
        /// This is our client that holds the underlying connection.
        /// </summary>
        private TcpClient _client;

        /// <summary>
        /// The ip address the client is connected to.
        /// </summary>
        private string _ip;

        /// <summary>
        /// The port that the client is connected to.
        /// </summary>
        private int _port;

        /// <summary>
        /// Local variable used inside the event; it keeps firing twice so this is a temporary fix.
        /// </summary>
        private bool _disconnected;

        #endregion

        #region properties

        /// <summary>
        /// Returns the IP address that this client is connected to.
        /// </summary>
        public string IP
        {
            get { return _ip; }
            set { System.Diagnostics.Debug.WriteLine(value); }
        }

        /// <summary>
        /// Returns the port number that the client is attached to.
        /// </summary>
        public int Port
        {
            get { return _port; }
            set { System.Diagnostics.Debug.WriteLine(value); }
        }

        /// <summary>
        /// The unique id of the client
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Returns if the client is connected or not.
        /// </summary>
        public bool Connected
        {
            get { return _client != null && _client.Connected; }
        }

        #endregion

        #region constructors

        /// <summary>
        /// Creates a new Phoenix Client to keep track of the TcpClient.
        /// </summary>
        /// <param name="connectedClient">The connected TcpClient.</param>
        public Client(TcpClient connectedClient)
        {
            
            // hold onto the client.
            _client = connectedClient;

            // Unique identification.
            ID = Guid.NewGuid();

            // store the ip and port
            var ipend = (IPEndPoint)connectedClient.Client.RemoteEndPoint;
            _ip = ipend.Address.ToString();
            _port = ipend.Port;

        }

        /// <summary>
        /// Creates a new Phoenix Client that has no connection.
        /// </summary>
        public Client()
        {

            // Unique identification.
            ID = Guid.NewGuid();

        }

        #endregion

        #region routines

        /// <summary>
        /// Performs a connection to a remote server.
        /// </summary>
        /// <param name="ip">The remote IP address (IPv4) to connect to.</param>
        /// <param name="port">The remote port to connect to.</param>
        public void Connect(string ip, int port)
        {

            if (_client == null || !_client.Connected)
            {
                // check
                _disconnected = false;
                _client = new TcpClient();
                _client.Client.BeginConnect(ip, port, OnConnectionEstablished, null);
            }

        }

        /// <summary>
        /// Performs a disconnection routine.
        /// </summary>
        public void Disconnect()
        {
            if (_client.Connected)
                Send(new[] { (byte)255, (byte)255, (byte)255 });
        }

        /// <summary>
        /// Sends data across the network to the connected server.
        /// </summary>
        /// <param name="data">The data to send.</param>
        /// <param name="async">If this is true, the data will be send asynchronously. 
        /// If this is false, the method will block until all data is sent.</param>
        public void Send(byte[] data, bool async = true)
        {
            
            // okay, make sure we're connected
            if(_client.Connected)
            {
                
                // switch
                if (async)
                    _client.Client.BeginSend(data, 0, data.Length, SocketFlags.None, OnDataSent, data);
                else
                {
                    _client.Client.Send(data, 0, 0, SocketFlags.None);
                }

            }

        }

        /// <summary>
        /// This routine will tell the client to start listening for incoming data.
        /// </summary>
        public void BeginRead()
        {

            try
            {
                // check
                if (!_client.Connected) return;

                // define the buffer
                var buffer = new byte[_client.ReceiveBufferSize];

                // buffer defined, get ready.
                _client.Client.BeginReceive(buffer, 0, _client.ReceiveBufferSize, SocketFlags.None, OnDataReceieved,
                                            buffer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                // throw;
            }

        }

        #endregion

        #region overridables?

        /// <summary>
        /// This routine is called whenever the client has successfully established a connection.
        /// </summary>
        /// <param name="iResult">The result of the connection.</param>
        public virtual void OnConnectionEstablished(IAsyncResult iResult)
        {

            try
            {

                // check to see if everything is okay
                if (iResult.IsCompleted)
                {

                    // connection established, go ahead and stop
                    _client.Client.EndConnect(iResult);

                    // grab the data
                    var ipend = (IPEndPoint)_client.Client.RemoteEndPoint;
                    _ip = ipend.Address.ToString();
                    _port = ipend.Port;

                    // read
                    BeginRead();

                    // raise the event
                    ConnectionEstablished(this, new System.EventArgs());
                }

            }
            catch (ArgumentException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            catch (Exception e)
            {
                Exception(this, new PhoenixClientExceptionEventArgs { Exception = e });
            }
            

        }

        /// <summary>
        /// This routine is raised whenever data is successfully receieved.
        /// </summary>
        /// <param name="iResult">The results of the data.</param>
        public virtual void OnDataReceieved(IAsyncResult iResult)
        {

            try
            {
                // end the read
                var length = _client.Client.EndReceive(iResult);

                // okay, if we do get disconnected, this length may equal zero.
                // so we need to check if we're still connected.
                if ((length.Equals(0) || !_client.Connected) && iResult.IsCompleted)
                {                   
                    // raise disconnected event
                    if(!_disconnected) Disconnected(this, new System.EventArgs());
                }
                else
                {

                    // let's grab the buffer of data
                    var buffer = (byte[]) iResult.AsyncState;

                    // resize
                    Array.Resize(ref buffer, length);

                    // now let's go ahead and format a List<byte>
                    var bufferList = new List<byte>(buffer);

                    // loop for more data
                    while (_client.Available > 0 && _client.GetStream().CanRead)
                    {

                        // define a new buffer
                        buffer = new byte[_client.Available];

                        // read
                        length = _client.Client.Receive(buffer, 0, _client.Available, SocketFlags.None);

                        // resize
                        Array.Resize(ref buffer, length);

                        // add.
                        bufferList.AddRange(buffer);

                    }

                    // Perform this check
                    if (bufferList.Count.Equals(3))
                    {
                        if(bufferList[0].Equals(255) && bufferList[1].Equals(255) && bufferList[2].Equals(255))
                        {
                            // we were just disconnected.
                            _client.Client.BeginDisconnect(false, OnDisconnect, null);
                        }
                    }
                    else
                    {
                        // All done; post and begin reading again.
                        DataReceived(this, new PhoenixClientDataReceievedEventArgs {Data = bufferList.ToArray()});

                        // Start reading again
                        BeginRead();
                    }

                }
            }
            catch (Exception e)
            {
                // if a disconnection call was already made, then this wouldn't matter.
                if (_client.Connected)
                {
                    // pass up the exception
                    Exception(this, new PhoenixClientExceptionEventArgs {Exception = e});
                }
            }

        }

        /// <summary>
        /// This routine is raised whenever the cilent disconnects.
        /// </summary>
        /// <param name="iResult">The disconnection results.</param>
        public virtual void OnDisconnect(IAsyncResult iResult)
        {

            // end!
            _client.Client.EndDisconnect(iResult);

            // check
            if (_disconnected) return;

            // go ahead and flip the variable
            _disconnected = true;

            // last but not least...
            Disconnected(this, new System.EventArgs());

        }

        /// <summary>
        /// this routine is fired whenever data has finished sending.
        /// </summary>
        /// <param name="iResult">The AsyncResult</param>
        public virtual void OnDataSent(IAsyncResult iResult)
        {
            
            // end the send
            _client.Client.EndSend(iResult);

            // grab the data for whatever reason...
            var data = iResult.AsyncState as byte[];

            // Check
            if(data != null && (data.Length.Equals(3) && data[0].Equals(255) && data[1].Equals(255) && data[2].Equals(255)))
                _client.Client.BeginDisconnect(false, OnDisconnect, null);
            else
                DataSent(this, new PhoenixClientDataSentEventArgs { Data = data });    

        }

        #endregion

        #region events

        #region established

        public event ConnectionEstablishedEventHandler ConnectionEstablished = delegate { };

        /// <summary>
        /// This event is raised whenever the connection to the remote server is successfully established.
        /// </summary>
        /// <param name="sender">The originating client.</param>
        /// <param name="e">The event arguments that are used to transmit additional information.</param>
        /// <remarks></remarks>
        public delegate void ConnectionEstablishedEventHandler(object sender, System.EventArgs e);

        #endregion

        #region got data

        public event DataReceivedEventHandler DataReceived = delegate { };

        /// <summary>
        /// This event is raised whenever the client receives data on the stream.
        /// </summary>
        /// <param name="sender">The originating client.</param>
        /// <param name="e">The event arguments that contain the received data.</param>
        /// <remarks></remarks>
        public delegate void DataReceivedEventHandler(object sender, PhoenixClientDataReceievedEventArgs e);

        #endregion

        #region crash

        public event ExceptionEventHandler Exception = delegate { };

        /// <summary>
        /// This event is raised whenever the client throws an exception that cannot be handled.
        /// </summary>
        /// <param name="sender">The originating client.</param>
        /// <param name="e">The event argument that contains the exception data.</param>
        /// <remarks>This event is usually raised when there is a connection issue.</remarks>
        public delegate void ExceptionEventHandler(object sender, PhoenixClientExceptionEventArgs e);

        #endregion

        #region disconnected

        public event DisconnectedEventHandler Disconnected = delegate { };

        /// <summary>
        /// This event is raised whenever the client disconnects.
        /// </summary>
        /// <param name="sender">The originating client</param>
        /// <param name="e">Generic, blank disconnection routines.</param>
        /// <remarks></remarks>
        public delegate void DisconnectedEventHandler(object sender, System.EventArgs e);

        #endregion

        #region sent data

        public event DataSentEventHandler DataSent = delegate { };

        /// <summary>
        /// This event is raised whenever the client finishes sending data.
        /// </summary>
        /// <param name="sender">The originating client.</param>
        /// <param name="e">Generic EventArgs</param>
        /// <remarks></remarks>
        public delegate void DataSentEventHandler(object sender, PhoenixClientDataSentEventArgs e);

        #endregion

        #endregion

    }

}

namespace Phoenix.Client.EventArgs
{

    /// <summary>
    /// These event arguments are for when data is receieved.
    /// </summary>
    public class PhoenixClientDataReceievedEventArgs : System.EventArgs
    {

        /// <summary>
        /// This is the data that was receieved.
        /// </summary>
        public byte[] Data { get; set; }

    }

    /// <summary>
    /// These event arguments are used only when the client crashes out.
    /// </summary>
    public class PhoenixClientExceptionEventArgs : System.EventArgs
    {

        /// <summary>
        /// This is the exception data from the client crash.
        /// </summary>
        public Exception Exception { get; set; }

    }

    /// <summary>
    /// These event arguments are used whenever data is finished sending.
    /// </summary>
    public class PhoenixClientDataSentEventArgs : System.EventArgs
    {

        /// <summary>
        /// This is the data that was sent.
        /// </summary>
        public byte[] Data { get; set; }

    }

}
