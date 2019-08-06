using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Generic;

namespace Mercury
{
    public static class Constants
    {

        /// <summary>
        /// This is the header for all login requests
        /// </summary>
        public const byte LoginHeader = 0;

        /// <summary>
        /// This is the header for all search requests.
        /// </summary>
        public const byte SearchRequestHeader = 1;

        /// <summary>
        /// This is the header for all search results.
        /// </summary>
        public const byte SearchResultsHeader = 2;

        /// <summary>
        /// This is the header for all uploads.
        /// </summary>
        public const byte UploadHeader = 3;

        /// <summary>
        /// This is the header for all server responses.
        /// </summary>
        public const byte ResponseHeader = 4;

        /// <summary>
        /// This is the header for all check requests.
        /// </summary>
        public const byte RequestHeader = 5;

        /// <summary>
        /// This is the header for all additional results request.
        /// </summary>
        public const byte AdditionalSearchHeader = 6;

        /// <summary>
        /// This is the header for a SearchPokemon.
        /// </summary>
        public const byte SearchPokemonHeader = 7;

        /// <summary>
        /// This is the requirements header.
        /// </summary>
        public const byte RequirementsHeader = 8;

        /// <summary>
        /// This is the trade header.
        /// </summary>
        public const byte TradeHeader = 9;

        /// <summary>
        /// This is the maximum number of search results allowed to go out.
        /// </summary>
        public const int MaxResults = 5;

    }
}

namespace Generic
{
    #region Interface

    interface IStruct
    {
        /// <summary>
        ///  This will initialize the Structure using the byte array.
        /// </summary>
        /// <param name="data">The byte array.</param>
        void Initialize(byte[] data);
        /// <summary>
        /// This will convert the structure to a byte array.
        /// </summary>
        /// <returns></returns>
        byte[] ToByteArray();
    }

    #endregion
}

namespace Mercury.Classes
{

    #region Enumerations

    /// <summary>
    /// Various server responses.
    /// </summary>
    public enum Responses 
    { 
        NoPokemon, 
        OldPokemon, 
        NewPokemon, 
        LoginGood, 
        LoginBounced, 
        UploadBounced, 
        UploadGood, 
        Connected, 
        Error 
    }

    /// <summary>
    /// Various client requests.
    /// </summary>
    public enum Requests 
    { 

        /// <summary>
        /// This has the server do a check to see if the client has anything waiting.
        /// </summary>
        Check, 

        /// <summary>
        /// This has the server send back a pokemon.
        /// </summary>
        GetPokemon 

    }

    /// <summary>
    /// The different genders of a Pokemon.
    /// </summary>
    public enum Gender { Male = 0, Female = 1, Any = 2, None = 3 }

    #endregion

    #region Searching

    public class SearchRequest : IStruct
    {

        public short NationalID { get; set; }
        public Gender Gender { get; set; }
        public byte MinLevel { get; set; }
        public byte MaxLevel { get; set; }

        public void Initialize(byte[] data)
        {

            // Make sure this is in fact
            // a valid array for the Search
            // Request structure
            if (!data[0].Equals(Constants.SearchRequestHeader)) return;
            // So, now that that's done...
            // Let's start breaking things down
            NationalID = BitConverter.ToInt16(data, 1);
            Gender = (Gender)data[3];
            MinLevel = data[4];
            MaxLevel = data[5];
        }

        public byte[] ToByteArray()
        {
            var idArr = BitConverter.GetBytes(NationalID);
            return new[] { Constants.SearchRequestHeader, idArr[0], idArr[1], (byte)Gender, MinLevel, MaxLevel };
        }

    }
    public class SearchResults : IStruct
    {

        public Guid ID { get; set; }
        public SearchPkm[] Pokemon { get; set; }

