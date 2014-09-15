<%@ Page Title="" Language="C#" MasterPageFile="~/Dispatcher.Master" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="Taksopark.WebForms.Dispatcher.Confirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div id="container">
        <div class="one-half">
            <div class="heading_bg">
                <h2>Order details</h2>
            </div>
            <asp:FormView runat="server" ID="formView" BackColor="Black">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td>Created time</td>
                            <td>
                                <asp:Label runat="server" Text='<%# Eval("CreatedTime") %>' /></td>
                        </tr>
                        <tr>
                            <td>Creator Id</td>
                            <td>
                                <asp:Label runat="server" Text='<%# Eval("CreatorId") %>' /></td>
                        </tr>
                        <tr>
                            <td>Phone Number</td>
                            <td>
                                <asp:Label runat="server" Text='<%# Eval("Phone") %>' /></td>
                        </tr>
                        <tr>
                            <td>Status</td>
                            <td>
                                <asp:DropDownList runat="server" ID="statusList" Height="35" Width="125" OnSelectedIndexChanged="statusList_SelectedIndexChanged">
                                    <asp:ListItem Text="Active" />
                                    <asp:ListItem Text="Finished" />
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Start Point</td>
                            <td>
                                <asp:Label runat="server" Text='<%# Eval("StartPoint") %>' /></td>
                        </tr>
                        <tr>
                            <td>Destination</td>
                            <td>
                                <asp:Label runat="server" Text='<%# Eval("DestinationPoint") %>' /></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:FormView>
        </div>
        <div class="one-half last">
            <div class="heading_bg">
                <h2>Avaliable drivers</h2>
            </div>
            <div>
                <div>
                    <asp:DropDownList runat="server" ID="dropDownList" Width="465" Height="25" OnSelectedIndexChanged="dropDownList_SelectedIndexChanged">
                        <asp:ListItem Text="Orest - Lada Kalina" />
                        <asp:ListItem Text="Nazar - Audi A6" />
                    </asp:DropDownList>
                </div>
                <br />
                <a class="button">OK</a>
            </div>

            <div class="heading_bg" style="clear: both">
                <h2>Taxi on Map</h2>
            </div>

            <iframe width="465" height="350" src="http://maps.google.no/maps?f=q&amp;source=s_q&amp;hl=no&amp;geocode=&amp;q=Lypneva,+F%C3%B8rde&amp;aq=0&amp;oq=hafstadvegen+35&amp;sll=61.143235,9.09668&amp;sspn=17.454113,57.084961&amp;ie=UTF8&amp;hq=&amp;hnear=Hafstadvegen+35,+6800+F%C3%B8rde,+Sogn+og+Fjordane&amp;t=m&amp;z=14&amp;iwloc=A&amp;ll=49.8347675,24.0027365&amp;output=embed"></iframe>
        </div>
    </div>
</asp:Content>
