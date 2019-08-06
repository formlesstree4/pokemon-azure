using System;
using System.Linq;
using System.Collections.Generic;
using Mercury.Classes;
using Phoenix.Server;

namespace Mercury
{

    /// <summary>
    /// This class handles output events.
    /// </summary>
    public class MercuryOutputEventArgs
    {

        /// <summary>
        /// The output string.
        /// </summary>
        public string Output { get; set; }

    }

    /// <summary>
    /// This class handles error messages.
    /// </summary>
    public class MercuryErrorEventArgs
    {

        /// <summary>
        /// The exception for the crash.
        /// </summary>
        public Exception Exception { get; set; }
        
        /// <summary>
        /// The error message.
        /// </summary>
        public string Message { get; set; }

    }

    /// <summary>
    /// The main Mercury class.
    /// </summary>
    public class Mercury : IDisposable
    {

        #region variables and events

        // private readonly RattleSnakeServer _rattleSnakeServer;
        private Server _phoenixServer;
        
        private Dictionary<Phoenix.Client.Client, LoginData> _connections;

        public delegate void MercuryConsoleOutput(MercuryOutputEventArgs output);
        public event MercuryConsoleOutput Output;

        public delegate void MercuryErrorOutput(MercuryErrorEventArgs error);
        public event MercuryErrorOutput Error;

        private readonly int _port = 2500;

        #endregion

        #region constructors

        public Mercury()
        {

        }
        public Mercury(int port)
        {
            _port = port;
        }

        #endregion

        #region routines

        /// <summary>
        /// Initializes the server.
        /// </summary>
        public void Start()
        {

            _phoenixServer = new Server(_port);
            _connections = new Dictionary<Phoenix.Client.Client, LoginData>();
            Database.Buffer.Initialize();
            Database.SearchTracker.Initialize();
            SetEvents();
            _phoenixServer.Start();
            Output(new MercuryOutputEventArgs { Output = "Server was started successfully!" });

        }

        /// <summary>
        /// Stops the server and disposes of it.
        /// </summary>
        public void Stop()
        {

            Output(new MercuryOutputEventArgs { Output = "Server was stopped!" });

            // Pause the server
            // Pause();

            // Call dispose
            Dispose();

        }

        /// <summary>
        /// Pauses the server without disposing it.
        /// </summary>
        [Obsolete]
        public void Pause()
        {
            
        }

        /// <summary>
        /// When the server is first created, this routine will attach event listeners to the underlying RattleSnake server.
        /// </summary>
        private void SetEvents()
        {
            _phoenixServer.ClientDataReceieved += IncomingMessage;
            _phoenixServer.ClientConnected += IncomingConnection;
            _phoenixServer.ClientDisconnected += Disconnection;
            _phoenixServer.ClientException += ClientException;
        }

        /// <summary>
        /// When the server is stopped, this routine will attach listeners 
        /// </summary>
        private void RemEvents()
        {
            _phoenixServer.ClientDataReceieved -= IncomingMessage;
            _phoenixServer.ClientConnected -= IncomingConnection;
            _phoenixServer.ClientDisconnected -= Disconnection;
            _phoenixServer.ClientException -= ClientException;
        }
        private bool IsLoggedIn(Phoenix.Client.Client phoenixClient)
        {
            try
            {
                return _connections[phoenixClient].LoggedIn;
            }
            catch (Exception ex)
            {
                Error(new MercuryErrorEventArgs {Exception = ex, Message = "Error checking this!"});
                return false;
            }
            
        }
        private void SetProperties(Phoenix.Client.Client client, Guid id, bool loggedIn)
        {
            var loginData = _connections[client];
            loginData.ID = id;
            loginData.LoggedIn = loggedIn;
            _connections[client] = loginData;
        }
        private void LoginCheck(Phoenix.Client.Client client, byte[] data)
        {

            Output(new MercuryOutputEventArgs {Output = "Login Routine called"});

            var loginStructure = new Login();
            loginStructure.Initialize(data);

            // Check to see if the ID exists
            if (Database.Buffer.Exists(loginStructure.ID))
            {
                // Exists; make sure pass is good.
                if (Database.Buffer.Login(loginStructure.ID, loginStructure.Password))
                {
                    // Good login.
                    SetProperties(client, loginStructure.ID, true);

                    client.Send(new Response { Resp = Responses.LoginGood }.ToByteArray());
                }
                else
                {
                    // Bad login.
                    client.Send(new Response { Resp = Responses.LoginBounced }.ToByteArray());
                }
            }
            else
            {
                // Register the ID
                Database.Buffer.Register(loginStructure.ID, loginStructure.Password);
                SetProperties(client, loginStructure.ID, true);
                client.Send(new Response { Resp = Responses.LoginGood }.ToByteArray());
            }

        }

