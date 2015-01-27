<%@ Page Title="" Language="C#" MasterPageFile="~/Home/admin.master" AutoEventWireup="true" CodeFile="expenses.aspx.cs" Inherits="Home_expenses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
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
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" style="width:1200px" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="expid">
                <Columns>
                    <asp:TemplateField HeaderText="Date">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Category">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("category") %>'></asp:Label>
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
                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Reason">
                        <ItemTemplate>
                            <asp:Label ID="Label12" runat="server" Text='<%# Bind("reason") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Paid Status">
                        <ItemTemplate>
                            <asp:Label ID="Label11" runat="server" Text='<%# Bind("paidstatus") %>'></asp:Label>
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
            <div style="margin-top:20px">
                <asp:Button ID="Button5" runat="server" Text="Add Request" OnClick="Button5_Click" />
            </div>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <asp:GridView ID="Gridview2" width="250px" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowCreated="Gridview2_RowCreated" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="No." HeaderText="No." />
                <asp:TemplateField HeaderText="Date">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox1" Width="153px" runat="server" TextMode="Date"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Category">
                    <ItemTemplate>
                        <asp:DropDownList ID="DropDownList1" Height="100%" runat="server">
                                    <asp:ListItem><-Select-></asp:ListItem>
                                    <asp:ListItem>Audit</asp:ListItem>
                                    <asp:ListItem>Center Support</asp:ListItem>
                                    <asp:ListItem>Diwali Party</asp:ListItem>
                                    <asp:ListItem>Marketing</asp:ListItem>
                                    <asp:ListItem>Networking</asp:ListItem>
                                    <asp:ListItem>Seminar</asp:ListItem>
                                    <asp:ListItem>Training</asp:ListItem>
                                </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Type">
                    <ItemTemplate>
                        <asp:DropDownList ID="DropDownList2" Height="100%" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem><-Select-></asp:ListItem>
                                    <asp:ListItem>Auto</asp:ListItem>
                                    <asp:ListItem>Bike</asp:ListItem>
                                    <asp:ListItem>Breakfast</asp:ListItem>
                                    <asp:ListItem>Bus</asp:ListItem>
                                    <asp:ListItem>Car</asp:ListItem>
                                    <asp:ListItem>Dinner</asp:ListItem>
                                    <asp:ListItem>Internet</asp:ListItem>
                                    <asp:ListItem>Lunch</asp:ListItem>
                                    <asp:ListItem>Mobile</asp:ListItem>
                                    <asp:ListItem>Night</asp:ListItem>
                                    <asp:ListItem>Other</asp:ListItem>
                                    <asp:ListItem>Train</asp:ListItem>
                                </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Amount">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox4" Width="150px" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Reason">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox5" Width="150px" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Remarks">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox6" Width="150px" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Image Upload">
                    <ItemTemplate>
                        <asp:FileUpload ID="FileUpload1" runat="server" Visible="false" />
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Right" />
                    <FooterTemplate>
                        <asp:Button ID="Button1" runat="server" Text="Add New Row" OnClick="Button1_Click" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Remove</asp:LinkButton>
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
        <div style="margin-top:20px">
            <asp:Button ID="Button2" runat="server" Text="Submit" Width="100px" OnClick="Button2_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" Text="Reset" Width="100px" OnClick="Button3_Click" />
        </div>
        </asp:View>
    </asp:MultiView>
            </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>