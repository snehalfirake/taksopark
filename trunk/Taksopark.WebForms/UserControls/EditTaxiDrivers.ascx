<%@ Control Language="C#" AutoEventWireup="true" EnableTheming="true" CodeBehind="EditTaxiDrivers.ascx.cs" Inherits="Taksopark.WebForms.UserControls.EditTaxiDrivers" %>
<link href="../Styles/Admin/AdminStyles.css" rel="stylesheet" />
<link href="../Styles/Admin/style.css" rel="stylesheet" />
<div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="centerDivLonger">
                <div>
                    <table>
                        <tr>
                            <td>
                                <asp:Label runat="server" Text="Find Taxi Driver by: " Width="110"></asp:Label></td>
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

            <div class="centerDivForDrivers">
                <%--class="centerDiv"--%>
                <div>


                    <table>
                        <tr>
                            <td colspan="2">
                                <asp:Label runat="server" Text="Driver" ForeColor="Orange" Font-Size="X-Large"></asp:Label></td>
                            <td rowspan="8"></td>
                            <td colspan="3">
                                <asp:Label runat="server" Text="Car" ForeColor="Orange" Font-Size="X-Large"></asp:Label></td>
                        </tr>

                        <tr>
                            <td style="width: 18%;">
                                <asp:Label runat="server" Text="Taxi Driver Name: "></asp:Label></td>
                            <td>
                                <asp:RequiredFieldValidator ID="requiredEditUserName" runat="server"
                                    ErrorMessage="Please, enter Taxi Driver Name!" ControlToValidate="tbxEditTaxiDriverName"
                                    CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupEdit">
                                </asp:RequiredFieldValidator>
                                <asp:TextBox runat="server" ID="tbxEditTaxiDriverName"></asp:TextBox>

                            </td>

                            <td style="width: 18%;">
                                <asp:Label runat="server" Text="Brand: "></asp:Label></td>
                            <td>
                                <asp:RequiredFieldValidator ID="requiredCarBrand" runat="server"
                                    ErrorMessage="Please, enter Brand!" ControlToValidate="tbxCarBrand"
                                    CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupAdd">
                                </asp:RequiredFieldValidator>
                                <asp:TextBox runat="server" ID="tbxCarBrand"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label runat="server" Text="Last Name: "></asp:Label></td>
                            <td>
                                <asp:RequiredFieldValidator ID="requiredEditLastName" runat="server"
                                    ErrorMessage="Please, enter Last Name!" ControlToValidate="tbxEditLastName"
                                    CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupEdit">
                                </asp:RequiredFieldValidator>
                                <asp:TextBox runat="server" ID="tbxEditLastName"></asp:TextBox></td>
                            <td>
                                <asp:Label runat="server" Text="Year: "></asp:Label></td>
                            <td>
                                <asp:RequiredFieldValidator ID="requiredCarYear" runat="server"
                                    ErrorMessage="Please, enter Year!" ControlToValidate="tbxCarYear"
                                    CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupAdd">
                                </asp:RequiredFieldValidator>
                                <asp:TextBox runat="server" ID="tbxCarYear"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label runat="server" Text="Login: "></asp:Label></td>
                            <td>
                                <asp:RequiredFieldValidator ID="requiredEditLogin" runat="server"
                                    ErrorMessage="Please, enter Login!" ControlToValidate="tbxEditLogin"
                                    CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupEdit">
                                </asp:RequiredFieldValidator>
                                <asp:TextBox runat="server" ID="tbxEditLogin"></asp:TextBox></td>
                            <td>
                                <asp:Label runat="server" Text="Start Work Time: "></asp:Label></td>
                            <td>
                                <asp:RequiredFieldValidator ID="requiredCarStartWorkTime" runat="server"
                                    ErrorMessage="Please, enter Start Work Time!" ControlToValidate="tbxCarStartWorkTime"
                                    CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupAdd">
                                </asp:RequiredFieldValidator>
                                <asp:TextBox runat="server" ID="tbxCarStartWorkTime"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label runat="server" Text="Phone Number: "></asp:Label></td>
                            <td>
                                <asp:RequiredFieldValidator ID="requiredPhoneNumber" runat="server"
                                    ErrorMessage="Please, enter Phone Number!" ControlToValidate="tbxEditPhoneNumber"
                                    CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupEdit">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="regExprValEditPhoneNumber" runat="server"
                                    ErrorMessage="Please, enter correct Phone Number!" ControlToValidate="tbxEditPhoneNumber"
                                    CssClass="validatorsMessage" ValidationExpression="^[\d]{1,13}$"
                                    Display="Dynamic" ValidationGroup="groupEdit"></asp:RegularExpressionValidator>
                                <asp:TextBox runat="server" ID="tbxEditPhoneNumber"></asp:TextBox></td>
                            <td>
                                <asp:Label runat="server" Text="Finish Work Time: "></asp:Label></td>
                            <td>
                                <asp:RequiredFieldValidator ID="requiredCarFinishWorkTime" runat="server"
                                    ErrorMessage="Please, enter Finish Work Time!" ControlToValidate="tbxCarFinishWorkTime"
                                    CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupAdd">
                                </asp:RequiredFieldValidator>
                                <asp:TextBox runat="server" ID="tbxCarFinishWorkTime"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label runat="server" Text="Email: "></asp:Label></td>
                            <td>
                                <asp:RequiredFieldValidator ID="requiredCarEmail" runat="server"
                                    ErrorMessage="Please, enter Email!" ControlToValidate="tbxEditEmail"
                                    CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupAdd">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="regExprValEditEmail" runat="server"
                                    ErrorMessage="Please, enter correct Email!" ControlToValidate="tbxEditEmail"
                                    CssClass="validatorsMessage"
                                    ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?"
                                    Display="Dynamic" ValidationGroup="groupEdit"></asp:RegularExpressionValidator>
                                <asp:TextBox runat="server" ID="tbxEditEmail"></asp:TextBox></td>
                            <td>
                                <asp:Label runat="server" Text="Latitude: "></asp:Label></td>
                            <td>
                                <asp:RequiredFieldValidator ID="requiredCarLatitude" runat="server"
                                    ErrorMessage="Please, enter Latitude!" ControlToValidate="tbxCarLatitude"
                                    CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupAdd">
                                </asp:RequiredFieldValidator>
                                <asp:TextBox runat="server" ID="tbxCarLatitude"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label runat="server" Text="Password: "></asp:Label></td>
                            <td>
                                <asp:RequiredFieldValidator ID="requiredEditPassword" runat="server"
                                    ErrorMessage="Please, enter Password!" ControlToValidate="tbxEditPassword"
                                    CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupEdit">
                                </asp:RequiredFieldValidator>
                                <asp:TextBox runat="server" ID="tbxEditPassword"></asp:TextBox></td>
                            <td>
                                <asp:Label runat="server" Text="Longitude: "></asp:Label></td>
                            <td>
                                <asp:RequiredFieldValidator ID="requiredCarLongitude" runat="server"
                                    ErrorMessage="Please, enter Longitude!" ControlToValidate="tbxCarLongitude"
                                    CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupAdd">
                                </asp:RequiredFieldValidator>
                                <asp:TextBox runat="server" ID="tbxCarLongitude"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label runat="server" Text="Status: "></asp:Label></td>
                            <td>
                                <asp:RequiredFieldValidator ID="requiredEditStatus" runat="server"
                                    ErrorMessage="Please, enter Status!" ControlToValidate="ddlEditStatus"
                                    CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupEdit">
                                </asp:RequiredFieldValidator>
                                <asp:DropDownList runat="server" ID="ddlEditStatus">
                                    <asp:ListItem Text="Active"></asp:ListItem>
                                    <asp:ListItem Text="Inactive"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td></td>
                            <td></td>
                        </tr>

                        <tr>
                            <td colspan="5" runat="server" class="validatorsMessage" id="loginBooked"></td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                <asp:Button runat="server" ID="btnSaveEdit" Text="Save" Width="100%"
                                    OnClick="btnSaveEdit_Click"
                                    ValidationGroup="groupEdit" /></td>
                            <td></td>
                            <td colspan="2">
                                <asp:Button ID="btnCancelEdit" runat="server" OnClick="btnCancelEdit_Click"
                                    Text="Cancel" Width="100%" /></td>
                        </tr>
                    </table>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
