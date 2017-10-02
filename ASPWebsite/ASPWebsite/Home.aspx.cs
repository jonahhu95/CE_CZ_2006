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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sendMessage_Click(object sender, EventArgs e)
        {
            SEService.ServiceClient se = new SEService.ServiceClient();
            Label1.Text = se.hellothere();
            
        }

    }
}