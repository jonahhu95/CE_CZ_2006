<%@ Page Title="" Language="C#" MasterPageFile="~/Anonymous.Master" AutoEventWireup="true" CodeBehind="CalculationResult.aspx.cs" Inherits="ASPWebsite.CalculationResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 294px;
        }

        .score {
            font-size: 20pt;
            background: #D5EDEF;
            border-radius: 100%;
            padding: 50px;
            display: inline-block;
            text-align: center;
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
        <h2 class="text-center">Job Satisfaction Index</h2>
        <hr class="star-primary">
        <br />
        <div class="text-center"><asp:Label ID="lblJSI" runat="server" Text="Label" CssClass="score"></asp:Label></div>
        <br />
        <br />
        <table id="t1" style="width: 100%; font-family: Gadugi;">
            <tr>
                <th></th>
                <th></th>
                <th></th>
            </tr>
            <tr>
                <td class="auto-style1">Commute Cost</td>
                <td>
                    <asp:Label ID="lbl3" runat="server" Text="Label" CssClass=""></asp:Label></td>
                <td>
                    <asp:Label ID="lblcc" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style1">Salary Satisfaction</td>
                <td>
                    <asp:Label ID="lbl7" runat="server" Text="Label" CssClass=""></asp:Label></td>
                <td>
                    <asp:Label ID="lblss" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style1">Job Interest</td>
                <td>
                    <asp:Label ID="lbl5" runat="server" Text="Label" CssClass=""></asp:Label></td>
                <td>
                    <asp:Label ID="lblji" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style1">Monthly Salary</td>
                <td>
                    <asp:Label ID="lbl6" runat="server" Text="Label" CssClass=""></asp:Label></td>
                <td>
                    <asp:Label ID="lblms" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style1">Commute Time</td>
                <td>
                    <asp:Label ID="lbl4" runat="server" Text="Label" CssClass=""></asp:Label></td>
                <td>
                    <asp:Label ID="lblct" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style1">Commute Comfort</td>
                <td>
                    <asp:Label ID="lbl1" runat="server" Text="Label" CssClass=""></asp:Label></td>
                <td>
                    <asp:Label ID="lbl2" runat="server" Text="Label"></asp:Label></td>
            </tr>
        </table>

        <br />
        <asp:Panel ID="pnlUserRecord" runat="server">
            <asp:Button ID="btnHome" runat="server" class="btn btn-default" OnClick="btnHome_Click" Text="	← Bring me back!" />
            &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnSave" runat="server" class="btn btn-default" Text="Save Calculation" OnClick="Button2_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
        </asp:Panel>
        <br />
        <br />
        <asp:Panel ID="pnlFeedback" runat="server" Visible="false">
            Give us suggestion on how we can improve!☺
            <br />
            <asp:TextBox ID="tbFeedbackMessage" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox><br />
            <asp:Button ID="btnFeedback" runat="server" Text="Submit Feedback" OnClick="btnFeedback_Click" />
        </asp:Panel>
        <asp:Label ID="lblFeedbackMessage" runat="server" Text="" Visible="false"></asp:Label>
        <br />
        <br />
    </div>
</asp:Content>
