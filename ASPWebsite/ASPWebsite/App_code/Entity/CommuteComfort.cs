using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_Code.Entity
{
    /// <summary>
    /// Commute comfort.
    /// </summary>
    public class CommuteComfort : Criteria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ASPWebsite.App_Code.Entity.CommuteComfort"/> class.
        /// </summary>
        /// <param name="averageRidersArea">Average riders area.</param>
        /// <param name="ridersArea">Riders area.</param>
        /// <param name="travelMode">Travel mode.</param>
        public CommuteComfort(int averageRidersArea, int ridersArea, char travelMode)
        {
            weightage = 15;
            explanations = new List<string> { 
                "Least commute comfort, high tendency to get held up by traffic.", 
                "Low commute comfort, may encounter pushing and shoving.", 
                "Average commute comfort, may encounter occasional hiccups.", 
                "High commute comfort, may have a pleasant journey most of the time.", 
                "Most commute comfort, having a smooth journey all the time."};

            if (travelMode == 'p')
            {
                long difference = ridersArea - averageRidersArea;
                if (difference > 20000)
                {
                    if(difference > 40000)
                    {
                        point = 0;
                    }else
                    {
                        point = 1;
                    }
                    
                }
                else if (difference < -12000)
                {
                    if(difference < -24000)
                    {
                        point = 4;
                    }
                    else
                    {
                        point = 3;
                    }
                    
                }
                else
                {
                    point = 2;
                }
            }
            else if (travelMode == 'c')
            {
                point = 4;
            }
            subScore = ((double)point/4.0)*weightage;
        }
    }
}