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
    public partial class WebForm10 : System.Web.UI.Page
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
                lblPropRevError1.Text = "An unexpected error has occured, please contact site management.";
                MyConnection.Close();
                return false;
            }
        }

        public Boolean isPropInDataBase(string Address, string City, string State, string University, int LanID)
        {
            //This method takes in the input and uses it to determine if the property exists or not
            //Bring in varibles
            string address = Address;
            string city = City;
            string state = State;
            string uni = University;
            int lanID = LanID;

            //This code initializes a connection to SQL and passes it a connection string to link visual studio to our tables
            SqlConnection MyConnection = new SqlConnection();
            //Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password = myPassword;
            MyConnection.ConnectionString = "Server=139.78.8.180,22;Database=F19_groupRoss;User Id=groupRoss;Password = ABCD123!;";
            MyConnection.Open();
            //Now that the connection is open and we are all good we can try and search for a match to our info
            string Login = "SELECT * FROM dbo.Property_ID WHERE Address='" + address + "'AND City='" + city + "'AND State='" + State + "'AND University='" + uni + "'AND Landlord_id='" + lanID + "'";
            SqlCommand MySqlCommand = new SqlCommand(Login, MyConnection);
            try
            {
                //MyConnection.Open();
                SqlDataReader MyReader = MySqlCommand.ExecuteReader();
                while (MyReader.Read() && MyReader.HasRows)
                {
                    //If we are even here it means that a user matching the given credentials is in the database
                    //We wont do any data collection here as that seems to cause things to explode for SOME reason
                    //Session["PropID"] = (int)MyReader["Landlord_id"];
                    //Session["PropCompName"] = MyReader["CompanyName"].ToString();
                    //Session["PropAddress"] = MyReader["Address"].ToString();
                    //Session["PropUni"] = MyReader["University"].ToString();

                    MyReader.Close();
                    //Anyway we got the session variables so go aheady and return true
                    lblPropRevError1.Text = "isPropInDataBase worked fine";
                    return true;
                }
                //If you got to this point the landlord isnt in the database yet so return false
                return false;
            }
            catch
            {
                //If you get to here something went VERY wrong
                lblPropRevError1.Text = "There was an error in isPropInDatabase";
                MyConnection.Close();
                return false;
            }
        }

        private int getPropID(string Address, string City, string State, string University, int LanID)
        {
            //This method takes in input and returns the prop ID of the property with the matching input
            //It returns a 0 in the event something went horribly wrong
            //Bring in varibles
            string address = Address;
            string city = City;
            string state = State;
            string uni = University;
            int lanID = LanID;

            int id = 0;
            SqlConnection MyConnection = new SqlConnection();
            MyConnection.ConnectionString = "Server=139.78.8.180,22;Database=F19_groupRoss;User Id=groupRoss;Password = ABCD123!;";

            string Login = "SELECT * FROM dbo.Property_ID WHERE Address='" + address + "'AND City='" + city + "'AND State='" + state + "'AND University='" + uni + "'AND Landlord_id='" + lanID + "'";
            SqlCommand MySqlCommand = new SqlCommand(Login, MyConnection);
            MyConnection.Open();
            try
            {
                SqlDataReader MyReader = MySqlCommand.ExecuteReader();
                while (MyReader.Read() && MyReader.HasRows)
                {
                    //If we are in here there is a match
                    //Get the Property ID out and set it to id for return
                    Session["PropID"] = (int)MyReader["Property_id"];
                    id = (int)MyReader["Property_id"];
                }
                //Close the connection when you are done
                MyConnection.Close();
                return id;
            }
            catch
            {
                //Well something went wrong... great...
                MyConnection.Close();
                return id;
            }
        }

        private int getLandID(string CName, string Add, string State, string Uni)
        {
            //This method returns the landlord ID of an existing landlord in the database
            //It returns 0 in the event something went horribly wrong

            string compName = CName;
            string address = Add;
            string state = State;
            string uni = Uni;


            int id = 0;
            SqlConnection MyConnection = new SqlConnection();
            MyConnection.ConnectionString = "Server=139.78.8.180,22;Database=F19_groupRoss;User Id=groupRoss;Password = ABCD123!;";

            string Login = "SELECT * FROM dbo.Landlord_ID WHERE CompanyName='" + compName + "'AND Address='" + address + "'AND State='" + state + "'AND University='" + uni + "'";
            SqlCommand MySqlCommand = new SqlCommand(Login, MyConnection);
            MyConnection.Open();
            try
            {
                SqlDataReader MyReader = MySqlCommand.ExecuteReader();
                while (MyReader.Read() && MyReader.HasRows)
                {
                    Session["LandlordID"] = (int)MyReader["Landlord_id"];
                    id = (int)MyReader["Landlord_id"];
                }
                //Close the connection when you are done
                MyConnection.Close();
                return id;
            }
            catch
            {
                MyConnection.Close();
                return id;
            }
        }

        private void createLandlord(string CompName, string Address, string State, string University)
        {
            //This method takes in input from the property form and uses it to create a new landlord
            string companyName = CompName;
            string address = Address;
            string state = State;
            string uni = University;
            //To begin we will start with the landlord
            SqlConnection MyConnection = new SqlConnection();
            MyConnection.ConnectionString = "Server=139.78.8.180,22;Database=F19_groupRoss;User Id=groupRoss;Password = ABCD123!;";

            //Get the insert statement and select the Landlord table to work with
            string MyInsertStatement;
            MyInsertStatement = "INSERT into dbo.Landlord_ID(CompanyName, Address, State, University) VALUES(@CompanyName, @Address, @State, @University);";
            SqlCommand MySqlCmd = new SqlCommand(MyInsertStatement, MyConnection);
            MySqlCmd.Parameters.AddWithValue("@CompanyName", companyName);
            MySqlCmd.Parameters.AddWithValue("@Address", address);
            MySqlCmd.Parameters.AddWithValue("@State", state);
            MySqlCmd.Parameters.AddWithValue("@University", uni);

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

        private void createProperty(string Add, string City, string State, string Uni, string Landlord, int LandID)
        {
            //This method takes information passed to it and creates a property with it so long as an identical one doesnt already exist within the database
            //Pass in Variables
            string address = Add;
            string city = City;
            string state = State;
            string uni = Uni;
            string landlord = Landlord;
            int landID = LandID;
            //Now determine if the property already exists in the database
            //We will define exist as something with an identical address, city, state, uni, landlord, and landID

            //Get our insert statements
            SqlConnection MyConnection = new SqlConnection();
            MyConnection.ConnectionString = "Server=139.78.8.180,22;Database=F19_groupRoss;User Id=groupRoss;Password = ABCD123!;";
            string MyInsertStatement;
            MyInsertStatement = "INSERT into dbo.Property_ID(Address, City, State, University, Landlord, Landlord_id) VALUES(@Address, @City, @State, @University, @Landlord, @Landlord_id);";
            SqlCommand MySqlCmd = new SqlCommand(MyInsertStatement, MyConnection);
            MySqlCmd = new SqlCommand(MyInsertStatement, MyConnection);
            MySqlCmd.Parameters.AddWithValue("@Address", txtPropRevAddress.Text);
            MySqlCmd.Parameters.AddWithValue("@City", txtPropRevCity.Text);
            MySqlCmd.Parameters.AddWithValue("@State", txtPropRevState.Text);
            MySqlCmd.Parameters.AddWithValue("@University", txtPropRevUniversity.Text);
            MySqlCmd.Parameters.AddWithValue("@Landlord", txtPropRevLandlord.Text);
            MySqlCmd.Parameters.AddWithValue("@Landlord_id", landID);
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

        protected void btnPropRevSubmit_Click(object sender, EventArgs e)
        {
            //This method is a rather stupid complicated one and is responsible for populating THREE of the database tables
            //These are Landlord, Proprty, and Property Review and require the following to create
            //Landlord: Landlord_id, CompanyName, Address, State, University
            //Property: Property_id, Address, City, State, University, Landlord, Landlord_id
            //Property Review: Property_reviewID, Property_id, User_id, Review, Rating
            //Due to the way these work we will make Landlords first, then Property with input for the session variables, and finally post a review
            //Whenever we put a landlord/property to the database store the ID into a session variable as it will be required for the creation of the future review
            
            //To begin make sure that the rating is between 1 and 5
            int score = Convert.ToInt32(txtPropRevRating.Text);
            if (score <= 5 && score >= 1)
            {
                //Make Connection String
                SqlConnection MyConnection = new SqlConnection();
                MyConnection.ConnectionString = "Server=139.78.8.180,22;Database=F19_groupRoss;User Id=groupRoss;Password = ABCD123!;";

                //landID and propID are the two IDs we have to get/create to make this work
                //They will be used to create the reviews but we only want to create them if the property/landlord doesnt already exist
                int landID = 0;
                int propID = 0;
                //Now create variables from the text in the form on the front end
                string city = txtPropRevCity.Text;
                string landlord = txtPropRevLandlord.Text;
                string address = txtPropRevAddress.Text;
                string state = txtPropRevState.Text;
                string uni = txtPropRevUniversity.Text;
                string review = txtPropRevReview.Text;
                //we already defined score above so we dont need to do it here


                //Step 1: Determine if a landlord exists in the database, if not create one
                if (isLLInDataBase(landlord, address, state, uni) == true)
                {
                    //The landlord is already in the database!
                    //Now we have to get back the LandlordID of the landlord we just added
                    landID = getLandID(landlord, address, state, uni);
                }
                else
                {
                    //The landlord does not exist yet so we need to make one and get the ID from it
                    createLandlord(landlord, address, state, uni);
                    landID = getLandID(landlord, address, state, uni);
                }
                //Now we have the landlord ID so we need to get/create the property
                
                //Step 2: Determine if a matching property exists and if not create one
                //Basically step 1 but this time with properties
                if(isPropInDataBase(address,city,state,uni,landID) == true)
                {
                    //The property is already in the database!
                    //Just get the ID and call it a day

                    propID = getPropID(address, city, state, uni, landID);
                }
                else
                {
                    createProperty(address, city, state, uni, landlord, landID);
                    propID = getPropID(address, city, state, uni, landID);
                }

                //Finally now that we have everything we can make the property review
                String MyInsertStatement = "INSERT into dbo.Property_Review(Property_id, User_id, Review, Rating, ReviewDate) VALUES(@Property_id, @User_id, @Review, @Rating, @ReviewDate);";
                SqlCommand MySqlCmd = new SqlCommand(MyInsertStatement, MyConnection);
                MySqlCmd.Parameters.AddWithValue("@Property_id", propID);
                MySqlCmd.Parameters.AddWithValue("@User_id", (int)Session["UserID"]);
                MySqlCmd.Parameters.AddWithValue("@Review", review);
                MySqlCmd.Parameters.AddWithValue("@Rating", score);
                MySqlCmd.Parameters.AddWithValue("@ReviewDate", getDate());
                MyConnection.Open();
                try
                {
                    int intNumberofRowsAffected = MySqlCmd.ExecuteNonQuery();
                    MyConnection.Close();
                }
                catch
                {
                    MyConnection.Close();
                }
                //Redirect the user to the home page now that the table assignment is complete
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                lblPropRevError1.Text = "Error: Rating MUST be an Int Between 1 and 10";
            }
        }

        protected void btnPropRevClear_Click(object sender, EventArgs e)
        {
            //The job of this button is to clear the contents of all the textboxes
            txtPropRevAddress.Text = "";
            txtPropRevCity.Text = "";
            txtPropRevLandlord.Text = "";
            txtPropRevRating.Text = "";
            txtPropRevReview.Text = "";
            txtPropRevState.Text = "";
            txtPropRevUniversity.Text = "";

        }
    }
}