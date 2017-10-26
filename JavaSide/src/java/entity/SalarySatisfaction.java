package entity;

import java.util.Arrays;
import java.util.List;

/**
 *
 * @author jonah
 */
public class SalarySatisfaction extends Criteria {

    private int salaryInterest = -1;
    private List<String> explanations = Arrays.asList("Description 1", "Description 2", "Description 3",
            "Description 4", "Description 5", "Description 6", "Description 7", "Description 8",
            "Description 9", "Description 10");

    SalarySatisfaction(int salaryInterest) {
        weightage = 10;
        setSalaryInterest(salaryInterest);
        calculateSubScore();
    }

    /**
     *
     * @return
     */
    @Override
    public double calculateSubScore() {
        return super.calculateSubScore();
    }

    /**
     *
     * @return
     */
    @Override
    public String getExplanation() {
        if (salaryInterest != -1) {
            return explanations.get(salaryInterest - 1);
        }
        return super.getExplanation();
    }

    /**
     *
     * @return
     */
    public int getSalaryInterest() {
        return salaryInterest;
    }

    /**
     *
     * @param salaryInterest
     */
    public void setSalaryInterest(int salaryInterest) {
        this.salaryInterest = salaryInterest;
    }
}
