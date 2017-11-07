﻿using ASPWebsite.App_Code.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace ASPWebsite.App_Code.Control
{
    /// <summary>
    /// Calculation manager.
    /// </summary>
    public class CalculationManager
    {
        private ApiManager apiManager = new ApiManager();
        private DatabaseManager dbManager = new DatabaseManager();
        private AddressManager addManager = new AddressManager();

        /// <summary>
        /// Creates the new calculation.
        /// </summary>
        /// <returns>The new calculation.</returns>
        /// <param name="workLocation">Work location.</param>
        /// <param name="homeLocation">Home location.</param>
        /// <param name="salary">Salary.</param>
        /// <param name="commuteType">Commute type.</param>
        /// <param name="jobInterest">Job interest.</param>
        /// <param name="salarySatisfaction">Salary satisfaction.</param>
        public Calculation createNewCalculation(String workLocation, String homeLocation,
                int salary, char commuteType, int jobInterest, int salarySatisfaction)
        {

            double[] timeCost;
            DateTime time; ;
            int medianSalary = 0;
            int ridersArea = 0;
            int aveRidersArea = 0;
            double commuteTime = 0;
            double aveCommuteTime = 0;
            double monthlyCommuteCost = 0;
            Address workLoc = null;
            Address homeLoc = null;
            Calculation cal;

            try
            {
                workLoc = addManager.createNewAddress(workLocation);
                homeLoc = addManager.createNewAddress(homeLocation);
                time = DateTime.Now;
                medianSalary = apiManager.getMedianSalary(homeLoc.getArea());
                ridersArea = apiManager.getNumberOfRiders(homeLoc.getArea());
                aveRidersArea = apiManager.getAverageNumberOfRiders();
                timeCost = apiManager.getCommuteTimeCost(homeLoc, workLoc);
                commuteTime = timeCost[0];
                aveCommuteTime = apiManager.getAverageCommuteTime();
                monthlyCommuteCost = timeCost[1];
                cal = new Calculation(workLoc, homeLoc,
                       salary, 'p', jobInterest, salarySatisfaction, time, medianSalary,
                       ridersArea, aveRidersArea, commuteTime, aveCommuteTime, monthlyCommuteCost);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
            return cal;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The calculations.</returns>
        /// <param name="userName">User Name.</param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public List<Calculation> getCalculations(string userName)
        {
            return dbManager.getCalculationsOfUser(userName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="calculation"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public Boolean saveCalculation(Calculation calculation, string userName)
        {
            return dbManager.saveCalculation(calculation, userName);
        }

        public Boolean getAddressValid(string address)
        {
            try
            {
                String url = apiManager.generateCall_GetCoordinates(address);
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);;
                JObject obj = JObject.Parse(response.Content);
                JArray ar = (JArray)obj["results"];
                String formattedAddress = ar.First["formatted_address"].ToString();
                Boolean contain = formattedAddress.Contains("Singapore");
                if (contain)//return true for address in singapore
                    return true;
            }
            catch (Exception ex)
            {

            }
            return false;
            
        }
    }
}