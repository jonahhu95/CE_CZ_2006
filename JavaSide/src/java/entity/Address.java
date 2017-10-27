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

    /**
     *
     * @param locationName
     * @param longitude
     * @param latitude
     * @param area
     */
    public Address(String locationName, double longitude, double latitude, String area) {
        setLocationName(locationName);
        setLongitude(longitude);
        setLatitude(latitude);
        setArea(area);
    }

    /**
     *
     * @return
     */
    public double getLongitude() {
        return longitude;
    }

    /**
     *
     * @return
     */
    public double getLatitude() {
        return latitude;
    }

    /**
     *
     * @return
     */
    public String getLocationName() {
        return locationName;
    }

    /**
     *
     * @return
     */
    public String getArea() {
        return area;
    }

    /**
     *
     * @param longitude
     */
    public void setLongitude(double longitude) {
        this.longitude = longitude;
    }

    /**
     *
     * @param latitude
     */
    public void setLatitude(double latitude) {
        this.latitude = latitude;
    }

    /**
     *
     * @param locationName
     */
    public void setLocationName(String locationName) {
        this.locationName = locationName;
    }

    /**
     *
     * @param area
     */
    public void setArea(String area) {
        this.area = area;
    }

}
