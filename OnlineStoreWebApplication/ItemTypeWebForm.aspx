<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemTypeWebForm.aspx.cs" Inherits="OnlineStoreWebApplication.ItemTypeWebForm" MasterPageFile="~/MySite.Master" %>

<asp:Content ID="headIT" ContentPlaceHolderID="title" runat="server">
    <title>Item Type Entry Form.</title>
</asp:Content>
<asp:Content ID="ItemType" ContentPlaceHolderID="WebForms" runat="server">
        <div class="container">
            <h1>Insert Item Type</h1>
            <table>
                <tr>
                    <asp:Image ID="TypeImage" runat="server" Width="150px" Height="150px" CssClass="img-thumbnail"/>
                </tr>
                <tr>
                    <td><asp:Label ID="ItemTypeIdLabel" runat="server" Text="Type Id" ></asp:Label></td>
                    <td><asp:TextBox ID="ItemTypeIdTextBox" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="ItemTypeLabel" runat="server" Text="Type"></asp:Label></td>
                    <td><asp:TextBox ID="ItemTypeTextBox" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="ItemNameLabel" runat="server" Text="Name"></asp:Label></td>
                    <td><asp:TextBox ID="ItemNameTextBox" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label" runat="server" Text="Name"></asp:Label></td>
                    <td><asp:FileUpload ID="ImageFileUpload" runat="server" /></td>
                </tr>
                <tr>
                    <td><asp:Button ID="InsertItemTypeButton" runat="server" Text="Save" class="btn btn-info" OnClick="InsertItemTypeButton_Click"/></td>
                </tr>
            </table>
        </div>
   </asp:Content>