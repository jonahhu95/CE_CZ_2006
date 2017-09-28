package Entities;

import java.util.Arrays;
import java.util.List;

/**
 * Created by jonah on 21/9/2017.
 */
public class SalarySatisfaction extends Criteria {

    int salaryInterest = -1;
    private List<String> explanations = Arrays.asList("Description 1", "Description 2", "Description 3",
            "Description 4", "Description 5", "Description 6", "Description 7", "Description 8",
            "Description 9", "Description 10");

    SalarySatisfaction(int salaryInterest){
        weightage = 10;
        setSalaryInterest(salaryInterest);
    }

    @Override
    public double calculateSubScore() {
        return super.calculateSubScore();
    }

    @Override
    public String getExplanation() {
        if(salaryInterest != -1)
            return explanations.get(salaryInterest-1);
        return super.getExplanation();
    }

    public int getSalaryInterest() {
        return salaryInterest;
    }

    public void setSalaryInterest(int salaryInterest) {
        this.salaryInterest = salaryInterest;
    }
}
