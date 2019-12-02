<%@ Page Title="" Language="C#" MasterPageFile="~/Rental.Master" AutoEventWireup="true" CodeBehind="LandlordReviewForm.aspx.cs" Inherits="ApartmentApp.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainDisplay" runat="server">
    <%-- This page will go and create a Landlord Review to populate the landlord --%>
    <div class="jumbotron">
        <%-- We need to use a label due to its ability to modify text, we can give it a bootstrap class so it wont stand out --%>
        <asp:Label ID="lblLandLordReviewFormHeader" CssClass="h1 col-form-label-lg" runat="server" Text="Landlord Review"></asp:Label>
        <p class="lead">Please enter below information on your current landlord and how you feel about them!</p>
        <p class="lead">The more landlords you review the better our system becomes!</p>
    </div>

    <table style="width: 100%;">
        <tr>
            <td>Landlord</td>
            <td><asp:TextBox ID="txtLLRevLandlord" CssClass="form-control" runat="server"></asp:TextBox> </td>
            <td><asp:RequiredFieldValidator ID="rfvLLRevLandlord" runat="server" ErrorMessage="Error Please Enter a Landlord" ControlToValidate="txtLLRevLandlord" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>Address</td>
            <td><asp:TextBox ID="txtLLRevAddress" CssClass="form-control" runat="server"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator ID="rfvLLRevAddress" runat="server" ErrorMessage="Error Please Enter a Valid Address" ControlToValidate="txtLLRevAddress" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>State</td>
            <td><asp:TextBox ID="txtLLRevState" CssClass="form-control" runat="server"></asp:TextBox> </td>
            <td><asp:RequiredFieldValidator ID="rfvLLRevState" runat="server" ErrorMessage="Error Please Enter a State" ControlToValidate="txtLLRevState" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>University</td>
            <td><asp:TextBox ID="txtLLRevUniversity" CssClass="form-control" runat="server"></asp:TextBox> </td>
            <td><asp:RequiredFieldValidator ID="rfvLLRevUniversity" runat="server" ErrorMessage="Error Please Enter a Valid University" ControlToValidate="txtLLRevUniversity" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        
        <tr>
            <td>Review</td>
            <td><asp:TextBox ID="txtLLRevReview" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox> </td>
            <td><asp:RequiredFieldValidator ID="rfvLLRevReview" runat="server" ErrorMessage="Error Please Enter a Review" ControlToValidate="txtLLRevReview" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>Rating</td>
            <td><asp:TextBox ID="txtLLRevRating" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox> </td>
            <td><asp:RequiredFieldValidator ID="rfvLLRevRating" runat="server" ErrorMessage="Error Please Enter a Valid Rating Out of 5" ControlToValidate="txtLLRevRating" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td>
            <%--<asp:RangeValidator ID="rfvPropRevRatingRange" runat="server" ErrorMessage="Ratings MUST be between 1 and 10" ControlToValidate="txtPropRevRating" MaximumValue="10" MinimumValue="1" Display="Dynamic" ForeColor="Red"></asp:RangeValidator>--%>
            <asp:Label ID="lblLLRevError1" runat="server" Text=" " ForeColor="Red"></asp:Label>
        </tr>
    </table>

    <%-- Make the buttons for clearing and submitting the info --%>
    <div>
        <asp:Button ID="btnLLRevSubmit" CssClass="btn-primary" runat="server" Text="Submit" OnClick="btnLLRevSubmit_Click" />
        <asp:Button ID="btnLLRevClear" CssClass="btn-danger" runat="server" Text="Clear" CausesValidation="False" OnClick="btnLLRevClear_Click" />
    </div>


</asp:Content>
