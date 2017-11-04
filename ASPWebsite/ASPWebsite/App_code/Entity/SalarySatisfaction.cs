using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_Code.Entity
{
    /// <summary>
    /// Salary satisfaction.
    /// </summary>
    public class SalarySatisfaction : Criteria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ASPWebsite.App_Code.Entity.SalarySatisfaction"/> class.
        /// </summary>
        /// <param name="salaryInterest">Salary interest.</param>
        public SalarySatisfaction(int salaryInterest)
        {
            weightage = 15;
            explanations = new List<string> {
                "Extremely dissatisfied with salary, may not be rewarded and recognised.",
                "Very dissatisfied with salary, may not be inspired.",
                "Dissatisfied with salary, may have little growth and development.",
                "Mildly dissatisfied with salary, may have little job security.",
                "Neutral to salary satisfaction, may have uncertainties in work environment.",
                "Mildly satisfied with salary, may be satisfied with company.",
                "Quite satisfied with salary, may have established good communication.",
                "Satisfied with salary, generally contented with remuneration.",
                "Very satisfied with salary, may feel energised to work.",
                "Fully satisfied with salary, may feel extremely moltivated." };
            point = salaryInterest - 1;
            subScore = ((double)point / 9.0) * weightage;
        }
    }
}