﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TaxiDriversTable.ascx.cs" Inherits="Taksopark.WebForms.UserControls.TaxiDriversTable" %>
<link href="../Styles/AdminStyles.css" rel="stylesheet" />
<%--<link href="../Styles/Admin.css" rel="stylesheet" />--%>
<div class="centerDiv">
    <asp:GridView runat="server" ID="TaxiDriversGV" AllowPaging="true" PageSize="10"
        OnPageIndexChanging="TaxiDriversGV_PageIndexChanging" DataSourceID="allTaxiDriversDS"
        AutoGenerateColumns="true" CssClass="gvMain">
        <%--<Columns>
            <asp:ButtonField HeaderText="Edit User" Text="Edit" CommandName="Select" />
        </Columns>--%>
        <HeaderStyle CssClass="gvHeader" />
        <SelectedRowStyle CssClass="gvSelectedRow" />
    </asp:GridView>
</div>