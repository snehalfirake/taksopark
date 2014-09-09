<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OperatorsTable.ascx.cs" Inherits="Taksopark.WebForms.UserControls.OperatorsTable" %>
<link href="../Styles/AdminStyles.css" rel="stylesheet" />
<%--<link href="../Styles/Admin.css" rel="stylesheet" />--%>
<div class="centerDiv">
    <asp:GridView runat="server" ID="OperatorsGV" AllowPaging="true" PageSize="10"
        OnPageIndexChanging="OperatorsGV_PageIndexChanging" DataSourceID="allOperatorsDS"
        AutoGenerateColumns="true" CssClass="gvMain">
        <%--<Columns>
            <asp:ButtonField HeaderText="Edit User" Text="Edit" CommandName="Select" />
        </Columns>--%>
        <HeaderStyle CssClass="gvHeader" />
        <SelectedRowStyle CssClass="gvSelectedRow" />
    </asp:GridView>
</div>