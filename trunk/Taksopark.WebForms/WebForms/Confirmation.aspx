<%@ Page Title="" Language="C#" MasterPageFile="~/Dispatcher.Master" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="Taksopark.WebForms.Dispatcher.Confirmation" %>

<%@ Register Src="~/UserControls/Dispatcher/OrderInfo.ascx" TagPrefix="uc1" TagName="OrderInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div id="container">
        <div class="one-half">
            <div class="heading_bg">
                <h2>Order details</h2>
            </div>
            <uc1:OrderInfo runat="server" ID="orderInfo" />
            <%--<asp:DetailsView runat="server" ID="detailsView1" AutoGenerateRows="false">
                <Fields>
                    <asp:BoundField DataField="id" HeaderText="Id" />
                    <asp:BoundField DataField="RequesTime" HeaderText="Created At" />
                    <asp:BoundField DataField="phoneNumber" HeaderText="Phone" />
                    <asp:BoundField DataField="startPoint" HeaderText="Start Point" />
                    <asp:BoundField DataField="finishPoint" HeaderText="Destination Point" />
                    <asp:BoundField DataField="status" HeaderText="Status" />
                </Fields>
            </asp:DetailsView>--%>

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
                                <b>Status</b>
                            </td>
                            <td>
                                <asp:Image runat="server" ImageUrl='<%# Eval("StatusIconUrl") %>' Width="17" Height="17" />&nbsp
                                <asp:Label runat="server" Text='<%# ((Taksopark.DAL.Enums.UserStatusEnum)Eval("Status")).ToString() %>' />
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
                    CssClass="form-control">
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

            <iframe width="465" height="350" src="http://maps.google.no/maps?f=q&amp;source=s_q&amp;hl=no&amp;geocode=&amp;q=Lypneva,+F%C3%B8rde&amp;aq=0&amp;oq=hafstadvegen+35&amp;sll=61.143235,9.09668&amp;sspn=17.454113,57.084961&amp;ie=UTF8&amp;hq=&amp;hnear=Hafstadvegen+35,+6800+F%C3%B8rde,+Sogn+og+Fjordane&amp;t=m&amp;z=14&amp;iwloc=A&amp;ll=49.8347675,24.0027365&amp;output=embed"></iframe>

        </div>
    </div>

    <asp:ObjectDataSource runat="server" ID="ordersDataSource" TypeName="Taksopark.WebForms.Dispatcher.Confirmation" SelectMethod="GetRequest">
        <SelectParameters>
            <asp:QueryStringParameter Name="id" QueryStringField="id" />
        </SelectParameters>
    </asp:ObjectDataSource>

</asp:Content>
