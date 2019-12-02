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
    public partial class WebForm12 : System.Web.UI.Page
    {
        //The guide has a public SQLConnection so we are too.
        //It is weird but if it works I am not picky on the particulars
        public SqlConnection MyConnection = new SqlConnection();

        public string constr;
        protected void Page_Load(object sender, EventArgs e)
        {
            //set the text value of the new search to the session
            //Will need to use !PostBack otherwise the search will only work ONCE
            if(!IsPostBack)
            {
                txtSearch.Text = Session["Search"].ToString();
            }
        }

        public void connection()
        {
            //This method is designed to get the connection going without having to write the same connection thing over and over again
            //This code initializes a connection to SQL and passes it a connection string to link visual studio to our tables
            //SqlConnection MyConnection = new SqlConnection();
            MyConnection.ConnectionString = "Server=139.78.8.180,22;Database=F19_groupRoss;User Id=groupRoss;Password = ABCD123!;";
            MyConnection.Open();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //For now this is rather complicated so we will either search by property or landlord
            //landlord searches will search by company name
            //properties will search by address

            //Determine which search mode is selected
            if (rblSearchType.SelectedValue == "land")
            {
                //Here we search the landlord tables
                connection();
                string query = "SELECT * FROM dbo.Landlord_ID WHERE " + ddlLandCat.SelectedValue + " like '" + txtSearch.Text + "%'";
                SqlCommand com = new SqlCommand(query, MyConnection);

                //Get the data reader
                //It will read in the data into the table
                SqlDataReader dr;
                dr = com.ExecuteReader();

                //If there are still tables to read we read them and populate our gridview with them
                if (dr.HasRows)
                {
                    dr.Read();
                    searchLand();
                    gvSearchResults.Visible = true;
                    txtSearch.Text = "";
                    lblReport.Text = "";
                }
                else
                {
                    //Things have gone wrong or there was nothing to find
                    gvSearchResults.Visible = false;
                    lblReport.Visible = true;
                    lblReport.Text = "The search Term " + txtSearch.Text + " Is Not Available in the Records";
                }
            }
            else
            {
                //Here we search the property table
                connection();
                string query = "SELECT * FROM dbo.Property_ID WHERE " + ddlPropCat.SelectedValue + " like '" + txtSearch.Text + "%'";
                SqlCommand com = new SqlCommand(query, MyConnection);

                //Get the data reader
                //It will read in the data into the table
                SqlDataReader dr;
                dr = com.ExecuteReader();

                //If there are still tables to read we read them and populate our gridview with them
                if (dr.HasRows)
                {
                    dr.Read();
                    searchProp();
                    gvSearchResults.Visible = true;
                    txtSearch.Text = "";
                    lblReport.Text = "";
                }
                else
                {
                    //Things have gone wrong or there was nothing to find
                    gvSearchResults.Visible = false;
                    lblReport.Visible = true;
                    lblReport.Text = "The search Term " + txtSearch.Text + " Is Not Available in the Records";
                }
            }
        }

        private void searchProp()
        {
            //This method searches the database in the Properties tables and returns properties that match the entered data
            SqlConnection MyConnection = new SqlConnection();
            MyConnection.ConnectionString = "Server=139.78.8.180,22;Database=F19_groupRoss;User Id=groupRoss;Password = ABCD123!;";
            //Get a search statement
            string MySearchStatement;
            MySearchStatement = "SELECT * FROM dbo.Property_ID WHERE " + ddlPropCat.SelectedValue + " like '" + txtSearch.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(MySearchStatement, MyConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gvSearchResults.DataSource = ds;
            //gvSearchResults.
            gvSearchResults.DataBind();
        }

        private void searchLand()
        {
            //This method searches the database in the landlord table and returns landlord entries that match the entered data
            SqlConnection MyConnection = new SqlConnection();
            MyConnection.ConnectionString = "Server=139.78.8.180,22;Database=F19_groupRoss;User Id=groupRoss;Password = ABCD123!;";
            //Get a search statement
            string MySearchStatement;
            MySearchStatement = "SELECT * FROM dbo.Landlord_ID WHERE " + ddlLandCat.SelectedValue + " like '" + txtSearch.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(MySearchStatement, MyConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gvSearchResults.DataSource = ds;
            gvSearchResults.DataBind();
        }

        protected void gvSearchResults_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnView_Click(object sender, EventArgs e)
        {
            //This method is designed to bring us to the review page for a selected item. This will be hilariously harder than this first would appear to be
            //This is because we need to retreave all the info from the gridview and also determine WHAT info to retreave in the first place!
            //Step 1: Get the index of the gridview row you are on
            LinkButton lb = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lb.NamingContainer;
            int index = 0;
            if (row != null)
            {
                //gets the row index selected
                index = row.RowIndex; 
            }
            //lblReport.Text = "" + index;
            //Step 2: Determine whether you are working with a property or a landlord
            if(rblSearchType.SelectedValue == "property")
            {
                //You are working with properties
                //Step 3: Retrieve the required data from the gridview and put it into session variables
                //lblReport.Text = row.Cells[2].Text;
                Session["SCHPropID"] = row.Cells[1].Text;
                Session["SCHAddress"] = row.Cells[2].Text;
                Session["SCHCity"] = row.Cells[3].Text;
                Session["SCHState"] = row.Cells[4].Text;
                Session["SCHUni"] = row.Cells[5].Text;
                Session["SCHLandlord"] = row.Cells[6].Text;
                Session["SCHLandlordID"] = row.Cells[7].Text;
                Response.Redirect("PropertyResult.aspx");
            }
            else
            {
                //You are working with landlords
                //Step 3: Retrieve the required data from the gridview and put it into session variables
                Session["SCHLandlordID"] = row.Cells[1].Text;
                Session["SCHCompName"] = row.Cells[2].Text;
                Session["SCHAddress"] = row.Cells[3].Text;
                Session["SCHState"] = row.Cells[4].Text;
                Session["SCHUni"] = row.Cells[5].Text;
                Response.Redirect("LandlordResult.aspx");
            }


        }
    }
}