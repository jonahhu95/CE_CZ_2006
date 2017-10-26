/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package border;

import control.ApiFetcher;
import control.CalculationManager;
import control.DatabaseManager;
import control.UserManager;
import entity.Calculation;
import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.WebParam;

/**
 *
 * @author Joey
 */
@WebService
public class Service {

    UserManager um = new UserManager();

    /**
     *
     * @param u
     * @param p
     * @return
     */
    @WebMethod
    public boolean checkUser(String u, String p) {
        return um.loginUser(u, p);
    }

    /**
     *
     * @param u
     * @param p
     * @return
     */
    @WebMethod
    public boolean createUserAccount(String u, String p) {
        return um.createUser(u, p);
    }

    /**
     *
     * @param u
     * @param p
     * @return
     */
    @WebMethod
    public boolean changePassword(String u, String p) {
        return um.editUser(u, p);
    }
<<<<<<< HEAD

=======
    
    @WebMethod
    public Calculation calculateJS(String workLocation, String homeLocation,
            int salary, char commuteType, int jobInterest, int salarySatisfaction)
    {
        return cm.createNewCalculation(workLocation, homeLocation, salary, commuteType, jobInterest, salarySatisfaction);
    }
    
    
>>>>>>> 9447e542dd3a9240a7e4c62ab956790d13841585
}
