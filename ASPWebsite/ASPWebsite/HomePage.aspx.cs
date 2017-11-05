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
            if (Session["Username"] != null)
            {
                lblWelcomeUser.Text = "Welcome " + Session["Username"].ToString();
                LoginLink.Visible = false;
                RegisterLink.Visible = false;
                SignOutLink.Visible = true;
                lblWelcomeUser.Visible = true;
            }
        }

        protected void loginBtn_Click1(object sender, EventArgs e)
        {
            UserManager um = new UserManager();
            Boolean t = um.loginUser(tbEmail.Text, tbPassword.Text);

            if (t)
            {
                Session["Username"] = tbEmail.Text;
                Response.Redirect(Request.RawUrl);
                //Response.Redirect("HomePage.aspx?Username=" + tbEmail.Text);
            }
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
                    Session["Username"] = tbEmail2.Text;
                    //Response.Redirect("UserPage.aspx?Username=" + tbEmail2.Text);
                    Response.Redirect("UserPage.aspx");
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
                Response.Redirect("Result.aspx");
            }
            catch (Exception ex)
            {
                //error in input

            }
        }

    }
}