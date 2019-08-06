using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Phoenix.Client.EventArgs;
using Phoenix.Server.EventArgs;

namespace Phoenix.Server
{

    /// <summary>
    /// This is the work horse of Phoenix.
    /// </summary>
    public class Server
    {

        #region variables

        /// <summary>
        /// This is the underlying tcp listener
        /// that handles incoming connections.
        /// </summary>
        private TcpListener _listener;

        /// <summary>
        /// A private list of the connected clients.
        /// </summary>
        private List<Client.Client> _clients;

        /// <summary>
        /// The server has been told to shutdown.
        /// </summary>
        private bool _shutdown;

        #endregion

        #region constructors

        /// <summary>
        /// This will initialize Phoenix.
        /// </summary>
        public Server()
        {
            _listener = new TcpListener(System.Net.IPAddress.Any, 2500);
            _clients = new List<Client.Client>();
            _shutdown = false;
        }

        /// <summary>
        /// This will initialize Phoenix on the specified port.
        /// </summary>
        /// <param name="port">The port to initialize Phoenix on.</param>
        public Server(int port)
        {
            _listener = new TcpListener(System.Net.IPAddress.Any, port);
            _clients = new List<Client.Client>();
            _shutdown = false;
        }

        /// <summary>
        /// This will initialize Phoenix on the specified port.
        /// </summary>
        /// <param name="ip">The IP Address to bind Phoenix on.</param>
        /// <param name="port">The port to initialize Phoenix on.</param>
        public Server(string ip, int port)
        {
            _listener = new TcpListener(System.Net.IPAddress.Parse(ip), port);
            _clients = new List<Client.Client>();
            _shutdown = false;
        }

        #endregion

        #region events

        #region disconnect

        /// <summary>
        /// This event is raised whenever someone disconnects.
        /// </summary>
        public event ClientDisconnectedEventHandler ClientDisconnected = delegate { };

        /// <summary>
        /// This event is raised whenever the client disconnects.
        /// </summary>
        /// <param name="sender">The originating client</param>
        /// <param name="e">Contains important information on who disconnects.</param>
        /// <remarks></remarks>
        public delegate void ClientDisconnectedEventHandler(object sender, PhoenixServerClientDisconnectedEventArgs e);

        #endregion

        #region connection

        /// <summary>
        /// This event is raised whenever someone connects.
        /// </summary>
        public event ClientConnectedEventHandler ClientConnected = delegate { };

        /// <summary>
        /// This event is raised whenever a client connects.
        /// </summary>
        /// <param name="sender">The originating client</param>
        /// <param name="e">Contains connection information.</param>
        /// <remarks></remarks>
        public delegate void ClientConnectedEventHandler(object sender, PhoenixServerClientConnectedEventArgs e);

        #endregion

        #region data receieved

        /// <summary>
        /// This event is raised whenever a client recieves information.
        /// </summary>
        public event ClientDataReceievedEventHandler ClientDataReceieved = delegate { };

        /// <summary>
        /// This event is raised whenever a client recieves information.
        /// </summary>
        /// <param name="sender">The originating client</param>
        /// <param name="e">Contains data.</param>
        /// <remarks></remarks>
        public delegate void ClientDataReceievedEventHandler(object sender, PhoenixServerClientDataReceievedEventArgs e);

        #endregion

        #region exception

        /// <summary>
        /// This event is raised whenever someone disconnects.
        /// </summary>
        public event ClientExceptionEventHandler ClientException = delegate { };

        /// <summary>
        /// This event is raised whenever the client disconnects.
        /// </summary>
        /// <param name="sender">The originating client</param>
        /// <param name="e">Contains important information on who disconnects.</param>
        /// <remarks></remarks>
        public delegate void ClientExceptionEventHandler(object sender, PhoenixServerClientExceptionEventArgs e);

        #endregion

        #endregion

        #region routines

        /// <summary>
        /// Initializes Phoenix to begin accepting connections.
        /// </summary>
        public void Start()
        {
            // _listener.AllowNatTraversal(true);
            _listener.Start();
            _listener.BeginAcceptTcpClient(OnIncomingConnection, null);
        }

        /// <summary>
        /// Shuts down Phoenix.
        /// </summary>
        public void Stop()
        {

            _shutdown = true;
            _listener.Stop();

            // loop backwards
            lock(_clients)
            {
                for (var i = 0; i < _clients.Count; i++)
                {
                    _clients[i].Disconnect();
                }
            }

        }

        #endregion

        #region client handles

