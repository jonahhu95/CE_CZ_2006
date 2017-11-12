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
            color: #4f6b72;
            font-family: "Trebuchet MS", Verdana, Arial, Helvetica, sans-serif;
        }

        #t1 td {
            padding: 10px;
        }

        .hehe {
            font-family: Segoe Print;
        }

        th {
            font: bold 11px "Trebuchet MS", Verdana, Arial, Helvetica, sans-serif;
            color: #4f6b72;
            border-right: 1px solid #C1DAD7;
            border-bottom: 1px solid #C1DAD7;
            border-top: 1px solid #C1DAD7;
            letter-spacing: 2px;
            text-transform: uppercase;
            text-align: left;
            padding: 6px 6px 6px 12px;
            background: #D5EDEF;
        }

        td {
            border-left: 1px solid #C1DAD7;
            border-right: 1px solid #C1DAD7;
            border-bottom: 1px solid #C1DAD7;
            background: #fff;
            padding: 6px 6px 6px 12px;
            color: #4f6b72;
        }

            td.alt {
                background: #F5FAFA;
                color: #797268;
            }

            td.boldtd {
                font: bold 13px "Trebuchet MS", Verdana, Arial, Helvetica, sans-serif;
                background: #D5EDEF;
                color: #797268;
            }

        .fdback {
            letter-spacing: 2px;
            text-transform: uppercase;
            font: bold 15px "Trebuchet MS", Verdana, Arial, Helvetica, sans-serif;
            color: #4f6b72;
            font-weight: normal;
            border: 1px solid #C1DAD7;
            padding: 30px;
        }

        .try {
            background: #D5EDEF;
            border: none;
            color: #4f6b72;
            font-weight: normal;
            padding: 10px;
            font-family: "Trebuchet MS", Verdana, Arial, Helvetica, sans-serif;
            color: #4f6b72;
            border-radius: 10%;
        }

        .savecalculationbtn{
            border: none;
            font-weight: normal;
            padding: 10px;
            font-family: "Trebuchet MS", Verdana, Arial, Helvetica, sans-serif;
            color: #4f6b72;
            border-radius: 10%;
        }

        .gobackbtn{
            border: none;
            font-weight: normal;
            padding: 10px;
            font-family: "Trebuchet MS", Verdana, Arial, Helvetica, sans-serif;
            color: white;
            border-radius: 10%;
            background-color: #81a59b;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="padding: 100px; padding-top: 200px;">
        <h2 class="text-center">Job Satisfaction Index</h2>
        <hr class="star-primary">
        <br />
        <div class="text-center">
            <asp:Label ID="lblJSI" runat="server" Text="Label" CssClass="score"></asp:Label>
        </div>
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
            <asp:Button ID="btnHome" runat="server" class="gobackbtn" OnClick="btnHome_Click" Text="← Bring me back!" />
            &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnSave" runat="server" class="savecalculationbtn" Text="Save Calculation" OnClick="Button2_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
        </asp:Panel>
        <br />
        <br />
        <asp:Panel ID="pnlFeedback" runat="server" Visible="false" CssClass="fdback">
            Give us suggestion on how we can improve!☺
            <br />
            <asp:TextBox ID="tbFeedbackMessage" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox><br />
            <asp:Button ID="btnFeedback" runat="server" Text="Submit Feedback" OnClick="btnFeedback_Click" CssClass="try" />
        </asp:Panel>
        <asp:Label ID="lblFeedbackMessage" runat="server" Text="" Visible="false"></asp:Label>
        <br />
        <br />
    </div>
</asp:Content>
