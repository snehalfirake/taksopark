<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RequestInfoPage.Default" %>

<!DOCTYPE HTML>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Request options</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" media="screen" href="style.css" />
    <link rel="stylesheet" type="text/css" media="screen" href="menu/css/simple_menu.css" />
    <script type="text/javascript" src="js/jquery.min.js"></script>
</head>

<body>
    <form runat="server">
        <div class="header">
            <div id="site_title">
                <a href="index.html">
                    <img src="img/logo.png" /></a>
            </div>
            <ol id="menu">
                <li class="active_menu_item"><a href="#">Diapatcher Options</a>
                    <ol>
                        <li><a href="#">Menu Item 1</a></li>
                        <li><a href="#">Menu Item 2</a></li>
                    </ol>
                </li>
                <li><a href="#">Contact</a></li>
            </ol>
        </div>

        <div id="container">

            <%--<h1>Request Handler</h1>--%>

            <div class="one-half">

                <div class="heading_bg">
                    <h2>Request Info</h2>
                </div>

                <asp:FormView runat="server" ID="formView" BackColor="Black">
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td>Created time</td>
                                <td><asp:Label runat="server" Text='<%# Eval("CreatedTime") %>' /></td>
                            </tr>
                            <tr>
                                <td>Creator Id</td>
                                <td><asp:Label runat="server" Text='<%# Eval("CreatorId") %>' /></td>
                            </tr>
                            <tr>
                                <td>Phone Number</td>
                                <td><asp:Label runat="server" Text='<%# Eval("Phone") %>' /></td>
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
                                <td><asp:Label runat="server" Text='<%# Eval("StartPoint") %>'/></td>
                            </tr>
                            <tr>
                                <td>Destination</td>
                                <td><asp:Label runat="server" Text='<%# Eval("DestinationPoint") %>' /></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:FormView>

                <div class="heading_bg">
                    <h2>Request options</h2>
                </div>
                <p>
                    <asp:Label ForeColor="Black" Font-Size="Medium" runat="server" ID="labelSelectedDriverInfo" />
                </p>
                <p>
                    <asp:Button runat="server" Text="Submit" Height="35" Width="75" ID="submitButton" OnClick="submitButton_Click" />
                    <asp:Button runat="server" Text="Cancel" Height="35" Width="75" ID="cancelButton" OnClick="cancelButton_Click" />
                    <%--<a href="#" class="button">Submit</a>
                    <a href="#" class="button">Cancel</a>--%>
                </p>

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
                </div>

                <div class="heading_bg" style="clear: both">
                    <h2>Taxi on Map</h2>
                </div>

                <iframe width="465" height="350" src="http://maps.google.no/maps?f=q&amp;source=s_q&amp;hl=no&amp;geocode=&amp;q=Lypneva,+F%C3%B8rde&amp;aq=0&amp;oq=hafstadvegen+35&amp;sll=61.143235,9.09668&amp;sspn=17.454113,57.084961&amp;ie=UTF8&amp;hq=&amp;hnear=Hafstadvegen+35,+6800+F%C3%B8rde,+Sogn+og+Fjordane&amp;t=m&amp;z=14&amp;iwloc=A&amp;ll=49.8347675,24.0027365&amp;output=embed"></iframe>

            </div>
        </div>
        <div id="footer">
            <small>© Copyright 2014, A-Team</small>
        </div>
    </form>
</body>
</html>
