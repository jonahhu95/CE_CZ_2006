using ASPWebsite.App_Code.Control;
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
        UserManager um = new UserManager();

        /// <summary>
        /// Load the page
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
            if (Session["Username"] != null)
            {
                //lblWelcomeUser.Text = "Welcome " + Session["Username"].ToString();
                LoginLink.Visible = false;
                RegisterLink.Visible = false;
                SignOut.Visible = true;
                //lblWelcomeUser.Visible = true;
                userPanel.Visible = true;
                lblUsername.Text = Session["Username"].ToString();
                if (um.getUserHomeLocation(Session["Username"].ToString()) != null) { lblHome.Text = "LIVES AT " + um.getUserHomeLocation(Session["Username"].ToString()) + " "; }

                btnMenuClick.Visible = true;

            }
        }

        /// <summary>
        /// Button login click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        protected void loginBtn_Click1(object sender, EventArgs e)
        {

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

        /// <summary>
        /// Button1 create account click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
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

        /// <summary>
        /// Button Sign out click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        protected void SignOut_Click(object sender, EventArgs e)
        {

            if (Session["Username"] != null)
            {
                SignOut.Visible = false;
                //lblWelcomeUser.Text = null;
                LoginLink.Visible = true;
                RegisterLink.Visible = true;
                //lblWelcomeUser.Visible = false;
                userPanel.Visible = false;
                btnMenuClick.Visible = false;

                Session["Username"] = null;
                Response.Redirect("HomePage.aspx");
            }
        }

        /// <summary>
        /// Buttons change home click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        protected void btnChangeHome_Click(object sender, EventArgs e)
        {
            tbHome.Visible = true;
            lblHome.Visible = false;
            btnChangeHome.Visible = false;
            btnSaveHome.Visible = true;
            btnCancel.Visible = true;
        }

        /// <summary>
        /// Buttons save home click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        protected void btnSaveHome_Click(object sender, EventArgs e)
        {
            string locate;
            CalculationManager cm = new CalculationManager();
            try
            {
                bool addValid = false;
                addValid = (tbHome.Text).Length != 0;
                if (addValid)
                {
                    locate = tbHome.Text;
                    addValid = cm.checkAddressValid(locate);

                    if (!addValid)
                    {
                        MessageBox.Show(Page, "Please enter a valid Singapore Address");
                        return;
                    }
                    else
                    {
                        string loc = tbHome.Text;
                        um.saveUserHomeLocation(Session["Username"].ToString(), loc);
                        btnCancel.Visible = false;
                        tbHome.Visible = false;
                        lblHome.Visible = true;
                        btnChangeHome.Visible = true;
                        btnSaveHome.Visible = false;

                        lblHome.Text = "LIVES AT " + um.getUserHomeLocation(Session["Username"].ToString()) + " ";
                        Response.Redirect(Request.UrlReferrer.ToString());
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// Buttons cancel click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showProfileModal();", true);
            btnCancel.Visible = false;
            tbHome.Visible = false;
            lblHome.Visible = true;
            btnChangeHome.Visible = true;
            btnSaveHome.Visible = false;

        }

    }
}