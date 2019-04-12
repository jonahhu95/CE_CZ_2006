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
    /// <summary>
    /// API manager.
    /// Responsible to fetch data from remote APIs.
    /// </summary>
    public class ApiManager
    {
        private string oneMapAccessToken = null;
        private long oneMapAccessToken_expiryTime = 0;
        private string googleApiKey = "NONE";
        private string backup_googleApiKey_1 = "NONE";
        private string backup_googleApiKey_2 = "NONE";

        private DatabaseManager dbManager = new DatabaseManager();

        /// <summary>
        /// Gets the median salary.
        /// </summary>
        /// <returns>The median salary.</returns>
        /// <param name="area">Area.</param>
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

            while (year > 1989)
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
            return 4000;
        }
        /// <summary>
        /// Gets the area.
        /// </summary>
        /// <returns>The area.</returns>
        /// <param name="longitude">Longitude.</param>
        /// <param name="latitude">Latitude.</param>
        public string getArea(double longitude, double latitude)
        {
            string url;
            JObject obj = null;
            int year = DateTime.Now.Year;
            if (!checkOneMapAccessToken())
                return null;

            while (year > 1989)
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
        /// <summary>
        /// Gets the average commute time.
        /// </summary>
        /// <returns>The average commute time.</returns>
        public double getAverageCommuteTime()
        {
            return 40.0;
        }
        /// <summary>
        /// Gets the commute time cost.
        /// </summary>
        /// <returns>The commute time cost.</returns>
        /// <param name="homeLocation">Home location.</param>
        /// <param name="workLocation">Work location.</param>
        public double[] getCommuteTimeCost(Address homeLocation, Address workLocation)
        {
            string url;
            JObject obj;
            double[] ret = new double[2];
            ret[0] = 45;
            ret[1] = 40;
            try
            {
                url = generateCall_GetCommuteTimeCost(homeLocation.getLongitude(), homeLocation.getLatitude(),
                        workLocation.getLongitude(), workLocation.getLatitude());
                string res = doGetRequest(url);
                obj = JObject.Parse(res);
                obj = (JObject) obj["total_data"];
                ret[0] = (double)obj["tc"]; // time cost
                ret[1] = (double)obj["tr"] * 40.0; // cost
            }
            catch (Exception ex)
            {
            }
            return ret;
        }
        /// <summary>
        /// Gets the average number of riders.
        /// </summary>
        /// <returns>The average number of riders.</returns>
        public int getAverageNumberOfRiders()
        {
            List<KeyValuePair<string, int>> ret = getAllAreaRiders();
            int total = 0, countedAreas = 0;
            for (int n = 0; n < ret.Count; n++)
            {
                if(ret[n].Value != 0)
                {
                    total = total + ret[n].Value;
                    countedAreas++;
                }
                
            }
            return total / countedAreas;

        }
        /// <summary>
        /// Gets the number of riders.
        /// </summary>
        /// <returns>The number of riders.</returns>
        /// <param name="area">Area.</param>
        public int getNumberOfRiders(string area)
        {
            string url;
            JObject obj = null;
            int total = -1;
            int year = DateTime.Now.Year;
            List<string> key = new List<string> { "mrt_bus", "mrt", "bus", "mrt_car", "mrt_other" };

            List<KeyValuePair<string, int>> areas = dbManager.getArea();
            if (areas != null)
            {
                for(int n = 0; n < areas.Count; n++)
                {
                    if (areas[n].Key == area)
                        return areas[n].Value;
                }
            }
            if (!checkOneMapAccessToken())
                return -1;
            while (year > 1989)
            {
                try
                {
                    url = generateCall_GetNumberOfRiders(area, year);
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
        /// <summary>
        /// Gets the coordinates.
        /// </summary>
        /// <returns>The coordinates.</returns>
        /// <param name="locationName">Location name.</param>
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
                String formattedAddress = ar.First["formatted_address"].ToString();
                Boolean contain = formattedAddress.Contains("Singapore");
                if (!contain)
                    return null;
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
        /// <summary>
        /// Gets all planning area.
        /// </summary>
        /// <returns>The all planning area.</returns>
        private List<string> getAllPlanningArea()
        {
            string url;
            JArray jsAr;
            List<string> ret = new List<string>();
            int year = DateTime.Now.Year;
            if (!checkOneMapAccessToken())
                return null;
            while (year > 1989)
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
                    break;
                }
                catch (Exception ex)
                {
                    break;
                }
            }
            return ret;
        }
        /// <summary>
        /// Gets all area riders.
        /// </summary>
        /// <returns>The all area riders.</returns>
        private List<KeyValuePair<string, int>> getAllAreaRiders()
        {
            List<KeyValuePair<string, int>> areas = dbManager.getArea();
            if (areas != null)
            {
                return areas;
            }else
            {
                List<string> areaNames = getAllPlanningArea();
                for (int n = 0; n < areaNames.Count; n++)
                {
                    int temp = getNumberOfRiders(areaNames[n]);
                    if (temp >= 0)
                    {
                        dbManager.saveArea(areaNames[n], temp, DateTime.Now.AddYears(1));
                    }
                }
                areas = dbManager.getArea();
            }
            return areas;
        }

        /// <summary>
        /// Get request from URL
        /// </summary>
        /// <returns>The request result.</returns>
        /// <param name="url">URL.</param>
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
        /// <summary>
        /// Generates the call number of riders.
        /// </summary>
        /// <returns>The call number of riders.</returns>
        /// <param name="area">Area.</param>
        /// <param name="year">Year.</param>
        private string generateCall_GetNumberOfRiders(string area, int year)
        {
            string url = "https://developers.onemap.sg/privateapi/popapi/getModeOfTransportWork?";
            url = url + "token=" + oneMapAccessToken;
            url = url + "&year=" + year.ToString();
            url = url + "&planningArea=" + area;
            return url;
        }
        /// <summary>
        /// Generates the call get all planning area.
        /// </summary>
        /// <returns>The call get all planning area.</returns>
        /// <param name="year">Year.</param>
        private string generateCall_GetAllPlanningArea(int year)
        {
            string url = "https://developers.onemap.sg/privateapi/popapi/getPlanningareaNames?";
            url = url + "token=" + oneMapAccessToken;
            url = url + "&year=" + year.ToString();
            return url;
        }
        /// <summary>
        /// Generates the call get median salary.
        /// </summary>
        /// <returns>The call get median salary.</returns>
        /// <param name="area">Area.</param>
        /// <param name="year">Year.</param>
        private string generateCall_GetMedianSalary(string area, int year)
        {
            string url = "https://developers.onemap.sg/privateapi/popapi/getIncomeFromWork?";
            url = url + "token=" + oneMapAccessToken;
            url = url + "&planningArea=" + area;
            url = url + "&year=" + year.ToString();
            return url;
        }
        /// <summary>
        /// Generates the call get area.
        /// </summary>
        /// <returns>The call get area.</returns>
        /// <param name="longitude">Longitude.</param>
        /// <param name="latitude">Latitude.</param>
        /// <param name="year">Year.</param>
        private string generateCall_GetArea(double longitude, double latitude, int year)
        {
            string url = "https://developers.onemap.sg/privateapi/popapi/getPlanningarea?";
            url = url + "token=" + oneMapAccessToken;
            url = url + "&lat=" + latitude.ToString();
            url = url + "&lng=" + longitude.ToString();
            url = url + "&year=" + year.ToString();
            return url;
        }
        /// <summary>
        /// Generates the call get coordinates.
        /// </summary>
        /// <returns>The call get coordinates.</returns>
        /// <param name="locationName">Location name.</param>
        private string generateCall_GetCoordinates(string locationName)
        {
            string url = "https://maps.googleapis.com/maps/api/place/textsearch/json?";
			string locationNameHold = locationName.Replace("&", "%26");
			locationNameHold = locationNameHold.Replace("-", "%2D");
			url = url + "query=" + locationNameHold.Replace(" ", "+");
            int ran = new Random().Next(0, 3);
            switch (ran)
            {
                case 0:
                    url = url + "&key=" + googleApiKey;
                    break;
                case 1:
                    url = url + "&key=" + backup_googleApiKey_1;
                    break;
                case 2:
                    url = url + "&key=" + backup_googleApiKey_2;
                    break;
                default:
                    url = url + "&key=" + backup_googleApiKey_1;
                    break;
            }
            return url;
        }
        /// <summary>
        /// Generates the call get commute time cost.
        /// </summary>
        /// <returns>The call get commute time cost.</returns>
        /// <param name="start_lng">Start lng.</param>
        /// <param name="start_lat">Start lat.</param>
        /// <param name="end_lng">End lng.</param>
        /// <param name="end_lat">End lat.</param>
        private string generateCall_GetCommuteTimeCost(double start_lng, double start_lat, double end_lng, double end_lat)
        {

            string url = "http://www.streetdirectory.com/api/?mode=journey&output=json&country=sg&";
            url = url + "q=" + start_lng + "," + start_lat + "%20to%20" + end_lng + "," + end_lat;
            //url = url + "&methods=bustrain&vehicle=both&info=1&time=12:00%20PM&date=" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year;
            url = url + "&methods=bustrain&vehicle=both&info=1&time=12:00%20PM";
            return url;
        }
        /// <summary>
        /// Checks the json response.
        /// </summary>
        /// <returns><c>true</c>, if json response was checked, <c>false</c> otherwise.</returns>
        /// <param name="res">Res.</param>
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
                /*JArray ar = (JArray)obj["results"];
                String formattedAddress = ar.First["formatted_address"].ToString();
                if (!formattedAddress.Contains("Singapore"))
                    return false;
                */
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Checks the json response one map.
        /// </summary>
        /// <returns><c>true</c>, if json response one map was checked, <c>false</c> otherwise.</returns>
        /// <param name="res">Res.</param>
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
        /// <summary>
        /// Checks the json response street directory.
        /// </summary>
        /// <returns><c>true</c>, if json response street directory was checked, <c>false</c> otherwise.</returns>
        /// <param name="res">Res.</param>
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
        /// <summary>
        /// Gets the one map access token.
        /// </summary>
        /// <returns><c>true</c>, if one map access token was gotten, <c>false</c> otherwise.</returns>
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
        /// <summary>
        /// Checks the one map access token.
        /// </summary>
        /// <returns><c>true</c>, if one map access token was checked, <c>false</c> otherwise.</returns>
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
