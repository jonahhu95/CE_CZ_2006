package control;

import entity.Address;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Calendar;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import okhttp3.MediaType;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.RequestBody;
import okhttp3.Response;
import org.json.JSONArray;
import org.json.JSONObject;

/**
 *
 * @
 */
public class ApiFetcher {

    private String accessToken = null;
    private String googleApiKey = "AIzaSyDh0GkxyS2a9Sc1Uy-u0Z8Q-7_LBhYeHPk";

    /**
     *
     */
    public ApiFetcher() {
        getAccessToken();
        if (accessToken == null) {
            //ERROR HANDLING
        }

    }

    /**
     *
     */
    public void test() {
        String location = ""; //input
        String APIKey = "AIzaSyCpfcGTHKxaYAJA_n_5jCVkJCeG9zBiJwA";
        String url = "https://maps.googleapis.com/maps/api/geocode/json?address=";
        url = url + location;
        url = url + "&key=" + APIKey;
        String test;
        try {
            test = doGetRequest(url);
        } catch (IOException ex) {
            Logger.getLogger(ApiFetcher.class.getName()).log(Level.SEVERE, null, ex);
        }
        int m = 1;
    }

    /**
     * Returns area name based on oneMap's planning area. The longitude argument
     * must specify the longitude of the location The latitude argument must
     * specify the latitude of the location
     * <p>
     * This method does a HTTP get request to the relevant API before it returns
     * the area name
     *
     * @param longitude longitude of the location
     * @param latitude latitude of the location
     * @return planning area name of the location
     */
    public String getArea(double longitude, double latitude) {
        String url;
        JSONObject obj = null;
        String ret = null;
        int year = Calendar.getInstance().get(Calendar.YEAR);

        while (year > 1965) {
            try {
                url = generateCall_GetArea(longitude, latitude, year);
                String res = doGetRequest(url);
                if (checkJSONResponse_oneMap(res)) {
                    obj = new JSONArray(res).getJSONObject(0);
                    ret = obj.getString("pln_area_n");
                    break;
                } else {
                    year--;
                    continue;
                }
            } catch (Exception ex) {
                break;
            }
        }
        return ret;
    }

    /**
     *
     * @return
     */
    public double getAverageCommuteTime() {
        return 40.0;
    }

    /**
     *
     * @return
     */
    c

    /**
     *
     * @param area
     * @return
     */
    public int getNumberOfRiders(String area) {

        String url;
        JSONObject obj = null;
        int total = -1;
        int year = Calendar.getInstance().get(Calendar.YEAR);
        List<String> key = new ArrayList<>(Arrays.asList("mrt_bus", "mrt",
                "bus", "mrt_car", "mrt_other"));

        while (year > 1965) {
            try {
                url = generateCall_NumberOfRiders(area, year);
                String res = doGetRequest(url);
                if (checkJSONResponse_oneMap(res)) {
                    obj = new JSONArray(res).getJSONObject(0);
                } else {
                    year--;
                    continue;
                }
                int check;
                total = 0;
                for (check = 0; check < key.size(); check++) {
                    if (!obj.isNull(key.get(check))) {
                        total = total + obj.getInt(key.get(check));
                    }
                }
                break;
            } catch (Exception ex) {
                break;
            }
        }
        return total;
    }

