package entity;

import java.util.Arrays;
import java.util.List;

/**
 *
 * @author jonah
 */
public class CommuteComfort extends Criteria {

    private int averageRidersArea;
    private int ridersArea;
    private char travelMode;
    private double point = -1;
    private List<String> explanations = Arrays.asList("Description 1", "Description 2", "Description 3");

    CommuteComfort(int averageRidersArea, int ridersArea, char travelMode) {
        weightage = 15;
        setAverageRidersArea(averageRidersArea);
        setRidersArea(ridersArea);
        setTravelMode(travelMode);
        calculateSubScore();
    }

    /**
     *
     * @return
     */
    @Override
    public double calculateSubScore() {
        if (travelMode == 'p') {
            int difference = ridersArea - averageRidersArea;
            if (difference > 8000) {
                point = 0;
            } else if (difference < -8000) {
                point = 1;
            } else {
                point = 0.5;
            }
            return point * weightage;
        } else if (travelMode == 'c') {
            return weightage;
        }
        return super.calculateSubScore();
    }

    /**
     *
     * @return
     */
    @Override
    public String getExplanation() {
        if (point == 0) {
            return explanations.get(0);
        }
        if (point == 0.5) {
            return explanations.get(1);
        }
        if (point == 1) {
            return explanations.get(2);
        }
        return super.getExplanation();
    }

    /**
     *
     * @return
     */
    public int getAverageRidersArea() {
        return averageRidersArea;
    }

    /**
     *
     * @return
     */
    public int getRidersArea() {
        return ridersArea;
    }

    /**
     *
     * @return
     */
    public char getTravelMode() {
        return travelMode;
    }

    /**
     *
     * @param averageRidersArea
     */
    public void setAverageRidersArea(int averageRidersArea) {
        this.averageRidersArea = averageRidersArea;
    }

    /**
     *
     * @param ridersArea
     */
    public void setRidersArea(int ridersArea) {
        this.ridersArea = ridersArea;
    }

    /**
     *
     * @param travelMode
     */
    public void setTravelMode(char travelMode) {
        this.travelMode = travelMode;
    }
}
