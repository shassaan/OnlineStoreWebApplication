<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerWebForm.aspx.cs" Inherits="OnlineStoreWebApplication.CustomerWebForm" MasterPageFile="~/MySite.Master"%>
<asp:Content runat="server" ID="title" ContentPlaceHolderID="title"> 
    <title>Customer WebForm</title>
</asp:Content>

<asp:Content runat="server" id="Customer" ContentPlaceHolderID="WebForms">
       <div class="container">
       <h1>Customer</h1>
        <div class="row">
            <h4>Login Here</h4>
            <div class="col-md-10">
                        
                        <table>
                            <tr>
                                <td><asp:Label ID="UserIdLabel" runat="server" Text="User-Id"></asp:Label></td>
                                <td><asp:TextBox ID="UserIdTextBox" runat="server" CssClass="form-control"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="PasswordLoginLabel" runat="server" Text="Password"></asp:Label></td>
                                <td><asp:TextBox ID="PasswordLoginTextBox" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td><asp:Button ID="LoginButton" runat="server" Text="Login" class="btn btn-info" OnClick="LoginButton_Click"/></td>
                            </tr>
                        </table>
                   </div>
       </div>
           <hr />
       <div class="row">
            <h4>Signup Here</h4>
           <div class="col-md-2">
               <asp:Image ID="SignUpImage" ImageUrl="~/Images/lock.svg" runat="server" Height="200px" Width="200px"/>
           </div>
           <div class="col-md-4" >
                      
                       <table>
                           <tr>
                               <td><asp:Label ID="FirstNameLabel" runat="server" Text="First Name"></asp:Label></td>
                               <td><asp:TextBox ID="FirstNameTextBox" runat="server" CssClass="form-control"></asp:TextBox></td>
                           </tr>
                           <tr>
                               <td><asp:Label ID="LastNameLabel" runat="server" Text="Last Name"></asp:Label></td>
                               <td><asp:TextBox ID="LastNameTextBox" runat="server" CssClass="form-control"></asp:TextBox></td>
                           </tr>
                           <tr>
                               <td><asp:Label ID="GenderLabel" runat="server" Text="Gender"></asp:Label></td>
                               <td>
                                   <asp:RadioButton ID="RdBtnM" GroupName="Gender" runat="server" AutoPostBack="true" Text="Male" OnCheckedChanged="RdBtnM_CheckedChanged" Checked="True"/>
                                   <asp:RadioButton ID="RdBtnF" GroupName="Gender" runat="server" AutoPostBack="true" Text="Female"/>
                               </td>
                           </tr>
                           <tr>
                               <td><asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label></td>
                               <td><asp:TextBox ID="EmailTextBox" runat="server" CssClass="form-control"></asp:TextBox></td>
                           </tr>
                           <tr>
                               <td><asp:Label ID="PasswordLabel" runat="server" Text="Choose Password"></asp:Label></td>
                               <td><asp:TextBox ID="PasswordTextBox" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox></td>
                           </tr>
                           <tr>
                               <td><asp:Label ID="ConfirmPasswordLabel" runat="server" Text="Confirm"></asp:Label></td>
                               <td><asp:TextBox ID="ConfirmPasswordTextBox" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox></td>
                           </tr>
                           <tr>
                               <td><asp:Button ID="SignupButton" runat="server" Text="Signup" CssClass="btn btn-success" OnClick="SignupButton_Click"/></td>
                           </tr>
                       </table>
                 </div>
               
              
           <div class="col-md-2">
               <table>
                   <tr>
                       <td><div class="img-thumbnail"><asp:Image ID="CustomerImage" runat="server" Height="150px" Width="150px"/></div></td>
                   </tr>
                   <tr>
                       <td><asp:FileUpload ID="ImageFileUpload" runat="server" CssClass="form-control"/></td>
                   </tr>
               </table>
           </div>
       </div>
            <asp:Label ID="WaitForIdLabel" runat="server" Text="Wait For id.."></asp:Label>
  </div>
</asp:Content>

