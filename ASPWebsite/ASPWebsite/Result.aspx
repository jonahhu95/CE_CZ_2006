<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="ASPWebsite.Result" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1 style="font-size: 20px; font-family: 'ADAM.CG PRO'; text-transform: none !important; "><asp:Label ID="lblUsername" visibility="false" runat="server"></asp:Label></h1>
    <br />

    <h4>Calculation Result</h4>
    <br />
    <table style="width: 100%; font-family: Consolas;">
        <tr>
            <td style="width: 468px">Commute Cost</td>
            <td>
                <asp:Label ID="lbl3" runat="server" Text="Label"></asp:Label></td>
            <td>
                <asp:Label ID="lblcc" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 468px">Salary Satisfaction</td>
            <td>
                <asp:Label ID="lbl7" runat="server" Text="Label"></asp:Label></td>
            <td>
                <asp:Label ID="lblss" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 468px">Job Interest</td>
            <td>
                <asp:Label ID="lbl5" runat="server" Text="Label"></asp:Label></td>
            <td>
                <asp:Label ID="lblji" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 468px">Monthly Salary</td>
            <td>
                <asp:Label ID="lbl6" runat="server" Text="Label"></asp:Label></td>
            <td>
                <asp:Label ID="lblms" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 468px">Commute Time</td>
            <td>
                <asp:Label ID="lbl4" runat="server" Text="Label"></asp:Label></td>
            <td>
                <asp:Label ID="lblct" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 468px">Commute Comfort</td>
            <td>
                <asp:Label ID="lbl1" runat="server" Text="Label"></asp:Label></td>
            <td>
                <asp:Label ID="lbl2" runat="server" Text="Label"></asp:Label></td>
        </tr>
    </table>

    Job Satisfaction Score:
    <asp:Label ID="lblJSI" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Do Another Calculation" />
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" Text="Save Calculation" OnClick="Button2_Click" />
    <br />
    <br />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script>
        function openModal() {
            $('#Sign').modal({ show: true });
        }
        function openLoginModal() {
            $('#Login').modal({ show: true });
        }
    </script>
    <nav class="navbar navbar-expand-lg navbar-light fixed-top" id="mainNav">
        <div class="container">
            <a class="navbar-brand js-scroll-trigger" href="#page-top">3° Burn</a>
            <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
                Menu
          <i class="fa fa-bars"></i>
            </button>
            <div class="collapse navbar-collapse" id="navbarResponsive">
                <ul class="navbar-nav ml-auto">
                    <li class="nav-item">
                        <a class="nav-link" data-toggle="modal" style="margin-right: 10px;" href="#Login">Login</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" data-toggle="modal" href="#Sign">Sign Up</a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>

    <div class="modal fade" id="Login" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Login</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:Label ID="exampleInputEmail1" runat="server" Text="Email address"></asp:Label>
                    <asp:TextBox ID="tbEmail" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server"
                        ControlToValidate="tbEmail"
                        ErrorMessage="Email is required." CssClass="help-block text-danger" Font-Size="12px" ValidationGroup="group1"> Email is required
                    </asp:RequiredFieldValidator>

                    <br />
                    <asp:Label ID="exampleInputPassword1" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="tbPassword" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server"
                        ControlToValidate="tbPassword"
                        ErrorMessage="Password is required." CssClass="help-block text-danger" Font-Size="12px" ValidationGroup="group1"> Password is required
                    </asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="lblLoginWarning" runat="server"></asp:Label><br />
                </div>
                <div class="modal-footer">
                    <asp:Button ID="loginBtn" class="btn btn-primary" runat="server" Text="Login" OnClick="loginBtn_Click1" ValidationGroup="group1" />
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal -->
    <div class="modal fade" id="Sign" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Register</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:Label ID="Label1" runat="server" Text="Email address"></asp:Label>
                    <asp:TextBox ID="tbEmail2" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server"
                        ControlToValidate="tbEmail2"
                        ErrorMessage="Email is required." CssClass="help-block text-danger" Font-Size="12px" ValidationGroup="group2"> Email is required
                    </asp:RequiredFieldValidator>

                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="tbPassword2" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server"
                        ControlToValidate="tbPassword2"
                        ErrorMessage="Password is required." CssClass="help-block text-danger" Font-Size="12px" ValidationGroup="group2"> Password is required
                    </asp:RequiredFieldValidator>

                    <br />
                    <asp:Label ID="Label3" runat="server" Text="Confirm Password"></asp:Label>
                    <asp:TextBox ID="tbConfirmPW" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server"
                        ControlToValidate="tbConfirmPW"
                        ErrorMessage="Confirm password is required." CssClass="help-block text-danger" Font-Size="12px" ValidationGroup="group2"> Please enter confirm password
                    </asp:RequiredFieldValidator><br />

                    <asp:Label ID="LabelWarning" runat="server"></asp:Label>
                </div>
                <div class="modal-footer">
                    <%--<asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Login" OnClick="loginBtn_Click1" />--%>
                    <asp:Button ID="Button3" class="btn btn-primary" runat="server" Text="Confirm" OnClick="Button1_Click" ValidationGroup="group2" />
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
