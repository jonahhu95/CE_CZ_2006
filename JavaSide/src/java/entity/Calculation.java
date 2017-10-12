package entity;

import control.ApiFetcher;
import java.util.ArrayList;
import java.util.List;
import javafx.util.Pair;

public class Calculation {

    private List<Criteria> criteriaList;
    private double JSIScore;
    private long createdTime;
    private Pair workLocation;
    private Pair homeLoction;
    private int salary;
    private char commuteType;
    private int jobInterest;
    private int salarySatisfaction;

    private int medianSalary;
    private int ridersArea;
    private int aveRidersArea;
    private int commuteTime;
    private int aveCommuteTime;
    private int monthlyCommuteCost;

    private ApiFetcher apiFetch;

    Calculation(Pair workLocation, Pair homeLoction, int salary, char commuteType,
            int jobInterest, int salarySatisfaction, long createdTime, int medianSalary,
            int ridersArea, int aveRidersArea, int commuteTime, int aveCommuteTime,
            int monthlyCommuteCost) throws Exception {
        setCreatedTime(createdTime);
        setWorkLocation(workLocation);
        setHomeLoction(homeLoction);
        setSalary(salary);
        setCommuteType(commuteType);
        setJobInterest(jobInterest);
        setSalarySatisfaction(salarySatisfaction);
        setMedianSalary(medianSalary);
        setRidersArea(ridersArea);
        setAveRidersArea(aveRidersArea);
        setCommuteTime(commuteTime);
        setAveCommuteTime(aveCommuteTime);
        setMonthlyCommuteCost(monthlyCommuteCost);
        criteriaList = new ArrayList<>();

        try {
            createCriteria_Salary(); //0
            createCriteria_CommuteComfort(); //1
            createCriteria_CommuteCost(); //2
            createCriteria_CommuteTime(); //3
            createCriteria_JobInterest(); //4
            createCriteria_SalarySatisfaction(); //5
        } catch (Exception e) {
            throw new Exception("Something went wrong");
        }

    }

    public Pair getWorkLocation() {
        return workLocation;
    }

    public Pair getHomeLoction() {
        return homeLoction;
    }

    public int getSalary() {
        return salary;
    }

    public char getCommuteType() {
        return commuteType;
    }

    public int getJobInterest() {
        return jobInterest;
    }

    public long getCreatedTime() {
        return createdTime;
    }

    public int getMedianSalary() {
        return medianSalary;
    }

    public int getRidersArea() {
        return ridersArea;
    }

    public int getAveRidersArea() {
        return aveRidersArea;
    }

    public int getCommuteTime() {
        return commuteTime;
    }

    public int getAveCommuteTime() {
        return aveCommuteTime;
    }

    public int getMonthlyCommuteCost() {
        return monthlyCommuteCost;
    }

    public double getJSIScore() {
        double total = 0;
        for (int n = 0; n < criteriaList.size(); n++) {
            total = total + criteriaList.get(n).calculateSubScore();
        }
        return total;
    }

    public void setWorkLocation(Pair workLocation) {
        this.workLocation = workLocation;
    }

    public void setHomeLoction(Pair homeLoction) {
        this.homeLoction = homeLoction;
    }

    public void setSalary(int salary) {
        this.salary = salary;
    }

    public void setCommuteType(char commuteType) {
        this.commuteType = commuteType;
    }

    public void setJobInterest(int jobInterest) {
        this.jobInterest = jobInterest;
    }

    public void setSalarySatisfaction(int salarySatisfaction) {
        this.salarySatisfaction = salarySatisfaction;
    }

    public void setCreatedTime(long createdTime) {
        this.createdTime = createdTime;
    }

    public void setMedianSalary(int medianSalary) {
        this.medianSalary = medianSalary;
    }

    public void setRidersArea(int ridersArea) {
        this.ridersArea = ridersArea;
    }

    public void setAveRidersArea(int aveRidersArea) {
        this.aveRidersArea = aveRidersArea;
    }

    public void setCommuteTime(int commuteTime) {
        this.commuteTime = commuteTime;
    }

    public void setAveCommuteTime(int aveCommuteTime) {
        this.aveCommuteTime = aveCommuteTime;
    }

    public void setMonthlyCommuteCost(int monthlyCommuteCost) {
        this.monthlyCommuteCost = monthlyCommuteCost;
    }

    public void createCriteria_Salary() throws Exception {
        if (!checkIfExist(Salary.class)) {
            Criteria hold = new Salary(medianSalary, salary);
            criteriaList.add(hold);
        } else {
            throw new Exception("Salary criteria already exist");
        }
    }

    public void createCriteria_CommuteComfort() throws Exception {
        if (!checkIfExist(CommuteComfort.class)) {
            Criteria hold = new CommuteComfort(aveRidersArea, ridersArea, commuteType);
            criteriaList.add(hold);
        } else {
            throw new Exception("Commute Comfort criteria already exist");
        }
    }

    public void createCriteria_CommuteTime() throws Exception {
        if (!checkIfExist(CommuteTime.class)) {
            Criteria hold = new CommuteTime(aveCommuteTime, commuteTime);
            criteriaList.add(hold);
        } else {
            throw new Exception("Commute Time criteria already exist");
        }
    }

