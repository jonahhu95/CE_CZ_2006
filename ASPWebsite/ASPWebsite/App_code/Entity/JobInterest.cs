using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_Code.Entity
{
    /// <summary>
    /// Job interest.
    /// </summary>
    public class JobInterest : Criteria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ASPWebsite.App_Code.Entity.JobInterest"/> class.
        /// </summary>
        /// <param name="jobInterest">Job interest.</param>
        public JobInterest(int jobInterest)
        {
            weightage = 20;
            explanations = new List<String> {
                "Least interest in jobscope",
                "Very low interest in jobscope",
                "Low interest in jobscope",
                "little interest in jobscope",
                "Moderate interest in jobscope",
                "Mild interest in jobscope",
                "Quite interested in jobscope",
                "high interest in jobscope",
                "Very high interest in jobscope",
                "Most interest in jobscope" };
            point = jobInterest - 1;
            subScore = ((double)point / 9.0) * weightage;
        }
    }
}