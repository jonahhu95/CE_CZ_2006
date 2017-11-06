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
                "You may consider to get another job instead because the salary does not meet your requirement.",      
                "The salary will not motivate you to work hard and you may need to reconsider the worth of this job offer.",                         
                "Limited growth and development may be part of the concern while you are looking at the pay.",
                "While the salary is attractive, you may have on second thought about the outlook of the position.",
                "The pay is good enough but the work environment may hinder you from picking up the offer.",
                "The pay offered by the company satisfy your need.",
                "You are satisfied with the salary as you fought hard for it.",
                "The salary may improve your living.",
                "You will be extremely satisfied with the pay by the end of every month.",
                "Salary will be your satisfaction to work." };
            point = salaryInterest - 1;
            subScore = ((double)point / 9.0) * weightage;
        }
    }
}