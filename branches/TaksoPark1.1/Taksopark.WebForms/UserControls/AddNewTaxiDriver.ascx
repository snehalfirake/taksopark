<%@ Control Language="C#" AutoEventWireup="true" EnableTheming="true" CodeBehind="AddNewTaxiDriver.ascx.cs" Inherits="Taksopark.WebForms.UserControls.AddNewTaxiDriver" %>
<link href="../Styles/Admin/AdminStyles.css" rel="stylesheet" />
<link href="../Styles/Admin/style.css" rel="stylesheet" />

<div class="centerDivForDrivers">
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
                    <asp:RequiredFieldValidator ID="requiredUserName" runat="server"
                        ErrorMessage="Please, enter Name!" ControlToValidate="tbxTaxiDriverName"
                        CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupAdd">
                    </asp:RequiredFieldValidator>
                    <asp:TextBox runat="server" ID="tbxTaxiDriverName"></asp:TextBox></td>
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
                    <asp:RequiredFieldValidator ID="requiredTaxiDriverLastName" runat="server"
                        ErrorMessage="Please, enter Last Name!" ControlToValidate="tbxLastName"
                        CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupAdd">
                    </asp:RequiredFieldValidator>
                    <asp:TextBox runat="server" ID="tbxLastName"></asp:TextBox></td>
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
                    <asp:RequiredFieldValidator ID="requiredLogin" runat="server"
                        ErrorMessage="Please, enter Login!" ControlToValidate="tbxLogin"
                        CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupAdd">
                    </asp:RequiredFieldValidator>
                    <asp:TextBox runat="server" ID="tbxLogin"></asp:TextBox></td>
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
                        ErrorMessage="Please, enter Phone Number!" ControlToValidate="tbxPhoneNumber"
                        CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupAdd">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regExprValPhoneNumber" runat="server"
                        ErrorMessage="Please, enter correct Phone Number!" ControlToValidate="tbxPhoneNumber"
                        CssClass="validatorsMessage" ValidationExpression="^[\d]{1,13}$"
                        Display="Dynamic" ValidationGroup="groupAdd"></asp:RegularExpressionValidator>
                    <asp:TextBox runat="server" ID="tbxPhoneNumber"></asp:TextBox></td>
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
                        ErrorMessage="Please, enter Email!" ControlToValidate="tbxEmail"
                        CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupAdd">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regExprValEmail" runat="server"
                        ErrorMessage="Please, enter correct Email!" ControlToValidate="tbxEmail"
                        CssClass="validatorsMessage"
                        ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?"
                        Display="Dynamic" ValidationGroup="groupAdd"></asp:RegularExpressionValidator>
                    <asp:TextBox runat="server" ID="tbxEmail"></asp:TextBox></td>
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
                    <asp:RequiredFieldValidator ID="requiredPassword" runat="server"
                        ErrorMessage="Please, enter Password!" ControlToValidate="tbxPassword"
                        CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupAdd">
                    </asp:RequiredFieldValidator>
                    <asp:TextBox runat="server" ID="tbxPassword"></asp:TextBox></td>
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
                    <asp:RequiredFieldValidator ID="requiredStatus" runat="server"
                        ErrorMessage="Please, enter Status!" ControlToValidate="ddlStatus"
                        CssClass="validatorsMessage" Display="Dynamic" ValidationGroup="groupAdd">
                    </asp:RequiredFieldValidator>
                    <asp:DropDownList runat="server" ID="ddlStatus">
                        <asp:ListItem Text="Active"></asp:ListItem>
                        <asp:ListItem Text="Inactive"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td></td>
                <td></td>
            </tr>

            <tr>
                <td colspan ="5" runat="server" class="validatorsMessage" id="loginBooked"></td>
            </tr>

            <tr>
                <td colspan="2">
                    <asp:Button runat="server" ID="btnAddNewTaxiDriver" Text="Add New Taxi Driver"
                        OnClick="btnAddNewTaxiDriver_Click" Width="100%" ValidationGroup="groupAdd" /></td>
                <td></td>
                <td colspan="2">
                    <asp:Button runat="server" ID="btnCancel" Text="Cancel"
                        OnClick="btnCancel_Click" Width="100%" /></td>
            </tr>
        </table>
    </div>
</div>
