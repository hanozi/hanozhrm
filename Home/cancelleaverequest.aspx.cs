using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_cancelleaverequest : System.Web.UI.Page
{
    DAL d = new DAL();
    BAL b = new BAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id2"] == null)
            Response.Redirect("../login/login.aspx");
        if (!IsPostBack)
        {
            gridfillleaverequest();
        }
    }
    void gridfillleaverequest()
    {
        string empid = Session["id2"].ToString();
        b.empid = int.Parse(empid);
        GridView1.DataSource = b.cancelgridfillleaverequest(b);
        GridView1.DataBind();
        GroupGridView(GridView1.Rows, 0, 6);
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
            Label ch = (Label)gvrc[i].FindControl("Label7");
            string che = ch.Text;
            Label ch1 = (Label)gvrc[i - 1].FindControl("Label7");
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
    protected void Button5_Click(object sender, EventArgs e)
    {
        string str = string.Empty;
        foreach(GridViewRow gvrow in GridView1.Rows)
        {
            CheckBox chk1 = (CheckBox)gvrow.FindControl("chk");
            if (chk1.Checked)
            {
                Label ch = (Label)gvrow.FindControl("Label7");
                string che = ch.Text;
                b.leavemerge = int.Parse(che);
                string empid = Session["id2"].ToString();
                b.empid = int.Parse(empid);
                b.cancelleaverequest(b);
            }
        }
        gridfillleaverequest();
    }
}