using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_Code.Entity
{
    /// <summary>
    /// Commute cost.
    /// </summary>
    public class CommuteCost : Criteria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ASPWebsite.App_Code.Entity.CommuteCost"/> class.
        /// </summary>
        /// <param name="monthlyTravelCost">Monthly travel cost.</param>
        /// <param name="salary">Salary.</param>
        public CommuteCost(double monthlyTravelCost, int salary)
        {
            weightage = 10;
            explanations = new List<string> {
                "Highest cost of travelling.",
                "Very high cost of travelling.",
                "High cost of travelling.",
                "Moderate cost of travelling.",
                "Average cost of travelling.",
                "Ordinary cost of travelling.",
                "Little cost of travelling.",
                "Very little cost of travelling.",
                "Low cost of travelling.",
                "Very low cost of travelling.",
                "Lowest cost of travelling." };

            double ratio = monthlyTravelCost / salary;
            if (ratio < 1.75)
            {
                if (ratio < 1.35)
                {
                    if (ratio < 0.95)
                    {
                        if (ratio < 0.75)
                        {
                            point = 10;
                        }
                        else
                        {
                            point = 9;
                        }
                    }
                    else
                    {
                        if (ratio < 1.15)
                        {
                            point = 8;
                        }
                        else
                        {
                            point = 7;
                        }
                    }
                }
                else
                {
                    if (ratio < 1.55)
                    {
                        point = 6;
                    }
                    else
                    {
                        point = 5;
                    }
                }
            }
            else
            {
                if (ratio < 2.15)
                {
                    if (ratio < 1.95)
                    {
                        point = 4;
                    }
                    else
                    {
                        point = 3;
                    }
                }
                else if (ratio < 2.45)
                {
                    if (ratio < 2.25)
                    {
                        point = 2;
                    }
                    else
                    {
                        point = 1;
                    }
                }
                else
                {
                    point = 0;
                }
            }
            subScore = ((double)point / 10.0) * weightage;
        }
    }
}