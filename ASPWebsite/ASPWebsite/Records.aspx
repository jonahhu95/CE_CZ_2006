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
                 <asp:TemplateField>
                     <EditItemTemplate>
                         <asp:CheckBox ID="CheckBox1" runat="server" />
                     </EditItemTemplate>
                     <ItemTemplate>
                         <%--<asp:CheckBox ID="checkBoxSelect" runat="server" ClientIDMode="Static"/>--%>
                         <asp:CheckBox ID="checkBoxSelect" runat="server" ClientIDMode="Static" onclick = "Check_Click(this)"/>
                     </ItemTemplate>
                 </asp:TemplateField>
             </Columns>
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
                        <div class="container">
                            <div class="row">
                                <div class="col-lg-8 mx-auto">
                                    <div class="modal-body">
                                        <h2>Compare two records</h2>
                                        <hr class="star-primary">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="firstcc" runat="server" Text="Label"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="ccCompare" runat="server" Text="Label"></asp:Label>
                                                </td>
                                                <td><asp:Label ID="secondcc" runat="server" Text="Label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><asp:Label ID="firstss" runat="server" Text="Label"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="ssCompare" runat="server" Text="Label"></asp:Label></td>
                                                <td><asp:Label ID="secondss" runat="server" Text="Label"></asp:Label></td>
                                            </tr>
                                             <tr>
                                                <td><asp:Label ID="firstji" runat="server" Text="Label"></asp:Label></td>
                                                 <td>
                                                     <asp:Label ID="jiCompare" runat="server" Text="Label"></asp:Label></td>
                                                <td><asp:Label ID="secondji" runat="server" Text="Label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><asp:Label ID="firstms" runat="server" Text="Label"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="msCompare" runat="server" Text="Label"></asp:Label></td>
                                                <td><asp:Label ID="secondms" runat="server" Text="Label"></asp:Label></td>
                                            </tr>
                                             <tr>
                                                <td><asp:Label ID="firstct" runat="server" Text="Label"></asp:Label></td>
                                                 <td>
                                                     <asp:Label ID="ctCompare" runat="server" Text="Label"></asp:Label></td>
                                                <td><asp:Label ID="secondct" runat="server" Text="Label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="firstcco" runat="server" Text="Label"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="ccoCompare" runat="server" Text="Label"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="secondcco" runat="server" Text="Label"></asp:Label></td>
                                            </tr>
                                        </table>
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
