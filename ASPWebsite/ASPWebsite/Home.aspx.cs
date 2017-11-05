﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPWebsite.App_Code.Control;
using ASPWebsite.App_Code.Entity;

namespace ASPWebsite
{
    public partial class Home : System.Web.UI.Page
    {
        //SEService.ServiceClient se = new SEService.ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            //ApiManager apiFetch = new ApiManager();
            //apiFetch.getCoordinates("Evergreen Park Singapore");
            //DatabaseManager dbManager = new DatabaseManager();
            //dbManager.getArea();
            //UserManager userManager = new UserManager();
            //userManager.createUser("qingyao", "lala");
            //AddressManager adManager = new AddressManager();
            //userManager.saveUserHomeLocation("qingyao", "NTU HALL OF RESIDENCE 16");
            //string ret = userManager.getUserHomeLocation("qingyao");

            //Boolean bo = userManager.loginUser("qingyao", "lala");

        }
        protected void loginBtn_Click1(object sender, EventArgs e)
        {
            UserManager um = new UserManager();
            Boolean t = um.loginUser(tbEmail.Text, tbPassword.Text);

            if (t)
                Response.Redirect("UserPage.aspx?Username=" + tbEmail.Text);
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
                    Response.Redirect("UserPage.aspx?Username=" + tbEmail2.Text);
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
            //char type;
<<<<<<< HEAD
            int interest = Convert.ToInt32(rbInterest.SelectedValue);
            int satisfaction = Convert.ToInt32(rbSalary.SelectedValue);
            
            CalculationManager cm = new CalculationManager();
           Calculation s = cm.createNewCalculation(worklocate, homelocate, salary, 'F', interest, satisfaction);
           Session["CalculationJSIObject"] = s;
           Response.Redirect("Result.aspx");
=======
            int interest;
            int satisfaction;
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
            catch(Exception ex){
                //error in input

            }
>>>>>>> a13a9fde8af62f4610b94a223b196ab2fdd05e53
        }
         
    }
}