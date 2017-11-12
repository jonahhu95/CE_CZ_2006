<%@ Page Title="" Language="C#" MasterPageFile="~/Anonymous.Master" AutoEventWireup="true" CodeBehind="Records.aspx.cs" Inherits="ASPWebsite.Records" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style></style>
    <script type = "text/javascript">

        function openCompareModal() {
            $('#compareTwo').modal({ show: true });
        }

        $(function () {
            $("[id*=gvData] td").hover(function () {
                $("td", $(this).closest("tr")).addClass("RowHover");
            }, function () {
                $("td", $(this).closest("tr")).removeClass("RowHover");
            });
        });

        $(function () {
            $("[id*=gvData] tr").click(function () {
                if (event.target.type !== 'checkbox') {
                    $(':checkbox', this).trigger('click');
                }
            });
        });

       <%-- $(document).ready(function () {
            //Loop through each checkbox in gridview
            //Change the GridView id here
            $("#<%=gvData.ClientID %> input:checkbox").each(function () {
                this.onclick = function () {
                    //Check if the checkbox is selected or not
                    if (this.checked)
                        this.parentNode.parentNode.style.backgroundColor = 'aqua';
                    else
                        this.parentNode.parentNode.style.backgroundColor = 'white';
                }
            })
        })--%>

        function CheckCheck() {
            var chkBoxList = document.getElementById('<%=gvData.ClientID %>');
            var chkBoxCount = chkBoxList.getElementsByTagName("input");

            var i = 0;
            var tot = 0;
            for (i = 0; i < chkBoxCount.length; i++) {
                if (chkBoxCount[i].checked) {
                    tot = tot + 1;
                    if (tot > 2) {
                        alert('Cannot check more, than 2 check boxes');
                        chkBoxCount[i].checked = false;
                        return;
                    }
                }
            }
            if (tot > 1) {
                document.getElementById('<%=btnCompare.ClientID %>').style.display = 'inline-block';
            }
            else {
                document.getElementById('<%=btnCompare.ClientID %>').style.display = 'none';
            }
        }

        $(function () {
            document.getElementById('<%=btnCompare.ClientID %>').style.display = 'none';
        });


        function uncheckAll() {
            $('input[type="checkbox"]:checked').prop('checked', false);
        }

