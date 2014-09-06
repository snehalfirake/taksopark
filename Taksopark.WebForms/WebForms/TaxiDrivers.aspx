<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Admin.Master" AutoEventWireup="true" CodeBehind="TaxiDrivers.aspx.cs" Inherits="Taksopark.WebForms.WebForms.TaxiDrivers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align:center">Taxi drivers information</h2>
    <div id="driversInfo">
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
                <td>Volodia</td>
                <td>Mamchur</td>
                <td>vova</td>
                <td>vova123</td>
                <td>driver</td>
                <td>ok</td>
                <td><input type="submit" value="Edit" /></td>
                <td><input type="submit" value="Ban" /></td>
            </tr>
            <tr>
                <td>Oleksandr</td>
                <td>Zhyndor</td>
                <td>sasha</td>
                <td>batia5</td>
                <td>driver</td>
                <td>ok</td>
                <td><input type="submit" value="Edit" /></td>
                <td><input type="submit" value="Ban" /></td>
            </tr>
            <tr>
                <td>Oleh</td>
                <td>Kuziak</td>
                <td>oleh</td>
                <td>fer32</td>
                <td>driver</td>
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
