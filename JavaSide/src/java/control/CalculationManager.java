package control;
import entity.*;

/**
 * Created by jonah on 28/9/2017.
 */
public class CalculationManager {
	DatabaseManager valid=new DatabaseManager();
	private Calculation[] CalculationList = new Calculation[100]; //???
	
	public Calculation getUserCalculation(User user) {
		valid.getCalculatedRecord(user.getUsername());
		return null;
	}
	
	public Calculation createNewCalculation(String workLocation, String homeLocation, int salary, int jobInterest, int salarySatisfaction) {
		//use calculation entity
		//assume that user has input for all mandatory information
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
