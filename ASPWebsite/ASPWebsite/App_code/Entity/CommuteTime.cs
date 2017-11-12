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
                "You commute time is the highest among the group and it might affect overall health in long term.",
                "Physical and psycological exhaustion may be a possible outcome due to the travel time in between home and work locstion.",
                "Your work performance may be affected due to the lengthy commute time.",
                "The length of travelling between two location which is higher than the average of 40 minutes may result in decrease of patience. In the worst case it can ruin your day.",
                "Stress may be a concern during the long time between travelling.",
                "Commute time is not a big issue to consider whether to take up the offer.",
                "You can expect to save some time for other tasks as your commute time is lower than the average.",
                "The amount of time you save by taking up the job will allow you to have sufficient time to prepare your breakfast.",
                "An ideal home and work location which you will have sufficient sleeping time before work starts" };

            double difference = travelTime - averageTravelTime;
            if (difference >= -10)
            {
                if (difference <= 10)
                {
                    point = 4;
                }
                else if (difference <= 30)
                {
                    if (difference <= 20)
                    {
                        point = 3;
                    }
                    else
                    {
                        point = 2;
                    }
                }
                else if (difference <= 40)
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
                if (difference >= -30)
                {
                    if (difference >= -20)
                    {
                        point = 5;
                    }
                    else
                    {
                        point = 6;
                    }
                }
                else if (difference >= -40)
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