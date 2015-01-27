using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Home_Changepassword : System.Web.UI.Page
{
    DAL d = new DAL();
    BAL b = new BAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id2"] == null)
            Response.Redirect("../login/login.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string empid = Session["id2"].ToString();
        b.empid=int.Parse(empid);
        b.password = TextBox2.Text;
        b.label = TextBox1.Text;
        b.changepassword(b);
        Label5.Text = b.label;
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
    }
}