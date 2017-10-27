/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package border;

import control.ApiFetcher;
import control.CalculationManager;

/**
 *
 * @author jonah
 */
public class Test {

    /**
     *
     * @param arg
     */
    public static void main(String arg[]) {
        CalculationManager cm = new CalculationManager();
        System.out.println(cm.createNewCalculation("Nanayang Technological University", "Evergreen Park Singapore", 4500, 'p', 5, 5));
        
        //test--;

    }
}
