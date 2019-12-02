<%@ Page Title="" Language="C#" MasterPageFile="~/Rental.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="ApartmentApp.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainDisplay" runat="server">
    <%-- This will be the search page and its job will be to return search results for everything you search for --%>
    <%-- It can search for info on landlords or property --%>

    <div class="jumbotron">
        <h1>Rental Search</h1>
    </div>

    <div class ="list-group list-group-horizontal">
        <asp:TextBox ID="txtSearch" CssClass="mr-sm-2 form-control list-group-item" runat="server"></asp:TextBox>
        <asp:Button ID="btnSubmit" CssClass="btn btn-success mr-sm-2" runat="server" Text="Search" OnClick="btnSubmit_Click" style="left: 0px; top: 1px" />
    </div>

    <h2>Search By</h2>
    <table class ="table">
        <tbody>
            <%-- This row handles property --%>
            <tr>
                <td>
                    <asp:RadioButtonList ID="rblSearchType" RepeatDirection="Horizontal" runat="server">
                        <asp:ListItem Value="property">Search by Properties</asp:ListItem>
                        <asp:ListItem Value="land">Search by Landlords</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="rfvSearchType" runat="server" ErrorMessage="Error: Please Select Something to Search By" Display="Dynamic" ForeColor="Red" ControlToValidate="rblSearchType"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <%-- This row handles the lists --%>
            <tr>
                <td>
                    <label>Property Fields</label>
                    <asp:DropDownList ID="ddlPropCat" runat="server">
                        <asp:ListItem>Address</asp:ListItem>
                        <asp:ListItem>City</asp:ListItem>
                        <asp:ListItem>State</asp:ListItem>
                        <asp:ListItem>University</asp:ListItem>
                        <asp:ListItem>Landlord</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <label>Landlord Fields</label>
                    <asp:DropDownList ID="ddlLandCat" runat="server">
                        <asp:ListItem>CompanyName</asp:ListItem>
                        <asp:ListItem>Address</asp:ListItem>
                        <asp:ListItem>State</asp:ListItem>
                        <asp:ListItem>University</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </tbody>
    </table>

    <asp:GridView ID="gvSearchResults" runat="server" OnSelectedIndexChanged="gvSearchResults_SelectedIndexChanged">
        <Columns>
            <%--<asp:CommandField HeaderText ="modify" ShowDeleteButton ="false" ShowEditButton ="true" EditText ="modify" />--%>
            <asp:TemplateField HeaderText="View Review">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkView" CommandName="View" runat="server" OnClick ="btnView_Click" >View</asp:LinkButton>
                    </ItemTemplate>
            </asp:TemplateField>
        </Columns>  
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>

    <asp:Label ID="lblReport" runat="server" Text=""></asp:Label>












</asp:Content>
