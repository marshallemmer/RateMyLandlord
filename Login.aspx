<%@ Page Title="" Language="C#" MasterPageFile="~/Landlord.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ApartmentApp.WebForm7" %>

<asp:Content ID="TeamContent" ContentPlaceHolderID="MainDisplay" runat="server">
    <%-- This area needs to hold the login functionality --%>
    <div class="jumbotron">
        <h1>Log In to Rate My Landlords</h1>
        <p class="lead">Go ahead, log in, you're still anonymous. You are always anonymous here, but logging in will save your school and recent searches, helping you find professors faster. You can thank us later</p>
    </div>

    <%-- The Login Input --%>
    <div class="form-group">
        <input type="email" class="form-control" id="LoginEmail" aria-describedby="logEmailHelp" placeholder="Enter email">
        <small id="logEmailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
    </div>
        <div class="form-group">
        <input type="password" class="form-control" id="LoginPassword" placeholder="Password">
    </div>
    <div>
        <button type="submit" class="btn btn-dark">Login</button>
    </div>
      
        





</asp:Content>
