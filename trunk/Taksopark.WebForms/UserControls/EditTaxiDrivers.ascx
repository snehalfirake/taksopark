﻿<%@ Control Language="C#" AutoEventWireup="true" EnableTheming="true" CodeBehind="EditTaxiDrivers.ascx.cs" Inherits="Taksopark.WebForms.UserControls.EditTaxiDrivers" %>
<link href="../Styles/Admin/AdminStyles.css" rel="stylesheet" />

<div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="centerDivLonger">
                <div>
                    <table>
                        <tr>
                            <td>
                                <asp:Label runat="server" Text="Find Taxi Driver by Id: "></asp:Label></td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlFindingCategory" CssClass="ddlFindingCategory" 
                                    Width="220">
                                    <asp:ListItem Text="Id"></asp:ListItem>
                                    <asp:ListItem Text="Login"></asp:ListItem>
                                </asp:DropDownList></td>
                            <asp:HiddenField runat="server" ID="hiddenId" Value="" />
                            <td>
                            <td>
                                <asp:TextBox runat="server" ID="tbxFindTaxiDriverByCategory"></asp:TextBox></td>
                            <td>
                                <asp:Button runat="server" ID="btnFindTaxiDriverById" Text="Find" Width="100px"
                                    OnClick="btnFindTaxiDriverById_Click" /></td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="centerDiv">
                <div>
                    <table>
                        <tr>
                            <td>
                                <asp:Label runat="server" Text="Taxi Driver Name: "></asp:Label></td>
                            <td>
                                <asp:TextBox runat="server" ID="tbxEditTaxiDriverName"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2" class="centerErrorMesssage">
                                <asp:RequiredFieldValidator ID="requiredEditUserName" runat="server"
                                    ErrorMessage="Please, enter Taxi Driver Name!" ControlToValidate="tbxEditTaxiDriverName"
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
                            <td colspan="2" class="centerErrorMesssage">
                                <asp:RequiredFieldValidator ID="requiredEditLastName" runat="server"
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
                            <td colspan="2" class="centerErrorMesssage">
                                <asp:RequiredFieldValidator ID="requiredEditLogin" runat="server"
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
                            <td colspan="2" class="centerErrorMesssage">
                                <asp:RegularExpressionValidator ID="regExprValEditPhoneNumber" runat="server"
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
                            <td colspan="2" class="centerErrorMesssage">
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
                                <asp:TextBox runat="server" ID="tbxEditPassword"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2" class="centerErrorMesssage">
                                <asp:RequiredFieldValidator ID="requiredEditPassword" runat="server"
                                    ErrorMessage="Please, enter Password!" ControlToValidate="tbxEditPassword"
                                    CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupEdit">
                                </asp:RequiredFieldValidator></td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label runat="server" Text="Status: "></asp:Label></td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlEditStatus">
                                    <asp:ListItem Text="Active"></asp:ListItem>
                                    <asp:ListItem Text="Baned"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="centerErrorMesssage">
                                <asp:RequiredFieldValidator ID="requiredEditStatus" runat="server"
                                    ErrorMessage="Please, enter Status!" ControlToValidate="ddlEditStatus"
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
                                <asp:Button runat="server" ID="btnSaveEdit" Text="Save" Width="100%" OnClick="btnSaveEdit_Click"
                                    ValidationGroup="groupEdit" /></td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Button ID="btnCancelEdit" runat="server" OnClick="btnCancelEdit_Click" Text="Cancel" Width="100%" />
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
