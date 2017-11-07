<%@ Page Title="" Language="C#" MasterPageFile="~/Anonymous.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="ASPWebsite.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <div class="container" style="padding: 100px; padding-top: 200px;";>
         Username: <br />
         Home Location: <br />

         <asp:Button ID="Button1" runat="server" Text="Button" />
         </div>
</asp:Content>
