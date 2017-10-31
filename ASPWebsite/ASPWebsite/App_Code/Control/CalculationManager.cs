﻿using ASPWebsite.App_Code.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_Code.Control
{
    public class CalculationManager
    {
        ApiManager apiManager = new ApiManager();
        public Calculation createNewCalculation(String workLocation, String homeLocation,
                int salary, char commuteType, int jobInterest, int salarySatisfaction)
        {

            double[] coordinates;
            double[] timeCost;
            String area;
            long time = 0;
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
                coordinates = apiManager.getCoordinates(workLocation);
                area = apiManager.getArea(coordinates[0], coordinates[1]);
                workLoc = new Address(workLocation, coordinates[0], coordinates[1], area);
                coordinates = apiManager.getCoordinates(homeLocation);
                area = apiManager.getArea(coordinates[0], coordinates[1]);
                homeLoc = new Address(homeLocation, coordinates[0], coordinates[1], area);
                time = System.currentTimeMillis();
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
    }
}