<%@ Control Language="C#" AutoEventWireup="true" EnableTheming="true" CodeBehind="CarsTable.ascx.cs" Inherits="Taksopark.WebForms.UserControls.CarsTable" %>
<link href="../Styles/AdminStyles.css" rel="stylesheet" />

<div>
    <asp:GridView runat="server" ID="CarsGV" AllowPaging="true" PageSize="20"
        OnPageIndexChanging="CarsGV_PageIndexChanging" DataSourceID="allCarsDS"
        AutoGenerateColumns="true" OnRowCommand="CarsGV_RowCommand">
        <Columns>
            <asp:ButtonField HeaderText="Edit" Text="Edit" CommandName="Select" />
        </Columns>
        <HeaderStyle CssClass="gvHeader" />
        <SelectedRowStyle CssClass="gvSelectedRow" />
    </asp:GridView>
</div>