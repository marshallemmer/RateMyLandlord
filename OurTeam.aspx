<%@ Page Title="" Language="C#" MasterPageFile="~/Rental.Master" AutoEventWireup="true" CodeBehind="OurTeam.aspx.cs" Inherits="ApartmentApp.WebForm5" %>

<asp:Content ID="TeamContent" ContentPlaceHolderID="MainDisplay" runat="server">
 <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
<script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
<!------ Include the above in your HEAD tag ---------->


    <h1 class="text-center">Rate my Rental Team Members</h1>

	
	<div class="container">
	<div class="row">
	
	<!--team-1-->
	<div class="col-lg-4">
	<div class="our-team-main">
	
	<div class="team-front">
	<img src="http://placehold.it/110x110/9c27b0/fff?text=TM" class="img-fluid" />
	<h3>Trevor McPherson</h3>
	<p>Front End and Owner</p>
	</div>
	
	<div class="team-back">
	<span>

	</span>
	</div>
	
	</div>
	</div>
	<!--team-1-->
	
	<!--team-2-->
	<div class="col-lg-4">
	<div class="our-team-main">
	
	<div class="team-front">
	<img src="http://placehold.it/110x110/336699/fff?text=ME" class="img-fluid" />
	<h3>Marshall Emmer</h3>
	<p>Back End and Database</p>
	</div>
	
	<div class="team-back">
	<span>
	
	</span>
	</div>
	
	</div>
	</div>
	<!--team-2-->
	
	<!--team-3-->
	<div class="col-lg-4">
	<div class="our-team-main">
	
	<div class="team-front">
	<img src="http://placehold.it/110x110/607d8b/fff?text=TR" class="img-fluid" />
	<h3>TJ Ross</h3>
	<p>Sql Database</p>
	</div>
	
	<div class="team-back">
	<span>
	
	</span>
	</div>
	
	</div>
	</div>
	<!--team-3-->
	</div>
	</div>
</asp:Content>

