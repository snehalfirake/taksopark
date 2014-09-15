<%@ Page Title="Admin panel: Users info" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Taksopark.WebForms.WebForms.Users" %>

<%@ Register Src="~/UserControls/UsersTable.ascx" TagPrefix="uc" TagName="UsersTable" %>
<%@ Register Src="~/UserControls/AddNewUser.ascx" TagPrefix="uc" TagName="AddNewUser" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link rel="stylesheet" type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.14/themes/redmond/jquery-ui.css" />
	<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.6.1/jquery.min.js"></script>
	<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.14/jquery-ui.min.js"></script>
	<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.14/i18n/jquery-ui-i18n.min.js"></script>
	<script type="text/javascript">
	    $(document).ready(function () {
	        $(function () {
	            $("#dialog").dialog({
	                autoOpen: false,
	                show: {
	                    effect: "blind",
	                    duration: 1000
	                },
                    width:400,
	                hide: {
	                    effect: "explode",
	                    duration: 1000
	            //    },
	            //    buttons: {
	            //    "Add New User": function () {
	            //        //$(this).dialog("close");
	            //        var table = document.getElementById("AddNewUser");
                //        var button = table.parentNode.id.
	            //    }
	            }
	            });

	            $("#opener").click(function () {
	                $("#dialog").dialog("open");
	            });
	        });
	    });
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <%--<div id="dialog" title="Add New User">
        <uc:AddNewUser runat="server" id="AddNewUser" />
    </div>--%>

    <div class="one-half">
        <div class="heading_bg">
            <h2>Add New User</h2>
        </div>
        <uc:AddNewUser runat="server" id="AddNewUser" />
        <%--<span id="opener" style="background-color:#f2cf0d; color:#000cee;">Add New User</span>--%>
    </div>
        
    <div class="one-half last">
        <div class="heading_bg">

            <h2>Edit User</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Find User by Id: "></asp:Label></td>
                        <td>
                            <asp:TextBox runat="server" ID="tbxFindUserById"></asp:TextBox></td>
                        <td>
                            <asp:Button runat="server" ID="btnFindUserById" Text="Find" Width="100px"
                                OnClick="btnFindUserById_Click" /></td>
                    </tr>
                </table>

                <table>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="User Name: "></asp:Label></td>
                        <td>
                            <asp:TextBox runat="server" ID="tbxEditUserName" ReadOnly="true"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="requiredEditUserName" runat="server"
                                ErrorMessage="Please, enter User Name!" ControlToValidate="tbxEditUserName"
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
                    </tr>--%>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button runat="server" ID="btnSaveEdit" Text="Save" Width="100%" OnClick="btnSaveEdit_Click" 
            ValidationGroup="groupEdit" />
        <asp:Button runat="server" ID="btnCancelEdit" Text="Cancel" Width="100%" OnClick="btnCancelEdit_Click" />
    </div>

    <div class="one">
        <div class="heading_bg">
            <h2>All Users</h2>
            <uc:UsersTable runat="server" ID="UsersTable" DataSourceID="allUsersDS" />
        </div>
        <br />
        <br />
    </div>

    <asp:ObjectDataSource runat="server" ID="allUsersDS" TypeName="Taksopark.WebForms.WebForms.Users" 
        SelectMethod="GetAllUsersFromRepository">
    </asp:ObjectDataSource>
</asp:Content>
