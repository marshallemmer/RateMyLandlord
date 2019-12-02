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
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Update the page banner to show the user's name so they feel more welcome
            lblAccountBanner.Text = "Welcome Back " + Session["FName"].ToString() + "!";

            //Do if not post back to prevent our changes form being overriden each time a button is clicked
            if (!IsPostBack)
            {
                //Use Session you initialized during login to set the base values of the My Account
                txtAcctEmail.Text = (string)Session["Email"];
                txtAcctFirstName.Text = (string)Session["FName"];
                txtAcctLastName.Text = (string)Session["LName"];
                txtAcctPass1.Text = (string)Session["UserPassword"];
                txtAcctPass2.Text = (string)Session["UserPassword"];
                txtAcctState.Text = (string)Session["State"];
                txtAcctTown.Text = (string)Session["Town"];
                txtAcctUniversity.Text = (string)Session["Universities"];


            }
        }

        protected void btnAcctUpdate_Click(object sender, EventArgs e)
        {
            //This unit's job is to update the database of the specified user with the info in the text boxes
            //Make sure the password fields are the same
            if (txtAcctPass1.Text == txtAcctPass2.Text)
            {
                lblAcctDebug.Text = "";

                SqlConnection MyConnection = new SqlConnection();
                MyConnection.ConnectionString = "Server=139.78.8.180,22;Database=F19_groupRoss;User Id=groupRoss;Password = ABCD123!;";
                string MyUpdateStatement;

                //MyUpdateStatement = "UPDATE dbo.User_id(Username, Email, Password, FirstName, LastName, Properties, Landlords, Universities, Town, CreationDate, State) VALUES(@Username, @Email, @Password, @FirstName, @LastName, @Properties, @Landlords, @Universities, @Town, @CreationDate, @State) " + "WHERE User_id=@User_id;";



                //This time lets try an update with literally EVERY field
                MyUpdateStatement = "UPDATE dbo.User_ID SET Username=@Username,Email=@Email,Password=@Password,FirstName=@FirstName,LastName=@LastName,Properties=@Properties,Landlords=@Landlords,Universities=@Universities,Town=@Town,CreationDate=@CreationDate,State=@State " + "Where User_id=@User_id;";

                SqlCommand MySqlCmd = new SqlCommand(MyUpdateStatement, MyConnection);

                //These are the values we will be overriding the database with
                //For the fields we DONT want to override with user data we use the data stored in Session Variables we got when the users logged in.
                //We also WILL do this in the EXACT same order as they are assigned in the databse just. in. case.

                MySqlCmd.Parameters.AddWithValue("@User_id", (int)Session["UserID"]);
                MySqlCmd.Parameters.AddWithValue("@Username", (string)Session["UserName"]);
                MySqlCmd.Parameters.AddWithValue("@Email", txtAcctEmail.Text);
                MySqlCmd.Parameters.AddWithValue("@Password", txtAcctPass1.Text);
                MySqlCmd.Parameters.AddWithValue("@FirstName", txtAcctFirstName.Text);
                MySqlCmd.Parameters.AddWithValue("@LastName", txtAcctLastName.Text);
                MySqlCmd.Parameters.AddWithValue("@Properties", (string)Session["Properties"]);
                MySqlCmd.Parameters.AddWithValue("@Landlords", (string)Session["Landlords"]);
                MySqlCmd.Parameters.AddWithValue("@Universities", txtAcctUniversity.Text);
                MySqlCmd.Parameters.AddWithValue("@Town", txtAcctTown.Text);
                MySqlCmd.Parameters.AddWithValue("@CreationDate", (string)Session["CreationDate"]);
                MySqlCmd.Parameters.AddWithValue("@State", txtAcctState.Text);

                //This also means we WILL have to go and update and changed data stored in session variables which we will do below
                Session["Email"] = txtAcctEmail.Text;
                Session["FName"] = txtAcctFirstName.Text;
                Session["LName"] = txtAcctLastName.Text;
                Session["UserPassword"] = txtAcctPass1.Text;
                Session["State"] = txtAcctState.Text;
                Session["Town"] = txtAcctTown.Text;
                Session["Universities"] = txtAcctUniversity.Text;

                //Open the connection
                MyConnection.Open();

                //Now check to see if everything worked
                try
                {
                    int numRowsAffected;

                    numRowsAffected = MySqlCmd.ExecuteNonQuery();
                    if (numRowsAffected == 1)
                    {
                        lblAcctDebug.Text = "Profile Update Sucessful";
                    }
                    else
                    {
                        lblAcctDebug.Text = "Error: Profile Update Failed";
                    }
                    MyConnection.Close();
                }
                catch
                {
                    MyConnection.Close();
                }

            }
            else
            {
                lblAcctDebug.Text = "Error: Please ensure the text in the new password and password confirmation boxes are identical";
            }
        }
    }
}