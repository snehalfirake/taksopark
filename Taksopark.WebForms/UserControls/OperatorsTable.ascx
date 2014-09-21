<%@ Control Language="C#" AutoEventWireup="true" EnableTheming="true" CodeBehind="OperatorsTable.ascx.cs" Inherits="Taksopark.WebForms.UserControls.OperatorsTable" %>
<link href="../Styles/AdminStyles.css" rel="stylesheet" />
<div>
    <asp:GridView runat="server" ID="OperatorsGV" AllowPaging="true" PageSize="20"
        OnPageIndexChanging="OperatorsGV_PageIndexChanging" DataSourceID="allOperatorsDS"
        AutoGenerateColumns="true" OnRowCommand="OperatorsGV_RowCommand">
        <Columns>
            <asp:ButtonField HeaderText="Edit" Text="Edit" CommandName="Select" />
        </Columns>
        <HeaderStyle CssClass="gvHeader" />
        <SelectedRowStyle CssClass="gvSelectedRow" />
    </asp:GridView>
</div>