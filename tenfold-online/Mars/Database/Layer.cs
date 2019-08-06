using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mars.Database
{

    /// <summary>
    /// static class that controls database interaction.
    /// </summary>
    public static class Layer
    {

        /// <summary>
        /// Checks to see if a username exists in the database.
        /// </summary>
        /// <param name="user">The username to check for.</param>
        /// <returns></returns>
        public static bool UsernameExists(string user)
        {
            return false;
        }

        /// <summary>
        /// Performs a registration.
        /// </summary>
        /// <param name="user">The user to register with.</param>
        /// <param name="pass">The password to register with.</param>
        /// <returns></returns>
        public static bool Register(string user, string pass)
        {
            return false;
        }

        /// <summary>
        /// Performs a login.
        /// </summary>
        /// <param name="user">The user to register with.</param>
        /// <param name="pass">The password to register with.</param>
        /// <returns></returns>
        public static bool Login(string user, string pass)
        {
            return false;
        }

    }

}
