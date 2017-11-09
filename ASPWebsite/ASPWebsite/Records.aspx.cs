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
        List<Calculation> cal = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGridData();
            }

            compareRecords();
        }
        protected void BindGridData()
        {
            CalculationManager cm = new CalculationManager();
            List<Calculation> c = cm.getCalculations("joey");
            //List<Calculation> c = cm.getCalculations(Session["Username"].ToString());
            gvData.DataSource = c;
            gvData.DataBind();
        }

        protected void compareRecords()
        {
            int salaryRating = 0;
            int salaryRatingRow = 0;

            int jobRating = 0;
            int jobRatingRow = 0;

            double JSI = 0;
            int JSIRow = 0;

            double JSIe = 0;
            int JSIRowe = 0;
            foreach (GridViewRow row in gvData.Rows)
            {
                if (Convert.ToInt32(row.Cells[2].Text) >= salaryRating && Convert.ToDouble(row.Cells[4].Text) >= JSIe)
                {
                    JSIe = Convert.ToDouble(row.Cells[4].Text);
                    salaryRating = Convert.ToInt32(row.Cells[2].Text);
                    salaryRatingRow = row.RowIndex;
                }
                if (Convert.ToInt32(row.Cells[3].Text) >= jobRating && Convert.ToDouble(row.Cells[4].Text) >= JSIe)
                {
                    JSIe = Convert.ToDouble(row.Cells[4].Text);
                    jobRating = Convert.ToInt32(row.Cells[3].Text);
                    jobRatingRow = row.RowIndex;
                }
                if (Convert.ToDouble(row.Cells[4].Text) >= JSI)
                {
                    JSI = Convert.ToDouble(row.Cells[4].Text);
                    JSIRow = row.RowIndex;
                }
                if (Convert.ToDouble(row.Cells[4].Text) >= JSIe)
                {
                    JSIe = Convert.ToDouble(row.Cells[4].Text);
                    JSIRowe = row.RowIndex;
                }
            }

            var sr = this.gvData.Rows[salaryRatingRow];
            sr.Cells[5].Text = "Yes!";

            var jr = this.gvData.Rows[jobRatingRow];
            jr.Cells[6].Text = "Yes!";

            var jsir = this.gvData.Rows[JSIRow];
            jsir.Cells[7].Text = "Yes!";

            //check for duplicate
            foreach (GridViewRow dup in gvData.Rows)
            {
                if (dup.Cells[2].Text == salaryRating.ToString() && dup.Cells[3].Text == jobRating.ToString() && dup.Cells[4].Text == JSI.ToString())
                {
                    if (dup.Cells[5].Text == "&nbsp;" && dup.Cells[6].Text == "&nbsp;" && dup.Cells[7].Text == "&nbsp;")
                    {
                        dup.Cells[5].Text = "Yes!";
                        dup.Cells[6].Text = "Yes!";
                        dup.Cells[7].Text = "Yes!";
                    }

                }
            }
        }

        protected void btnCompare_Click(object sender, EventArgs e)
        {
            CalculationManager cm = new CalculationManager();
            List<Calculation> c = cm.getCalculations("joey");
            //List<Calculation> c = cm.getCalculations(Session["Username"].ToString());

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

            if (cal1.getCriteriaMark_CommuteComfort()[0] > cal2.getCriteriaMark_CommuteComfort()[0])
            {
                firstcco.Text = cal1.getCriteriaMark_CommuteComfort()[0].ToString();
                ccoCompare.Text = " > ";
                secondcco.Text = cal2.getCriteriaMark_CommuteComfort()[0].ToString();
            }
            else if (cal1.getCriteriaMark_CommuteComfort()[0] < cal2.getCriteriaMark_CommuteComfort()[0])
            {
                firstcco.Text = cal1.getCriteriaMark_CommuteComfort()[0].ToString();
                ccoCompare.Text = " < ";
                secondcco.Text = cal2.getCriteriaMark_CommuteComfort()[0].ToString();
            }
            else
            {
                firstcco.Text = cal1.getCriteriaMark_CommuteComfort()[0].ToString();
                ccoCompare.Text = " = ";
                secondcco.Text = cal2.getCriteriaMark_CommuteComfort()[0].ToString();
            }

            if (cal1.getCriteriaMark_CommuteCost()[0] > cal2.getCriteriaMark_CommuteCost()[0])
            {
                firstcc.Text = cal1.getCriteriaMark_CommuteCost()[0].ToString();
                ccCompare.Text = " > ";
                secondcc.Text = cal2.getCriteriaMark_CommuteCost()[0].ToString();
            }
            else if (cal1.getCriteriaMark_CommuteCost()[0] < cal2.getCriteriaMark_CommuteCost()[0])
            {
                firstcc.Text = cal1.getCriteriaMark_CommuteCost()[0].ToString();
                ccCompare.Text = " < ";
                secondcc.Text = cal2.getCriteriaMark_CommuteCost()[0].ToString();
            }
            else
            {
                firstcc.Text = cal1.getCriteriaMark_CommuteCost()[0].ToString();
                ccCompare.Text = " = ";
                secondcc.Text = cal2.getCriteriaMark_CommuteCost()[0].ToString();
            }

            if (cal1.getCriteriaMark_CommuteTime()[0] > cal2.getCriteriaMark_CommuteTime()[0])
            {
                firstct.Text = cal1.getCriteriaMark_CommuteTime()[0].ToString();
                ctCompare.Text = " > ";
                secondct.Text = cal2.getCriteriaMark_CommuteTime()[0].ToString();
            }
            else if (cal1.getCriteriaMark_CommuteTime()[0] < cal2.getCriteriaMark_CommuteTime()[0])
            {
                firstct.Text = cal1.getCriteriaMark_CommuteTime()[0].ToString();
                ctCompare.Text = " < ";
                secondct.Text = cal2.getCriteriaMark_CommuteTime()[0].ToString();
            }
            else
            {
                firstct.Text = cal1.getCriteriaMark_CommuteTime()[0].ToString();
                ctCompare.Text = " = ";
                secondct.Text = cal2.getCriteriaMark_CommuteTime()[0].ToString();
            }

            if (cal1.getCriteriaMark_JobInterest()[0] > cal2.getCriteriaMark_JobInterest()[0])
            {
                firstji.Text = cal1.getCriteriaMark_JobInterest()[0].ToString();
                jiCompare.Text = " > ";
                secondji.Text = cal2.getCriteriaMark_JobInterest()[0].ToString();
            }
            else if (cal1.getCriteriaMark_JobInterest()[0] < cal2.getCriteriaMark_JobInterest()[0])
            {
                firstji.Text = cal1.getCriteriaMark_JobInterest()[0].ToString();
                jiCompare.Text = " < ";
                secondji.Text = cal2.getCriteriaMark_JobInterest()[0].ToString();
            }
            else
            {
                firstji.Text = cal1.getCriteriaMark_JobInterest()[0].ToString();
                jiCompare.Text = " = ";
                secondji.Text = cal2.getCriteriaMark_JobInterest()[0].ToString();
            }

            if (cal1.getCriteriaMark_Salary()[0] > cal2.getCriteriaMark_Salary()[0])
            {
                firstms.Text = cal1.getCriteriaMark_Salary()[0].ToString();
                msCompare.Text = " > ";
                secondms.Text = cal2.getCriteriaMark_Salary()[0].ToString();
            }
            else if (cal1.getCriteriaMark_Salary()[0] < cal2.getCriteriaMark_Salary()[0])
            {
                firstms.Text = cal1.getCriteriaMark_Salary()[0].ToString();
                msCompare.Text = " < ";
                secondms.Text = cal2.getCriteriaMark_Salary()[0].ToString();
            }
            else
            {
                firstms.Text = cal1.getCriteriaMark_Salary()[0].ToString();
                msCompare.Text = " = ";
                secondms.Text = cal2.getCriteriaMark_Salary()[0].ToString();
            }

            if (cal1.getCriteriaMark_SalarySatisfaction()[0] > cal2.getCriteriaMark_SalarySatisfaction()[0])
            {
                firstss.Text = cal1.getCriteriaMark_SalarySatisfaction()[0].ToString();
                ssCompare.Text = " > ";
                secondss.Text = cal2.getCriteriaMark_SalarySatisfaction()[0].ToString();
            }
            else if (cal1.getCriteriaMark_SalarySatisfaction()[0] < cal2.getCriteriaMark_SalarySatisfaction()[0])
            {
                firstss.Text = cal1.getCriteriaMark_SalarySatisfaction()[0].ToString();
                ssCompare.Text = " < ";
                secondss.Text = cal2.getCriteriaMark_SalarySatisfaction()[0].ToString();
            }
            else
            {
                firstss.Text = cal1.getCriteriaMark_SalarySatisfaction()[0].ToString();
                ssCompare.Text = " = ";
                secondss.Text = cal2.getCriteriaMark_SalarySatisfaction()[0].ToString();
            }
           
        }

    }

}
