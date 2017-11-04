using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPWebsite.App_Code.Entity
{
    /// <summary>
    /// Criteria.
    /// </summary>
    public abstract class Criteria
    {
        /// <summary>
        /// The weightage.
        /// </summary>
        protected double weightage;

        /// <summary>
        /// The sub score.
        /// </summary>
        protected double subScore;

        /// <summary>
        /// The point.
        /// </summary>
        protected int point = -1;

        /// <summary>
        /// The explanations.
        /// </summary>
        protected List<string> explanations;

        /// <summary>
        /// Gets the explanation.
        /// </summary>
        /// <returns>The explanation.</returns>
        public string getExplanation()
        {
            if (point != -1)
            {
                return explanations[point];
            }
            return "Error";
        }
        /// <summary>
        /// Gets the weightage.
        /// </summary>
        /// <returns>The weightage.</returns>
        public double getWeightage()
        {
            return weightage;
        }
        /// <summary>
        /// Gets the sub score.
        /// </summary>
        /// <returns>The sub score.</returns>
        public double getSubScore()
        {
            return subScore;
        }
    }
}
