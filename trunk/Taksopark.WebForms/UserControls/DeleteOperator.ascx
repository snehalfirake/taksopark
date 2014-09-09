<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeleteOperator.ascx.cs" Inherits="Taksopark.WebForms.UserControls.DeleteOperator" %>
<link href="../Styles/Admin/AdminStyles.css" rel="stylesheet" />
<table>
    <tr>
        <td>
            <asp:Label runat="server" ID="lblDeleteOperator" Text="Delete Operator with ID:"></asp:Label></td>
        <td>
            <asp:TextBox runat="server" ID="tbxDeleteOperator"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator runat="server" ID="requiredFieldDeleteOperator" 
                ErrorMessage="Please, enter Operator ID!" ControlToValidate="tbxDeleteOperator" 
                CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupDelete">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator runat="server" ID="requiredNumberDeleteOperator"
                ControlToValidate="tbxDeleteOperator" ValidationExpression="^[0-9]+$"
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