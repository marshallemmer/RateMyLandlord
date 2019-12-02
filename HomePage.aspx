<%@ Page Title="" Language="C#" MasterPageFile="~/Rental.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="ApartmentApp.WebForm1" %>

<%-- This is the home page --%>
<%-- It will be the first thing that the user sees --%>
<asp:Content ID="HomeContent" ContentPlaceHolderID="MainDisplay" runat="server">
    <link rel="stylesheet" href="CustomStyleSheet.css" type="text/css" runat="server"/>
  <div data-collapse="none" data-animation="default" data-duration="400" class="navigation w-nav">
  </div>
  <div class="section cc-store-home-wrap">
    <div class="intro-header">
      <div class="intro-content cc-homepage">
        <div class="intro-text">
          <div class="heading-jumbo">Rate My Rental</div>
          <div class="paragraph-bigger cc-bigger-white-light"><strong><em>Search by Landlord or by Address</em></strong><br></div>
        </div>
      </div>
    </div>
    <div class="container">
      <div class="motto-wrap">
        <div class="label cc-light">Its just a search away</div>
        <div class="heading-jumbo-small">Review it before you Rent.<br></div>
      </div>
          <%-- So the table we want to create will have 5 col and lets start with 10 entities --%>
    <%-- Columns: Property Name/Address, Reviewer Username, Review Snippit, Review, Link to a Full Review --%>
    <div class="container text-primary col-4 offset-4">
        <h1>Recent Reviews</h1>
    </div>
    <%-- Here we make the table radio button controls --%>
    <%--<asp:RadioButtonList RepeatDirection="Horizontal" ID="rbGridControl" runat="server">
        <asp:ListItem>Properties</asp:ListItem>
        <asp:ListItem>Landlords</asp:ListItem>
    </asp:RadioButtonList>--%>

    <%-- Here we make the table where we will store the most recent reviews --%>
    <asp:GridView ID="gvHomeGrid" AllowPaging="true" PageSize="5" cssclass="hidden" runat="server"></asp:GridView>
      <div class="divider"></div>
      <div class="home-content-wrap">
        <div class="w-layout-grid about-grid">
          <div id="w-node-76c147234d34-da64b7de">
            <div class="home-section-wrap">
              <div class="label cc-light">About</div>
              <h2 class="section-heading">Who we are</h2>
              <p class="paragraph-light">Striving to be the number one rental review site for college students around the country. Built by college kids for college kids. From Oklahoma State university and ready to expand.</p>
            </div>
            
            <div>
                <asp:Button ID="Button1" runat="server" Class="btn btn-dark" OnClick="Button1_Click" Text="Learn More" />
            </div>
          </div><img src="images/Computer.jpeg" /></div>
        <div class="w-layout-grid about-grid cc-about-2">
          <div id="w-node-76c147234d41-da64b7de">
            <div class="home-section-wrap">
              <div class="label cc-light">Team</div>
              <h2 class="section-heading">What we do</h2>
              <p class="paragraph-light">Host the most Rental Properties for College Students so they can research their house before they rent. The renting process is difficult sometimes with our help it just became easier. Ever wonder how much average utilities cost or how far the walk is to campus. Start your search and find out.</p>
            </div>
           
            <div>
                <asp:Button ID="Button2" runat="server" Class="btn btn-dark" OnClick="Button2_Click" Text="Learn More" />
            </div>

          </div><img src="images/Code.jpeg" /></div>
      </div>
    </div>
  </div>
  <div class="section">
    <div class="container">
      <div class="blog-heading">
        <div class="label cc-light">Contact Us</div>
        <h2 class="work-heading">
            <asp:Button ID="Button3" runat="server" Class="btn btn-dark" OnClick="Button3_Click" Text="Send Us a Message" />
          </h2>
      </div>
    </div>
  </div>
  <script src="https://d3e54v103j8qbb.cloudfront.net/js/jquery-3.4.1.min.220afd743d.js" type="text/javascript"></script>
  <script src="js/webflow.js" type="text/javascript"></script>
  <!-- [if lte IE 9]><script src="https://cdnjs.cloudflare.com/ajax/libs/placeholders/3.0.2/placeholders.min.js"></script><![endif] -->

    
    <%--<div class="form-group col-4 offset-4">
        <asp:TextBox ID="txtMainSearch" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:Button ID="btnMainSubmit" CssClass="form-control" runat="server" Text="Submit" />
    </div>--%>

</asp:Content>

