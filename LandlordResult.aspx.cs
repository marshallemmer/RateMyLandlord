using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace ApartmentApp
{
    public partial class WebForm14 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SCHAddress is the address of the property being worked with
            lblLandBanner.Text = "Average User Rating for " + Session["SCHCompName"].ToString();
            //We need to search the database for all the reviews for this property and find the average
            SqlConnection MyConnection = new SqlConnection("Server=139.78.8.180,22;Database=F19_groupRoss;User Id=groupRoss;Password = ABCD123!;");
            MyConnection.Open();
            SqlCommand cmd = MyConnection.CreateCommand();
            //We are just gonna run the average query, grab the result, and set the lblAvgReview to it as a proof of concept
            cmd.CommandText = "SELECT AVG(Rating) FROM Landlord_Review WHERE Landlord_id = '" + Session["SCHLandlordID"].ToString() + "';";
            //Have to make sure the score is not rounded when it comes out
            lblAvgReview.Text = "Average Review Score: " + Convert.ToDouble(cmd.ExecuteScalar()).ToString();
            MyConnection.Close();

            //Now that we have the average we need to find the scores from individual reviews
            //We also need to account for nulls if there were no reviews
            int propID = Convert.ToInt32(Session["SCHLandlordID"].ToString().ToString());
            lblLR5Star.Text = "" + getNumReviews(5, propID);
            lblLR4Star.Text = "" + getNumReviews(4, propID);
            lblLR3Star.Text = "" + getNumReviews(3, propID);
            lblLR2Star.Text = "" + getNumReviews(2, propID);
            lblLR1Star.Text = "" + getNumReviews(1, propID);

            //Now we need to create the grid of reviews
            createTable(Convert.ToInt32(Session["SCHLandlordID"].ToString()));
        }

        private int getNumReviews(int numReview, int propID)
        {
            //This method is designed to take in a number representing the number of reviews with a rating matching the passed number
            //Ex: pass in a 5 and the method returns the number of 5 star reviews
            int nRev = numReview;
            int id = propID;
            int result = 0;

            SqlConnection MyConnection = new SqlConnection("Server=139.78.8.180,22;Database=F19_groupRoss;User Id=groupRoss;Password = ABCD123!;");
            MyConnection.Open();
            SqlCommand cmd = MyConnection.CreateCommand();
            cmd.CommandText = "SELECT COUNT(Landlord_reviewID) as NumReviews FROM Landlord_Review WHERE Landlord_id = " + id + " AND Rating = " + nRev + " GROUP BY Rating;";
            result = Convert.ToInt32(cmd.ExecuteScalar());
            //Now that we have a result we need to be sure its not null
            //if(result == null)
            //{

            //}

            return result;
        }

        private void createTable(int landID)
        {
            //This method is responsible for creating the reviews on the screen
            //Now we need to display all the property reviews
            DataTable dataTable = new DataTable();

            SqlConnection MyConnection = new SqlConnection();
            MyConnection.ConnectionString = "Server=139.78.8.180,22;Database=F19_groupRoss;User Id=groupRoss;Password = ABCD123!;";

            string Reader = "SELECT Review, Rating, ReviewDate FROM Landlord_Review WHERE Landlord_ID = " + landID + ";";
            SqlCommand MySqlCommand = new SqlCommand(Reader, MyConnection);
            MyConnection.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(MySqlCommand);
            // this will query your database and return the result to your datatable
            da.Fill(dataTable);
            gvLandReviews.DataSource = dataTable;
            gvLandReviews.DataBind();
            MyConnection.Close();
            da.Dispose();

            gvLandReviews.DataSource = dataTable;
        }
    }
}