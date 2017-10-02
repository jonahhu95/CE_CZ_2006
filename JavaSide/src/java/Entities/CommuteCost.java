package Entities;

import java.util.Arrays;
import java.util.List;

/**
 * Created by jonah on 21/9/2017.
 */
public class CommuteCost extends Criteria {

    private double monthlyTravelCost;
    private int salary;
    private double averageSalaryToCommuteRatio; //NOT USED YET
    private int point = -1;
    private List<String> explanations = Arrays.asList("Description 1", "Description 2", "Description 3",
            "Description 4", "Description 5", "Description 6", "Description 7", "Description 8",
            "Description 9", "Description 10", "Description 11");

   CommuteCost(double monthlyTravelCost, int salary){
        weightage = 10;
        setMonthlyTravelCost(monthlyTravelCost);
        setSalary(salary);
    }

    @Override
    public double calculateSubScore() {
        double ratio = monthlyTravelCost / salary;
        if(ratio < 1.75){
            if(ratio < 1.35){
                if(ratio < 0.95 ){
                    if(ratio < 0.75){
                        point = 10;
                    }else{
                        point = 9;
                    }
                }else{
                    if(ratio < 1.15) {
                        point = 8;
                    }else{
                        point = 7;
                    }
                }
            }else{
                if(ratio < 1.55){
                    point = 6;
                }else{
                    point = 5;
                }
            }
        }else{
            if(ratio < 2.15){
                if(ratio < 1.95) {
                    point = 4;
                }else{
                    point = 3;
                }
            }else if(ratio < 2.45) {
                if(ratio < 2.25){
                    point = 2;
                }else{
                    point = 1;
                }
            }else{
                point = 0;
            }
        }
        return point/10 * weightage;
    }

    @Override
    public String getExplanation() {
        if(point != -1)
            return explanations.get(point);
        return super.getExplanation();
    }

    public double getMonthlyTravelCost() {
        return monthlyTravelCost;
    }

    public int getSalary() {
        return salary;
    }

    public double getAverageSalaryToCommuteRatio() {
        return averageSalaryToCommuteRatio;
    }

    public void setMonthlyTravelCost(double monthlyTravelCost) {
        this.monthlyTravelCost = monthlyTravelCost;
    }

    public void setSalary(int salary) {
        this.salary = salary;
    }

    public void setAverageSalaryToCommuteRatio(double averageSalaryToCommuteRatio) {
        this.averageSalaryToCommuteRatio = averageSalaryToCommuteRatio;
    }
}
