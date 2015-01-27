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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

public partial class Home_Attendance : System.Web.UI.Page
{
    string connection = ConfigurationManager.ConnectionStrings["projectConnectionString"].ConnectionString;
    SqlConnection con;
    DataTable dt1;
    string warn = "Warning";
    int warn1 = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id2"] == null)
            Response.Redirect("../login/login.aspx");
        con = new SqlConnection(connection);
    }
    public void getdata()
    {
        SqlDataAdapter adp = new SqlDataAdapter("select tblattendance.attendanceid,tblattendance.empid,tblattendance.date,tblattendance.intime,tblattendance.outtime,tblattendance.totalhrs,tblattendance.shiftid,tblattendance.leavetype from tblattendance,tblshift,tblemployee where tblattendance.empid=tblemployee.empid and tblattendance.empid="+int.Parse(Session["id2"].ToString()), con);
        dt1 = new DataTable();
        adp.Fill(dt1);
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
        DateTime time1 = new DateTime(int.Parse(DropDownList2.SelectedItem.ToString()), int.Parse(DropDownList1.SelectedItem.ToString()),1);
        DateTime time2 = time1.AddMonths(1);
        TimeSpan ts = time2 - time1;
        for (int i = 0; i < ts.TotalDays; i++)
        {
            
            DataRow dr = dt.NewRow();
            string day1="0";
            string month =DropDownList1.SelectedItem.ToString();
            string year= DropDownList2.SelectedItem.ToString();
            if (day <= 9)
            {
                day1 = "0" + day.ToString();
            }
            else
            {
                day1 = day.ToString();
            }
            string actualdate = day1 + "-" + month + "-" + year+" 00:00:00";
            string actual = day1 + "-" + month + "-" + year;
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
            string abc = Session["id2"].ToString();
            DateTime d1 = DateTime.Parse(actualdate);
            string def = d1.ToString("yyyy-MM-dd");
            SqlDataAdapter adp1 = new SqlDataAdapter("SELECT tblshift.intime, tblshift.outtime FROM tblshift INNER JOIN tblattendance ON tblshift.shiftid = tblattendance.shiftid WHERE (tblattendance.empid = " + abc + ") AND (tblattendance.date = '" + def+ "')", con);
            DataTable sh = new DataTable();
            adp1.Fill(sh);
            if (sh.Rows.Count == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert" + UniqueID, "alert('" + "No attendance found" + "');", true);
            }
            else
            {
                dr["ShiftTotalHrs"] = "08:00";
                dr["ShiftInTime"] = sh.Rows[0]["intime"];
                dr["ShiftOutTime"] = sh.Rows[0]["outtime"];
            }
            //Shift totalhrs, intime, outime

            //Type(offday)
            DateTime date1= DateTime.Parse(actualdate);
              if( date1.DayOfWeek==0)
              {
                  dr["Type"]="Off day";
                  dr["InTime"] = "";
                  dr["OutTime"] = "";
              }
              else
              {
                dr["Type"]=" ";
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
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        getdata();
        if (dt1.Rows.Count == 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert" + UniqueID, "alert('" + "No attendance found" + "');", true);
        }
        else
        {
            createdatatable();
            foreach (GridViewRow item in GridView1.Rows)
            {
                 int l= item.RowIndex;
                 Label lb=(Label)GridView1.Rows[l].FindControl("att");
                 if (lb.Text == "Absent")
                     item.BackColor = ColorTranslator.FromHtml("orangered");
                 else
                     item.BackColor = ColorTranslator.FromHtml("lightgreen");
             }
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Attendance.xls"));
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        GridView1.AllowPaging = false;
        getdata();
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
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Attendance.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        GridView1.AllowPaging = false;
        getdata();
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
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        DropDownList1.SelectedIndex = DropDownList1.SelectedIndex - 1;
        Button1_Click(sender,e);
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        DropDownList1.SelectedIndex = DropDownList1.SelectedIndex + 1;
        Button1_Click(sender, e);
    }
}