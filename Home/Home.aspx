<%@ Page Title="" Language="C#" MasterPageFile="~/Home/admin.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home_Home" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<%-- Add content controls here --%>
<asp:Content ID="Content1" ContentPlaceHolderId="ContentPlaceHolder1" runat="server">
<div style="width:100%;margin-bottom:500px">
<%--leave balance--%>
<div style="height:162px; width:33%;float:left;background-color:lightblue;margin-right:10px">
    <p style="text-align:center;margin-bottom:10px">Balance Leave</p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="16px" Width="100%" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
        <Columns>
            <asp:TemplateField HeaderText="PL">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("PL") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399"></FooterStyle>

        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF"></HeaderStyle>

        <PagerStyle HorizontalAlign="Left" BackColor="#99CCCC" ForeColor="#003399"></PagerStyle>

        <RowStyle BackColor="White" ForeColor="#003399"></RowStyle>

        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99"></SelectedRowStyle>

        <SortedAscendingCellStyle BackColor="#EDF6F6"></SortedAscendingCellStyle>

        <SortedAscendingHeaderStyle BackColor="#0D4AC4"></SortedAscendingHeaderStyle>

        <SortedDescendingCellStyle BackColor="#D6DFDF"></SortedDescendingCellStyle>

        <SortedDescendingHeaderStyle BackColor="#002876"></SortedDescendingHeaderStyle>
    </asp:GridView>
</div>
<%--leave balance--%>

<%--Quotes--%>
    <div style="height:162px; width:33%;float:left;background-color:lightblue;margin-right:10px">
         <p style="text-align:center;margin-bottom:10px">Quotes</p>
         <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" Height="16px" Width="100%" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("thought") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399"></FooterStyle>

        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF"></HeaderStyle>

        <PagerStyle HorizontalAlign="Left" BackColor="#99CCCC" ForeColor="#003399"></PagerStyle>

        <RowStyle BackColor="White" ForeColor="#003399"></RowStyle>

        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99"></SelectedRowStyle>

        <SortedAscendingCellStyle BackColor="#EDF6F6"></SortedAscendingCellStyle>

        <SortedAscendingHeaderStyle BackColor="#0D4AC4"></SortedAscendingHeaderStyle>

        <SortedDescendingCellStyle BackColor="#D6DFDF"></SortedDescendingCellStyle>

        <SortedDescendingHeaderStyle BackColor="#002876"></SortedDescendingHeaderStyle>
    </asp:GridView>
     </div>
<%--Quotes--%>
        
<%--Quick Launch--%>
<div style="height:162px; width:31%;background-color:lightblue;float:left;margin-bottom:10px">
    <p style="text-align:center;margin-bottom:10px">Quick Launch</p>
    <table style="width:100%;text-align:center">
    <tr>
        <td>
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Home/images/ApplyLeave.png" OnClick="ImageButton1_Click"/>
        </td>
        <td>
            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Home/images/MyLeave.png" OnClick="ImageButton2_Click"/>
        </td>
        <td>
            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Home/images/MyTimesheet.png" OnClick="ImageButton3_Click"/>
        </td>
    </tr>
    <tr>
        <td>
            <a href="leaveapplication.aspx"><span>Apply Leave</span></a>
        </td>
        <td>
            <a href="shiftchangerequest.aspx"><span>Shift Change<br /> Request</span></a>
        </td>
        <td>
            <a href="attendance.aspx"><span>Attendance</span></a>
        </td>
    </tr>   
    </table>
 </div>
<%--Quick Launch--%>
<br /> 
<%--Employee by department--%>
<div style="float:left;background-color:lightblue;height:475px;width:33%;text-align:center">
         <p style="text-align:center;margin-bottom:10px">Employee by Department</p>
            <asp:Chart ID="Chart1" runat="server" Height="350px" DataSourceID="SqlDataSource1" BackColor="LightBlue">
                <BorderSkin BackColor="OrangeRed" PageColor="LightBlue" SkinStyle="Emboss" />
             <Series>
                 <asp:Series Name="Series1" XValueMember="deptname" YValueMembers="groupi"></asp:Series>
             </Series>
             <ChartAreas>
                 <asp:ChartArea Name="ChartArea1" BackColor="YellowGreen"></asp:ChartArea>
             </ChartAreas>
         </asp:Chart>
         <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:projectConnectionString %>' SelectCommand="SELECT deptname,COUNT(deptname)as groupi FROM tblemployee group by deptname"></asp:SqlDataSource>
     </div>
