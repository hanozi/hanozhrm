<%@ Page Title="" Language="C#" MasterPageFile="~/Home/admin.master" AutoEventWireup="true" CodeFile="manageexpenserequest.aspx.cs" Inherits="Home_manageexpenserequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
    <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />  
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Request ID">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("expid") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Employee ID">
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("empid") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Employee Name">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("empname") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("date") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Category">
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("category") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Type">
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("type") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Amount">
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("amount") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Remarks">
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("remarks") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:Label ID="Label12" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Reason">
                <ItemTemplate>
                    <asp:Label ID="Label10" runat="server" Text='<%# Bind("reason") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Image">
                <ItemTemplate>
                    <asp:Button ID="Button3" runat="server" Text="View" OnClick="Button3_Click" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Image">
                <ItemTemplate>
                    <asp:Label ID="Label13" runat="server" Text='<%# Bind("image") %>'></asp:Label>
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
    <asp:Button ID="Button1" runat="server" Text="Approve" OnClick="Button1_Click" />
    <asp:Button ID="Button2" runat="server" Text="Reject" OnClick="Button2_Click" />
    <div><asp:Image ID="Image1" runat="server" /></div>
</asp:Content>

