package Entities;

/**
 * Created by jonah on 21/9/2017.
 */
public class User {

    private String userName;
    private String password;
    
    public User(String username,String password) {
    		this.userName=username;
    		this.password=password;
    }
    
    public String getUsername() {
    		return userName;
    }
    public String getPassword() {
		return password;
}
    
    public void changePassword(String password) {
    		this.password=password;
    }
    
}
