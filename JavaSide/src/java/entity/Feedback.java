package entity;

/**
 *
 * @author jonah
 */
public class Feedback {

    private User submitter;
    private String message;

    /**
     *
     * @param submitter
     * @param message
     */
    public Feedback(User submitter, String message) {
        setSubmitter(submitter);
        setMessage(message);
    }

    /**
     *
     * @return
     */
    public User getSubmitter() {
        return submitter;
    }

    /**
     *
     * @return
     */
    public String getMessage() {
        return message;
    }

    /**
     *
     * @param submitter
     */
    public void setSubmitter(User submitter) {
        this.submitter = submitter;
    }

    /**
     *
     * @param message
     */
    public void setMessage(String message) {
        this.message = message;
    }

}
