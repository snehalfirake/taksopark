<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeleteTaxiDriver.ascx.cs" Inherits="Taksopark.WebForms.UserControls.DeleteTaxiDriver" %>
<link href="../Styles/Admin/AdminStyles.css" rel="stylesheet" />
<table>
    <tr>
        <td>
            <asp:Label runat="server" ID="lblDeleteTaxiDriver" Text="Delete Taxi Driver with ID:"></asp:Label></td>
        <td>
            <asp:TextBox runat="server" ID="tbxDeleteTaxiDriver"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator runat="server" ID="requiredFieldDeleteTaxiDriver" 
                ErrorMessage="Please, enter Taxi Driver ID!" ControlToValidate="tbxDeleteTaxiDriver" 
                CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupDelete">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator runat="server" ID="requiredNumberDeleteTaxiDriver"
                ControlToValidate="tbxDeleteTaxiDriver" ValidationExpression="^[0-9]+$"
                ErrorMessage="Please, enter number!" CssClass="validatorsMessage" 
                ValidationGroup="groupDelete" Display="Dynamic">
            </asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:Button runat="server" ID="btnDeleteTaxiDriver" Text="Delete Taxi Driver" ValidationGroup="groupDelete" 
                OnClick="btnDeleteTaxiDriver_Click" Width="100%" />
        </td>
    </tr>
</table>