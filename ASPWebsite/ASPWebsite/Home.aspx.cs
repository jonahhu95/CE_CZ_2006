using System;
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

        protected void sendMessage_Click(object sender, EventArgs e)
        {
            Label1.Text = se.hellothere();
        }

        protected void loginBtn_Click1(object sender, EventArgs e)
        {
            Boolean t = se.checkUser(tbEmail.Text, tbPassword.Text);
            Label1.Text = t.ToString();

            if (t)
                Response.Redirect("Try.aspx");
        }

    }
}