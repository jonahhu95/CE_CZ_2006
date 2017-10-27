package entity;

/**
 *
 * @author jonah
 */
public abstract class Criteria {

    /**
     *
     */
    protected double weightage;

    /**
     *
     * @return
     */
    public double calculateSubScore() {
        return 0;
    }

    /**
     *
     * @return
     */
    public String getExplanation() {
        return "Error";
    }

    /**
     *
     * @return
     */
    public double getWeightage() {
        return weightage;
    }
}
