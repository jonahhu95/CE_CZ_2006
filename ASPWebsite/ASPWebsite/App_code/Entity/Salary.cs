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
			"You will be severely underpaid in this offer.",
			"The salary may not be sufficient to cover your monthly utility bill.",
			"The less than average salary may not be ideal if you want to have a comfortable lifestyle.",
			"You may need to find some ways to stretch your money if you decide to take up the offer.",
			"The salary may not be what you are looking for.",
			"The salary is of the same rate as what your peers have.",
			"The salary helps to strike the balance in the rising cost of living.",
			"The salary is good enough that you will afford to save a small amount for future emergency use.",
			"The salary is sufficient to afford you an avocado toast and coffee every morning.",
            "The job salary is on the top of the salary level."
                 };

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