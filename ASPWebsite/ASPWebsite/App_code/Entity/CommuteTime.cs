using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_Code.Entity
{
    public class CommuteTime : Criteria
    {
        public CommuteTime(double averageTravelTime, double travelTime)
        {
            weightage = 20;
            explanations = new List<string> { "Description 1", "Description 2", "Description 3",
                "Description 4", "Description 5", "Description 6", "Description 7", "Description 8",
                "Description 9" };
            double difference = travelTime - averageTravelTime;
            if (difference >= -15)
            {
                if (difference <= 15)
                {
                    point = 4;
                }
                else if (difference <= 45)
                {
                    if (difference <= 30)
                    {
                        point = 3;
                    }
                    else
                    {
                        point = 2;
                    }
                }
                else if (difference <= 60)
                {
                    point = 1;
                }
                else
                {
                    point = 0;
                }
            }
            else
            {
                if (difference >= -45)
                {
                    if (difference >= -30)
                    {
                        point = 5;
                    }
                    else
                    {
                        point = 6;
                    }
                }
                else if (difference <= -60)
                {
                    point = 7;
                }
                else
                {
                    point = 8;
                }
            }
            subScore = ((double)point / 8.0) * weightage;
        }
    }
}