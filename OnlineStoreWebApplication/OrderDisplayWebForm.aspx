<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderDisplayWebForm.aspx.cs" Inherits="OnlineStoreWebApplication.OrderDisplayWebForm" MasterPageFile="~/MySite.Master"%>
<asp:Content ID="OrderDisplayWebForm" ContentPlaceHolderID="WebForms" runat="server">
    <asp:Button ID="DisplayButton" runat="server" Text="Display Orders" CssClass="btn btn-info" OnClick="DisplayButton_Click"/>
    <asp:Calendar ID="Calendar" runat="server"></asp:Calendar>
    <br />
    <br />
    <asp:GridView ID="OrdersGridView" runat="server" CellPadding="4" ForeColor="Black" CellSpacing="2" OnRowDataBound="OrdersGridView_RowDataBound" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" >
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
</asp:Content>
