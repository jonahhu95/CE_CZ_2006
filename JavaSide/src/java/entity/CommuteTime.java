package entity;

import java.util.Arrays;
import java.util.List;


public class CommuteTime extends Criteria {

    private int aveCommuteTime;
    private int commuteTime;
    private int point = -1;
    private List<String> explanations = Arrays.asList("Description 1", "Description 2", "Description 3",
            "Description 4", "Description 5", "Description 6", "Description 7", "Description 8",
            "Description 9");

    CommuteTime(int averageTravelTime, int travelTime) {
        weightage = 20;
        setAveCommuteTime(averageTravelTime);
        setCommuteTime(travelTime);
    }

    @Override
    public double calculateSubScore() {
        int difference = commuteTime - aveCommuteTime;
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

    public int getAveCommuteTime() {
        return aveCommuteTime;
    }

    public void setAveCommuteTime(int aveCommuteTime) {
        this.aveCommuteTime = aveCommuteTime;
    }

    public int getCommuteTime() {
        return commuteTime;
    }

    public void setCommuteTime(int commuteTime) {
        this.commuteTime = commuteTime;
    }
}
