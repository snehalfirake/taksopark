<%@ Control Language="C#" AutoEventWireup="true" EnableTheming="true" CodeBehind="UsersTable.ascx.cs" Inherits="Taksopark.WebForms.UserControls.UsersTable" %>
<link href="../Styles/AdminStyles.css" rel="stylesheet" />
<div>
    <asp:GridView runat="server" ID="UsersGV" AllowPaging="true" PageSize="20"
        OnPageIndexChanging="UsersGV_PageIndexChanging" DataSourceID="allUsersDS"
        AutoGenerateColumns="false" OnRowCommand="UsersGV_RowCommand" ShowHeaderWhenEmpty="true">
        <EmptyDataTemplate>
            <img src="../Images/Admin/NoDataAvailable.png" />
        </EmptyDataTemplate>
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:HyperLink runat="server" Text="Edit"
                        NavigateUrl='<%# "~/WebForms/EditUser.aspx?id=" + Eval("Id") %>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="User">
                <ItemTemplate>
                    <%# String.Format("{0}"+" "+"{1}",Eval("UserName"),Eval("LastName"))  %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Login">
                <ItemTemplate>
                    <%# Eval("Login") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Phone Number">
                <ItemTemplate>
                    <%# Eval("PhoneNumber") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Email">
                <ItemTemplate>
                    <%# Eval("Email") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <%# Eval("Status") %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="gvHeader" />
        <SelectedRowStyle CssClass="gvSelectedRow" />
    </asp:GridView>
</div>