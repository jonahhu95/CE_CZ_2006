using ASPWebsite.App_Code.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_Code.Control
{
    /// <summary>
    /// User manager.
    /// Responsible for managing User objects.
    /// </summary>
    public class UserManager
    {
        private DatabaseManager dbManager = new DatabaseManager();
        private AddressManager addManager = new AddressManager();

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <returns><c>true</c>, if user was created, <c>false</c> otherwise.</returns>
        /// <param name="userName">User name.</param>
        /// <param name="password">Password.</param>
        public Boolean createUser(string userName, string password)
        {
            if (checkIfUserExist(userName))
                return false;
            User newUser = new User(userName, BCrypt.Net.BCrypt.HashPassword(password));
            return dbManager.saveUser(newUser);
        }
        /// <summary>
        /// Logins the user.
        /// </summary>
        /// <returns><c>true</c>, if user was logined, <c>false</c> otherwise.</returns>
        /// <param name="userName">User name.</param>
        /// <param name="password">Password.</param>
        public Boolean loginUser(string userName, string password)
        {
            User user = dbManager.getUser(userName);
            if(user != null)
            {
                return BCrypt.Net.BCrypt.Verify(password, user.getPassword());
            }
            return false;
        }
        /// <summary>
        /// Checks if user exist.
        /// </summary>
        /// <returns><c>true</c>, if if user exist was checked, <c>false</c> otherwise.</returns>
        /// <param name="userName">User name.</param>
        public Boolean checkIfUserExist(string userName)
        {
            if (dbManager.getUser(userName) != null)
                return true;
            return false;
        }
        /// <summary>
        /// Saves the user home location.
        /// </summary>
        /// <returns><c>true</c>, if user home location was saved, <c>false</c> otherwise.</returns>
        /// <param name="userName">User name.</param>
        /// <param name="locationName">Location name.</param>
        public Boolean saveUserHomeLocation(string userName, string locationName)
        {
            Address homeLocation = addManager.createNewAddress(locationName);
            User user = dbManager.getUser(userName);
            if (homeLocation == null || user == null)
                return false;
            return dbManager.saveUserHomeLocation(user, homeLocation);
        }
        /// <summary>
        /// Gets the user home location.
        /// </summary>
        /// <returns>The user home location.</returns>
        /// <param name="userName">User name.</param>
        public string getUserHomeLocation(string userName)
        {
            try
            {
                User user = dbManager.getUser(userName);
                return user.getHomeLocation().getLocationName();
            }
            catch
            {
                //ERROR HANDLING
            }
            return null;
            
            
        }

    }
}