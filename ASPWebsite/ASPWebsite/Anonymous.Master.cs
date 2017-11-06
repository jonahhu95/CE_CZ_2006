﻿using ASPWebsite.App_Code.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPWebsite
{
    public partial class Anonymous : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                lblWelcomeUser.Text = "Welcome " + Session["Username"].ToString();
                LoginLink.Visible = false;
                RegisterLink.Visible = false;
                SignOut.Visible = true;
                lblWelcomeUser.Visible = true;
                userPanel.Visible = true;
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
                Boolean t = um.createUser(tbEmail2.Text, tbPassword2.Text);
                if (t)
                {
                    Session["Username"] = tbEmail2.Text;
                    //Response.Redirect("UserPage.aspx?Username=" + tbEmail2.Text);
                    Response.Redirect(Request.RawUrl);
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

        protected void SignOut_Click(object sender, EventArgs e)
        {
            if(Session["Username"] != null)
            {
                SignOut.Visible = false;
                lblWelcomeUser.Text = null;
                LoginLink.Visible = true;
                RegisterLink.Visible = true;
                lblWelcomeUser.Visible = false;
                userPanel.Visible = false;
            }
        }

    }
}