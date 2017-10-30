using System;
using ASPWebsite.App_Code.Entity;
namespace ASPWebsite.App_Code.Control
{
    public class FeedbackManager
    {
        public FeedbackManager()
        {
        }
            DatabaseManager valid = new DatabaseManager();
            private Feedback[] FeedbackList = new Feedback[100];

        public Boolean addFeedback(User user, String message)
        {
            int i = 0;

            for (i = 0; i < FeedbackList.Length; i++)
            {
                if (FeedbackList[i] == null)
                {
                    FeedbackList[i] = new Feedback(user, message);
                    //valid.addFeedback(user.getUsername(), message);
                    return true;
                }
            }
            return false; //fail to get feedback
        }
    }
}

