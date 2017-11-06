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
                "There is a high tendency of you to get squeezed into public transport if you decide to accept the job offer.",
                "You may not always be on time to work as there are time when the number of transport is not enough to cater to the publics.",
                "You will experience the same commute comfortability as other working adults. Waking up a little early in the morning may help to avoid the crowdedness at the waiting area.",
                "You will have a pleasant journey to work most of the time.",
                "You will have a good start at work everyday as you are excluded from squeezing in public transport especially under hot and humid weather." };

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