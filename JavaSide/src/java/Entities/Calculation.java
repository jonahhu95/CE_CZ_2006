package Entities;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by jonah on 21/9/2017.
 */
public class Calculation {

    private List<Criteria> criteriaList;
    private double JSIScore;
    private long createdTime;
    private String workLocation;
    private String homeLoction;
    private int salary;
    private char commuteType;
    private int jobInterest;
    private int salarySatisfaction;

    Calculation(String workLocation, String homeLoction, int salary, char commuteType,
                int jobInterest, int salarySatisfaction) throws Exception{
        createdTime = System.currentTimeMillis();
        setWorkLocation(workLocation);
        setHomeLoction(homeLoction);
        setSalary(salary);
        setCommuteType(commuteType);
        setJobInterest(jobInterest);
        setSalarySatisfaction(salarySatisfaction);
        criteriaList = new ArrayList<>();

        try{
            createCriteria_Salary(); //0
            createCriteria_CommuteComfort(); //1
            createCriteria_CommuteCost(); //2
            createCriteria_CommuteTime(); //3
            createCriteria_JobInterest(); //4
            createCriteria_SalarySatisfaction(); //5
        }catch (Exception e){
            throw new Exception("Something went wrong");
        }

    }

    public String getWorkLocation() {
        return workLocation;
    }

    public String getHomeLoction() {
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

    public double getJSIScore() {
        double total = 0;
        for(int n = 0; n < criteriaList.size(); n++){
            total = total + criteriaList.get(n).calculateSubScore();
        }
        return total;
    }

    public void setWorkLocation(String workLocation) {
        this.workLocation = workLocation;
    }

    public void setHomeLoction(String homeLoction) {
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

    public void createCriteria_Salary() throws Exception{
        if(!checkIfExist(Salary.class)){
            Criteria hold = new Salary(2500,salary); //TODO: replace with API value
            criteriaList.add(hold);
        }else{
            throw new Exception("Salary criteria already exist");
        }
    }

    public void createCriteria_CommuteComfort() throws Exception{
        if(!checkIfExist(CommuteComfort.class)){
            Criteria hold = new CommuteComfort(1000,1000, commuteType); //TODO: replace with API value
            criteriaList.add(hold);
        }else{
            throw new Exception("Commute Comfort criteria already exist");
        }
    }

    public void createCriteria_CommuteTime() throws Exception{
        if(!checkIfExist(CommuteTime.class)){
            Criteria hold = new CommuteTime(1000,1000); //TODO: replace with API value
            criteriaList.add(hold);
        }else{
            throw new Exception("Commute Time criteria already exist");
        }
    }

    public void createCriteria_CommuteCost() throws Exception{
        if(!checkIfExist(CommuteCost.class)){
            Criteria hold = new CommuteCost(100,salary); //TODO: replace with API value
            criteriaList.add(hold);
        }else{
            throw new Exception("Commute Cost criteria already exist");
        }
    }

    public void createCriteria_JobInterest() throws Exception{
        if(!checkIfExist(JobInterest.class)){
            Criteria hold = new JobInterest(jobInterest);
            criteriaList.add(hold);
        }else{
            throw new Exception("Job Interest criteria already exist");
        }
    }

    public void createCriteria_SalarySatisfaction() throws Exception{
        if(!checkIfExist(SalarySatisfaction.class)){
            Criteria hold = new SalarySatisfaction(salarySatisfaction);
            criteriaList.add(hold);
        }else{
            throw new Exception("Salary Interest criteria already exist");
        }
    }

    public String getCriteriaExplanation_Salary(){
        for(int n = 0; n < criteriaList.size(); n++){
            if(criteriaList.get(n).getClass() == Salary.class)
                return criteriaList.get(n).getExplanation();
        }
        return "Error";
    }

    public String getCriteriaExplanation_CommuteComfort(){
        for(int n = 0; n < criteriaList.size(); n++){
            if(criteriaList.get(n).getClass() == CommuteComfort.class)
                return criteriaList.get(n).getExplanation();
        }
        return "Error";
    }

    public String getCriteriaExplanation_CommuteTime(){
        for(int n = 0; n < criteriaList.size(); n++){
            if(criteriaList.get(n).getClass() == CommuteTime.class)
                return criteriaList.get(n).getExplanation();
        }
        return "Error";
    }

    public String getCriteriaExplanation_CommuteCost(){
        for(int n = 0; n < criteriaList.size(); n++){
            if(criteriaList.get(n).getClass() == CommuteCost.class)
                return criteriaList.get(n).getExplanation();
        }
        return "Error";
    }

    public String getCriteriaExplanation_JobInterest(){
        for(int n = 0; n < criteriaList.size(); n++){
            if(criteriaList.get(n).getClass() == JobInterest.class)
                return criteriaList.get(n).getExplanation();
        }
        return "Error";
    }

    public String getCriteriaExplanation_SalarySatisfaction(){
        for(int n = 0; n < criteriaList.size(); n++){
            if(criteriaList.get(n).getClass() == SalarySatisfaction.class)
                return criteriaList.get(n).getExplanation();
        }
        return "Error";
    }

    public double[] getCriteriaMark_Salary(){
        double[] ret = {0.0, 0.0};
        for(int n = 0; n < criteriaList.size(); n++){
            if(criteriaList.get(n).getClass() == Salary.class)
                ret[0] = criteriaList.get(n).calculateSubScore();
        }
        return ret;
    }

    public double[] getCriteriaMark_CommuteComfort(){
        double[] ret = {0.0, 0.0};
        for(int n = 0; n < criteriaList.size(); n++){
            if(criteriaList.get(n).getClass() == CommuteComfort.class){
                ret[0] = criteriaList.get(n).calculateSubScore();
                ret[1] = criteriaList.get(n).getWeightage();
            }

        }
        return ret;
    }

    public double[] getCriteriaMark_CommuteTime(){
        double[] ret = {0.0, 0.0};
        for(int n = 0; n < criteriaList.size(); n++){
            if(criteriaList.get(n).getClass() == CommuteTime.class){
                ret[0] = criteriaList.get(n).calculateSubScore();
                ret[1] = criteriaList.get(n).getWeightage();
            }
        }
        return ret;
    }

    public double[] getCriteriaMark_CommuteCost(){
        double[] ret = {0.0, 0.0};
        for(int n = 0; n < criteriaList.size(); n++){
            if(criteriaList.get(n).getClass() == CommuteCost.class){
                ret[0] = criteriaList.get(n).calculateSubScore();
                ret[1] = criteriaList.get(n).getWeightage();
            }
        }
        return ret;
    }

    public double[] getCriteriaMark_JobInterest(){
        double[] ret = {0.0, 0.0};
        for(int n = 0; n < criteriaList.size(); n++){
            if(criteriaList.get(n).getClass() == JobInterest.class){
                ret[0] = criteriaList.get(n).calculateSubScore();
                ret[1] = criteriaList.get(n).getWeightage();
            }
        }
        return ret;
    }

    public double[] getCriteriaMark_SalarySatisfaction(){
        double[] ret = {0.0, 0.0};
        for(int n = 0; n < criteriaList.size(); n++){
            if(criteriaList.get(n).getClass() == SalarySatisfaction.class){
                ret[0] = criteriaList.get(n).calculateSubScore();
                ret[1] = criteriaList.get(n).getWeightage();
            }
        }
        return ret;
    }



    private boolean checkIfExist(Class check){
        for(int n = 0; n < criteriaList.size(); n++){
            if(criteriaList.get(n).getClass()==check)
                return true;
        }
        return false;
    }

}
