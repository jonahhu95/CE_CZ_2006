<%@ Page Title="" Language="C#" MasterPageFile="~/Anonymous.Master" AutoEventWireup="true" CodeBehind="Records.aspx.cs" Inherits="ASPWebsite.Records" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style></style>
    <script type = "text/javascript">
        function Check_Click(objRef) {
            //Get the Row based on checkbox
            var row = objRef.parentNode.parentNode;
            if (objRef.checked) {
                //If checked change color to Aqua
                row.style.backgroundColor = "aqua";
            }
            else {
                //If not checked change back to original color
                if (row.rowIndex % 2 == 0) {
                    //Alternating Row Color
                    row.style.backgroundColor = "#C2D69B";
                }
                else {
                    row.style.backgroundColor = "white";
                }
            }

            //Get the reference of GridView
            var GridView = row.parentNode;

            //Get all input elements in Gridview
            var inputList = GridView.getElementsByTagName("input");

            var numChecked = 0;

            for (var i = 0; i < inputList.length; i++) {
                if (inputList[i].type == "checkbox" && inputList[i].checked) {
                    numChecked = numChecked + 1;
                    if (numChecked > 2) {
                        row.style.backgroundColor = "white";
                        inputList[i].checked = false;
                        alert("Please select only 2");
                    }
                }
            }
        }

        function openCompareModal() {
            $('#compareTwo').modal({ show: true });
        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <div class="container" style="padding: 100px; padding-top: 200px;";>
         <h4> View Past Records </h4><br />
         <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvData_SelectedIndexChanged" AllowPaging="True" PageSize="5" OnPageIndexChanging="gvData_PageIndexChanging" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
             <Columns>
                 <asp:BoundField DataField="workLocation.area" HeaderText="Work location" />
                 <asp:BoundField DataField="salary" HeaderText="Salary" />
                 <asp:BoundField DataField="salarySatisfaction" HeaderText="Salary Rating" />
                 <asp:BoundField DataField="jobInterest" HeaderText="Job Rating" />
                 <asp:BoundField DataField="JSIScore" HeaderText="Satisfaction Index" />
                 <asp:TemplateField>
                     <EditItemTemplate>
                         <asp:CheckBox ID="CheckBox1" runat="server" />
                     </EditItemTemplate>
                     <ItemTemplate>
                         <%--<asp:CheckBox ID="checkBoxSelect" runat="server" ClientIDMode="Static"/>--%>
                         <asp:CheckBox ID="checkBoxSelect" runat="server" ClientIDMode="Static" onclick = "Check_Click(this)"/>
                     </ItemTemplate>
                 </asp:TemplateField>
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
         <asp:Button ID="btnCompare" runat="server" Text="Compare Records" OnClick="btnCompare_Click" />
         </div>

    <%--Compare Records Modal--%>
     <div class="portfolio-modal modal fade" id="compareTwo" tabindex="-1" role="dialog" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="close-modal" data-dismiss="modal">
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

                            .table1{
                                width: 300px;
                            }
                            .table2{
                                width: 300px;
                            }
                        </style>
                        <div class="container">
                            <div class="row">
                                <div class="col-lg-8 mx-auto">
                                    <div class="modal-body">
                                        <h2>Compare two records</h2>
                                        <hr class="star-primary">
                                        <table id="recordtable">
                                            <tr>
                                                <th style="border: none;"></th>
                                                <th>Work Location 1: ..... </th>
                                                <th style="border: none;"></th>
                                                <th>Work Location 2: .....</th>
                                            </tr>
                                            <tr>
                                                <td style="border: none; font-weight: bold;">Commute Cost</td>
                                                <td class="table1">
                                                    <asp:Label ID="firstcc" runat="server" Text="Label"></asp:Label></td>
                                                <td style="border: none; padding: 20px;">
                                                    <asp:Label ID="ccCompare" runat="server" Text="Label"></asp:Label>
                                                </td class="table2"> 
                                                <td><asp:Label ID="secondcc" runat="server" Text="Label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="border: none; font-weight: bold;">Salary Satisfaction</td>
                                                <td class="table1"><asp:Label ID="firstss" runat="server" Text="Label"></asp:Label></td>
                                                <td style="border: none; padding: 20px;">
                                                    <asp:Label ID="ssCompare" runat="server" Text="Label" CssClass="mid"></asp:Label></td>
                                                <td class="table2"><asp:Label ID="secondss" runat="server" Text="Label"></asp:Label></td>
                                            </tr>
                                             <tr>
                                                 <td style="border: none; font-weight: bold;">Job Interest</td>
                                                <td class="table1"><asp:Label ID="firstji" runat="server" Text="Label"></asp:Label></td>
                                                 <td style="border: none; padding: 20px;">
                                                     <asp:Label ID="jiCompare" runat="server" Text="Label"></asp:Label></td>
                                                <td class="table2"><asp:Label ID="secondji" runat="server" Text="Label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="border: none; font-weight: bold;">Monthly Salary</td>
                                                <td><asp:Label ID="firstms" runat="server" Text="Label"></asp:Label></td>
                                                <td style="border: none; padding: 20px;">
                                                    <asp:Label ID="msCompare" runat="server" Text="Label"></asp:Label></td>
                                                <td><asp:Label ID="secondms" runat="server" Text="Label"></asp:Label></td>
                                            </tr>
                                             <tr>
                                                 <td style="border: none; font-weight: bold;">Commute Time</td>
                                                <td class="table1"><asp:Label ID="firstct" runat="server" Text="Label"></asp:Label></td>
                                                 <td style="border: none; padding: 20px;">
                                                     <asp:Label ID="ctCompare" runat="server" Text="Label"></asp:Label></td>
                                                <td class="table2"><asp:Label ID="secondct" runat="server" Text="Label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="border: none; font-weight: bold;">Commute Comfort</td>
                                                <td class="table1">
                                                    <asp:Label ID="firstcco" runat="server" Text="Label"></asp:Label></td>
                                                <td style="border: none; padding: 20px;">
                                                    <asp:Label ID="ccoCompare" runat="server" Text="Label"></asp:Label></td>
                                                <td class="table2">
                                                    <asp:Label ID="secondcco" runat="server" Text="Label"></asp:Label></td>
                                            </tr>
                                        </table>
                                        <br />
                                        <br />

                                        <button class="btn btn-success" type="button" data-dismiss="modal">
                                            <i class="fa fa-times"></i>
                                            Close
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
</asp:Content>
