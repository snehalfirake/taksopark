<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UsersTable.ascx.cs" Inherits="Taksopark.WebForms.UserControls.UsersTable" %>
<link href="../Styles/AdminStyles.css" rel="stylesheet" />
<%--<link href="../Styles/Admin.css" rel="stylesheet" />--%>
<div class="centerDiv">
    <asp:GridView runat="server" ID="UsersGV" AllowPaging="true" PageSize="10"
        OnPageIndexChanging="UsersGV_PageIndexChanging" DataSourceID="allUsersDS"
        AutoGenerateColumns="true" OnRowCommand="UsersGV_RowCommand" CssClass="gvMain">
        <%--<Columns>
            <asp:ButtonField HeaderText="Edit User" Text="Edit" CommandName="Select" />
        </Columns>--%>
        <HeaderStyle CssClass="gvHeader" />
        <SelectedRowStyle CssClass="gvSelectedRow" />
    </asp:GridView>
</div>