<%@ Page Title="" Language="C#" MasterPageFile="~/Anonymous.Master" AutoEventWireup="true" CodeBehind="Records.aspx.cs" Inherits="ASPWebsite.Records" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style></style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container" style="padding: 100px; padding-top: 200px;";>
         <h4> View Past Records </h4><br />
         <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False">
             <Columns>
                 <asp:BoundField DataField="workLocation.area" HeaderText="Work location" />
                 <asp:BoundField DataField="JSIScore" HeaderText="Satisfaction Index" />
                 <asp:BoundField DataField="salary" HeaderText="Salary" />
             </Columns>
         </asp:GridView>
         </div>
</asp:Content>
