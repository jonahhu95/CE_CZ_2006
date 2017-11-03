using ASPWebsite.App_Code.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_Code.Control
{
    public class CalculationManager
    {
        private ApiManager apiManager = new ApiManager();
        private DatabaseManager dbManager = new DatabaseManager();

        public Calculation createNewCalculation(String workLocation, String homeLocation,
                int salary, char commuteType, int jobInterest, int salarySatisfaction)
        {

            double[] coordinates;
            double[] timeCost;
            String area;
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
                coordinates = apiManager.getCoordinates(workLocation);
                area = apiManager.getArea(coordinates[0], coordinates[1]);
                workLoc = new Address(workLocation, coordinates[0], coordinates[1], area);
                coordinates = apiManager.getCoordinates(homeLocation);
                area = apiManager.getArea(coordinates[0], coordinates[1]);
                homeLoc = new Address(homeLocation, coordinates[0], coordinates[1], area);
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
        public List<Calculation> getCalculations(User user)
        {
            return dbManager.getCalculationsOfUser(user);
        }
        public Boolean saveCalculation(Calculation calculation, User user)
        {
            return dbManager.saveCalculation(calculation, user);
        }


    }
}