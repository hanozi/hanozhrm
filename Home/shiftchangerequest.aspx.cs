﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;

public partial class Home_shiftchangerequest : System.Web.UI.Page
{
    DAL d = new DAL();
    BAL b = new BAL();
    string daa;
    string connection = ConfigurationManager.ConnectionStrings["projectConnectionString"].ConnectionString;
    SqlConnection con;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id2"] == null)
            Response.Redirect("../login/login.aspx");
        MultiView1.ActiveViewIndex = 0;
        if (!IsPostBack)
        {
            gridfillshiftrequest();
        }
        con = new SqlConnection(connection);
    }
    void gridfillshiftrequest()
    {
        string empid = Session["id2"].ToString();
        b.empid = int.Parse(empid);
        GridView1.DataSource = b.gridfillshiftrequest(b);
        GridView1.DataBind();
        int check = GridView1.Rows.Count;
        if (check != 0)
        {
            GroupGridView(GridView1.Rows, 0, 3);
            Label1.Visible = true;
            DropDownList1.Visible = true;
            Label10.Visible = false;
        }
        else
        {
            Label1.Visible = false;
            DropDownList1.Visible = false;
            Label10.Visible = true;
            Label10.Text = "No Shift Change Applied";
        }
    }
    void GroupGridView(GridViewRowCollection gvrc, int startIndex, int total)
    {
        if (total == 0) return;
        int i, count = 1;
        ArrayList lst = new ArrayList();
        lst.Add(gvrc[0]);
        var ctrl = gvrc[0].Cells[startIndex];
        for (i = 1; i < gvrc.Count; i++)
        {
            Label ch = (Label)gvrc[i].FindControl("Label2");
            string che = ch.Text;
            Label ch1 = (Label)gvrc[i - 1].FindControl("Label2");
            string che1 = ch1.Text;
            TableCell nextCell = gvrc[i].Cells[startIndex];
            if (che == che1)
            {
                count++;
                nextCell.Visible = false;
                lst.Add(gvrc[i]);
            }
            else
            {
                if (count > 1)
                {
                    ctrl.RowSpan = count;
                    GroupGridView(new GridViewRowCollection(lst), startIndex + 1, total - 1);
                }
                count = 1;
                lst.Clear();
                ctrl = gvrc[i].Cells[startIndex];
                lst.Add(gvrc[i]);
            }
        }
        if (count > 1)
        {
            ctrl.RowSpan = count;
            GroupGridView(new GridViewRowCollection(lst), startIndex + 1, total - 1);
        }
        count = 1;
        lst.Clear();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        GridView2.Visible = false;
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        int count = GridView2.Rows.Count;
        SqlDataAdapter adp1 = new SqlDataAdapter("SELECT shiftmerge from tblshiftrequest", con);
        DataTable ds1 = new DataTable();
        adp1.Fill(ds1);
        int merge = ds1.Rows.Count - 1;
        int merge1 = int.Parse(ds1.Rows[merge]["shiftmerge"].ToString()) + 1;
        foreach (GridViewRow gvrow in GridView2.Rows)
        {
            DropDownList shift = (DropDownList)gvrow.FindControl("DropDownList3");
            Label date = (Label)gvrow.FindControl("Label2");
            b.empid = int.Parse(Session["id2"].ToString());
            if (shift.Text == "Shift A")
                b.shiftid = 1;
            else if (shift.Text == "Shift B")
                b.shiftid = 2;
            else if (shift.Text == "Shift C")
                b.shiftid = 3;
            b.reason = TextBox1.Text;
            string ffdate = date.Text + " 00:00:00";
            DateTime fdate = DateTime.Parse(ffdate);
            string datef = fdate.ToString("yyyy-MM-dd");
            b.fromdate = datef;
            b.todate = datef;
            b.status = "Pending";
            b.shiftmerge = merge1;
            b.addshiftrequest(b);
        }
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        GridView2.Visible = false;
        gridfillshiftrequest();
        MultiView1.ActiveViewIndex = 0;
    }
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {
        GridView2.Visible = true;
        DataTable dt = new DataTable();
        dt.Columns.Add("Date", typeof(string));
        dt.Columns.Add("Leaveduration", typeof(string));
        dt.Columns.Add("Leavetype", typeof(string));

        DateTime fromd = DateTime.Parse(TextBox2.Text);
        DateTime tod = DateTime.Parse(TextBox3.Text);
        TimeSpan ts = tod-fromd;
        int day = ts.Days;
        DateTime date = fromd;
        int days = date.Day;
        for (int i = 0; i <= day ; i++)
        {
            DataRow dr = dt.NewRow();
            if(i==0)
            {
                int day1 = date.Day;
                int month2 = date.Month;
                int year2 = date.Year;
                string from = day1 + "-" + month2 + "-" + year2;
                dr["Date"] = from;
            }
            else
            {
                dr["Date"] = daa;
            }
            dt.Rows.Add(dr);
            days++;
            int month1 = date.Month;
            int year = date.Year;
            daa = days + "-" + month1 + "-" + year;
        }
        GridView2.DataSource = dt;
        GridView2.DataBind();
        MultiView1.ActiveViewIndex = 1;
    }
    protected void DropDownList1_TextChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue.ToString() == "Show All")
        {
            gridfillshiftrequest();
        }
        else
        {
            string empid = Session["id2"].ToString();
            b.empid = int.Parse(empid);
            b.status = DropDownList1.SelectedValue.ToString();
            GridView1.DataSource = b.gridfillshiftrequestlist(b);
            GridView1.DataBind();
            int check = GridView1.Rows.Count;
            if (check != 0)
            {
                GroupGridView(GridView1.Rows, 0, 3);
                Label1.Visible = true;
                DropDownList1.Visible = true;
                Label10.Visible = false;
            }
            else
            {
                Label10.Visible = true;
                Label10.Text = "No " + b.status + " Shift Request";
            }
        }
    }
}