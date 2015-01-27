using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Home_Viewprofile : System.Web.UI.Page
{
    DAL d = new DAL();
    BAL b = new BAL();    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id2"] == null)
            Response.Redirect("../login/login.aspx");
        string empid = Session["id2"].ToString();
        formfill(empid);
    }
    public void formfill(string empid)
    {
        FormView1.DataSource = d.formfill(empid);
        FormView1.DataBind();
    }
    protected void FormView1_ModeChanging(object sender, FormViewModeEventArgs e)
    {
        FormView1.ChangeMode(e.NewMode);
        string empid = Session["id2"].ToString();
        formfill(empid);
    }
}