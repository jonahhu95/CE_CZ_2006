package Entities;

import java.util.Arrays;
import java.util.List;

/**
 * Created by jonah on 21/9/2017.
 */
public class CommuteTime extends Criteria {

    private int averageTravelTime;
    private int travelTime;
    private int point = -1;
    private List<String> explanations = Arrays.asList("Description 1", "Description 2", "Description 3",
            "Description 4", "Description 5", "Description 6", "Description 7", "Description 8",
            "Description 9");

    CommuteTime(int averageTravelTime, int travelTime) {
        weightage = 20;
        setAverageTravelTime(averageTravelTime);
        setTravelTime(travelTime);
    }

    @Override
    public double calculateSubScore() {
        int difference = travelTime - averageTravelTime;
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
                if(difference >= -30){
                    point = 5 ;
                }else{
                    point = 6;
                }
            }else if(difference <= -60){
                point = 7;
            }else{
                point = 8;
            }
        }
        return point/8 * weightage;
    }

    @Override
    public String getExplanation() {
        if(point != -1)
            return explanations.get(point);
        return super.getExplanation();
    }

    public int getAverageTravelTime() {
        return averageTravelTime;
    }

    public void setAverageTravelTime(int averageTravelTime) {
        this.averageTravelTime = averageTravelTime;
    }

    public int getTravelTime() {
        return travelTime;
    }

    public void setTravelTime(int travelTime) {
        this.travelTime = travelTime;
    }
}
