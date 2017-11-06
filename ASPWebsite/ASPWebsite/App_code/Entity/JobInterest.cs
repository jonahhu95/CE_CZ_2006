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
                "Your interest level towards the job offer is the lowest as compared to other who is offered the same job.",
                "You work value may not match the job offer.",
                "You may have some worries about taking up the offer.",
                "You can consider to accept the job offer if salary and work location is not a concern.",
                "You may find the 'eureka' moment in this job",
                "A job that is in line with your interest will help you to move up faster in your career.",
                "This may be your dream job",
                "This job offer may be a fulfiling career for you.",
				"This job will be a perfect fit for you.",
                "You are born for the job.",
                };
            point = jobInterest - 1;
            subScore = ((double)point / 9.0) * weightage;
        }
    }
}