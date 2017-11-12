using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_Code.Entity
{
    /// <summary>
    /// Calculation.
    /// </summary>
    public class Calculation
    {
        public List<Criteria> criteriaList;
        public double JSIScore { get; set; }
        public DateTime createdTime;
        public Address workLocation { get; set; }
        public Address homeLoction { get; set; }
        public int salary { get; set; }
        public char commuteType;
        public int jobInterest { get; set; }
        public int salarySatisfaction { get; set; }

        public int medianSalary;
        public int ridersArea;
        public int aveRidersArea;
        public double commuteTime;
        public double aveCommuteTime;
        public double monthlyCommuteCost;

        public Boolean initializationComplete = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ASPWebsite.App_Code.Entity.Calculation"/> class.
        /// </summary>
        /// <param name="workLocation">Work location.</param>
        /// <param name="homeLocation">Home loction.</param>
        /// <param name="salary">Salary.</param>
        /// <param name="commuteType">Commute type.</param>
        /// <param name="jobInterest">Job interest.</param>
        /// <param name="salarySatisfaction">Salary satisfaction.</param>
        /// <param name="createdTime">Created time.</param>
        /// <param name="medianSalary">Median salary.</param>
        /// <param name="ridersArea">Riders area.</param>
        /// <param name="aveRidersArea">Ave riders area.</param>
        /// <param name="commuteTime">Commute time.</param>
        /// <param name="aveCommuteTime">Ave commute time.</param>
        /// <param name="monthlyCommuteCost">Monthly commute cost.</param>
        public Calculation(Address workLocation, Address homeLocation, int salary, char commuteType,
                int jobInterest, int salarySatisfaction, DateTime createdTime, int medianSalary,
                int ridersArea, int aveRidersArea, double commuteTime, double aveCommuteTime,
                double monthlyCommuteCost)
        {
            setCreatedTime(createdTime);
            setWorkLocation(workLocation);
            setHomeLocation(homeLocation);
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
        /// <summary>
        /// Gets the work location.
        /// </summary>
        /// <returns>The work location.</returns>
        public Address getWorkLocation()
        {
            return workLocation;
        }
        /// <summary>
        /// Gets the home location.
        /// </summary>
        /// <returns>The home location.</returns>
        public Address getHomeLocation()
        {
            return homeLoction;
        }
        /// <summary>
        /// Gets the salary.
        /// </summary>
        /// <returns>The salary.</returns>
        public int getSalary()
        {
            return salary;
        }
        public char getCommuteType()
        {
            return commuteType;
        }
        /// <summary>
        /// Gets the job interest.
        /// </summary>
        /// <returns>The job interest.</returns>
        public int getJobInterest()
        {
            return jobInterest;
        }
        /// <summary>
        /// Gets the created time.
        /// </summary>
        /// <returns>The created time.</returns>
        public DateTime getCreatedTime()
        {
            return createdTime;
        }
        /// <summary>
        /// Gets the median salary.
        /// </summary>
        /// <returns>The median salary.</returns>
        public int getMedianSalary()
        {
            return medianSalary;
        }
        /// <summary>
        /// Gets the riders area.
        /// </summary>
        /// <returns>The riders area.</returns>
        public int getRidersArea()
        {
            return ridersArea;
        }
        /// <summary>
        /// Gets the ave riders area.
        /// </summary>
        /// <returns>The ave riders area.</returns>
        public int getAveRidersArea()
        {
            return aveRidersArea;
        }
        /// <summary>
        /// Gets the commute time.
        /// </summary>
        /// <returns>The commute time.</returns>
        public double getCommuteTime()
        {
            return commuteTime;
        }
        /// <summary>
        /// Gets the ave commute time.
        /// </summary>
        /// <returns>The ave commute time.</returns>
        public double getAveCommuteTime()
        {
            return aveCommuteTime;
        }
        /// <summary>
        /// Gets the monthly commute cost.
        /// </summary>
        /// <returns>The monthly commute cost.</returns>
        public double getMonthlyCommuteCost()
        {
            return monthlyCommuteCost;
        }
        /// <summary>
        /// Gets the salary satisfaction.
        /// </summary>
        /// <returns>The salary satisfaction.</returns>
        public int getSalarySatisfaction()
        {
            return salarySatisfaction;
        }
        /// <summary>
        /// Gets the JSIS core.
        /// </summary>
        /// <returns>The JSIS core.</returns>
        public double getJSIScore()
        {
            return formatDoubleDecimalPoint(JSIScore);
        }
        /// <summary>
        /// Sets the work location.
        /// </summary>
        /// <param name="workLocation">Work location.</param>
        private void setWorkLocation(Address workLocation)
        {
            this.workLocation = workLocation;
        }
        /// <summary>
        /// Sets the home location.
        /// </summary>
        /// <param name="homeLoction">Home loction.</param>
        private void setHomeLocation(Address homeLoction)
        {
            this.homeLoction = homeLoction;
        }
        /// <summary>
        /// Sets the salary.
        /// </summary>
        /// <param name="salary">Salary.</param>
        private void setSalary(int salary)
        {
            this.salary = salary;
        }
        /// <summary>
        /// Sets the type of the commute.
        /// </summary>
        /// <param name="commuteType">Commute type.</param>
        private void setCommuteType(char commuteType)
        {
            this.commuteType = commuteType;
        }
        /// <summary>
        /// Sets the job interest.
        /// </summary>
        /// <param name="jobInterest">Job interest.</param>
        private void setJobInterest(int jobInterest)
        {
            this.jobInterest = jobInterest;
        }
        /// <summary>
        /// Sets the salary satisfaction.
        /// </summary>
        /// <param name="salarySatisfaction">Salary satisfaction.</param>
        private void setSalarySatisfaction(int salarySatisfaction)
        {
            this.salarySatisfaction = salarySatisfaction;
        }
        /// <summary>
        /// Sets the created time.
        /// </summary>
        /// <param name="createdTime">Created time.</param>
        private void setCreatedTime(DateTime createdTime)
        {
            this.createdTime = createdTime;
        }
        /// <summary>
        /// Sets the median salary.
        /// </summary>
        /// <param name="medianSalary">Median salary.</param>
        private void setMedianSalary(int medianSalary)
        {
            this.medianSalary = medianSalary;
        }
        /// <summary>
        /// Sets the riders area.
        /// </summary>
        /// <param name="ridersArea">Riders area.</param>
        private void setRidersArea(int ridersArea)
        {
            this.ridersArea = ridersArea;
        }
        /// <summary>
        /// Sets the ave riders area.
        /// </summary>
        /// <param name="aveRidersArea">Ave riders area.</param>
        private void setAveRidersArea(int aveRidersArea)
        {
            this.aveRidersArea = aveRidersArea;
        }
        /// <summary>
        /// Sets the commute time.
        /// </summary>
        /// <param name="commuteTime">Commute time.</param>
        private void setCommuteTime(double commuteTime)
        {
            this.commuteTime = commuteTime;
        }
        /// <summary>
        /// Sets the ave commute time.
        /// </summary>
        /// <param name="aveCommuteTime">Ave commute time.</param>
        private void setAveCommuteTime(double aveCommuteTime)
        {
            this.aveCommuteTime = aveCommuteTime;
        }
        /// <summary>
        /// Sets the monthly commute cost.
        /// </summary>
        /// <param name="monthlyCommuteCost">Monthly commute cost.</param>
        private void setMonthlyCommuteCost(double monthlyCommuteCost)
        {
            this.monthlyCommuteCost = monthlyCommuteCost;
        }
        /// <summary>
        /// Creates the criteria salary.
        /// </summary>
        private void createCriteria_Salary()
        {
            Criteria hold = new Salary(medianSalary, salary);
            criteriaList.Add(hold);
        }
        /// <summary>
        /// Creates the criteria commute comfort.
        /// </summary>
        private void createCriteria_CommuteComfort()
        {
            Criteria hold = new CommuteComfort(aveRidersArea, ridersArea, commuteType);
            criteriaList.Add(hold);
        }
        /// <summary>
        /// Creates the criteria commute time.
        /// </summary>
        private void createCriteria_CommuteTime()
        {
            Criteria hold = new CommuteTime(aveCommuteTime, commuteTime);
            criteriaList.Add(hold);
        }
        /// <summary>
        /// Creates the criteria commute cost.
        /// </summary>
        private void createCriteria_CommuteCost()
        {
            Criteria hold = new CommuteCost(monthlyCommuteCost, salary);
            criteriaList.Add(hold);
        }
        /// <summary>
        /// Creates the criteria job interest.
        /// </summary>
        private void createCriteria_JobInterest()
        {
            Criteria hold = new JobInterest(jobInterest);
            criteriaList.Add(hold);
        }
        /// <summary>
        /// Creates the criteria salary satisfaction.
        /// </summary>
        private void createCriteria_SalarySatisfaction()
        {
            Criteria hold = new SalarySatisfaction(salarySatisfaction);
            criteriaList.Add(hold);
        }
        /// <summary>
        /// Gets the criteria explanation salary.
        /// </summary>
        /// <returns>The criteria explanation salary.</returns>
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
        /// <summary>
        /// Gets the criteria explanation commute comfort.
        /// </summary>
        /// <returns>The criteria explanation commute comfort.</returns>
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
        /// <summary>
        /// Gets the criteria explanation commute time.
        /// </summary>
        /// <returns>The criteria explanation commute time.</returns>
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
        /// <summary>
        /// Gets the criteria explanation commute cost.
        /// </summary>
        /// <returns>The criteria explanation commute cost.</returns>
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
        /// <summary>
        /// Gets the criteria explanation job interest.
        /// </summary>
        /// <returns>The criteria explanation job interest.</returns>
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
        /// <summary>
        /// Gets the criteria explanation salary satisfaction.
        /// </summary>
        /// <returns>The criteria explanation salary satisfaction.</returns>
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
        /// <summary>
        /// Gets the criteria mark salary.
        /// </summary>
        /// <returns>The criteria mark salary.</returns>
        public double[] getCriteriaMark_Salary()
        {
            double[] ret = { 0.0, 0.0 };
            for (int n = 0; n < criteriaList.Count; n++)
            {
                if (criteriaList[n] is Salary)
                {

                    ret[0] = formatDoubleDecimalPoint(criteriaList[n].getSubScore());
                    ret[1] = formatDoubleDecimalPoint(criteriaList[n].getWeightage());
                }
            }
            return ret;
        }
        /// <summary>
        /// Gets the criteria mark commute comfort.
        /// </summary>
        /// <returns>The criteria mark commute comfort.</returns>
        public double[] getCriteriaMark_CommuteComfort()
        {
            double[] ret = { 0.0, 0.0 };
            for (int n = 0; n < criteriaList.Count; n++)
            {
                if (criteriaList[n] is CommuteComfort)
                {
                    ret[0] = formatDoubleDecimalPoint(criteriaList[n].getSubScore());
                    ret[1] = formatDoubleDecimalPoint(criteriaList[n].getWeightage());
                }

            }
            return ret;
        }
        /// <summary>
        /// Gets the criteria mark commute time.
        /// </summary>
        /// <returns>The criteria mark commute time.</returns>
        public double[] getCriteriaMark_CommuteTime()
        {
            double[] ret = { 0.0, 0.0 };
            for (int n = 0; n < criteriaList.Count; n++)
            {
                if (criteriaList[n] is CommuteTime)
                {
                    ret[0] = formatDoubleDecimalPoint(criteriaList[n].getSubScore());
                    ret[1] = formatDoubleDecimalPoint(criteriaList[n].getWeightage());
                }
            }
            return ret;
        }
        /// <summary>
        /// Gets the criteria mark commute cost.
        /// </summary>
        /// <returns>The criteria mark commute cost.</returns>
        public double[] getCriteriaMark_CommuteCost()
        {
            double[] ret = { 0.0, 0.0 };
            for (int n = 0; n < criteriaList.Count; n++)
            {
                if (criteriaList[n] is CommuteCost)
                {
                    ret[0] = formatDoubleDecimalPoint(criteriaList[n].getSubScore());
                    ret[1] = formatDoubleDecimalPoint(criteriaList[n].getWeightage());
                }
            }
            return ret;
        }
        /// <summary>
        /// Gets the criteria mark job interest.
        /// </summary>
        /// <returns>The criteria mark job interest.</returns>
        public double[] getCriteriaMark_JobInterest()
        {
            double[] ret = { 0.0, 0.0 };
            for (int n = 0; n < criteriaList.Count; n++)
            {
                if (criteriaList[n] is JobInterest)
                {
                    ret[0] = formatDoubleDecimalPoint(criteriaList[n].getSubScore());
                    ret[1] = formatDoubleDecimalPoint(criteriaList[n].getWeightage());
                }
            }
            return ret;
        }
        /// <summary>
        /// Gets the criteria mark salary satisfaction.
        /// </summary>
        /// <returns>The criteria mark salary satisfaction.</returns>
        public double[] getCriteriaMark_SalarySatisfaction()
        {
            double[] ret = { 0.0, 0.0 };
            for (int n = 0; n < criteriaList.Count; n++)
            {
                if (criteriaList[n] is SalarySatisfaction)
                {
                    ret[0] = formatDoubleDecimalPoint(criteriaList[n].getSubScore());
                    ret[1] = formatDoubleDecimalPoint(criteriaList[n].getWeightage());
                }
            }
            return ret;
        }
        /// <summary>
        /// Checks the initialization.
        /// </summary>
        /// <returns><c>true</c>, if initialization was checked, <c>false</c> otherwise.</returns>
        private Boolean checkInitialization()
        {
            if (!initializationComplete)
            {
                throw new Exception("Please initialize all criteria");
            }
            return true;
        }
        /// <summary>
        /// Formats the double decimal point.
        /// </summary>
        /// <returns>The double decimal point.</returns>
        /// <param name="input">Input.</param>
        private double formatDoubleDecimalPoint(double input)
        {
            decimal d = (decimal)input;
            d = decimal.Round(d, 2);
            return (double)d;
        }
    }
}
