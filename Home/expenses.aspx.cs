using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_expenses : System.Web.UI.Page
{
    DAL d = new DAL();
    BAL b = new BAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id2"] == null)
            Response.Redirect("../login/login.aspx");
        if (!IsPostBack)
        {
            gridfillexpensesrequest();
        }
        MultiView1.ActiveViewIndex = 0;
    }
    void gridfillexpensesrequest()
    {
        string empid = Session["id2"].ToString();
        b.empid = int.Parse(empid);
        GridView1.DataSource = b.gridfillexpensesrequest(b);
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
            Label10.Text = "No Expense Request Applied";
        }
    }
    protected void DropDownList1_TextChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue.ToString() == "Show All")
        {
            gridfillexpensesrequest();
        }
        else
        {
            string empid = Session["id2"].ToString();
            b.empid = int.Parse(empid);
            b.status = DropDownList1.SelectedValue.ToString();
            GridView1.DataSource = b.gridfillexpensesrequestlist(b);
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
                Label10.Text = "No " + b.status + " Expense Request";
            }
        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList d1 = (DropDownList)sender;
        GridViewRow gvrow = (GridViewRow)d1.NamingContainer;
        DropDownList dr = (DropDownList)gvrow.FindControl("DropDownList2");
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
        MultiView1.ActiveViewIndex = 1;
    }
    protected void Gridview2_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            LinkButton lb = (LinkButton)e.Row.FindControl("LinkButton1");
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
        Label box1 = (Label)gvRow.FindControl("Label1");
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
                    Gridview2.Columns[8].Visible = false;
                }
            }
            ViewState["CurrentTable"] = dt;
            Gridview2.DataSource = dt;
            Gridview2.DataBind();
            MultiView1.ActiveViewIndex = 1;
        }
        SetPreviousData();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gvrow in Gridview2.Rows)
        {
            TextBox box1 = (TextBox)gvrow.FindControl("TextBox1");
            DropDownList box2 = (DropDownList)gvrow.FindControl("DropDownList1");
            DropDownList box3 = (DropDownList)gvrow.FindControl("DropDownList2");
            TextBox box4 = (TextBox)gvrow.FindControl("TextBox4");
            TextBox box5 = (TextBox)gvrow.FindControl("TextBox5");
            TextBox box6 = (TextBox)gvrow.FindControl("TextBox6");
            FileUpload box7 = (FileUpload)gvrow.FindControl("FileUpload1");
            Label box8 = (Label)gvrow.FindControl("Label1");
            b.date = box1.Text;
            b.category = box2.SelectedItem.Text;
            b.type = box3.SelectedItem.Text;
            b.amount = int.Parse(box4.Text);
            b.remarks = box5.Text;
            b.status = "Pending";
            b.reason = box6.Text;
            b.paidstatus = "No";
            string empid = Session["id2"].ToString();
            b.empid = int.Parse(empid);
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
            b.expenserequest(b);
        }
        MultiView1.ActiveViewIndex = 0;
        gridfillexpensesrequest();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        SetInitialRow();
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        SetInitialRow();
    }
    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("No.", typeof(string)));
        dt.Columns.Add(new DataColumn("Date", typeof(string)));
        dt.Columns.Add(new DataColumn("Category", typeof(string)));
        dt.Columns.Add(new DataColumn("Type", typeof(string)));
        dt.Columns.Add(new DataColumn("Amount", typeof(string)));
        dt.Columns.Add(new DataColumn("Reason", typeof(string)));
        dt.Columns.Add(new DataColumn("Remarks", typeof(string)));
        dt.Columns.Add(new DataColumn("Image", typeof(string)));
        dr = dt.NewRow();
        dr["No."] = 1;
        dr["Date"] = string.Empty;
        dr["Category"] = string.Empty;
        dr["Type"] = string.Empty;
        dr["Amount"] = string.Empty;
        dr["Reason"] = string.Empty;
        dr["Remarks"] = string.Empty;
        dr["Image"] = string.Empty;
        dt.Rows.Add(dr);
        ViewState["CurrentTable"] = dt;
        Gridview2.DataSource = dt;
        Gridview2.Columns[8].Visible = false;
        Gridview2.DataBind();
        MultiView1.ActiveViewIndex = 1;
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
                    TextBox box1 = (TextBox)Gridview2.Rows[rowIndex].Cells[2].FindControl("TextBox1");
                    DropDownList box2 = (DropDownList)Gridview2.Rows[rowIndex].Cells[3].FindControl("DropDownList1");
                    DropDownList box3 = (DropDownList)Gridview2.Rows[rowIndex].Cells[4].FindControl("DropDownList2");
                    TextBox box4 = (TextBox)Gridview2.Rows[rowIndex].Cells[5].FindControl("TextBox4");
                    TextBox box5 = (TextBox)Gridview2.Rows[rowIndex].Cells[6].FindControl("TextBox5");
                    TextBox box6 = (TextBox)Gridview2.Rows[rowIndex].Cells[7].FindControl("TextBox6");
                    FileUpload box7 = (FileUpload)Gridview2.Rows[rowIndex].Cells[8].FindControl("FileUpload1");
                    Label box8 = (Label)Gridview2.Rows[rowIndex].Cells[8].FindControl("Label1");
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["No."] = i + 1;
                    drCurrentRow["Date"] = box1.Text;
                    drCurrentRow["Category"] = box2.Text;
                    drCurrentRow["Type"] = box3.Text;
                    drCurrentRow["Amount"] = box4.Text;
                    drCurrentRow["Reason"] = box5.Text;
                    drCurrentRow["Remarks"] = box6.Text;
                    string image = box7.FileName;
                    string path = Server.MapPath("expimage");
                    string apath = path + "\\" + image;
                    box7.SaveAs(apath);
                    string sqlpath = "expimage\\" + image;
                    if (sqlpath != "expimage\\")
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
                Gridview2.DataSource = dtCurrentTable;
                Gridview2.Columns[8].Visible = true;
                Gridview2.DataBind();
                MultiView1.ActiveViewIndex = 1;
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
                    TextBox box1 = (TextBox)Gridview2.Rows[rowIndex].Cells[2].FindControl("TextBox1");
                    DropDownList box2 = (DropDownList)Gridview2.Rows[rowIndex].Cells[3].FindControl("DropDownList1");
                    DropDownList box3 = (DropDownList)Gridview2.Rows[rowIndex].Cells[4].FindControl("DropDownList2");
                    TextBox box4 = (TextBox)Gridview2.Rows[rowIndex].Cells[5].FindControl("TextBox4");
                    TextBox box5 = (TextBox)Gridview2.Rows[rowIndex].Cells[6].FindControl("TextBox5");
                    TextBox box6 = (TextBox)Gridview2.Rows[rowIndex].Cells[7].FindControl("TextBox6");
                    Label box7 = (Label)Gridview2.Rows[rowIndex].Cells[8].FindControl("Label1");

                    box1.Text = dt.Rows[i]["Date"].ToString();
                    box2.Text = dt.Rows[i]["Category"].ToString();
                    box3.Text = dt.Rows[i]["Type"].ToString();
                    box4.Text = dt.Rows[i]["Amount"].ToString();
                    box5.Text = dt.Rows[i]["Reason"].ToString();
                    box6.Text = dt.Rows[i]["Remarks"].ToString();
                    box7.Text = dt.Rows[i]["Image"].ToString();
                    rowIndex++;
                }
            }
            MultiView1.ActiveViewIndex = 1;
        }
    }
}