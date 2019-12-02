using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace ApartmentApp
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string date = now.ToString("yyyy-MM-dd");
            lblRegDate.Text = date;
        }

        protected void btnRegSubmit_Click(object sender, EventArgs e)
        {
            //This method will be responsible for the creation of the account
            //We will get the value of the creation date from the date label we set up in the page load

            //It also will not let you create an account if a username is already taken
            if(accountExists(txtRegUser.Text) == true)
            {
                //if we are here that means an account with the same username as something in the database exists
                //tell the users such and prompt them to try again
                lblRegDebug1.Text = "An account with the given username already exists please enter another";
            }
            else
            {
                //First link into the database
                SqlConnection MyConnection = new SqlConnection();
                MyConnection.ConnectionString = "Server=139.78.8.180,22;Database=F19_groupRoss;User Id=groupRoss;Password = ABCD123!;";

                //Get the insert statement and select the UserProfile table to work with
                string MyInsertStatement;
                //Leave out UserID as it is auto handled by the system
                //MyInsertStatement = "INSERT into dbo.UserProfile(FName, LName, Email, PhoneNum, CompanyName, JobTitle, DepartmentName, PID, RangeID, BoolNewsletter, UserName, UserPassword) VALUES(@FName, @LName, @Email, @PhoneNum, @CompanyName, @JobTitle, @DepartmentName, @PID, @RangeID, @BoolNewsletter, @UserName, @UserPassword);";
                MyInsertStatement = "INSERT into dbo.User_ID(Username, Email, Password, FirstName, LastName, Properties, Landlords, Universities, Town, CreationDate, State) VALUES(@Username, @Email, @Password, @FirstName, @LastName, @Properties, @Landlords, @Universities, @Town, @CreationDate, @State);";
                SqlCommand MySqlCmd = new SqlCommand(MyInsertStatement, MyConnection);

                //MySqlCmd.Parameters.AddWithValue("@User_id", 4);
                MySqlCmd.Parameters.AddWithValue("@Username", txtRegUser.Text);
                MySqlCmd.Parameters.AddWithValue("@Email", txtRegEmail.Text);
                MySqlCmd.Parameters.AddWithValue("@Password", txtRegPass1.Text);
                MySqlCmd.Parameters.AddWithValue("@FirstName", txtRegFirstName.Text);
                MySqlCmd.Parameters.AddWithValue("@LastName", txtRegLastName.Text);
                MySqlCmd.Parameters.AddWithValue("@Properties", "None");
                MySqlCmd.Parameters.AddWithValue("@Landlords", "None");
                MySqlCmd.Parameters.AddWithValue("@Universities", txtRegUniversity.Text);
                MySqlCmd.Parameters.AddWithValue("@Town", txtRegTown.Text);
                MySqlCmd.Parameters.AddWithValue("@CreationDate", lblRegDate.Text);
                MySqlCmd.Parameters.AddWithValue("@State", txtRegState.Text);

                MyConnection.Open();

                //Ok begin the final add
                try
                {
                    int intNumberofRowsAffected;
                    intNumberofRowsAffected = MySqlCmd.ExecuteNonQuery();
                    MyConnection.Close();

                    //Congratulations if you got this far and the code ISNT on fire you are registered

                    Session["login"] = "no";
                    //Send user to the Login Screen
                    //Has to be login so we can get the session variables
                    Response.Redirect("Login.aspx");
                }
                //Catch the error
                //If things go wrong report it
                catch
                {
                    MyConnection.Close();
                    lblRegDebug1.Text = "Error: Data was not sucessfully passed to Database";
                }
            }
        }

        protected void btnRegClear_Click(object sender, EventArgs e)
        {
            txtRegEmail.Text = "";
            txtRegFirstName.Text = "";
            txtRegLastName.Text = "";
            txtRegPass1.Text = "";
            txtRegPass2.Text = "";
            txtRegState.Text = "";
            txtRegTown.Text = "";
            txtRegUniversity.Text = "";
            txtRegUser.Text = "";
        }

        private Boolean accountExists(string userName)
        {
            //This method will take in the login credentials and determine if the user already exists in the system.
            //if the user does not exist in the system the method returns false
            //if they do it means the username is taken and a new one must be selected
            string name = userName;

            //This code initializes a connection to SQL and passes it a connection string to link visual studio to our tables
            SqlConnection MyConnection = new SqlConnection();
            //Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password = myPassword;
            MyConnection.ConnectionString = "Server=139.78.8.180,22;Database=F19_groupRoss;User Id=groupRoss;Password = ABCD123!;";
            MyConnection.Open();
            //Now that the connection is open and we are all good we can try and search for a match to our info
            string Login = "SELECT * FROM dbo.User_ID WHERE Username='" + name + "'";
            SqlCommand MySqlCommand = new SqlCommand(Login, MyConnection);
            try
            {
                //MyConnection.Open();
                SqlDataReader MyReader = MySqlCommand.ExecuteReader();
                while (MyReader.Read() && MyReader.HasRows)
                {
                    //If we are even here it means that a user matching the given credentials is in the database
                    MyReader.Close();
                    return true;
                }
                //If you got to this point the landlord isnt in the database yet so return false
                MyReader.Close();
                MyConnection.Close();
                return false;
            }
            catch
            {
                //If you get to here something went VERY wrong
                lblRegDebug1.Text = "An unexpected error has occured, please contact site management.";
                MyConnection.Close();
                return true;
            }

        }
    }
}