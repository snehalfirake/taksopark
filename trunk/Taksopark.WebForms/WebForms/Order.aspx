<%@ Page Title="Dispatcher: OrderList" Language="C#" MasterPageFile="~/Dispatcher.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="Taksopark.WebForms.Dispatcher.Order" %>

<%@ Register Src="~/UserControls/OrdersTable.ascx" TagPrefix="uc" TagName="OrdersTable" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div id="container">
        <div align="center">
            <uc:OrdersTable runat="server" ID="OrdersTable" DataSourceID="ordersDataSource" />
        </div>
    </div>
    <asp:ObjectDataSource runat="server" ID="ordersDataSource" TypeName="Taksopark.WebForms.Dispatcher.Order" SelectMethod="GetAllRequests"></asp:ObjectDataSource>
</asp:Content>
