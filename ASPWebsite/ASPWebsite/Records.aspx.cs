using ASPWebsite.App_Code.Control;
using ASPWebsite.App_Code.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPWebsite
{
    public partial class Records : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CalculationManager cm = new CalculationManager();

            //List<Calculation> c = cm.getCalculations(Session["Username"].ToString());
            //gvData.DataSource = c;
            //gvData.DataBind();

            Label1.Text = cm.getCalculations(Session["Username"].ToString()).ToString();


            //c = cm.getCalculations(Session["Username"]);

        }


    }
}