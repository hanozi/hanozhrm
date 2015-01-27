<%@ Page Title="" Language="C#" MasterPageFile="~/Home/admin.master" AutoEventWireup="true" CodeFile="attendance.aspx.cs" Inherits="Home_Attendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <link href="css/style.css" rel="stylesheet" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="Label2" runat="server" Text="Period"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>&lt;-select-&gt;</asp:ListItem>
        <asp:ListItem>01</asp:ListItem>
        <asp:ListItem>02</asp:ListItem>
        <asp:ListItem>03</asp:ListItem>
        <asp:ListItem>04</asp:ListItem>
        <asp:ListItem>05</asp:ListItem>
        <asp:ListItem>06</asp:ListItem>
        <asp:ListItem>07</asp:ListItem>
        <asp:ListItem>08</asp:ListItem>
        <asp:ListItem>09</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>11</asp:ListItem>
        <asp:ListItem>12</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="DropDownList2" runat="server">
        <asp:ListItem>&lt;-select-&gt;</asp:ListItem>
        <asp:ListItem>2008</asp:ListItem>
        <asp:ListItem>2009</asp:ListItem>
        <asp:ListItem>2010</asp:ListItem>
        <asp:ListItem>2011</asp:ListItem>
        <asp:ListItem>2012</asp:ListItem>
        <asp:ListItem>2013</asp:ListItem>
        <asp:ListItem>2014</asp:ListItem>
        <asp:ListItem>2015</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" /><br /><br />
    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Previous</asp:LinkButton>
    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Next</asp:LinkButton>
    <asp:Button ID="Button2" runat="server" Text="Export To Excel" OnClick="Button2_Click"/>
    <asp:Button ID="Button3" runat="server" Text="Export To PDF" OnClick="Button3_Click"/>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
        <Columns>
            <asp:TemplateField HeaderText="Date" HeaderStyle-CssClass="header-center">
                <ItemTemplate>
                    <div style="width:90px;text-align:right">
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="In Time" HeaderStyle-CssClass="header-center">
                <ItemTemplate>
                    <div style="width:70px;text-align:right">
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("InTime") %>'></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Out Time" HeaderStyle-CssClass="header-center">
                <ItemTemplate>
                    <div style="width:70px;text-align:right">
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("OutTime") %>'></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Shift TotalHrs" HeaderStyle-CssClass="header-center">
                <ItemTemplate>
                    <div style="width:90px;text-align:right">
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("ShiftTotalHrs") %>'></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Shift InTime" HeaderStyle-CssClass="header-center">
                <ItemTemplate>
                    <div style="width:90px;text-align:right">
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("ShiftInTime") %>'></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Shift OutTime" HeaderStyle-CssClass="header-center">
                <ItemTemplate>
                    <div style="width:90px;text-align:right">
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("ShiftOutTime") %>'></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Type" HeaderStyle-CssClass="header-center">
                <ItemTemplate>
                    <div style="width:50px;text-align:right">
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("Type") %>'></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Day/Half" HeaderStyle-CssClass="header-center">
                <ItemTemplate>
                    <div style="width:80px;text-align:right">
                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("DayHalf") %>'></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Attendance" HeaderStyle-CssClass="header-center">
                <ItemTemplate>
                    <div style="width:90px;text-align:right">
                    <asp:Label ID="att" runat="server" Text='<%# Bind("Attendance") %>'></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Late" HeaderStyle-CssClass="header-center">
                <ItemTemplate>
                    <div style="width:50px;text-align:right">
                    <asp:Label ID="Label10" runat="server" Text='<%# Bind("Late") %>'></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Early" HeaderStyle-CssClass="header-center">
                <ItemTemplate>
                    <div style="width:50px;text-align:right">
                    <asp:Label ID="Label11" runat="server" Text='<%# Bind("Early") %>'></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Actual Work" HeaderStyle-CssClass="header-center">
                <ItemTemplate>
                    <div style="width:90px;text-align:right">
                    <asp:Label ID="Label12" runat="server" Text='<%# Bind("ActualWork") %>'></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Presence" HeaderStyle-CssClass="header-center">
                <ItemTemplate>
                    <div style="width:90px;text-align:right">
                    <asp:Label ID="Label13" runat="server" Text='<%# Bind("Presence") %>'></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="OT" HeaderStyle-CssClass="header-center">
                <ItemTemplate>
                    <div style="width:60px;text-align:right">
                    <asp:Label ID="Label14" runat="server" Text='<%# Bind("OT") %>'></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Leave Type" HeaderStyle-CssClass="header-center">
                <ItemTemplate>
                    <div style="width:60px;text-align:right">
                    <asp:Label ID="Label16" runat="server" Text='<%# Bind("leavetype") %>'></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Remarks" HeaderStyle-CssClass="header-center">
                <ItemTemplate>
                    <div style="width:90px;text-align:center">
                    <asp:Label ID="Label15" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                    </div>
                </ItemTemplate>
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
            </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="LinkButton1" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="LinkButton2" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
</asp:Content>

