using ASPWebsite.App_Code.Entity;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_Code.Control
{
    public class ApiManager
    {
        private string oneMapAccessToken = null;
        private long oneMapAccessToken_expiryTime = 0;
        private string googleApiKey = "AIzaSyDh0GkxyS2a9Sc1Uy-u0Z8Q-7_LBhYeHPk";
        private List<string> allPlanningArea = null;
        private int allPlanningArea_expiryYear = 0;
        private List<KeyValuePair<string,int>> planningAreaRiders = null;
        private int planningAreaRiders_expiryYear = 0;

        public int getMedianSalary(string area)
        {
            string url;
            int totalAreaPopulation = 0, median = 0, salaryRange = 0; ;
            int year = DateTime.Now.Year;
            List<string> key = new List<string> { "below_sgd_1000",
                    "sgd_1000_to_1499", "sgd_1500_to_1999", "sgd_2000_to_2499",
                    "sgd_2500_to_2999", "sgd_3000_to_3999", "sgd_4000_to_4999",
                    "sgd_5000_to_5999", "sgd_6000_to_6999", "sgd_7000_to_7999",
                    "sgd_8000_over" };
            if (!checkOneMapAccessToken())
                return -1;

            while (year > 1965)
            {
                try
                {
                    url = generateCall_GetMedianSalary(area, 2010);
                    string res = doGetRequest(url);
                    JArray obj = JArray.Parse(res);
                    for (int n = 0; n < key.Count; n++)
                    {
                        if (obj[0][key[n]] != null)
                        {
                            totalAreaPopulation = totalAreaPopulation + (int)obj[0][key[n]];
                        }
                    }
                    median = totalAreaPopulation / 2;
                    for (salaryRange = 0; salaryRange < key.Count; salaryRange++)
                    {
                        if (obj[0][key[salaryRange]] != null)
                        {
                            median = median - (int)obj[0][key[salaryRange]];
                        }
                        if (median < 0)
                        {
                            return 750 + (salaryRange * 500);
                        }
                    }
                }
                catch (Exception ex)
                {
                    year--;
                    continue;
                }
            }
            return -1;
        }
        public string getArea(double longitude, double latitude)
        {
            string url;
            JObject obj = null;
            int year = DateTime.Now.Year;
            if (!checkOneMapAccessToken())
                return null;

            while (year > 1965)
            {
                try
                {
                    url = generateCall_GetArea(longitude, latitude, year);
                    string res = doGetRequest(url);
                    obj = (JObject)(JArray.Parse(res)).First;
                    return (string)obj["pln_area_n"];
                }
                catch (Exception ex)
                {
                    year--;
                    continue;
                }
            }
            return null;
        }
        public double getAverageCommuteTime()
        {
            return 40.0;
        }
        public double[] getCommuteTimeCost(Address homeLocation, Address workLocation)
        {
            string url;
            JObject obj;
            double[] ret = new double[2];
            ret[0] = 0;
            ret[1] = 0;
            try
            {
                url = generateCall_GetCommuteTimeCost(homeLocation.getLongitude(), homeLocation.getLatitude(),
                        workLocation.getLongitude(), workLocation.getLatitude());
                string res = doGetRequest(url);
                obj = new JObject(res);
                ret[0] = (double)obj["tc"]; // time cost
                ret[1] = (double)obj["tr"] * 22.0; // cost
            }
            catch (Exception ex)
            {
            }
            return ret;
        }
        public int getAverageNumberOfRiders()
        {
            List<KeyValuePair<string, int>> ret = getAllAreaRiders();
            int total = 0;
            for(int n = 0; n < ret.Count; n++)
            {
                total = total + ret[n].Value;
            }
            return total / ret.Count;
            
        }
        public int getNumberOfRiders(string area)
        {
            string url;
            JObject obj = null;
            int total = -1;
            int year = DateTime.Now.Year;
            List<string> key = new List<string> { "mrt_bus", "mrt", "bus", "mrt_car", "mrt_other" };

            if (!checkOneMapAccessToken())
                return -1;
            while (year > 1965)
            {
                try
                {
                    url = generateCall_NumberOfRiders(area, year);
                    string res = doGetRequest(url);
                    obj = (JObject)(JArray.Parse(res)).First;
                    total = 0;
                    for (int m = 0; m < key.Count; m++)
                    {
                        if (obj[key[m]] != null)
                        {
                            total = total + (int)obj[key[m]];
                        }
                    }
                    break;
                }
                catch (Exception ex)
                {
                    year--;
                    continue;
                }
            }
            return total;
        }
        public double[] getCoordinates(string locationName)
        {
            string url;
            JObject obj;
            double[] geo = new double[2];
            try
            {
                url = generateCall_GetCoordinates(locationName);
                string res = doGetRequest(url);
                obj = JObject.Parse(res);
                JArray ar = (JArray)obj["results"];
                JObject hold = (JObject)ar.First["geometry"]["location"];
                geo[0] = (Double)hold["lng"];
                geo[1] = (Double)hold["lat"];
            }
            catch (Exception ex)
            {
                geo = null;
            }
            return geo;
        }


        private List<string> getAllPlanningArea()
        {
            string url;
            JArray jsAr;
            List<string> ret = new List<string>();
            int year = DateTime.Now.Year;
            if (allPlanningArea == null || allPlanningArea_expiryYear < DateTime.Now.Year)
            {
                allPlanningArea = new List<string>();
                if (!checkOneMapAccessToken())
                    return null;
                while (year > 1965)
                {
                    try
                    {
                        url = generateCall_GetAllPlanningArea(year);
                        string response = doGetRequest(url);
                        jsAr = JArray.Parse(response);
                        if (jsAr.Count < 2)
                        {
                            year--;
                            continue;
                        }
                        for (int n = 0; n < jsAr.Count; n++)
                        {
                            ret.Add((string)(jsAr[n])["pln_area_n"]);
                        }
                        allPlanningArea = ret;
                        allPlanningArea_expiryYear = DateTime.Now.Year;
                        break;
                    }
                    catch (Exception ex)
                    {
                        break;
                    }
                }
            }
            return allPlanningArea;
        }
        private List<KeyValuePair<string, int>> getAllAreaRiders()
        {
            string url;
            List<string> areas = getAllPlanningArea();
            int year = DateTime.Now.Year;
            int totalRiders = 0;
            if(planningAreaRiders == null || allPlanningArea_expiryYear < DateTime.Now.Year)
            {
                planningAreaRiders = new List<KeyValuePair<string, int>>();
                for (int n = 0; n < areas.Count; n++)
                {
                    int temp = getNumberOfRiders(areas[n]);
                    if (temp > 0)
                    {
                        planningAreaRiders.Add(new KeyValuePair<string, int>(areas[n], temp));
                    }
                    else
                    {
                        //ERROR HANDLING
                    }
                }
                planningAreaRiders_expiryYear = DateTime.Now.Year;
            }
            
            return planningAreaRiders;
        }

        private string doGetRequest(string url)
        {
            IRestResponse response;
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                response = client.Execute(request);
            }
            catch (Exception e)
            {
                return null;
            }
            if (checkJsonResponse(response))
                return response.Content;
            return null;
        }

        private string generateCall_NumberOfRiders(string area, int year)
        {
            string url = "https://developers.onemap.sg/privateapi/popapi/getModeOfTransportWork?";
            url = url + "token=" + oneMapAccessToken;
            url = url + "&year=" + year.ToString();
            url = url + "&planningArea=" + area;
            return url;
        }
        private string generateCall_GetAllPlanningArea(int year)
        {
            string url = "https://developers.onemap.sg/privateapi/popapi/getPlanningareaNames?";
            url = url + "token=" + oneMapAccessToken;
            url = url + "&year=" + year.ToString();
            return url;
        }
        private string generateCall_GetMedianSalary(string area, int year)
        {
            string url = "https://developers.onemap.sg/privateapi/popapi/getIncomeFromWork?";
            url = url + "token=" + oneMapAccessToken;
            url = url + "&planningArea=" + area;
            url = url + "&year=" + year.ToString();
            return url;
        }
        private string generateCall_GetArea(double longitude, double latitude, int year)
        {
            string url = "https://developers.onemap.sg/privateapi/popapi/getPlanningarea?";
            url = url + "token=" + oneMapAccessToken;
            url = url + "&lat=" + latitude.ToString();
            url = url + "&lng=" + longitude.ToString();
            url = url + "&year=" + year.ToString();
            return url;
        }
        private string generateCall_GetCoordinates(string locationName)
        {
            string url = "https://maps.googleapis.com/maps/api/place/textsearch/json?";
            url = url + "query=" + locationName.Replace(" ", "+");
            url = url + "&key=" + googleApiKey;
            return url;
        }
        private string generateCall_GetCommuteTimeCost(double start_lng, double start_lat, double end_lng, double end_lat)
        {

            string url = "http://www.streetdirectory.com/api/?mode=journey&output=json&country=sg&";
            url = url + "q=" + start_lng + "," + start_lat + "%20to%20" + end_lng + "," + end_lat;
            url = url + "&methods=bustrain&vehicle=both&info=1&time=08:00%00AM";
            return url;
        }

        private Boolean checkJsonResponse(IRestResponse res)
        {
            if (!(res.ResponseStatus == ResponseStatus.Completed))
                return false;
            if (res.StatusCode != System.Net.HttpStatusCode.OK)
                return false;
            if (res.Content.Equals(""))
                return false;
            if (res.ErrorException != null)
                return false;
            if (checkJsonResponse_google(res) || checkJsonResponse_oneMap(res)
                || checkJsonResponse_streetDirectory(res))
                return true;
            return false;
        }
        private Boolean checkJsonResponse_google(IRestResponse res)
        {
            JObject obj = null;
            try
            {
                obj = JObject.Parse(res.Content);
                if (!(((string)obj["status"]).Equals("OK")))
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        private Boolean checkJsonResponse_oneMap(IRestResponse res)
        {
            JObject obj = null;
            JArray arr = null;
            try
            {
                obj = JObject.Parse(res.Content);
                if (obj["error"] != null)
                    return false;
            }
            catch (Exception e)
            {
                try
                {
                    arr = JArray.Parse(res.Content);
                    if (arr[0]["error"] != null)
                        return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }
        private Boolean checkJsonResponse_streetDirectory(IRestResponse res)
        {
            JObject obj = null;
            try
            {
                obj = JObject.Parse(res.Content);
                if (obj["info"] == null || obj["routes"] == null)
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        private Boolean getOneMapAccessToken()
        {
            try
            {
                var client = new RestClient("https://developers.onemap.sg/privateapi/auth/post/getToken");
                var request = new RestRequest(Method.POST);
                request.AddHeader("content-type", "multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW");
                request.AddParameter("multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW", "------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"email\"\r\n\r\njonahhu95@gmail.com\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"password\"\r\n\r\n3DEGREE\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW--", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (checkJsonResponse(response))
                {
                    JObject obj = JObject.Parse(response.Content);
                    oneMapAccessToken = (string)obj["access_token"];
                    oneMapAccessToken_expiryTime = (long)obj["expiry_timestamp"];
                }
            }
            catch (Exception e)
            {
                oneMapAccessToken = null;
                oneMapAccessToken_expiryTime = 0;
                return false;
            }
            return true;
        }
        private Boolean checkOneMapAccessToken()
        {
            if ((long)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds > oneMapAccessToken_expiryTime)
            {
                return getOneMapAccessToken();
            }
            return true;
        }

    }
}