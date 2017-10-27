using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_Code.Control
{
    public class ApiFetcher
    {
        private String oneMapAccessToken = null;
        private long oneMapAccessToken_expiryTime = 0;
        private String googleApiKey = "AIzaSyDh0GkxyS2a9Sc1Uy-u0Z8Q-7_LBhYeHPk";

        public int getMedianSalary(String area)
        {
            String url;
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
                    String res = doGetRequest(url);
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
                if (obj["info"] == null)
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