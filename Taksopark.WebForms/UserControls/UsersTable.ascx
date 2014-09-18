<%@ Control Language="C#" AutoEventWireup="true" EnableTheming="true" CodeBehind="UsersTable.ascx.cs" Inherits="Taksopark.WebForms.UserControls.UsersTable" %>
<link href="../Styles/AdminStyles.css" rel="stylesheet" />
<%--<link href="../Styles/Admin.css" rel="stylesheet" />--%>
<div>
    <asp:GridView runat="server" ID="UsersGV" AllowPaging="true" PageSize="20"
        OnPageIndexChanging="UsersGV_PageIndexChanging" DataSourceID="allUsersDS"
        AutoGenerateColumns="true" OnRowCommand="UsersGV_RowCommand">
        <Columns>
            <asp:ButtonField HeaderText="Edit" Text="Edit" CommandName="Select" />
        </Columns>
        <HeaderStyle CssClass="gvHeader" />
        <SelectedRowStyle CssClass="gvSelectedRow" />
    </asp:GridView>
</div>