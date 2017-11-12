using ASPWebsite.App_Code.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_Code.Control
{
    /// <summary>
    /// Feedback manager.
    /// Responsible for managing Feedback objects.
    /// </summary>
    public class FeedbackManager
    {
        private DatabaseManager dbManager = new DatabaseManager();

        /// <summary>
        /// Adds Feedback
        /// </summary>
        /// <returns><c>true</c>, if successful, <c>false</c> otherwise.</returns>
        /// <param name="username">User name.</param>
        /// <param name="message">Feedback message.</param>
        public Boolean addFeedback(string userName, string message)
        {
            Feedback toSubmit = new Feedback(userName, message, DateTime.Now);
            return dbManager.saveFeedback(toSubmit);
        }

        /// <summary>
<<<<<<< HEAD
        /// Get Feedbacks
        /// </summary>
        /// <returns>All feedbacks submitted.</returns>
        /// <param name="username">User name.</param>
        /// <param name="message">Feedback message.</param>
=======
        /// Gets all feedback.
        /// </summary>
        /// <returns>The list of all feedback.</returns>
>>>>>>> 0e55555886c2d462f0ddc99d9089470a2dcc4215
        public List<Feedback> getAllFeedback()
        {
            return dbManager.getFeedback();
        }
    }
}