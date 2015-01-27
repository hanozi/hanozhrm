<%@ Page Title="" Language="C#" MasterPageFile="~/Home/admin.master" AutoEventWireup="true" CodeFile="Viewprofile.aspx.cs" Inherits="Home_Viewprofile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="css/table.css" rel="stylesheet" />
    <asp:FormView ID="FormView1" runat="server" OnModeChanging="FormView1_ModeChanging">
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
            </table>
                </div>
            <br />
        </ItemTemplate>
        </asp:FormView>
</asp:Content>

