<%@ Page Title="" Language="C#" MasterPageFile="~/Home/admin.master" AutoEventWireup="true" CodeFile="changepassword.aspx.cs" Inherits="Home_Changepassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../themes/bvalidator.theme.bootstrap.rc.css" rel="stylesheet" />
    <link href="../themes/bvalidator.theme.bootstrap.rt.css" rel="stylesheet" />
    <link href="../themes/bvalidator.theme.gray2.css" rel="stylesheet" />
    <link href="../themes/bvalidator.theme.gray3.css" rel="stylesheet" />
    <link href="../themes/bvalidator.theme.orange.css" rel="stylesheet" />
    <link href="../themes/bvalidator.theme.postit.css" rel="stylesheet" />
    <link href="../themes/bvalidator.theme.red.css" rel="stylesheet" />
    <link href="../bvalidator.css" rel="stylesheet" />
    <script src="../jquery-1.11.0.min.js"></script>
    <script src="../jquery.bvalidator-yc.js"></script>
    <script src="../jquery.bvalidator.js"></script>
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
    <link href="css/chngpasstable.css" rel="stylesheet" />
    <table class="CSS_Table_Example">
        <tr>
            <td><asp:Label ID="Label1" runat="server" Text="Account Information"></asp:Label></td>
            <td><asp:Label ID="Label5" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td style="width:80px"><asp:Label ID="Label2" runat="server" Text="Old Password:"></asp:Label></td>
            <td style="width:300px"><asp:TextBox ID="TextBox1" AutoComplete="off" runat="server" Width="200px" TextMode="Password" data-bvalidator="required" data-bvalidator-msg="Please Enter Old Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="Label3" runat="server" Text="New Password"></asp:Label></td>
            <td><asp:TextBox ID="TextBox2" runat="server" AutoComplete="off" Width="200px" TextMode="Password" data-bvalidator="required" data-bvalidator-msg="Please Enter New Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label4" runat="server" Text="Confirm New Password"></asp:Label></td>
            <td><asp:TextBox ID="TextBox3" runat="server" AutoComplete="off" Width="200px" TextMode="Password" data-bvalidator="required" data-bvalidator-msg="Please Enter New Password Again"></asp:TextBox>
                <br />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Passwords Don't Match" ControlToCompare="TextBox2" ControlToValidate="TextBox3" ForeColor="Red"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2"><asp:Button ID="Button1" runat="server" Text="Change Password" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Reset" OnClick="Button2_Click"/></td>
        </tr>
   </table>
</asp:Content>

