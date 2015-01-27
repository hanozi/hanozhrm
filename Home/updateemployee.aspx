<%@ Page Title="" Language="C#" MasterPageFile="~/Home/admin.master" AutoEventWireup="true" CodeFile="updateemployee.aspx.cs" Inherits="Home_updateemployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="css/chngpasstable.css" rel="stylesheet" />
<table class="CSS_Table_Example" style="margin-bottom:20px">
    <tr><td colspan="2">Update Employee</td></tr>
    <tr>
        <td>Employee ID</td>
        <td><asp:TextBox ID="TextBox1" AutoComplete="off" runat="server" Width="212px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="Textbox1"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td><asp:Button ID="Button1" runat="server" Text="Search" Width="126px" OnClick="Button1_Click"/></td>
        <td><asp:Label ID="Label4" runat="server" Text=""></asp:Label></td>
    </tr>
</table>
    <asp:FormView ID="FormView1" runat="server" OnItemUpdating="FormView1_ItemUpdating" OnModeChanging="FormView1_ModeChanging1">
         <ItemTemplate>
            <table class="CSS_Table_Example" style="margin-bottom:20px">
                <tr><td colspan="3" style="width:600px">Profile Details</td></tr>
                <tr>    
                    <td>Employee Name</td>
                    <td><asp:Label ID="Label1" runat="server" Text='<%# Bind("empname") %>'></asp:Label></td>
                    <td rowspan="4"style="height:128px;width:128px;background-image:url('images/boy.png')"></td>
                </tr>
                <tr>    
                    <td>Department Name</td>
                    <td><asp:Label ID="Label2" runat="server" Text='<%# Bind("deptname") %>'></asp:Label></td>
                </tr>
                <tr>    
                    <td>Designation</td>
                    <td><asp:Label ID="Label3" runat="server" Text='<%# Bind("designation") %>'></asp:Label></td>
                </tr>
                <tr>    
                    <td>Date of Joining</td>
                    <td><asp:Label ID="Label4" runat="server" Text='<%# Bind("doj") %>'></asp:Label></td>
                </tr>
              </table></div>
            <div style="width:270px">
            <table class="CSS_Table_Example"  style="margin-bottom:20px;width:600px">
                <tr><td colspan="2">Personal Details</td></tr>
                <tr>    
                    <td>Date of Birth</td>
                    <td><asp:Label ID="Label5" runat="server" Text='<%# Bind("dob") %>'></asp:Label></td>
                </tr>
                <tr>    
                    <td>e-mail</td>
                    <td><asp:Label ID="Label6" runat="server" Text='<%# Bind("email") %>'></asp:Label></td>
                </tr>
                <tr>    
                    <td>Mobile</td>
                    <td><asp:Label ID="Label7" runat="server" Text='<%# Bind("mobile") %>'></asp:Label></td>
                </tr>
                <tr>    
                    <td>Gender</td>
                    <td><asp:Label ID="Label8" runat="server" Text='<%# Bind("Gender") %>'></asp:Label></td>
                </tr>
                <tr>    
                    <td>Marital Status</td>
                    <td><asp:Label ID="Label9" runat="server" Text='<%# Bind("MaritalStatus") %>'></asp:Label></td>
                </tr></table>
                <table class="CSS_Table_Example"  style="width:600px">
                <tr><td colspan="2">Postal Details</td></tr>
                <tr>    
                    <td>Address</td>
                    <td><asp:Label ID="Label10" runat="server" Text='<%# Bind("address") %>'></asp:Label></td>
                </tr>
                <tr>    
                    <td>Zipcode</td>
                    <td><asp:Label ID="Label11" runat="server" Text='<%# Bind("Zipcode") %>'></asp:Label></td>
                </tr>
                <tr>    
                    <td>State</td>
                    <td><asp:Label ID="Label12" runat="server" Text='<%# Bind("State") %>'></asp:Label></td>
                </tr>
                <tr>    
                    <td>Country</td>
                    <td><asp:Label ID="Label13" runat="server" Text='<%# Bind("Country") %>'></asp:Label></td>
                </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="Button4" runat="server" Text="Edit" CommandName="edit" /><%--<asp:LinkButton ID="LinkButton1" CommandName="edit" Text="Edit Employee" runat="server" Font-Size="Small"></asp:LinkButton>--%></td>
                    </tr>
            </table>
                </div>
            <br />
        </ItemTemplate>
        <EditItemTemplate>
            <table class="CSS_Table_Example" style="margin-bottom:20px">
                <tr><td colspan="2" style="width:600px">Profile Details</td></tr>
                <tr>    
                    <td>Employee Name</td>
                    <td><asp:TextBox ID="TextBox2" runat="server" Height="16px" Width="150px"></asp:TextBox></td>
                </tr>
                <tr>    
                    <td>Department Name</td>
                    <td><asp:TextBox ID="TextBox3" runat="server" Width="150px"></asp:TextBox></td>
                </tr>
                <tr>    
                    <td>Designation</td>
                    <td><asp:TextBox ID="TextBox4" runat="server" Width="150px"></asp:TextBox></td>
                </tr>
                <tr>    
                    <td>Date of Joining</td>
                    <td><asp:TextBox ID="TextBox5" runat="server" Width="150px"></asp:TextBox></td>
                </tr>
              </table></div>
            <div style="width:270px">
            <table class="CSS_Table_Example"  style="margin-bottom:20px;width:600px">
                <tr><td colspan="2">Personal Details</td></tr>
                <tr>    
                    <td>Date of Birth</td>
                    <td><asp:TextBox ID="TextBox6" runat="server" Width="150px"></asp:TextBox></td>
                </tr>
                <tr>    
                    <td>e-mail</td>
                    <td><asp:TextBox ID="TextBox7" runat="server" Width="150px"></asp:TextBox></td>
                </tr>
                <tr>    
                    <td>Mobile</td>
                    <td><asp:TextBox ID="TextBox8" runat="server" Width="150px"></asp:TextBox></td>
                </tr>
                <tr>    
                    <td>Gender</td>
                    <td><asp:TextBox ID="TextBox9" runat="server" Width="150px"></asp:TextBox></td>
                </tr>
                <tr>    
                    <td>Marital Status</td>
                    <td><asp:TextBox ID="TextBox10" runat="server" Width="150px"></asp:TextBox></td>
                </tr></table>
                <table class="CSS_Table_Example"  style="width:600px">
                <tr><td colspan="2">Postal Details</td></tr>
                <tr>    
                    <td>Address</td>
                    <td><asp:TextBox ID="TextBox11" runat="server" Width="150px"></asp:TextBox></td>
                </tr>
                <tr>    
                    <td>Zipcode</td>
                    <td><asp:TextBox ID="TextBox12" runat="server" Width="150px"></asp:TextBox></td>
                </tr>
                <tr>    
                    <td>State</td>
                    <td><asp:TextBox ID="TextBox13" runat="server" Width="150px"></asp:TextBox></td>
                </tr>
                <tr>    
                    <td>Country</td>
                    <td><asp:TextBox ID="TextBox14" runat="server" Width="150px"></asp:TextBox></td>
                </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="Button2" runat="server" Text="Update" CommandName="update" Width="126px"/>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Button3" runat="server" Text="Cancel" CommandName="cancel" Height="22px" Width="128px" />
                        </td>
                    </tr>
            </table>
                </div>
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>