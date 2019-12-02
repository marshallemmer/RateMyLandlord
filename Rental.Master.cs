using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ApartmentApp
{
    public partial class Apartment : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //If you are logged in the login button should instead turn into a log out button and the register button a my account button
            if (Session["login"] != null && Session["login"].ToString() == "yes")
            {
                btnNavLog.Text = "Log Out";
                btnNavRegister.Text = "My Account";
                btnNavLLReview.Visible = true;
                btnNavPropReview.Visible = true;
            }
        }

        protected void btnNavLog_Click(object sender, EventArgs e)
        {
            //If the person is logged in log them out and return them to the main menu
            //If they arent logged in, send them to the login page
            if (Session["login"] != null && Session["login"].ToString() == "yes")
            {
                Session["login"] = "no";
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnNavRegister_Click(object sender, EventArgs e)
        {
            //If the user is logged in take them to the my account page, if they arent logged in take them to the register page
            if (Session["login"] != null && Session["login"].ToString() == "yes")
            {
                Response.Redirect("MyAccount.aspx");
            }
            else
            {
                Response.Redirect("Register.aspx");
            }
        }

        protected void btnNavPropReview_Click(object sender, EventArgs e)
        {
            Response.Redirect("PropertyReview.aspx");
        }

        protected void btnNavLLReview_Click(object sender, EventArgs e)
        {
            Response.Redirect("LandlordReviewForm.aspx");
        }

        protected void btnNavSubmit_Click(object sender, EventArgs e)
        {
            //Because of sillyness we are going to just PUT the text in here in the new search box to make it easier on us for now
            //We can upgrade it later
            Session["Search"] = txtNavSearch.Text;
            Response.Redirect("Search.aspx");
        }
    }
}