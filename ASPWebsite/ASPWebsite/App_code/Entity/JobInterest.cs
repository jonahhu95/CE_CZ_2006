using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_Code.Entity
{
    public class JobInterest : Criteria
    {
        public JobInterest(int jobInterest)
        {
            weightage = 20;
            explanations = new List<string> { "Description 1", "Description 2", "Description 3",
                "Description 4", "Description 5", "Description 6", "Description 7", "Description 8",
                "Description 9", "Description 10" };
            point = jobInterest - 1;
            subScore = ((double)point / 9.0) * weightage;
        }
    }
}