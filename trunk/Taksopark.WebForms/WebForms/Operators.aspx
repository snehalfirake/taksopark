<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Operators.aspx.cs" Inherits="Taksopark.WebForms.WebForms.Operators" %>

<%@ Register Src="~/UserControls/OperatorsTable.ascx" TagPrefix="uc" TagName="OperatorsTable" %>
<%@ Register Src="~/UserControls/AddNewOperator.ascx" TagPrefix="uc" TagName="AddNewOperator" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="one">
        <div class="heading_bg">
            <h2>All operators</h2>
            <uc:OperatorsTable runat="server" id="OperatorsTable" DataSourceID="allOperatorsDS" />
        </div>
    </div>

    <div class="one-half">
        <div class="heading_bg">
            <h2>Add New Operator</h2>
        </div>
        <uc:AddNewOperator runat="server" id="AddNewOperator" />
    </div>

    <div class="one-half last">
        <div class="heading_bg">

            <h2>Edit Operator</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
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

                <table>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Operator Name: "></asp:Label></td>
                        <td>
                            <asp:TextBox runat="server" ID="tbxEditOperatorName" ReadOnly="true"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="requiredEditOperatorName" runat="server"
                                ErrorMessage="Please, enter Operator Name!" ControlToValidate="tbxEditOperatorName"
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

    <asp:ObjectDataSource runat="server" ID="allOperatorsDS" TypeName="Taksopark.WebForms.WebForms.Operators" 
        SelectMethod="GetAllOperatorsFromRepository">
    </asp:ObjectDataSource>
</asp:Content>
