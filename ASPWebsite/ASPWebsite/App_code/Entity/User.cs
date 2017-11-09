using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_Code.Entity
{
    /// <summary>
    /// User.
    /// </summary>
    public class User
    {
        private string userName;
        private string password;
        private Address homeLocation;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ASPWebsite.App_Code.Entity.User"/> class.
        /// </summary>
        /// <param name="userName">User name.</param>
        /// <param name="password">Password.</param>
        public User(string userName, string password)
        {
            setUserName(userName);
            setPassword(password);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ASPWebsite.App_Code.Entity.User"/> class.
        /// </summary>
        /// <param name="userName">User name.<u/param>
        /// <param name="password">Password.</param>
        /// <param name="homeLocation">Home location.</param>
        public User(string userName, string password, Address homeLocation)
        {
            setUserName(userName);
            setPassword(password);
            setHomeLocation(homeLocation);
        }
        /// <summary>
        /// Gets the username.
        /// </summary>
        /// <returns>The username.</returns>
        public string getUsername()
        {
            return userName;
        }
        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <returns>The password.</returns>
        public string getPassword()
        {
            return password;
        }
        /// <summary>
        /// Gets the home location.
        /// </summary>
        /// <returns>The home location.</returns>
        public Address getHomeLocation()
        {
            return homeLocation;
        }
        /// <summary>
        /// Sets the name of the user.
        /// </summary>
        /// <param name="userName">User name.</param>
        private void setUserName(string userName)
        {
            this.userName = userName;
        }
        /// <summary>
        /// Sets the password.
        /// </summary>
        /// <param name="password">Password.</param>
        private void setPassword(string password)
        {
            this.password = password;
        }
        /// <summary>
        /// Sets the home location.
        /// </summary>
        /// <param name="homeLocation">Home location.</param>
        private void setHomeLocation(Address homeLocation)
        {
            this.homeLocation = homeLocation;
        }
    }
}