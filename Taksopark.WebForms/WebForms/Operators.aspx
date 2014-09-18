<%@ Page Title="Admin panel: Operators info" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Operators.aspx.cs" Inherits="Taksopark.WebForms.WebForms.Operators" Theme="Main" %>

<%@ Register Src="~/UserControls/OperatorsTable.ascx" TagPrefix="uc" TagName="OperatorsTable" %>
<%@ Register Src="~/UserControls/AddNewOperator.ascx" TagPrefix="uc" TagName="AddNewOperator" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="one">
        <div class="heading_bg">
            <h2>All Operators</h2>
            <div class="one-fourth" style="float: right;">
                <asp:Button runat="server" ID="btnAdd" Text="Add New Operator" Width="100%" OnClick="btnAdd_Click" />
            </div>
            
            <uc:OperatorsTable runat="server" id="OperatorsTable" DataSourceID="allOperatorsDS" OnGridViewClicked="OperatorsTable_GridViewClicked" />
        </div>
        <br />
        <br />
    </div>

    <asp:ObjectDataSource runat="server" ID="allOperatorsDS" TypeName="Taksopark.WebForms.WebForms.Operators" 
        SelectMethod="GetAllOperatorsFromRepository">
    </asp:ObjectDataSource>
</asp:Content>
