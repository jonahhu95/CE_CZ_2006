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
    public partial class CalculationResult : System.Web.UI.Page
    {
        Calculation c;
        // static variable
        static string prevPage = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                prevPage = Request.UrlReferrer.ToString();
            }

            if (Session["Username"] != null)
            {
                pnlFeedback.Visible = true;
            }

            if (Session["CalculationJSIObject"] != null)
            {
                c = (Calculation)Session["CalculationJSIObject"];
            }
            else
            {
                if (Session["DetailObject"] != null)
                {
                    c = (Calculation)Session["DetailObject"];
                    btnSave.Visible = false;
                    pnlFeedback.Visible = false;
                }

            }

            try
            {
                lblJSI.Text = c.getJSIScore().ToString() + "/100";
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
            catch
            {
                Response.Redirect("Home.aspx");
            }

        }

        /// <summary>
        /// Button2 Record click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Session["Username"] == null) { ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openLoginModal();", true); }
            else
            {
                CalculationManager cm = new CalculationManager();
                Boolean t = cm.saveCalculation(c, Session["Username"].ToString());
                if (t)
                {
                    Response.Redirect("Records.aspx");
                }
                else
                {

                }

            }

        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }

        /// <summary>
        /// Buttons feedback click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        protected void btnFeedback_Click(object sender, EventArgs e)
        {
            FeedbackManager fm = new FeedbackManager();
            fm.addFeedback(Session["Username"].ToString(), tbFeedbackMessage.Text);
            pnlFeedback.Visible = false;
            lblFeedbackMessage.Visible = true;
            lblFeedbackMessage.Text = "Feedback Sent!";

        }
    }
}