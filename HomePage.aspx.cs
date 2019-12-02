using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace ApartmentApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            //In here we will be writing the code to draw data from the database to create the recent reviews table
            //The table will show the following: The property's name/address, the reviewing username, a snippit of the review, and the rating
            //should also house a link to a full review

            // your data table
            DataTable dataTable = new DataTable();

            SqlConnection MyConnection = new SqlConnection();
            MyConnection.ConnectionString = "Server=139.78.8.180,22;Database=F19_groupRoss;User Id=groupRoss;Password = ABCD123!;";

            string Reader = "SELECT Review, Rating FROM dbo.Property_Review ORDER BY Property_reviewID DESC;";
            SqlCommand MySqlCommand = new SqlCommand(Reader, MyConnection);
            MyConnection.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(MySqlCommand);
            // this will query your database and return the result to your datatable
            da.Fill(dataTable);
            gvHomeGrid.DataSource = dataTable;
            gvHomeGrid.DataBind();
            MyConnection.Close();
            da.Dispose();

            gvHomeGrid.DataSource = dataTable;


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AboutUs.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("OurTeam.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContactUs.aspx");
        }
    }
}