        #endregion

        #region server routines

        private void IncomingMessage(object sender, Phoenix.Server.EventArgs.PhoenixServerClientDataReceievedEventArgs e)
        {

            Output(new MercuryOutputEventArgs { Output = "Incoming Message from client." });
            if(IsLoggedIn(e.Client))
            {
                // We can do everything pretty much.
                // All but login structures will be
                // accepted.
                try
                {
                    switch (e.Data[0])
                    {
                        #region Search Request
                        case Constants.SearchRequestHeader:

                            // Define some variables
                            var sRequest = new SearchRequest();
                            var sResults = new SearchResults();

                            // Initialize the request
                            sRequest.Initialize(e.Data);

                            // Structure got.
                            Output(new MercuryOutputEventArgs { Output = string.Format("Search Request from {0} ({1})", e.Client.IP, _connections[e.Client].ID) });

                            // Search.
                            var resultID = Database.Buffer.Search(sRequest, _connections[e.Client].ID);

                            // Grab the results now.
                            var pkmnList = Database.SearchTracker.GetResults(resultID).ToArray();
                            sResults.Pokemon = pkmnList;
                            sResults.ID = resultID;

                            // Ship the results back.
                            e.Client.Send(sResults.ToByteArray());

                            break;
                        #endregion
                        #region Uploading
                        case Constants.UploadHeader:

                            // Get the structure.
                            var uploadedPkmn = new Upload();
                            uploadedPkmn.Initialize(e.Data);
                            uploadedPkmn.Pokemon.ID = Guid.NewGuid();

                            // Perform some authentication...ala hack checks
                            if (uploadedPkmn.Pokemon.Requirements.MaxLevel < uploadedPkmn.Pokemon.Requirements.MinLevel)
                                e.Client.Send(new Response { Resp = Responses.UploadBounced }.ToByteArray());
                            else
                            {
                                // Done!
                                Output(new MercuryOutputEventArgs
                                           {
                                               Output =
                                                   string.Format("Upload from {0} ({1})", e.Client.IP,
                                                                 _connections[e.Client].ID)
                                           });

                                // Make sure they don't have a pokemon already
                                if (Database.Buffer.OwnerRequest(_connections[e.Client].ID) !=
                                    Database.Buffer.Request.OwnerHasNone)
                                    e.Client.Send(new Response {Resp = Responses.UploadBounced}.ToByteArray());
                                else
                                {
                                    Database.Buffer.InsertPokemon(uploadedPkmn.Pokemon, _connections[e.Client].ID);
                                    e.Client.Send(new Response {Resp = Responses.UploadGood}.ToByteArray());
                                }
                            }
                            break;
                        #endregion
                        #region Client Request
                        case Constants.RequestHeader:

                            // Get the structure.
                            var request = new Request();
                            request.Initialize(e.Data);

                            // Done!
                            Output(new MercuryOutputEventArgs { Output = string.Format("Request from {0} ({1})", e.Client.IP, _connections[e.Client].ID) });

                            switch (request.ClientRequest)
                            {
                                case Requests.Check:
                                    switch (Database.Buffer.OwnerRequest(_connections[e.Client].ID))
                                    {
                                        case Database.Buffer.Request.OwnerHasOriginal:
                                            e.Client.Send(new Response { Resp = Responses.OldPokemon }.ToByteArray());
                                            break;
                                        case Database.Buffer.Request.OwnerHasNew:
                                            e.Client.Send(new Response { Resp = Responses.NewPokemon }.ToByteArray());
                                            break;
                                        case Database.Buffer.Request.OwnerHasNone:
                                            e.Client.Send(new Response { Resp = Responses.NoPokemon }.ToByteArray());
                                            break;
                                    }
                                    break;
                                case Requests.GetPokemon:

                                    // let's search the database
                                    switch (Database.Buffer.OwnerRequest(_connections[e.Client].ID))
                                    {
                                        case Database.Buffer.Request.OwnerHasOriginal:
                                        case Database.Buffer.Request.OwnerHasNew:
                                            var poke = Database.Buffer.GetPokemonByOwner(_connections[e.Client].ID);
                                            e.Client.Send(new Upload { Pokemon = poke }.ToByteArray());
                                            Database.Buffer.RemovePokemon(poke.ID);
                                            break;
                                        case Database.Buffer.Request.OwnerHasNone:
                                            e.Client.Send(new Response { Resp = Responses.NoPokemon }.ToByteArray());
                                            break;
                                    }


                                    break;
                            }
                            break;
                        #endregion
                        #region Additional Searching
                        case Constants.AdditionalSearchHeader:

                            var additional = new AdditionalResults();
                            additional.Initialize(e.Data);

                            // Grab the structure
                            Output(new MercuryOutputEventArgs { Output = string.Format("Additional Search Results requested from {0} ({1})", e.Client.IP, _connections[e.Client].ID) });

                            var results = Database.SearchTracker.GetResults(additional.SearchID).ToArray();
                            var addResults = new SearchResults { Pokemon = results, ID = additional.SearchID };

                            e.Client.Send(addResults.ToByteArray());

                            break;
                        #endregion
                        #region Trading
                        case Constants.TradeHeader:

                            // Get the structure.
                            var trade = new Trade();
                            trade.Initialize(e.Data);
                            trade.Pokemon.ID = Guid.NewGuid();

                            Output(new MercuryOutputEventArgs { Output = string.Format("Trade from {0} ({1})", e.Client.IP, _connections[e.Client].ID) });
                            
                            // Make sure the Pokemon to trade exists
                            if (!Database.Buffer.PokemonExists(trade.ID))
                                // Error out, fuck everything
                                e.Client.Send(new Response { Resp = Responses.Error }.ToByteArray());
                            else
                            {
                                
                                // Add the new pokemon in
                                Database.Buffer.InsertPokemon(trade.Pokemon, _connections[e.Client].ID);

                                // perform the trade
                                Database.Buffer.PerformTrade(trade.ID, trade.Pokemon.ID, _connections[e.Client].ID);

                                // give it back
                                var pkmn = Database.Buffer.GetPokemon(trade.ID);
                                e.Client.Send(new Upload { Pokemon = pkmn }.ToByteArray());

                                // Now remove it
                                Database.Buffer.RemovePokemon(pkmn.ID);

                            }

                            break;
                        #endregion
                    }
                }
                catch (Exception ex)
                {
                    Error(new MercuryErrorEventArgs { Exception = ex, Message = "Error during processing of message" });
                    e.Client.Send(new Response { Resp = Responses.Error }.ToByteArray());
                }
                

            }
            else
            {
                #region Login Check

                try
                {
                    if (!e.Data[0].Equals(Constants.LoginHeader))
                    {
                        Output(new MercuryOutputEventArgs { Output = "Failure to Login!" });
                        e.Client.Disconnect();
                    }
                    else
                    {
                        Output(new MercuryOutputEventArgs { Output = "Performing Login Check..." });
                        LoginCheck(e.Client, e.Data);
                    }
                }
                catch (Exception ex)
                {
                    Error(new MercuryErrorEventArgs { Exception = ex, Message = "Error during processing of login" });
                    // throw;
                }
                
                
                #endregion
            }
        }
        private void IncomingConnection(object sender, Phoenix.Server.EventArgs.PhoenixServerClientConnectedEventArgs e)
        {
            // Lock the keys.
            lock (_connections.Keys)
            {
                // Output(new MercuryOutputEventArgs { Output = "Client Connection" });
                // Check to see if the connection exists already, if so, we're going to
                // ignore the connection attempt and disconnect them. No point in trying
                // to fineagle with a stupid connection.
                if (!_connections.Keys.Contains(e.Client))
                {
                    
                    Output(new MercuryOutputEventArgs { Output = "Added to the connection list." });
                    _connections.Add(e.Client, new LoginData { ID = Guid.NewGuid(), LoggedIn = false });
                    Output(new MercuryOutputEventArgs { Output = "Sending the connection information." });
                    e.Client.Send(new Response { Resp = Responses.Connected }.ToByteArray());
                }
                //else
                //{
                //    Output(new MercuryOutputEventArgs { Output = "Disconnecting client; duplicate detected." });
                //    e.Client.Disconnect();
                //}
                    

            }

        }
        private void Disconnection(object sender, Phoenix.Server.EventArgs.PhoenixServerClientDisconnectedEventArgs e)
        {
            lock (_connections)
            { if (_connections.Keys.Contains(e.Client)) _connections.Remove(e.Client); Output(new MercuryOutputEventArgs { Output = "Client Disconnected!" }); }
        }
        private void ClientException(object sender, Phoenix.Server.EventArgs.PhoenixServerClientExceptionEventArgs e)
        {
            lock (_connections)
                if(_connections.Keys.Contains(e.Client)) _connections.Remove(e.Client);
            Error(new MercuryErrorEventArgs { Exception = e.Exception, Message = "Client has raised an exception!" });
        }

        #endregion

        #region disposal stuff

        public void Dispose()
        {
            Database.Buffer.Dispose();
            _phoenixServer.Stop();
            // _connections.Clear();
            RemEvents();
        }

        #endregion

    }

}
