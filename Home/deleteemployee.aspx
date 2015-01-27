<%@ Page Title="" Language="C#" MasterPageFile="~/Home/admin.master" AutoEventWireup="true" CodeFile="deleteemployee.aspx.cs" Inherits="Home_deleteemployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" style="margin-bottom:10px;margin-top:20px" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="empid">
        <Columns>
            <asp:TemplateField HeaderText="" ControlStyle-Width="50px">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </ItemTemplate>

<ControlStyle Width="50px"></ControlStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Employee ID" ControlStyle-Width="150px">
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("empid") %>'></asp:Label>
                </ItemTemplate>

<ControlStyle Width="150px"></ControlStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Employee Name" ControlStyle-Width="150px">
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("empname") %>'></asp:Label>
                </ItemTemplate>

<ControlStyle Width="150px"></ControlStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Department Name" ControlStyle-Width="200px">
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("deptname") %>'></asp:Label>
                </ItemTemplate>

<ControlStyle Width="200px"></ControlStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Designation" ControlStyle-Width="150px">
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("designation") %>'></asp:Label>
                </ItemTemplate>

<ControlStyle Width="150px"></ControlStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="e-Mail" ControlStyle-Width="350px">
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("email") %>'></asp:Label>
                </ItemTemplate>
            <ControlStyle Width="350px"></ControlStyle>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
        <RowStyle BackColor="White" ForeColor="#003399" />
        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <SortedAscendingCellStyle BackColor="#EDF6F6" />
        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
        <SortedDescendingCellStyle BackColor="#D6DFDF" />
        <SortedDescendingHeaderStyle BackColor="#002876" />
    </asp:GridView>
    <asp:Button ID="Button2" runat="server" Text="Delete Selected Records" OnClick="Button2_Click" />
    <br />
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
</asp:Content>

