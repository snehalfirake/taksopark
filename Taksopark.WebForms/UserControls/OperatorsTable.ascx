<%@ Control Language="C#" AutoEventWireup="true" EnableTheming="true" CodeBehind="OperatorsTable.ascx.cs" Inherits="Taksopark.WebForms.UserControls.OperatorsTable" %>
<link href="../Styles/AdminStyles.css" rel="stylesheet" />
<div>
    <asp:GridView runat="server" ID="OperatorsGV" AllowPaging="true" PageSize="20"
        OnPageIndexChanging="OperatorsGV_PageIndexChanging" DataSourceID="allOperatorsDS"
        AutoGenerateColumns="false" OnRowCommand="OperatorsGV_RowCommand">
        <Columns>
            <%--<asp:ButtonField HeaderText="Edit" Text="Edit" CommandName="Select" />--%>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:HyperLink runat="server" Text="Edit"
                        NavigateUrl='<%# "~/WebForms/EditOperator.aspx?id=" + Eval("Id") %>' />
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