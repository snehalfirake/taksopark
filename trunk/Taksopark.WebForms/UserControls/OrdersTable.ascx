<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrdersTable.ascx.cs" Inherits="Taksopark.WebForms.UserControls.Dispatcher.OrdersTable" %>
<link href="../style.css" rel="stylesheet" />

<div class="centerDiv">   
    <asp:GridView runat="server" 
        ID="gridViewOrders"
        AllowPaging="true"
        PageSize="20"
        OnPageIndexChanging="gridViewOrders_PageIndexChanging" 
        AutoGenerateColumns="false"
        DataSourceID="ordersDataSource" CssClass="gvMain tableOrders centerTableFixedSize" ShowHeaderWhenEmpty="true">
        <EmptyDataTemplate>
            <img src="../Images/Admin/NoDataAvailable.png" />
        </EmptyDataTemplate>
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Id"/>
            <asp:BoundField DataField="RequesTime" HeaderText="Created At"/>
            <asp:BoundField DataField="startPoint" HeaderText="Start Point"/>
            <asp:BoundField DataField="finishPoint" HeaderText="Destination Point"/>

            <%--<asp:BoundField DataField="status" HeaderText="Status"/>--%>
            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <%# ((Taksopark.DAL.Enums.RequestStatusEnum)Eval("Status")).ToString() %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="DriverId" HeaderText="Driver"/>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnEdit" runat="server" CssClass="button danger" 
                        Text="Edit" PostBackUrl='<%# "~/WebForms/Confirmation.aspx?id=" + Eval("id")  %>' />              
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</div>