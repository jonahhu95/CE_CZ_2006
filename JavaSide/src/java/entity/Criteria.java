package entity;


public abstract class Criteria {
    protected double weightage;

    public double calculateSubScore() {
        return 0;
    }

    public String getExplanation() {
        return "Error";
    }

    public double getWeightage(){
        return weightage;
    }
}
