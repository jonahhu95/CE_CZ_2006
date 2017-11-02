using ASPWebsite.App_Code.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPWebsite
{
    public partial class Result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Calculation c = (Calculation)Session["CalculationJSIObject"];
            lblJSI.Text = c.getJSIScore().ToString();
            lbl2.Text = c.getCriteriaMark_CommuteComfort()[0].ToString() + "/" + c.getCriteriaMark_CommuteComfort()[1].ToString();
            lbl1.Text = c.getCriteriaExplanation_CommuteComfort().ToString();
            lbl3.Text = c.getCriteriaExplanation_CommuteCost().ToString();
            lbl4.Text = c.getCriteriaExplanation_CommuteTime().ToString();
            lbl5.Text = c.getCriteriaExplanation_JobInterest().ToString();
            lbl6.Text = c.getCriteriaExplanation_Salary().ToString();
            lbl7.Text = c.getCriteriaExplanation_SalarySatisfaction().ToString();
            lblcc.Text = c.getCriteriaMark_CommuteCost()[0].ToString() + "/" + c.getCriteriaMark_CommuteCost()[1].ToString();
            lblss.Text = c.getCriteriaMark_SalarySatisfaction()[0].ToString() + "/" + c.getCriteriaMark_SalarySatisfaction()[1].ToString();
            lblji.Text = c.getCriteriaMark_JobInterest()[0].ToString() + "/" + c.getCriteriaMark_JobInterest()[1].ToString();
            lblms.Text = c.getCriteriaMark_Salary()[0].ToString() + "/" + c.getCriteriaMark_Salary()[1].ToString();
            lblct.Text = c.getCriteriaMark_CommuteTime()[0].ToString() + "/" + c.getCriteriaMark_CommuteTime()[1].ToString();
        }
    }
}