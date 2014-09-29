<%@ Page Title="Lviv Taxi: Operators" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Operators.aspx.cs" Inherits="Taksopark.WebForms.WebForms.Operators" Theme="Main" %>

<%@ Register Src="~/UserControls/OperatorsTable.ascx" TagPrefix="uc" TagName="OperatorsTable" %>
<%@ Register Src="~/UserControls/AddNewOperator.ascx" TagPrefix="uc" TagName="AddNewOperator" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="one">
        <div class="heading_bg">
            <h2>Operators</h2>
            <div class="one-fourth buttonAdd">
                <asp:Button runat="server" ID="btnAdd" Text="Add New Operator" Width="100%" OnClick="btnAdd_Click" />
            </div>
            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="one-third">
                        <div style="display: inline-block;">
                            <asp:Label runat="server" Text="Status: "></asp:Label>
                        </div>
                        <div style="display: inline-block; width: 150px;">
                            <asp:DropDownList runat="server" ID="ddlOperatorStatus" AutoPostBack="true" 
                                EnableTheming="false" CssClass="ddlStatusForFilter">
                                <asp:ListItem Text="All"></asp:ListItem>
                                <asp:ListItem Text="Active"></asp:ListItem>
                                <asp:ListItem Text="Inactive"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <br />
                        <br />
                    </div>
                    <uc:OperatorsTable runat="server" ID="OperatorsTable" DataSourceID="allOperatorsDS" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <br />
        <br />
    </div>

    <asp:ObjectDataSource runat="server" ID="allOperatorsDS" TypeName="Taksopark.WebForms.WebForms.Operators"
        SelectMethod="GetAllOperatorsFromRepository">
        <SelectParameters>
            <asp:ControlParameter Name="status" Type="String" ControlID="ddlOperatorStatus" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