        public void Initialize(byte[] data)
        {

            // Check
            if (!data[0].Equals(Constants.SearchResultsHeader)) return;

            // The next byte tells us how many pokemon there are; it should not
            // be greater than CONSTANTS.MaxResults

            // Convert the fucker to a list<byte>
            var dataList = new List<byte>(data);
            var sentpkmn = dataList[1];

            // Remove
            dataList.RemoveRange(0, 2);

            // Okay, get the GUID array.
            ID = new Guid(dataList.GetRange(0, 16).ToArray());
            dataList.RemoveRange(0, 16);

            Pokemon = new SearchPkm[sentpkmn];

            // Okay, now we can loop until all the data is gone
            for (int i = 0; i < sentpkmn; i++)
            {
                
                // Grab the current range
                var currentPkmn = dataList.GetRange(0, 27);

                // Remove the range
                dataList.RemoveRange(0, 27);

                // Initialize
                var searchPokemon = new SearchPkm();
                searchPokemon.Initialize(currentPkmn.ToArray());

                // Set
                Pokemon[i] = searchPokemon;

            }
            

        }

        public byte[] ToByteArray()
        {

            var returnList = new List<byte>
                                 {Constants.SearchResultsHeader, (byte) Pokemon.Count()};

            // Add the initial stuff
            returnList.AddRange(ID.ToByteArray());

            // Add all the pokemon
            foreach (var pkmn in Pokemon)
                returnList.AddRange(pkmn.ToByteArray());

            // Give back an array
            return returnList.ToArray();

        }

    }
    public class SearchPkm : IStruct
    {

        /// <summary>
        /// This is the unique ID code given to this Pokemon for
        /// tracking purposes by Mercury.
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// This is the national ID of the Pokemon.
        /// </summary>
        public short NationalID { get; set; }

        /// <summary>
        /// This is the Gender of the Pokemon.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// This is the level of the Pokemon.
        /// </summary>
        public byte Level { get; set; }

        /// <summary>
        /// These are the requirements to get the Pokemon.
        /// </summary>
        public Requirements Requirements { get; set; }

        public void Initialize(byte[] data)
        {
            
            // The first byte should be the header
            if (!data[0].Equals(Constants.SearchPokemonHeader)) return;

            // Okay, convert to a list
            var dataList = new List<byte>(data);
            
            // remove the first byte, because fuck it :3
            dataList.RemoveAt(0); // Just the checker anyways.

            // Okay, GUID first
            ID = new Guid(dataList.GetRange(0, 16).ToArray());

            // remove the guid portion now.
            dataList.RemoveRange(0, 16);

            // Okay, now the next 2 bytes are the national id
            NationalID = BitConverter.ToInt16(dataList.GetRange(0, 2).ToArray(), 0);

            // remove
            dataList.RemoveRange(0, 2);

            // Gender
            Gender = (Gender)dataList[0];

            // remove!!!
            dataList.RemoveAt(0);

            // level!!
            Level = dataList[0];
            dataList.RemoveAt(0);

            // The rest of the data is for requirements
            Requirements = new Requirements();
            Requirements.Initialize(dataList.ToArray());

        }

        public byte[] ToByteArray()
        {

            var returnList = new List<byte> {Constants.SearchPokemonHeader};

            returnList.AddRange(ID.ToByteArray());
            returnList.AddRange(BitConverter.GetBytes(NationalID));
            returnList.Add((byte)Gender);
            returnList.Add(Level);
            returnList.AddRange(Requirements.ToByteArray());

            return returnList.ToArray();
            
        }

    }
    public class AdditionalResults : IStruct
    {

        public Guid SearchID { get; set; }

        public void Initialize(byte[] data)
        {
            if (!data[0].Equals(Constants.AdditionalSearchHeader)) return;

            var guidArr = new byte[16];
            Array.ConstrainedCopy(data, 1, guidArr, 0, 16);
            SearchID = new Guid(guidArr);

        }

        public byte[] ToByteArray()
        {
            var returnArr = new byte[17];
            returnArr[0] = Constants.AdditionalSearchHeader;
            var guidArr = SearchID.ToByteArray();
            Array.ConstrainedCopy(guidArr, 0, returnArr, 1, 16);
            return returnArr;
        }

    }

