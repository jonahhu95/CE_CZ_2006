package entity;

/**
 *
 * @author jonah
 */
public class User {

    private String userName;
    private String password;

    /**
     *
     * @param username
     * @param password
     */
    public User(String username, String password) {
        this.userName = username;
        this.password = password;
    }

    /**
     *
     * @return
     */
    public String getUsername() {
        return userName;
    }

    /**
     *
     * @return
     */
    public String getPassword() {
        return password;
    }

    /**
     *
     * @param password
     */
    public void changePassword(String password) {
        this.password = password;
    }

}
