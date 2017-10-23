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
public class address {
    String lng;
    String lat;
    
    public String getLongitude(){
        return lng;
    }
    public String getLatitude(){
        return lat;
    }
    public void setLongitude(String longitude){
        this.lng = longitude;
    }
    public void setLatitude(String latitude){
        this.lat = latitude;
    }
    
    public address(){
        
    }
    public address(String location){
        try{
            String url = generateCall_retriveLocation(location);
            OkHttpClient clientAdd = new OkHttpClient();
            Request requestAdd = new Request.Builder().url(url).build();
            Response responseAdd = clientAdd.newCall(requestAdd).execute();
            
            if(responseAdd.isSuccessful()){
                String resultAdd = responseAdd.body().string();
                JSONObject JSONResult = new JSONObject(resultAdd);
                JSONArray resultArray = (JSONArray) JSONResult.get("results");
                JSONObject resultAddress = resultArray.optJSONObject(0).getJSONObject("geometry").getJSONObject("location");
                
                lng = (String)resultAddress.optString("lng");
                lat = (String)resultAddress.optString("lat");
            }
        }
        catch(Exception e){

        }
    }
    
    private String generateCall_retriveLocation(String location){
        //google api key AIzaSyCpfcGTHKxaYAJA_n_5jCVkJCeG9zBiJwA
        String APIKey = "AIzaSyCpfcGTHKxaYAJA_n_5jCVkJCeG9zBiJwA";
        String url = "https://maps.googleapis.com/maps/api/geocode/json?address=";
        //to do, remove spaces from the location if location != postal code
        url = url + location;
        url = url + "&key=" + APIKey;
        return url;
    }
}