    #endregion

    #region Uploading and Trading

    public class Pokemon : IStruct
    {

        /// <summary>
        /// This is the unique ID code given to this Pokemon for
        /// tracking purposes by Mercury.
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// This is the national ID of the Pokemon.
        /// </summary>
        public short NationalID { get; set; }

        /// <summary>
        /// This is the Gender of the Pokemon.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// This is the level of the Pokemon.
        /// </summary>
        public byte Level { get; set; }

        /// <summary>
        /// These are the requirements to successfully get a pokemon.
        /// </summary>
        public Requirements Requirements { get; set; }

        /// <summary>
        /// A simple binary blob that contains the actual pokemon data
        /// </summary>
        public byte[] Blob { get; set; }

        public void Initialize(byte[] data)
        {

            // No more crying for adam!
            var dataArr = new List<byte>(data);

            // Guid
            ID = new Guid(dataArr.GetRange(0, 16).ToArray());
            dataArr.RemoveRange(0, 16);

            // NatID
            NationalID = BitConverter.ToInt16(dataArr.GetRange(0, 2).ToArray(), 0);
            dataArr.RemoveRange(0, 2);

            // Gender
            Gender = (Gender)dataArr[0];
            dataArr.RemoveAt(0);

            // Level
            Level = dataArr[0];
            dataArr.RemoveAt(0);

            // Requirements
            Requirements = new Requirements();
            Requirements.Initialize(dataArr.GetRange(0, 6).ToArray());
            dataArr.RemoveRange(0, 6);

            // Okay, all that's left is the blob!
            Blob = dataArr.ToArray();

        }

        public byte[] ToByteArray()
        {

            var dataList = new List<byte>();

            dataList.AddRange(ID.ToByteArray());
            dataList.AddRange(BitConverter.GetBytes(NationalID));
            dataList.Add((byte)Gender);
            dataList.Add(Level);
            dataList.AddRange(Requirements.ToByteArray());
            dataList.AddRange(Blob);

            return dataList.ToArray();

        }

        public override string ToString()
        {
            return string.Format("{0}, Level {1}", NationalID, Level);
        }

    }
    public class Requirements : IStruct
    {

        /// <summary>
        /// This is the Pokedex Number of the Pokemon
        /// wanted in return.
        /// </summary>
        public short NationalID { get; set; }

        /// <summary>
        /// This is the lowest level in the range that can
        /// be accepted.
        /// </summary>
        public byte MinLevel { get; set; }

        /// <summary>
        /// This is the highest level in the range that can
        /// be accepted.
        /// </summary>
        public byte MaxLevel { get; set; }

        /// <summary>
        /// This is the gender that is required.
        /// </summary>
        public Gender Gender { get; set; }

        public void Initialize(byte[] data)
        {
            
            // First byte!
            if (!data[0].Equals(Constants.RequirementsHeader)) return;

            // Derp
            var dataList = new List<byte>(data);
            dataList.RemoveAt(0);

            NationalID = BitConverter.ToInt16(dataList.GetRange(0, 2).ToArray(), 0);
            dataList.RemoveRange(0, 2);

            MinLevel = dataList[0];
            dataList.RemoveAt(0);

            MaxLevel = dataList[0];
            dataList.RemoveAt(0);

            Gender = (Gender)dataList[0];

        }

        public byte[] ToByteArray()
        {

            var dataList = new List<byte> {Constants.RequirementsHeader};
            dataList.AddRange(BitConverter.GetBytes(NationalID));
            dataList.Add(MinLevel);
            dataList.Add(MaxLevel);
            dataList.Add((byte)Gender);

            return dataList.ToArray();

            //// Define our arrays
            //var returnArr = new byte[6];
            //var idArr = BitConverter.GetBytes(NationalID);

            //// Start copying data
            //returnArr[0] = CONSTANTS.RequirementsHeader;                
            //Array.ConstrainedCopy(idArr, 0, returnArr, 1, idArr.Length);
            //returnArr[3] = MinLevel;
            //returnArr[4] = MaxLevel;
            //returnArr[5] = (byte) Gender;

            //// Finished
            //return returnArr;
        }

    }
    public class Upload : IStruct
    {

