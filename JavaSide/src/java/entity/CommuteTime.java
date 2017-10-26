package entity;

import java.util.Arrays;
import java.util.List;

/**
 *
 * @author jonah
 */
public class CommuteTime extends Criteria {

    private double aveCommuteTime;
    private double commuteTime;
    private int point = -1;
    private List<String> explanations = Arrays.asList("Description 1", "Description 2", "Description 3",
            "Description 4", "Description 5", "Description 6", "Description 7", "Description 8",
            "Description 9");

    CommuteTime(double averageTravelTime, double travelTime) {
        weightage = 20;
        setAveCommuteTime(averageTravelTime);
        setCommuteTime(travelTime);
        calculateSubScore();
    }

    /**
     *
     * @return
     */
    @Override
    public double calculateSubScore() {
        double difference = commuteTime - aveCommuteTime;
        if (difference >= -15) {
            if (difference <= 15) {
                point = 4;
            } else if (difference <= 45) {
                if (difference <= 30) {
                    point = 3;
                } else {
                    point = 2;
                }
            } else if (difference <= 60) {
                point = 1;
            } else {
                point = 0;
            }
        } else {
            if (difference >= -45) {
                if (difference >= -30) {
                    point = 5;
                } else {
                    point = 6;
                }
            } else if (difference <= -60) {
                point = 7;
            } else {
                point = 8;
            }
        }
        return point / 8 * weightage;
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
    public double getAveCommuteTime() {
        return aveCommuteTime;
    }

    /**
     *
     * @param aveCommuteTime
     */
    public void setAveCommuteTime(double aveCommuteTime) {
        this.aveCommuteTime = aveCommuteTime;
    }

    /**
     *
     * @return
     */
    public double getCommuteTime() {
        return commuteTime;
    }

    /**
     *
     * @param commuteTime
     */
    public void setCommuteTime(double commuteTime) {
        this.commuteTime = commuteTime;
    }
}
