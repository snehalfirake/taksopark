<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogOn.aspx.cs" Inherits="Taksopark.WebForms.WebForms.LogOn" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Authorization</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <link rel="stylesheet" href="../FutureStyle/css/app.v1.css" />
    <link rel="stylesheet" href="../FutureStyle/css/font.css" />
    <script src="../FutureStyle/css/app.v1.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <section id="content" class="m-t-lg wrapper-md animated fadeInUp">
            <a class="nav-brand">Taksopark Control Panel</a>
            <div class="row m-n">
                <div class="col-md-4 col-md-offset-4 m-t-lg">
                    <section class="panel">
                        <header class="panel-heading text-center">Sign in </header>
                        <div class="form-group">
                            <br />
                            <label class="control-label">Email</label>
                            <input id="txtUserName" type="text" runat="server" placeholder="test@example.com" class="form-control" />
                        </div>
                        <div class="form-group">
                            <label class="control-label">Password</label>
                            <input id="txtUserPass" type="password" class="form-control" runat="server" />
                        </div>
                        <div class="line line-dashed"></div>
                        <div class="form-group">
                            <asp:LinkButton runat="server" CssClass="pull-right m-t-xs" Text="Forgot password?"/>
                            <asp:Button runat="server" Text="SignIn" CssClass="btn btn-info" OnClick="LogOn_Click" />
                            <div class="line line-dashed"></div>
                            <p class="text-muted text-center"><small>Do not have an account?</small></p>
                            <asp:Button runat="server" CssClass="btn btn-white btn-block" Text="Create Account" />
                        </div>
                    </section>
                </div>
            </div>
        </section>
        <footer id="footer">
            <div class="text-center padder clearfix">
                <p>
                    <small>A-Team &copy; 2013</small>
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