        public Pokemon Pokemon { get; set; }

        public void Initialize(byte[] data)
        {

            // Do that damn check
            if (!data[0].Equals(Constants.UploadHeader)) return;

            // data list
            var dataList = new List<byte>(data);

            // remove the first one because idgaf!
            dataList.RemoveAt(0);

            // pokemon
            Pokemon = new Pokemon();
            Pokemon.Initialize(dataList.ToArray());

        }

        public byte[] ToByteArray()
        {

            var dataList = new List<byte> {Constants.UploadHeader};
            dataList.AddRange(Pokemon.ToByteArray());
            return dataList.ToArray();

            //var returnArray = new[] { CONSTANTS.UploadHeader };
            //var pkmnArray = Pokemon.ToByteArray();
            //Array.Resize(ref returnArray, pkmnArray.Count() + 1);
            //Array.ConstrainedCopy(pkmnArray, 0, returnArray, 1, pkmnArray.Count());
            //return returnArray;

        }

    }
    public class Trade : IStruct
    {

        /// <summary>
        /// The Guid of the Pokemon to receive.
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// This is the pokemon being uploaded in its' place.
        /// </summary>
        public Pokemon Pokemon { get; set; }

        public void Initialize(byte[] data)
        {
            // Check the header
            if (!data[0].Equals(Constants.TradeHeader)) return;

            // Now list
            var dataList = new List<byte>(data);
            dataList.RemoveAt(0);

            // set
            ID = new Guid(dataList.GetRange(0, 16).ToArray());
            dataList.RemoveRange(0, 16);

            // set again
            Pokemon = new Pokemon();
            Pokemon.Initialize(dataList.ToArray());

        }

        public byte[] ToByteArray()
        {

            var dataList = new List<byte> {Constants.TradeHeader};
            dataList.AddRange(ID.ToByteArray());
            dataList.AddRange(Pokemon.ToByteArray());
            return dataList.ToArray();

            //// Here's our return array
            //var returnArr = new [] {CONSTANTS.TradeHeader};

            //// Get our other arrays
            //var guidArr = ID.ToByteArray();
            //var pokeArr = Pokemon.ToByteArray();

            //// Resize
            //Array.Resize(ref returnArr, guidArr.Length + pokeArr.Length + returnArr.Length);

            //// Now copy shit over.
            //Array.ConstrainedCopy(guidArr, 0, returnArr, 1, guidArr.Length);
            //Array.ConstrainedCopy(pokeArr, 0, returnArr, 17, pokeArr.Length);

            //// done
            //return returnArr;

        }
    }

    #endregion

    #region Request-Response

    public class Request : IStruct
    {

        public Requests ClientRequest { get; set; }

        public void Initialize(byte[] data)
        {
            if (data[0].Equals(Constants.RequestHeader)) ClientRequest = (Requests)data[1];
        }

        public byte[] ToByteArray()
        {
            return new[] { Constants.RequestHeader, (byte)ClientRequest };
        }

    }
    public class Response : IStruct
    {

        public Responses Resp { get; set; }

        public void Initialize(byte[] data)
        {
            // We need to make sure that this is a proper
            // Response structure which is just checking
            // the first byte for a 2.
            if (data[0].Equals(Constants.ResponseHeader))
                Resp = (Responses)data[1];
        }

        public byte[] ToByteArray()
        {
            // Create and return the byte array
            return new[] { Constants.ResponseHeader, (byte)Resp };
        }

    }
    public class Login : IStruct
    {

        public Guid ID { get; set; }
        public string Password { get; set; }

