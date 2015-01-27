using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_manageclaimadvance : System.Web.UI.Page
{
    DAL d = new DAL();
    BAL b = new BAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id2"] == null)
            Response.Redirect("../login/login.aspx");
        if (!IsPostBack)
        {
            gridfillmanageclaimadvrequest();
        }
    }
    void gridfillmanageclaimadvrequest()
    {
        b.empid = int.Parse(Session["id2"].ToString());
        DataTable dt = b.getlocation(b);
        b.address = dt.Rows[0]["address"].ToString();
        GridView1.DataSource = b.gridfillmanageclaimadvrequest(b);
        GridView1.DataBind();
        GridView1.Columns[10].Visible = false;
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
            Label10.Text = "No Pending Request For Advance Claim";
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvrow in GridView1.Rows)
        {
            Label dr = (Label)gvrow.FindControl("Label6");
            if (dr.Text == "Auto" || dr.Text == "Bike" || dr.Text == "Car")
            {
                Button click = (Button)gvrow.FindControl("Button3");
                click.Visible = false;
            }
            else
            {
                Button click = (Button)gvrow.FindControl("Button3");
                click.Visible = true;
            }
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Button d1 = (Button)sender;
        GridViewRow gvrow = (GridViewRow)d1.NamingContainer;
        Label dr = (Label)gvrow.FindControl("Label13");
        Image1.ImageUrl = dr.Text;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string str = string.Empty;
        foreach (GridViewRow gvrow in GridView1.Rows)
        {
            CheckBox chk = (CheckBox)gvrow.FindControl("CheckBox1");
            if (chk.Checked)
            {
                Label ch = (Label)gvrow.FindControl("Label14");
                string che = ch.Text;
                b.claimid = int.Parse(che);
                b.status = "Approved";
                b.approveclaimadvrequest(b);
            }
        }
        gridfillmanageclaimadvrequest();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string str = string.Empty;
        foreach (GridViewRow gvrow in GridView1.Rows)
        {
            CheckBox chk = (CheckBox)gvrow.FindControl("CheckBox1");
            if (chk.Checked)
            {
                Label ch = (Label)gvrow.FindControl("Label14");
                string che = ch.Text;
                b.claimid = int.Parse(che);
                b.status = "Rejected";
                b.rejectclaimadvrequest(b);
            }
        }
        gridfillmanageclaimadvrequest();
    }
}