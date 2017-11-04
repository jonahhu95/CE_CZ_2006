﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_Code.Entity
{
    public class Feedback
    {
        private string submitter;
        private string message;
        private DateTime submitTime;

        public Feedback(string submitter, string message, DateTime submitTime)
        {
            setSubmitter(submitter);
            setMessage(message);
            setSubmitTime(submitTime);
        }

        public string getSubmitter()
        {
            return submitter;
        }
        public string getMessage()
        {
            return message;
        }
        public DateTime getSubmitTime()
        {
            return submitTime;
        }

        private void setSubmitter(string submitter)
        {
            this.submitter = submitter;
        }
        private void setMessage(string message)
        {
            this.message = message;
        }
        private void setSubmitTime(DateTime submitTime)
        {
            this.submitTime = submitTime;
        }
    }
}