        public void Initialize(byte[] data)
        {

            // The first byte is garbage really
            // but it should be checked to make sure
            // this really is a login structure.
            if (!data[0].Equals(Constants.LoginHeader)) return;
            // Okay, this really is a login byte array
            // or is masquerading as one. Either way,
            // let's go about processing it.

            // Create the GUID & Pass array
            var guidArr = new byte[16];
            var passArr = new byte[data.Length - (guidArr.Length + 1)];

            // Copy the data over.
            Array.ConstrainedCopy(data, 1, guidArr, 0, 16);
            Array.ConstrainedCopy(data, 17, passArr, 0, passArr.Length);

            // Set the data.
            ID = new Guid(guidArr);
            Password = Encoding.UTF8.GetString(passArr);

        }

        public byte[] ToByteArray()
        {

            // list & header
            var byteList = new List<byte> {Constants.LoginHeader};

            // so add the guid
            byteList.AddRange(ID.ToByteArray());
            
            //convert the password to bytes
            var passBytes = Encoding.UTF8.GetBytes(Password);
            
            // add
            byteList.AddRange(passBytes);

            // return
            return byteList.ToArray();
            
        }

    }

    #endregion

}

namespace Mars
{

    /// <summary>
    /// global list of constants for mars.
    /// </summary>
    public static class Constants
    {
        public const byte LoginHeader = 0;
        public const byte RegisterHeader = 1;
        public const byte AdministrativeHeader = 2;
        public const byte CreateRoomHeader = 3;
        public const byte RoomMessageHeader = 4;
        public const byte LobbyMessageHeader = 5;
        public const byte UserListHeader = 6;
        public const byte RoomDataHeader = 7;
        public const byte PrivateMessageHeader = 8;
    }

}

namespace Mars.Classes
{

    #region Enumeration

    public enum Actions
    {

        /// <summary>
        /// A user is kicked from a room/lobby.
        /// </summary>
        KickUser,

        /// <summary>
        /// A user is banned from a room.
        /// A user cannot be banned from the lobby.
        /// </summary>
        BanUser,

        /// <summary>
        /// A user is server-banned. The username
        /// will be flagged.
        /// </summary>
        ServerBan,

        /// <summary>
        /// Removes a server ban on a username.
        /// </summary>
        RemoveServerBan,

        /// <summary>
        /// Gives the user permission to speak.
        /// </summary>
        VoiceUser,

        /// <summary>
        /// Removes a users permission to speak.
        /// </summary>
        DeVoiceUser,

        /// <summary>
        /// Gives a user operator powers in a room/lobby.
        /// </summary>
        OpUser,

        /// <summary>
        /// Removes a users operator powers.
        /// </summary>
        DeOpUser,

        /// <summary>
        /// A user has joined.
        /// </summary>
        UserJoined,

        /// <summary>
        /// A user has left.
        /// </summary>
        UserLeft,

        /// <summary>
        /// A user wants to join a room.
        /// </summary>
        JoinRoom,

        /// <summary>
        /// A user wants to leave a room.
        /// </summary>
        LeaveRoom,

    }

    public enum Rank
    {

        /// <summary>
        /// The lowest level; no voice.
        /// </summary>
        NoVoice = 0,

        /// <summary>
        /// The middle level; voice.
        /// </summary>
        Voice,

        /// <summary>
        /// The 2nd highest level, operator
        /// </summary>
        Ops,

        /// <summary>
        /// The highest level, super op.
        /// </summary>
        SuperOp

    }

    #endregion

    #region Login and Registration

    /// <summary>
    /// This structure is used for logging in to Mars.
    /// </summary>
    public class Login : IStruct
    {

        /// <summary>
        /// The username of the person logging in.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The password of the person logging in.
        /// </summary>
        public string Password { get; set; }

