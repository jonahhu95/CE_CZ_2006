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
    /// <summary>
    /// Records.
    /// </summary>
    public partial class Records : System.Web.UI.Page
    {
        //List<Calculation> cal = null;
        /// <summary>
        /// Load the page
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Session["CalculationJSIObject"] = null;
                bindGv();
                if (gvData.Rows.Count != 0)
                {
                    compareRecords();
                }
                else
                {
                    pnlNoRecords.Visible = true;
                    btnCompare.Visible = false;
                }

            }
        }
        private void bindGv()
        {
            CalculationManager cm = new CalculationManager();
            //List<Calculation> c = cm.getCalculations("joey");
            List<Calculation> c = cm.getCalculations(Session["Username"].ToString());
            gvData.DataSource = c;
            gvData.DataBind();
        }
        /// <summary>
        /// Compares the records.
        /// </summary>
        protected void compareRecords()
        {
            //int salaryRating = 0;
            //int salaryRatingRow = 0;

            //int jobRating = 0;
            //int jobRatingRow = 0;

            //double JSI = 0;
            //int JSIRow = 0;

            //double JSIe = 0;
            //int JSIRowe = 0;
            //foreach (GridViewRow row in gvData.Rows)
            //{
            //    if (Convert.ToInt32(row.Cells[2].Text) >= salaryRating && Convert.ToDouble(row.Cells[4].Text) >= JSIe)
            //    {
            //        JSIe = Convert.ToDouble(row.Cells[4].Text);
            //        salaryRating = Convert.ToInt32(row.Cells[2].Text);
            //        salaryRatingRow = row.RowIndex;
            //    }
            //    if (Convert.ToInt32(row.Cells[3].Text) >= jobRating && Convert.ToDouble(row.Cells[4].Text) >= JSIe)
            //    {
            //        JSIe = Convert.ToDouble(row.Cells[4].Text);
            //        jobRating = Convert.ToInt32(row.Cells[3].Text);
            //        jobRatingRow = row.RowIndex;
            //    }
            //    if (Convert.ToDouble(row.Cells[4].Text) >= JSI)
            //    {
            //        JSI = Convert.ToDouble(row.Cells[4].Text);
            //        JSIRow = row.RowIndex;
            //    }
            //    if (Convert.ToDouble(row.Cells[4].Text) >= JSIe)
            //    {
            //        JSIe = Convert.ToDouble(row.Cells[4].Text);
            //        JSIRowe = row.RowIndex;
            //    }
            //}

            //var sr = this.gvData.Rows[salaryRatingRow];
            //sr.Cells[5].Text = "Yes!";

            //var jr = this.gvData.Rows[jobRatingRow];
            //jr.Cells[6].Text = "Yes!";

            //var jsir = this.gvData.Rows[JSIRow];
            //jsir.Cells[7].Text = "Yes!";

            ////check for duplicate
            //foreach (GridViewRow dup in gvData.Rows)
            //{
            //    if (dup.Cells[2].Text == salaryRating.ToString() && dup.Cells[3].Text == jobRating.ToString() && dup.Cells[4].Text == JSI.ToString())
            //    {
            //        if (dup.Cells[5].Text == "&nbsp;" && dup.Cells[6].Text == "&nbsp;" && dup.Cells[7].Text == "&nbsp;")
            //        {
            //            dup.Cells[5].Text = "Yes!";
            //            dup.Cells[6].Text = "Yes!";
            //            dup.Cells[7].Text = "Yes!";
            //        }

            //    }
            //}
        }

        /// <summary>
        /// Buttons compare click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        protected void btnCompare_Click(object sender, EventArgs e)
        {
            CalculationManager cm = new CalculationManager();
            //List<Calculation> c = cm.getCalculations("joey");
            List<Calculation> c = cm.getCalculations(Session["Username"].ToString());

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openCompareModal();", true);
            string str = string.Empty;
            string strname = string.Empty;
            int index = 0;

            Calculation cal1 = null, cal2 = null;
            foreach (GridViewRow gvrow in gvData.Rows)
            {
                CheckBox chk = gvrow.FindControl("checkBoxSelect") as CheckBox;
                if (chk != null && chk.Checked)
                {
                    if (cal1 == null)
                        cal1 = c[index];
                    else
                    {
                        cal2 = c[index];
                        break;
                    }
                }
                index++;
            }

            if (cal1 != null && cal2 != null)
            {
                lbl1.Text = cal1.getWorkLocation().getArea().ToString();
                lbl2.Text = cal2.getWorkLocation().getArea().ToString();
                //Commute Comfort
                if (cal1.getCriteriaMark_CommuteComfort()[0] > cal2.getCriteriaMark_CommuteComfort()[0])
                {
                    firstcco.Text = cal1.getCriteriaMark_CommuteComfort()[0].ToString() + " <br/> " + cal1.getCriteriaExplanation_CommuteComfort().ToString();
                    ccoCompare.Text = " > ";
                    secondcco.Text = cal2.getCriteriaMark_CommuteComfort()[0].ToString() + " <br/> " + cal2.getCriteriaExplanation_CommuteComfort().ToString();
                }
                else if (cal1.getCriteriaMark_CommuteComfort()[0] < cal2.getCriteriaMark_CommuteComfort()[0])
                {
                    firstcco.Text = cal1.getCriteriaMark_CommuteComfort()[0].ToString() + " <br/> " + cal1.getCriteriaExplanation_CommuteComfort().ToString();
                    ccoCompare.Text = " < ";
                    secondcco.Text = cal2.getCriteriaMark_CommuteComfort()[0].ToString() + " <br/> " + cal2.getCriteriaExplanation_CommuteComfort().ToString();
                }
                else
                {
                    firstcco.Text = cal1.getCriteriaMark_CommuteComfort()[0].ToString() + " <br/> " + cal1.getCriteriaExplanation_CommuteComfort().ToString();
                    ccoCompare.Text = " = ";
                    secondcco.Text = cal2.getCriteriaMark_CommuteComfort()[0].ToString() + " <br/> " + cal2.getCriteriaExplanation_CommuteComfort().ToString();
                }

                //Commute Cost
                if (cal1.getCriteriaMark_CommuteCost()[0] > cal2.getCriteriaMark_CommuteCost()[0])
                {
                    firstcc.Text = cal1.getCriteriaMark_CommuteCost()[0].ToString() + " <br/> " + cal1.getCriteriaExplanation_CommuteCost().ToString();
                    ccCompare.Text = " > ";
                    secondcc.Text = cal2.getCriteriaMark_CommuteCost()[0].ToString() + " <br/> " + cal2.getCriteriaExplanation_CommuteCost().ToString();
                }
                else if (cal1.getCriteriaMark_CommuteCost()[0] < cal2.getCriteriaMark_CommuteCost()[0])
                {
                    firstcc.Text = cal1.getCriteriaMark_CommuteCost()[0].ToString() + " <br/> " + cal1.getCriteriaExplanation_CommuteCost().ToString();
                    ccCompare.Text = " < ";
                    secondcc.Text = cal2.getCriteriaMark_CommuteCost()[0].ToString() + " <br/> " + cal2.getCriteriaExplanation_CommuteCost().ToString();
                }
                else
                {
                    firstcc.Text = cal1.getCriteriaMark_CommuteCost()[0].ToString() + " <br/> " + cal1.getCriteriaExplanation_CommuteCost().ToString();
                    ccCompare.Text = " = ";
                    secondcc.Text = cal2.getCriteriaMark_CommuteCost()[0].ToString() + " <br/> " + cal2.getCriteriaExplanation_CommuteCost().ToString();
                }

                //Commute Time
                if (cal1.getCriteriaMark_CommuteTime()[0] > cal2.getCriteriaMark_CommuteTime()[0])
                {
                    firstct.Text = cal1.getCriteriaMark_CommuteTime()[0].ToString() + " <br/> " + cal1.getCriteriaExplanation_CommuteTime().ToString();
                    ctCompare.Text = " > ";
                    secondct.Text = cal2.getCriteriaMark_CommuteTime()[0].ToString() + " <br/> " + cal2.getCriteriaExplanation_CommuteTime().ToString();
                }
                else if (cal1.getCriteriaMark_CommuteTime()[0] < cal2.getCriteriaMark_CommuteTime()[0])
                {
                    firstct.Text = cal1.getCriteriaMark_CommuteTime()[0].ToString() + " <br/> " + cal1.getCriteriaExplanation_CommuteTime().ToString();
                    ctCompare.Text = " < ";
                    secondct.Text = cal2.getCriteriaMark_CommuteTime()[0].ToString() + " <br/> " + cal2.getCriteriaExplanation_CommuteTime().ToString();
                }
                else
                {
                    firstct.Text = cal1.getCriteriaMark_CommuteTime()[0].ToString() + " <br/> " + cal1.getCriteriaExplanation_CommuteTime().ToString();
                    ctCompare.Text = " = ";
                    secondct.Text = cal2.getCriteriaMark_CommuteTime()[0].ToString() + " <br/> " + cal2.getCriteriaExplanation_CommuteTime().ToString();
                }


                //Job Interest
                if (cal1.getCriteriaMark_JobInterest()[0] > cal2.getCriteriaMark_JobInterest()[0])
                {
                    firstji.Text = cal1.getCriteriaMark_JobInterest()[0].ToString() + " <br/> " + cal1.getCriteriaExplanation_JobInterest().ToString();
                    jiCompare.Text = " > ";
                    secondji.Text = cal2.getCriteriaMark_JobInterest()[0].ToString() + " <br/> " + cal2.getCriteriaExplanation_JobInterest().ToString();
                }
                else if (cal1.getCriteriaMark_JobInterest()[0] < cal2.getCriteriaMark_JobInterest()[0])
                {
                    firstji.Text = cal1.getCriteriaMark_JobInterest()[0].ToString() + " <br/> " + cal1.getCriteriaExplanation_JobInterest().ToString();
                    jiCompare.Text = " < ";
                    secondji.Text = cal2.getCriteriaMark_JobInterest()[0].ToString() + " <br/> " + cal2.getCriteriaExplanation_JobInterest().ToString();
                }
                else
                {
                    firstji.Text = cal1.getCriteriaMark_JobInterest()[0].ToString() + " <br/> " + cal1.getCriteriaExplanation_JobInterest().ToString();
                    jiCompare.Text = " = ";
                    secondji.Text = cal2.getCriteriaMark_JobInterest()[0].ToString() + " <br/> " + cal2.getCriteriaExplanation_JobInterest().ToString();
                }

                //Salary
                if (cal1.getCriteriaMark_Salary()[0] > cal2.getCriteriaMark_Salary()[0])
                {
                    firstms.Text = cal1.getCriteriaMark_Salary()[0].ToString() + " <br/> " + cal1.getCriteriaExplanation_Salary().ToString();
                    msCompare.Text = " > ";
                    secondms.Text = cal2.getCriteriaMark_Salary()[0].ToString() + " <br/> " + cal2.getCriteriaExplanation_Salary().ToString();
                }
                else if (cal1.getCriteriaMark_Salary()[0] < cal2.getCriteriaMark_Salary()[0])
                {
                    firstms.Text = cal1.getCriteriaMark_Salary()[0].ToString() + " <br/> " + cal1.getCriteriaExplanation_Salary().ToString();
                    msCompare.Text = " < ";
                    secondms.Text = cal2.getCriteriaMark_Salary()[0].ToString() + " <br/> " + cal2.getCriteriaExplanation_Salary().ToString();
                }
                else
                {
                    firstms.Text = cal1.getCriteriaMark_Salary()[0].ToString() + " <br/> " + cal1.getCriteriaExplanation_Salary().ToString();
                    msCompare.Text = " = ";
                    secondms.Text = cal2.getCriteriaMark_Salary()[0].ToString() + " <br/> " + cal2.getCriteriaExplanation_Salary().ToString();
                }

                //Salary Satisfaction
                if (cal1.getCriteriaMark_SalarySatisfaction()[0] > cal2.getCriteriaMark_SalarySatisfaction()[0])
                {
                    firstss.Text = cal1.getCriteriaMark_SalarySatisfaction()[0].ToString() + " <br/> " + cal1.getCriteriaExplanation_SalarySatisfaction().ToString();
                    ssCompare.Text = " > ";
                    secondss.Text = cal2.getCriteriaMark_SalarySatisfaction()[0].ToString() + " <br/> " + cal2.getCriteriaExplanation_SalarySatisfaction().ToString();
                }
                else if (cal1.getCriteriaMark_SalarySatisfaction()[0] < cal2.getCriteriaMark_SalarySatisfaction()[0])
                {
                    firstss.Text = cal1.getCriteriaMark_SalarySatisfaction()[0].ToString() + " <br/> " + cal1.getCriteriaExplanation_SalarySatisfaction().ToString();
                    ssCompare.Text = " < ";
                    secondss.Text = cal2.getCriteriaMark_SalarySatisfaction()[0].ToString() + " <br/> " + cal2.getCriteriaExplanation_SalarySatisfaction().ToString();
                }
                else
                {
                    firstss.Text = cal1.getCriteriaMark_SalarySatisfaction()[0].ToString() + " <br/> " + cal1.getCriteriaExplanation_SalarySatisfaction().ToString();
                    ssCompare.Text = " = ";
                    secondss.Text = cal2.getCriteriaMark_SalarySatisfaction()[0].ToString() + " <br/> " + cal2.getCriteriaExplanation_SalarySatisfaction().ToString();
                }
            }
        }

        /// <summary>
        /// Gvive the data selected index changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        protected void gvData_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculationManager cm = new CalculationManager();
            //List<Calculation> c = cm.getCalculations("joey");
            List<Calculation> c = cm.getCalculations(Session["Username"].ToString());
            Calculation ca = c[gvData.SelectedIndex];
            Session["DetailObject"] = ca;

            Response.Redirect("CalculationResult.aspx");
        }

        /// <summary>
        /// Give the data page index changing.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        protected void gvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvData.PageIndex = e.NewPageIndex;
            bindGv();
        }


    }

}