    public void createCriteria_CommuteCost() throws Exception {
        if (!checkIfExist(CommuteCost.class)) {
            Criteria hold = new CommuteCost(monthlyCommuteCost, salary);
            criteriaList.add(hold);
        } else {
            throw new Exception("Commute Cost criteria already exist");
        }
    }

    public void createCriteria_JobInterest() throws Exception {
        if (!checkIfExist(JobInterest.class)) {
            Criteria hold = new JobInterest(jobInterest);
            criteriaList.add(hold);
        } else {
            throw new Exception("Job Interest criteria already exist");
        }
    }

    public void createCriteria_SalarySatisfaction() throws Exception {
        if (!checkIfExist(SalarySatisfaction.class)) {
            Criteria hold = new SalarySatisfaction(salarySatisfaction);
            criteriaList.add(hold);
        } else {
            throw new Exception("Salary Interest criteria already exist");
        }
    }

    public String getCriteriaExplanation_Salary() {
        for (int n = 0; n < criteriaList.size(); n++) {
            if (criteriaList.get(n).getClass() == Salary.class) {
                return criteriaList.get(n).getExplanation();
            }
        }
        return "Error";
    }

    public String getCriteriaExplanation_CommuteComfort() {
        for (int n = 0; n < criteriaList.size(); n++) {
            if (criteriaList.get(n).getClass() == CommuteComfort.class) {
                return criteriaList.get(n).getExplanation();
            }
        }
        return "Error";
    }

    public String getCriteriaExplanation_CommuteTime() {
        for (int n = 0; n < criteriaList.size(); n++) {
            if (criteriaList.get(n).getClass() == CommuteTime.class) {
                return criteriaList.get(n).getExplanation();
            }
        }
        return "Error";
    }

    public String getCriteriaExplanation_CommuteCost() {
        for (int n = 0; n < criteriaList.size(); n++) {
            if (criteriaList.get(n).getClass() == CommuteCost.class) {
                return criteriaList.get(n).getExplanation();
            }
        }
        return "Error";
    }

    public String getCriteriaExplanation_JobInterest() {
        for (int n = 0; n < criteriaList.size(); n++) {
            if (criteriaList.get(n).getClass() == JobInterest.class) {
                return criteriaList.get(n).getExplanation();
            }
        }
        return "Error";
    }

    public String getCriteriaExplanation_SalarySatisfaction() {
        for (int n = 0; n < criteriaList.size(); n++) {
            if (criteriaList.get(n).getClass() == SalarySatisfaction.class) {
                return criteriaList.get(n).getExplanation();
            }
        }
        return "Error";
    }

    public double[] getCriteriaMark_Salary() {
        double[] ret = {0.0, 0.0};
        for (int n = 0; n < criteriaList.size(); n++) {
            if (criteriaList.get(n).getClass() == Salary.class) {
                ret[0] = criteriaList.get(n).calculateSubScore();
            }
        }
        return ret;
    }

    public double[] getCriteriaMark_CommuteComfort() {
        double[] ret = {0.0, 0.0};
        for (int n = 0; n < criteriaList.size(); n++) {
            if (criteriaList.get(n).getClass() == CommuteComfort.class) {
                ret[0] = criteriaList.get(n).calculateSubScore();
                ret[1] = criteriaList.get(n).getWeightage();
            }

        }
        return ret;
    }

    public double[] getCriteriaMark_CommuteTime() {
        double[] ret = {0.0, 0.0};
        for (int n = 0; n < criteriaList.size(); n++) {
            if (criteriaList.get(n).getClass() == CommuteTime.class) {
                ret[0] = criteriaList.get(n).calculateSubScore();
                ret[1] = criteriaList.get(n).getWeightage();
            }
        }
        return ret;
    }

    public double[] getCriteriaMark_CommuteCost() {
        double[] ret = {0.0, 0.0};
        for (int n = 0; n < criteriaList.size(); n++) {
            if (criteriaList.get(n).getClass() == CommuteCost.class) {
                ret[0] = criteriaList.get(n).calculateSubScore();
                ret[1] = criteriaList.get(n).getWeightage();
            }
        }
        return ret;
    }

    public double[] getCriteriaMark_JobInterest() {
        double[] ret = {0.0, 0.0};
        for (int n = 0; n < criteriaList.size(); n++) {
            if (criteriaList.get(n).getClass() == JobInterest.class) {
                ret[0] = criteriaList.get(n).calculateSubScore();
                ret[1] = criteriaList.get(n).getWeightage();
            }
        }
        return ret;
    }

    public double[] getCriteriaMark_SalarySatisfaction() {
        double[] ret = {0.0, 0.0};
        for (int n = 0; n < criteriaList.size(); n++) {
            if (criteriaList.get(n).getClass() == SalarySatisfaction.class) {
                ret[0] = criteriaList.get(n).calculateSubScore();
                ret[1] = criteriaList.get(n).getWeightage();
            }
        }
        return ret;
    }

    private boolean checkIfExist(Class check) {
        for (int n = 0; n < criteriaList.size(); n++) {
            if (criteriaList.get(n).getClass() == check) {
                return true;
            }
        }
        return false;
    }

}