        public void Initialize(byte[] data)
        {

            // convert to list
            var list = new List<byte>(data);

            // check the starting
            if(list[0].Equals(Constants.LoginHeader))
            {
                
                // remove it
                list.RemoveAt(0);

                // next byte is how long the username is
                var usernameLength = list[0];

                // remove it
                list.RemoveAt(0);

                // Grab the first 20 characters
                var usernameBytes = list.GetRange(0, usernameLength).ToArray();
                Username = Encoding.UTF8.GetString(usernameBytes);

                // remove
                list.RemoveRange(0, usernameLength);

                // the rest should be the password
                Password = Encoding.UTF8.GetString(list.ToArray());

            }

        }

        public byte[] ToByteArray()
        {
            
            // okay, data list
            var list = new List<byte>(Constants.LoginHeader);

            // quick check
            if(Username.Length > Byte.MaxValue)
                throw new ArgumentException("Username is too long!");

            // next byte is how long the username is.
            list.Add((byte)Username.Length);

            // add the username in bytes
            list.AddRange(Encoding.UTF8.GetBytes(Username));

            // add the password
            list.AddRange(Encoding.UTF8.GetBytes(Password));

            // give it back
            return list.ToArray();

        }
    }

    /// <summary>
    /// This structure is used for Registering on Mars.
    /// </summary>
    public class Register : IStruct
    {

        /// <summary>
        /// The username of the person registering.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The password of the person registering.
        /// </summary>
        public string Password { get; set; }

        public void Initialize(byte[] data)
        {

            // convert to list
            var list = new List<byte>(data);

            // check the starting
            if (list[0].Equals(Constants.RegisterHeader))
            {

                // remove it
                list.RemoveAt(0);

                // next byte is how long the username is
                var usernameLength = list[0];

                // remove it
                list.RemoveAt(0);

                // Grab the first 20 characters
                var usernameBytes = list.GetRange(0, usernameLength).ToArray();
                Username = Encoding.UTF8.GetString(usernameBytes);

                // remove
                list.RemoveRange(0, usernameLength);

                // the rest should be the password
                Password = Encoding.UTF8.GetString(list.ToArray());

            }

        }

        public byte[] ToByteArray()
        {

            // okay, data list
            var list = new List<byte>(Constants.RegisterHeader);

            // quick check
            if (Username.Length > Byte.MaxValue)
                throw new ArgumentException("Username is too long!");

            // next byte is how long the username is.
            list.Add((byte)Username.Length);

            // add the username in bytes
            list.AddRange(Encoding.UTF8.GetBytes(Username));

            // add the password
            list.AddRange(Encoding.UTF8.GetBytes(Password));

            // give it back
            return list.ToArray();

        }
    }

    #endregion

    #region Room & Lobby

    /// <summary>
    /// Structure that creates a room.
    /// </summary>
    public class CreateRoom : IStruct
    {

        /// <summary>
        /// The name of the room to create.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// the owner of the room.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// A brief description of the room.
        /// </summary>
        public string Description { get; set; }

        public void Initialize(byte[] data)
        {
            if (data[0].Equals(Constants.CreateRoomHeader))
            {
                var list = new List<byte>(data);
                list.RemoveAt(0);

                var nameLength = list[0];
                var ownerLength = list[1];
                var descLength = BitConverter.ToInt16(data, 2);

                // remove 0, 1, 2, & 3
                list.RemoveRange(0, 4);

                //name first
                Name = Encoding.UTF8.GetString(list.GetRange(0, nameLength).ToArray());
                list.RemoveRange(0, nameLength);

                // owner
                Owner = Encoding.UTF8.GetString(list.GetRange(0, ownerLength).ToArray());
                list.RemoveRange(0, ownerLength);

                // description
                Description = Encoding.UTF8.GetString(list.GetRange(0, descLength).ToArray());
                list.RemoveRange(0, descLength);
            }
        }