</script>
    
    <style>
        .hover_row {
            background-color: #A1DCF2;
        }

        .RowHighlight {
            color: #336699;
            cursor: pointer;
            background-color: lightgreen;
            background-repeat: repeat-x;
        }

        .RowHover {
            color: #336699;
            cursor: pointer;
            background-color: lightblue;
            background-repeat: repeat-x;
        }

        .invisible {
            display: none;
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
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <div class="container" style="padding: 100px; padding-top: 200px;";>
         <h2 class="text-center">View/Compare Records</h2>
            <hr class="star-primary">
         <div style="position: center; text-align: center;">
         <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvData_SelectedIndexChanged" OnPageIndexChanging="gvData_PageIndexChanging" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" horizontalalign="Center">
             <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvData_SelectedIndexChanged" AllowPaging="True" PageSize="5" OnPageIndexChanging="gvData_PageIndexChanging" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">--%>
             <Columns>
                 <asp:TemplateField>
                     <ItemTemplate>
                         <asp:CheckBox ID="checkBoxSelect" runat="server" ClientIDMode="Static" onclick = "javascript:CheckCheck();"/>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:BoundField DataField="workLocation.area" HeaderText="Work location" />
                 <asp:BoundField DataField="salary" HeaderText="Salary" DataFormatString="{0:C}" />
                 <asp:BoundField DataField="salarySatisfaction" HeaderText="Salary Rating" />
                 <asp:BoundField DataField="jobInterest" HeaderText="Job Rating" />
                 <asp:BoundField DataField="JSIScore" HeaderText="Satisfaction Index" DataFormatString="{0:0.00}" />
                 <asp:TemplateField ShowHeader="False">
                     <ItemTemplate>
                         <asp:LinkButton ID="btnLinkDetail" runat="server" CausesValidation="False" CommandName="Select" Text="View Record"></asp:LinkButton>
                     </ItemTemplate>
                 </asp:TemplateField>
             </Columns>
             <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
             <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
             <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
             <SortedAscendingCellStyle BackColor="#F7F7F7" />
             <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
             <SortedDescendingCellStyle BackColor="#E5E5E5" />
             <SortedDescendingHeaderStyle BackColor="#242121" />
         </asp:GridView><br />
         <asp:Button ID="btnCompare" runat="server" Text="Compare Records" OnClick="btnCompare_Click" CssClass="try btn btn-success"/>
         </div>
         </div>
    <asp:Panel ID="pnlNoRecords" runat="server" Visible="false"><h2 class="text-center" style="text-transform:none; font-weight: normal;">No Records! <br /> <a href="HomePage.aspx#JSI">Go compute and save Job Satisfaction Index</a></h2></asp:Panel>

    <style>
        .try {
            background: #D5EDEF;
            border: none;
            color: #4f6b72;
            font-weight: normal;
        }

            .try:hover {
                background-color: lightblue;
                color: #336699;
            }
    </style>
    <%--Compare Records Modal--%>
     <div class="portfolio-modal modal fade" id="compareTwo" tabindex="-1" role="dialog" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="close-modal" data-dismiss="modal" onclick="uncheckAll()">
                            <div class="lr">
                                <div class="rl"></div>
                            </div>
                        </div>
                        <style>
                            #recordtable tr td {
                                text-align: left;
                            }

                            .row1 {
                            }

                            #recordtable th {
                                border: 1px solid black;
                            }

                            #recordtable td {
                                border: 1px solid black;
                            }

                            .table1 {
                                width: 300px;
                            }

                            .table2 {
                                width: 300px;
                            }

                            .compare {
                                font-size: 30pt;
                            }
                        </style>
                        <div class="container">
                            <div class="row">
                                <div class="col-lg-8 mx-auto">
                                    <div class="modal-body">
                                       <%-- <h2 class="text-center">Compare two records</h2>
                                        <hr class="star-primary">--%>
                                        <table id="recordtable">
                                            <tr>
                                                <th style="border: none; background: none;"></th>
                                                <th>Work Location 1: <asp:Label ID="lbl1" runat="server" Text="Label"></asp:Label> </th>
                                                <th style="border: none; background: none;"></th>
                                                <th>Work Location 2: <asp:Label ID="lbl2" runat="server" Text="Label"></asp:Label></th>
                                            </tr>
                                            <tr>
                                                <td style="border: none; font-weight: bold; padding-right: 10px;">Commute Cost</td>
                                                <td class="table1">
                                                    <asp:Label ID="firstcc" runat="server" Text="Label"></asp:Label></td>
                                                <td style="border: none; padding: 20px;">
                                                    <asp:Label ID="ccCompare" runat="server" Text="Label" CssClass="compare"></asp:Label></td>
                                                <td class="table2"> 
                                                <asp:Label ID="secondcc" runat="server" Text="Label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="border: none; font-weight: bold;padding-right: 10px;">Salary Satisfaction</td>
                                                <td class="table1"><asp:Label ID="firstss" runat="server" Text="Label"></asp:Label></td>
                                                <td style="border: none; padding: 20px;">
                                                    <asp:Label ID="ssCompare" runat="server" Text="Label" CssClass="compare"></asp:Label></td>
                                                <td class="table2"><asp:Label ID="secondss" runat="server" Text="Label"></asp:Label></td>
                                            </tr>
                                             <tr>
                                                 <td style="border: none; font-weight: bold;padding-right: 10px;">Job Interest</td>
                                                <td class="table1"><asp:Label ID="firstji" runat="server" Text="Label"></asp:Label></td>
                                                 <td style="border: none; padding: 20px;">
                                                     <asp:Label ID="jiCompare" runat="server" Text="Label" CssClass="compare"></asp:Label></td>
                                                <td class="table2"><asp:Label ID="secondji" runat="server" Text="Label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="border: none; font-weight: bold;padding-right: 10px;">Monthly Salary</td>
                                                <td><asp:Label ID="firstms" runat="server" Text="Label"></asp:Label></td>
                                                <td style="border: none; padding: 20px;">
                                                    <asp:Label ID="msCompare" runat="server" Text="Label" CssClass="compare"></asp:Label></td>
                                                <td><asp:Label ID="secondms" runat="server" Text="Label"></asp:Label></td>
                                            </tr>
                                             <tr>
                                                 <td style="border: none; font-weight: bold;padding-right: 10px;">Commute Time</td>
                                                <td class="table1"><asp:Label ID="firstct" runat="server" Text="Label"></asp:Label></td>
                                                 <td style="border: none; padding: 20px;">
                                                     <asp:Label ID="ctCompare" runat="server" Text="Label" CssClass="compare"></asp:Label></td>
                                                <td class="table2"><asp:Label ID="secondct" runat="server" Text="Label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="border: none; font-weight: bold;padding-right: 10px;">Commute Comfort</td>
                                                <td class="table1">
                                                    <asp:Label ID="firstcco" runat="server" Text="Label"></asp:Label></td>
                                                <td style="border: none; padding: 20px;">
                                                    <asp:Label ID="ccoCompare" runat="server" Text="Label" CssClass="compare"></asp:Label></td>
                                                <td class="table2">
                                                    <asp:Label ID="secondcco" runat="server" Text="Label"></asp:Label></td>
                                            </tr>
                                        </table>
                                        <br />
                                        <br />
                                        <%--<button class="btn btn-success" type="button" data-dismiss="modal" onclick="uncheckAll()">
                                            <i class="fa fa-times"></i>
                                            Close
                                        </button>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    
</asp:Content>
