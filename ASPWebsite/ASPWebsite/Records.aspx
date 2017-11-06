<%@ Page Title="" Language="C#" MasterPageFile="~/Anonymous.Master" AutoEventWireup="true" CodeBehind="Records.aspx.cs" Inherits="ASPWebsite.Records" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container" style="padding: 100px; padding-top: 200px;";>
         <asp:GridView ID="gvData" runat="server"></asp:GridView>
         </div>
</asp:Content>
