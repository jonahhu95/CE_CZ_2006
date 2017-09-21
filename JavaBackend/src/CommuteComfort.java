/**
 * Created by jonah on 21/9/2017.
 */
public class CommuteComfort extends Criteria{

    private int averageRidersArea;
    private int ridersArea;
    private char travelMode;

    CommuteComfort(int averageRidersArea, int ridersArea, char travelMode){
        weightage = 15;
        setAverageRidersArea(averageRidersArea);
        setRidersArea(ridersArea);
        setTravelMode(travelMode);
    }

    @Override
    public double calculateSubScore() {
        int difference = ridersArea - averageRidersArea;
        double point;
        if(difference>8000){
            point = 0;
        }else if(difference < -8000){
            point = 1;
        }else{
            point = 0.5;
        }
        return point*weightage;
    }

    public int getAverageRidersArea() {
        return averageRidersArea;
    }

    public int getRidersArea() {
        return ridersArea;
    }

    public char getTravelMode() {
        return travelMode;
    }

    public void setAverageRidersArea(int averageRidersArea) {
        this.averageRidersArea = averageRidersArea;
    }

    public void setRidersArea(int ridersArea) {
        this.ridersArea = ridersArea;
    }

    public void setTravelMode(char travelMode) {
        this.travelMode = travelMode;
    }
}
