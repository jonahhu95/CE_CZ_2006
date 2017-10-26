package entity;

import java.util.Arrays;
import java.util.List;

/**
 *
 * @author jonah
 */
public class Salary extends Criteria {

    private int salary;
    private int medianSalary;
    private int point = -1;
    private List<String> explanations = Arrays.asList("Description 1", "Description 2", "Description 3",
            "Description 4", "Description 5", "Description 6", "Description 7", "Description 8",
            "Description 9", "Description 10");

    /**
     *
     * @param medianSalary
     * @param salary
     */
    public Salary(int medianSalary, int salary) {
        weightage = 20;
        setMedianSalary(medianSalary);
        setSalary(salary);
        calculateSubScore();
    }

    /**
     *
     * @return
     */
    @Override
    public double calculateSubScore() {
        int difference = 0;
        difference = salary - medianSalary;
        difference = difference / 1000;
        switch (difference) {
            case -4:
                point = 0;
                break;
            case -3:
                point = 1;
                break;
            case -2:
                point = 2;
                break;
            case -1:
                point = 3;
                break;
            case 0:
                point = 4;
                break;
            case 1:
                point = 5;
                break;
            case 2:
                point = 6;
                break;
            case 3:
                point = 7;
                break;
            case 4:
                point = 8;
                break;
            default:
                if (difference > 4) {
                    point = 9;
                } else {
                    point = 0;
                }
                break;
        }
        return point / 9 * weightage;
    }

    /**
     *
     * @return
     */
    @Override
    public String getExplanation() {
        if (point != -1) {
            return explanations.get(point);
        }
        return super.getExplanation();
    }

    /**
     *
     * @return
     */
    public int getMedianSalary() {
        return medianSalary;
    }

    /**
     *
     * @return
     */
    public int getSalary() {
        return getSalary();
    }

    /**
     *
     * @param medianSalary
     */
    public void setMedianSalary(int medianSalary) {
        this.medianSalary = medianSalary;
    }

    /**
     *
     * @param salary
     */
    public void setSalary(int salary) {
        this.salary = salary;
    }
}
