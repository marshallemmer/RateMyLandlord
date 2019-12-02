<%@ Page Title="" Language="C#" MasterPageFile="~/Rental.Master" AutoEventWireup="true" CodeBehind="PropertyReview.aspx.cs" Inherits="ApartmentApp.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainDisplay" runat="server">
    <%-- This page will go and create a property, a landlord, AND a property review for the thing all in one go! --%>
    <div class="jumbotron">
        <%-- We need to use a label due to its ability to modify text, we can give it a bootstrap class so it wont stand out --%>
        <asp:Label ID="lblPropReview" CssClass="h1 col-form-label-lg" runat="server" Text="Property Review"></asp:Label>
        <p class="lead">Please enter below information on your current rental and how you feel about it!</p>
        <p class="lead">The more properties you review the better our system becomes!</p>
    </div>

    <table style="width: 100%;">
        <tr>
            <td>Address</td>
            <td><asp:TextBox ID="txtPropRevAddress" CssClass="form-control" runat="server"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator ID="rfvPropRevAddress" runat="server" ErrorMessage="Error Please Enter a Valid Address" ControlToValidate="txtPropRevAddress" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>City</td>
            <td><asp:TextBox ID="txtPropRevCity" CssClass="form-control" runat="server"></asp:TextBox> </td>
            <td><asp:RequiredFieldValidator ID="rfvPropRevCity" runat="server" ErrorMessage="Error Please Enter a City" ControlToValidate="txtPropRevCity" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>State</td>
            <td><asp:TextBox ID="txtPropRevState" CssClass="form-control" runat="server"></asp:TextBox> </td>
            <td><asp:RequiredFieldValidator ID="rfvPropRevState" runat="server" ErrorMessage="Error Please Enter a State" ControlToValidate="txtPropRevState" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>University</td>
            <td><asp:TextBox ID="txtPropRevUniversity" CssClass="form-control" runat="server"></asp:TextBox> </td>
            <td><asp:RequiredFieldValidator ID="rfvPropRevUniversity" runat="server" ErrorMessage="Error Please Enter a Valid University" ControlToValidate="txtPropRevUniversity" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>Landlord</td>
            <td><asp:TextBox ID="txtPropRevLandlord" CssClass="form-control" runat="server"></asp:TextBox> </td>
            <td><asp:RequiredFieldValidator ID="rfvPropRevLandlord" runat="server" ErrorMessage="Error Please Enter a Landlord" ControlToValidate="txtPropRevLandlord" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>Review</td>
            <td><asp:TextBox ID="txtPropRevReview" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox> </td>
            <td><asp:RequiredFieldValidator ID="rfvPropRevReview" runat="server" ErrorMessage="Error Please Enter a Review" ControlToValidate="txtPropRevReview" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>Rating</td>
            <td><asp:TextBox ID="txtPropRevRating" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox> </td>
            <td><asp:RequiredFieldValidator ID="rfvPropRevRating" runat="server" ErrorMessage="Error Please Enter a Valid Rating Out of 5" ControlToValidate="txtPropRevRating" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td>
            <%--<asp:RangeValidator ID="rfvPropRevRatingRange" runat="server" ErrorMessage="Ratings MUST be between 1 and 10" ControlToValidate="txtPropRevRating" MaximumValue="10" MinimumValue="1" Display="Dynamic" ForeColor="Red"></asp:RangeValidator>--%>
            <asp:Label ID="lblPropRevError1" runat="server" Text=" " ForeColor="Red"></asp:Label>
        </tr>
    </table>

    <%-- Make the buttons for clearing and submitting the info --%>
    <div>
        <asp:Button ID="btnPropRevSubmit" CssClass="btn-primary" runat="server" Text="Submit" OnClick="btnPropRevSubmit_Click" />
        <asp:Button ID="btnPropRevClear" CssClass="btn-danger" runat="server" Text="Clear" CausesValidation="False" OnClick="btnPropRevClear_Click" />
    </div>












</asp:Content>
