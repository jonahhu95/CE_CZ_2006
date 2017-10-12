/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package border;

import control.ApiFetcher;
import control.DatabaseManager;
import control.UserManager;
import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.WebParam;

/**
 *
 * @author Joey
 */
@WebService
public class Service {

    @WebMethod
    public String hellothere() {
        return "Success";
    }

    @WebMethod
    public boolean checkUser(String u, String p) {
        UserManager um = new UserManager();
        
        return um.loginUser(u, p);
    }
    
}
