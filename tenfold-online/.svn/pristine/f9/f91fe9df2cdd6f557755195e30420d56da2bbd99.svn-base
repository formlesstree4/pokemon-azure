using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mars.Classes
{

    /// <summary>
    /// The lobby is the main environment of Mars. 
    /// It is the meet up place for the match making system.
    /// </summary>
    public static class Lobby
    {

        #region variables and initialization

        /// <summary>
        /// The current users in the lobby.
        /// </summary>
        private static List<UserInformation> Users { get; set; }

        /// <summary>
        /// The list of rooms.
        /// </summary>
        private static List<Room> Rooms { get; set; }

        /// <summary>
        /// Initializes the lobby.
        /// </summary>
        public static void Initialize()
        {
            Users = new List<UserInformation>();
            Rooms = new List<Room>();
        }

        #endregion

        #region messages

        /// <summary>
        /// Sends a message to all the clients.
        /// </summary>
        /// <param name="message">The message to send.</param>
        public static void SendMessage(byte[] message)
        {
            lock (Users)
                Parallel.ForEach(Users, information => information.Client.Send(message));
        }

        /// <summary>
        /// Sends a RoomMessage array to a specific room.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="room">The room.</param>
        public static void SendMessage(byte[] message, string room)
        {

        }

        #endregion

        #region users

        /// <summary>
        /// Determines if a user exists.
        /// </summary>
        /// <param name="user">The username to check for.</param>
        /// <returns></returns>
        public static bool UserExists(string user)
        {
            lock(Users)
                return Users.Any(f => f.Username.Equals(user));
        }

        /// <summary>
        /// Returns a structure of user information.
        /// </summary>
        /// <param name="username">The username to look for.</param>
        /// <returns></returns>
        public static UserInformation GetUser(string username)
        {
            if (UserExists(username))
                lock (Users)
                    return Users.Where(f => f.Username.Equals(username)).ToList()[0];
            throw new ArgumentException(username);
        }

        /// <summary>
        /// Modifies someone's rank.
        /// </summary>
        /// <param name="sender">The person requesting the change.</param>
        /// <param name="target">The target of the change.</param>
        /// <param name="newRank">The new rank.</param>
        public static void ModifyPermission(string sender, string target, Rank newRank)
        {

            // let's grab the sender
            var senderInformation = GetUser(sender);

            // now check their rank and make sure they are not promoting someone above their own rank.
            if (senderInformation.Rank >= Rank.Ops && senderInformation.Rank <= newRank)
            {
                lock (Users)
                {
                    for (var i = 0; i < Users.Count(); i++)
                    {
                        if (Users[i].Username.Equals(target))
                        {
                            var u = Users[i];
                            u.Rank = newRank;
                            Users[i] = u;
                            break;
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Adds a new user to the lobby.
        /// </summary>
        /// <param name="user">the username of the person to add.</param>
        /// <param name="client">their client</param>
        /// <param name="rank">their rank</param>
        public static void Add(string user, ref Phoenix.Client.Client client, Rank rank)
        {
            if (!UserExists(user))
            {
                SendMessage((new Action { SelectedAction = Actions.UserJoined, User = user }).ToByteArray());
                lock (Users)
                    Users.Add(new UserInformation { Username = user, Rank = rank, Client = client });

                // build the user list.

                // client.Send(new LobbyUserList {});
                
            }
        }

        /// <summary>
        /// Removes a user from the lobby, logging them out.
        /// </summary>
        /// <param name="user">The user to remove.</param>
        public static void Remove(string user)
        {
            if (UserExists(user))
            {

                lock (Users)
                {
                    // remove from the lobby
                    Users.Remove(GetUser(user));

                    // remove from individual rooms
                    foreach (var room in Rooms)
                    {
                        // ToDo: Remove from rooms.
                    }
                }

                // all removed.
                SendMessage(new Action { User = user, SelectedAction = Actions.UserLeft }.ToByteArray());

            }
        }

        #endregion

        #region rooms

        /// <summary>
        /// Checks to see if a room exists.
        /// </summary>
        /// <param name="name">The name of the room.</param>
        /// <returns></returns>
        public static bool RoomExists(string name)
        {
            lock (Rooms)
                return Rooms.Any(r => r.Name.Equals(name));
        }

        #endregion

    }

}
