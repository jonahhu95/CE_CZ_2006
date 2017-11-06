using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPWebsite.App_Code.Control;
using ASPWebsite.App_Code.Entity;
namespace ASPWebsite
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        
        protected void sendMessage_Click(object sender, EventArgs e)
        {
            String worklocate;
            String homelocate;
            int salary;
            //char type;=
            int interest = Convert.ToInt32(rbInterest.SelectedValue);
            int satisfaction = Convert.ToInt32(rbSalary.SelectedValue);
            try
            {
                worklocate = txt_Destination.Text;
                homelocate = txt_Source.Text;
                salary = Convert.ToInt32(txt_Salary.Text);
                //char type;
                interest = Convert.ToInt32(rbInterest.SelectedValue);
                satisfaction = Convert.ToInt32(rbSalary.SelectedValue);

                //createNewCalculation(String workLocation, String homeLocation,
                //    int salary, char commuteType, int jobInterest, int salarySatisfaction)
                CalculationManager cm = new CalculationManager();
                Calculation s = cm.createNewCalculation(worklocate, homelocate, salary, 'F', interest, satisfaction);
                Session["CalculationJSIObject"] = s;
                Response.Redirect("CalculationResult.aspx");
            }
            catch (Exception ex)
            {
                //error in input

            }
        }

    }
}