/**
 * Created by jonah on 21/9/2017.
 */
public class Salary extends Criteria {

    private int salary;
    private int medianSalary;

    public Salary(int medianSalary, int salary){
        weightage = 20;
        setMedianSalary(medianSalary);
        setSalary(salary);
    }

    @Override
    public double calculateSubScore() {
        int difference = 0;
        int point;
        difference = salary - medianSalary;
        difference = difference/1000;
        switch (difference){
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
                if(difference > 4)
                    point = 9;
                else{
                    point = 0;
                }
                break;
        }
        return point/9 * weightage;
    }

    public int getMedianSalary() {
        return medianSalary;
    }

    public int getSalary() {
        return getSalary();
    }

    public void setMedianSalary(int medianSalary) {
        this.medianSalary = medianSalary;
    }

    public void setSalary(int salary) {
        this.salary = salary;
    }
}