        public byte[] ToByteArray()
        {
            var list = new List<byte>(Constants.CreateRoomHeader) {(byte) Name.Length, (byte) Owner.Length};
            list.AddRange(BitConverter.GetBytes((short)Description.Length));
            list.AddRange(Encoding.UTF8.GetBytes(Name));
            list.AddRange(Encoding.UTF8.GetBytes(Owner));
            list.AddRange(Encoding.UTF8.GetBytes(Description));
            return list.ToArray();
        }

    }

    /// <summary>
    /// Structure that creates a room.
    /// </summary>
    public class RoomData : IStruct
    {

        /// <summary>
        /// The name of the room to create.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// the owner of the room.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// A brief description of the room.
        /// </summary>
        public string Description { get; set; }

        public void Initialize(byte[] data)
        {
            if (data[0].Equals(Constants.RoomDataHeader))
            {
                var list = new List<byte>(data);
                list.RemoveAt(0);

                var nameLength = list[0];
                var ownerLength = list[1];
                var descLength = BitConverter.ToInt16(data, 2);

                // remove 0, 1, 2, & 3
                list.RemoveRange(0, 4);

                //name first
                Name = Encoding.UTF8.GetString(list.GetRange(0, nameLength).ToArray());
                list.RemoveRange(0, nameLength);

                // owner
                Owner = Encoding.UTF8.GetString(list.GetRange(0, ownerLength).ToArray());
                list.RemoveRange(0, ownerLength);

                // description
                Description = Encoding.UTF8.GetString(list.GetRange(0, descLength).ToArray());
                list.RemoveRange(0, descLength);
            }
        }

        public byte[] ToByteArray()
        {
            var list = new List<byte>(Constants.RoomDataHeader) { (byte)Name.Length, (byte)Owner.Length };
            list.AddRange(BitConverter.GetBytes((short)Description.Length));
            list.AddRange(Encoding.UTF8.GetBytes(Name));
            list.AddRange(Encoding.UTF8.GetBytes(Owner));
            list.AddRange(Encoding.UTF8.GetBytes(Description));
            return list.ToArray();
        }

    }

    /// <summary>
    /// Structure that sends a room message.
    /// </summary>
    public class RoomMessage : IStruct
    {

        public string Sender { get; set; }
        public string Room { get; set; }
        public string Message { get; set; }

        public void Initialize(byte[] data)
        {
            if(data[0].Equals(Constants.RoomMessageHeader))
            {

                // first byte is the sender name length
                // second byte is the room name length
                // third and fourth byte is the message length meaning a message
                // can be upwards of 65,535 characters long [or ~63kb of data]

                // read the length
                var senderLength = data[1];
                var roomLength = data[2];
                var messageLength = BitConverter.ToInt16(data, 3);

                // make the data a list now
                var dataList = new List<byte>(data);

                // remove bytes 0, 1, 2, 3 and 4
                dataList.RemoveRange(0, 5);

                // Sender & Remove
                Sender = Encoding.UTF8.GetString(dataList.GetRange(0, senderLength).ToArray());
                dataList.RemoveRange(0, senderLength);

                // Room & Remove
                Room = Encoding.UTF8.GetString(dataList.GetRange(0, roomLength).ToArray());
                dataList.RemoveRange(0, roomLength);

                // Message & Remove
                Message = Encoding.UTF8.GetString(dataList.GetRange(0, messageLength).ToArray());

            }
        }

        public byte[] ToByteArray()
        {
            
            // build the array
            var dataList = new List<byte>();

            // build our arrays.
            var senderArray = Encoding.UTF8.GetBytes(Sender);
            var roomArray = Encoding.UTF8.GetBytes(Room);
            var message = Encoding.UTF8.GetBytes(Message);

            // We need to check for invalid lengths..
            if((senderArray.Length > Byte.MaxValue) || (roomArray.Length > Byte.MaxValue) || (message.Length > short.MaxValue))
                throw new ArgumentException("One of the parameters is invalid");

            // okay all good.
            dataList.Add(Constants.RoomMessageHeader);
            dataList.Add((byte)senderArray.Length);
            dataList.Add((byte) roomArray.Length);
            dataList.AddRange(BitConverter.GetBytes((short)message.Length));
            dataList.AddRange(senderArray);
            dataList.AddRange(roomArray);
            dataList.AddRange(message);

            // give everything back
            return dataList.ToArray();

        }
    }

