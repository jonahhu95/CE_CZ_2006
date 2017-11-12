using ASPWebsite.App_Code.Entity;
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
    /// Reponsible for managing Calculation objects.
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
        public Calculation createNewCalculation(string workLocation, string homeLocation,
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
        /// Get calculations of the user
        /// </summary>
        /// <returns>All saved calculations of the user.</returns>
        /// <param name="userName">User Name.</param>
        public List<Calculation> getCalculations(string userName)
        {
            return dbManager.getCalculationsOfUser(userName);
        }

        /// <summary>
        /// Saves calculation of the user
        /// </summary>
        /// <returns><c>true</c>, if successfully saved, <c>false</c> otherwise.</returns>
        /// <param name="calculation">Calculation.</param>
        /// <param name="userName">User Name.</param>
        public Boolean saveCalculation(Calculation calculation, string userName)
        {
            return dbManager.saveCalculation(calculation, userName);
        }

        /// <summary>
        /// Checks if location name is valid
        /// </summary>
        /// <returns><c>true</c>, if location name is valid, <c>false</c> otherwise.</returns>
        /// <param name="locationName">Location Name.</param>
        public Boolean checkAddressValid(string locationName)
        {
            if (apiManager.getCoordinates(locationName) == null)
                return false;
            return true;
        }
    }
}