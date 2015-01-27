using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_managedrequest : System.Web.UI.Page
{
    DAL d = new DAL();
    BAL b = new BAL();
    string connection = ConfigurationManager.ConnectionStrings["projectConnectionString"].ConnectionString;
    SqlConnection con;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id2"] == null)
            Response.Redirect("../login/login.aspx");
        con = new SqlConnection(connection);
    }
    public DataTable show()
    {
        GridView1.Visible = true;
        DropDownList2.Visible = true;
        Label2.Visible = true;
        GridView1.PageSize = int.Parse(DropDownList2.SelectedItem.Text);
        DataTable dt = new DataTable();
        dt.Columns.Add("empid", typeof(string));
        dt.Columns.Add("empname", typeof(string));
        dt.Columns.Add("type", typeof(string));
        dt.Columns.Add("date", typeof(string));
        dt.Columns.Add("status", typeof(string));
        dt.Columns.Add("authority", typeof(string));

        string show = DropDownList1.SelectedValue;
        if (show == "Show All" || show == "Leave Application")
        {
            SqlDataAdapter adp = new SqlDataAdapter("SELECT tblemployee.*,tblleavemaster.empid as expr1, tblleavemaster.fromdate, tblleavemaster.status FROM tblleavemaster INNER JOIN tblemployee ON tblleavemaster.empid = tblemployee.empid where (tblleavemaster.status = 'Approved' OR tblleavemaster.status = 'Rejected') and (tblemployee.empid!=20112)", con);
            DataTable dt1 = new DataTable();
            adp.Fill(dt1);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["empid"] = dt1.Rows[i]["empid"];
                dr["empname"] = dt1.Rows[i]["empname"];
                dr["type"] = "Leave";
                dr["date"] = dt1.Rows[i]["fromdate"];
                dr["status"] = dt1.Rows[i]["status"];
                b.empid = int.Parse(dt1.Rows[i]["expr1"].ToString());
                DataTable dt2 = b.getlocation(b);
                b.address = dt2.Rows[0]["address"].ToString();
                if (b.empid == 20111)
                {
                    dr["authority"] = "Admin";
                }
                else
                {
                    if (b.empid == 20111)
                    {
                        b.deptname = "Admin";
                        SqlDataAdapter adp1 = new SqlDataAdapter("SELECT empname FROM tblemployee WHERE (deptname = @b)", con);
                        adp1.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
                        DataTable dt3 = new DataTable();
                        adp1.Fill(dt3);
                        dr["authority"] = dt3.Rows[0]["empname"].ToString();
                    }
                    else if (b.empid == 20001 || b.empid == 20018 || b.empid == 20037 || b.empid == 20047 || b.empid == 20057)
                    {
                        b.deptname = "HR";
                        SqlDataAdapter adp1 = new SqlDataAdapter("SELECT empname FROM tblemployee WHERE (deptname = @b)", con);
                        adp1.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
                        DataTable dt3 = new DataTable();
                        adp1.Fill(dt3);
                        dr["authority"] = dt3.Rows[0]["empname"].ToString();
                    }
                    else
                    {
                        b.deptname = "Centerhead";
                        SqlDataAdapter adp1 = new SqlDataAdapter("SELECT empname FROM tblemployee WHERE (address = @a) and (deptname = @b)", con);
                        adp1.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
                        adp1.SelectCommand.Parameters.AddWithValue("@a", b.address);
                        DataTable dt3 = new DataTable();
                        adp1.Fill(dt3);
                        dr["authority"] = dt3.Rows[0]["empname"].ToString();
                    }
                }
                dt.Rows.Add(dr);
            }
        }
        if (show == "Show All" || show == "Shift Change")
        {
            SqlDataAdapter adp2 = new SqlDataAdapter("SELECT tblemployee.*,tblshiftrequest.empid as expr1, tblshiftrequest.shiftchangefrom, tblshiftrequest.status FROM tblshiftrequest INNER JOIN tblemployee ON tblshiftrequest.empid = tblemployee.empid where  (tblshiftrequest.status = 'Approved' OR tblshiftrequest.status = 'Rejected') and (tblemployee.empid!=20112)", con);
            DataTable dt4 = new DataTable();
            adp2.Fill(dt4);
            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["empid"] = dt4.Rows[i]["empid"];
                dr["empname"] = dt4.Rows[i]["empname"];
                dr["type"] = "Shift";
                dr["date"] = dt4.Rows[i]["shiftchangefrom"];
                dr["status"] = dt4.Rows[i]["status"];
                b.empid = int.Parse(dt4.Rows[i]["expr1"].ToString());
                DataTable dt2 = b.getlocation(b);
                b.address = dt2.Rows[0]["address"].ToString();
                if (b.empid == 20111)
                {
                    dr["authority"] = "Admin";
                }
                else
                {
                    if (b.empid == 20111)
                    {
                        b.deptname = "Admin";
                        SqlDataAdapter adp1 = new SqlDataAdapter("SELECT empname FROM tblemployee WHERE (deptname = @b)", con);
                        adp1.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
                        DataTable dt3 = new DataTable();
                        adp1.Fill(dt3);
                        dr["authority"] = dt3.Rows[0]["empname"].ToString();
                    }
                    else if (b.empid == 20001 || b.empid == 20018 || b.empid == 20037 || b.empid == 20047 || b.empid == 20057)
                    {
                        b.deptname = "HR";
                        SqlDataAdapter adp1 = new SqlDataAdapter("SELECT empname FROM tblemployee WHERE (deptname = @b)", con);
                        adp1.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
                        DataTable dt3 = new DataTable();
                        adp1.Fill(dt3);
                        dr["authority"] = dt3.Rows[0]["empname"].ToString();
                    }
                    else
                    {
                        b.deptname = "Centerhead";
                        SqlDataAdapter adp1 = new SqlDataAdapter("SELECT empname FROM tblemployee WHERE (address = @a) and (deptname = @b)", con);
                        adp1.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
                        adp1.SelectCommand.Parameters.AddWithValue("@a", b.address);
                        DataTable dt3 = new DataTable();
                        adp1.Fill(dt3);
                        dr["authority"] = dt3.Rows[0]["empname"].ToString();
                    }
                }
                dt.Rows.Add(dr);
            }
        }
        if (show == "Show All" || show == "Correction Request")
        {
            SqlDataAdapter adp = new SqlDataAdapter("SELECT tblemployee.*,tblcorrection.empid as expr1, tblcorrection.date, tblcorrection.status FROM tblcorrection INNER JOIN tblemployee ON tblcorrection.empid = tblemployee.empid where  (tblcorrection.status = 'Approved' OR tblcorrection.status = 'Rejected') and (tblemployee.empid!=20112)", con);
            DataTable dt1 = new DataTable();
            adp.Fill(dt1);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["empid"] = dt1.Rows[i]["empid"];
                dr["empname"] = dt1.Rows[i]["empname"];
                dr["type"] = "Correcttion";
                dr["date"] = dt1.Rows[i]["date"];
                dr["status"] = dt1.Rows[i]["status"];
                b.empid = int.Parse(dt1.Rows[i]["expr1"].ToString());
                DataTable dt2 = b.getlocation(b);
                b.address = dt2.Rows[0]["address"].ToString();
                if (b.empid == 20111)
                {
                    dr["authority"] = "Admin";
                }
                else
                {
                    if (b.empid == 20111)
                    {
                        b.deptname = "Admin";
                        SqlDataAdapter adp1 = new SqlDataAdapter("SELECT empname FROM tblemployee WHERE (deptname = @b)", con);
                        adp1.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
                        DataTable dt3 = new DataTable();
                        adp1.Fill(dt3);
                        dr["authority"] = dt3.Rows[0]["empname"].ToString();
                    }
                    else if (b.empid == 20001 || b.empid == 20018 || b.empid == 20037 || b.empid == 20047 || b.empid == 20057)
                    {
                        b.deptname = "HR";
                        SqlDataAdapter adp1 = new SqlDataAdapter("SELECT empname FROM tblemployee WHERE (deptname = @b)", con);
                        adp1.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
                        DataTable dt3 = new DataTable();
                        adp1.Fill(dt3);
                        dr["authority"] = dt3.Rows[0]["empname"].ToString();
                    }
                    else
                    {
                        b.deptname = "Centerhead";
                        SqlDataAdapter adp1 = new SqlDataAdapter("SELECT empname FROM tblemployee WHERE (address = @a) and (deptname = @b)", con);
                        adp1.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
                        adp1.SelectCommand.Parameters.AddWithValue("@a", b.address);
                        DataTable dt3 = new DataTable();
                        adp1.Fill(dt3);
                        dr["authority"] = dt3.Rows[0]["empname"].ToString();
                    }
                }
                dt.Rows.Add(dr);
            }
        }
        if (show == "Show All" || show == "Regularisation Request")
        {
            SqlDataAdapter adp = new SqlDataAdapter("SELECT tblemployee.*,tblregularisation.empid as expr1, tblregularisation.fromdate, tblregularisation.status FROM tblregularisation INNER JOIN tblemployee ON tblregularisation.empid = tblemployee.empid where  (tblregularisation.status = 'Approved' OR tblregularisation.status = 'Rejected') and (tblemployee.empid!=20112)", con);
            DataTable dt1 = new DataTable();
            adp.Fill(dt1);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["empid"] = dt1.Rows[i]["empid"];
                dr["empname"] = dt1.Rows[i]["empname"];
                dr["type"] = "Regularisation";
                dr["date"] = dt1.Rows[i]["fromdate"];
                dr["status"] = dt1.Rows[i]["status"];
                b.empid = int.Parse(dt1.Rows[i]["expr1"].ToString());
                DataTable dt2 = b.getlocation(b);
                b.address = dt2.Rows[0]["address"].ToString();
                if (b.empid == 20111)
                {
                    dr["authority"] = "Admin";
                }
                else
                {
                    if (b.empid == 20111)
                    {
                        b.deptname = "Admin";
                        SqlDataAdapter adp1 = new SqlDataAdapter("SELECT empname FROM tblemployee WHERE (deptname = @b)", con);
                        adp1.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
                        DataTable dt3 = new DataTable();
                        adp1.Fill(dt3);
                        dr["authority"] = dt3.Rows[0]["empname"].ToString();
                    }
                    else if (b.empid == 20001 || b.empid == 20018 || b.empid == 20037 || b.empid == 20047 || b.empid == 20057)
                    {
                        b.deptname = "HR";
                        SqlDataAdapter adp1 = new SqlDataAdapter("SELECT empname FROM tblemployee WHERE (deptname = @b)", con);
                        adp1.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
                        DataTable dt3 = new DataTable();
                        adp1.Fill(dt3);
                        dr["authority"] = dt3.Rows[0]["empname"].ToString();
                    }
                    else
                    {
                        b.deptname = "Centerhead";
                        SqlDataAdapter adp1 = new SqlDataAdapter("SELECT empname FROM tblemployee WHERE (address = @a) and (deptname = @b)", con);
                        adp1.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
                        adp1.SelectCommand.Parameters.AddWithValue("@a", b.address);
                        DataTable dt3 = new DataTable();
                        adp1.Fill(dt3);
                        dr["authority"] = dt3.Rows[0]["empname"].ToString();
                    }
                }
                dt.Rows.Add(dr);
            }
        }
        if (show == "Show All" || show == "Daily Attendance Request")
        {
            SqlDataAdapter adp = new SqlDataAdapter("SELECT tblemployee.*,tblattrequest.empid as expr1, tblattrequest.date, tblattrequest.status FROM tblattrequest INNER JOIN tblemployee ON tblattrequest.empid = tblemployee.empid where  (tblattrequest.status = 'Approved' OR tblattrequest.status = 'Rejected') and (tblemployee.empid!=20112)", con);
            DataTable dt1 = new DataTable();
            adp.Fill(dt1);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["empid"] = dt1.Rows[i]["empid"];
                dr["empname"] = dt1.Rows[i]["empname"];
                dr["type"] = "Daily Attendance";
                dr["date"] = dt1.Rows[i]["date"];
                dr["status"] = dt1.Rows[i]["status"];
                b.empid = int.Parse(dt1.Rows[i]["expr1"].ToString());
                DataTable dt2 = b.getlocation(b);
                b.address = dt2.Rows[0]["address"].ToString();
                if (b.empid == 20111)
                {
                    dr["authority"] = "Admin";
                }
                else
                {
                    if (b.empid == 20111)
                    {
                        b.deptname = "Admin";
                        SqlDataAdapter adp1 = new SqlDataAdapter("SELECT empname FROM tblemployee WHERE (deptname = @b)", con);
                        adp1.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
                        DataTable dt3 = new DataTable();
                        adp1.Fill(dt3);
                        dr["authority"] = dt3.Rows[0]["empname"].ToString();
                    }
                    else if (b.empid == 20001 || b.empid == 20018 || b.empid == 20037 || b.empid == 20047 || b.empid == 20057)
                    {
                        b.deptname = "HR";
                        SqlDataAdapter adp1 = new SqlDataAdapter("SELECT empname FROM tblemployee WHERE (deptname = @b)", con);
                        adp1.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
                        DataTable dt3 = new DataTable();
                        adp1.Fill(dt3);
                        dr["authority"] = dt3.Rows[0]["empname"].ToString();
                    }
                    else
                    {
                        b.deptname = "Centerhead";
                        SqlDataAdapter adp1 = new SqlDataAdapter("SELECT empname FROM tblemployee WHERE (address = @a) and (deptname = @b)", con);
                        adp1.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
                        adp1.SelectCommand.Parameters.AddWithValue("@a", b.address);
                        DataTable dt3 = new DataTable();
                        adp1.Fill(dt3);
                        dr["authority"] = dt3.Rows[0]["empname"].ToString();
                    }
                }
                dt.Rows.Add(dr);
            }
        }
        if (show == "Show All" || show == "Expense Request")
        {
            SqlDataAdapter adp = new SqlDataAdapter("SELECT tblemployee.*,tblexpense.empid as expr1, tblexpense.date, tblexpense.status FROM tblexpense INNER JOIN tblemployee ON tblexpense.empid = tblemployee.empid where  (tblexpense.status = 'Approved' OR tblexpense.status = 'Rejected') and (tblemployee.empid!=20112)", con);
            DataTable dt1 = new DataTable();
            adp.Fill(dt1);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["empid"] = dt1.Rows[i]["empid"];
                dr["empname"] = dt1.Rows[i]["empname"];
                dr["type"] = "Expense";
                dr["date"] = dt1.Rows[i]["date"];
                dr["status"] = dt1.Rows[i]["status"];
                b.empid = int.Parse(dt1.Rows[i]["expr1"].ToString());
                DataTable dt2 = b.getlocation(b);
                b.address = dt2.Rows[0]["address"].ToString();
                if (b.empid == 20111)
                {
                    dr["authority"] = "Admin";
                }
                else
                {
                    if (b.empid == 20111)
                    {
                        b.deptname = "Admin";
                        SqlDataAdapter adp1 = new SqlDataAdapter("SELECT empname FROM tblemployee WHERE (deptname = @b)", con);
                        adp1.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
                        DataTable dt3 = new DataTable();
                        adp1.Fill(dt3);
                        dr["authority"] = dt3.Rows[0]["empname"].ToString();
                    }
                    else if (b.empid == 20001 || b.empid == 20018 || b.empid == 20037 || b.empid == 20047 || b.empid == 20057)
                    {
                        b.deptname = "HR";
                        SqlDataAdapter adp1 = new SqlDataAdapter("SELECT empname FROM tblemployee WHERE (deptname = @b)", con);
                        adp1.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
                        DataTable dt3 = new DataTable();
                        adp1.Fill(dt3);
                        dr["authority"] = dt3.Rows[0]["empname"].ToString();
                    }
                    else
                    {
                        b.deptname = "Centerhead";
                        SqlDataAdapter adp1 = new SqlDataAdapter("SELECT empname FROM tblemployee WHERE (address = @a) and (deptname = @b)", con);
                        adp1.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
                        adp1.SelectCommand.Parameters.AddWithValue("@a", b.address);
                        DataTable dt3 = new DataTable();
                        adp1.Fill(dt3);
                        dr["authority"] = dt3.Rows[0]["empname"].ToString();
                    }
                }
                dt.Rows.Add(dr);
            }
        }
        if (show == "Show All" || show == "Advance Requisition")
        {
            SqlDataAdapter adp = new SqlDataAdapter("SELECT tblemployee.*,tbladvance.empid as expr1, tbladvance.date, tbladvance.status FROM tbladvance INNER JOIN tblemployee ON tbladvance.empid = tblemployee.empid where  (tbladvance.status = 'Approved' OR tbladvance.status = 'Rejected') and (tblemployee.empid!=20112)", con);
            DataTable dt1 = new DataTable();
            adp.Fill(dt1);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["empid"] = dt1.Rows[i]["empid"];
                dr["empname"] = dt1.Rows[i]["empname"];
                dr["type"] = "Advance";
                dr["date"] = dt1.Rows[i]["date"];
                dr["status"] = dt1.Rows[i]["status"];
                b.empid = int.Parse(dt1.Rows[i]["expr1"].ToString());
                DataTable dt2 = b.getlocation(b);
                b.address = dt2.Rows[0]["address"].ToString();
                if (b.empid == 20111)
                {
                    dr["authority"] = "Admin";
                }
                else
                {
                    if (b.empid == 20111)
                    {
                        b.deptname = "Admin";
                        SqlDataAdapter adp1 = new SqlDataAdapter("SELECT empname FROM tblemployee WHERE (deptname = @b)", con);
                        adp1.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
                        DataTable dt3 = new DataTable();
                        adp1.Fill(dt3);
                        dr["authority"] = dt3.Rows[0]["empname"].ToString();
                    }
                    else if (b.empid == 20001 || b.empid == 20018 || b.empid == 20037 || b.empid == 20047 || b.empid == 20057)
                    {
                        b.deptname = "HR";
                        SqlDataAdapter adp1 = new SqlDataAdapter("SELECT empname FROM tblemployee WHERE (deptname = @b)", con);
                        adp1.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
                        DataTable dt3 = new DataTable();
                        adp1.Fill(dt3);
                        dr["authority"] = dt3.Rows[0]["empname"].ToString();
                    }
                    else
                    {
                        b.deptname = "Centerhead";
                        SqlDataAdapter adp1 = new SqlDataAdapter("SELECT empname FROM tblemployee WHERE (address = @a) and (deptname = @b)", con);
                        adp1.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
                        adp1.SelectCommand.Parameters.AddWithValue("@a", b.address);
                        DataTable dt3 = new DataTable();
                        adp1.Fill(dt3);
                        dr["authority"] = dt3.Rows[0]["empname"].ToString();
                    }
                }
                dt.Rows.Add(dr);
            }
        }
        if (show == "Show All" || show == "Claim Advance Request")
        {
            SqlDataAdapter adp = new SqlDataAdapter("SELECT tblemployee.*,tblclaim.empid as expr1, tblclaim.date, tblclaim.status FROM tblclaim INNER JOIN tblemployee ON tblclaim.empid = tblemployee.empid where  (tblclaim.status = 'Approved' OR tblclaim.status = 'Rejected') and (tblemployee.empid!=20112)", con);
            DataTable dt1 = new DataTable();
            adp.Fill(dt1);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["empid"] = dt1.Rows[i]["empid"];
                dr["empname"] = dt1.Rows[i]["empname"];
                dr["type"] = "Claim Advance";
                dr["date"] = dt1.Rows[i]["date"];
                dr["status"] = dt1.Rows[i]["status"];
                b.empid = int.Parse(dt1.Rows[i]["expr1"].ToString());
                DataTable dt2 = b.getlocation(b);
                b.address = dt2.Rows[0]["address"].ToString();
                if (b.empid == 20111)
                {
                    dr["authority"] = "Admin";
                }
                else
                {
                    if (b.empid == 20111)
                    {
                        b.deptname = "Admin";
                        SqlDataAdapter adp1 = new SqlDataAdapter("SELECT empname FROM tblemployee WHERE (deptname = @b)", con);
                        adp1.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
                        DataTable dt3 = new DataTable();
                        adp1.Fill(dt3);
                        dr["authority"] = dt3.Rows[0]["empname"].ToString();
                    }
                    else if (b.empid == 20001 || b.empid == 20018 || b.empid == 20037 || b.empid == 20047 || b.empid == 20057)
                    {
                        b.deptname = "HR";
                        SqlDataAdapter adp1 = new SqlDataAdapter("SELECT empname FROM tblemployee WHERE (deptname = @b)", con);
                        adp1.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
                        DataTable dt3 = new DataTable();
                        adp1.Fill(dt3);
                        dr["authority"] = dt3.Rows[0]["empname"].ToString();
                    }
                    else
                    {
                        b.deptname = "Centerhead";
                        SqlDataAdapter adp1 = new SqlDataAdapter("SELECT empname FROM tblemployee WHERE (address = @a) and (deptname = @b)", con);
                        adp1.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
                        adp1.SelectCommand.Parameters.AddWithValue("@a", b.address);
                        DataTable dt3 = new DataTable();
                        adp1.Fill(dt3);
                        dr["authority"] = dt3.Rows[0]["empname"].ToString();
                    }
                }
                dt.Rows.Add(dr);
            }
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
        return dt;
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        show();
        if (DropDownList1.SelectedItem.Text=="<-Select->")
        {
            Label2.Visible = false;
            DropDownList2.Visible = false;
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = show();
        GridView1.DataBind();
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        show();
    }
}