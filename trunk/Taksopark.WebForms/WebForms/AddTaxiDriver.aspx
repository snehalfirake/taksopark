<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddTaxiDriver.aspx.cs" Inherits="Taksopark.WebForms.WebForms.AddTaxiDriver" Theme="Main" %>

<%@ Register Src="~/UserControls/AddNewTaxiDriver.ascx" TagPrefix="uc" TagName="AddNewTaxiDriver" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="one">
        <div class="heading_bg">
            <h2>Add New Taxi Driver</h2>
        </div>
        <div>
            <uc:AddNewTaxiDriver runat="server" id="AddNewTaxiDriver" />
        </div>
    </div>
</asp:Content>
