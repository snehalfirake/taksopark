<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="LogOn.aspx.cs" Inherits="Taksopark.WebForms.WebForms.LogOn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
   <tr>
      <td>Email:</td>
      <td><input id="txtUserName" type="text" runat="server"></input></td>
      <td><ASP:RequiredFieldValidator ControlToValidate="txtUserName"
           Display="Static" ErrorMessage="*" runat="server" 
           ID="vUserName" /></td>
   </tr>
   <tr>
      <td>Password:</td>
      <td><input id="txtUserPass" type="password" runat="server"></input></td>
      <td><ASP:RequiredFieldValidator ControlToValidate="txtUserPass"
          Display="Static" ErrorMessage="*" runat="server" 
          ID="vUserPass" />
      </td>
   </tr>
</table>
    </div>
        <asp:Button runat="server" Text="LogOn" OnClick="LogOn_Click"/>
    </form>
</body>
</html>
