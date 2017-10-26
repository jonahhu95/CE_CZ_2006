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

    public Calculation getUserCalculation(User user) {
        dbManager.getCalculatedRecord(user.getUsername());
        return null;
    }

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
                    salary, commuteType, jobInterest, salarySatisfaction, time, medianSalary,
                    ridersArea, aveRidersArea, commuteTime, aveCommuteTime, monthlyCommuteCost);
            String test = cal.getCriteriaExplanation_CommuteComfort();
//            test = cal.getCriteriaExplanation_CommuteCost();
//            test = cal.getCriteriaExplanation_CommuteTime();
//            test = cal.getCriteriaExplanation_JobInterest();
//            test = cal.getCriteriaExplanation_Salary();
//            test = cal.getCriteriaExplanation_SalarySatisfaction();
            int m = 0;
        } catch (Exception e) {
            return null;
        }
        return cal;
    }

    public void compareCalculations(Calculation calculation1, Calculation calculation2) {
        //receive the most recent calculation
        //retrieve data from the score_t table in database

    }

    public boolean saveCalculation(Calculation calculation, User user) {
        //valid.saveCalculation(); //new method on databaseManager
        return false;
    }
}
