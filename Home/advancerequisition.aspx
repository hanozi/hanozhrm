<%@ Page Title="" Language="C#" MasterPageFile="~/Home/admin.master" AutoEventWireup="true" CodeFile="advancerequisition.aspx.cs" Inherits="Home_advancerequisition" %>

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
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" style="width:1200px" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="advid">
                <Columns>
                    <asp:TemplateField HeaderText="Advance ID">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("advid") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date">
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Advance Requisition For">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("advfor") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Amount">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("amount") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Remarks">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("remarks") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Claim">
                        <ItemTemplate>
                            <asp:Label ID="Label15" runat="server" Text="" Visible="false"></asp:Label><br />
                            <asp:LinkButton ID="LinkButton1" runat="server" Visible="false" OnClick="LinkButton1_Click"></asp:LinkButton>
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
            <table style="width:100%;float:left">
        <tr>
            <td colspan="2">Add Advance Requisition</td>
        </tr>
        <tr>
            <td style="width: 63px; height: 34px;">Date</td>
            <td style="height: 34px">
                <asp:TextBox ID="TextBox4" runat="server" Width="200px" Height="50px" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 63px;margin-bottom:10px">Advance Requisition For</td>
            <td style="width: 116px">
                <asp:DropDownList ID="DropDownList2" Width="200px" Height="50px" runat="server">
                    <asp:ListItem>&lt;-Select-&gt;</asp:ListItem>
                    <asp:ListItem>Purchase Hardware</asp:ListItem>
                    <asp:ListItem>Tour</asp:ListItem>
                    <asp:ListItem>Audit</asp:ListItem>
                    <asp:ListItem>Center Support</asp:ListItem>
                    <asp:ListItem>Seminar</asp:ListItem>
                    <asp:ListItem>Training</asp:ListItem>
                    <asp:ListItem>Others</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 63px">Amount</td>
            <td style="width: 116px"><asp:TextBox ID="TextBox3" AutoComplete="off" runat="server" Height="50px" Width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 63px">Remarks</td>
            <td><asp:TextBox ID="TextBox1" AutoComplete="off" runat="server" Height="60px" Width="200px"></asp:TextBox>
            </td>
        </tr>
    </table>
        <div style="margin-top:20px">
            <asp:Button ID="Button1" runat="server" Text="Submit" Width="100px" OnClick="Button1_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Reset" Width="100px" OnClick="Button2_Click" />
        </div>
        </asp:View>
        <asp:View ID="View3" runat="server">
            <asp:Label ID="Label8" runat="server" Text="" Visible="false"></asp:Label>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" style="width:1200px" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="advid" ShowHeaderWhenEmpty="True" Visible="false">
                <Columns>
                    <asp:TemplateField HeaderText="Claim ID">
                        <ItemTemplate>
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("claimid") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date">
                        <ItemTemplate>
                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Advance Requisition For">
                        <ItemTemplate>
                            <asp:Label ID="Label18" runat="server" Text='<%# Bind("Type") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Amount">
                        <ItemTemplate>
                            <asp:Label ID="Label11" runat="server" Text='<%# Bind("amount") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Remarks">
                        <ItemTemplate>
                            <asp:Label ID="Label12" runat="server" Text='<%# Bind("remarks") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Label ID="Label13" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Advance ID">
                        <ItemTemplate>
                            <asp:Label ID="Label14" runat="server" Text='<%# Bind("advid") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Adjustment">
                        <ItemTemplate>
                            <asp:Label ID="Label17" runat="server" Text='<%# Bind("adjustments") %>'></asp:Label>
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
            <br /><br />
            <asp:Button ID="Button3" runat="server" Text="Add Claim" OnClick="Button3_Click"/>
            <asp:GridView ID="Gridview3" width="250px" runat="server" ShowFooter="true" Visible="false" AutoGenerateColumns="false" OnRowCreated="Gridview3_RowCreated" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="No." HeaderText="No." />
                <asp:TemplateField HeaderText="Date">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox5" Width="153px" runat="server" TextMode="Date"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Type">
                    <ItemTemplate>
                        <asp:DropDownList ID="DropDownList3" Height="100%" runat="server" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" AutoPostBack="true">
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
                                    <asp:ListItem>Purchased Hardware</asp:ListItem>
                                    <asp:ListItem>Train</asp:ListItem>
                                </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Amount">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox6" Width="150px" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Remarks">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox7" Width="150px" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Image Upload">
                    <ItemTemplate>
                        <asp:FileUpload ID="FileUpload1" runat="server" Visible="false" />
                        <asp:Label ID="Label16" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Right" />
                    <FooterTemplate>
                        <asp:Button ID="Button7" runat="server" Text="Add New Row" OnClick="Button7_Click" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Remove</asp:LinkButton>
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
            <asp:Button ID="Button4" runat="server" Text="Submit" Width="100px" Visible="false" OnClick="Button4_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button6" runat="server" Text="Reset" Width="100px" Visible="false" OnClick="Button6_Click" />
        </div>
        </asp:View>
    </asp:MultiView>
</asp:Content>

