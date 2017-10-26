package control;

import entity.Feedback;
import entity.User;

/**
 * Created by jonah on 28/9/2017.
 */
public class FeedbackManager {

    DatabaseManager valid = new DatabaseManager();
    private Feedback[] FeedbackList = new Feedback[100];

    //assume that feedback cannot be deleted
    /**
     *
     * @param user
     * @param message
     * @return
     */
    public boolean addFeedback(User user, String message) {
        int i = 0;

        for (i = 0; i < FeedbackList.length; i++) {
            if (FeedbackList[i] == null) {
                FeedbackList[i] = new Feedback(user, message);
                valid.addFeedback(user.getUsername(), message);
                return true;
            }
        }
        return false; //fail to get feedback
    }

}
