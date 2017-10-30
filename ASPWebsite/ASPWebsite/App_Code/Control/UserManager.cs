using System;
using ASPWebsite.App_Code.Entity;
namespace ASPWebsite.App_Code.Control
{
    public class UserManager
    {
        public UserManager()
        {
        }

        private static User[] UserList = new User[100]; // ???

        private DatabaseManager valid = new DatabaseManager();


        public Boolean CreateUser(String username, String password){
            int i = 0;

            for (i = 0; i < UserList.Length; i++){
                if (UserList[i] == null){
                    break;
                }
                else if (username == UserList[i].getUsername()){
                    return false;
                }
            }
            UserList[i] = new User(username, password);
            //Boolean result = valid.createAccount(username, password);
            //return result;
            return true;
        }

        public Boolean DeleteUser(String username){
            int i = 0;

            for (i = 0; i < UserList.Length; i++){
                if (username == UserList[i].getUsername()){
                    UserList[i] = null;
                    //valid.deleteAccount(username);
                    return true;
                }
            }
            return false; //fail to delete user
        }


        public Boolean EditUser(String username, String password){
            int i = 0;

            for (i = 0; i < UserList.Length; i++){
                if (username == UserList[i].getUsername()){
                    //UserList[i]
                    //UserList[i].changePassword(password);
                    //valid.editAccount(username, password);
                    return true;
                }
            }
            return false; //fail to edit user
        }


        public Boolean loginUser(String username, String password)
        {
            return true;
            //return valid.validateLogin(username, password);
            //return false if password does not match or user not found
        }
    }
}

