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
            lbl1.Text = c.getCriteriaExplanation_CommuteCost().ToString();
            lbl2.Text = c.getCriteriaMark_CommuteComfort()[0].ToString() + "/" + c.getCriteriaMark_CommuteComfort()[1].ToString();
        }
    }
}