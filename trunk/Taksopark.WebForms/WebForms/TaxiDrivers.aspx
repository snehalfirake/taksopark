<%@ Page Title="Admin panel: Taxi Drivers info" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="TaxiDrivers.aspx.cs" Inherits="Taksopark.WebForms.WebForms.TaxiDrivers" Theme="Main" %>

<%@ Register Src="~/UserControls/TaxiDriversTable.ascx" TagPrefix="uc" TagName="TaxiDriversTable" %>
<%@ Register Src="~/UserControls/AddNewTaxiDriver.ascx" TagPrefix="uc" TagName="AddNewTaxiDriver" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="one">
        <div class="heading_bg">
            <h2>All Taxi Drivers</h2>
            <div class="one-fourth" style="float: right;">
                <asp:Button runat="server" ID="btnAdd" Text="Add New Taxi Driver" Width="100%" OnClick="btnAdd_Click" />
            </div>
            <uc:TaxiDriversTable runat="server" id="TaxiDriversTable1" DataSourceID="allTaxiDriversDS" 
                OnGridViewClicked="TaxiDriversTable1_GridViewClicked" />
        </div>
        <br />
        <br />
    </div>

    <%--<div class="one-half">
        <div class="heading_bg">
            <h2>Add New Taxi Driver</h2>
        </div>
        <uc:AddNewTaxiDriver runat="server" id="AddNewTaxiDriver" />
    </div>

    <div class="one-half last">
        <div class="heading_bg">

            <h2>Edit Taxi Driver</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Find Taxi Driver by Id: "></asp:Label></td>
                        <td>
                            <asp:TextBox runat="server" ID="tbxFindTaxiDriverById"></asp:TextBox></td>
                        <td>
                            <asp:Button runat="server" ID="btnFindTaxiDriverById" Text="Find" Width="100px"
                                OnClick="btnFindTaxiDriverById_Click" /></td>
                    </tr>
                </table>--%>

                <%--<table>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Taxi Driver Name: "></asp:Label></td>
                        <td>
                            <asp:TextBox runat="server" ID="tbxEditTaxiDriverName" ReadOnly="true"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="requiredEditUserName" runat="server"
                                ErrorMessage="Please, enter Taxi Driver Name!" ControlToValidate="tbxEditTaxiDriverName"
                                CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupEdit">
                            </asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Last Name: "></asp:Label></td>
                        <td>
                            <asp:TextBox runat="server" ID="tbxEditLastName" ReadOnly="true"></asp:TextBox></td>
                        <td><asp:RequiredFieldValidator ID="requiredEditLastName" runat="server"
                                ErrorMessage="Please, enter Last Name!" ControlToValidate="tbxEditLastName"
                                CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupEdit">
                            </asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Login: "></asp:Label></td>
                        <td>
                            <asp:TextBox runat="server" ID="tbxEditLogin" ReadOnly="true"></asp:TextBox></td>
                        <td><asp:RequiredFieldValidator ID="requiredEditLogin" runat="server"
                                ErrorMessage="Please, enter Login!" ControlToValidate="tbxEditLogin"
                                CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupEdit">
                            </asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Phone Number: "></asp:Label></td>
                        <td>
                            <asp:TextBox runat="server" ID="tbxEditPhoneNumber" ReadOnly="true"></asp:TextBox></td>
                        <td>
                            <asp:RegularExpressionValidator ID="regExprValEditPhoneNumber" runat="server"
                                ErrorMessage="Only 13 chahacters allowed!" ControlToValidate="tbxEditPhoneNumber"
                                CssClass="validatorsMessage" ValidationExpression="^[\d]{1,13}$"
                                Display="Dynamic" ValidationGroup="groupEdit"></asp:RegularExpressionValidator></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Email: "></asp:Label></td>
                        <td>
                            <asp:TextBox runat="server" ID="tbxEditEmail" ReadOnly="true"></asp:TextBox></td>
                        <td>
                            <asp:RegularExpressionValidator ID="regExprValEditEmail" runat="server"
                                ErrorMessage="Please, enter correct Email!" ControlToValidate="tbxEditEmail"
                                CssClass="validatorsMessage"
                                ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?"
                                Display="Dynamic" ValidationGroup="groupEdit"></asp:RegularExpressionValidator></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Password: "></asp:Label></td>
                        <td>
                            <asp:TextBox runat="server" ID="tbxEditPassword" ReadOnly="true"></asp:TextBox></td>
                        <td><asp:RequiredFieldValidator ID="requiredEditPassword" runat="server"
                                ErrorMessage="Please, enter Password!" ControlToValidate="tbxEditPassword"
                                CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupEdit">
                            </asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Status: "></asp:Label></td>
                        <td>
                            <asp:TextBox runat="server" ID="tbxEditStatus" ReadOnly="true"></asp:TextBox></td>
                        <td><asp:RequiredFieldValidator ID="requiredEditStatus" runat="server"
                                ErrorMessage="Please, enter Status!" ControlToValidate="tbxEditStatus"
                                CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupEdit">
                            </asp:RequiredFieldValidator></td>
                    </tr>
                   <%-- <tr>
                        <td>
                            <asp:Button runat="server" ID="btnSaveEdit" Text="Save" Width="100%" OnClick="btnSaveEdit_Click" /></td>
                        <td>
                            <asp:Button runat="server" ID="btnCancelEdit" Text="Cancel" Width="100%" /></td>
                    </tr>--%
                </table>--%>
            <%--</ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button runat="server" ID="btnSaveEdit" Text="Save" Width="100%" OnClick="btnSaveEdit_Click" 
            ValidationGroup="groupEdit" />
        <asp:Button runat="server" ID="btnCancelEdit" Text="Cancel" Width="100%" OnClick="btnCancelEdit_Click" />
    </div>

    <div class="one">
        <div class="heading_bg">
            <h2>All Taxi Drivers</h2>
            <uc:TaxiDriversTable runat="server" id="TaxiDriversTable" DataSourceID="allTaxiDriversDS" />
        </div>
        <br />
        <br />
    </div>--%>

    <asp:ObjectDataSource runat="server" ID="allTaxiDriversDS" TypeName="Taksopark.WebForms.WebForms.TaxiDrivers" 
        SelectMethod="GetAllTaxiDriversFromRepository">
    </asp:ObjectDataSource>
</asp:Content>
