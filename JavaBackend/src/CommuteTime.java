/**
 * Created by jonah on 21/9/2017.
 */
public class CommuteTime extends Criteria {

    private int averageTravelTime;
    private int travelTime;

    CommuteTime(int averageTravelTime, int travelTime){
        setAverageTravelTime(averageTravelTime);
        setTravelTime(travelTime);
    }

    @Override
    public double calculateSubScore() {
        return super.calculateSubScore();
    }

    public int getAverageTravelTime() {
        return averageTravelTime;
    }

    public int getTravelTime() {
        return travelTime;
    }

    public void setAverageTravelTime(int averageTravelTime) {
        this.averageTravelTime = averageTravelTime;
    }

    public void setTravelTime(int travelTime) {
        this.travelTime = travelTime;
    }
}
