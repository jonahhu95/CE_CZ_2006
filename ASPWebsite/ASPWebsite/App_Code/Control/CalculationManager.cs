using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPWebsite.App_Code.Entity;
using ASPWebsite.App_Code.Control;

namespace ASPWebsite.App_Code.Control
{
    public class CalculationManager
    {

        //private List<Calculation> CalculationList = new ArrayList();
        private DatabaseManager dbManager = new DatabaseManager();
        private ApiManager apiManager = new ApiManager();
        private ArrayList CalculationList = new ArrayList();


        public Calculation GetUserCalculation(User user, int choice)
        {
            dbManager.getCalculation(user.getUsername(), choice);
            return null;
        }

        public Calculation createNewCalculation(String workLocation, String homeLocation,
                int salary, char commuteType, int jobInterest, int salarySatisfaction)
        {

            double[] coordinates;
            double[] timeCost;
            string area;
            DateTime time;
            int medianSalary = 0;
            int ridersArea = 0;
            int aveRidersArea = 0;
            double commuteTime = 0;
            double aveCommuteTime = 0;
            double monthlyCommuteCost = 0;
            Address workLoc = null;
            Address homeLoc = null;

            try
            {
                //apiManager.
                coordinates = apiManager.getCoordinates(workLocation);
                area = apiManager.getArea(coordinates[0], coordinates[1]);
                workLoc = new Address(workLocation, coordinates[0], coordinates[1], area);
                coordinates = apiManager.getCoordinates(homeLocation);
                area = apiManager.getArea(coordinates[0], coordinates[1]);
                homeLoc = new Address(homeLocation, coordinates[0], coordinates[1], area);
                //time = System.currentTimeMillis();
                time = DateTime.Now;
                medianSalary = apiManager.getMedianSalary(homeLoc.getArea());
                ridersArea = apiManager.getNumberOfRiders(homeLoc.getArea());
                aveRidersArea = apiManager.getAverageNumberOfRiders();
                timeCost = apiManager.getCommuteTimeCost(homeLoc, workLoc);
                commuteTime = timeCost[0];
                aveCommuteTime = apiManager.getAverageCommuteTime();
                monthlyCommuteCost = timeCost[1];
            }
            catch (Exception e)
            {
                return null;
            }

            Calculation cal;
            try
            {
                cal = new Calculation(workLoc, homeLoc,
                                      salary, 'p', jobInterest, salarySatisfaction, time, medianSalary,
                        ridersArea, aveRidersArea, commuteTime, aveCommuteTime, monthlyCommuteCost);
            }
            catch (Exception e)
            {
                return null;
            }
            return cal;
        }

        public void compareCalculations(Calculation calculation1, Calculation calculation2)
        {
            //receive the most recent calculation
            //retrieve data from the score_t table in database

        }

        public Boolean saveCalculation(Calculation calculation, User user)
        {
            //valid.saveCalculation(); //new method on databaseManager
            return false;
        }
    }

}