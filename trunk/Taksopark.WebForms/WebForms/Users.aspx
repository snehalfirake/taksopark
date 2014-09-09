<%@ Page Title="Admin panel: Users info" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Taksopark.WebForms.WebForms.Users" %>

<%@ Register Src="~/UserControls/UsersTable.ascx" TagPrefix="uc" TagName="UsersTable" %>
<%@ Register Src="~/UserControls/AddNewUser.ascx" TagPrefix="uc" TagName="AddNewUser" %>
<%@ Register Src="~/UserControls/DeleteUser.ascx" TagPrefix="uc" TagName="DeleteUser" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="one">
        <div class="heading_bg">
            <h2>All Users</h2>
            <uc:UsersTable runat="server" ID="UsersTable" DataSourceID="allUsersDS" />
        </div>
    </div>

    <div class="one-half">
        <div class="heading_bg">
            <h2>Add New User</h2>
        </div>
        <uc:AddNewUser runat="server" id="AddNewUser" />

        <div class="heading_bg">
            <h2>Delete User</h2>
        </div>
        <uc:DeleteUser runat="server" id="DeleteUser" />
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

    <asp:ObjectDataSource runat="server" ID="allUsersDS" TypeName="Taksopark.WebForms.WebForms.Users" 
        SelectMethod="GetAllUsersFromRepository">
    </asp:ObjectDataSource>
</asp:Content>
