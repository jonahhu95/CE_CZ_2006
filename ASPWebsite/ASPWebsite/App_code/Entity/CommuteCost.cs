using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_code.Entity
{
    public class CommuteCost : Criteria
    {
        public CommuteCost(double monthlyTravelCost, int salary)
        {
            weightage = 10;
            explanations = new List<string> {"Description 1", "Description 2", "Description 3",
                "Description 4", "Description 5", "Description 6", "Description 7", "Description 8",
                "Description 9", "Description 10", "Description 11" };
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