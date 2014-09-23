﻿<%@ Control Language="C#" AutoEventWireup="true" EnableTheming="true" CodeBehind="AddNewOperator.ascx.cs" Inherits="Taksopark.WebForms.UserControls.AddNewOperator" %>
<link href="../Styles/Admin/AdminStyles.css" rel="stylesheet" />
<div>
    <table>
        <tr>
            <td>
                <asp:Label runat="server" Text="Operator Name: "></asp:Label></td>
            <td>
                <asp:TextBox runat="server" ID="tbxOperatorName"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" class="centerErrorMesssage">
                <asp:RequiredFieldValidator ID="requiredOperatorName" runat="server"
                    ErrorMessage="Please, enter Name!" ControlToValidate="tbxOperatorName"
                    CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupAdd">
                </asp:RequiredFieldValidator></td>
        </tr>

        <tr>
            <td>
                <asp:Label runat="server" Text="Last Name: "></asp:Label></td>
            <td>
                <asp:TextBox runat="server" ID="tbxLastName"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" class="centerErrorMesssage">
                <asp:RequiredFieldValidator ID="requiredOperatorLastName" runat="server"
                    ErrorMessage="Please, enter Last Name!" ControlToValidate="tbxLastName"
                    CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupAdd">
                </asp:RequiredFieldValidator></td>
        </tr>

        <tr>
            <td>
                <asp:Label runat="server" Text="Login: "></asp:Label></td>
            <td>
                <asp:TextBox runat="server" ID="tbxLogin"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" class="centerErrorMesssage">
                <asp:RequiredFieldValidator ID="requiredLogin" runat="server"
                    ErrorMessage="Please, enter Login!" ControlToValidate="tbxLogin"
                    CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupAdd">
                </asp:RequiredFieldValidator></td>
        </tr>

        <tr>
            <td>
                <asp:Label runat="server" Text="Phone Number: "></asp:Label></td>
            <td>
                <asp:TextBox runat="server" ID="tbxPhoneNumber"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" class="centerErrorMesssage">
                <asp:RegularExpressionValidator ID="regExprValPhoneNumber" runat="server"
                    ErrorMessage="Only 13 chahacters allowed!" ControlToValidate="tbxPhoneNumber"
                    CssClass="validatorsMessage" ValidationExpression="^[\d]{1,13}$"
                    Display="Dynamic" ValidationGroup="groupAdd"></asp:RegularExpressionValidator></td>
        </tr>

        <tr>
            <td>
                <asp:Label runat="server" Text="Email: "></asp:Label></td>
            <td>
                <asp:TextBox runat="server" ID="tbxEmail"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" class="centerErrorMesssage">
                <asp:RegularExpressionValidator ID="regExprValEmail" runat="server"
                    ErrorMessage="Please, enter correct Email!" ControlToValidate="tbxEmail"
                    CssClass="validatorsMessage" 
                    ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?"
                    Display="Dynamic" ValidationGroup="groupAdd"></asp:RegularExpressionValidator></td>
        </tr>

        <tr>
            <td>
                <asp:Label runat="server" Text="Password: "></asp:Label></td>
            <td>
                <asp:TextBox runat="server" ID="tbxPassword"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" class="centerErrorMesssage">
                <asp:RequiredFieldValidator ID="requiredPassword" runat="server"
                    ErrorMessage="Please, enter Password!" ControlToValidate="tbxPassword"
                    CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupAdd">
                </asp:RequiredFieldValidator></td>
        </tr>

        <tr>
            <td>
                <asp:Label runat="server" Text="Status: "></asp:Label></td>
            <td>
                <asp:DropDownList runat="server" ID="ddlStatus">
                    <asp:ListItem Text="Active"></asp:ListItem>
                    <asp:ListItem Text="Baned"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="centerErrorMesssage">
                <asp:RequiredFieldValidator ID="requiredStatus" runat="server"
                    ErrorMessage="Please, enter Status!" ControlToValidate="ddlStatus"
                    CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupAdd">
                </asp:RequiredFieldValidator></td>
        </tr>
    </table>
    <table>
        <tr>
            <td></td>
            <td runat="server" class="validatorsMessage" id="loginBooked"></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="3"><asp:Button runat="server" ID="btnAddNewOperator" Text="Add New Operator" 
                OnClick="btnAddNewOperator_Click" Width="100%" ValidationGroup="groupAdd" /></td>
        </tr>
        <tr>
            <td colspan="3"><asp:Button runat="server" ID="btnCancel" Text="Cancel" 
                OnClick="btnCancel_Click" Width="100%" /></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
        </tr>
    </table>
</div>