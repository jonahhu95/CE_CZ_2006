/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package entity;

import okhttp3.*;
import org.json.*;

/**
 *
 * @author xy
 */
public class Address {
    private double longitude;
    private double latitude;
    private String locationName;
    private String area;
    
    public Address(String locationName, double longitude, double latitude, String area){
        setLocationName(locationName);
        setLongitude(longitude);
        setLatitude(latitude);
        setArea(area);
    }
    
    public double getLongitude() {
        return longitude;
    }

    public double getLatitude() {
        return latitude;
    }

    public String getLocationName() {
        return locationName;
    }

    public String getArea() {
        return area;
    }
    
    public void setLongitude(double longitude) {
        this.longitude = longitude;
    }

    public void setLatitude(double latitude) {
        this.latitude = latitude;
    }

    public void setLocationName(String locationName) {
        this.locationName = locationName;
    }

    public void setArea(String area) {
        this.area = area;
    }
    
    
}
