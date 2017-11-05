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

        protected void Button2_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openLoginModal();", true);
        }

        protected void loginBtn_Click1(object sender, EventArgs e)
        {
            UserManager um = new UserManager();
            Boolean t = um.loginUser(tbEmail.Text, tbPassword.Text);

            if (t)
                Response.Redirect("UserPage.aspx?Username=" + tbEmail.Text);
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openLoginModal();", true);
                lblLoginWarning.Text = "Invalid username or password";
                tbPassword.Text = null;
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UserManager um = new UserManager();
            if (tbPassword2.Text == tbConfirmPW.Text)
            {
                if (um.createUser(tbEmail2.Text, tbPassword2.Text))
                {
                    Response.Redirect("UserPage.aspx?Username=" + tbEmail2.Text);
                }

                else
                {
                    //when email exist in database
                    //need a method here to check
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    LabelWarning.Text = "Username exist in database";
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                LabelWarning.Text = "Password does not match confirm password!";
                tbConfirmPW.Text = null;
                tbPassword2.Text = null;
            }

        }
    }
}