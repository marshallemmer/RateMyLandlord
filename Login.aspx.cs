using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace ApartmentApp
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogLogin_Click(object sender, EventArgs e)
        {
            //First get the username and password
            //Will be attempting to match these up with a set of usernames and passwords in the database
            string user = txtLogUser.Text;
            string pass = txtLogPass.Text;

            //The Log In Code
            //This code initializes a connection to SQL and passes it a connection string to link visual studio to our tables
            SqlConnection MyConnection = new SqlConnection();
            //Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password = myPassword;
            MyConnection.ConnectionString = "Server=139.78.8.180,22;Database=F19_groupRoss;User Id=groupRoss;Password = ABCD123!;";
            MyConnection.Open();
            //Now that the connection is open and we are all good we can get the login info from the match we found earlier and link the User data to session variables
            string Login = "SELECT * FROM dbo.User_ID WHERE Username='" + user + "'AND Password='" + pass + "'";
            SqlCommand MySqlCommand = new SqlCommand(Login, MyConnection);
            try
            {
                //MyConnection.Open();
                SqlDataReader MyReader = MySqlCommand.ExecuteReader();
                while (MyReader.Read() && MyReader.HasRows)
                {
                    //If we are even here it means that a user matching the given credentials is in the database
                    lblLogDebug.Text = "Login Successful";
                    //Now we store all the fields in Session variables
                    //This is so we can retrieve the info for delete, update, and display in My Account
                    //For some reason the order of these is ACTUALLY IMPORTANT, no idea WHY but it is
                    Session["UserName"] = MyReader["Username"].ToString();
                    Session["UserPassword"] = MyReader["Password"].ToString();
                    Session["Email"] = MyReader["Email"].ToString();

                    Session["UserID"] = (int)MyReader["User_id"];
                    Session["FName"] = MyReader["FirstName"].ToString();
                    Session["LName"] = MyReader["LastName"].ToString();

                    Session["Properties"] = MyReader["Properties"].ToString();
                    Session["Landlords"] = MyReader["Landlords"].ToString();
                    Session["Universities"] = MyReader["Universities"].ToString();
                    Session["Town"] = MyReader["Town"].ToString();
                    Session["CreationDate"] = MyReader["CreationDate"].ToString();
                    Session["State"] = MyReader["State"].ToString();


                    //If we get to here we are logged in so set login to yes, display the label as logged in, and send them back to main
                    Session["login"] = "yes";
                    lblLogDebug.Text = "Login Sucessful";
                    Response.Redirect("PropertyReview.aspx");

                }

                if (lblLogDebug.Text != "Login Successful")
                {
                    lblLogDebug.Text = "Error: Either your username, password, or both are incorrect.";
                }

            }
            catch
            {
                lblLogDebug.Text = "An unexpected error has occured, please contact site management.";
                MyConnection.Close();

            }
        }
        protected void btnLogClear_Click(object sender, EventArgs e)
        {
            //Clear the contents of the textboxes when hit
            txtLogUser.Text = "";
            txtLogPass.Text = "";
        }
    }
}