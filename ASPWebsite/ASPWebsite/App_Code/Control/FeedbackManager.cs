using System;
using ASPWebsite.App_Code.Entity;
using System.Collections.Generic;

namespace ASPWebsite.App_Code.Control
{
    public class FeedbackManager
    {

        private DatabaseManager dbManager = new DatabaseManager();
        public Boolean addFeedback(User user, string message)
        {
            Feedback toSubmit = new Feedback(user.getUsername(), message, DateTime.Now);
            return dbManager.saveFeedback(toSubmit);
        }
        public List<Feedback> getAllFeedback()
        {
            return dbManager.getFeedback();
        }
    }
}

