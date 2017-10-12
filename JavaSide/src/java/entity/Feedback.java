package entity;


public class Feedback {

    private User submitter;
    private String message;

    public Feedback(User submitter, String message){
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

