<%@ Page Title="Lviv Taxi: Edit Taxi Driver" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EditTaxiDriver.aspx.cs" Inherits="Taksopark.WebForms.WebForms.EditTaxiDriver" Theme="Main" %>

<%@ Register Src="~/UserControls/EditTaxiDrivers.ascx" TagPrefix="uc" TagName="EditTaxiDrivers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/App_Themes/Main/MainStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="one">
        <div class="heading_bg">
            <h2>Edit Taxi Driver</h2>
        </div>
        <div>
            <uc:EditTaxiDrivers runat="server" id="EditTaxiDrivers" />
        </div>
    </div>
</asp:Content>
