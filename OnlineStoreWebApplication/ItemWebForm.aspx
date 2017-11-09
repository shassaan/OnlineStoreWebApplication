<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemWebForm.aspx.cs" Inherits="OnlineStoreWebApplication.ItemWebForm" MasterPageFile="~/MySite.Master" %>
<asp:Content ID="headI" ContentPlaceHolderID="title" runat="server">
    <title>Items Entry Form.</title>
</asp:Content>
<asp:Content ID="Items" ContentPlaceHolderID="WebForms" runat="server">
        <h1>Items Entry Form</h1>
        <div class="container">
            <table>
                <tr>
                    <td><asp:Label ID="TypeLabel" runat="server" Text="Type"></asp:Label></td>
                    <td>
                     <asp:DropDownList ID="TypeDropDownList" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                     <asp:ListItem Value="-1" Text="---select---"></asp:ListItem></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td><asp:Label ID="ItemIdLabel" runat="server" Text="Item-Id" ></asp:Label></td>
                    <td><asp:TextBox ID="ItemIdTextBox" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="WieghtSizeLabel" runat="server" Text="Wieght/Size" ></asp:Label></td>
                    <td><asp:TextBox ID="WieghtSizeTextBox" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="UnitPriceLabel" runat="server" Text="Unit Price"></asp:Label></td>
                    <td><asp:TextBox ID="UnitPriceTextBox" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Button ID="InsertItemButton" runat="server" Text="Save" class="btn btn-info" OnClick="InsertItemButton_Click"/></td>
                </tr>
            </table>
        </div>
</asp:Content>