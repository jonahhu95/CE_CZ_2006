<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="ASPWebsite.Result" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%; font-family:Consolas;">
        <tr>
            <td>Commute Cost</td>
            <td><asp:Label ID="lbl3" runat="server" Text="Label"></asp:Label></td>
            <td>
                <asp:Label ID="lblcc" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>Salary Satisfaction</td>
            <td><asp:Label ID="lbl7" runat="server" Text="Label"></asp:Label></td>
            <td>
                <asp:Label ID="lblss" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>Job Interest</td>
            <td><asp:Label ID="lbl5" runat="server" Text="Label"></asp:Label></td>
            <td>
                <asp:Label ID="lblji" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>Monthly Salary</td>
            <td><asp:Label ID="lbl6" runat="server" Text="Label"></asp:Label></td>
            <td><asp:Label ID="lblms" runat="server" Text="Label"></asp:Label></td>
        </tr><tr>
            <td>Commute Time</td>
            <td><asp:Label ID="lbl4" runat="server" Text="Label"></asp:Label></td>
            <td><asp:Label ID="lblct" runat="server" Text="Label"></asp:Label></td>
        </tr><tr>
            <td>Commute Comfort</td>
            <td><asp:Label ID="lbl1" runat="server" Text="Label"></asp:Label></td>
            <td><asp:Label ID="lbl2" runat="server" Text="Label"></asp:Label></td>
        </tr>
    </table>

    Job Satisfaction Score: <asp:Label ID="lblJSI" runat="server" Text="Label"></asp:Label><br />

</asp:Content>
