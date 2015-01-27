using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_dailyattendancerequest : System.Web.UI.Page
{
    DAL d = new DAL();
    BAL b = new BAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id2"] == null)
            Response.Redirect("../login/login.aspx");
        if (!IsPostBack)
        {
            gridfillattrequest();
        }
        MultiView1.ActiveViewIndex = 0;
    }
    void gridfillattrequest()
    {
        string empid = Session["id2"].ToString();
        b.empid = int.Parse(empid);
        GridView1.DataSource = b.gridfillattrequest(b);
        GridView1.DataBind();
        int check = GridView1.Rows.Count;
        if (check != 0)
        {
            Label1.Visible = true;
            DropDownList1.Visible = true;
            Label10.Visible = false;
        }
        else
        {
            Label1.Visible = false;
            DropDownList1.Visible = false;
            Label10.Visible = true;
            Label10.Text = "No Attendance Request Applied";
        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        string empid = Session["id2"].ToString();
        b.empid = int.Parse(empid);
        b.intime = TextBox2.Text;
        b.outtime = TextBox3.Text;
        b.descr = TextBox1.Text;
        b.date = TextBox4.Text;
        b.status = "Pending";
        b.addattrequest(b);
        gridfillattrequest();
        MultiView1.ActiveViewIndex = 0;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
    }
    protected void DropDownList1_TextChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue.ToString() == "Show All")
        {
            gridfillattrequest();
        }
        else
        {
            string empid = Session["id2"].ToString();
            b.empid = int.Parse(empid);
            b.status = DropDownList1.SelectedValue.ToString();
            GridView1.DataSource = b.gridfillattrequestlist(b);
            GridView1.DataBind();
            int check = GridView1.Rows.Count;
            if (check != 0)
            {
                Label1.Visible = true;
                DropDownList1.Visible = true;
                Label10.Visible = false;
            }
            else
            {
                Label10.Visible = true;
                Label10.Text = "No " + b.status + " Attendance Request";
            }
        }
    }
}