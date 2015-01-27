<%@ Page Title="" Language="C#" MasterPageFile="~/Home/admin.master" AutoEventWireup="true" CodeFile="leaveapplication.aspx.cs" Inherits="Home_leaveapplication" enableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <div style="margin-bottom:20px"><asp:Label ID="Label10" runat="server" Text=""></asp:Label></div>
            <div style="margin-bottom:20px">
            <asp:Label ID="Label1" runat="server" Text="Filter : "></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" OnTextChanged="DropDownList1_TextChanged" AutoPostBack="True">
                <asp:ListItem>Show All</asp:ListItem>
                <asp:ListItem>Pending</asp:ListItem>
                <asp:ListItem>Cancelled</asp:ListItem>
                <asp:ListItem>Rejected</asp:ListItem>
                <asp:ListItem>Approved</asp:ListItem>
            </asp:DropDownList></div>
            <asp:Button ID="Button3" runat="server" Text="Export To Excel" OnClick="Button3_Click"/>
            <asp:Button ID="Button4" runat="server" Text="Export To PDF" OnClick="Button4_Click"/>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" style="width:1200px" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                <Columns>
                    <asp:TemplateField HeaderText="Request ID">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("leavemerge") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Leave Duration(Half/Full)">
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("leaveduration") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Reason">
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("reason") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Leave Type">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("leavetype") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("fromdate") %>'></asp:Label>
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
            <td colspan="2">Add Leave Request</td>
        </tr>
        <tr>
            <td colspan="2"><asp:Label ID="Label5" runat="server" ForeColor="OrangeRed" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 63px; height: 34px;">Leave Duration</td>
            <td style="height: 34px">
                <asp:DropDownList ID="DropDownList2" runat="server" Height="50px" Width="200px" Visible="True">
                <asp:ListItem>Half Day</asp:ListItem>
                <asp:ListItem>Full Day</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="margin:100px 100px 100px 100px">
            <td style="width: 63px">From</td>
            <td style="width: 116px">
            <asp:TextBox ID="TextBox2" AutoComplete="off" runat="server" Height="50px" Width="200px" TextMode="Date"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Textbox2" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 63px">To</td>
            <td style="width: 116px"><asp:TextBox ID="TextBox3" AutoComplete="off" runat="server" Height="50px" Width="200px" TextMode="Date" OnTextChanged="TextBox3_TextChanged" AutoPostBack="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 63px">Reason</td>
            <td><asp:TextBox ID="TextBox1" AutoComplete="off" runat="server" Height="60px" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Textbox1" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" style="width:1200px" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Visible="False">
                <Columns>
                    <asp:TemplateField HeaderText="Date">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Leave Duration">
                        <ItemTemplate>
                            <asp:DropDownList ID="DropDownList3" runat="server" Height="50px" Width="200px" Visible="True">
                            <asp:ListItem>Full Day</asp:ListItem>
                            <asp:ListItem>Half Day</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Leave Type">
                        <ItemTemplate>
                            <asp:DropDownList ID="DropDownList4" runat="server" Height="50px" Width="200px" Visible="True">
                            <asp:ListItem>PL</asp:ListItem>
                            <asp:ListItem>LWP</asp:ListItem>
                            </asp:DropDownList>
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
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <asp:Button ID="Button1" runat="server" Text="Save" Width="100px" OnClick="Button1_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Text="Reset" Width="100px" OnClick="Button2_Click" />
</asp:View>
 </asp:MultiView>

</asp:Content>

