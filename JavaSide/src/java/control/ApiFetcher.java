package control;

import java.io.IOException;
import java.util.ArrayList;
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
import org.json.JSONException;
import org.json.JSONObject;

public class ApiFetcher {

    private String accessToken = null;

    public ApiFetcher() {
        getAccessToken();
        if (accessToken == null) {
            //ERROR HANDLING
        }

    }

    public double getAverageCommuteTime() {
        return 40.0;
    }

    public int getAverageNumberOfRiders() {
        String url = "https://developers.onemap.sg/privateapi/popapi/getModeOfTransportWork?";
        url = url + "token=" + accessToken;
        url = url + "&year=" + String.valueOf(Calendar.getInstance().get(Calendar.YEAR));
        List<String> areas = getAllPlanningArea();
        int totalRiders = 0;
        for (int n = 0; n < areas.size(); n++) {
            int temp = getNumberOfRiders(areas.get(n));
            if (temp != -1) {
                totalRiders = totalRiders + temp;
            }
        }
        return totalRiders / areas.size();
    }

    public int getNumberOfRiders(String area) {

        String url;
        JSONObject obj = null;
        int year = Calendar.getInstance().get(Calendar.YEAR);

        while (year > 1965) {
            try {
                url = generateCall_NumberOfRiders(area, year);
                obj = new JSONObject(doGetRequest(url));
                if (obj.getString("Result").equals("No Data Available!")) {
                    year--;
                    continue;
                }
                return obj.getInt("mrt_bus");
            } catch (Exception ex) {
                break;
            }
        }

        return -1;
    }

    private String generateCall_NumberOfRiders(String area, int year) {
        String url = "https://developers.onemap.sg/privateapi/popapi/getModeOfTransportWork?";
        url = url + "token=" + accessToken;
        url = url + "&year=" + String.valueOf(year);
        url = url + "&planningArea=" + area;
        return url;
    }

    private List<String> getAllPlanningArea() {

        String url;
        JSONArray jsAr;
        List<String> ret = new ArrayList();
        //int year = Calendar.getInstance().get(Calendar.YEAR);
        int year = 1000;

        while (true) {
            try {
                url = generateCall_GetAllPlanningArea(year);
                jsAr = new JSONArray(doGetRequest(url));
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
                break;
            }
        }

        return null;
    }

    private String generateCall_GetAllPlanningArea(int year) {
        String url = "https://developers.onemap.sg/privateapi/popapi/getPlanningareaNames?";
        url = url + "token=" + accessToken;
        url = url + "&year=" + String.valueOf(year);
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
