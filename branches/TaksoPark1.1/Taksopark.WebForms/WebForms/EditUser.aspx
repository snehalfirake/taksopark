<%@ Page Title="Lviv Taxi: Edit User" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="Taksopark.WebForms.WebForms.EditUser" Theme="Main" %>

<%@ Register Src="~/UserControls/EditUsers.ascx" TagPrefix="uc" TagName="EditUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/App_Themes/Main/MainStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="one">
        <div class="heading_bg">
            <h2>Edit User</h2>
        </div>
        <div>
            <uc:EditUsers runat="server" id="EditUsers" />
        </div>
    </div>
</asp:Content>
