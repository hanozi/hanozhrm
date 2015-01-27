using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

public partial class Home_advancerequisition : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            gridfilladvancerequisition();
        }
        MultiView1.ActiveViewIndex = 0;
    }
    void gridfilladvancerequisition()
    {
        string empid = Session["id2"].ToString();
        b.empid = int.Parse(empid);
        GridView1.DataSource = b.gridfilladvancerequisition(b);
        GridView1.DataBind();
        int check = GridView1.Rows.Count;
        if (check != 0)
        {
            Label1.Visible = true;
            DropDownList1.Visible = true;
            Label10.Visible = false;
        }
        else
        {
            Label1.Visible = false;
            DropDownList1.Visible = false;
            Label10.Visible = true;
            Label10.Text = "No Advance Requisition Applied";
        }
        foreach (GridViewRow item in GridView1.Rows)
        {
            Session["advid"] = null;
            Label status = (Label)item.FindControl("Label6");
            LinkButton claim = (LinkButton)item.FindControl("LinkButton1");
            Label note = (Label)item.FindControl("Label15");
            Label advid = (Label)item.FindControl("Label2");
            if (status.Text == "Approved")
            {
                b.advid = int.Parse(advid.Text);
                SqlDataAdapter adp = new SqlDataAdapter("select * from tblclaim where advid=@a", con);
                adp.SelectCommand.Parameters.AddWithValue("@a", b.advid);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    claim.Visible = true;
                    claim.Text = "Claim Advance";
                }
                int pending = 0;
                int rejected = 0;
                int approved = 0;
                int adjusted = 0;
                int notadjusted = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["status"].ToString() == "Pending")
                    {
                        pending=pending+1;   
                    }
                    if (dt.Rows[i]["status"].ToString() == "Approved")
                    {
                        approved=approved+1;
                    }
                    if (dt.Rows[i]["status"].ToString() == "Rejected")
                    {
                        rejected = rejected + 1;
                    }
                    if (dt.Rows[i]["adjustments"].ToString() == "Adjusted")
                    {
                        adjusted = adjusted + 1;
                    }
                    if (dt.Rows[i]["adjustments"].ToString() == "Not Adjusted")
                    {
                        notadjusted = notadjusted + 1;
                    }
                }
                if (adjusted>0)
                {
                    note.Visible = true;
                    claim.Visible = false;
                    note.Text = "Adjusted";
                }
                else if (notadjusted>0)
                {
                    note.Visible = true;
                    claim.Visible = true;
                    note.Text = "Payroll Genereated re-claim in these month";
                    claim.Text = "Re - Claim";
                }
                else if (pending>0||rejected>0||approved>0)
                {
                    note.Visible = true;
                    claim.Visible = true;
                    note.Text = "Claimed";
                    claim.Text = "Add Claim";
                }
            }
        }
    }
    protected void DropDownList1_TextChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue.ToString() == "Show All")
        {
            gridfilladvancerequisition();
        }
        else
        {
            string empid = Session["id2"].ToString();
            b.empid = int.Parse(empid);
            b.status = DropDownList1.SelectedValue.ToString();
            GridView1.DataSource = b.gridfilladvancerequisitionlist(b);
            GridView1.DataBind();
            int check = GridView1.Rows.Count;
            if (check != 0)
            {
                Label1.Visible = true;
                DropDownList1.Visible = true;
                Label10.Visible = false;
            }
            else
            {
                Label10.Visible = true;
                Label10.Text = "No " + b.status + " Advance Requisition Request";
            }
        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        b.date = TextBox4.Text;
        b.advfor = DropDownList2.SelectedValue.ToString();
        b.amount = int.Parse(TextBox3.Text);
        b.remarks = TextBox1.Text;
        b.status = "Pending";
        b.claimedamount = 0;
        string empid = Session["id2"].ToString();
        b.empid = int.Parse(empid);
        string id = b.addadvancerequisition(b);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert" + UniqueID, "alert('" + "Your Advance requisition ID is : " +id + "');", true);
        gridfilladvancerequisition();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        TextBox1.Text = "";
        DropDownList2.SelectedIndex = 0;
        TextBox3.Text = "";
        TextBox4.Text = "";
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
        LinkButton d1 = (LinkButton)sender;
        GridViewRow gvrow = (GridViewRow)d1.NamingContainer;
        Label dr = (Label)gvrow.FindControl("Label2");
        string advid = dr.Text;
        Session["advid"] = int.Parse(advid);
        gridfillclaimrequest();
    }
    void gridfillclaimrequest()
    {
        string empid = Session["id2"].ToString();
        b.empid = int.Parse(empid);
        string advid = Session["advid"].ToString();
        b.advid = int.Parse(advid);
        DataTable dt = b.gridfillclaimrequest(b);
        if (dt.Rows.Count == 0)
        {
            Label8.Visible = true;
            Label8.Text = "No record found";
        }
        else
        {
            Label8.Visible = false;
            GridView2.Visible = true;
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        SetInitialRow();
        Button3.Visible = false;
        Gridview3.Visible = true;
        Button4.Visible = true;
        Button6.Visible = true;
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList d1 = (DropDownList)sender;
        GridViewRow gvrow = (GridViewRow)d1.NamingContainer;
        DropDownList dr = (DropDownList)gvrow.FindControl("DropDownList3");
        if (dr.SelectedItem.Text == "Auto" || dr.SelectedItem.Text == "Bike" || dr.SelectedItem.Text == "Car" || dr.SelectedItem.Text == "<-Select->")
        {
            FileUpload file = (FileUpload)gvrow.FindControl("FileUpload1");
            file.Visible = false;
        }
        else
        {
            FileUpload file = (FileUpload)gvrow.FindControl("FileUpload1");
            file.Visible = true;
        }
        MultiView1.ActiveViewIndex = 2;
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gvrow in Gridview3.Rows)
        {
            TextBox box1 = (TextBox)gvrow.FindControl("TextBox5");
            DropDownList box2 = (DropDownList)gvrow.FindControl("DropDownList3");
            TextBox box4 = (TextBox)gvrow.FindControl("TextBox6");
            TextBox box5 = (TextBox)gvrow.FindControl("TextBox7");
            FileUpload box7 = (FileUpload)gvrow.FindControl("FileUpload1");
            Label box8 = (Label)gvrow.FindControl("Label16");
            b.date = box1.Text;
            b.type= box2.SelectedItem.Text;
            b.amount = int.Parse(box4.Text);
            b.remarks = box5.Text;
            b.status = "Pending";
            string empid = Session["id2"].ToString();
            b.empid = int.Parse(empid);
            string advid = Session["advid"].ToString();
            b.advid = int.Parse(advid);
            if (box8.Text == "")
            {
                string image = box7.FileName;
                string path = Server.MapPath("expimage");
                string apath = path + "\\" + image;
                box7.SaveAs(apath);
                string sqlpath = "expimage\\" + image;
                b.image = sqlpath;
            }
            else
            {
                b.image = box8.Text;
            }
            b.adjustments = "Pending";
            b.addclaimrequest(b);
        }
        MultiView1.ActiveViewIndex = 2;
        SetInitialRow();
        gridfillclaimrequest();
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        SetInitialRow();
    }
    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("No.", typeof(string)));
        dt.Columns.Add(new DataColumn("Date", typeof(string)));
        dt.Columns.Add(new DataColumn("Type", typeof(string)));
        dt.Columns.Add(new DataColumn("Amount", typeof(string)));
        dt.Columns.Add(new DataColumn("Remarks", typeof(string)));
        dt.Columns.Add(new DataColumn("Image", typeof(string)));
        dr = dt.NewRow();
        dr["No."] = 1;
        dr["Date"] = string.Empty;
        dr["Type"] = string.Empty;
        dr["Amount"] = string.Empty;
        dr["Remarks"] = string.Empty;
        dr["Image"] = string.Empty;
        dt.Rows.Add(dr);
        ViewState["CurrentTable"] = dt;
        Gridview3.DataSource = dt;
        Gridview3.Columns[6].Visible = false;
        Gridview3.DataBind();
        MultiView1.ActiveViewIndex = 2;
    }
    private void AddNewRowToGrid()
    {
        int rowIndex = 0;

        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    TextBox box1 = (TextBox)Gridview3.Rows[rowIndex].Cells[2].FindControl("TextBox5");
                    DropDownList box2 = (DropDownList)Gridview3.Rows[rowIndex].Cells[3].FindControl("DropDownList3");
                    TextBox box4 = (TextBox)Gridview3.Rows[rowIndex].Cells[4].FindControl("TextBox6");
                    TextBox box6 = (TextBox)Gridview3.Rows[rowIndex].Cells[5].FindControl("TextBox7");
                    FileUpload box7 = (FileUpload)Gridview3.Rows[rowIndex].Cells[6].FindControl("FileUpload1");
                    Label box8 = (Label)Gridview3.Rows[rowIndex].Cells[6].FindControl("Label16");
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["No."] = i + 1;
                    drCurrentRow["Date"] = box1.Text;
                    drCurrentRow["Type"] = box2.Text;
                    drCurrentRow["Amount"] = box4.Text;
                    drCurrentRow["Remarks"] = box6.Text;
                    string image = box7.FileName;
                    string path = Server.MapPath("claimimage");
                    string apath = path + "\\" + image;
                    box7.SaveAs(apath);
                    string sqlpath = "claimimage\\" + image;
                    if (sqlpath != "claimimage\\")
                    {
                        drCurrentRow["Image"] = sqlpath;
                    }
                    else
                    {
                        drCurrentRow["Image"] = "";
                    }
                    rowIndex++;
                }
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;
                Gridview3.DataSource = dtCurrentTable;
                Gridview3.Columns[6].Visible = true;
                Gridview3.DataBind();
                MultiView1.ActiveViewIndex = 2;
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }
        SetPreviousData();
    }
    private void SetPreviousData()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    TextBox box1 = (TextBox)Gridview3.Rows[rowIndex].Cells[2].FindControl("TextBox5");
                    DropDownList box2 = (DropDownList)Gridview3.Rows[rowIndex].Cells[3].FindControl("DropDownList3");
                    TextBox box4 = (TextBox)Gridview3.Rows[rowIndex].Cells[4].FindControl("TextBox6");
                    TextBox box6 = (TextBox)Gridview3.Rows[rowIndex].Cells[5].FindControl("TextBox7");
                    Label box7 = (Label)Gridview3.Rows[rowIndex].Cells[6].FindControl("Label16");

                    box1.Text = dt.Rows[i]["Date"].ToString();
                    box2.Text = dt.Rows[i]["Type"].ToString();
                    box4.Text = dt.Rows[i]["Amount"].ToString();
                    box6.Text = dt.Rows[i]["Remarks"].ToString();
                    box7.Text = dt.Rows[i]["Image"].ToString();
                    rowIndex++;
                }
            }
            MultiView1.ActiveViewIndex = 2;
        }
    }
    protected void Gridview3_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            LinkButton lb = (LinkButton)e.Row.FindControl("LinkButton2");
            if (lb != null)
            {
                if (dt.Rows.Count > 1)
                {
                    if (e.Row.RowIndex == dt.Rows.Count - 1)
                    {
                        lb.Visible = false;
                    }
                }
                else
                {
                    lb.Visible = false;
                }
            }
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
        Label box1 = (Label)gvRow.FindControl("Label16");
        string box = box1.Text;
        int rowID = gvRow.RowIndex + 1;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            if (dt.Rows.Count > 1)
            {
                if (gvRow.RowIndex < dt.Rows.Count - 1)
                {
                    dt.Rows.Remove(dt.Rows[rowID]);
                    if (box != "")
                    {
                        File.Delete(Server.MapPath(@"" + box + ""));
                    }
                }
                if (dt.Rows.Count <= 1)
                {
                    Gridview3.Columns[6].Visible = false;
                }
            }
            ViewState["CurrentTable"] = dt;
            Gridview3.DataSource = dt;
            Gridview3.DataBind();
            MultiView1.ActiveViewIndex = 2;
        }
        SetPreviousData();
    }
}