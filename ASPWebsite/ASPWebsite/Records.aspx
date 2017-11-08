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
                         <asp:CheckBox ID="checkBoxSelect" runat="server" ClientIDMode="Static" onclick = "Check_Click(this)"/>
                     </ItemTemplate>
                 </asp:TemplateField>
             </Columns>
         </asp:GridView><br />
         <asp:Button ID="Button1" runat="server" Text="Compare Records" OnClick="btnCompare_Click" />
         </div>
</asp:Content>
