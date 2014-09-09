<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddNewTaxiDriver.ascx.cs" Inherits="Taksopark.WebForms.UserControls.AddNewTaxiDriver" %>
<link href="../Styles/Admin/AdminStyles.css" rel="stylesheet" />
<div class="centerDiv gvMain">
    <table>
        <tr>
            <td>
                <asp:Label runat="server" Text="Taxi Driver Name: "></asp:Label></td>
            <td>
                <asp:TextBox runat="server" ID="tbxTaxiDriverName"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="requiredUserName" runat="server"
                    ErrorMessage="Please, enter Name!" ControlToValidate="tbxTaxiDriverName"
                    CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupAdd">
                </asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" Text="Last Name: "></asp:Label></td>
            <td>
                <asp:TextBox runat="server" ID="tbxLastName"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="requiredTaxiDriverLastName" runat="server"
                    ErrorMessage="Please, enter Last Name!" ControlToValidate="tbxLastName"
                    CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupAdd">
                </asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" Text="Login: "></asp:Label></td>
            <td>
                <asp:TextBox runat="server" ID="tbxLogin"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="requiredLogin" runat="server"
                    ErrorMessage="Please, enter Login!" ControlToValidate="tbxLogin"
                    CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupAdd">
                </asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" Text="Password: "></asp:Label></td>
            <td>
                <asp:TextBox runat="server" ID="tbxPassword"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="requiredPassword" runat="server"
                    ErrorMessage="Please, enter Password!" ControlToValidate="tbxPassword"
                    CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupAdd">
                </asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" Text="Status: "></asp:Label></td>
            <td>
                <asp:TextBox runat="server" ID="tbxStatus"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="requiredStatus" runat="server"
                    ErrorMessage="Please, enter Status!" ControlToValidate="tbxStatus"
                    CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupAdd">
                </asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td colspan="3"><asp:Button runat="server" ID="btnAddNewTaxiDriver" Text="Add New Taxi Driver" 
                OnClick="btnAddNewTaxiDriver_Click" Width="100%" ValidationGroup="groupAdd" /></td>
        </tr>
    </table>
</div>