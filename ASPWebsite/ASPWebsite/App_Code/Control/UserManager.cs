using ASPWebsite.App_Code.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_Code.Control
{
    public class UserManager
    {
        private DatabaseManager dbManager = new DatabaseManager();

        public Boolean createUser(string userName, string password)
        {
            if (checkIfUserExist(userName))
                return false;
            User newUser = new User(userName, BCrypt.Net.BCrypt.HashPassword(password));
            return dbManager.saveUser(newUser);
        }
        public Boolean loginUser(string userName, string password)
        {
            User user = dbManager.getUser(userName);
            if(user != null)
            {
                return BCrypt.Net.BCrypt.Verify(password, user.getPassword());
            }
            return false;
        }
        public Boolean checkIfUserExist(string userName)
        {
            if (dbManager.getUser(userName) != null)
                return true;
            return false;
        }

    }
}