<%@ Page Title="Lviv Taxi: Edit Operator" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EditOperator.aspx.cs" Inherits="Taksopark.WebForms.WebForms.EditOperator" Theme="Main" %>

<%@ Register Src="~/UserControls/EditOperators.ascx" TagPrefix="uc" TagName="EditOperators" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/App_Themes/Main/MainStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="one">
        <div class="heading_bg">
            <h2>Edit Operator</h2>
        </div>
        <div>
            <uc:EditOperators runat="server" id="EditOperators" />
        </div>
    </div>
</asp:Content>
