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
            explanations = new List<string> { "Description 1", "Description 2", "Description 3" };
            if (travelMode == 'p')
            {
                int difference = ridersArea - averageRidersArea;
                if (difference > 8000)
                {
                    point = 0;
                }
                else if (difference < -8000)
                {
                    point = 2;
                }
                else
                {
                    point = 1;
                }
            }
            else if (travelMode == 'c')
            {
                point = 2;
            }
            subScore = ((double)point/3.0)*weightage;
        }
    }
}