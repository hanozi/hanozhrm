<%@ Page Title="" Language="C#" MasterPageFile="~/Home/admin.master" AutoEventWireup="true" CodeFile="generatepayroll.aspx.cs" Inherits="Home_generatepayroll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label2" runat="server" Text=""></asp:Label><br /><br /><br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" style="width:1200px" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="empid">
                <Columns>
                    <asp:TemplateField HeaderText="">
                        <HeaderTemplate>
                            <asp:CheckBox ID="selectall" runat="server" OnCheckedChanged="selectall_CheckedChanged" AutoPostBack="True" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Employee ID">
                        <ItemTemplate>
                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("empid") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Employee Name">
                        <ItemTemplate>
                            <asp:Label ID="Label10" runat="server" Text='<%# Bind("empname") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Depatment Name">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("deptname") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Designation">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("designation") %>'></asp:Label>
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
    <asp:Button ID="Button1" runat="server" Text="Generate" OnClick="Button1_Click" /><br /><br /><br />
    <h1 id="show" runat="server" visible="False">Payroll Generated Succefully for the Month :<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>, Year:<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></h1>
</asp:Content>

