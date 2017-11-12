using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_Code.Entity
{
    /// <summary>
    /// Commute cost.
    /// </summary>
    public class CommuteCost : Criteria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ASPWebsite.App_Code.Entity.CommuteCost"/> class.
        /// </summary>
        /// <param name="monthlyTravelCost">Monthly travel cost.</param>
        /// <param name="salary">Salary.</param>
        public CommuteCost(double monthlyTravelCost, int salary)
        {
            weightage = 10;
            explanations = new List<string> {
                "You may need to sacrifice your some of your entertainment to cover the travelling cost. I would suggest you not to take up the offer.",
                "The travelling cost is higher than the average ratio. You may need to reconsider in taking up the offer.",
                "The cost on transportation does not fall within the desirable range but do go for it if you think the job is worth the money.",
				"The monthly travel cost to salary ratio is just right. You might want to consider the other factors before you take up the job offer.",
				"You can consider to take up this job offer as the transport cost will not burn a hole in your pocket.",
                "Your monthly travelling cost to salary ratio is almost the same as your peer. Do consult your peer if you are not sure on whether to take up the offer.",
                "You will be able to save the monthly travelling cost for that extra shot of coffee. The monthly travel cost is just within the ideal range",
                "The monthly cost of travelling between work and home location is desirable.",
                "You can expect to save some money for your future house if you take up the job offer. It falls within the ideal range.",
                "You are highly recommended to take up the offer since you don't need to sacrifice your favourite entertainment. The monthly travel cost will allow you to save and get something good to treat yourself on a bad day.",
                "Your travelling cost falls within the ideal range. Congratulation!" };

            double ratio = (monthlyTravelCost / salary) * 100;
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