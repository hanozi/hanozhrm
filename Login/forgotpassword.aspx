<%@ Page Language="C#" AutoEventWireup="true" CodeFile="forgotpassword.aspx.cs" Inherits="Login_forgotpassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HRM PROJ | Hanoz</title>
		<meta charset="utf-8">
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
		<link href="css/style.css" rel='stylesheet' type='text/css' />
		<meta name="viewport" content="width=device-width, initial-scale=1">
		<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
		<!--webfonts-->
		<link href='http://fonts.googleapis.com/css?family=Open+Sans:600italic,400,300,600,700' rel='stylesheet' type='text/css'>
		<!--//webfonts-->
</head>
<body>
    <!-----start-main---->
	 <div class="main">
		<div class="login-form">
			<h1>Reset Password</h1>
					<div class="head"><img src="images/user.png" alt=""/></div>
				<form id="form1" runat="server">
                    <asp:TextBox ID="TextBox1" placeholder="Employee ID" AutoComplete="off" runat="server" data-bvalidator="required" data-bvalidator-msg="Please Enter Employee ID"></asp:TextBox>
                    <asp:TextBox ID="TextBox2" placeholder="Registered Mobile Number" AutoComplete="off" runat="server" data-bvalidator="required" data-bvalidator-msg="Please Enter Registered Mobile Number"></asp:TextBox>
                    <asp:TextBox ID="TextBox3" placeholder="New Password" AutoComplete="off" runat="server" TextMode="Password" data-bvalidator="required" data-bvalidator-msg="Please Enter New Password"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="Small"></asp:Label>
                    &nbsp;<div class="submit">
					<asp:Button ID="Button1" runat="server" Text="Submit" Width="342px" OnClick="Button1_Click"/>
                    &nbsp;</div>	
					<p><a href="Login.aspx">Back to Login Screen</a></p>
				</form>
			</div>
			<!--//End-login-form-->
			 
		</div>
			 <!-----//end-main---->
</body>
</html>
