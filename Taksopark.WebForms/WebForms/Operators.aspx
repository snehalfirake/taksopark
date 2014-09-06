<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Admin.Master" AutoEventWireup="true" CodeBehind="Operators.aspx.cs" Inherits="Taksopark.WebForms.WebForms.Operators" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align:center">Operators information</h2>
    <div id="operatorsInfo">
        <table style="width: 500px; border-style:double; margin:0 24% 0 24%; width:52%; text-align:center;">
            <thead>
                <tr>
                    <td><b>Name</b></td>
                    <td><b>LastName</b></td>
                    <td><b>Login</b></td>
                    <td><b>Password</b></td>
                    <td><b>Role</b></td>
                    <td><b>Status</b></td>
                </tr>
            </thead>
            <tr>
                <td>Petro</td>
                <td>Savchuk</td>
                <td>petia</td>
                <td>superman</td>
                <td>operator</td>
                <td>ok</td>
                <td><input type="submit" value="Edit" /></td>
                <td><input type="submit" value="Ban" /></td>
            </tr>
            <tr>
                <td>Iryna</td>
                <td>Hyra</td>
                <td>irinka</td>
                <td>kvitochka</td>
                <td>operator</td>
                <td>ok</td>
                <td><input type="submit" value="Edit" /></td>
                <td><input type="submit" value="Ban" /></td>
            </tr>
            <tr>
                <td>Vasyl</td>
                <td>Savckenko</td>
                <td>sava</td>
                <td>frgt564</td>
                <td>operator</td>
                <td>ok</td>
                <td><input type="submit" value="Edit" /></td>
                <td><input type="submit" value="Ban" /></td>
            </tr>
            <tr>
                <td><input type="text" style="width:40px;" /></td>
                <td><input type="text" style="width:40px;"/></td>
                <td><input type="text" style="width:40px;"/></td>
                <td><input type="text" style="width:40px;"/></td>
                <td><input type="text" style="width:40px;"/></td>
                <td><input type="text" style="width:40px;"/></td>
                <td><input type="submit" value="Add" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
