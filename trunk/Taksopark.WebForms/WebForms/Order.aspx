<%@ Page Title="" Language="C#" MasterPageFile="~/Dispatcher.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="Taksopark.WebForms.Dispatcher.Order" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div id="container">
       <table width="100%">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Created at</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>123</td>
                    <td>12.09.2014 04:24 PM</td>
                    <td>
                        <div class="button-group">
                            <a class="button" href="Confirmation.aspx">Edit</a>
                            <a class="button danger" href="#">Delete</a>
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
   </div>
</asp:Content>