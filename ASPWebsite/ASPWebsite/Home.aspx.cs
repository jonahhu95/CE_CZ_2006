﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPWebsite
{
    public partial class Home : System.Web.UI.Page
    {
        SEService.ServiceClient se = new SEService.ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void loginBtn_Click1(object sender, EventArgs e)
        {
            Boolean t = se.checkUser(tbEmail.Text, tbPassword.Text);

            if (t)
                Response.Redirect("UserPage.aspx?Username=" + tbEmail.Text);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (tbPassword2.Text == tbConfirmPW.Text)
            {
                if (se.createUserAccount(tbEmail2.Text, tbPassword2.Text))
                    Response.Redirect("UserPage.aspx?Username=" + tbEmail2.Text);
                else
                    //when email exist in database
                    //need a method here to check
                    LabelWarning.Text = "Username exist in database";
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