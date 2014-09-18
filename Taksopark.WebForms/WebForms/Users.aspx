<%@ Page Title="Admin panel: Users info" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Taksopark.WebForms.WebForms.Users" Theme="Main" %>

<%@ Register Src="~/UserControls/UsersTable.ascx" TagPrefix="uc" TagName="UsersTable" %>
<%@ Register Src="~/UserControls/AddNewUser.ascx" TagPrefix="uc" TagName="AddNewUser" %>
<%@ Register Src="~/UserControls/EditUsers.ascx" TagPrefix="uc" TagName="EditUsers" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="one">
        <div class="heading_bg">
            <h2>All Users</h2>
            <div class="one-fourth" style="float: right;">
                <asp:Button runat="server" ID="btnAdd" Text="Add New User" Width="100%" OnClick="btnAdd_Click" />
            </div>
            <uc:UsersTable runat="server" ID="UsersTable" DataSourceID="allUsersDS" OnGridViewClicked="UsersTable_GridViewClicked" />
            <br />
            <br />
        </div>
    </div>

    <asp:ObjectDataSource runat="server" ID="allUsersDS" TypeName="Taksopark.WebForms.WebForms.Users"
        SelectMethod="GetAllUsersFromRepository"></asp:ObjectDataSource>
</asp:Content>
