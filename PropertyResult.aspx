<%@ Page Title="" Language="C#" MasterPageFile="~/Rental.Master" AutoEventWireup="true" CodeBehind="PropertyResult.aspx.cs" Inherits="ApartmentApp.WebForm13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainDisplay" runat="server">

    <div class="jumbotron">
        <asp:Label ID="lblPropBanner" CssClass="h1 col-form-label-lg" runat="server" Text="Average User Rating for [Address]"></asp:Label>
    </div>

    <%-- Here we will show the average review and all the reviews --%>
    <div>
        <asp:Label ID="lblAvgReview" runat="server" CssClass="h2" Text="Average Review Score: "></asp:Label>
    </div>

    <%-- Ok to sort all the number of reviews we will use a bootstrap table as they look nice and auto format the way we want --%>
    <table class="table table-sm">
    <thead>
        <tr>
            <th scope="col">Rating</th>
            <th scope="col">Number of Reviews</th>
        </tr>
    </thead>
        <tbody>
            <tr>
                <td>5 Stars</td>
                <td>
                    <asp:Label ID="lblPR5Star" runat="server" Text="5 Stars:"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>4 Stars</td>
                <td>
                    <asp:Label ID="lblPR4Star" runat="server" Text="4 Stars:"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>3 Stars</td>
                <td>
                    <asp:Label ID="lblPR3Star" runat="server" Text="3 Stars:"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>2 Stars</td>
                <td>
                    <asp:Label ID="lblPR2Star" runat="server" Text="2 Stars:"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>1 Stars</td>
                <td>
                    <asp:Label ID="lblPR1Star" runat="server" Text="1 Stars:"></asp:Label>
                </td>
            </tr>
        </tbody>
    </table>

    <%-- Here we made the gridview that will display the actual property reviews to the user --%>
    <div class="h2">
        <label>Reviews</label>
    </div>

    <asp:GridView ID="gvPropReviews" runat="server"></asp:GridView>


</asp:Content>
