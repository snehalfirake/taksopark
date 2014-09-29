<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogOn.aspx.cs" Inherits="Taksopark.WebForms.WebForms.LogOn" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Authorization</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <link rel="stylesheet" href="../FutureStyle/css/app.v1.css" />
    <link rel="stylesheet" href="../FutureStyle/css/font.css" />
    <link  rel="stylesheet" href="../Styles/Admin/LogOn.css"/>
    <script src="../FutureStyle/css/app.v1.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <section id="content" class="m-t-lg wrapper-md animated fadeInUp">
            <a class="nav-brand">Taksopark Control Panel</a>
            <div class="row m-n">
                <div class="col-md-4 col-md-offset-4 m-t-lg" >
                    <section class="panel" style="height: 230px">
<%--                        <header class="panel-heading text-center">Sign in </header>--%>
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Provided login or password is incorect" ForeColor="Red" Width="100%"  CssClass="validatorsMessage" ></asp:CustomValidator>
                        <asp:RegularExpressionValidator runat="server"  CssClass="validatorsMessage" ForeColor="Red" Width="100%" ErrorMessage="Login must be less than 20 characters lenght"  ControlToValidate="txtUserName" ValidationExpression="^[\s\S]{0,20}$"></asp:RegularExpressionValidator>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator1"   CssClass="validatorsMessage"  ForeColor="Red" Width="100%" runat="server" ControlToValidate="txtUserName" ErrorMessage="Login Is Required"></asp:RequiredFieldValidator>
                  
                        <div class="form-group">
                            <br />
                            <label class="control-label">Login</label>
                            <input id="txtUserName" type="text" runat="server"  class="txtUserName1" />
                        </div>
                        <asp:RegularExpressionValidator CssClass="validatorsMessage" ForeColor="Red" Width="100%" runat="server" ErrorMessage="Password must be less than 15 characters lenght"  ControlToValidate="txtUserPass" ValidationExpression="^[\s\S]{0,15}$"></asp:RegularExpressionValidator>
                         <asp:RequiredFieldValidator  CssClass="validatorsMessage" ForeColor="Red" Width="100%" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUserPass" ErrorMessage="Password Is Required"></asp:RequiredFieldValidator>
                        <div class="form-group">
                           
                            <label class="control-label">Password</label>
                            <input id="txtUserPass" type="password" class="txtUserName1" runat="server" />

                        &nbsp;
                        </div>
                      
                        <div class="form-group">
<%--                            <asp:LinkButton runat="server" CssClass="pull-right m-t-xs" Text="Forgot password?"/>--%>
                            <asp:Button  runat="server" Text="Sign In" CssClass="btn-info2" OnClick="LogOn_Click" />
                        </div>
                    </section>
                </div>
            </div>
        </section>
        <footer id="footer">
            <div class="text-center padder clearfix">
                <p>
                    <small>A-Team &copy; 2014</small>
                </p>
            </div>
        </footer>
        <%--<div>
            <table>
                <tr>
                    <td>Email:</td>
                    <td>
                        <input id="txtUserName" type="text" runat="server"></input></td>
                    <td>
                        <asp:RequiredFieldValidator ControlToValidate="txtUserName"
                            Display="Static" ErrorMessage="*" runat="server"
                            ID="vUserName" /></td>
                </tr>
                <tr>
                    <td>Password:</td>
                    <td>
                        <input id="txtUserPass" type="password" runat="server"></input></td>
                    <td>
                        <asp:RequiredFieldValidator ControlToValidate="txtUserPass"
                            Display="Static" ErrorMessage="*" runat="server"
                            ID="vUserPass" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:Button runat="server" Text="LogOn" OnClick="LogOn_Click" />--%>
    </form>
</body>
</html>
