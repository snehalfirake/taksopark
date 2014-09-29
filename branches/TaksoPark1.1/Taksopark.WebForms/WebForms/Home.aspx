<%@ Page Title="Welcome" Language="C#" MasterPageFile="~/Dispatcher.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Taksopark.WebForms.Dispatcher.Home" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div id="container">
        <div id="welcome">
            <div id="picturebox">
                <img src="../img/demo/1.jpg" />
            </div>
            <div id="infobox">
                <h3>Welcome</h3>
                <br/>
                <a href="Order.aspx" class="button">View Orders</a>
            </div>
        </div>
    </div>
</asp:Content>
