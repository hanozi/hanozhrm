using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_manageregularisationrequest : System.Web.UI.Page
{
    DAL d = new DAL();
    BAL b = new BAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id2"] == null)
            Response.Redirect("../login/login.aspx");
        if (!IsPostBack)
        {
            gridfillmanageregularisationrequest();
        }
    }
    void gridfillmanageregularisationrequest()
    {
        b.empid = int.Parse(Session["id2"].ToString());
        DataTable dt = b.getlocation(b);
        b.address = dt.Rows[0]["address"].ToString();
        GridView1.DataSource = b.gridfillmanageregularisationrequest(b);
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
            Label10.Text = "No Pending Regularisation Request";
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
                b.regularisationid = int.Parse(che);
                Label ch1 = (Label)gvrow.FindControl("Label4");
                b.category = ch1.Text;
                b.status = "Approved";
                Label ch2 = (Label)gvrow.FindControl("Label5");
                DateTime abc = DateTime.Parse(ch2.Text);
                b.fromdate = abc.ToString("yyyy-MM-dd");
                Label ch4 = (Label)gvrow.FindControl("Label6");
                DateTime abc1 = DateTime.Parse(ch4.Text);
                b.todate = abc1.ToString("yyyy-MM-dd");
                Label ch3 = (Label)gvrow.FindControl("Label9");
                b.empid = int.Parse(ch3.Text);
                b.approveregularisationrequest(b);
            }
        }
        gridfillmanageregularisationrequest();
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
                b.regularisationid = int.Parse(che);
                b.status = "Rejected";
                b.rejectregularisationrequest(b);
            }
        }
        gridfillmanageregularisationrequest();
    }
}