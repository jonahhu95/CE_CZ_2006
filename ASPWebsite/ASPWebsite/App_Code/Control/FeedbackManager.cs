﻿using ASPWebsite.App_Code.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_Code.Control
{
    public class FeedbackManager
    {
        private DatabaseManager dbManager = new DatabaseManager();
        public Boolean addFeedback(string userName, string message)
        {
            Feedback toSubmit = new Feedback(userName, message, DateTime.Now);
            return dbManager.saveFeedback(toSubmit);
        }
        public List<Feedback> getAllFeedback()
        {
            return dbManager.getFeedback();
        }
    }
}