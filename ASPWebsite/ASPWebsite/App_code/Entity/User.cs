using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_Code.Entity
{
    public class User
    {
        private string userName;
        private string password;
        private Address homeLocation;

        public User(string userName, string password)
        {
            setUserName(userName);
            setPassword(password);
        }

        public User(string userName, string password, Address homeLocation)
        {
            setUserName(userName);
            setPassword(password);
            setHomeLocation(homeLocation);
        }

        public string getUsername()
        {
            return userName;
        }
        public string getPassword()
        {
            return password;
        }
        public Address getHomeLocation()
        {
            return homeLocation;
        }
        private void setUserName(string userName)
        {
            this.userName = userName;
        }
        private void setPassword(string password)
        {
            this.password = password;
        }
        private void setHomeLocation(Address homeLocation)
        {
            this.homeLocation = homeLocation;
        }
    }
}