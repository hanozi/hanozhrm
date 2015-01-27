using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Home_generatepayroll : System.Web.UI.Page
{
    DAL d = new DAL();
    BAL b = new BAL();
    string connection = ConfigurationManager.ConnectionStrings["projectConnectionString"].ConnectionString;
    SqlConnection con;
    DataTable dt1;
    string warn = "Warning";
    int warn1 = 0;
    DateTime today = DateTime.Now;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id2"] == null)
            Response.Redirect("../login/login.aspx");
        con = new SqlConnection(connection);
        int xyz = today.Month - 1;
        int abc = today.Year;
        ViewState["month"] = abc;
        ViewState["year"] = xyz;
        if (xyz == 0)
        {
            xyz = 12;
            abc = abc - 1;
            ViewState["month"] = abc;
            ViewState["year"] = xyz;
        }
        Label2.Text = "Generate Payroll for the Month : " + xyz + " and Year : " + abc;
        if (!IsPostBack)
        {
            gridfillpayroll();
        }
    }
    public void createdatatable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Date", typeof(string));
        dt.Columns.Add("InTime", typeof(string));
        dt.Columns.Add("OutTime", typeof(string));
        dt.Columns.Add("ShiftTotalHrs", typeof(string));
        dt.Columns.Add("ShiftInTime", typeof(string));
        dt.Columns.Add("ShiftOutTime", typeof(string));
        dt.Columns.Add("Type", typeof(string));
        dt.Columns.Add("DayHalf", typeof(string));
        dt.Columns.Add("Attendance", typeof(string));
        dt.Columns.Add("Late", typeof(string));
        dt.Columns.Add("Early", typeof(string));
        dt.Columns.Add("Actualwork", typeof(string));
        dt.Columns.Add("Presence", typeof(string));
        dt.Columns.Add("OT", typeof(string));
        dt.Columns.Add("leavetype", typeof(string));
        dt.Columns.Add("Remarks", typeof(string));

        int day = 1;
        int m = int.Parse(ViewState["month"].ToString());
        int y = int.Parse(ViewState["year"].ToString());
        DateTime time1 = new DateTime(m, y, 1);
        DateTime time2 = time1.AddMonths(1);
        TimeSpan ts = time2 - time1;
        for (int i = 0; i < ts.TotalDays; i++)
        {

            DataRow dr = dt.NewRow();
            string day1 = "0";
            string month1 = "0";
            int xyz = int.Parse(ViewState["month"].ToString());
            int month = xyz;
            string year = ViewState["year"].ToString();
            if (day <= 9)
            {
                day1 = "0" + day.ToString();
            }
            else
            {
                day1 = day.ToString();
            }
            if (month <= 9)
            {
                month1 = "0" + month.ToString();
            }
            else
            {
                month1 = month.ToString();
            }
            string actualdate = day1 + "-" + year + "-" + month1 + " 00:00:00";
            string actual = day1 + "-" + year + "-" + month1;
            dr["date"] = actual;

            //Intime
            for (int j = 0; j < dt1.Rows.Count; j++)
            {
                if (dt1.Rows[j]["date"].ToString() == actualdate)
                {
                    dr["InTime"] = dt1.Rows[j]["InTime"];
                    break;
                }
                else
                {
                    dr["InTime"] = "";
                }
            }
            //Intime

            //Outtime
            for (int j = 0; j < dt1.Rows.Count; j++)
            {
                if (dt1.Rows[j]["date"].ToString() == actualdate)
                {
                    dr["OutTime"] = dt1.Rows[j]["OutTime"];
                    break;
                }
                else
                {
                    dr["OutTime"] = "";
                }
            }
            //Outtime

            //Shift totalhrs, intime, outime
            string abc = Session["empid"].ToString();
            DateTime d1 = DateTime.Parse(actualdate);
            string def = d1.ToString("yyyy-MM-dd");
            SqlDataAdapter adp1 = new SqlDataAdapter("SELECT tblshift.intime, tblshift.outtime FROM tblshift INNER JOIN tblattendance ON tblshift.shiftid = tblattendance.shiftid WHERE (tblattendance.empid = " + abc + ") AND (tblattendance.date = '" + def + "')", con);
            DataTable sh = new DataTable();
            adp1.Fill(sh);
            if (sh.Rows.Count == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert" + UniqueID, "alert('" + "NO ATTENDANCE FOUND" + "');", true);
            }
            else
            {
                dr["ShiftTotalHrs"] = "08:00";
                dr["ShiftInTime"] = sh.Rows[0]["intime"];
                dr["ShiftOutTime"] = sh.Rows[0]["outtime"];
            }
            //Shift totalhrs, intime, outime

            //Type(offday)
            DateTime date1 = DateTime.Parse(actualdate);
            if (date1.DayOfWeek == 0)
            {
                dr["Type"] = "Off day";
                dr["InTime"] = "";
                dr["OutTime"] = "";
            }
            else
            {
                dr["Type"] = " ";
            }
            //Type(offday)

            //Full or Half Day
            for (int j = 0; j < dt1.Rows.Count; j++)
            {
                if (dt1.Rows[j]["date"].ToString() == actualdate)
                {
                    if (dt1.Rows[j]["intime"].ToString() == "" && dt1.Rows[j]["leavetype"].ToString() != "")
                    {
                        dr["DayHalf"] = "Full Day";
                        break;
                    }
                    else if (dt1.Rows[j]["intime"].ToString() != "")
                    {
                        int tots = int.Parse(dt1.Rows[j]["totalhrs"].ToString());
                        if (tots > 4)
                        {
                            dr["DayHalf"] = "Full Day";
                        }
                        else
                        {
                            dr["DayHalf"] = "Half Day";
                        }
                        break;
                    }
                }
            }
            //Full or Half Day

            //Present or Absent
            for (int j = 0; j < dt1.Rows.Count; j++)
            {
                if (dt1.Rows[j]["date"].ToString() == actualdate && (dt1.Rows[j]["intime"].ToString() != "" || (dt1.Rows[j]["intime"].ToString() == "" && dt1.Rows[j]["leavetype"].ToString() != "")))
                {
                    dr["Attendance"] = "Present";
                    break;
                }
                else
                {
                    if (dr["Type"] == "Off day")
                    {
                        dr["Attendance"] = "Holiday";
                    }
                    else
                    {
                        dr["Attendance"] = "Absent";
                    }
                }
            }
            //Present or Absent

            //Late hours
            for (int j = 0; j < dt1.Rows.Count; j++)
            {
                if (dt1.Rows[j]["date"].ToString() == actualdate)
                {
                    if (dt1.Rows[j]["intime"].ToString() != "")
                    {
                        DateTime time = DateTime.Parse(dt1.Rows[j]["InTime"].ToString());
                        DateTime actualtime = DateTime.Parse(sh.Rows[0]["intime"].ToString());
                        string tot = ((time - actualtime).Hours.ToString());
                        string tot1 = ((time - actualtime).Minutes.ToString());
                        if (int.Parse(tot) > 0 || int.Parse(tot1) > 0)
                        {
                            string act = tot + ":" + tot1;
                            dr["Late"] = act;
                            break;
                        }
                        else
                        {
                            dr["Late"] = "";
                        }
                    }
                }
                else
                {
                    dr["Late"] = "";
                }
            }
            //Late hours

            //Early hours
            for (int j = 0; j < dt1.Rows.Count; j++)
            {
                if (dt1.Rows[j]["date"].ToString() == actualdate)
                {
                    if (dt1.Rows[j]["outtime"].ToString() != "")
                    {
                        DateTime time = DateTime.Parse(dt1.Rows[j]["OutTime"].ToString());
                        DateTime actualtime = DateTime.Parse(sh.Rows[0]["outtime"].ToString());
                        string tot = ((actualtime - time).Hours.ToString());
                        string tot1 = ((actualtime - time).Minutes.ToString());
                        if (int.Parse(tot) > 0 || int.Parse(tot1) > 0)
                        {
                            string act = tot + ":" + tot1;
                            dr["Early"] = act;
                            break;
                        }
                        else
                        {
                            dr["Early"] = "";
                        }
                    }
                }
                else
                {
                    dr["Early"] = "";
                }
            }
            //Early hours

            //Actual work hours
            for (int j = 0; j < dt1.Rows.Count; j++)
            {
                if (dt1.Rows[j]["date"].ToString() == actualdate)
                {
                    if (dt1.Rows[j]["intime"].ToString() != "")
                    {
                        if (sh.Rows[0]["intime"].ToString() != "22:00:00")
                        {
                            DateTime intime = DateTime.Parse(dt1.Rows[j]["InTime"].ToString());
                            DateTime outtime = DateTime.Parse(dt1.Rows[j]["OutTime"].ToString());
                            string tot = ((outtime - intime).Hours.ToString());
                            string tot1 = ((outtime - intime).Minutes.ToString());
                            if (tot != "0")
                            {
                                string act = tot + ":" + tot1;
                                dr["Actualwork"] = act;
                                break;
                            }
                            else
                            {
                                dr["Actualwork"] = "0.00";
                            }
                        }
                        else
                        {
                            DateTime intime = DateTime.Parse(dt1.Rows[j]["InTime"].ToString());
                            DateTime outtime = DateTime.Parse(dt1.Rows[j]["OutTime"].ToString());
                            int intt = 24 - intime.Hour;
                            int tot = intt + outtime.Hour;
                            string tot1 = ((outtime - intime).Minutes.ToString());
                            if (tot != 0)
                            {
                                string act = tot + ":" + tot1;
                                dr["Actualwork"] = act;
                                break;
                            }
                            else
                            {
                                dr["Actualwork"] = "0.00";
                            }
                        }
                    }
                }
                else
                {
                    dr["Actualwork"] = "0.00";
                }
            }
            //Actual work hours

            //Presence
            for (int j = 0; j < dt1.Rows.Count; j++)
            {
                if (dt1.Rows[j]["date"].ToString() == actualdate && (dt1.Rows[j]["intime"].ToString() != "" || (dt1.Rows[j]["intime"].ToString() == "" && (dt1.Rows[j]["leavetype"].ToString() != "" || dr["Attendance"] == "Holiday"))))
                {
                    if (dr["DayHalf"] == "Full Day" || dr["Attendance"] == "Holiday")
                    {
                        dr["Presence"] = "1.00";
                        break;
                    }
                    else
                    {
                        dr["Presence"] = "0.50";
                        break;
                    }
                }
                else
                {
                    dr["Presence"] = "0.00";
                }
            }
            //Presence

            //OT Hours
            for (int j = 0; j < dt1.Rows.Count; j++)
            {
                if (dt1.Rows[j]["date"].ToString() == actualdate)
                {
                    if (dt1.Rows[j]["outtime"].ToString() != "")
                    {
                        DateTime time = DateTime.Parse(dt1.Rows[j]["OutTime"].ToString());
                        DateTime actualtime = DateTime.Parse(dr["ShiftOutTime"].ToString());
                        string tot = ((time - actualtime).Hours.ToString());
                        string tot1 = ((time - actualtime).Minutes.ToString());
                        if (int.Parse(tot) > 0 || int.Parse(tot1) > 0)
                        {
                            string act = tot + ":" + tot1;
                            dr["OT"] = act;
                            break;
                        }
                        else
                        {
                            dr["OT"] = "0.00";
                        }
                    }
                }
                else
                {
                    dr["OT"] = "0.00";
                }
            }
            //OT Hours

            //Leave Type
            for (int j = 0; j < dt1.Rows.Count; j++)
            {
                if (dt1.Rows[j]["date"].ToString() == actualdate)
                {
                    dr["leavetype"] = dt1.Rows[j]["leavetype"];
                    if (dt1.Rows[j]["leavetype"].ToString() == "LWP")
                    {
                        dr["Presence"] = "0.00";
                        dr["DayHalf"] = "";
                    }
                    break;
                }
                else
                {
                    dr["leavetype"] = "";
                }
            }
            //Leave Type

            //Remarks
            for (int j = 0; j < dt1.Rows.Count; j++)
            {
                if (dt1.Rows[j]["date"].ToString() == actualdate)
                {
                    if (dt1.Rows[j]["totalhrs"].ToString() != "")
                    {
                        DateTime intime = DateTime.Parse(dt1.Rows[j]["InTime"].ToString());
                        DateTime outtime = DateTime.Parse(dt1.Rows[j]["OutTime"].ToString());
                        DateTime actualintime = DateTime.Parse(dr["ShiftInTime"].ToString());
                        DateTime actualouttime = DateTime.Parse(dr["ShiftOutTime"].ToString());
                        string tot = ((intime - actualintime).Hours.ToString());
                        string tot1 = ((intime - actualintime).Minutes.ToString());
                        string tot2 = ((actualouttime - outtime).Hours.ToString());
                        string tot3 = ((actualouttime - outtime).Minutes.ToString());
                        if (int.Parse(tot) > 0 || int.Parse(tot1) > 0 || int.Parse(tot2) > 0 || int.Parse(tot3) > 0)
                        {
                            warn1++;
                            string temp = warn + " " + warn1;
                            dr["Remarks"] = temp;
                            break;
                        }
                        else
                        {
                            dr["Remarks"] = " ";
                        }
                    }
                }
                else
                {
                    dr["Remarks"] = " ";
                }
            }
            //Remarks
            day++;
            dt.Rows.Add(dr);
        }
        Session["generatepayroll"] = dt;
    }
    public void gridfillpayroll()
    {
        SqlDataAdapter adp = new SqlDataAdapter("select * from tblemployee", con);
        DataTable dt2 = new DataTable();
        adp.Fill(dt2);
        GridView1.DataSource = dt2;
        GridView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        foreach (GridViewRow gvrow in GridView1.Rows)
        {
            CheckBox chk = (CheckBox)gvrow.FindControl("CheckBox1");
            if (chk.Checked)
            {
                Label emp = (Label)gvrow.FindControl("Label9");
                int empid = int.Parse(emp.Text);
                Session["empid"] = empid;
                SqlDataAdapter adp = new SqlDataAdapter("select perdaypay from tblemployee where empid=@", con);
                adp.SelectCommand.Parameters.AddWithValue("@",empid);
                DataTable dt2 = new DataTable();
                adp.Fill(dt2);
                int perdaypay = int.Parse(dt2.Rows[0]["perdaypay"].ToString());
                int payyear = int.Parse(ViewState["month"].ToString());
                int paymonth = int.Parse(ViewState["year"].ToString());
                DateTime start = DateTime.Parse("01-" + paymonth + "-" + payyear + " 00:00:00");
                string act = start.ToString("yyyy-MM-dd");
                DateTime time1 = start;
                DateTime time2 = time1.AddMonths(1);
                TimeSpan ts = time2 - time1;
                string day = ts.TotalDays.ToString();
                string month = time1.Month.ToString();
                string year = time1.Year.ToString();
                DateTime actualdate = DateTime.Parse(day + "-" + month + "-" + year + " 00:00:00");
                string act2 = actualdate.ToString("yyyy-MM-dd");
                SqlDataAdapter adp1 = new SqlDataAdapter("select tblattendance.attendanceid,tblattendance.empid,tblattendance.date,tblattendance.intime,tblattendance.outtime,tblattendance.totalhrs,tblattendance.shiftid,tblattendance.leavetype from tblattendance,tblshift,tblemployee where tblattendance.empid=tblemployee.empid and tblattendance.empid=@a AND (tblattendance.date BETWEEN @b AND @c)", con);
                adp1.SelectCommand.Parameters.AddWithValue("@a", empid);
                adp1.SelectCommand.Parameters.AddWithValue("@b", act);
                adp1.SelectCommand.Parameters.AddWithValue("@c", act2);
                dt1 = new DataTable();
                adp1.Fill(dt1);
                if (dt1.Rows.Count == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert" + UniqueID, "alert('" + "No attendance found" + "');", true);
                }
                else
                {
                    createdatatable();
                    int pday = 0;
                    DataTable dt = (DataTable)Session["generatepayroll"];
                    int days = dt.Rows.Count;
                    int late = 0;
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        string check = dt.Rows[j]["Presence"].ToString();
                        if (check == "1.00")
                        {
                            pday++;
                        }
                        string check2 = dt.Rows[j]["Late"].ToString();
                        string check3 = dt.Rows[j]["Early"].ToString();
                        if (check2 != "")
                        {
                            int check4 = int.Parse(check2.Substring(0, 1));
                            late = late + check4;
                        }
                        if (check3 != "")
                        {
                            int check5 = int.Parse(check3.Substring(0, 1));
                            late = late + check5;
                        }
                    }
                    SqlDataAdapter adp2 = new SqlDataAdapter("Select perdaypay from tblemployee where empid=@a", con);
                    adp2.SelectCommand.Parameters.AddWithValue("@a", empid);
                    DataTable dt3 = new DataTable();
                    adp2.Fill(dt3);
                    string check1 = dt3.Rows[0]["perdaypay"].ToString();
                    int basic = int.Parse(check1) * pday;
                    int perhour = int.Parse(check1) / 8;
                    int dect = perhour * late; ;
                    int pt = 150;
                    SqlDataAdapter adp3 = new SqlDataAdapter("SELECT SUM(amount) AS total FROM tblexpense WHERE (empid = @w) AND (date BETWEEN @x AND @y) AND (status = @z)", con);
                    b.status = "Approved";
                    adp3.SelectCommand.Parameters.AddWithValue("@w", empid);
                    adp3.SelectCommand.Parameters.AddWithValue("@x", act);
                    adp3.SelectCommand.Parameters.AddWithValue("@y", act2);
                    adp3.SelectCommand.Parameters.AddWithValue("@z", b.status);
                    DataTable dt4 = new DataTable();
                    adp3.Fill(dt4);
                    SqlDataAdapter adp4 = new SqlDataAdapter("SELECT SUM(amount) AS total FROM tblclaim WHERE (empid = @w) AND (date BETWEEN @x AND @y) AND (status = @z)", con);
                    b.status = "Approved";
                    adp4.SelectCommand.Parameters.AddWithValue("@w", empid);
                    adp4.SelectCommand.Parameters.AddWithValue("@x", act);
                    adp4.SelectCommand.Parameters.AddWithValue("@y", act2);
                    adp4.SelectCommand.Parameters.AddWithValue("@z", b.status);
                    DataTable dt5 = new DataTable();
                    adp4.Fill(dt5);
                    if (dt4.Rows[0]["total"].ToString() == "" && dt5.Rows[0]["total"].ToString() == "")
                    {
                        int exp = 0;
                        SqlCommand cmd = new SqlCommand("insert into tblpayroll values(@payyear,@paymonth,@basic,@lateandearly,@pt,@exptotal,@empid)", con);
                        cmd.Parameters.AddWithValue("@payyear", payyear);
                        cmd.Parameters.AddWithValue("@paymonth", paymonth);
                        cmd.Parameters.AddWithValue("@basic", basic);
                        cmd.Parameters.AddWithValue("@lateandearly", dect);
                        cmd.Parameters.AddWithValue("@pt", pt);
                        cmd.Parameters.AddWithValue("@exptotal", exp);
                        cmd.Parameters.AddWithValue("@empid", empid);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (dt4.Rows[0]["total"].ToString() == "")
                    {
                        int exp = int.Parse(dt4.Rows[0]["total"].ToString());
                        SqlCommand cmd = new SqlCommand("insert into tblpayroll values(@payyear,@paymonth,@basic,@lateandearly,@pt,@exptotal,@empid)", con);
                        cmd.Parameters.AddWithValue("@payyear", payyear);
                        cmd.Parameters.AddWithValue("@paymonth", paymonth);
                        cmd.Parameters.AddWithValue("@basic", basic);
                        cmd.Parameters.AddWithValue("@lateandearly", dect);
                        cmd.Parameters.AddWithValue("@pt", pt);
                        cmd.Parameters.AddWithValue("@exptotal", exp);
                        cmd.Parameters.AddWithValue("@empid", empid);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        SqlCommand cmd1 = new SqlCommand("update tblexpense set paidstatus=@v WHERE (empid = @w) AND (date BETWEEN @x AND @y) AND (status = @z)", con);
                        b.status = "Approved";
                        b.paidstatus = "Yes";
                        cmd1.Parameters.AddWithValue("@v", b.paidstatus);
                        cmd1.Parameters.AddWithValue("@w", empid);
                        cmd1.Parameters.AddWithValue("@x", act);
                        cmd1.Parameters.AddWithValue("@y", act2);
                        cmd1.Parameters.AddWithValue("@z", b.status);
                        con.Open();
                        cmd1.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (dt5.Rows[0]["total"].ToString() == "")
                    {
                        int exp = int.Parse(dt4.Rows[0]["total"].ToString());
                        SqlCommand cmd = new SqlCommand("insert into tblpayroll values(@payyear,@paymonth,@basic,@lateandearly,@pt,@exptotal,@empid)", con);
                        cmd.Parameters.AddWithValue("@payyear", payyear);
                        cmd.Parameters.AddWithValue("@paymonth", paymonth);
                        cmd.Parameters.AddWithValue("@basic", basic);
                        cmd.Parameters.AddWithValue("@lateandearly", dect);
                        cmd.Parameters.AddWithValue("@pt", pt);
                        cmd.Parameters.AddWithValue("@exptotal", exp);
                        cmd.Parameters.AddWithValue("@empid", empid);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        SqlCommand cmd1 = new SqlCommand("update tblclaim set adjustments=@v WHERE (empid = @w) AND (date BETWEEN @x AND @y) AND (status = @z)", con);
                        b.status = "Approved";
                        b.adjustments = "Adjusted";
                        cmd1.Parameters.AddWithValue("@v", b.adjustments);
                        cmd1.Parameters.AddWithValue("@w", empid);
                        cmd1.Parameters.AddWithValue("@x", act);
                        cmd1.Parameters.AddWithValue("@y", act2);
                        cmd1.Parameters.AddWithValue("@z", b.status);
                        con.Open();
                        cmd1.ExecuteNonQuery();
                        con.Close();
                        SqlCommand cmd2 = new SqlCommand("update tblclaim set adjustments=@v WHERE (empid = @w) AND (date BETWEEN @x AND @y) AND (status != @z)", con);
                        b.status = "Approved";
                        b.adjustments = "Not Adjusted";
                        cmd2.Parameters.AddWithValue("@v", b.adjustments);
                        cmd2.Parameters.AddWithValue("@w", empid);
                        cmd2.Parameters.AddWithValue("@x", act);
                        cmd2.Parameters.AddWithValue("@y", act2);
                        cmd2.Parameters.AddWithValue("@z", b.status);
                        con.Open();
                        cmd2.ExecuteNonQuery();
                        con.Close();
                    }
                    else 
                    {
                        int exp = int.Parse(dt4.Rows[0]["total"].ToString());
                        SqlCommand cmd = new SqlCommand("insert into tblpayroll values(@payyear,@paymonth,@basic,@lateandearly,@pt,@exptotal,@empid)", con);
                        cmd.Parameters.AddWithValue("@payyear", payyear);
                        cmd.Parameters.AddWithValue("@paymonth", paymonth);
                        cmd.Parameters.AddWithValue("@basic", basic);
                        cmd.Parameters.AddWithValue("@lateandearly", dect);
                        cmd.Parameters.AddWithValue("@pt", pt);
                        cmd.Parameters.AddWithValue("@exptotal", exp);
                        cmd.Parameters.AddWithValue("@empid", empid);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        SqlCommand cmd1 = new SqlCommand("update tblexpense set paidstatus=@v WHERE (empid = @w) AND (date BETWEEN @x AND @y) AND (status = @z)", con);
                        b.status = "Approved";
                        b.paidstatus = "Yes";
                        cmd1.Parameters.AddWithValue("@v", b.paidstatus);
                        cmd1.Parameters.AddWithValue("@w", empid);
                        cmd1.Parameters.AddWithValue("@x", act);
                        cmd1.Parameters.AddWithValue("@y", act2);
                        cmd1.Parameters.AddWithValue("@z", b.status);
                        con.Open();
                        cmd1.ExecuteNonQuery();
                        con.Close();
                        SqlCommand cmd2 = new SqlCommand("update tblclaim set adjustments=@v WHERE (empid = @w) AND (date BETWEEN @x AND @y) AND (status = @z)", con);
                        b.status = "Approved";
                        b.adjustments = "Adjusted";
                        cmd2.Parameters.AddWithValue("@v", b.adjustments);
                        cmd2.Parameters.AddWithValue("@w", empid);
                        cmd2.Parameters.AddWithValue("@x", act);
                        cmd2.Parameters.AddWithValue("@y", act2);
                        cmd2.Parameters.AddWithValue("@z", b.status);
                        con.Open();
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        SqlCommand cmd3 = new SqlCommand("update tblclaim set adjustments=@v WHERE (empid = @w) AND (date BETWEEN @x AND @y) AND (status != @z)", con);
                        b.status = "Approved";
                        b.adjustments = "Not Adjusted";
                        cmd3.Parameters.AddWithValue("@v", b.adjustments);
                        cmd3.Parameters.AddWithValue("@w", empid);
                        cmd3.Parameters.AddWithValue("@x", act);
                        cmd3.Parameters.AddWithValue("@y", act2);
                        cmd3.Parameters.AddWithValue("@z", b.status);
                        con.Open();
                        cmd3.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }
        show.Visible = true;
        Label3.Text = ViewState["month"].ToString();
        Label1.Text = ViewState["year"].ToString();
    }

    protected void selectall_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkheader = (CheckBox)GridView1.HeaderRow.FindControl("selectall");
        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox chkitem = (CheckBox)row.FindControl("Checkbox1");
            if (chkheader.Checked == true)
            {
                chkitem.Checked = true;
            }
            else
            {
                chkitem.Checked = false;
            }
        }
    }
}