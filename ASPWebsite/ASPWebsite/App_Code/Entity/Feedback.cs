using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_Code.Entity
{
    public class Feedback
    {
        private User submitter;
        private string message;

        public Feedback(User submitter, string message)
        {
            setSubmitter(submitter);
            setMessage(message);
        }

        public User getSubmitter()
        {
            return submitter;
        }
        public string getMessage()
        {
            return message;
        }

        public void setSubmitter(User submitter)
        {
            this.submitter = submitter;
        }
        public void setMessage(string message)
        {
            this.message = message;
        }
    }
}