    /**
     *
     * @param area
     * @return
     */
    public int getMedianSalary(String area) {
        String url;
        JSONObject obj = null;
        int totalAreaPopulation = 0, median = 0, salaryRange = 0;;
        int year = Calendar.getInstance().get(Calendar.YEAR);
        List<String> key = new ArrayList<>(Arrays.asList("below_sgd_1000",
                "sgd_1000_to_1499", "sgd_1500_to_1999", "sgd_2000_to_2499",
                "sgd_2500_to_2999", "sgd_3000_to_3999", "sgd_4000_to_4999",
                "sgd_5000_to_5999", "sgd_6000_to_6999", "sgd_7000_to_7999",
                "sgd_8000_over"));

        while (year > 1965) {
            try {
                url = generateCall_GetMedianSalary(area, year);
                String res = doGetRequest(url);
                if (checkJSONResponse_oneMap(res)) {
                    obj = new JSONArray(res).getJSONObject(0);
                    for (int n = 0; n < key.size(); n++) {
                        if (!obj.isNull(key.get(n))) {
                            totalAreaPopulation = totalAreaPopulation + obj.getInt(key.get(n));
                        }
                    }
                    median = totalAreaPopulation / 2;
                    for (salaryRange = 0; salaryRange < key.size(); salaryRange++) {
                        if (!obj.isNull(key.get(salaryRange))) {
                            median = median - obj.getInt(key.get(salaryRange));
                        }
                        if (median < 0) {
                            return 750 + (salaryRange * 500);
                        }
                    }
                } else {
                    year--;
                    continue;
                }
            } catch (Exception ex) {
                break;
            }
        }
        return -1;
    }

    /**
     *
     * @param locationName
     * @return
     */
    public double[] getCoordinates(String locationName) {
        String url;
        JSONObject obj;
        double[] geo = new double[2];
        try {
            url = generateCall_GetCoordinates(locationName);
            String res = doGetRequest(url);
            if (checkJSONResponse_google(res)) {
                obj = new JSONObject(res);
                JSONArray ar = obj.getJSONArray("results");
                JSONObject hold = ar.getJSONObject(0);
                JSONObject hold2 = hold.getJSONObject("geometry");
                JSONObject hold3 = hold2.getJSONObject("location");
                geo[0] = (Double) hold3.get("lng");
                geo[1] = (Double) hold3.get("lat");
            }
        } catch (Exception ex) {
            geo = null;
        }
        return geo;
    }

    /**
     *
     * @param homeLocation
     * @param workLocation
     * @return
     */
    public double[] getCommuteTimeCost(Address homeLocation, Address workLocation) {
        String url;
        JSONObject obj;
        double[] ret = new double[2];
        try {
            url = generateCall_GetCommuteTimeCost(homeLocation.getLongitude(), homeLocation.getLatitude(),
                    workLocation.getLongitude(), workLocation.getLatitude());
            String res = doGetRequest(url);
            if (checkJSONResponse_streetDirectory(res)) {
                obj = new JSONObject(res);
                JSONObject hold = obj.getJSONObject("total_data");
                ret[0] = (Double) hold.get("tm");
                ret[1] = (Double) hold.get("tr");
            }
        } catch (Exception ex) {
            ret = null;
        }
        return ret;
    }

    //-----------Helper Methods-----------
    private List<String> getAllPlanningArea() {

        String url;
        JSONArray jsAr;
        List<String> ret = new ArrayList();
        int year = Calendar.getInstance().get(Calendar.YEAR);

        while (year > 1965) {
            try {
                url = generateCall_GetAllPlanningArea(year);
                String response = doGetRequest(url);
                jsAr = new JSONArray(response);
                if (jsAr.length() < 2) {
                    year--;
                    continue;
                }
                for (int n = 0; n < jsAr.length(); n++) {
                    JSONObject obj = jsAr.getJSONObject(n);
                    ret.add(obj.getString("pln_area_n"));
                }
                return ret;
            } catch (Exception ex) {
                System.out.println(ex.getMessage());
                break;
            }
        }

        return null;
    }

    private String generateCall_NumberOfRiders(String area, int year) {
        String url = "https://developers.onemap.sg/privateapi/popapi/getModeOfTransportWork?";
        url = url + "token=" + accessToken;
        url = url + "&year=" + String.valueOf(year);
        url = url + "&planningArea=" + area;
        return url;
    }

    private String generateCall_GetAllPlanningArea(int year) {
        String url = "https://developers.onemap.sg/privateapi/popapi/getPlanningareaNames?";
        url = url + "token=" + accessToken;
        url = url + "&year=" + String.valueOf(year);
        return url;
    }