        /// <summary>
        /// This is utilized whenever a client crashes.
        /// </summary>
        /// <param name="sender">This is the client.</param>
        /// <param name="phoenixClientExceptionEventArgs">This contains the client information.</param>
        private void PClientOnException(object sender, PhoenixClientExceptionEventArgs phoenixClientExceptionEventArgs)
        {

            // raise the event.
            ClientException(this,
                            new PhoenixServerClientExceptionEventArgs
                            {
                                Client = sender as Client.Client,
                                Exception = phoenixClientExceptionEventArgs.Exception
                            });

            lock(_clients)
            {
                // remove the client
                _clients.Remove(sender as Client.Client);    
            }

            // assert the not null value of the client.
            var client = sender as Client.Client;
            if (client != null)
            {
                // unhinge events
                client.DataReceived -= PClientOnDataReceived;
                client.Disconnected -= PClientOnDisconnected;
                client.Exception -= PClientOnException;
            }

        }

        /// <summary>
        /// This is utilized whenever a client disconnects.
        /// </summary>
        /// <param name="sender">This is the client.</param>
        /// <param name="eventArgs"></param>
        private void PClientOnDisconnected(object sender, System.EventArgs eventArgs)
        {
            ClientDisconnected(this, new PhoenixServerClientDisconnectedEventArgs { Client = sender as Client.Client });

            lock (_clients)
            {
                // remove the client
                _clients.Remove(sender as Client.Client);
            }

            // assert the not null value of the client.
            var client = sender as Client.Client;
            if (client != null)
            {
                // unhinge events
                client.DataReceived -= PClientOnDataReceived;
                client.Disconnected -= PClientOnDisconnected;
                client.Exception -= PClientOnException;
            }

        }

        /// <summary>
        /// This routine is used whenever a client gets data.
        /// </summary>
        /// <param name="sender">This is the client.</param>
        /// <param name="phoenixClientDataReceievedEventArgs">This contains the data receieved.</param>
        private void PClientOnDataReceived(object sender, PhoenixClientDataReceievedEventArgs phoenixClientDataReceievedEventArgs)
        {
            // raise the event.
            ClientDataReceieved(this,
                                new PhoenixServerClientDataReceievedEventArgs { Client = sender as Client.Client, Data = phoenixClientDataReceievedEventArgs.Data });
        }

        #endregion

        #region overridables

        /// <summary>
        /// This is called whenever the listener has received a connection.
        /// </summary>
        /// <param name="iResult">The AsyncResult.</param>
        public virtual void OnIncomingConnection(IAsyncResult iResult)
        {

            // Do this check
            if (!_shutdown && iResult.IsCompleted)
            {
                
                // Handle the connection
                var client = _listener.EndAcceptTcpClient(iResult);
                
                // create the new client
                var pClient = new Client.Client(client);

                lock (_clients)
                {
                    // add the client
                    _clients.Add(pClient);
                }

                // attach event handlers
                pClient.DataReceived += PClientOnDataReceived;
                pClient.Disconnected += PClientOnDisconnected;
                pClient.Exception += PClientOnException;

                // Raise an Event
                ClientConnected(this, new PhoenixServerClientConnectedEventArgs {Client = pClient});

                // Begin reading
                pClient.BeginRead();

                // We have the client, go back to listening
                _listener.BeginAcceptTcpClient(OnIncomingConnection, null);

            }

        }

        #endregion

    }

}

namespace Phoenix.Server.EventArgs
{
    
    /// <summary>
    /// This event argument class is utilized only when a client has connected.
    /// </summary>
    public class PhoenixServerClientConnectedEventArgs : System.EventArgs
    {

        /// <summary>
        /// This is the client that has connected to the server.
        /// </summary>
        public Client.Client Client { get; set; }

    }

    /// <summary>
    /// This event argument class is used whenever a client has disconnected from the server.
    /// </summary>
    public class PhoenixServerClientDisconnectedEventArgs : System.EventArgs
    {

        /// <summary>
        /// This is the client that has disconnected.
        /// </summary>
        public Client.Client Client { get; set; }

    }

    /// <summary>
    /// This event argument class is used whenever a client has crashed or thrown an exception.
    /// </summary>
    public class PhoenixServerClientExceptionEventArgs : System.EventArgs
    {

        /// <summary>
        /// This is the client that has thrown an exception.
        /// </summary>
        public Client.Client Client { get; set; }

        /// <summary>
        /// This is the exception data that was thrown.
        /// </summary>
        public Exception Exception { get; set; }

    }

    /// <summary>
    /// This event argument class is used whenever a client has receieved data to be processed.
    /// </summary>
    public class PhoenixServerClientDataReceievedEventArgs : System.EventArgs
    {

        /// <summary>
        /// This is the client that has receieved the data.
        /// </summary>
        public Client.Client Client { get; set; }

        /// <summary>
        /// This is the data that has been receieved.
        /// </summary>
        public byte[] Data { get; set; }

    }
    
}
