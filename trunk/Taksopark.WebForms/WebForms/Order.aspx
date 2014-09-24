<%@ Page Title="Dispatcher: Order List" Language="C#" MasterPageFile="~/Dispatcher.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="Taksopark.WebForms.Dispatcher.Order" %>

<%@ Register Src="~/UserControls/OrdersTable.ascx" TagPrefix="uc" TagName="OrdersTable" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div id="container">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="one">
                    <div style="display: inline-block;">
                        <asp:Label runat="server" Text="Status: " Font-Bold="true" Font-Size="X-Large"></asp:Label>
                    </div>
                    <div style="display: inline-block; width: 150px;">
                        <asp:DropDownList runat="server" ID="ddlRequestStatus" AutoPostBack="true"
                            EnableTheming="false" CssClass="ddlStatusForFilter btn btn-s-md btn-info" Font-Size="Large">
                            <asp:ListItem Text="Active"></asp:ListItem>
                            <asp:ListItem Text="Closed"></asp:ListItem>
                            <asp:ListItem Text="InProgress"></asp:ListItem>
                            <asp:ListItem Text="Rejected"></asp:ListItem>
                            <asp:ListItem Text="All"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <br />
                    <br />
                </div>
                <br />
                <div align="center">
                    <uc:OrdersTable runat="server" ID="OrdersTable" DataSourceID="ordersDataSource" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:ObjectDataSource runat="server" ID="ordersDataSource" TypeName="Taksopark.WebForms.Dispatcher.Order"
        SelectMethod="GetAllRequests">
        <SelectParameters>
            <asp:ControlParameter Name="status" Type="String" ControlID="ddlRequestStatus" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
