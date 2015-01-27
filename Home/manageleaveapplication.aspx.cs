using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_approveleaveapplication : System.Web.UI.Page
{
    DAL d = new DAL();
    BAL b = new BAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id2"] == null)
            Response.Redirect("../login/login.aspx");
        if (!IsPostBack)
        {
            gridfillmanageleaveapplication();
        }
    }
    void gridfillmanageleaveapplication()
    {
        b.empid = int.Parse(Session["id2"].ToString());
        DataTable dt = b.getlocation(b);
        b.address = dt.Rows[0]["address"].ToString();
        GridView1.DataSource = b.gridfillmanageleaveapplication(b);
        GridView1.DataBind();
        int check = GridView1.Rows.Count;
        if (check != 0)
        {
            GroupGridView(GridView1.Rows, 0, 6);
            Button1.Visible = true;
            Button2.Visible = true;
        }
        else
        {
            Button1.Visible = false;
            Button2.Visible = false;
            Label10.Text = "No Pending Leave Application";
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
            Label ch = (Label)gvrc[i].FindControl("Label9");
            string che = ch.Text;
            Label ch1 = (Label)gvrc[i - 1].FindControl("Label9");
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        string str = string.Empty;
        foreach (GridViewRow gvrow in GridView1.Rows)
        {
            CheckBox chk = (CheckBox)gvrow.FindControl("CheckBox1");
            if (chk.Checked)
            {
                Label ch = (Label)gvrow.FindControl("Label9");
                string che = ch.Text;
                b.leavemerge = int.Parse(che);
                b.status = "Approved";
                b.approveleaverequest(b);
            }
        }
        gridfillmanageleaveapplication();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string str = string.Empty;
        foreach (GridViewRow gvrow in GridView1.Rows)
        {
            CheckBox chk = (CheckBox)gvrow.FindControl("CheckBox1");
            if (chk.Checked)
            {
                Label ch = (Label)gvrow.FindControl("Label9");
                string che = ch.Text;
                b.leavemerge = int.Parse(che);
                b.status = "Rejected";
                b.rejectleaverequest(b);
            }
        }
        gridfillmanageleaveapplication();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;

        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);

        GridView1.AllowPaging = false;
        GridView1.DataBind();

        //Change the Header Row back to white color
        GridView1.HeaderRow.Style.Add("background-color", "#FFFFFF");

        //Apply style to Individual Cells
        GridView1.HeaderRow.Cells[0].Style.Add("background-color", "green");
        GridView1.HeaderRow.Cells[1].Style.Add("background-color", "green");
        GridView1.HeaderRow.Cells[2].Style.Add("background-color", "green");
        GridView1.HeaderRow.Cells[3].Style.Add("background-color", "green");

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            GridViewRow row = GridView1.Rows[i];

            //Change Color back to white
            row.BackColor = System.Drawing.Color.White;

            //Apply text style to each Row
            row.Attributes.Add("class", "textmode");

            //Apply style to Individual Cells of Alternating Row
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#C2D69B");
                row.Cells[1].Style.Add("background-color", "#C2D69B");
                row.Cells[2].Style.Add("background-color", "#C2D69B");
                row.Cells[3].Style.Add("background-color", "#C2D69B");
            }
        }
        GridView1.RenderControl(hw);

        //style to format numbers to string
        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        Response.Write(style);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
}