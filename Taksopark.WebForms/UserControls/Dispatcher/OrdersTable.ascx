<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrdersTable.ascx.cs" Inherits="Taksopark.WebForms.UserControls.Dispatcher.OrdersTable" %>
<link href="../style.css" rel="stylesheet" />

<div class="centerDiv">
    <%--<asp:GridView runat="server" ID="gridViewOrders" AllowPaging="true" PageSize="20"
        OnPageIndexChanging="gridViewOrders_PageIndexChanging" DataSourceID="ordersDataSource"
        AutoGenerateColumns="true" CssClass="gvMain">
        <HeaderStyle CssClass="gvHeader" />
        <SelectedRowStyle CssClass="gvSelectedRow" />
    </asp:GridView>--%>
   
    <asp:GridView runat="server" 
        ID="gridViewOrders"
        AllowPaging="true"
        PageSize="20"
        OnPageIndexChanging="gridViewOrders_PageIndexChanging" 
        AutoGenerateColumns="false"
        DataSourceID="ordersDataSource" CssClass="gvMain">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Id"/>
            <asp:BoundField DataField="RequesTime" HeaderText="Created At"/>
            <asp:BoundField DataField="startPoint" HeaderText="Start Point"/>
            <asp:BoundField DataField="finishPoint" HeaderText="Destination Point"/>
            <asp:BoundField DataField="status" HeaderText="Status"/>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server" CssClass="button" Text="Edit" PostBackUrl='<%# "~/WebForms/Confirmation.aspx?id=" + Eval("id")  %>' />              
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:HyperLinkField ControlStyle-CssClass="button" Text="Edit" NavigateUrl="~/WebForms/Confirmation.aspx"  HeaderText="Action"/>--%>
        </Columns>
    </asp:GridView>

</div>