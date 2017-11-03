using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_Code.Entity
{
    public class Calculation
    {
        private List<Criteria> criteriaList;
        private double JSIScore;
        private DateTime createdTime;
        private Address workLocation;
        private Address homeLoction;
        private int salary;
        private char commuteType;
        private int jobInterest;
        private int salarySatisfaction;

        private int medianSalary;
        private int ridersArea;
        private int aveRidersArea;
        private double commuteTime;
        private double aveCommuteTime;
        private double monthlyCommuteCost;

        private Boolean initializationComplete = false;
        public Calculation(Address workLocation, Address homeLoction, int salary, char commuteType,
                int jobInterest, int salarySatisfaction, DateTime createdTime, int medianSalary,
                int ridersArea, int aveRidersArea, double commuteTime, double aveCommuteTime,
                double monthlyCommuteCost)
        {
            setCreatedTime(createdTime);
            setWorkLocation(workLocation);
            setHomeLocation(homeLoction);
            setSalary(salary);
            setCommuteType(commuteType);
            setJobInterest(jobInterest);
            setSalarySatisfaction(salarySatisfaction);
            setMedianSalary(medianSalary);
            setRidersArea(ridersArea);
            setAveRidersArea(aveRidersArea);
            setCommuteTime(commuteTime);
            setAveCommuteTime(aveCommuteTime);
            setMonthlyCommuteCost(monthlyCommuteCost);
            setCreatedTime(createdTime);
            criteriaList = new List<Criteria>();

            try
            {
                createCriteria_Salary(); //0
                createCriteria_CommuteComfort(); //1
                createCriteria_CommuteCost(); //2
                createCriteria_CommuteTime(); //3
                createCriteria_JobInterest(); //4
                createCriteria_SalarySatisfaction(); //5
                calculateJSIScore();
                initializationComplete = true;
            }
            catch (Exception e)
            {
                throw new Exception("Criteria creation failed");
            }
        }

        private void calculateJSIScore()
        {
            double total = 0;
            for (int n = 0; n < criteriaList.Count; n++)
            {
                total = total + criteriaList[n].getSubScore();
            }
            JSIScore = total;
        }

        public Address getWorkLocation()
        {
            return workLocation;
        }
        public Address getHomeLocation()
        {
            return homeLoction;
        }
        public int getSalary()
        {
            return salary;
        }
        public char getCommuteType()
        {
            return commuteType;
        }
        public int getJobInterest()
        {
            return jobInterest;
        }
        public DateTime getCreatedTime()
        {
            return createdTime;
        }
        public int getMedianSalary()
        {
            return medianSalary;
        }
        public int getRidersArea()
        {
            return ridersArea;
        }
        public int getAveRidersArea()
        {
            return aveRidersArea;
        }
        public double getCommuteTime()
        {
            return commuteTime;
        }
        public double getAveCommuteTime()
        {
            return aveCommuteTime;
        }
        public double getMonthlyCommuteCost()
        {
            return monthlyCommuteCost;
        }
        public int getSalarySatisfaction()
        {
            return salarySatisfaction;
        }
        public double getJSIScore()
        {
            return JSIScore;
        }

        private void setWorkLocation(Address workLocation)
        {
            this.workLocation = workLocation;
        }
        private void setHomeLocation(Address homeLoction)
        {
            this.homeLoction = homeLoction;
        }
        private void setSalary(int salary)
        {
            this.salary = salary;
        }
        private void setCommuteType(char commuteType)
        {
            this.commuteType = commuteType;
        }
        private void setJobInterest(int jobInterest)
        {
            this.jobInterest = jobInterest;
        }
        private void setSalarySatisfaction(int salarySatisfaction)
        {
            this.salarySatisfaction = salarySatisfaction;
        }
        private void setCreatedTime(DateTime createdTime)
        {
            this.createdTime = createdTime;
        }
        private void setMedianSalary(int medianSalary)
        {
            this.medianSalary = medianSalary;
        }
        private void setRidersArea(int ridersArea)
        {
            this.ridersArea = ridersArea;
        }
        private void setAveRidersArea(int aveRidersArea)
        {
            this.aveRidersArea = aveRidersArea;
        }
        private void setCommuteTime(double commuteTime)
        {
            this.commuteTime = commuteTime;
        }
        private void setAveCommuteTime(double aveCommuteTime)
        {
            this.aveCommuteTime = aveCommuteTime;
        }
        private void setMonthlyCommuteCost(double monthlyCommuteCost)
        {
            this.monthlyCommuteCost = monthlyCommuteCost;
        }

        private void createCriteria_Salary()
        {
            Criteria hold = new Salary(medianSalary, salary);
            criteriaList.Add(hold);
        }
        private void createCriteria_CommuteComfort()
        {
            Criteria hold = new CommuteComfort(aveRidersArea, ridersArea, commuteType);
            criteriaList.Add(hold);
        }
        private void createCriteria_CommuteTime()
        {
            Criteria hold = new CommuteTime(aveCommuteTime, commuteTime);
            criteriaList.Add(hold);
        }
        private void createCriteria_CommuteCost()
        {
            Criteria hold = new CommuteCost(monthlyCommuteCost, salary);
            criteriaList.Add(hold);
        }
        private void createCriteria_JobInterest()
        {
            Criteria hold = new JobInterest(jobInterest);
            criteriaList.Add(hold);
        }
        private void createCriteria_SalarySatisfaction()
        {
            Criteria hold = new SalarySatisfaction(salarySatisfaction);
            criteriaList.Add(hold);
        }

        public string getCriteriaExplanation_Salary()
        {
            if (checkInitialization())
            {
                for (int n = 0; n < criteriaList.Count; n++)
                {
                    if (criteriaList[n] is Salary)
                    {
                        return criteriaList[n].getExplanation();
                    }
                }
            }
            return "Error";
        }
        public string getCriteriaExplanation_CommuteComfort()
        {
            if (checkInitialization())
            {
                for (int n = 0; n < criteriaList.Count; n++)
                {
                    if (criteriaList[n] is CommuteComfort)
                    {
                        return criteriaList[n].getExplanation();
                    }
                }
            }
            return "Error";
        }
        public string getCriteriaExplanation_CommuteTime()
        {
            if (checkInitialization())
            {
                for (int n = 0; n < criteriaList.Count; n++)
                {
                    if (criteriaList[n] is CommuteTime)
                    {
                        return criteriaList[n].getExplanation();
                    }
                }
            }
            return "Error";
        }
        public string getCriteriaExplanation_CommuteCost()
        {
            if (checkInitialization())
            {
                for (int n = 0; n < criteriaList.Count; n++)
                {
                    if (criteriaList[n] is CommuteCost)
                    {
                        return criteriaList[n].getExplanation();
                    }
                }
            }
            return "Error";
        }
        public string getCriteriaExplanation_JobInterest()
        {
            if (checkInitialization())
            {
                for (int n = 0; n < criteriaList.Count; n++)
                {
                    if (criteriaList[n] is JobInterest)
                    {
                        return criteriaList[n].getExplanation();
                    }
                }
            }
            return "Error";
        }
        public string getCriteriaExplanation_SalarySatisfaction()
        {
            if (checkInitialization())
            {
                for (int n = 0; n < criteriaList.Count; n++)
                {
                    if (criteriaList[n] is SalarySatisfaction)
                    {
                        return criteriaList[n].getExplanation();
                    }
                }
            }

            return "Error";
        }

        public double[] getCriteriaMark_Salary()
        {
            double[] ret = { 0.0, 0.0 };
            for (int n = 0; n < criteriaList.Count; n++)
            {
                if (criteriaList[n] is Salary)
                {
                    ret[0] = criteriaList[n].getSubScore();
                    ret[1] = criteriaList[n].getWeightage();
                }
            }
            return ret;
        }
        public double[] getCriteriaMark_CommuteComfort()
        {
            double[] ret = { 0.0, 0.0 };
            for (int n = 0; n < criteriaList.Count; n++)
            {
                if (criteriaList[n] is CommuteComfort)
                {
                    ret[0] = criteriaList[n].getSubScore();
                    ret[1] = criteriaList[n].getWeightage();
                }

            }
            return ret;
        }
        public double[] getCriteriaMark_CommuteTime()
        {
            double[] ret = { 0.0, 0.0 };
            for (int n = 0; n < criteriaList.Count; n++)
            {
                if (criteriaList[n] is CommuteTime)
                {
                    ret[0] = criteriaList[n].getSubScore();
                    ret[1] = criteriaList[n].getWeightage();
                }
            }
            return ret;
        }
        public double[] getCriteriaMark_CommuteCost()
        {
            double[] ret = { 0.0, 0.0 };
            for (int n = 0; n < criteriaList.Count; n++)
            {
                if (criteriaList[n] is CommuteCost)
                {
                    ret[0] = criteriaList[n].getSubScore();
                    ret[1] = criteriaList[n].getWeightage();
                }
            }
            return ret;
        }
        public double[] getCriteriaMark_JobInterest()
        {
            double[] ret = { 0.0, 0.0 };
            for (int n = 0; n < criteriaList.Count; n++)
            {
                if (criteriaList[n] is JobInterest)
                {
                    ret[0] = criteriaList[n].getSubScore();
                    ret[1] = criteriaList[n].getWeightage();
                }
            }
            return ret;
        }
        public double[] getCriteriaMark_SalarySatisfaction()
        {
            double[] ret = { 0.0, 0.0 };
            for (int n = 0; n < criteriaList.Count; n++)
            {
                if (criteriaList[n] is SalarySatisfaction)
                {
                    ret[0] = criteriaList[n].getSubScore();
                    ret[1] = criteriaList[n].getWeightage();
                }
            }
            return ret;
        }

        private Boolean checkInitialization()
        {
            if (!initializationComplete)
            {
                throw new Exception("Please initialize all criteria");
            }
            return true;
        }
    }
}
