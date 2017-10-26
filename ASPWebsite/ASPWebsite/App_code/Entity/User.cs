﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_code.Entity
{
    public class User
    {
        private string userName;
        private string password;

        public User(string userName, string password)
        {
            setUserName(userName);
            setPassword(password);
        }

        public string getUsername()
        {
            return userName;
        }
        public string getPassword()
        {
            return password;
        }
        public void setUserName(string userName)
        {
            this.userName = userName;
        }
        public void setPassword(string password)
        {
            this.password = password;
        }
    }
}