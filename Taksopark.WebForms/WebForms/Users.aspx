<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Admin.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Taksopark.WebForms.WebForms.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align:center">Users information</h2>
    <div id="usersInfo">
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
                <td>Ivan</td>
                <td>Ivaniyk</td>
                <td>hero</td>
                <td>123456</td>
                <td>user</td>
                <td>ok</td>
                <td><input type="submit" value="Edit" /></td>
                <td><input type="submit" value="Ban" /></td>
            </tr>
            <tr>
                <td>Oleh</td>
                <td>Petrov</td>
                <td>Olehzik</td>
                <td>olezhik22</td>
                <td>user</td>
                <td>ok</td>
                <td><input type="submit" value="Edit" /></td>
                <td><input type="submit" value="Ban" /></td>
            </tr>
            <tr>
                <td>Katia</td>
                <td>Shevchenko</td>
                <td>kattia</td>
                <td>qwerty123456</td>
                <td>user</td>
                <td>ok</td>
                <td><input type="submit" value="Edit" /></td>
                <td><input type="submit" value="Ban" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
