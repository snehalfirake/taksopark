<%@ Page Title="Lviv Taxi: Taxi Drivers" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="TaxiDrivers.aspx.cs" Inherits="Taksopark.WebForms.WebForms.TaxiDrivers" Theme="Main" %>

<%@ Register Src="~/UserControls/TaxiDriversTable.ascx" TagPrefix="uc" TagName="TaxiDriversTable" %>
<%@ Register Src="~/UserControls/AddNewTaxiDriver.ascx" TagPrefix="uc" TagName="AddNewTaxiDriver" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="one">
        <div class="heading_bg">
            <h2>Taxi Drivers</h2>
            <div class="one-fourth buttonAdd">
                <asp:Button runat="server" ID="btnAdd" Text="Add New Taxi Driver" Width="100%" OnClick="btnAdd_Click" />
            </div>
            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="one-third">
                        <div style="display: inline-block;">
                            <asp:Label runat="server" Text="Status: "></asp:Label>
                        </div>
                        <div style="display: inline-block; width: 150px;">
                            <asp:DropDownList runat="server" ID="ddlDriverStatus" AutoPostBack="true" 
                                EnableTheming="false" CssClass="ddlStatusForFilter">
                                <asp:ListItem Text="All"></asp:ListItem>
                                <asp:ListItem Text="Active"></asp:ListItem>
                                <asp:ListItem Text="Inactive"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <br />
                        <br />
                    </div>
                    <uc:TaxiDriversTable runat="server" ID="TaxiDriversTable1" DataSourceID="allTaxiDriversDS" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <br />
        <br />
    </div>

    <asp:ObjectDataSource runat="server" ID="allTaxiDriversDS" TypeName="Taksopark.WebForms.WebForms.TaxiDrivers"
        SelectMethod="GetAllTaxiDriversFromRepository">
        <SelectParameters>
            <asp:ControlParameter Name="status" Type="String" ControlID="ddlDriverStatus" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
