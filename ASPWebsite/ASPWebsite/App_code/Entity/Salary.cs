using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_Code.Entity
{
    /// <summary>
    /// Salary.
    /// </summary>
    public class Salary : Criteria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ASPWebsite.App_Code.Entity.Salary"/> class.
        /// </summary>
        /// <param name="medianSalary">Median salary.</param>
        /// <param name="salary">Salary.</param>
        public Salary(int medianSalary, int salary)
        {
            weightage = 20;
            explanations = new List<String> {
                "Highest difference between current and median salary",
                "Very high difference between current and median salary",
                "High difference between current and median salary",
                "Significant difference between current and median salary",
                "Mild difference between current and median salary",
                "Moderate difference between current and median salary",
                "Little difference between current and median salary",
                "Very Little difference between current and median salary",
                "Very low difference between current and median salary",
                "Lowest difference between current and median salary" };

            int difference = 0;
            difference = salary - medianSalary;
            difference = difference / 1000;
            switch (difference)
            {
                case -4:
                    point = 0;
                    break;
                case -3:
                    point = 1;
                    break;
                case -2:
                    point = 2;
                    break;
                case -1:
                    point = 3;
                    break;
                case 0:
                    point = 4;
                    break;
                case 1:
                    point = 5;
                    break;
                case 2:
                    point = 6;
                    break;
                case 3:
                    point = 7;
                    break;
                case 4:
                    point = 8;
                    break;
                default:
                    if (difference > 4)
                    {
                        point = 9;
                    }
                    else
                    {
                        point = 0;
                    }
                    break;
            }
            subScore = ((double)point / 9.0) * weightage;
        }
    }
}