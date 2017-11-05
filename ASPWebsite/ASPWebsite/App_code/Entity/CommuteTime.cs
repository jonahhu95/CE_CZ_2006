using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_Code.Entity
{
    /// <summary>
    /// Commute time.
    /// </summary>
    public class CommuteTime : Criteria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ASPWebsite.App_Code.Entity.CommuteTime"/> class.
        /// </summary>
        /// <param name="averageTravelTime">Average travel time.</param>
        /// <param name="travelTime">Travel time.</param>
        public CommuteTime(double averageTravelTime, double travelTime)
        {
            weightage = 20;
            explanations = new List<String> {
                "Most amount of time needed for commuting, may affect overall health.",
                "Very high amount of time needed for commuting, may increase strain in health.",
                "High amount of time needed for commuting, leisure time may be reduced.",
                "Significant amount of time needed for commuting, may get impatient.",
                "Moderate amount of time needed for commuting, may have feelings of stress.",
                "Considerate amount of time needed for commuting, generally comfortable.",
                "Little time needed for commuting, happy most of the time.",
                "Very little time needed for commuting, very satisfied.",
                "Least time needed for commmuting, extremely satisfied. " };

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