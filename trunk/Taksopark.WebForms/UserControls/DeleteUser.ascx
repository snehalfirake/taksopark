<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeleteUser.ascx.cs" Inherits="Taksopark.WebForms.UserControls.DeleteUser" %>
<link href="../Styles/Admin/AdminStyles.css" rel="stylesheet" />
<table>
    <tr>
        <td>
            <asp:Label runat="server" ID="lblDeleteUser" Text="Delete User with ID:"></asp:Label></td>
        <td>
            <asp:TextBox runat="server" ID="tbxDeleteUser"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator runat="server" ID="requiredFieldDeleteUser" 
                ErrorMessage="Please, enter User ID!" ControlToValidate="tbxDeleteUser" 
                CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupDelete">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator runat="server" ID="requiredNumberDeleteUser"
                ControlToValidate="tbxDeleteUser" ValidationExpression="^[0-9]+$"
                ErrorMessage="Please, enter number!" CssClass="validatorsMessage" 
                ValidationGroup="groupDelete" Display="Dynamic">
            </asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:Button runat="server" ID="btnDeleteUser" Text="Delete User" ValidationGroup="groupDelete" 
                OnClick="btnDeleteUser_Click" Width="100%" />
        </td>
    </tr>
</table>
