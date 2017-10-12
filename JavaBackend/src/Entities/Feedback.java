package Entities;

/**
 * Created by jonah on 21/9/2017.
 */
public class Feedback {

    private User submitter;
    private String message;

    Feedback(User submitter, String message){
        setSubmitter(submitter);
        setMessage(message);
    }

    public User getSubmitter() {
        return submitter;
    }

    public String getMessage() {
        return message;
    }

    public void setSubmitter(User submitter) {
        this.submitter = submitter;
    }

    public void setMessage(String message) {
        this.message = message;
    }

}

