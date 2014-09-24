<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderInfo.ascx.cs" Inherits="Taksopark.WebForms.UserControls.Dispatcher.OrderInfo" %>

<asp:DetailsView runat="server" id="detailsView1" DataSourceID="ordersDataSource" AutoGenerateRows="false">
    <Fields>
        <asp:BoundField DataField="id" HeaderText="Id" />
        <asp:BoundField DataField="RequesTime" HeaderText="Created At" />
        <asp:BoundField DataField="phoneNumber" HeaderText="Phone" />
        <asp:BoundField DataField="startPoint" HeaderText="Start Point" />
        <asp:BoundField DataField="finishPoint" HeaderText="Destination Point" />
        <asp:BoundField DataField="status" HeaderText="Status" />
    </Fields>
</asp:DetailsView>

<%--<asp:DetailsView runat="server" id="detailsView1" AutoGenerateRows="false">
    <Fields>
        <asp:BoundField DataField="id" HeaderText="Id" />
        <asp:BoundField DataField="RequesTime" HeaderText="Created At" />
        <asp:BoundField DataField="phoneNumber" HeaderText="Phone" />
        <asp:BoundField DataField="startPoint" HeaderText="Start Point" />
        <asp:BoundField DataField="finishPoint" HeaderText="Destination Point" />
        <asp:BoundField DataField="status" HeaderText="Status" />
    </Fields>
</asp:DetailsView>--%>