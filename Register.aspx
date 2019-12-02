<%@ Page Title="" Language="C#" MasterPageFile="~/Rental.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ApartmentApp.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainDisplay" runat="server">
    
    <%-- Create a banner that welcomes the user to the pages --%>
    <div class="jumbotron">
        <h1>Account Registration</h1>
        <p class="lead">Welcome, please fill out the information below and we can get your account made right away!</p>
    </div>

    <div>
        <asp:Label ID="lblRegDate" runat="server" Text=""></asp:Label>
    </div>

    <%-- Make a table to hold registration info --%>
    <table style="width: 100%;">
        <tr>
            <td>Username:</td>
            <td><asp:TextBox ID="txtRegUser" CssClass="form-control" runat="server"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator ID="rfvRegUser" runat="server" ErrorMessage="Error Please Enter a Valid Username" ControlToValidate="txtRegUser" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>First Name</td>
            <td><asp:TextBox ID="txtRegFirstName" CssClass="form-control" runat="server"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator ID="rfvRegFirstName" runat="server" ErrorMessage="Error Please Enter a First Name" ControlToValidate="txtRegFirstName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>Last Name</td>
            <td><asp:TextBox ID="txtRegLastName" CssClass="form-control" runat="server"></asp:TextBox> </td>
            <td><asp:RequiredFieldValidator ID="rfvRegLastName" runat="server" ErrorMessage="Error Please Enter a Last Name" ControlToValidate="txtRegLastName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>Email</td>
            <td><asp:TextBox ID="txtRegEmail" CssClass="form-control" runat="server" AutoCompleteType="Company" TextMode="Email"></asp:TextBox> </td>
            <td><asp:RequiredFieldValidator ID="rfvRegEmail" runat="server" ErrorMessage="Error Please Enter an Email Address" ControlToValidate="txtRegEmail" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>Password</td>
            <td><asp:TextBox ID="txtRegPass1" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox> </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvRegPass1" runat="server" ErrorMessage="Error Please Enter a Password" ControlToValidate="txtRegPass1" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Confirm Password</td>
            <td><asp:TextBox ID="txtRegPass2" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox> </td>
            <td><asp:RequiredFieldValidator ID="rfvRegPass2" runat="server" ErrorMessage="Error Please Enter a Password" ControlToValidate="txtRegPass2" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td>
            <asp:Label ID="lblRegDebug" ForeColor="Red" runat="server" Text=" "></asp:Label>
        </tr>
        <tr>
            <td>State</td>
            <td><asp:TextBox ID="txtRegState" CssClass="form-control" runat="server"></asp:TextBox> </td>
            <td><asp:RequiredFieldValidator ID="rfvRegState" runat="server" ErrorMessage="Error Please Enter a Location" ControlToValidate="txtRegState" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td>
            
        </tr>
        <tr>
            <td>City</td>
            <td><asp:TextBox ID="txtRegTown" CssClass="form-control" runat="server"></asp:TextBox> </td>
            <td><asp:RequiredFieldValidator ID="rfvRegTown" runat="server" ErrorMessage="Error Please Enter a Location" ControlToValidate="txtRegTown" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>Current University</td>
            <td><asp:TextBox ID="txtRegUniversity" CssClass="form-control" runat="server"></asp:TextBox> </td>
            <td><asp:RequiredFieldValidator ID="rfvRegUniversity" runat="server" ErrorMessage="Error Please Enter a Valid University" ControlToValidate="txtRegUniversity" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
    </table>

    <%-- Make the Clear and Submit Buttons --%>
    <asp:Label ID="lblRegDebug1" ForeColor="Red" runat="server" Text=" "></asp:Label>
    <asp:Button ID="btnRegSubmit" CssClass="btn-primary" runat="server" Text="Submit" OnClick="btnRegSubmit_Click" />
    <asp:Button ID="btnRegClear" CssClass="btn-danger" runat="server" Text="Clear" CausesValidation="False" OnClick="btnRegClear_Click" />






</asp:Content>
