<%@ Page Title="" Language="C#" MasterPageFile="~/Home/admin.master" AutoEventWireup="true" CodeFile="shiftchangerequest.aspx.cs" Inherits="Home_shiftchangerequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="../jquery.bvalidator.js"></script>
    <script src="../jquery-1.11.0.min.js"></script>
    <script src="../jquery.bvalidator-yc.js"></script>
    <link href="../bvalidator.css" rel="stylesheet" />
    <link href="../themes/bvalidator.theme.bootstrap.rc.css" rel="stylesheet" />
    <link href="../themes/bvalidator.theme.bootstrap.rt.css" rel="stylesheet" />
    <link href="../themes/bvalidator.theme.gray2.css" rel="stylesheet" />
    <link href="../themes/bvalidator.theme.gray3.css" rel="stylesheet" />
    <link href="../themes/bvalidator.theme.orange.css" rel="stylesheet" />
    <link href="../themes/bvalidator.theme.postit.css" rel="stylesheet" />
    <link href="../themes/bvalidator.theme.red.css" rel="stylesheet" />
    <script type="text/javascript">
        var optionsGrays2 = {
            classNamePrefix: 'bvalidator_gray2_',
            position: { x: 'right', y: 'center' },
            offset: { x: 15, y: 0 },
            template: '<div class="{errMsgClass}"><div class="bvalidator_gray2_arrow"></div><div class="bvalidator_gray2_cont1">{message}</div></div>'
        }
        $(document).ready(function () {
            $("#form1").bValidator(optionsGrays2);
        });
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
            <div style="margin-bottom:20px"><asp:Label ID="Label10" runat="server" Text=""></asp:Label></div>
            <div style="margin-bottom:20px">
            <asp:Label ID="Label1" runat="server" Text="Filter : "></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" OnTextChanged="DropDownList1_TextChanged" AutoPostBack="True">
                <asp:ListItem>Show All</asp:ListItem>
                <asp:ListItem>Pending</asp:ListItem>
                <asp:ListItem>Rejected</asp:ListItem>
                <asp:ListItem>Approved</asp:ListItem>
            </asp:DropDownList></div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" style="width:1200px" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                <Columns>
                    <asp:TemplateField HeaderText="Request ID">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("shiftmerge") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Reason">
                        <ItemTemplate>
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("reason") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Shiftchangefrom") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Shift Name">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("shiftname") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="In Time">
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("intime") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Out Time">
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("outtime") %>'></asp:Label>
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
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            <asp:Button ID="Button5" runat="server" Text="Add Request" OnClick="Button5_Click" />
        </asp:View>
        <asp:View ID="View2" runat="server">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
    <table style="width:100%;float:left">
        <tr>
            <td colspan="2">Add Shift Change Request</td>
        </tr>
        <tr style="margin:100px 100px 100px 100px">
            <td style="width: 63px">From</td>
            <td style="width: 116px"><asp:TextBox ID="TextBox2" AutoComplete="off" runat="server" Width="200px" TextMode="Date" data-bvalidator="required" data-bvalidator-msg="Please Select Date"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 63px">To</td>
            <td style="width: 116px"><asp:TextBox ID="TextBox3" AutoComplete="off" runat="server" Width="200px" TextMode="Date" AutoPostBack="True" OnTextChanged="TextBox3_TextChanged" data-bvalidator="required" data-bvalidator-msg="Please Select Date"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 63px">Reason</td>
            <td><asp:TextBox ID="TextBox1" AutoComplete="off" runat="server" Height="60px" Width="200px" data-bvalidator="required" data-bvalidator-msg="Please Mention Reason"></asp:TextBox></td>
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
                            <asp:ListItem>Shift A</asp:ListItem>
                            <asp:ListItem>Shift B</asp:ListItem>
                            <asp:ListItem>Shift C</asp:ListItem>
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
                    </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="TextBox3" EventName="TextChanged" />
                </Triggers>
            </asp:UpdatePanel>
<asp:Button ID="Button1" runat="server" Text="Save" Width="100px" OnClick="Button1_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="Button2" runat="server" Text="Reset" Width="100px" OnClick="Button2_Click" />
</asp:View>
 </asp:MultiView>
</asp:Content>

