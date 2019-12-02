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
    public partial class WebForm11 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private string getDate()
        {
            //This method gets the current date using the DateTime system and returns it for use in creating reviews
            DateTime now = DateTime.Now;
            string date = now.ToString("yyyy-MM-dd");
            return date;
        }

        public Boolean isLLInDataBase(string Landlord, string Address, string State, string University)
        {
            //This method takes in the input to create a database, and uses it to determine if the landlord exists or not
            //This mostly exists because doing an extremely complicated task like this form is supposed to do in one method like on PropertyReview almost drove me MAD!
            //To determine if the user exists in here we basically use the same code as login only with 4 values instead of 2 for validation
            string lord = Landlord;
            string address = Address;
            string state = State;
            string uni = University;

            //This code initializes a connection to SQL and passes it a connection string to link visual studio to our tables
            SqlConnection MyConnection = new SqlConnection();
            //Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password = myPassword;
            MyConnection.ConnectionString = "Server=139.78.8.180,22;Database=F19_groupRoss;User Id=groupRoss;Password = ABCD123!;";
            MyConnection.Open();
            //Now that the connection is open and we are all good we can try and search for a match to our info
            string Login = "SELECT * FROM dbo.Landlord_ID WHERE CompanyName='" + lord + "'AND Address='" + address + "'AND State='" + State + "'AND University='" + uni + "'";
            SqlCommand MySqlCommand = new SqlCommand(Login, MyConnection);
            try
            {
                //MyConnection.Open();
                SqlDataReader MyReader = MySqlCommand.ExecuteReader();
                while (MyReader.Read() && MyReader.HasRows)
                {
                    //If we are even here it means that a user matching the given credentials is in the database
                    //We dont want to return yet though as we want to save some Session variables
                    //Honestly I am not POSITIVE I will need them but a little data harvesting never hurt anyone
                    Session["LLID"] = (int)MyReader["Landlord_id"];
                    Session["LLCompName"] = MyReader["CompanyName"].ToString();
                    Session["LLAddress"] = MyReader["Address"].ToString();
                    Session["LLUni"] = MyReader["University"].ToString();
                    MyReader.Close();
                    //Anyway we got the session variables so go aheady and return true
                    return true;
                }
                //If you got to this point the landlord isnt in the database yet so return false
                return false;
            }
            catch
            {
                //If you get to here something went VERY wrong
                lblLLRevError1.Text = "An unexpected error has occured, please contact site management.";
                MyConnection.Close();
                return false;
            }
        }

        public void createLLReview(int inLLID, int inUserID, string inReview, int inRating)
        {
            //We are making a Landlord Review a few times so we are just gonna make a single method to do it to save space
            //The method just takes in the input for a Landlord Review, IDs from a valid Landlord and User, and a review and an int rating for the company
            int LLID = inLLID;
            int UserID = inUserID;
            string review = inReview;
            int rating = inRating;
            string date = getDate();

            SqlConnection MyConnection = new SqlConnection();
            MyConnection.ConnectionString = "Server=139.78.8.180,22;Database=F19_groupRoss;User Id=groupRoss;Password = ABCD123!;";

            //Get the insert statement and select the Landlord table to work with
            string MyInsertStatement;
            MyInsertStatement = "INSERT into dbo.Landlord_Review(Landlord_id, User_id, Review, Rating, ReviewDate) VALUES(@Landlord_id, @User_id, @Review, @Rating, @ReviewDate);";
            SqlCommand MySqlCmd = new SqlCommand(MyInsertStatement, MyConnection);
            MySqlCmd.Parameters.AddWithValue("@Landlord_id", LLID);
            MySqlCmd.Parameters.AddWithValue("@User_id", UserID);
            MySqlCmd.Parameters.AddWithValue("@Review", review);
            MySqlCmd.Parameters.AddWithValue("@Rating", rating);
            MySqlCmd.Parameters.AddWithValue("@ReviewDate", date);

            //Ok begin the final add
            MyConnection.Open();
            try
            {
                int intNumberofRowsAffected;
                intNumberofRowsAffected = MySqlCmd.ExecuteNonQuery();
                MyConnection.Close();
            }
            catch
            {
                MyConnection.Close();
            }
        }

        protected void btnLLRevSubmit_Click(object sender, EventArgs e)
        {
            //This button takes the information stored in the text boxes and uses it to create a LandlordReview instance in the LandlordReview table
            //To do this the System must first determine if there if the landlord to be reviewed is already in the system
            //If the landlord IS in the system this method will grab the LandlordID of the landlord and the UserID to create the Landlord Review
            //The system will determine if it is the same landlord by seeing if the CompanyName, Address, State, and University are identical to those of an entity in the database.
            //If they are the landlord is identical to the one being entered by the user and we can create the review with landlord info stored in the database

            //Step 1: Make sure that we only continue if the rating is a num between 1 and 5
            int score = Convert.ToInt32(txtLLRevRating.Text);
            if (score <= 5 && score >= 1)
            {
                //Step 2: Determine if there is a landlord already existing in the database
                if(isLLInDataBase(txtLLRevLandlord.Text,txtLLRevAddress.Text,txtLLRevState.Text,txtLLRevUniversity.Text) == true)
                {
                    //The landlord is already in the database!
                    //Step 3: Create the Landlord Review with the information from the form and the Landlord table
                    createLLReview(Convert.ToInt32(Session["LLID"]), Convert.ToInt32(Session["UserID"]), txtLLRevReview.Text, Convert.ToInt32(txtLLRevRating.Text));
                }
                else
                {
                    //The landlord is NOT in the database!
                    //Step 4: Create a new Landlord
                    //Connection string to our database
                    SqlConnection MyConnection = new SqlConnection();
                    MyConnection.ConnectionString = "Server=139.78.8.180,22;Database=F19_groupRoss;User Id=groupRoss;Password = ABCD123!;";

                    //Get the insert statement and select the Landlord table to work with
                    string MyInsertStatement;
                    MyInsertStatement = "INSERT into dbo.Landlord_ID(CompanyName, Address, State, University) VALUES(@CompanyName, @Address, @State, @University);";
                    SqlCommand MySqlCmd = new SqlCommand(MyInsertStatement, MyConnection);
                    MySqlCmd.Parameters.AddWithValue("@CompanyName", txtLLRevLandlord.Text);
                    MySqlCmd.Parameters.AddWithValue("@Address", txtLLRevAddress.Text);
                    MySqlCmd.Parameters.AddWithValue("@State", txtLLRevState.Text);
                    MySqlCmd.Parameters.AddWithValue("@University", txtLLRevUniversity.Text);

                    //Ok begin the final add
                    MyConnection.Open();
                    try
                    {
                        int intNumberofRowsAffected;
                        intNumberofRowsAffected = MySqlCmd.ExecuteNonQuery();
                        MyConnection.Close();
                    }
                    catch
                    {
                        MyConnection.Close();
                    }

                    //Grab the LandlordID from the newly created Landlord
                    //Now we have to get back the LandlordID of the landlord we just added
                    string Login = "SELECT * FROM dbo.Landlord_ID WHERE CompanyName='" + txtLLRevLandlord.Text + "'AND Address='" + txtLLRevAddress.Text + "'AND State='" + txtLLRevState.Text + "'AND University='" + txtLLRevUniversity.Text + "'";
                    SqlCommand MySqlCommand = new SqlCommand(Login, MyConnection);
                    MyConnection.Open();
                    try
                    {
                        SqlDataReader MyReader = MySqlCommand.ExecuteReader();
                        //We already know there IS one but this method has proved to work in the past and there is only one possible target so we are just gonna use this
                        while (MyReader.Read() && MyReader.HasRows)
                        {
                            //Grab that LandlordID into a session
                            Session["LLID"] = (int)MyReader["Landlord_id"];
                        }
                        //Close the connection when you are done
                        MyConnection.Close();
                    }
                    catch
                    {
                        MyConnection.Close();
                    }

                    //Step 5: Make the LandlordReview for a brand new landlord
                    //Anyway now that there is a firm Landlord object we just made we just do it the same way we did last time
                    createLLReview(Convert.ToInt32(Session["LLID"]), Convert.ToInt32(Session["UserID"]), txtLLRevReview.Text, Convert.ToInt32(txtLLRevRating.Text));
                }

                //Redirect the user to the home page now that the table assignment is complete
                Response.Redirect("HomePage.aspx");
                
            }
            else
            {
                lblLLRevError1.Text = "Error: Rating MUST be an Int Between 1 and 5";
            }
        }
        protected void btnLLRevClear_Click(object sender, EventArgs e)
        {
            //This button does what it says on the tin and clears out all the text boxes on the page
            txtLLRevAddress.Text = "";
            txtLLRevLandlord.Text = "";
            txtLLRevRating.Text = "";
            txtLLRevReview.Text = "";
            txtLLRevState.Text = "";
            txtLLRevUniversity.Text = "";
        }
    }
}