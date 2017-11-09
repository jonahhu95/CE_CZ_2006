<%@ Page Title="" Language="C#" MasterPageFile="~/Anonymous.Master" AutoEventWireup="true" CodeBehind="CalculationResult.aspx.cs" Inherits="ASPWebsite.CalculationResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 294px;
        }

        .score {
            font-size: 20pt;
            color: rgb(68, 114, 196);
        }

        #t1 td {
            padding: 10px;
        }

        .hehe {
            font-family: Segoe Print;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="padding: 100px; padding-top: 200px;">

        <h4>Calculation Result</h4>
        <br />
        <asp:Label ID="lblHome" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="lblJob" runat="server" Text="Label"></asp:Label><br />
        <br />
        <br />
        <asp:Label ID="lblJSI" runat="server" Text="Label" CssClass="score"></asp:Label><br />
        <br />
        <table id="t1" style="width: 100%; font-family: Gadugi;">
            <tr>
                <td class="auto-style1">Commute Cost</td>
                <td>
                    <asp:Label ID="lbl3" runat="server" Text="Label" CssClass="hehe"></asp:Label></td>
                <td>
                    <asp:Label ID="lblcc" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style1">Salary Satisfaction</td>
                <td>
                    <asp:Label ID="lbl7" runat="server" Text="Label" CssClass="hehe"></asp:Label></td>
                <td>
                    <asp:Label ID="lblss" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style1">Job Interest</td>
                <td>
                    <asp:Label ID="lbl5" runat="server" Text="Label" CssClass="hehe"></asp:Label></td>
                <td>
                    <asp:Label ID="lblji" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style1">Monthly Salary</td>
                <td>
                    <asp:Label ID="lbl6" runat="server" Text="Label" CssClass="hehe"></asp:Label></td>
                <td>
                    <asp:Label ID="lblms" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style1">Commute Time</td>
                <td>
                    <asp:Label ID="lbl4" runat="server" Text="Label" CssClass="hehe"></asp:Label></td>
                <td>
                    <asp:Label ID="lblct" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style1">Commute Comfort</td>
                <td>
                    <asp:Label ID="lbl1" runat="server" Text="Label" CssClass="hehe"></asp:Label></td>
                <td>
                    <asp:Label ID="lbl2" runat="server" Text="Label"></asp:Label></td>
            </tr>
        </table>

        <br />
        <asp:Button ID="btnHome" runat="server" class="btn btn-default" OnClick="btnHome_Click" Text="	← Bring me back!" />
        &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnSave" runat="server" class="btn btn-default" Text="Save Calculation" OnClick="Button2_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:Panel ID="pnlFeedback" runat="server" Visible="false">
            <table>
                <tr>
                    What do you think about the index generated?
                </tr>
                <tr>
                    <td>Message: </td>
                    <td>
                        <asp:TextBox ID="tbFeedbackMessage" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
            </table>
        </asp:Panel>

        <br />
        <br />
    </div>
</asp:Content>
