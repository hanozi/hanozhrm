using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.DataVisualization.Charting;
using System.Collections;
using System.Configuration;

public partial class Home_Home : System.Web.UI.Page
{
    DAL d = new DAL();
    BAL b = new BAL();
    string connection = ConfigurationManager.ConnectionStrings["projectConnectionString"].ConnectionString;
    SqlConnection con;
    DataTable dt1;
    DataTable dt2;
    DataTable dt3;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id2"] == null)
            Response.Redirect("../login/login.aspx");
        string empid = Session["id2"].ToString();
        if (empid == "20112")
        {
            LinkButton10.Visible = true;
        }
        con = new SqlConnection(connection);
        if (!IsPostBack)
        {
            gridfillleavebalance();
            gridfillthought();
            createdatatable();
            pendinggetdata();
            checkpayroll();
        }
        if (Session["dept"] != null)
        {
            string abc = Session["dept"].ToString();
            if (abc == "Accounts" || abc == "Finance")
            {
                div1.Visible = false;
            }
        }
    }
    void checkpayroll()
    {
        DateTime check = DateTime.Now;
        int xyz = check.Month - 1;
        int month;
        if (xyz == 0)
        {
            month = 12;
        }
        else
        {
            month = xyz;
        }
        SqlDataAdapter pay = new SqlDataAdapter("Select * from tblpayroll where paymonth=@a", con);
        pay.SelectCommand.Parameters.AddWithValue("@a", month);
        DataTable pay1 = new DataTable();
        pay.Fill(pay1);
        if (pay1.Rows.Count == 0)
        {
            LinkButton3.Visible = true;
        }
    }
    void Page_PreInit(object sender, EventArgs e)
    {
        if (Session["dept"] != null)
        {
            string abc = Session["dept"].ToString();
            if (abc == "Accounts" || abc == "Finance")
            {
                this.MasterPageFile = (string)"employee.master";
            }
        }
        else
        {
            Response.Redirect("../login/login.aspx");
        }
    }
    void gridfillthought()
    {
        GridView3.DataSource = b.gridfillthought(b);
        GridView3.DataBind();
    }
    void gridfillleavebalance()
    {
        b.empid = int.Parse(Session["id2"].ToString());
        GridView1.DataSource = b.gridfillleavebalance(b);
        GridView1.DataBind();
    }
    public DataTable createdatatable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Empname", typeof(string));
        dt.Columns.Add("Department", typeof(string));
        dt.Columns.Add("DOB", typeof(string));
        dt.Columns.Add("Location", typeof(string));

        SqlDataAdapter adp = new SqlDataAdapter("select empname,deptname,dob,address from tblemployee", con);
        dt1 = new DataTable();
        adp.Fill(dt1);
        DateTime time1 = DateTime.Now;
        string month = time1.Month.ToString();
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            DataRow dr = dt.NewRow();
            DateTime check = DateTime.Parse(dt1.Rows[i]["dob"].ToString());
            string month1 = check.Month.ToString();
            if (month1 == month && check.Day>=time1.Day)
            {
                dr["Empname"] = dt1.Rows[i]["empname"];
                dr["Department"] = dt1.Rows[i]["deptname"];
                DateTime dob = DateTime.Parse(dt1.Rows[i]["dob"].ToString());
                string day = dob.Day.ToString();
                string month2 = dob.Month.ToString();
                string fdob = day + "-" + month2;
                dr["dob"] = fdob;
                dr["Location"] = dt1.Rows[i]["address"];
                dt.Rows.Add(dr);
            }
        }
        if (dt.Rows.Count == 0)
        {
            Label28.Text = "No more birthday babies in current month";
        }
        GridView2.DataSource = dt;
        GridView2.DataBind();
        return dt;
    }
    public void pendinggetdata()
    {
        int empid = int.Parse(Session["id2"].ToString());
        SqlDataAdapter adp9 = new SqlDataAdapter("SELECT address,deptname from tblemployee where empid=@a", con);
        adp9.SelectCommand.Parameters.AddWithValue("@a", empid);
        DataTable dt10 = new DataTable();
        adp9.Fill(dt10);
        if (empid != 20111 && empid != 20112)
        {
            b.address = dt10.Rows[0]["address"].ToString();
            b.deptname = "Centerhead";
            Label14.Text = "Pending Request For : " + b.address;
            DataTable dt2 = b.gridfillmanageleaveapplication(b);
            DataTable dt3 = b.gridfillmanageshiftrequest(b);
            DataTable dt4 = b.gridfillmanagecorrectionrequest(b);
            DataTable dt5 = b.gridfillmanageregularisationrequest(b);
            DataTable dt6 = b.gridfillmanageattrequest(b);
            DataTable dt7 = b.gridfillmanageexpenserequest(b);
            DataTable dt8 = b.gridfillmanageadvancerequest(b);
            DataTable dt9 = b.gridfillmanageclaimadvrequest(b);
            Label1.Text = dt2.Rows.Count.ToString();
            Label3.Text = dt3.Rows.Count.ToString();
            Label4.Text = dt4.Rows.Count.ToString();
            Label9.Text = dt5.Rows.Count.ToString();
            Label10.Text = dt6.Rows.Count.ToString();
            Label11.Text = dt7.Rows.Count.ToString();
            Label12.Text = dt8.Rows.Count.ToString();
            Label13.Text = dt9.Rows.Count.ToString();
        }
        else if (empid == 20112)
        {
            b.address = "HR";
            Label14.Text = "Pending Request For : " + b.address + "'s";
            DataTable dt2 = b.gridfillmanageleaveapplication(b);
            DataTable dt3 = b.gridfillmanageshiftrequest(b);
            DataTable dt4 = b.gridfillmanagecorrectionrequest(b);
            DataTable dt5 = b.gridfillmanageregularisationrequest(b);
            DataTable dt6 = b.gridfillmanageattrequest(b);
            DataTable dt7 = b.gridfillmanageexpenserequest(b);
            DataTable dt8 = b.gridfillmanageadvancerequest(b);
            DataTable dt9 = b.gridfillmanageclaimadvrequest(b);
            Label1.Text = dt2.Rows.Count.ToString();
            Label3.Text = dt3.Rows.Count.ToString();
            Label4.Text = dt4.Rows.Count.ToString();
            Label9.Text = dt5.Rows.Count.ToString();
            Label10.Text = dt6.Rows.Count.ToString();
            Label11.Text = dt7.Rows.Count.ToString();
            Label12.Text = dt8.Rows.Count.ToString();
            Label13.Text = dt9.Rows.Count.ToString();
        }
        else
        {
            b.address = "Centerhead";
            Label14.Text = "Pending Request For : " + b.address + "'s";
            DataTable dt2 = b.gridfillmanageleaveapplication(b);
            DataTable dt3 = b.gridfillmanageshiftrequest(b);
            DataTable dt4 = b.gridfillmanagecorrectionrequest(b);
            DataTable dt5 = b.gridfillmanageregularisationrequest(b);
            DataTable dt6 = b.gridfillmanageattrequest(b);
            DataTable dt7 = b.gridfillmanageexpenserequest(b);
            DataTable dt8 = b.gridfillmanageadvancerequest(b);
            DataTable dt9 = b.gridfillmanageclaimadvrequest(b);
            Label1.Text = dt2.Rows.Count.ToString();
            Label3.Text = dt3.Rows.Count.ToString();
            Label4.Text = dt4.Rows.Count.ToString();
            Label9.Text = dt5.Rows.Count.ToString();
            Label10.Text = dt6.Rows.Count.ToString();
            Label11.Text = dt7.Rows.Count.ToString();
            Label12.Text = dt8.Rows.Count.ToString();
            Label13.Text = dt9.Rows.Count.ToString();
        }

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Home/leaveapplication.aspx");
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Home/shiftchangerequest.aspx");
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Home/attendance.aspx");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("manageleaveapplication.aspx");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("manageshiftrequest.aspx");
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("generatepayroll.aspx");
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Response.Redirect("managecorrectionrequest.aspx");
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Response.Redirect("manageregularisationrequest.aspx");
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Response.Redirect("manageattrequest.aspx");
    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        Response.Redirect("manageexpenserequest.aspx");
    }
    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        Response.Redirect("manageadvancerequisition.aspx");
    }
    protected void LinkButton9_Click(object sender, EventArgs e)
    {
        Response.Redirect("manageclaimadvance.aspx");
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        GridView2.DataSource = createdatatable();
        GridView2.DataBind();
    }
    protected void LinkButton10_Click(object sender, EventArgs e)
    {
        Response.Redirect("managedrequest.aspx");
    }
}