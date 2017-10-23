package control;

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
	
	public Calculation createNewCalculation(double workLocation_long, double workLocation_lat,
                double homeLocation_long, double homeLocation_lat, int salary, char commuteType, 
                int jobInterest, int salarySatisfaction) {
            
                Pair workLocation = new Pair(workLocation_long, workLocation_lat);
                Pair homeLocation = new Pair(homeLocation_long, homeLocation_lat);
                long time = System.currentTimeMillis();
                int medianSalary = 10;
                int ridersArea = 10;
                int aveRidersArea = 10;
                int commuteTime = 10;
                int aveCommuteTime = 10;
                int monthlyCommuteCost = 10;
                
                try{
                    Calculation cal = new Calculation(workLocation, homeLocation,
                        salary, commuteType, jobInterest, salarySatisfaction, time, medianSalary,
                        ridersArea, aveRidersArea, commuteTime, aveCommuteTime, monthlyCommuteCost);
                }catch(Exception e){
                    
                }
		return null;
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
