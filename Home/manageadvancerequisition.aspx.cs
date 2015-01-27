using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_manageadvancerequisition : System.Web.UI.Page
{
    DAL d = new DAL();
    BAL b = new BAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id2"] == null)
            Response.Redirect("../login/login.aspx");
        if (!IsPostBack)
        {
            gridfillmanageadvancerequest();
        }
    }
    void gridfillmanageadvancerequest()
    {
        b.empid = int.Parse(Session["id2"].ToString());
        DataTable dt = b.getlocation(b);
        b.address = dt.Rows[0]["address"].ToString();
        GridView1.DataSource = b.gridfillmanageadvancerequest(b);
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
            Label10.Text = "No Pending Advance Requisition";
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
                b.advid = int.Parse(che);
                b.status = "Approved";
                b.approveadvancerequisition(b);
            }
        }
        gridfillmanageadvancerequest();
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
                b.advid = int.Parse(che);
                b.status = "Rejected";
                b.rejectadvancerequisition(b);
            }
        }
        gridfillmanageadvancerequest();
    }
}