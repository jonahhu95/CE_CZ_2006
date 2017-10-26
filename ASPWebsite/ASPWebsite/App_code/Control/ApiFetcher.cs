using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;


namespace ASPWebsite.App_code
{
    public class ApiFetcher
    {

        public int getMedianSalary(String area)
        {
            String url;
            JsonObject obj = null;
            int totalAreaPopulation = 0, median = 0, salaryRange = 0; ;
            int year = DateTime.Now.Year;
            List<string> key = new List<string> { "below_sgd_1000",
                    "sgd_1000_to_1499", "sgd_1500_to_1999", "sgd_2000_to_2499",
                    "sgd_2500_to_2999", "sgd_3000_to_3999", "sgd_4000_to_4999",
                    "sgd_5000_to_5999", "sgd_6000_to_6999", "sgd_7000_to_7999",
                    "sgd_8000_over" };

            while (year > 1965)
            {
                try
                {
                    url = generateCall_GetMedianSalary(area, year);
                    String res = doGetRequest(url);
                    if (checkJSONResponse_oneMap(res))
                    {
                        obj = new JSONArray(res).getJSONObject(0);
                        for (int n = 0; n < key.size(); n++)
                        {
                            if (!obj.isNull(key.get(n)))
                            {
                                totalAreaPopulation = totalAreaPopulation + obj.getInt(key.get(n));
                            }
                        }
                        median = totalAreaPopulation / 2;
                        for (salaryRange = 0; salaryRange < key.size(); salaryRange++)
                        {
                            if (!obj.isNull(key.get(salaryRange)))
                            {
                                median = median - obj.getInt(key.get(salaryRange));
                            }
                            if (median < 0)
                            {
                                return 750 + (salaryRange * 500);
                            }
                        }
                    }
                    else
                    {
                        year--;
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    break;
                }
            }
            return -1;
        }

        private string doGetRequest(string url)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
            }
            catch(Exception e)
            {

            }
            
        return null;
    }

    }
}