<%@ Page Title="" Language="C#" MasterPageFile="~/Rental.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ApartmentApp.WebForm7" %>

<asp:Content ID="TeamContent" ContentPlaceHolderID="MainDisplay" runat="server">
    
    
    <%-- This area needs to hold the login functionality --%>
    <div class="jumbotron">
        <h1>Log In to Rate My Landlords</h1>
        <p class="lead">Go ahead, log in, you're still anonymous. You are always anonymous here, but logging in will save your school and recent searches, helping you find professors faster. You can thank us later</p>
    </div>
    <%-- Bootstrap forms are stupid hard to get text data out of so we are going to have to cheat --%>
    <%-- We can use normal asp textboxes and give them the bootstrap form-control class to make them LOOK like bootstrap input but behave like normal text boxes --%>

    <%-- The Login Input --%>
    <div class="form-group">
        <label for="txtLogUser">Username</label>
        <asp:TextBox ID="txtLogUser" CssClass="form-control" runat="server"></asp:TextBox>
        <small id="logEmailHelp" class="form-text text-muted">We'll never share your username or password with anyone else.</small>
        <asp:RequiredFieldValidator ID="rfvLogUser" runat="server" ErrorMessage="Error: Please Enter a Username" ControlToValidate="txtLogUser" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <%-- The Login Password --%>
        <div class="form-group">
        <label for="txtLogPass">Password</label>
        <asp:TextBox ID="txtLogPass" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvLogPass" runat="server" ErrorMessage="Error: Please Enter a Password" ControlToValidate="txtLogPass" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <%-- We need a label to do some debugging. --%>
    <%-- It can also be used to tell the user when they input incorrect information --%>
    <div>
        <asp:Label ID="lblLogDebug" ForeColor="Red" runat="server" Text=" "></asp:Label>
    </div>
    
    <div>
        <asp:Button ID="btnLogLogin" CssClass="btn-info" runat="server" Text="Login" OnClick="btnLogLogin_Click" />
        <asp:Button ID="btnLogClear" CssClass="btn-info" runat="server" Text="Clear" CausesValidation="False" OnClick="btnLogClear_Click" />
    </div>
      
        





</asp:Content>
