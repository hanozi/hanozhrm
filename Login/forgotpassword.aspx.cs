using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login_forgotpassword : System.Web.UI.Page
{
    DAL d = new DAL();
    BAL b = new BAL();
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        b.empid = int.Parse(TextBox1.Text);
        b.mobile = Int64.Parse(TextBox2.Text);
        b.password = TextBox3.Text;
        b.label = Label1.Text;
        b.forgotpassword(b);
        Label1.Text = b.label;
    }
}