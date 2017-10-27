package entity;

import java.util.Arrays;
import java.util.List;

/**
 *
 * @author jonah
 */
public class JobInterest extends Criteria {

    private int jobInterest = -1;
    private List<String> explanations = Arrays.asList("Description 1", "Description 2", "Description 3",
            "Description 4", "Description 5", "Description 6", "Description 7", "Description 8",
            "Description 9", "Description 10");

    JobInterest(int jobInterest) {
        weightage = 20;
        setJobInterest(jobInterest);
        calculateSubScore();
    }

    /**
     *
     * @return
     */
    @Override
    public double calculateSubScore() {
        return (jobInterest - 1) / 10 * weightage;
    }

    /**
     *
     * @return
     */
    @Override
    public String getExplanation() {
        if (jobInterest != -1) {
            return explanations.get(jobInterest - 1);
        }
        return super.getExplanation();
    }

    /**
     *
     * @return
     */
    public int getJobInterest() {
        return jobInterest;
    }

    /**
     *
     * @param jobInterest
     */
    public void setJobInterest(int jobInterest) {
        this.jobInterest = jobInterest;
    }
}
