<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>HRM PROJ | Hanoz</title>
		<meta charset="utf-8">
		<link href="css/style.css" rel='stylesheet' type='text/css' />
        <link href="../bvalidator.css" rel="stylesheet" />
        <script src="../jquery-1.11.0.min.js"></script>
        <script src="../jquery.bvalidator-yc.js"></script>
        <script src="../jquery.bvalidator.js"></script>
        <link href="../themes/bvalidator.theme.bootstrap.rc.css" rel="stylesheet" />
        <link href="../themes/bvalidator.theme.bootstrap.rt.css" rel="stylesheet" />
        <link href="../themes/bvalidator.theme.gray2.css" rel="stylesheet" />
        <link href="../themes/bvalidator.theme.gray3.css" rel="stylesheet" />
        <link href="../themes/bvalidator.theme.orange.css" rel="stylesheet" />
        <link href="../themes/bvalidator.theme.postit.css" rel="stylesheet" />
        <link href="../themes/bvalidator.theme.red.css" rel="stylesheet" />
		<meta name="viewport" content="width=device-width, initial-scale=1">
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
    <script type="text/javascript">
        function preventback() {
            window.history.forward();
        }
        setTimeout("preventback()", 0);
        window.onunload = function () {
            null
        };
    </script>
		<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
		<!--webfonts-->
		<link href='http://fonts.googleapis.com/css?family=Open+Sans:600italic,400,300,600,700' rel='stylesheet' type='text/css'>
		<!--//webfonts-->
</head>
<body>
    <!-----start-main---->
	 <div class="main">
		<div class="login-form">
			<h1>Login Page</h1>
					<div class="head">
						<img src="images/user.png" alt=""/>
					</div>
				<form id="form1" runat="server">
                    <asp:TextBox ID="TextBox1" placeholder="Employee ID" AutoComplete="off" runat="server" data-bvalidator="required" data-bvalidator-msg="Please Enter Employee ID"></asp:TextBox>
                    <asp:DropDownList class="listitem" ID="DropDownList1" runat="server">
                        <asp:ListItem Selected="True">&lt;-Usertype-&gt;</asp:ListItem>
                        <asp:ListItem>Admin &amp; HR</asp:ListItem>
                        <asp:ListItem>Centerhead</asp:ListItem>
                        <asp:ListItem>Finance</asp:ListItem>
                        <asp:ListItem>Accounts</asp:ListItem>
                    </asp:DropDownList><br />
                    <asp:TextBox ID="TextBox2" placeholder="Password" runat="server" TextMode="Password" data-bvalidator="required" data-bvalidator-msg="Please Enter Password"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                    <div class="submit">
					<asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" Width="342px" />
                    </div>	
					<p><a href="forgotpassword.aspx">Forgot Password ?</a></p>
				</form>
			</div>
			<!--//End-login-form-->
		</div>
			 <!-----//end-main---->
</body>
</html>
