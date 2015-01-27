using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Configuration;

public partial class Home_generatepayroll : System.Web.UI.Page
{
    string connection = ConfigurationManager.ConnectionStrings["projectConnectionString"].ConnectionString;
    SqlConnection con;
    DataTable dt1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id2"] == null)
            Response.Redirect("../login/login.aspx");
        con = new SqlConnection(connection);
        string dept = Session["dept"].ToString();
        if (dept == "Finance" || dept == "Accounts")
        {
            TextBox1.Text = Session["id2"].ToString();
            TextBox1.ReadOnly = true;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int empid = int.Parse(TextBox1.Text);
        int payyear = int.Parse(DropDownList2.SelectedValue);
        int paymonth = int.Parse(DropDownList1.SelectedValue);
        SqlDataAdapter adp = new SqlDataAdapter("select * from tblpayroll where empid=@a and paymonth=@c and payyear=@d", con);
        adp.SelectCommand.Parameters.AddWithValue("@a", empid);
        adp.SelectCommand.Parameters.AddWithValue("@c", paymonth);
        adp.SelectCommand.Parameters.AddWithValue("@d", payyear);
        dt1 = new DataTable();
        adp.Fill(dt1);
        if (dt1.Rows.Count==0)
        {
            Label13.Visible = true;
            tab.Visible = false;
        }
        else
        {
            Label13.Visible = false;
            tab.Visible = true;
            SqlDataAdapter adp1 = new SqlDataAdapter("select * from tblemployee where empid=@b", con);
            adp1.SelectCommand.Parameters.AddWithValue("@b", empid);
            DataTable dt2 = new DataTable();
            adp1.Fill(dt2);
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
            SqlDataAdapter adp2 = new SqlDataAdapter("SELECT SUM(tblclaim.amount) AS amount, SUM(tbladvance.amount) AS advamount FROM tbladvance INNER JOIN tblclaim ON tbladvance.advid = tblclaim.advid WHERE (tblclaim.date BETWEEN @t AND @s) AND (tblclaim.empid = @r) AND (tblclaim.adjustments = 'Adjusted')", con);
            adp2.SelectCommand.Parameters.AddWithValue("@r", empid);
            adp2.SelectCommand.Parameters.AddWithValue("@t", start);
            adp2.SelectCommand.Parameters.AddWithValue("@s", act2);
            DataTable dt3 = new DataTable();
            adp2.Fill(dt3);
            int claimadvance;
            if (dt3.Rows[0]["amount"].ToString() != "")
                claimadvance = int.Parse(dt3.Rows[0]["amount"].ToString());
            else
                claimadvance = 0;
            int advamount;
            if (dt3.Rows[0]["advamount"].ToString() != "")
                advamount = int.Parse(dt3.Rows[0]["advamount"].ToString());
            else
                advamount = 0;
            int adjustment1 = advamount - claimadvance;
            int adjustment;
            if (adjustment1 < 0)
                adjustment = Math.Abs(adjustment1);
            else
                adjustment = adjustment1; 
            int perdaypay = int.Parse(dt2.Rows[0]["perdaypay"].ToString());
            int basic = int.Parse(dt1.Rows[0]["basic"].ToString());
            int expense;
            if (dt1.Rows[0]["exptotal"].ToString() != "")
            expense = int.Parse(dt1.Rows[0]["exptotal"].ToString());
            else
            expense = 0;
            int gross;
            if (adjustment1 < 0)
                gross = basic + expense;
            else
                gross = basic + expense + adjustment;
            if (adjustment1 < 0)
                Label20.Text="Deduct";
            else
                Label20.Text = "Add";
            int presence = basic / perdaypay;
            int deduct = int.Parse(dt1.Rows[0]["lateandearly"].ToString());
            int pt = 150;
            int tded;
            if (adjustment1 < 0)
                tded = deduct + pt+adjustment;
            else
                tded = deduct + pt;
            int net = gross - tded;
            Label19.Text = adjustment.ToString();
            Label1.Text = day;
            Label5.Text = day;
            Label6.Text = day;
            Label14.Text = day;
            Label17.Text = day;
            Label18.Text = presence.ToString();
            Label3.Text = presence.ToString();
            Label21.Text = presence.ToString();
            Label8.Text = presence.ToString();
            Label15.Text = presence.ToString();
            Label4.Text = basic.ToString();
            Label7.Text = deduct.ToString();
            Label9.Text = pt.ToString();
            Label10.Text = gross.ToString();
            Label11.Text = tded.ToString();
            Label12.Text = net.ToString();
            Label16.Text = expense.ToString();
            string dept = Session["dept"].ToString();
            if (dept == "Finance" || dept == "Accounts")
            {
                adjust.Visible = false;
            }
            else
            {
                adjust.Visible = true;
                check.Visible = false;
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        TextBox2.Text = "";
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked == true)
        {
            check.Visible = true;
        }
        else
        {
            check.Visible = false;
        }
    }
}