using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPWebsite.App_code.Entity
{
    public abstract class Criteria
    {

        protected double weightage;
        protected double subScore;
        protected int point = -1;
        protected List<string> explanations;

        public string getExplanation()
        {
            if (point != -1)
            {
                return explanations[point];
            }
            return "Error";
        }

        public double getWeightage()
        {
            return weightage;
        }
        public double getSubScore()
        {
            return subScore;
        }
    }
}
