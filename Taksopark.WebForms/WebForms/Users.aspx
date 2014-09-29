<%@ Page Title="Lviv Taxi: Users" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Taksopark.WebForms.WebForms.Users" Theme="Main" %>

<%@ Register Src="~/UserControls/UsersTable.ascx" TagPrefix="uc" TagName="UsersTable" %>
<%@ Register Src="~/UserControls/AddNewUser.ascx" TagPrefix="uc" TagName="AddNewUser" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="one">
        <div class="heading_bg">
            <h2>Users</h2>
            <div class="one-fourth buttonAdd">
                <asp:Button runat="server" ID="btnAdd" Text="Add New User" Width="100%" OnClick="btnAdd_Click" />
            </div>
            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="one-third">
                        <div style="display: inline-block;">
                            <asp:Label runat="server" Text="Status: "></asp:Label>
                        </div>
                        <div style="display: inline-block; width: 150px;">
                            <asp:DropDownList runat="server" ID="ddlUserStatus" AutoPostBack="true" 
                                EnableTheming="false" CssClass="ddlStatusForFilter">
                                <asp:ListItem Text="All"></asp:ListItem>
                                <asp:ListItem Text="Active"></asp:ListItem>
                                <asp:ListItem Text="Inactive"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <br />
                        <br />
                    </div>
                    <uc:UsersTable runat="server" ID="UsersTable" DataSourceID="allUsersDS" />
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <br />
        </div>
    </div>

    <asp:ObjectDataSource runat="server" ID="allUsersDS" TypeName="Taksopark.WebForms.WebForms.Users"
        SelectMethod="GetAllUsersFromRepository">
        <SelectParameters>
            <asp:ControlParameter Name="status" Type="String" ControlID="ddlUserStatus" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
