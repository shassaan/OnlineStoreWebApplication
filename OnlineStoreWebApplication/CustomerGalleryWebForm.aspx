<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerGalleryWebForm.aspx.cs" Inherits="OnlineStoreWebApplication.CustomerGalleryWebForm" MasterPageFile="~/MySite.Master"%>

<asp:Content runat="server" ContentPlaceHolderID="title" ID="title">
    <title>Customer Gallery</title>
</asp:Content>
<asp:Content runat="server" ID="CustomerGallery" ContentPlaceHolderID="WebForms">
            <h1>Customer Gallery</h1>
             <asp:Label ID="ErrorLabel" runat="server" Text="" Visible="false" CssClass="alert alert-danger"></asp:Label>
        <div class="container">
            <table align="center">
                <tr>
                    <td><asp:Label ID="GenderLabel" runat="server" Text="Gender"></asp:Label></td>
                    <td>&nbsp</td>
                    <td><asp:DropDownList ID="GenderDropDownList" runat="server" CssClass="form-control">
                        <asp:ListItem Selected="True" Value="0">---select----</asp:ListItem>
                        
                        </asp:DropDownList></td>
                    <td>&nbsp</td>
                    <td><asp:Button ID="DisplayButton" runat="server" Text="Display" class="btn btn-info" OnClick="DisplayButton_Click"/></td>
                </tr>
                <tr>
                    <asp:DataList ID="ImageDataList" runat="server" RepeatDirection="Horizontal" CssClass="table" RepeatColumns="3" OnItemCommand="ImageDataList_ItemCommand" >
                      <ItemTemplate>
                        <div>
                            <%--data binding expression--%>
                            <asp:ImageButton ID="ImageButton" ImageUrl='<%#Eval("ImagePath") %>' runat="server" CssClass="btn btn-block" Width="175px" Height="175px" CommandArgument='<%# Eval("Cust_id") %>'/>
                            <b>Id:&nbsp</b><asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Cust_id") %>'></asp:Label>
                        </div>
                      </ItemTemplate>
                    </asp:DataList>
                </tr>
            </table>
             <asp:UpdateProgress runat="server">
               <ProgressTemplate>
                   <asp:Image ID="Image" runat="server" ImageUrl="~/Images/Gear.svg"/>
               </ProgressTemplate>
             </asp:UpdateProgress>
             <asp:ScriptManager ID="ScriptManager" runat="server" />
             <asp:UpdatePanel ID="UpdatePanel" runat="server">
              <ContentTemplate>
                  <asp:Timer runat="server" id="UpdateTimer" interval="5000" ontick="UpdateTimer_Tick" />
                <h2 align="center">Customer Info</h2>
                <table>
                    <tr>
                        <td><asp:Label ID="Label1" runat="server" Text="ID: "></asp:Label></td>
                        <td><asp:Label ID="IdLabel" runat="server" Text="------"></asp:Label></td>
                        <td><asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" CssClass="btn btn-info"/></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label2" runat="server" Text="Full Name: "></asp:Label></td>
                        <td><asp:Label ID="FNLabel" runat="server" Text="------"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label3" runat="server" Text="Email: "></asp:Label></td>
                        <td><asp:Label ID="EmailLabel" runat="server" Text="------"></asp:Label></td>
                    </tr>
                </table>
              </ContentTemplate>
           </asp:UpdatePanel>
        </div>

</asp:Content>
