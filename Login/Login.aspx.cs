using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    DAL d = new DAL();
    BAL b = new BAL();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        b.empid = int.Parse(TextBox1.Text);
        b.password = TextBox2.Text;
        b.label = Label1.Text;
        b.usertype = DropDownList1.SelectedItem.Text;
        b.logincheck(b);
        if (b.label == "Valid User")
        {
                Session["id"] = b.empname;
                Session["id2"] = b.empid;
                Session["dept"] = b.deptname;
                Response.Redirect("../Home/Home.aspx");
        }
        else
            Label1.Text = b.label;
    }
}