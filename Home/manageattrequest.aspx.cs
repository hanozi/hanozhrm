using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_manageatrequest : System.Web.UI.Page
{
    DAL d = new DAL();
    BAL b = new BAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id2"] == null)
            Response.Redirect("../login/login.aspx");
        if (!IsPostBack)
        {
            gridfillmanageattrequest();
        }
    }
    void gridfillmanageattrequest()
    {
        b.empid = int.Parse(Session["id2"].ToString());
        DataTable dt = b.getlocation(b);
        b.address = dt.Rows[0]["address"].ToString();
        GridView1.DataSource = b.gridfillmanageattrequest(b);
        GridView1.DataBind();
        int check = GridView1.Rows.Count;
        if (check != 0)
        {
            Button1.Visible = true;
            Button2.Visible = true;
        }
        else
        {
            Button1.Visible = false;
            Button2.Visible = false;
            Label10.Text = "No Pending Attendance Request";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string str = string.Empty;
        foreach (GridViewRow gvrow in GridView1.Rows)
        {
            CheckBox chk = (CheckBox)gvrow.FindControl("CheckBox1");
            if (chk.Checked)
            {
                Label ch = (Label)gvrow.FindControl("Label2");
                string che = ch.Text;
                Label ch1 = (Label)gvrow.FindControl("Label4");
                string che1 = ch1.Text;
                b.attrequestid = int.Parse(che);
                b.status = "Approved";
                Label ch2 = (Label)gvrow.FindControl("Label5");
                b.intime = ch2.Text;
                Label ch3 = (Label)gvrow.FindControl("Label6");
                b.outtime = ch3.Text;
                Label ch4 = (Label)gvrow.FindControl("Label9");
                b.empid = int.Parse(ch4.Text);
                Label ch5 = (Label)gvrow.FindControl("Label4");
                DateTime abc = DateTime.Parse(ch5.Text);
                b.date = abc.ToString("yyyy-MM-dd");
                TimeSpan intime = TimeSpan.Parse(b.intime);
                TimeSpan outtime = TimeSpan.Parse(b.outtime);
                int inth = intime.Hours;
                int outh = outtime.Hours;
                string total;
                if (inth != 22)
                {
                    total = Convert.ToString(outh - inth);
                }
                else
                {
                    int intht = 24 - inth;
                    total = Convert.ToString(outh + inth);
                }
                b.totalhrs = total;
                b.approveattrequest(b);
            }
        }
        gridfillmanageattrequest();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string str = string.Empty;
        foreach (GridViewRow gvrow in GridView1.Rows)
        {
            CheckBox chk = (CheckBox)gvrow.FindControl("CheckBox1");
            if (chk.Checked)
            {
                Label ch = (Label)gvrow.FindControl("Label2");
                string che = ch.Text;
                b.attrequestid = int.Parse(che);
                b.status = "Rejected";
                b.rejectattrequest(b);
            }
        }
        gridfillmanageattrequest();
    }
}