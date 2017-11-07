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
                 <asp:BoundField DataField="salary" HeaderText="Salary" />
                 <asp:BoundField DataField="salarySatisfaction" HeaderText="Salary Rating" />
                 <asp:BoundField DataField="jobInterest" HeaderText="Job Rating" />
                 <asp:BoundField DataField="JSIScore" HeaderText="Satisfaction Index" />
                 <asp:BoundField HeaderText="Money is important to me" />
                 <asp:BoundField HeaderText="Interest is important to me" />
                 <asp:BoundField HeaderText="Both money and interest is important to me" />
             </Columns>
         </asp:GridView><br />
         </div>
</asp:Content>
