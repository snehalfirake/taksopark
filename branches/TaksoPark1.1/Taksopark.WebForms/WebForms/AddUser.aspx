<%@ Page Title="Lviv Taxi: Add User" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="Taksopark.WebForms.WebForms.AddUser" Theme="Main" %>

<%@ Register Src="~/UserControls/AddNewUser.ascx" TagPrefix="uc" TagName="AddNewUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="one">
        <div class="heading_bg">
            <h2>Add New User</h2>
        </div>
        <div class="centerDiv">
            <uc:AddNewUser runat="server" ID="AddNewUser" />
        </div>
    </div>
</asp:Content>
