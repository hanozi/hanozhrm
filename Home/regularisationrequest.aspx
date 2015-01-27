<%@ Page Title="" Language="C#" MasterPageFile="~/Home/admin.master" AutoEventWireup="true" CodeFile="regularisationrequest.aspx.cs" Inherits="Home_correctionrequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <div style="margin-bottom:20px"><asp:Label ID="Label10" runat="server" Text=""></asp:Label></div>
            <div style="margin-bottom:20px">
            <asp:Label ID="Label1" runat="server" Text="Filter : "></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" OnTextChanged="DropDownList1_TextChanged" AutoPostBack="True">
                <asp:ListItem>Show All</asp:ListItem>
                <asp:ListItem>Pending</asp:ListItem>
                <asp:ListItem>Rejected</asp:ListItem>
                <asp:ListItem>Approved</asp:ListItem>
            </asp:DropDownList></div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" style="width:1200px" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="regularisationid">
                <Columns>
                    <asp:TemplateField HeaderText="Category">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("category") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="From Date">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("fromdate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="To Date">
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("todate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description">
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("descr") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("status") %>'></asp:Label>
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
            <asp:Button ID="Button5" runat="server" Text="Add Request" OnClick="Button5_Click" />
        </asp:View>
        <asp:View ID="View2" runat="server">
    <table style="width:100%;float:left">
        <tr>
            <td colspan="2">Add Regularisation Request</td>
        </tr>
        <tr>
            <td style="width: 63px; height: 34px;">Category</td>
            <td style="height: 34px">
                <asp:DropDownList ID="DropDownList2" runat="server" Height="50px" Width="200px" Visible="True">
                <asp:ListItem>Center Support</asp:ListItem>
                <asp:ListItem>On Field</asp:ListItem>
                <asp:ListItem>On Seminar</asp:ListItem>
                <asp:ListItem>On Tour</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="margin:100px 100px 100px 100px">
            <td style="width: 63px">From Date</td>
            <td style="width: 116px">
            <asp:TextBox ID="TextBox2" AutoComplete="off" runat="server" Height="50px" Width="200px" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 63px">To Date</td>
            <td style="width: 116px"><asp:TextBox ID="TextBox3" AutoComplete="off" runat="server" Height="50px" Width="200px" TextMode="Date"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 63px">Description</td>
            <td><asp:TextBox ID="TextBox1" AutoComplete="off" runat="server" Height="60px" Width="200px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
    </table>
            <asp:Button ID="Button1" runat="server" Text="Save" Width="100px" OnClick="Button1_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Text="Reset" Width="100px" OnClick="Button2_Click" />
            </asp:View>
    </asp:MultiView>
</asp:Content>