    private String generateCall_GetMedianSalary(String area, int year) {
        String url = "https://developers.onemap.sg/privateapi/popapi/getIncomeFromWork?";
        url = url + "token=" + accessToken;
        url = url + "&planningArea=" + area;
        url = url + "&year=" + String.valueOf(year);
        return url;
    }

    private String generateCall_GetArea(double longitude, double latitude, int year) {
        String url = "https://developers.onemap.sg/privateapi/popapi/getPlanningarea?";
        url = url + "token=" + accessToken;
        url = url + "&lat=" + String.valueOf(latitude);
        url = url + "&lng=" + String.valueOf(longitude);
        url = url + "&year=" + String.valueOf(year);
        return url;
    }

    private String generateCall_GetCoordinates(String locationName) {
        String url = "https://maps.googleapis.com/maps/api/place/textsearch/json?query=";
        url = url + "qury=" + locationName.replace(" ", "+");
        url = url + "&key=" + googleApiKey;
        return url;
    }

    private String generateCall_GetCommuteTimeCost(double start_lng, double start_lat, double end_lng, double end_lat) {

        String url = "http://www.streetdirectory.com/api/?mode=journey&output=json&country=sg&";
        url = url + "q=" + start_lng + "," + start_lat + "%20to%" + end_lng + "," + end_lat;
        url = url + "&methods=bustrain&info=1&time=08:00%00AM";
        return url;
    }

    private String doPostRequest(String url) throws IOException {
        OkHttpClient client = new OkHttpClient();
        Request request = new Request.Builder()
                .url(url)
                .build();
        Response response = client.newCall(request).execute();
        if (response.isSuccessful()) {
            return response.body().string();
        }
        return null;
    }

    private String doGetRequest(String url) throws IOException {
        OkHttpClient client = new OkHttpClient();
        Request request = new Request.Builder()
                .url(url).get().build();
        Response response = client.newCall(request).execute();
        if (response.isSuccessful()) {
            return response.body().string();
        }
        return null;
    }

    private boolean checkJSONResponse_google(String res) {
        JSONObject obj = null;
        JSONArray jArray = null;
        try {
            obj = new JSONObject(res);
            if (obj.get("status").equals("OK")) {
                return true;
            }
        } catch (Exception e) {
            return false;
        }
        return false;
    }

    private boolean checkJSONResponse_oneMap(String res) {
        JSONObject obj = null;
        JSONArray jArray = null;
        boolean objTrue = false;
        try {
            jArray = new JSONArray(res);
        } catch (Exception e) {
            try {
                obj = new JSONObject(res);
                objTrue = true;
            } catch (Exception f) {
                return false;
            }
        }
        try {
            JSONObject temp;
            if (objTrue) {
                temp = obj;
            } else {
                temp = jArray.getJSONObject(0);
            }
            if (temp.has("Result")) {
                if (temp.getString("Result").equals("No Data Available!")) {
                    return false;
                }
            }
        } catch (Exception e) {
            return false;
        }
        return true;
    }

    private boolean checkJSONResponse_streetDirectory(String res) {
        JSONObject obj = null;
        JSONArray jArray = null;
        try {
            obj = new JSONObject(res);
            if (obj.isNull("routes")) {
                return false;
            }
        } catch (Exception e) {
            return false;
        }
        return true;
    }

    private void getAccessToken() {
        try {
            OkHttpClient client = new OkHttpClient();

            MediaType mediaType = MediaType.parse("multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW");
            RequestBody body = RequestBody.create(mediaType, "------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"email\"\r\n\r\njonahhu95@gmail.com\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"password\"\r\n\r\n3DEGREE\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW--");
            Request request = new Request.Builder()
                    .url("https://developers.onemap.sg/privateapi/auth/post/getToken")
                    .post(body)
                    .addHeader("content-type", "multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW")
                    .build();
            Response response = client.newCall(request).execute();
            if (response.isSuccessful()) {
                String res = response.body().string();
                accessToken = res.substring(res.indexOf("\":\"") + 3, res.indexOf("\",\""));
            }
        } catch (Exception e) {
            //ERROR HANDLING
        }
    }

}
