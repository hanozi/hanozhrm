using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

public partial class Home_leaveapplication : System.Web.UI.Page
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
        con = new SqlConnection(connection);
        if (!IsPostBack)
        {
            gridfillleaverequest();    
        }
        MultiView1.ActiveViewIndex = 0;
    }
    void gridfillleaverequest()
    {
        string empid = Session["id2"].ToString();
        b.empid = int.Parse(empid);
        GridView1.DataSource = b.gridfillleaverequest(b);
        GridView1.DataBind();
        int check = GridView1.Rows.Count;
        if (check != 0)
        {
            GroupGridView(GridView1.Rows, 0, 4);
            Label1.Visible = true;
            DropDownList1.Visible = true;
            Label10.Visible = false;
        }
        else
        {
            Label1.Visible = false;
            DropDownList1.Visible = false;
            Label10.Visible = true;
            Label10.Text = "No Leave Applied";
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
        Label5.Text = "";
        GridView2.Visible = false;
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        Label5.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        int count = GridView2.Rows.Count;
        SqlDataAdapter adp = new SqlDataAdapter("SELECT PL from tblleavebalance where empid=@a", con);
        b.empid = int.Parse(Session["id2"].ToString());
        adp.SelectCommand.Parameters.AddWithValue("@a", b.empid);
        DataTable ds = new DataTable();
        adp.Fill(ds);
        int balance = int.Parse(ds.Rows[0]["PL"].ToString());
        string f = TextBox2.Text + " 00:00:00";
        string t = TextBox3.Text + " 00:00:00";
        DateTime from = DateTime.Parse(f);
        DateTime to = DateTime.Parse(t);
        TimeSpan c = to - from;
        int day = c.Days + 1;
        int final = balance - day;
        if(final<0 )
        {
            MultiView1.ActiveViewIndex = 1;
            DropDownList2.ClearSelection();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            GridView2.Visible = false;
            Label5.Text = "Don't have sufficent leave balance to apply. Available leave = "+balance+" Day";
        }
        else
        {
            Label5.Text = "";
            Label2.Text = ds.Rows[0]["PL"].ToString();
            SqlDataAdapter adp1 = new SqlDataAdapter("SELECT leavemerge from tblleavemaster", con);
            DataTable ds1 = new DataTable();
            adp1.Fill(ds1);
            int merge = ds1.Rows.Count - 1;
            int merge1 = int.Parse(ds1.Rows[merge]["leavemerge"].ToString())+1;
            foreach (GridViewRow gvrow in GridView2.Rows)
            {
                DropDownList leaved = (DropDownList)gvrow.FindControl("DropDownList3");
                DropDownList leavet = (DropDownList)gvrow.FindControl("DropDownList4");
                Label date = (Label)gvrow.FindControl("Label2");
                b.empid = int.Parse(Session["id2"].ToString());
                b.reason = TextBox1.Text;
                b.leaveduration = leaved.Text;
                b.leavetype = leavet.Text;
                string ffdate = date.Text + " 00:00:00";
                DateTime fdate = DateTime.Parse(ffdate);
                string datef = fdate.ToString("yyyy-MM-dd");
                b.fromdate = datef;
                b.todate = datef;
                b.status = "Pending";
                b.leavemerge = merge1;
                b.count = 1;
                b.addleaverequest(b);
            }
            DropDownList2.ClearSelection();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            GridView2.Visible = false;
            gridfillleaverequest();
            MultiView1.ActiveViewIndex = 0;
        }
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
            gridfillleaverequest();
        }
        else
        {
            string empid = Session["id2"].ToString();
            b.empid = int.Parse(empid);
            b.status = DropDownList1.SelectedValue.ToString();
            GridView1.DataSource = b.gridfillleaverequestlist(b);
            GridView1.DataBind();
            int check = GridView1.Rows.Count;
            if (check != 0)
            {
                GroupGridView(GridView1.Rows, 0, 4);
                Label1.Visible = true;
                DropDownList1.Visible = true;
                Label10.Visible = false;
            }
            else
            {
                Label10.Visible = true;
                Label10.Text = "No "+ b.status +" Leave Request";
            }
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "LeaveApplication.xls"));
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        GridView1.AllowPaging = false;
        gridfillleaverequest();
        //Change the Header Row back to white color
        GridView1.HeaderRow.Style.Add("background-color", "#FFFFFF");
        //Applying stlye to gridview header cells
        for (int i = 0; i < GridView1.HeaderRow.Cells.Count; i++)
        {
            GridView1.HeaderRow.Cells[i].Style.Add("background-color", "#df5015");
        }
        GridView1.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Leaveapplication.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        GridView1.AllowPaging = false;
        gridfillleaverequest();
        GridView1.RenderControl(hw);
        GridView1.HeaderRow.Style.Add("width", "15%");
        GridView1.HeaderRow.Style.Add("font-size", "10px");
        GridView1.Style.Add("text-decoration", "none");
        GridView1.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
        GridView1.Style.Add("font-size", "8px");
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
    }
}