<%@ Page Title="" Language="C#" MasterPageFile="~/Home/admin.master" AutoEventWireup="true" CodeFile="managedrequest.aspx.cs" Inherits="Home_managedrequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
    <asp:Label ID="Label1" runat="server" Text="Select Request Type : "></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
        <asp:ListItem>&lt;-Select-&gt;</asp:ListItem>
        <asp:ListItem>Show All</asp:ListItem>
        <asp:ListItem>Leave Application</asp:ListItem>
        <asp:ListItem>Shift Change</asp:ListItem>
        <asp:ListItem>Correction Request</asp:ListItem>
        <asp:ListItem>Regularisation Request</asp:ListItem>
        <asp:ListItem>Daily Attendance Request</asp:ListItem>
        <asp:ListItem>Expense Request</asp:ListItem>
        <asp:ListItem>Advance Requisition</asp:ListItem>
        <asp:ListItem>Claim Advance Request</asp:ListItem>
    </asp:DropDownList>
 <asp:GridView ID="GridView1" Visible="false" runat="server" Width="100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="Employee ID">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("empid") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Employee Name">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("empname") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Request Type">
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("type") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date">
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("date") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Authority">
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("authority") %>'></asp:Label>
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
    <asp:Label ID="Label2" runat="server" Text="Page Size : " Visible="false"></asp:Label>
    <asp:DropDownList ID="DropDownList2" Visible="false" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True">
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>20</asp:ListItem>
        <asp:ListItem>30</asp:ListItem>
        <asp:ListItem>40</asp:ListItem>
        <asp:ListItem>50</asp:ListItem>
    </asp:DropDownList>
</asp:Content>

