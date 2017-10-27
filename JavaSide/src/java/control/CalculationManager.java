package control;

import entity.Address;
import entity.Calculation;
import entity.User;
import java.util.ArrayList;
import java.util.List;
import javafx.util.Pair;

/**
 * Created by jonah on 28/9/2017.
 */
public class CalculationManager {

    private DatabaseManager dbManager = new DatabaseManager();
    private ApiFetcher apiManager = new ApiFetcher();
    private List<Calculation> CalculationList = new ArrayList();

    /**
     *
     * @param user
     * @return
     */
    public Calculation getUserCalculation(User user, int choice) {
        dbManager.getCalculation(user.getUsername(), choice);
        return null;
    }

    /**
     *
     * @param workLocation
     * @param homeLocation
     * @param salary
     * @param commuteType
     * @param jobInterest
     * @param salarySatisfaction
     * @return
     */
    public Calculation createNewCalculation(String workLocation, String homeLocation,
            int salary, char commuteType, int jobInterest, int salarySatisfaction) {

        double[] coordinates;
        double[] timeCost;
        String area;
        long time = 0;
        int medianSalary = 0;
        int ridersArea = 0;
        int aveRidersArea = 0;
        double commuteTime = 0;
        double aveCommuteTime = 0;
        double monthlyCommuteCost = 0;
        Address workLoc = null;
        Address homeLoc = null;

        try {
            coordinates = apiManager.getCoordinates(workLocation);
            area = apiManager.getArea(coordinates[0], coordinates[1]);
            workLoc = new Address(workLocation, coordinates[0], coordinates[1], area);
            coordinates = apiManager.getCoordinates(homeLocation);
            area = apiManager.getArea(coordinates[0], coordinates[1]);
            homeLoc = new Address(homeLocation, coordinates[0], coordinates[1], area);
            time = System.currentTimeMillis();
            medianSalary = apiManager.getMedianSalary(homeLoc.getArea());
            ridersArea = apiManager.getNumberOfRiders(homeLoc.getArea());
            aveRidersArea = apiManager.getAverageNumberOfRiders();
            timeCost = apiManager.getCommuteTimeCost(homeLoc, workLoc);
            commuteTime = timeCost[0];
            aveCommuteTime = apiManager.getAverageCommuteTime();
            monthlyCommuteCost = timeCost[1];
        } catch (Exception e) {
            return null;
        }

        Calculation cal;
        try {
            cal = new Calculation(workLoc, homeLoc,
                    salary, 'p', jobInterest, salarySatisfaction, time, medianSalary,
                    ridersArea, aveRidersArea, commuteTime, aveCommuteTime, monthlyCommuteCost);
        } catch (Exception e) {
            return null;
        }
        return cal;
    }

    /**
     *
     * @param calculation1
     * @param calculation2
     */
    public void compareCalculations(Calculation calculation1, Calculation calculation2) {
        //receive the most recent calculation
        //retrieve data from the score_t table in database

    }

    /**
     *
     * @param calculation
     * @param user
     * @return
     */
    public boolean saveCalculation(Calculation calculation, User user) {
        //valid.saveCalculation(); //new method on databaseManager
        return false;
    }
}
