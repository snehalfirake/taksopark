<%@ Page Title="" Language="C#" MasterPageFile="~/Dispatcher.Master" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="Taksopark.WebForms.Dispatcher.Confirmation" %>

<%@ Register Src="~/UserControls/OrderInfo.ascx" TagPrefix="uc1" TagName="OrderInfo" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false">
    </script>
    <script type="text/javascript">
        var markers = [
        <asp:Repeater ID="rptMarkers" runat="server">
        <ItemTemplate>
                 {
                     "id": '<%# Eval("Id") %>',
                    "title": '<%# Eval("DriverInfo") %>',
                    "lat": '<%# Eval("Car.Latitude") %>',
                    "lng": '<%# Eval("Car.Longitude") %>',
                    "description": '<%# Eval("PhoneNumber") %>'
             }
        </ItemTemplate>
        <SeparatorTemplate>
            ,
        </SeparatorTemplate>
        </asp:Repeater>
        ];
    </script>
    <script src="../Scripts/ShowDriversOnMap.js"></script>
</asp:Content>

<asp:Content ID="content3" ContentPlaceHolderID="contentMenu" runat="server">
    Order details
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <div id="container">

                <div class="one">
                    <span class="right">
                        <br />
                        <asp:HyperLink runat="server" Text="Back to dashboard" CssClass="btn btn-s-md" BackColor="RoyalBlue"
                            ForeColor="White" NavigateUrl="~/WebForms/Order.aspx" />
                    </span>
                </div>
                <div class="one-half">
                    <div class="heading_bg">
                        <h2>Details</h2>
                    </div>
                    <asp:FormView runat="server" ID="formView">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <b>Id</b>
                                    </td>
                                    <td>
                                        <%# Eval("Id") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Date</b>
                                    </td>
                                    <td>
                                        <%# Eval("Date") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Time</b>
                                    </td>
                                    <td>
                                        <%# Eval("Time") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Created</b>
                                    </td>
                                    <td>
                                        <%# Eval("CreatedAt") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Start</b>
                                    </td>
                                    <td>
                                        <%# Eval("StartPoint") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Destination</b>
                                    </td>
                                    <td>
                                        <%# Eval("FinishPoint") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Estimated Price</b>
                                    </td>
                                    <td>
                                        <%# Eval("EstimatedPrice") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Status</b>
                                    </td>
                                    <td>
                                        <asp:Image runat="server" ImageUrl='<%# Eval("StatusIconUrl") %>' Width="17" Height="17" />&nbsp
                                <asp:Label runat="server" Text='<%# ((Taksopark.DAL.Enums.RequestStatusEnum)Eval("Status")).ToString() %>' />
                                    </td>
                                </tr>
                                <tr style='<%# Eval("Visibility") %>'>
                                    <td>
                                        <b>Additional</b>
                                    </td>
                                    <td>
                                        <%# Eval("Additional") %>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:FormView>
                    <br />
                    <div>
                    </div>
                </div>

                <div class="one-half last">
                    <div class="heading_bg">
                        <h2>Available drivers</h2>
                    </div>
                    <div>
                        <asp:DropDownList runat="server"
                            ID="driversDropDownList"
                            Width="100%"
                            CssClass="form-control" OnSelectedIndexChanged="driversDropDownList_SelectedIndexChanged" AutoPostBack="false" onchange="showFreeTaxiDrivers();">
                        </asp:DropDownList>

                        <br />
                        <%--<div class="btn-group btn-group-justified">--%>
                        <asp:Button runat="server" ID="confirmButton" Text="Submit" Width="33%" CssClass="btn btn-s-md btn-info" OnClick="ComfirmButton_Click" />
                        <asp:Button runat="server" ID="rejectButton" Text="Reject" Width="32%" CssClass="btn btn-s-md btn-danger" OnClick="rejectButton_Click" />
                        <asp:Button runat="server" ID="closeButton" Text="Close" Width="33%" CssClass="btn btn-s-md btn-success" OnClick="closeButton_Click" />
                        <%--</div>--%>
                    </div>

                    <div class="heading_bg" style="clear: both">
                        <h2>Taxi on Map</h2>
                    </div>

                    <div style="width: 465px; height: 350px;" id="driverMap"></div>
                    
                    <br />
                    <br />
                </div>

                <div class="one bottomLine">
                    <span class="right">
                        <br />
                        <asp:HyperLink runat="server" Text="Back to dashboard" CssClass="btn btn-s-md" BackColor="RoyalBlue"
                            ForeColor="White" NavigateUrl="~/WebForms/Order.aspx" />
                    </span>
                </div>
                <br />
                <br />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
