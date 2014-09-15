<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UsersTable.ascx.cs" Inherits="Taksopark.WebForms.UserControls.UsersTable" %>
<link href="../Styles/AdminStyles.css" rel="stylesheet" />
<%--<link href="../Styles/Admin.css" rel="stylesheet" />--%>
<div class="centerDiv">
    <asp:GridView runat="server" ID="UsersGV" AllowPaging="true" PageSize="20"
        OnPageIndexChanging="UsersGV_PageIndexChanging" DataSourceID="allUsersDS"
        AutoGenerateColumns="true" CssClass="gvMain">
        <HeaderStyle CssClass="gvHeader" />
        <SelectedRowStyle CssClass="gvSelectedRow" />
    </asp:GridView>
</div>