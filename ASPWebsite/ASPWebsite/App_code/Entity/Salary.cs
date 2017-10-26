using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_code.Entity
{
    public class Salary : Criteria
    {
        public Salary(int medianSalary, int salary)
        {
            weightage = 20;
            explanations = new List<string> { "Description 1", "Description 2", "Description 3",
                "Description 4", "Description 5", "Description 6", "Description 7", "Description 8",
                "Description 9", "Description 10" };
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