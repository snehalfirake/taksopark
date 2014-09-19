<%@ Control Language="C#" AutoEventWireup="true" EnableTheming="true" CodeBehind="EditOperators.ascx.cs" Inherits="Taksopark.WebForms.UserControls.EditOperators" %>
<link href="../Styles/Admin/AdminStyles.css" rel="stylesheet" />

<div class="centerDiv">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="centerDivLonger">
                <div>
                    <table>
                        <tr>
                            <td>
                                <asp:Label runat="server" Text="Find Operator by Id: "></asp:Label></td>
                            <td>
                                <asp:TextBox runat="server" ID="tbxFindOperatorById"></asp:TextBox></td>
                            <td>
                                <asp:Button runat="server" ID="btnFindOperatorById" Text="Find" Width="100px"
                                OnClick="btnFindOperatorById_Click" /></td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="centerDiv">
                <div>
                    <table>
                        <tr>
                            <td>
                                <asp:Label runat="server" Text="Operator Name: "></asp:Label></td>
                            <td>
                                <asp:TextBox runat="server" ID="tbxEditOperatorName"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2"><asp:RequiredFieldValidator ID="requiredEditOperatorName" runat="server"
                                    ErrorMessage="Please, enter Operator Name!" ControlToValidate="tbxEditOperatorName"
                                    CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupEdit">
                                </asp:RequiredFieldValidator></td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label runat="server" Text="Last Name: "></asp:Label></td>
                            <td>
                                <asp:TextBox runat="server" ID="tbxEditLastName"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2"><asp:RequiredFieldValidator ID="requiredEditLastName" runat="server"
                                    ErrorMessage="Please, enter Last Name!" ControlToValidate="tbxEditLastName"
                                    CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupEdit">
                                </asp:RequiredFieldValidator></td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label runat="server" Text="Login: "></asp:Label></td>
                            <td>
                                <asp:TextBox runat="server" ID="tbxEditLogin"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2"><asp:RequiredFieldValidator ID="requiredEditLogin" runat="server"
                                    ErrorMessage="Please, enter Login!" ControlToValidate="tbxEditLogin"
                                    CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupEdit">
                                </asp:RequiredFieldValidator></td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label runat="server" Text="Phone Number: "></asp:Label></td>
                            <td>
                                <asp:TextBox runat="server" ID="tbxEditPhoneNumber"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2"><asp:RegularExpressionValidator ID="regExprValEditPhoneNumber" runat="server"
                                    ErrorMessage="Only 13 chahacters allowed!" ControlToValidate="tbxEditPhoneNumber"
                                    CssClass="validatorsMessage" ValidationExpression="^[\d]{1,13}$"
                                    Display="Dynamic" ValidationGroup="groupEdit"></asp:RegularExpressionValidator></td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label runat="server" Text="Email: "></asp:Label></td>
                            <td>
                                <asp:TextBox runat="server" ID="tbxEditEmail"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2"><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                    ErrorMessage="Please, enter correct Email!" ControlToValidate="tbxEditEmail"
                                    CssClass="validatorsMessage"
                                    ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?"
                                    Display="Dynamic" ValidationGroup="groupEdit"></asp:RegularExpressionValidator></td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label runat="server" Text="Password: "></asp:Label></td>
                            <td>
                                <asp:TextBox runat="server" ID="tbxEditPassword"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2"><asp:RequiredFieldValidator ID="requiredEditPassword" runat="server"
                                    ErrorMessage="Please, enter Password!" ControlToValidate="tbxEditPassword"
                                    CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupEdit">
                                </asp:RequiredFieldValidator></td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label runat="server" Text="Status: "></asp:Label></td>
                            <td>
                                <asp:TextBox runat="server" ID="tbxEditStatus"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2"><asp:RequiredFieldValidator ID="requiredEditStatus" runat="server"
                                    ErrorMessage="Please, enter Status!" ControlToValidate="tbxEditStatus"
                                    CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupEdit">
                                </asp:RequiredFieldValidator></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Button runat="server" ID="btnSaveEdit" Text="Save" Width="100%" 
                                    OnClick="btnSaveEdit_Click" /></td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Button runat="server" ID="btnCancelEdit" Text="Cancel" Width="100%" 
                                    OnClick="btnCancelEdit_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                    </table>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
