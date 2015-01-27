<%@ Page Title="" Language="C#" MasterPageFile="~/Home/admin.master" AutoEventWireup="true" CodeFile="addemployee.aspx.cs" Inherits="Home_addemployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="css/chngpasstable.css" rel="stylesheet" />
<asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <table class="CSS_Table_Example">
                <tr>
                    <td colspan="2">Profile Details</td>
                </tr>
                <tr>
                    <td style="width: 179px">Employee Name</td>
                    <td><asp:TextBox ID="TextBox1" AutoComplete="off" runat="server" Width="200px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 179px">Department Name</td>
                    <td><asp:DropDownList ID="DropDownList1"  style="width:200px;height:25px" runat="server">
                        <asp:ListItem Selected="True">&lt;-Select-&gt;</asp:ListItem>
                        <asp:ListItem>Admin</asp:ListItem>
                        <asp:ListItem>Accounts</asp:ListItem>
                        <asp:ListItem>Finance</asp:ListItem>
                        <asp:ListItem>Centerhead</asp:ListItem>
                        <asp:ListItem>HR</asp:ListItem>
                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 179px">Designation</td>
                    <td><asp:TextBox ID="TextBox3" AutoComplete="off" runat="server" Width="200px" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 179px">Date of Joining</td>
                    <td><asp:TextBox ID="TextBox4" AutoComplete="off" placeholder="dd-mm-yyyy" runat="server" Width="200px" ></asp:TextBox></td>
                </tr>
                <tr><td colspan="2"><asp:Button ID="Button1" runat="server" Text="Next" Width="82px" OnClick="Button1_Click"/></td></tr>
            </table>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <table class="CSS_Table_Example">
                <tr>
                    <td colspan="2">Personal Details</td>
                </tr>
                <tr>
                    <td style="width: 179px">Date of Birth</td>
                    <td><asp:TextBox ID="TextBox5" AutoComplete="off" placeholder="dd-mm-yyyy" runat="server" Width="200px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 179px">e-mail</td>
                    <td><asp:TextBox ID="TextBox6" AutoComplete="off" runat="server" Width="200px" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 179px">Mobile</td>
                    <td><asp:TextBox ID="TextBox7" AutoComplete="off" runat="server" Width="200px" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 179px">Gender</td>
                    <td><asp:DropDownList ID="DropDownList2"  style="width:200px;height:25px" runat="server">
                        <asp:ListItem Selected="True">&lt;-Select-&gt;</asp:ListItem>
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 179px">Marital Status</td>
                    <td><asp:DropDownList ID="DropDownList3"  style="width:200px;height:25px" runat="server">
                        <asp:ListItem Selected="True">&lt;-Select-&gt;</asp:ListItem>
                        <asp:ListItem>Married</asp:ListItem>
                        <asp:ListItem>Unmarried</asp:ListItem>
                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="2"><asp:Button ID="Button5" runat="server" Text="Previous" Width="82px" OnClick="Button5_Click"/> 
                    <asp:Button ID="Button2" runat="server" Text="Next" Width="82px" OnClick="Button2_Click"/></td>
                </tr>
            </table>
         </asp:View>
         <asp:View ID="View3" runat="server">
            <table class="CSS_Table_Example">
                <tr>
                    <td colspan="2">Postal Details</td>
                </tr>
                <tr>
                    <td style="width: 179px; height: 34px;">Address</td>
                    <td style="height: 34px">
                        <asp:DropDownList ID="DropDownList4" style="width:200px;height:25px" runat="server">
                            <asp:ListItem>&lt;-Select-&gt;</asp:ListItem>
                            <asp:ListItem>Ahemdabad</asp:ListItem>
                            <asp:ListItem>Bharuch</asp:ListItem>
                            <asp:ListItem>Surat</asp:ListItem>
                            <asp:ListItem>Navsari</asp:ListItem>
                            <asp:ListItem>Vadodara</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 179px">Zipcode</td>
                    <td><asp:TextBox ID="TextBox10" AutoComplete="off" runat="server" Width="200px" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 179px">State</td>
                    <td><asp:TextBox ID="TextBox11" AutoComplete="off" runat="server" Width="200px" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 179px">Country</td>
                    <td><asp:TextBox ID="TextBox12" AutoComplete="off" runat="server" Width="200px" ></asp:TextBox></td>
                </tr>
                <tr><td colspan="2"><asp:Button ID="Button6" runat="server" Text="Previous" Width="82px" OnClick="Button6_Click"/> 
                    <asp:Button ID="Button3" runat="server" Text="Submit" Width="82px" OnClick="Button3_Click"/></td></tr>
            </table>
        </asp:View>
    <asp:View ID="View4" runat="server">
            <table class="CSS_Table_Example">
                <tr>
                    <td colspan="2">Please check the Details:</td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size:12px;font-weight:bold">Profile Details:</td>
                </tr>
                <tr>
                    <td style="width: 250px">Employee Name</td>
                    <td><asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 179px">Department Name</td>
                    <td><asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 179px">Designation</td>
                    <td><asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 179px">Date of Joining</td>
                    <td><asp:Label ID="Label4" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size:12px;font-weight:bold">Personal Details:</td>
                </tr>
                <tr>
                    <td style="width: 179px">Date of Birth</td>
                    <td><asp:Label ID="Label5" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 179px">e-mail</td>
                    <td><asp:Label ID="Label6" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 179px">Mobile</td>
                    <td><asp:Label ID="Label7" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 179px">Gender</td>
                    <td><asp:Label ID="Label8" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 179px">Marital Status</td>
                    <td><asp:Label ID="Label9" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size:12px;font-weight:bold">Postal Details:</td>
                </tr>
                <tr>
                    <td style="width: 179px; height: 34px;">Address</td>
                    <td style="height: 34px"><asp:Label ID="Label10" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 179px">Zipcode</td>
                    <td><asp:Label ID="Label11" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 179px">State</td>
                    <td><asp:Label ID="Label12" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 179px">Country</td>
                    <td><asp:Label ID="Label13" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr><td><asp:Button ID="Button4" runat="server" Text="Add Employee" Width="82px" OnClick="Button4_Click"/>
                    &nbsp;&nbsp;
                    <asp:Button ID="Button7" runat="server" Text="Reset" Width="82px" OnClick="Button7_Click"/>
                    </td><td><asp:Label ID="Label14" runat="server" Text=""></asp:Label></td></tr>
            </table>
        </asp:View>
    <asp:View ID="View5" runat="server">
        <table class="CSS_Table_Example" style="margin-bottom:20px">
                <tr><td colspan="3" style="width:600px">Profile Details</td></tr>
                <tr>
                    <td colspan="3">Employee Added Successfully!!</td>
                </tr>
                <tr>    
                    <td>Employee Name</td>
                    <td><asp:Label ID="Label15" runat="server"></asp:Label></td>
                    <td rowspan="4"style="height:128px;width:128px;background-image:url('images/boy.png')"></td>
                </tr>
                <tr>    
                    <td>Department Name</td>
                    <td><asp:Label ID="Label16" runat="server"></asp:Label></td>
                </tr>
                <tr>    
                    <td>Designation</td>
                    <td><asp:Label ID="Label17" runat="server"></asp:Label></td>
                </tr>
                <tr>    
                    <td>Date of Joining</td>
                    <td><asp:Label ID="Label18" runat="server"></asp:Label></td>
                </tr>
              </table>
    </asp:View>
</asp:MultiView>
</asp:Content>

