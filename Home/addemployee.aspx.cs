using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Home_addemployee : System.Web.UI.Page
{
    DAL d = new DAL();
    BAL b = new BAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id2"] == null)
            Response.Redirect("../login/login.aspx");
        MultiView1.ActiveViewIndex = 0;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 3;
        Label1.Text = TextBox1.Text;
        Label2.Text = DropDownList1.SelectedValue;
        Label3.Text = TextBox3.Text;
        Label4.Text = TextBox4.Text;
        Label5.Text = TextBox5.Text;
        Label6.Text = TextBox6.Text;
        Label7.Text = TextBox7.Text;
        Label8.Text = DropDownList2.SelectedValue;
        Label9.Text = DropDownList3.SelectedValue;
        Label10.Text = DropDownList4.SelectedValue;
        Label11.Text = TextBox10.Text;
        Label12.Text = TextBox11.Text;
        Label13.Text = TextBox12.Text;

    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        b.empname = Label1.Text;
        b.deptname = Label2.Text;
        b.designation = Label3.Text;
        b.doj = DateTime.Parse(Label4.Text);
        b.dob = DateTime.Parse(Label5.Text);
        b.email = Label6.Text;
        b.mobile = Int64.Parse(Label7.Text);
        b.gender = Label8.Text;
        b.maritalstatus = Label9.Text;
        b.address = Label10.Text;
        b.zipcode = int.Parse(Label11.Text);
        b.state = Label12.Text;
        b.country = Label13.Text;
        b.password = Label1.Text;
        b.shiftid = 1;
        if (b.deptname == "Admin" || b.deptname == "HR")
        {
            b.label = "1";
        }
        else if (b.deptname == "Accounts")
        {
            b.label = "3";
        }
        else if (b.deptname == "Finance")
        {
            b.label = "2";
        }
        b.advid = 350;
        b.addemployee(b);
        Label15.Text=b.empname;
        Label16.Text=b.deptname;
        Label17.Text=b.designation;
        Label18.Text = b.doj.ToString(); ;
        MultiView1.ActiveViewIndex = 4;
        TextBox1.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox10.Text = "";
        TextBox11.Text = "";
        TextBox12.Text = "";
    }
}