<%--Employee by department--%>

<%--Birthday Babies--%>
    <div style="float:left;background-color:lightblue;width:33%;height:475px;text-align:center;margin-left:10px">
    <p style="text-align:center;margin-bottom:10px">Birthday Babies</p>
    <asp:Label ID="Label28" runat="server" Text="" ForeColor="OrangeRed"></asp:Label>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Height="16px" Width="100%" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="True" OnPageIndexChanging="GridView2_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="DOB">
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("DOB") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Employee Name">
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Empname") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Department">
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("Department") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Location">
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("Location") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399"></FooterStyle>

        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF"></HeaderStyle>

        <PagerStyle HorizontalAlign="Left" BackColor="#99CCCC" ForeColor="#003399"></PagerStyle>

        <RowStyle BackColor="White" ForeColor="#003399"></RowStyle>

        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99"></SelectedRowStyle>

        <SortedAscendingCellStyle BackColor="#EDF6F6"></SortedAscendingCellStyle>

        <SortedAscendingHeaderStyle BackColor="#0D4AC4"></SortedAscendingHeaderStyle>

        <SortedDescendingCellStyle BackColor="#D6DFDF"></SortedDescendingCellStyle>

        <SortedDescendingHeaderStyle BackColor="#002876"></SortedDescendingHeaderStyle>
    </asp:GridView>
</div>
<%--Birthday Babies--%>

<%--Pending Request Nos--%>
<div id="div1" runat="server" style="float:left;background-color:lightblue;width:31%;height:475px;margin-left:10px;margin-bottom:50px">
<asp:Label ID="Label14" runat="server" Text="" style="margin-left:60px;margin-bottom:10px"></asp:Label><br /><br />
<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Pending Leave Application :-</asp:LinkButton><asp:Label ID="Label1" ForeColor="OrangeRed" runat="server" Text=""></asp:Label><br /><br />
<asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Pending Shift Request :-</asp:LinkButton><asp:Label ID="Label3" ForeColor="OrangeRed" runat="server" Text=""></asp:Label><br /><br />
<asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">Pending Correction Request :-</asp:LinkButton><asp:Label ID="Label4" ForeColor="OrangeRed" runat="server" Text=""></asp:Label><br /><br />
<asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click">Pending Regularisation Request :-</asp:LinkButton><asp:Label ID="Label9" ForeColor="OrangeRed" runat="server" Text=""></asp:Label><br /><br />
<asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton6_Click">Pending Daily Attendance Request :-</asp:LinkButton><asp:Label ID="Label10" ForeColor="OrangeRed" runat="server" Text=""></asp:Label><br /><br />
<asp:LinkButton ID="LinkButton7" runat="server" OnClick="LinkButton7_Click">Pending Expense Request :-</asp:LinkButton><asp:Label ID="Label11" ForeColor="OrangeRed" runat="server" Text=""></asp:Label><br /><br />
<asp:LinkButton ID="LinkButton8" runat="server" OnClick="LinkButton8_Click">Pending Advance Requisition :-</asp:LinkButton><asp:Label ID="Label12" ForeColor="OrangeRed" runat="server" Text=""></asp:Label><br /><br />
<asp:LinkButton ID="LinkButton9" runat="server" OnClick="LinkButton9_Click">Pending Advance Claim Request :-</asp:LinkButton><asp:Label ID="Label13" ForeColor="OrangeRed" runat="server" Text=""></asp:Label><br /><br />
<asp:LinkButton ID="LinkButton10" runat="server" Visible="false" OnClick="LinkButton10_Click">View All Location Request</asp:LinkButton><br /><br />
<asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click" Visible="False">Generate Payroll</asp:LinkButton>
</div>
<%--Pending Request Nos--%>
</asp:Content>
