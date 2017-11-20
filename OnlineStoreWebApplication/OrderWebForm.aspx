<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderWebForm.aspx.cs" Inherits="OnlineStoreWebApplication.OrderWebForm" MasterPageFile="~/MySite.Master" %>
<asp:Content ID="OrderWebForm" ContentPlaceHolderID="WebForms" runat="server">
    <asp:Label ID="UseridLabel" runat="server" Text="Label" CssClass="label label-info"></asp:Label>
    <div class="row">
        <div class="col-lg-6">
            <%--dropdownlist--%>
            <asp:DropDownList ID="TypeDropDownList" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                <asp:ListItem>---select----</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="SearchItems" runat="server" Text="Search" OnClick="SearchItems_Click" CssClass="btn btn-info"/>
        </div>
        <div class="col-lg-6">
            <%--CART--%>
            
        </div>
        
    </div>



    <div class="row">
        <div class="col-lg-6">
            <%--datalist--%>
            <asp:DataList ID="ItemsDataList" runat="server" RepeatColumns="3" OnItemCommand="ItemsDataList_ItemCommand">
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton" ImageUrl='<%#Eval("ImagePath") %>' runat="server" CssClass="btn btn-block" Width="175px" Height="175px" CommandArgument='<%# Eval("Item_id") %>'/>
                    <br />
                    <p><b>Type</b></p><asp:Label ID="ItemTypeLabel" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                    <br />
                    <p><b>Price</b></p><asp:Label ID="PriceLabel" runat="server" Text='<%#Eval("Price") %>'></asp:Label>
                    <br />
                    <p><b>Weight</b></p><asp:Label ID="QuantiyLabel" runat="server" Text='<%#Eval("Quantity") %>'></asp:Label>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div class="col-lg-6">
            <%------ItemsInformation---%>
             <p><b>Item Id</b></p><asp:Label ID="ItemIdLabel" runat="server" Text="------"></asp:Label>
             <br />
             <p><b>Weight</b></p><asp:Label ID="ItemWeightLabel" runat="server" Text="------"></asp:Label>
             <br />
             <p><b>Price</b></p><asp:Label ID="PriceLabel" runat="server" Text="------"></asp:Label>
             <br />
             <p><b>Enter Quantiy</b></p><asp:TextBox ID="QuantitiTextBox" runat="server" CssClass="form-control"></asp:TextBox>
             <br />
             <p><b>Total Price</b></p><asp:Label ID="TotalPriceLabel" runat="server" Text="------"></asp:Label>
             <br />
             <asp:Button ID="BuyButton" runat="server" Text="Buy" OnClick="BuyButton_Click"  CssClass="btn btn-info"/>
        </div>
    </div>
</asp:Content>