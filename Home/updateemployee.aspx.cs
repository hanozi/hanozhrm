using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Home_updateemployee : System.Web.UI.Page
{
    DAL d = new DAL();
    BAL b = new BAL();  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id2"] == null)
            Response.Redirect("../login/login.aspx");
    }
    public void formfill(string empid)
    {
        FormView1.DataSource = d.formfill(empid);
        FormView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string empid = TextBox1.Text;
        formfill(empid);
        FormView1.Visible = true;
    }

    protected void FormView1_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {
        string empid = TextBox1.Text;
        TextBox empname = (TextBox)FormView1.FindControl("TextBox2");
        TextBox deptname = (TextBox)FormView1.FindControl("TextBox3");
        TextBox designation = (TextBox)FormView1.FindControl("TextBox4");
        TextBox doj = (TextBox)FormView1.FindControl("TextBox5");
        TextBox dob = (TextBox)FormView1.FindControl("TextBox6");
        TextBox email = (TextBox)FormView1.FindControl("TextBox7");
        TextBox mobile = (TextBox)FormView1.FindControl("TextBox8");
        TextBox gender = (TextBox)FormView1.FindControl("TextBox9");
        TextBox maritalstatus = (TextBox)FormView1.FindControl("TextBox10");
        TextBox address = (TextBox)FormView1.FindControl("TextBox11");
        TextBox zipcode = (TextBox)FormView1.FindControl("TextBox12");
        TextBox state = (TextBox)FormView1.FindControl("TextBox13");
        TextBox country = (TextBox)FormView1.FindControl("TextBox14");
        b.empid = int.Parse(empid);
        b.empname = empname.Text;
        b.deptname = deptname.Text;
        b.designation = designation.Text;
        b.doj = DateTime.Parse(doj.Text);
        b.dob = DateTime.Parse(dob.Text);
        b.email = email.Text;
        b.mobile = Int64.Parse(mobile.Text);
        b.gender = gender.Text;
        b.maritalstatus = maritalstatus.Text;
        b.address = address.Text;
        b.zipcode = int.Parse(zipcode.Text);
        b.state = state.Text;
        b.country = country.Text;
        b.updateemployee(b);
        Label4.Text = b.label;
        FormView1.Visible = false;
    }
    protected void FormView1_ModeChanging1(object sender, FormViewModeEventArgs e)
    {
        FormView1.ChangeMode(e.NewMode);
        string empid = TextBox1.Text;
        formfill(empid);
    }
}