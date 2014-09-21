<%@ Page Title="Admin panel: Taxi Drivers info" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="TaxiDrivers.aspx.cs" Inherits="Taksopark.WebForms.WebForms.TaxiDrivers" Theme="Main" %>

<%@ Register Src="~/UserControls/TaxiDriversTable.ascx" TagPrefix="uc" TagName="TaxiDriversTable" %>
<%@ Register Src="~/UserControls/AddNewTaxiDriver.ascx" TagPrefix="uc" TagName="AddNewTaxiDriver" %>
<%@ Register Src="~/UserControls/CarsTable.ascx" TagPrefix="uc" TagName="CarsTable" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="one">
        <div class="heading_bg">
            <h2>All Taxi Drivers</h2>
            <div class="one-fourth buttonAdd">
                <asp:Button runat="server" ID="btnAdd" Text="Add New Taxi Driver" Width="100%" OnClick="btnAdd_Click" />
            </div>
            <uc:TaxiDriversTable runat="server" id="TaxiDriversTable1" DataSourceID="allTaxiDriversDS" 
                OnGridViewClicked="TaxiDriversTable1_GridViewClicked" />
        </div>
        <br />
        <br />
    </div>

    <div class="one">
        <div class="heading_bg">
            <h2>All Cars</h2>
            <uc:CarsTable runat="server" id="CarsTable" DataSourceID="allCarsDS" OnGridViewClicked="CarsTable_GridViewClicked" />
        </div>
        <br />
        <br />
    </div>

    <asp:ObjectDataSource runat="server" ID="allTaxiDriversDS" TypeName="Taksopark.WebForms.WebForms.TaxiDrivers" 
        SelectMethod="GetAllTaxiDriversFromRepository">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource runat="server" ID="allCarsDS" TypeName="Taksopark.WebForms.WebForms.TaxiDrivers" 
        SelectMethod="GetAllCarsFromRepository">
    </asp:ObjectDataSource>
</asp:Content>
