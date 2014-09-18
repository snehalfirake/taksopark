<%@ Page Title="" Language="C#" MasterPageFile="~/Dispatcher.Master" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="Taksopark.WebForms.Dispatcher.Confirmation" %>

<%@ Register Src="~/UserControls/Dispatcher/OrderInfo.ascx" TagPrefix="uc1" TagName="OrderInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div id="container">
        <div class="one-half">
            <div class="heading_bg">
                <h2>Order details</h2>
            </div>
            <uc1:OrderInfo runat="server" ID="OrderInfo" DataSourceID="ordersDataSource" />
            <br />
            <div>
                <asp:Label runat="server" ID="labelStatus" Text="Set Status: " ForeColor="Black" Font-Size="Larger" />
                <asp:DropDownList runat="server" ID="statusDropdownList" OnSelectedIndexChanged="statusDropdownList_SelectedIndexChanged" AutoPostBack="true" Width="150">
                    <asp:ListItem Text="Active" />
                    <asp:ListItem Text="InProgress" />
                    <asp:ListItem Text="Closed" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="one-half last">
            <div class="heading_bg">
                <h2>Avaliable drivers</h2>
            </div>
            <div>
                <asp:DropDownList runat="server"
                    ID="dropDownList"
                    Width="465" Height="25"
                    AutoPostBack="true"
                    OnSelectedIndexChanged="dropDownList_SelectedIndexChanged1">
                </asp:DropDownList>
                <br />
                <asp:Button runat="server" ID="ComfirmButton" Text="Submit" Width="100%" CssClass="button" OnClick="ComfirmButton_Click" />
            </div>

            <div class="heading_bg" style="clear: both">
                <h2>Taxi on Map</h2>
            </div>

            <iframe width="465" height="350" src="http://maps.google.no/maps?f=q&amp;source=s_q&amp;hl=no&amp;geocode=&amp;q=Lypneva,+F%C3%B8rde&amp;aq=0&amp;oq=hafstadvegen+35&amp;sll=61.143235,9.09668&amp;sspn=17.454113,57.084961&amp;ie=UTF8&amp;hq=&amp;hnear=Hafstadvegen+35,+6800+F%C3%B8rde,+Sogn+og+Fjordane&amp;t=m&amp;z=14&amp;iwloc=A&amp;ll=49.8347675,24.0027365&amp;output=embed"></iframe>
        </div>
    </div>

    <asp:ObjectDataSource runat="server" ID="ordersDataSource" TypeName="Taksopark.WebForms.Dispatcher.Confirmation"
        SelectMethod="GetRequest">
        <SelectParameters>
            <asp:QueryStringParameter Name="id" QueryStringField="id" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
