using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_Code.Entity
{
    /// <summary>
    /// Feedback.
    /// </summary>
    public class Feedback
    {
        private string submitter { get; set; }
        private string message { get; set; }
        private DateTime submitTime { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ASPWebsite.App_Code.Entity.Feedback"/> class.
        /// </summary>
        /// <param name="submitter">Submitter.</param>
        /// <param name="message">Message.</param>
        /// <param name="submitTime">Submit time.</param>
        public Feedback(string submitter, string message, DateTime submitTime)
        {
            setSubmitter(submitter);
            setMessage(message);
            setSubmitTime(submitTime);
        }
        /// <summary>
        /// Gets the submitter.
        /// </summary>
        /// <returns>The submitter.</returns>
        public string getSubmitter()
        {
            return submitter;
        }
        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <returns>The message.</returns>
        public string getMessage()
        {
            return message;
        }
        /// <summary>
        /// Gets the submit time.
        /// </summary>
        /// <returns>The submit time.</returns>
        public DateTime getSubmitTime()
        {
            return submitTime;
        }
        /// <summary>
        /// Sets the submitter.
        /// </summary>
        /// <param name="submitter">Submitter.</param>
        private void setSubmitter(string submitter)
        {
            this.submitter = submitter;
        }
        /// <summary>
        /// Sets the message.
        /// </summary>
        /// <param name="message">Message.</param>
        private void setMessage(string message)
        {
            this.message = message;
        }
        /// <summary>
        /// Sets the submit time.
        /// </summary>
        /// <param name="submitTime">Submit time.</param>
        private void setSubmitTime(DateTime submitTime)
        {
            this.submitTime = submitTime;
        }
    }
}