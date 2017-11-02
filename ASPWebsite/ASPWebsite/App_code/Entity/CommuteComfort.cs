using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_Code.Entity
{
    public class CommuteComfort : Criteria
    {
        public CommuteComfort(int averageRidersArea, int ridersArea, char travelMode)
        {
            weightage = 15;
            explanations = new List<string> { "Description 1", "Description 2", "Description 3", "Description 4", "Description 5"};
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