<%@ Page Title="" Language="C#" MasterPageFile="~/Rental.Master" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="ApartmentApp.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainDisplay" runat="server">
    <%-- This page should display account information for the end user and allow them to edit their account info --%>
    <%-- The page should ONLY be accessable if the user is logged in --%>
    
    <%-- Create a banner that personally welcomes the user to the page --%>
    <div class="jumbotron">
        <%-- We need to use a label due to its ability to modify text, we can give it a bootstrap class so it wont stand out --%>
        <asp:Label ID="lblAccountBanner" CssClass="h1 col-form-label-lg" runat="server" Text="Welcome Back [FName]!"></asp:Label>
        <p class="lead">You can find all your account information below if you would like to add or change anything!</p>
    </div>

    <%-- Make a table to hold account info --%>
    <table style="width: 100%;">
        <tr>
            <td>First Name</td>
            <td><asp:TextBox ID="txtAcctFirstName" CssClass="form-control" runat="server"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator ID="rfvAcctFirstName" runat="server" ErrorMessage="Error Please Enter a First Name" ControlToValidate="txtAcctFirstName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>Last Name</td>
            <td><asp:TextBox ID="txtAcctLastName" CssClass="form-control" runat="server"></asp:TextBox> </td>
            <td><asp:RequiredFieldValidator ID="rfvAcctLastName" runat="server" ErrorMessage="Error Please Enter a Last Name" ControlToValidate="txtAcctLastName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>Email</td>
            <td><asp:TextBox ID="txtAcctEmail" CssClass="form-control" runat="server" AutoCompleteType="Company" TextMode="Email"></asp:TextBox> </td>
            <td><asp:RequiredFieldValidator ID="rfvAcctEmail" runat="server" ErrorMessage="Error Please Enter an Email Address" ControlToValidate="txtAcctEmail" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>Password</td>
            <td><asp:TextBox ID="txtAcctPass1" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox> </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvAcctPass1" runat="server" ErrorMessage="Error Please Enter a Password" ControlToValidate="txtAcctPass1" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Confirm Password</td>
            <td><asp:TextBox ID="txtAcctPass2" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox> </td>
            <td><asp:RequiredFieldValidator ID="rfvAcctPass2" runat="server" ErrorMessage="Error Please Enter a Password" ControlToValidate="txtAcctPass2" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td>
            <asp:Label ID="lblAcctDebug" ForeColor="Red" runat="server" Text=" "></asp:Label>
        </tr>
        <tr>
            <td>State</td>
            <td><asp:TextBox ID="txtAcctState" CssClass="form-control" runat="server"></asp:TextBox> </td>
            <td><asp:RequiredFieldValidator ID="rfvAcctState" runat="server" ErrorMessage="Error Please Enter a State" ControlToValidate="txtAcctState" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>City</td>
            <td><asp:TextBox ID="txtAcctTown" CssClass="form-control" runat="server"></asp:TextBox> </td>
            <td><asp:RequiredFieldValidator ID="rfvAcctTown" runat="server" ErrorMessage="Error Please Enter a Location" ControlToValidate="txtAcctTown" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>Current University</td>
            <td><asp:TextBox ID="txtAcctUniversity" CssClass="form-control" runat="server"></asp:TextBox> </td>
            <td><asp:RequiredFieldValidator ID="rfvAcctUniversity" runat="server" ErrorMessage="Error Please Enter a valid University" ControlToValidate="txtAcctUniversity" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
    </table>

    <%-- Make the Clear and Submit Buttons --%>
    <asp:Button ID="btnAcctUpdate" CssClass="btn-primary" runat="server" Text="Update" OnClick="btnAcctUpdate_Click" />

    <asp:Label ID="lblDebug2" ForeColor="Red" runat="server" Text=" "></asp:Label>



</asp:Content>
