using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_Code.Entity
{
    public class Feedback
    {
        private string submitter;
        private string message;
        private long submitTime;

        public Feedback(string submitter, string message, long submitTime)
        {
            setSubmitter(submitter);
            setMessage(message);
        }

        public string getSubmitter()
        {
            return submitter;
        }
        public string getMessage()
        {
            return message;
        }
        public long getSubmitTime()
        {
            return submitTime;
        }

        public void setSubmitter(string submitter)
        {
            this.submitter = submitter;
        }
        public void setMessage(string message)
        {
            this.message = message;
        }
        public void setSubmitTime(long submitTime)
        {
            this.submitTime = submitTime;
        }
    }
}