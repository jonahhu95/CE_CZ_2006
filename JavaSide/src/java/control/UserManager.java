package control;

import control.DatabaseManager;
import entity.User;

/**
 *
 * @author jonah
 */
public class UserManager {

    private static User[] UserList = new User[100]; // ???

    DatabaseManager valid = new DatabaseManager();

    /**
     *
     * @param username
     * @param password
     * @return
     */
    public boolean createUser(String username, String password) {
        int i = 0;

        for (i = 0; i < UserList.length; i++) {
            if (UserList[i] == null) {
                break;
            } else if (username == UserList[i].getUsername()) {
                return false;
            }
        }
        UserList[i] = new User(username, password);
        boolean result = valid.createAccount(username, password);
        return result;
    }

    /**
     *
     * @param username
     * @return
     */
    public boolean deleteUser(String username) {
        int i = 0;

        for (i = 0; i < UserList.length; i++) {
            if (username == UserList[i].getUsername()) {
                UserList[i] = null;
                valid.deleteAccount(username);
                return true;
            }
        }
        return false; //fail to delete user
    }

    //only password can be altered
    /**
     *
     * @param username
     * @param password
     * @return
     */
    public boolean editUser(String username, String password) {
        int i = 0;

        for (i = 0; i < UserList.length; i++) {
            if (username == UserList[i].getUsername()) {
                UserList[i].changePassword(password);
                valid.editAccount(username, password);
                return true;
            }
        }
        return false; //fail to edit user
    }

    /**
     *
     * @param username
     * @param password
     * @return
     */
    public boolean loginUser(String username, String password) {

        return valid.validateLogin(username, password);
        //return false if password does not match or user not found
    }

}
