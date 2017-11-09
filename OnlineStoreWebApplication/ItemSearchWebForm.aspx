<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemSearchWebForm.aspx.cs" Inherits="OnlineStoreWebApplication.ItemSearchWebForm" MasterPageFile="~/MySite.Master"%>
<asp:Content runat="server" ContentPlaceHolderID="title" ID="title">
    <title>Customer Gallery</title>
</asp:Content>
<asp:Content runat="server" ID="ItemSearch" ContentPlaceHolderID="WebForms">
     <asp:Label ID="ErrorLabel" runat="server" Text="" Visible="false" CssClass="alert alert-danger"></asp:Label>
        <div class="container">
            <h1>Item Search</h1>
            <table>
                <tr>
                    <td>Item Name:</td>
                    <td>&nbsp</td>
                    <td>
                        <asp:DropDownList ID="ItemNameDropDownList" runat="server" AppendDataBoundItems="true" CssClass="form-control" Width="200px">
                        <asp:ListItem>---Select---</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp</td>
                    <td><asp:Button ID="DisplayButton" runat="server" Text="Display" CssClass="btn btn-info" OnClick="DisplayButton_Click"/></td>
                </tr>
            </table>
            <br />
            <asp:DataList ID="ItemsDataList" runat="server">
                <ItemTemplate>
                    <div class="alert alert-info">
                        <div class="row">
                            <div class="col-md-4">
                                <asp:Image ID="ItemImage" ImageURl='<%# Eval("ImagePath")%>' runat="server" width="150px" Height="150px" CssClass="img-thumbnail" />
                            </div>
                            <div class="col-md-6">
                                <b>Type :&nbsp</b><asp:Label ID="ItemTypeLabel" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                                <br />
                                <b>Size :&nbsp</b><asp:Label ID="SizeLabel" runat="server" Text='<%#Eval("Quantity") %>'></asp:Label>
                                <br />
                                <b>Price :&nbsp</b><asp:Label ID="PriceLabel" runat="server" Text='<%#Eval("Price") %>'></asp:Label>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
</asp:Content>
