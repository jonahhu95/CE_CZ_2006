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
            int interest;
            int satisfaction;
            CalculationManager cm = new CalculationManager();
            try
            {
                bool workAddValid = false, homeAddValid = false, salaryValid = false;
                workAddValid = (txt_Destination.Text).Length != 0;
                homeAddValid = (txt_Source.Text).Length != 0;
                salaryValid = int.TryParse(txt_Salary.Text, out salary);
                //value is passed into salary if int.TryParse return true
                
                if (workAddValid && homeAddValid)
                {
                    worklocate = txt_Destination.Text;
                    homelocate = txt_Source.Text;

                    workAddValid = cm.checkAddressValid(worklocate);
                    homeAddValid = cm.checkAddressValid(homelocate);

                    if (!workAddValid && !homeAddValid)
                        MessageBox.Show(Page, "Please enter a valid work and home address in Singapore");
                    else if (!workAddValid)
                        MessageBox.Show(Page, "Please enter a valid work address in Singapore");
                    else if (!homeAddValid)
                        MessageBox.Show(Page, "Please enter a valid home address in Singapore");

                    if (!workAddValid || !homeAddValid)
                        return;
                }
                else
                {
                    if (!workAddValid && !homeAddValid)
                        MessageBox.Show(Page, "Please enter a valid work and home address");
                    else if (!workAddValid)
                        MessageBox.Show(Page, "Please enter a valid work address");
                    else if (!homeAddValid)
                        MessageBox.Show(Page, "Please enter a valid home address");
                    return;
                }
                if (!salaryValid)
                {
                    MessageBox.Show(Page, "Please enter a valid salary value");
                    return;
                }

                interest = Convert.ToInt32(rbInterest.SelectedValue);
                satisfaction = Convert.ToInt32(rbSalary.SelectedValue);
                
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
    public static class MessageBox
    {
        public static void Show(this Page Page, String Message)
        {
            Page.ClientScript.RegisterStartupScript(
               Page.GetType(),
               "MessageBox",
               "<script language='javascript'>alert('" + Message + "');</script>"
            );
        }
    }
}