    /// <summary>
    /// Structure that sends a message in the lobby.
    /// </summary>
    public class LobbyMessage : IStruct
    {

        public string Sender { get; set; }
        public string Message { get; set; }

        public void Initialize(byte[] data)
        {
            if(data[0].Equals(Constants.LobbyMessageHeader))
            {

                var dataList = new List<byte>(data);

                // remove first byte
                dataList.RemoveAt(0);

                // okay, sender and message length are first in bytes 0, 1, and 2.
                var senderLength = dataList[0];
                var messageLength = BitConverter.ToInt16(dataList.ToArray(), 1);

                // remove!
                dataList.RemoveRange(0, 3);

                // all done, now start converting
                Sender = Encoding.UTF8.GetString(dataList.GetRange(0, senderLength).ToArray());
                dataList.RemoveRange(0, senderLength);

                Message = Encoding.UTF8.GetString(dataList.GetRange(0, messageLength).ToArray());
                dataList.RemoveRange(0, messageLength);

            }
        }

        public byte[] ToByteArray()
        {
            
            // convert data to bytes
            var senderArray = Encoding.UTF8.GetBytes(Sender);
            var messageArray = Encoding.UTF8.GetBytes(Message);

            // cheeeeeck!
            if((senderArray.Length > Byte.MaxValue) || (messageArray.Length > short.MaxValue))
                throw new ArgumentException("One of the parameters is not valid!");

            // herp.
            var dataList = new List<byte> {Constants.LobbyMessageHeader, (byte) senderArray.Length};
            dataList.AddRange(BitConverter.GetBytes(messageArray.Length).ToArray());
            dataList.AddRange(senderArray);
            dataList.AddRange(messageArray);

            return dataList.ToArray();

        }
    }

    /// <summary>
    /// Allows a personal message to be sent to a user.
    /// </summary>
    public class PrivateMessage : IStruct
    {

        public void Initialize(byte[] data)
        {
            throw new NotImplementedException();
        }

        public byte[] ToByteArray()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// A user list that is sent when someone logs in.
    /// </summary>
    public class LobbyUserList : IStruct
    {
        public string[] Users { get; set; }

        public void Initialize(byte[] data)
        {
            if (data[0].Equals(Constants.UserListHeader))
            {
                var list = new List<byte>(data);
                var userList = new List<string>();
                list.RemoveAt(0);

                while (list.Count > 0)
                {
                    var length = list[0];
                    list.RemoveAt(0);
                    userList.Add(Encoding.UTF8.GetString(list.GetRange(0, length).ToArray()));
                    list.RemoveRange(0, length);
                }
                Users = userList.ToArray();
            }
        }

        public byte[] ToByteArray()
        {
            var list = new List<byte>(Constants.UserListHeader);
            foreach (var item in Users)
            {
                list.Add((byte)item.Length);
                list.AddRange(Encoding.UTF8.GetBytes(item));
            }
            return list.ToArray();
        }
    }

    #endregion

    #region Administration & Client Changes

    /// <summary>
    /// Structure that describes an action.
    /// </summary>
    public class Action : IStruct
    {

        /// <summary>
        /// The action to execute.
        /// </summary>
        public Actions SelectedAction { get; set; }

        /// <summary>
        /// The person sending the action.
        /// </summary>
        public string Sender { get; set; }

        /// <summary>
        /// The user affected by the action.
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Optional: The room where the action is taking place.
        /// </summary>
        public string Room { get; set; }

        public void Initialize(byte[] data)
        {
            throw new NotImplementedException();
        }

        public byte[] ToByteArray()
        {
            throw new NotImplementedException();
        }
    }

    #endregion

}
