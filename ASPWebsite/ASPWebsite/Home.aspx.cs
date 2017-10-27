using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPWebsite.App_Code.Control;

namespace ASPWebsite
{
    public partial class Home : System.Web.UI.Page
    {
        //SEService.ServiceClient se = new SEService.ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            ApiFetcher apiFetch = new ApiFetcher();
            apiFetch.getCoordinates("Evergreen Park Singapore");
        }
        protected void loginBtn_Click1(object sender, EventArgs e)
        {
            //Boolean t = se.checkUser(tbEmail.Text, tbPassword.Text);

            //if (t)
            //    Response.Redirect("UserPage.aspx?Username=" + tbEmail.Text);
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openLoginModal();", true);
            //    lblLoginWarning.Text = "Invalid username or password";
            //    tbPassword.Text = null;
            //}
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //if (tbPassword2.Text == tbConfirmPW.Text)
            //{
            //    if (se.createUserAccount(tbEmail2.Text, tbPassword2.Text))
            //    {
            //        Response.Redirect("UserPage.aspx?Username=" + tbEmail2.Text);
            //    }

            //    else
            //    {
            //        //when email exist in database
            //        //need a method here to check
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            //        LabelWarning.Text = "Username exist in database";
            //    }
                    
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            //    LabelWarning.Text = "Password does not match confirm password!";
            //    tbConfirmPW.Text = null;
            //    tbPassword2.Text = null;
            //}

        }

        protected void sendMessage_Click(object sender, EventArgs e)
        {
           // String worklocate = txt_Destination.Text;
           // String homelocate = txt_Source.Text;
           // int salary = Convert.ToInt32(txt_Salary.Text);
           // //char type;
           // int interest = Convert.ToInt32(rbInterest.SelectedValue);
           // int satisfaction = Convert.ToInt32(rbSalary.SelectedValue);


           //se.calculateJS(worklocate, homelocate, salary, 'T', interest, salary);
           // //Label9.Text = m

        }

    }
}