using ASPWebsite.App_Code.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_Code.Control
{
    /// <summary>
    /// Feedback manager.
    /// </summary>
    public class FeedbackManager
    {
        private DatabaseManager dbManager = new DatabaseManager();
        /// <summary>
        /// Adds the feedback.
        /// </summary>
        /// <returns><c>true</c>, if feedback was added, <c>false</c> otherwise.</returns>
        /// <param name="userName">User name.</param>
        /// <param name="message">Message.</param>
        public Boolean addFeedback(string userName, string message)
        {
            Feedback toSubmit = new Feedback(userName, message, DateTime.Now);
            return dbManager.saveFeedback(toSubmit);
        }

        /// <summary>
        /// Gets all feedback.
        /// </summary>
        /// <returns>The list of all feedback.</returns>
        public List<Feedback> getAllFeedback()
        {
            return dbManager.getFeedback();
        }
    }
}