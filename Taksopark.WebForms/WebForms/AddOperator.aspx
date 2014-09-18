<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddOperator.aspx.cs" Inherits="Taksopark.WebForms.WebForms.AddOperator" Theme="Main" %>

<%@ Register Src="~/UserControls/AddNewOperator.ascx" TagPrefix="uc" TagName="AddNewOperator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="one">
        <div class="heading_bg">
            <h2>Add New Operator</h2>
        </div>
        <div class="centerDiv">
            <uc:AddNewOperator runat="server" ID="AddNewOperator" />
        </div>
    </div>
</asp:Content>
