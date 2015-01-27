using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;

public class DAL
{
    string connection = ConfigurationManager.ConnectionStrings["projectConnectionString"].ConnectionString;
    SqlConnection con;
    public DAL()
	{
        con = new SqlConnection(connection);
	}
    public void logincheck(BAL b)
    {
        SqlDataAdapter adp = new SqlDataAdapter("select empname,deptname from tblemployee where empid=@a and password=@b", con);
        adp.SelectCommand.Parameters.AddWithValue("@a", b.empid);
        adp.SelectCommand.Parameters.AddWithValue("@b", b.password);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        if (ds.Tables[0].Rows.Count == 0)
        {
            b.label = "Employee ID or Password Mismatch!";
        }
        else
        {
            string check = ds.Tables[0].Rows[0]["deptname"].ToString();
            if (b.usertype=="Admin & HR" && (check=="Admin" || check=="HR"))
            {
                b.label = "Valid User";
                b.empname = ds.Tables[0].Rows[0]["empname"].ToString();
                b.deptname = ds.Tables[0].Rows[0]["deptname"].ToString();
            }
            
           else if (b.usertype == "Finance" && check == "Finance")
            {
                b.label = "Valid User";
                b.empname = ds.Tables[0].Rows[0]["empname"].ToString();
                b.deptname = ds.Tables[0].Rows[0]["deptname"].ToString();
            }

            else if (b.usertype == "Accounts" && check == "Accounts")
            {
                b.label = "Valid User";
                b.empname = ds.Tables[0].Rows[0]["empname"].ToString();
                b.deptname = ds.Tables[0].Rows[0]["deptname"].ToString();
            }

            else if (b.usertype == "Centerhead" && check == "Centerhead")
            {
                b.label = "Valid User";
                b.empname = ds.Tables[0].Rows[0]["empname"].ToString();
                b.deptname = ds.Tables[0].Rows[0]["deptname"].ToString();
            }
            else
                b.label = "Usertype Mismatch!";
        }    
    }
    public void forgotpassword(BAL b)
    {
        SqlDataAdapter adp = new SqlDataAdapter("select password from tblemployee where empid=@a and mobile=@b", con);
        adp.SelectCommand.Parameters.AddWithValue("@a", b.empid);
        adp.SelectCommand.Parameters.AddWithValue("@b", b.mobile);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        if (ds.Tables[0].Rows.Count == 0)
        {
            b.label = "Invalid Employee ID or Mobile Number!";
        }
        else
        {
            SqlDataAdapter adp1 = new SqlDataAdapter("update tblemployee set password=@d where empid=@c", con);
            adp1.SelectCommand.Parameters.AddWithValue("@c", b.empid);
            adp1.SelectCommand.Parameters.AddWithValue("@d", b.password);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            b.label = "Password Reset Successfull";
        }
    }
    public void changepassword(BAL b)
    {
        SqlDataAdapter adp = new SqlDataAdapter("select * from tblemployee where empid=@a and password=@b", con);
        adp.SelectCommand.Parameters.AddWithValue("@a", b.empid);
        adp.SelectCommand.Parameters.AddWithValue("@b", b.label);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        if (ds.Tables[0].Rows.Count == 0)
        {
            b.label = "Old Password Incorrect!!";
        }
        else
        {
            SqlCommand cmd = new SqlCommand("update tblemployee set password=@d where empid=@c", con);
            cmd.Parameters.AddWithValue("@c", b.empid);
            cmd.Parameters.AddWithValue("@d", b.password);
            con.Open();
            cmd.ExecuteNonQuery();
            b.label = "Password Changed Successfully!!";
        }
    }
    public void addemployee(BAL b)
    {
        SqlCommand cmd = new SqlCommand("insert into tblemployee values(@ename,@dname,@desg,@doj,@dob,@mail,@mobile,@gender,@marital,@address,@zipcode,@state,@country,@password,@user,@shift,@perdaypay)", con);
        cmd.Parameters.AddWithValue("@ename", b.empname);
        cmd.Parameters.AddWithValue("@dname", b.deptname);
        cmd.Parameters.AddWithValue("@desg", b.designation);
        cmd.Parameters.AddWithValue("@doj", b.doj);
        cmd.Parameters.AddWithValue("@dob", b.dob);
        cmd.Parameters.AddWithValue("@mail", b.email);
        cmd.Parameters.AddWithValue("@mobile", b.mobile);
        cmd.Parameters.AddWithValue("@gender", b.gender);
        cmd.Parameters.AddWithValue("@marital", b.maritalstatus);
        cmd.Parameters.AddWithValue("@address", b.address);
        cmd.Parameters.AddWithValue("@zipcode", b.zipcode);
        cmd.Parameters.AddWithValue("@state", b.state);
        cmd.Parameters.AddWithValue("@country", b.country);
        cmd.Parameters.AddWithValue("@password", b.password);
        cmd.Parameters.AddWithValue("@user", b.label);
        cmd.Parameters.AddWithValue("@shift", b.shiftid);
        cmd.Parameters.AddWithValue("@perdaypay", b.advid);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        SqlDataAdapter adp = new SqlDataAdapter("Select max(empid)as empid from tblemployee", con);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        SqlCommand cmd1 = new SqlCommand("insert into tblleavebalance values(@empid,@PL,@bdate)", con);
        b.maxid = int.Parse(dt.Rows[0]["empid"].ToString());
        b.pl = 1;
        DateTime time1 = DateTime.Now;
        DateTime time2 = time1.AddMonths(1);
        TimeSpan ts = time2 - time1;
        string day = ts.TotalDays.ToString();
        string month = time1.Month.ToString();
        string year = time1.Year.ToString();
        DateTime actualdate = DateTime.Parse(day + "-" + month + "-" + year+ " 00:00:00");
        string act = actualdate.ToString("yyyy-MM-dd");
        cmd1.Parameters.AddWithValue("@empid", b.maxid);
        cmd1.Parameters.AddWithValue("@PL", b.pl);
        cmd1.Parameters.AddWithValue("@bdate", act);
        con.Open();
        cmd1.ExecuteNonQuery();
        con.Close();       
    }
    public void deleteemployee(BAL b)
    {
        SqlCommand cmd = new SqlCommand("delete from tblemployee where empid=@c", con);
        cmd.Parameters.AddWithValue("@c", b.empid);
        con.Open();
        cmd.ExecuteNonQuery();
    }
    public void updateemployee(BAL b)
    {
        SqlCommand cmd = new SqlCommand("update tblemployee set empname=@a,deptname=@b,designation=@c,doj=@d,dob=@e,email=@f,mobile=@g,gender=@h,maritalstatus=@i,address=@j,zipcode=@k,state=@l,country=@m where empid=@n", con);
        cmd.Parameters.AddWithValue("@n", b.empid);
        cmd.Parameters.AddWithValue("@a", b.empname);
        cmd.Parameters.AddWithValue("@b", b.deptname);
        cmd.Parameters.AddWithValue("@c", b.designation);
        cmd.Parameters.AddWithValue("@d", b.doj);
        cmd.Parameters.AddWithValue("@e", b.dob);
        cmd.Parameters.AddWithValue("@f", b.email);
        cmd.Parameters.AddWithValue("@g", b.mobile);
        cmd.Parameters.AddWithValue("@h", b.gender);
        cmd.Parameters.AddWithValue("@i", b.maritalstatus);
        cmd.Parameters.AddWithValue("@j", b.address);
        cmd.Parameters.AddWithValue("@k", b.zipcode);
        cmd.Parameters.AddWithValue("@l", b.state);
        cmd.Parameters.AddWithValue("@m", b.country);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        b.label = "Employee updated Successfully";
    }
    public DataSet gridfillshiftrequest(BAL b)
    {
        SqlDataAdapter adp = new SqlDataAdapter("SELECT tblshift.shiftname, tblshiftrequest.shiftchangefrom, tblshiftrequest.shiftchangeto, tblshift.intime, tblshift.outtime, tblshiftrequest.reason, tblshiftrequest.status, tblshiftrequest.shiftmerge FROM tblshift INNER JOIN tblshiftrequest ON tblshift.shiftid = tblshiftrequest.shiftid WHERE tblshiftrequest.empid=@empid", con);
        adp.SelectCommand.Parameters.AddWithValue("@empid", b.empid);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        return ds;
    }
    public void addshiftrequest(BAL b)
    {
        SqlCommand cmd = new SqlCommand("insert into tblshiftrequest values(@shiftid,@shiftchangefrom,@shiftchangeto,@reason,@status,@empid,@shiftmerge,@shiftname,@intime,@outtime)", con);
        cmd.Parameters.AddWithValue("@shiftid", b.shiftid);
        cmd.Parameters.AddWithValue("@shiftchangefrom", b.fromdate);
        cmd.Parameters.AddWithValue("@shiftchangeto", b.todate);
        cmd.Parameters.AddWithValue("@reason", b.reason);
        cmd.Parameters.AddWithValue("@status", b.status);
        cmd.Parameters.AddWithValue("@empid", b.empid);
        cmd.Parameters.AddWithValue("@shiftmerge", b.shiftmerge);
        if (b.shiftid==1)
        {
            b.shiftname = "Shift A";
            b.intime="06:00:00";
            b.outtime = "14:00:00";
            cmd.Parameters.AddWithValue("@shiftname", b.shiftname);
            cmd.Parameters.AddWithValue("@intime", b.intime);
            cmd.Parameters.AddWithValue("@outtime", b.outtime);
        }
        else if (b.shiftid == 2)
        {
            b.shiftname = "Shift B";
            b.intime = "14:00:00";
            b.outtime = "22:00:00";
            cmd.Parameters.AddWithValue("@shiftname", b.shiftname);
            cmd.Parameters.AddWithValue("@intime", b.intime);
            cmd.Parameters.AddWithValue("@outtime", b.outtime);
        }
        else if (b.shiftid == 3)
        {
            b.shiftname = "Shift C";
            b.intime = "22:00:00";
            b.outtime = "06:00:00";
            cmd.Parameters.AddWithValue("@shiftname", b.shiftname);
            cmd.Parameters.AddWithValue("@intime", b.intime);
            cmd.Parameters.AddWithValue("@outtime", b.outtime);
        }
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public DataTable formfill(string empid)
    {
        SqlDataAdapter adp = new SqlDataAdapter("select * from tblemployee where empid=@a", con);
        adp.SelectCommand.Parameters.AddWithValue("@a", empid);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        return dt;
    }
    public DataSet gridfilldeleteemployee(BAL b)
    {
        SqlDataAdapter adp = new SqlDataAdapter("SELECT * from tblemployee", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        return ds;
    }
    public DataSet gridfillleaverequest(BAL b)
    {
        SqlDataAdapter adp = new SqlDataAdapter("SELECT * from tblleavemaster where empid=@a", con);
        adp.SelectCommand.Parameters.AddWithValue("@a", b.empid);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        return ds;
    }
    public void addleaverequest(BAL b)
    {
        SqlCommand cmd = new SqlCommand("insert into tblleavemaster values(@leavetype,@leaveduration,@empid,@fromdate,@todate,@reason,@status,@leavemerge)", con);
        cmd.Parameters.AddWithValue("@leavetype", b.leavetype );
        cmd.Parameters.AddWithValue("@leaveduration", b.leaveduration);
        cmd.Parameters.AddWithValue("@empid", b.empid);
        cmd.Parameters.AddWithValue("@fromdate", b.fromdate);
        cmd.Parameters.AddWithValue("@todate", b.todate);
        cmd.Parameters.AddWithValue("@reason", b.reason);
        cmd.Parameters.AddWithValue("@status", b.status);
        cmd.Parameters.AddWithValue("@leavemerge", b.leavemerge);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        if (b.leavetype == "PL")
        {
            SqlCommand cmd1 = new SqlCommand("update tblleavebalance set PL=PL-@h where empid=@i", con);
            cmd1.Parameters.AddWithValue("@i", b.empid);
            cmd1.Parameters.AddWithValue("@h", b.count);
            con.Open();
            cmd1.ExecuteNonQuery();
            con.Close();
        }
    }
    public void cancelleaverequest(BAL b)
    {
        SqlDataAdapter adp = new SqlDataAdapter("SELECT * FROM tblleavemaster INNER JOIN tblleavebalance ON tblleavemaster.empid = tblleavebalance.empid where leavemerge=@c", con);
        adp.SelectCommand.Parameters.AddWithValue("@c", b.leavemerge);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        int available = int.Parse(dt.Rows[0]["PL"].ToString());
        int count = dt.Rows.Count;
        int balance = available + count;
        string status = dt.Rows[0]["status"].ToString();
        if (status == "Pending")
        {
            SqlCommand cmd = new SqlCommand("update tblleavebalance set PL=@c where empid=@d", con);
            cmd.Parameters.AddWithValue("@c", balance);
            cmd.Parameters.AddWithValue("@d", b.empid);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        SqlCommand cmd1 = new SqlCommand("update tblleavemaster set status=@b where leavemerge=@c", con);
        b.status = "Cancelled";
        cmd1.Parameters.AddWithValue("@b", b.status);
        cmd1.Parameters.AddWithValue("@c",b.leavemerge);
        con.Open();
        cmd1.ExecuteNonQuery();
        con.Close();
    }
    public DataTable gridfillleavebalance(BAL b)
    {
        SqlDataAdapter adp = new SqlDataAdapter("SELECT * from tblleavebalance where empid=@a", con);
        adp.SelectCommand.Parameters.AddWithValue("@a", b.empid);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        DateTime tdate = DateTime.Parse(dt.Rows[0]["bdate"].ToString());
        DateTime sdate = DateTime.Now;
        int pl = int.Parse(dt.Rows[0]["PL"].ToString())+1;
        if (sdate > tdate)
        {
            SqlCommand cmd = new SqlCommand("update tblleavebalance set bdate=@a,PL=@c where empid=@b", con);
            DateTime time1 = sdate;
            DateTime time2 = time1.AddMonths(1);
            TimeSpan ts = time2 - time1;
            string day = ts.TotalDays.ToString();
            string month = time1.Month.ToString();
            string year = time1.Year.ToString();
            DateTime actualdate = DateTime.Parse(day + "-" + month + "-" + year + " 00:00:00");
            string act = actualdate.ToString("yyyy-MM-dd");
            cmd.Parameters.AddWithValue("@b", b.empid);
            cmd.Parameters.AddWithValue("@c", pl);
            cmd.Parameters.AddWithValue("@a", act);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            SqlDataAdapter adp1 = new SqlDataAdapter("SELECT * from tblleavebalance where empid=@a", con);
            adp1.SelectCommand.Parameters.AddWithValue("@a", b.empid);
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);
            return dt1;
        }
        else
        {
            return dt;
        }
    }
    public DataTable gridfillmanageshiftrequest(BAL b)
    {
        if (b.empid != 20111 && b.empid != 20112)
        {
            b.deptname = "Centerhead";
            string dept = "HR";
            string dept1 = "Admin";
            SqlDataAdapter adp = new SqlDataAdapter("SELECT tblemployee.*,tblshiftrequest.* FROM tblshiftrequest INNER JOIN tblemployee ON tblshiftrequest.empid = tblemployee.empid where (tblemployee.address = @b) AND (tblemployee.deptname != @c) AND (tblemployee.deptname != @d) AND (tblemployee.deptname != @e) AND (tblshiftrequest.status = 'Pending' OR tblshiftrequest.status = 'Rejected')", con);
            adp.SelectCommand.Parameters.AddWithValue("@b", b.address);
            adp.SelectCommand.Parameters.AddWithValue("@c", b.deptname);
            adp.SelectCommand.Parameters.AddWithValue("@d", dept);
            adp.SelectCommand.Parameters.AddWithValue("@e", dept1);
            DataTable ds = new DataTable();
            adp.Fill(ds);
            return ds;
        }
        else if (b.empid == 20112)
        {
            b.deptname = "HR";
            SqlDataAdapter adp = new SqlDataAdapter("SELECT tblemployee.*,tblshiftrequest.* FROM tblshiftrequest INNER JOIN tblemployee ON tblshiftrequest.empid = tblemployee.empid where (tblemployee.deptname = @b) AND (tblshiftrequest.status = 'Pending' OR tblshiftrequest.status = 'Rejected')", con);
            adp.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
            DataTable ds = new DataTable();
            adp.Fill(ds);
            return ds;
        }
        else
        {
            b.deptname = "Centerhead";
            SqlDataAdapter adp = new SqlDataAdapter("SELECT tblemployee.*,tblshiftrequest.* FROM tblshiftrequest INNER JOIN tblemployee ON tblshiftrequest.empid = tblemployee.empid where (tblemployee.deptname = @b OR tblemployee.deptname = 'Admin') AND (tblshiftrequest.status = 'Pending' OR tblshiftrequest.status = 'Rejected')", con);
            adp.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
            DataTable ds = new DataTable();
            adp.Fill(ds);
            return ds;
        }
    }
    public void rejectshiftrequest(BAL b)
    {
        SqlCommand cmd = new SqlCommand("update tblshiftrequest set status=@b where shiftmerge=@c", con);
        cmd.Parameters.AddWithValue("@c", b.shiftmerge);
        cmd.Parameters.AddWithValue("@b", b.status);
        con.Open();
        cmd.ExecuteNonQuery();
    }
    public void approveshiftrequest(BAL b)
    {
        SqlCommand cmd = new SqlCommand("update tblshiftrequest set status=@a where shiftmerge=@b", con);
        cmd.Parameters.AddWithValue("@b", b.shiftmerge);
        cmd.Parameters.AddWithValue("@a", b.status);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        SqlDataAdapter adp = new SqlDataAdapter("select shiftid,ushiftid,empid,shiftchangefrom from tblshiftrequest where shiftmerge=@c", con);
        adp.SelectCommand.Parameters.AddWithValue("@c", b.shiftmerge);
        DataTable ds = new DataTable();
        adp.Fill(ds);
        for (int i = 0; i < ds.Rows.Count; i++)
        {
            SqlCommand cmd2 = new SqlCommand("update tblattendance set shiftid=@d where empid=@e and date=@f", con);
            b.shiftid = int.Parse(ds.Rows[i]["shiftid"].ToString());
            b.empid=int.Parse(ds.Rows[i]["empid"].ToString());
            DateTime dt1 = DateTime.Parse(ds.Rows[i]["shiftchangefrom"].ToString());
            b.fromdate = dt1.ToString("yyyy-MM-dd");
            cmd2.Parameters.AddWithValue("@d", b.shiftid);
            cmd2.Parameters.AddWithValue("@e", b.empid);
            cmd2.Parameters.AddWithValue("@f", b.fromdate);
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();
        }
    }
    public DataSet gridfillshiftrequestlist(BAL b)
    {
        SqlDataAdapter adp = new SqlDataAdapter("SELECT tblshift.shiftname,tblshiftrequest.shiftmerge, tblshiftrequest.shiftchangefrom, tblshiftrequest.shiftchangeto, tblshift.intime, tblshift.outtime, tblshiftrequest.reason, tblshiftrequest.status FROM tblshift INNER JOIN tblshiftrequest ON tblshift.shiftid = tblshiftrequest.shiftid WHERE tblshiftrequest.empid=@empid and status=@a", con);
        adp.SelectCommand.Parameters.AddWithValue("@empid", b.empid);
        adp.SelectCommand.Parameters.AddWithValue("@a", b.status);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        return ds;
    }
    public DataTable gridfillmanageleaveapplication(BAL b)
    {
        if (b.empid != 20111 && b.empid != 20112)
        {
            b.deptname = "Centerhead";
            string dept = "HR";
            string dept1 = "Admin";
            SqlDataAdapter adp = new SqlDataAdapter("SELECT tblemployee.*,tblleavemaster.* FROM tblleavemaster INNER JOIN tblemployee ON tblleavemaster.empid = tblemployee.empid where (tblemployee.address = @b) AND (tblemployee.deptname != @c) AND (tblemployee.deptname != @d) AND (tblemployee.deptname != @e) AND (tblleavemaster.status = 'Pending' OR tblleavemaster.status = 'Rejected')", con);
            adp.SelectCommand.Parameters.AddWithValue("@b", b.address);
            adp.SelectCommand.Parameters.AddWithValue("@c", b.deptname);
            adp.SelectCommand.Parameters.AddWithValue("@d", dept);
            adp.SelectCommand.Parameters.AddWithValue("@e", dept1);
            DataTable ds = new DataTable();
            adp.Fill(ds);
            return ds;
        }
        else if (b.empid == 20112)
        {
            b.deptname = "HR";
            SqlDataAdapter adp = new SqlDataAdapter("SELECT tblemployee.*,tblleavemaster.* FROM tblleavemaster INNER JOIN tblemployee ON tblleavemaster.empid = tblemployee.empid where (tblemployee.deptname = @b) AND (tblleavemaster.status = 'Pending' OR tblleavemaster.status = 'Rejected')", con);
            adp.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
            DataTable ds = new DataTable();
            adp.Fill(ds);
            return ds;
        }
        else
        {
            b.deptname = "Centerhead";
            SqlDataAdapter adp = new SqlDataAdapter("SELECT tblemployee.*,tblleavemaster.* FROM tblleavemaster INNER JOIN tblemployee ON tblleavemaster.empid = tblemployee.empid where (tblemployee.deptname = @b) AND (tblleavemaster.status = 'Pending' OR tblleavemaster.status = 'Rejected')", con);
            adp.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
            DataTable ds = new DataTable();
            adp.Fill(ds);
            return ds;
        }
    }
    public void rejectleaverequest(BAL b)
    {
        SqlDataAdapter adp = new SqlDataAdapter("SELECT * FROM tblleavemaster INNER JOIN tblleavebalance ON tblleavemaster.empid = tblleavebalance.empid where leavemerge=@c", con);
        adp.SelectCommand.Parameters.AddWithValue("@c", b.leavemerge);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        int available = int.Parse(dt.Rows[0]["PL"].ToString());
        int count = dt.Rows.Count;
        int balance = available + count;
        string status = dt.Rows[0]["status"].ToString();
        b.empid = int.Parse(dt.Rows[0]["empid"].ToString());
        if (status == "Pending")
        {
            SqlCommand cmd = new SqlCommand("update tblleavebalance set PL=@c where empid=@d", con);
            cmd.Parameters.AddWithValue("@c", balance);
            cmd.Parameters.AddWithValue("@d", b.empid);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        SqlCommand cmd1 = new SqlCommand("update tblleavemaster set status=@b where leavemerge=@c", con);
        cmd1.Parameters.AddWithValue("@c", b.leavemerge);
        cmd1.Parameters.AddWithValue("@b", b.status);
        con.Open();
        cmd1.ExecuteNonQuery();
        con.Close();
    }
    public void approveleaverequest(BAL b)
    {
        SqlDataAdapter adp1 = new SqlDataAdapter("SELECT * FROM tblleavemaster INNER JOIN tblleavebalance ON tblleavemaster.empid = tblleavebalance.empid where leavemerge=@c", con);
        adp1.SelectCommand.Parameters.AddWithValue("@c", b.leavemerge);
        DataTable dt3 = new DataTable();
        adp1.Fill(dt3);
        int available = int.Parse(dt3.Rows[0]["PL"].ToString());
        int count1 = dt3.Rows.Count;
        int balance = available - count1;
        string status = dt3.Rows[0]["status"].ToString();
        b.empid = int.Parse(dt3.Rows[0]["empid"].ToString());
        if (status == "Rejected")
        {
            SqlCommand cmd1 = new SqlCommand("update tblleavebalance set PL=@c where empid=@d", con);
            cmd1.Parameters.AddWithValue("@c", balance);
            cmd1.Parameters.AddWithValue("@d", b.empid);
            con.Open();
            cmd1.ExecuteNonQuery();
            con.Close();
        }
        SqlCommand cmd = new SqlCommand("update tblleavemaster set status=@a where leavemerge=@b", con);
        cmd.Parameters.AddWithValue("@b", b.leavemerge);
        cmd.Parameters.AddWithValue("@a", b.status);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        SqlDataAdapter adp = new SqlDataAdapter("SELECT * from tblleavemaster where leavemerge=@a", con);
        adp.SelectCommand.Parameters.AddWithValue("@a", b.leavemerge);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        DateTime dt1 = DateTime.Parse(dt.Rows[0]["fromdate"].ToString());
        b.fromdate = dt1.ToString("yyyy-MM-dd");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DateTime dt2 = DateTime.Parse(dt.Rows[i]["fromdate"].ToString());
            b.todate = dt2.ToString("yyyy-MM-dd");
            TimeSpan diff = DateTime.Parse(b.todate.ToString()) - dt1;
            int count = diff.Days + 1;
            b.count = count;
            b.empid = int.Parse(dt.Rows[0]["empid"].ToString());
            b.leavetype = (dt.Rows[i]["leavetype"].ToString());
            SqlCommand cmd2 = new SqlCommand("update tblattendance set leavetype=@d where empid=@e and date = @f", con);
            cmd2.Parameters.AddWithValue("@d", b.leavetype);
            cmd2.Parameters.AddWithValue("@e", b.empid);
            cmd2.Parameters.AddWithValue("@f", b.todate);
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();
        }
    }
    public DataSet gridfillleaverequestlist(BAL b)
    {
        SqlDataAdapter adp = new SqlDataAdapter("SELECT * from tblleavemaster where empid=@a and status=@j", con);
        adp.SelectCommand.Parameters.AddWithValue("@a", b.empid);
        adp.SelectCommand.Parameters.AddWithValue("@j", b.status);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        return ds;
    }
    public DataSet gridfillthought(BAL b)
    {
        SqlDataAdapter adp = new SqlDataAdapter("SELECT TOP 1 thought FROM tblthought ORDER BY NEWID()", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        return ds;
    }
    public DataTable gridfillshowlrequest(BAL b)
    {
        SqlDataAdapter adp = new SqlDataAdapter("SELECT * from tblleavemaster where leaveid=@a", con);
        adp.SelectCommand.Parameters.AddWithValue("@a", b.leaveid);
        DataTable ds = new DataTable();
        adp.Fill(ds);
        return ds;
    }
    public DataTable gridfillshowsrequest(BAL b)
    {
        SqlDataAdapter adp = new SqlDataAdapter("SELECT * from tblshiftrequest where ushiftid=@a", con);
        adp.SelectCommand.Parameters.AddWithValue("@a", b.ushiftid);
        DataTable ds = new DataTable();
        adp.Fill(ds);
        return ds;
    }
    public DataTable gridfillcorrectionrequest(BAL b)
    {
        SqlDataAdapter adp = new SqlDataAdapter("SELECT * from tblcorrection where empid=@a", con);
        adp.SelectCommand.Parameters.AddWithValue("@a", b.empid);
        DataTable ds = new DataTable();
        adp.Fill(ds);
        return ds;
    }
    public void addcorrectionrequest(BAL b)
    {
        SqlCommand cmd = new SqlCommand("insert into tblcorrection values(@request,@acualtime,@date,@descr,@status,@empid)", con);
        cmd.Parameters.AddWithValue("@request", b.request);
        cmd.Parameters.AddWithValue("@acualtime", b.actualtime);
        cmd.Parameters.AddWithValue("@date", b.date);
        cmd.Parameters.AddWithValue("@descr", b.descr);
        cmd.Parameters.AddWithValue("@status", b.status);
        cmd.Parameters.AddWithValue("@empid", b.empid);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public DataTable gridfillregularisationrequest(BAL b)
    {
        SqlDataAdapter adp = new SqlDataAdapter("SELECT * from tblregularisation where empid=@a", con);
        adp.SelectCommand.Parameters.AddWithValue("@a", b.empid);
        DataTable ds = new DataTable();
        adp.Fill(ds);
        return ds;
    }
    public void addregularisationrequest(BAL b)
    {
        SqlCommand cmd = new SqlCommand("insert into tblregularisation values(@category,@fromdate,@todate,@descr,@status,@empid)", con);
        cmd.Parameters.AddWithValue("@category", b.category);
        cmd.Parameters.AddWithValue("@fromdate", b.fromdate);
        cmd.Parameters.AddWithValue("@todate", b.todate);
        cmd.Parameters.AddWithValue("@descr", b.descr);
        cmd.Parameters.AddWithValue("@status", b.status);
        cmd.Parameters.AddWithValue("@empid", b.empid);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public DataTable gridfillmanagecorrectionrequest(BAL b)
    {
        if (b.empid != 20111 && b.empid != 20112)
        {
            b.deptname = "Centerhead";
            string dept = "HR";
            string dept1 = "Admin";
            SqlDataAdapter adp = new SqlDataAdapter("SELECT tblemployee.*,tblcorrection.* FROM tblcorrection INNER JOIN tblemployee ON tblcorrection.empid = tblemployee.empid where (tblemployee.address = @b) AND (tblemployee.deptname != @c) AND (tblemployee.deptname != @d) AND (tblemployee.deptname != @e) AND (tblcorrection.status = 'Pending' OR tblcorrection.status = 'Rejected')", con);
            adp.SelectCommand.Parameters.AddWithValue("@b", b.address);
            adp.SelectCommand.Parameters.AddWithValue("@c", b.deptname);
            adp.SelectCommand.Parameters.AddWithValue("@d", dept);
            adp.SelectCommand.Parameters.AddWithValue("@e", dept1);
            DataTable ds = new DataTable();
            adp.Fill(ds);
            return ds;
        }
        else if (b.empid == 20112)
        {
            b.deptname = "HR";
            SqlDataAdapter adp = new SqlDataAdapter("SELECT tblemployee.*,tblcorrection.* FROM tblcorrection INNER JOIN tblemployee ON tblcorrection.empid = tblemployee.empid where (tblemployee.deptname = @b) AND (tblcorrection.status = 'Pending' OR tblcorrection.status = 'Rejected')", con);
            adp.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
            DataTable ds = new DataTable();
            adp.Fill(ds);
            return ds;
        }
        else
        {
            b.deptname = "Centerhead";
            SqlDataAdapter adp = new SqlDataAdapter("SELECT tblemployee.*,tblcorrection.* FROM tblcorrection INNER JOIN tblemployee ON tblcorrection.empid = tblemployee.empid where (tblemployee.deptname = @b) AND (tblcorrection.status = 'Pending' OR tblcorrection.status = 'Rejected')", con);
            adp.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
            DataTable ds = new DataTable();
            adp.Fill(ds);
            return ds;
        }
    }
    public void rejectcorrectionrequest(BAL b)
    {
        SqlCommand cmd = new SqlCommand("update tblcorrection set status=@b where correctionid=@c", con);
        cmd.Parameters.AddWithValue("@c", b.correctionid);
        cmd.Parameters.AddWithValue("@b", b.status);
        con.Open();
        cmd.ExecuteNonQuery();
    }
    public void approvecorrectionrequestin(BAL b)
    {
        SqlCommand cmd = new SqlCommand("update tblcorrection set status=@a where correctionid=@b", con);
        cmd.Parameters.AddWithValue("@b", b.correctionid);
        cmd.Parameters.AddWithValue("@a", b.status);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        SqlCommand cmd2 = new SqlCommand("update tblattendance set intime=@d where empid=@e and date=@f", con);
        cmd2.Parameters.AddWithValue("@d", b.intime);
        cmd2.Parameters.AddWithValue("@e", b.empid);
        cmd2.Parameters.AddWithValue("@f", b.date);
        con.Open();
        cmd2.ExecuteNonQuery();
        con.Close();
    }
    public void approvecorrectionrequestout(BAL b)
    {
        SqlCommand cmd = new SqlCommand("update tblcorrection set status=@a where correctionid=@b", con);
        cmd.Parameters.AddWithValue("@b", b.correctionid);
        cmd.Parameters.AddWithValue("@a", b.status);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        SqlCommand cmd2 = new SqlCommand("update tblattendance set outtime=@d where empid=@e and date=@f", con);
        cmd2.Parameters.AddWithValue("@d", b.intime);
        cmd2.Parameters.AddWithValue("@e", b.empid);
        cmd2.Parameters.AddWithValue("@f", b.date);
        con.Open();
        cmd2.ExecuteNonQuery();
        con.Close();
    }
    public DataTable gridfillmanageregularisationrequest(BAL b)
    {
        if (b.empid != 20111 && b.empid != 20112)
        {
            b.deptname = "Centerhead";
            string dept = "HR";
            string dept1 = "Admin";
            SqlDataAdapter adp = new SqlDataAdapter("SELECT tblemployee.*,tblregularisation.* FROM tblregularisation INNER JOIN tblemployee ON tblregularisation.empid = tblemployee.empid where (tblemployee.address = @b) AND (tblemployee.deptname != @c) AND (tblemployee.deptname != @d) AND (tblemployee.deptname != @e) AND (tblregularisation.status = 'Pending' OR tblregularisation.status = 'Rejected')", con);
            adp.SelectCommand.Parameters.AddWithValue("@b", b.address);
            adp.SelectCommand.Parameters.AddWithValue("@c", b.deptname);
            adp.SelectCommand.Parameters.AddWithValue("@d", dept);
            adp.SelectCommand.Parameters.AddWithValue("@e", dept1);
            DataTable ds = new DataTable();
            adp.Fill(ds);
            return ds;
        }
        else if (b.empid == 20112)
        {
            b.deptname = "HR";
            SqlDataAdapter adp = new SqlDataAdapter("SELECT tblemployee.*,tblregularisation.* FROM tblregularisation INNER JOIN tblemployee ON tblregularisation.empid = tblemployee.empid where (tblemployee.deptname = @b) AND (tblregularisation.status = 'Pending' OR tblregularisation.status = 'Rejected')", con);
            adp.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
            DataTable ds = new DataTable();
            adp.Fill(ds);
            return ds;
        }
        else
        {
            b.deptname = "Centerhead";
            SqlDataAdapter adp = new SqlDataAdapter("SELECT tblemployee.*,tblregularisation.* FROM tblregularisation INNER JOIN tblemployee ON tblregularisation.empid = tblemployee.empid where (tblemployee.deptname = @b) AND (tblregularisation.status = 'Pending' OR tblregularisation.status = 'Rejected')", con);
            adp.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
            DataTable ds = new DataTable();
            adp.Fill(ds);
            return ds;
        }
    }
    public void rejectregularisationrequest(BAL b)
    {
        SqlCommand cmd = new SqlCommand("update tblregularisation set status=@b where regularisationid=@c", con);
        cmd.Parameters.AddWithValue("@c", b.regularisationid);
        cmd.Parameters.AddWithValue("@b", b.status);
        con.Open();
        cmd.ExecuteNonQuery();
    }
    public void approveregularisationrequest(BAL b)
    {
        SqlCommand cmd = new SqlCommand("update tblregularisation set status=@a where regularisationid=@b", con);
        cmd.Parameters.AddWithValue("@b", b.regularisationid);
        cmd.Parameters.AddWithValue("@a", b.status);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        SqlCommand cmd2 = new SqlCommand("update tblattendance set leavetype=@f where (date BETWEEN @c AND @d) AND (empid = @e)", con);
        cmd2.Parameters.AddWithValue("@c", b.fromdate);
        cmd2.Parameters.AddWithValue("@d", b.todate);
        cmd2.Parameters.AddWithValue("@e", b.empid);
        cmd2.Parameters.AddWithValue("@f", b.category);
        con.Open();
        cmd2.ExecuteNonQuery();
        con.Close();
    }
    public DataTable gridfillattrequest(BAL b)
    {
        SqlDataAdapter adp = new SqlDataAdapter("SELECT * from tblattrequest where empid=@a", con);
        adp.SelectCommand.Parameters.AddWithValue("@a", b.empid);
        DataTable ds = new DataTable();
        adp.Fill(ds);
        return ds;
    }
    public void addattrequest(BAL b)
    {
        SqlCommand cmd = new SqlCommand("insert into tblattrequest values(@intime,@outtime,@date,@descr,@status,@empid)", con);
        cmd.Parameters.AddWithValue("@intime", b.intime);
        cmd.Parameters.AddWithValue("@outtime", b.outtime);
        cmd.Parameters.AddWithValue("@date", b.date);
        cmd.Parameters.AddWithValue("@descr", b.descr);
        cmd.Parameters.AddWithValue("@status", b.status);
        cmd.Parameters.AddWithValue("@empid", b.empid);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public DataTable gridfillmanageattrequest(BAL b)
    {
        if (b.empid != 20111 && b.empid != 20112)
        {
            b.deptname = "Centerhead";
            string dept = "HR";
            string dept1 = "Admin";
            SqlDataAdapter adp = new SqlDataAdapter("SELECT tblemployee.*,tblattrequest.* FROM tblattrequest INNER JOIN tblemployee ON tblattrequest.empid = tblemployee.empid where (tblemployee.address = @b) AND (tblemployee.deptname != @c) AND (tblemployee.deptname != @d) AND (tblemployee.deptname != @e) AND (tblattrequest.status = 'Pending' OR tblattrequest.status = 'Rejected')", con);
            adp.SelectCommand.Parameters.AddWithValue("@b", b.address);
            adp.SelectCommand.Parameters.AddWithValue("@c", b.deptname);
            adp.SelectCommand.Parameters.AddWithValue("@d", dept);
            adp.SelectCommand.Parameters.AddWithValue("@e", dept1);
            DataTable ds = new DataTable();
            adp.Fill(ds);
            return ds;
        }
        else if (b.empid == 20112)
        {
            b.deptname = "HR";
            SqlDataAdapter adp = new SqlDataAdapter("SELECT tblemployee.*,tblattrequest.* FROM tblattrequest INNER JOIN tblemployee ON tblattrequest.empid = tblemployee.empid where (tblemployee.deptname = @b) AND (tblattrequest.status = 'Pending' OR tblattrequest.status = 'Rejected')", con);
            adp.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
            DataTable ds = new DataTable();
            adp.Fill(ds);
            return ds;
        }
        else
        {
            b.deptname = "Centerhead";
            SqlDataAdapter adp = new SqlDataAdapter("SELECT tblemployee.*,tblattrequest.* FROM tblattrequest INNER JOIN tblemployee ON tblattrequest.empid = tblemployee.empid where (tblemployee.deptname = @b) AND (tblattrequest.status = 'Pending' OR tblattrequest.status = 'Rejected')", con);
            adp.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
            DataTable ds = new DataTable();
            adp.Fill(ds);
            return ds;
        }
    }
    public void rejectattrequest(BAL b)
    {
        SqlCommand cmd = new SqlCommand("update tblattrequest set status=@b where attrequestid=@c", con);
        cmd.Parameters.AddWithValue("@c", b.attrequestid);
        cmd.Parameters.AddWithValue("@b", b.status);
        con.Open();
        cmd.ExecuteNonQuery();
    }
    public void approveattrequest(BAL b)
    {
        SqlCommand cmd = new SqlCommand("update tblattrequest set status=@a where attrequestid=@b", con);
        cmd.Parameters.AddWithValue("@b", b.attrequestid);
        cmd.Parameters.AddWithValue("@a", b.status);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        SqlCommand cmd2 = new SqlCommand("update tblattendance set outtime=@d, intime=@f,totalhrs=@g where date=@c AND empid = @e", con);
        cmd2.Parameters.AddWithValue("@c", b.date);
        cmd2.Parameters.AddWithValue("@d", b.outtime);
        cmd2.Parameters.AddWithValue("@e", b.empid);
        cmd2.Parameters.AddWithValue("@f", b.intime);
        cmd2.Parameters.AddWithValue("@g", b.totalhrs);
        con.Open();
        cmd2.ExecuteNonQuery();
        con.Close();
    }
    public DataSet gridfillcorrectionrequestlist(BAL b)
    {
        SqlDataAdapter adp = new SqlDataAdapter("SELECT * from tblcorrection where empid=@a and status=@j", con);
        adp.SelectCommand.Parameters.AddWithValue("@a", b.empid);
        adp.SelectCommand.Parameters.AddWithValue("@j", b.status);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        return ds;
    }
    public DataSet gridfillregularisationrequestlist(BAL b)
    {
        SqlDataAdapter adp = new SqlDataAdapter("SELECT * from tblregularisation where empid=@a and status=@j", con);
        adp.SelectCommand.Parameters.AddWithValue("@a", b.empid);
        adp.SelectCommand.Parameters.AddWithValue("@j", b.status);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        return ds;
    }
    public DataSet gridfillattrequestlist(BAL b)
    {
        SqlDataAdapter adp = new SqlDataAdapter("SELECT * from tblattrequest where empid=@a and status=@j", con);
        adp.SelectCommand.Parameters.AddWithValue("@a", b.empid);
        adp.SelectCommand.Parameters.AddWithValue("@j", b.status);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        return ds;
    }
    public DataSet gridfillexpensesrequest(BAL b)
    {
        SqlDataAdapter adp = new SqlDataAdapter("SELECT * from tblexpense where empid=@a", con);
        adp.SelectCommand.Parameters.AddWithValue("@a", b.empid);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        return ds;
    }
    public DataSet gridfillexpensesrequestlist(BAL b)
    {
        SqlDataAdapter adp = new SqlDataAdapter("SELECT * from tblexpense where empid=@a and status=@j", con);
        adp.SelectCommand.Parameters.AddWithValue("@a", b.empid);
        adp.SelectCommand.Parameters.AddWithValue("@j", b.status);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        return ds;
    }
    public void expenserequest(BAL b)
    {
        SqlCommand cmd = new SqlCommand("insert into tblexpense values(@date,@category,@type,@amount,@remarks,@status,@reason,@paidstatus,@empid,@image)", con);
        cmd.Parameters.AddWithValue("@date", b.date);
        cmd.Parameters.AddWithValue("@category", b.category);
        cmd.Parameters.AddWithValue("@type", b.type);
        cmd.Parameters.AddWithValue("@amount", b.amount);
        cmd.Parameters.AddWithValue("@remarks", b.remarks);
        cmd.Parameters.AddWithValue("@status", b.status);
        cmd.Parameters.AddWithValue("@reason", b.reason);
        cmd.Parameters.AddWithValue("@paidstatus", b.paidstatus);
        cmd.Parameters.AddWithValue("@empid", b.empid);
        cmd.Parameters.AddWithValue("@image", b.image);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public DataTable gridfillmanageexpenserequest(BAL b)
    {
        if (b.empid != 20111 && b.empid != 20112)
        {
            b.deptname = "Centerhead";
            string dept = "HR";
            string dept1 = "Admin";
            SqlDataAdapter adp = new SqlDataAdapter("SELECT tblemployee.*,tblexpense.* FROM tblexpense INNER JOIN tblemployee ON tblexpense.empid = tblemployee.empid where (tblemployee.address = @b) AND (tblemployee.deptname != @c) AND (tblemployee.deptname != @d) AND (tblemployee.deptname != @e) AND (tblexpense.status = 'Pending' OR tblexpense.status = 'Rejected')", con);
            adp.SelectCommand.Parameters.AddWithValue("@b", b.address);
            adp.SelectCommand.Parameters.AddWithValue("@c", b.deptname);
            adp.SelectCommand.Parameters.AddWithValue("@d", dept);
            adp.SelectCommand.Parameters.AddWithValue("@e", dept1);
            DataTable ds = new DataTable();
            adp.Fill(ds);
            return ds;
        }
        else if (b.empid == 20112)
        {
            b.deptname = "HR";
            SqlDataAdapter adp = new SqlDataAdapter("SELECT tblemployee.*,tblexpense.* FROM tblexpense INNER JOIN tblemployee ON tblexpense.empid = tblemployee.empid where (tblemployee.deptname = @b) AND (tblexpense.status = 'Pending' OR tblexpense.status = 'Rejected')", con);
            adp.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
            DataTable ds = new DataTable();
            adp.Fill(ds);
            return ds;
        }
        else
        {
            b.deptname = "Centerhead";
            SqlDataAdapter adp = new SqlDataAdapter("SELECT tblemployee.*,tblexpense.* FROM tblexpense INNER JOIN tblemployee ON tblexpense.empid = tblemployee.empid where (tblemployee.deptname = @b) AND (tblexpense.status = 'Pending' OR tblexpense.status = 'Rejected')", con);
            adp.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
            DataTable ds = new DataTable();
            adp.Fill(ds);
            return ds;
        }
    }
    public void rejectexpenserequest(BAL b)
    {
        SqlCommand cmd = new SqlCommand("update tblexpense set status=@b where expid=@c", con);
        cmd.Parameters.AddWithValue("@c", b.expid);
        cmd.Parameters.AddWithValue("@b", b.status);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public void approveexpenserequest(BAL b)
    {
        SqlCommand cmd = new SqlCommand("update tblexpense set status=@a where expid=@b", con);
        cmd.Parameters.AddWithValue("@b", b.expid);
        cmd.Parameters.AddWithValue("@a", b.status);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public DataSet gridfilladvancerequisition(BAL b)
    {
        SqlDataAdapter adp = new SqlDataAdapter("SELECT * from tbladvance where empid=@a", con);
        adp.SelectCommand.Parameters.AddWithValue("@a", b.empid);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        return ds;
    }
    public DataSet gridfilladvancerequisitionlist(BAL b)
    {
        SqlDataAdapter adp = new SqlDataAdapter("SELECT * from tbladvance where empid=@a and status=@j", con);
        adp.SelectCommand.Parameters.AddWithValue("@a", b.empid);
        adp.SelectCommand.Parameters.AddWithValue("@j", b.status);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        return ds;
    }
    public string addadvancerequisition(BAL b)
    {
        SqlCommand cmd = new SqlCommand("insert into tbladvance values(@date,@advfor,@amount,@remarks,@status,@claimedamount,@empid)", con);
        cmd.Parameters.AddWithValue("@date", b.date);
        cmd.Parameters.AddWithValue("@advfor", b.advfor);
        cmd.Parameters.AddWithValue("@amount", b.amount);
        cmd.Parameters.AddWithValue("@remarks", b.remarks);
        cmd.Parameters.AddWithValue("@status", b.status);
        cmd.Parameters.AddWithValue("@claimedamount", b.claimedamount);
        cmd.Parameters.AddWithValue("@empid", b.empid);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        SqlCommand cmd1 = new SqlCommand("Select max(advid) as advid from tbladvance", con);
        con.Open();
        String advid= cmd1.ExecuteScalar().ToString();
        con.Close();
        return advid;
    }
    public DataTable gridfillmanageadvancerequest(BAL b)
    {
        if (b.empid != 20111 && b.empid != 20112)
        {
            b.deptname = "Centerhead";
            string dept = "HR";
            string dept1 = "Admin";
            SqlDataAdapter adp = new SqlDataAdapter("SELECT tblemployee.*,tbladvance.* FROM tbladvance INNER JOIN tblemployee ON tbladvance.empid = tblemployee.empid where (tblemployee.address = @b) AND (tblemployee.deptname != @c) AND (tblemployee.deptname != @d) AND (tblemployee.deptname != @e) AND (tbladvance.status = 'Pending' OR tbladvance.status = 'Rejected')", con);
            adp.SelectCommand.Parameters.AddWithValue("@b", b.address);
            adp.SelectCommand.Parameters.AddWithValue("@c", b.deptname);
            adp.SelectCommand.Parameters.AddWithValue("@d", dept);
            adp.SelectCommand.Parameters.AddWithValue("@e", dept1);
            DataTable ds = new DataTable();
            adp.Fill(ds);
            return ds;
        }
        else if (b.empid == 20112)
        {
            b.deptname = "HR";
            SqlDataAdapter adp = new SqlDataAdapter("SELECT tblemployee.*,tbladvance.* FROM tbladvance INNER JOIN tblemployee ON tbladvance.empid = tblemployee.empid where (tblemployee.deptname = @b) AND (tbladvance.status = 'Pending' OR tbladvance.status = 'Rejected')", con);
            adp.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
            DataTable ds = new DataTable();
            adp.Fill(ds);
            return ds;
        }
        else
        {
            b.deptname = "Centerhead";
            SqlDataAdapter adp = new SqlDataAdapter("SELECT tblemployee.*,tbladvance.* FROM tbladvance INNER JOIN tblemployee ON tbladvance.empid = tblemployee.empid where (tblemployee.deptname = @b) AND (tbladvance.status = 'Pending' OR tbladvance.status = 'Rejected')", con);
            adp.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
            DataTable ds = new DataTable();
            adp.Fill(ds);
            return ds;
        }
    }
    public void rejectadvancerequisition(BAL b)
    {
        SqlCommand cmd = new SqlCommand("update tbladvance set status=@b where advid=@c", con);
        cmd.Parameters.AddWithValue("@c", b.advid);
        cmd.Parameters.AddWithValue("@b", b.status);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public void approveadvancerequisition(BAL b)
    {
        SqlCommand cmd = new SqlCommand("update tbladvance set status=@b where advid=@c", con);
        cmd.Parameters.AddWithValue("@c", b.advid);
        cmd.Parameters.AddWithValue("@b", b.status);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public DataTable gridfillclaimrequest(BAL b)
    {
        SqlDataAdapter adp = new SqlDataAdapter("SELECT * from tblclaim where empid=@a and advid=@b", con);
        adp.SelectCommand.Parameters.AddWithValue("@a", b.empid);
        adp.SelectCommand.Parameters.AddWithValue("@b", b.advid);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        return dt;
    }
    public void addclaimrequest(BAL b)
    {
        SqlCommand cmd = new SqlCommand("insert into tblclaim values(@date,@type,@amount,@remarks,@status,@empid,@advid,@image,@adjustments)", con);
        cmd.Parameters.AddWithValue("@date", b.date);
        cmd.Parameters.AddWithValue("@type", b.type);
        cmd.Parameters.AddWithValue("@amount", b.amount);
        cmd.Parameters.AddWithValue("@remarks", b.remarks);
        cmd.Parameters.AddWithValue("@status", b.status);
        cmd.Parameters.AddWithValue("@empid", b.empid);
        cmd.Parameters.AddWithValue("@advid", b.advid);
        cmd.Parameters.AddWithValue("@image", b.image);
        cmd.Parameters.AddWithValue("@adjustments", b.adjustments);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        SqlDataAdapter adp = new SqlDataAdapter("select sum(amount) as amount from tblclaim where advid=@a", con);
        adp.SelectCommand.Parameters.AddWithValue("@a", b.advid);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        int amount = int.Parse(dt.Rows[0]["amount"].ToString());
        b.amount = amount;
        SqlCommand cmd1 = new SqlCommand("update tbladvance set claimedamount=@a where advid=@b", con);
        cmd1.Parameters.AddWithValue("@a", b.amount);
        cmd1.Parameters.AddWithValue("@b", b.advid);
        con.Open();
        cmd1.ExecuteNonQuery();
        con.Close();
    }
    public DataTable gridfillmanageclaimadvrequest(BAL b)
    {
        if (b.empid != 20111 && b.empid != 20112)
        {
            b.deptname = "Centerhead";
            string dept = "HR";
            string dept1 = "Admin";
            SqlDataAdapter adp = new SqlDataAdapter("SELECT tblemployee.*,tblclaim.* FROM tblclaim INNER JOIN tblemployee ON tblclaim.empid = tblemployee.empid where (tblemployee.address = @b) AND (tblemployee.deptname != @c) AND (tblemployee.deptname != @d) AND (tblemployee.deptname != @e) AND (tblclaim.status = 'Pending' OR tblclaim.status = 'Rejected')", con);
            adp.SelectCommand.Parameters.AddWithValue("@b", b.address);
            adp.SelectCommand.Parameters.AddWithValue("@c", b.deptname);
            adp.SelectCommand.Parameters.AddWithValue("@d", dept);
            adp.SelectCommand.Parameters.AddWithValue("@e", dept1);
            DataTable ds = new DataTable();
            adp.Fill(ds);
            return ds;
        }
        else if (b.empid == 20112)
        {
            b.deptname = "HR";
            SqlDataAdapter adp = new SqlDataAdapter("SELECT tblemployee.*,tblclaim.* FROM tblclaim INNER JOIN tblemployee ON tblclaim.empid = tblemployee.empid where (tblemployee.deptname = @b) AND (tblclaim.status = 'Pending' OR tblclaim.status = 'Rejected')", con);
            adp.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
            DataTable ds = new DataTable();
            adp.Fill(ds);
            return ds;
        }
        else
        {
            b.deptname = "Centerhead";
            SqlDataAdapter adp = new SqlDataAdapter("SELECT tblemployee.*,tblclaim.* FROM tblclaim INNER JOIN tblemployee ON tblclaim.empid = tblemployee.empid where (tblemployee.deptname = @b) AND (tblclaim.status = 'Pending' OR tblclaim.status = 'Rejected')", con);
            adp.SelectCommand.Parameters.AddWithValue("@b", b.deptname);
            DataTable ds = new DataTable();
            adp.Fill(ds);
            return ds;
        }
    }
    public void rejectclaimadvrequest(BAL b)
    {
        SqlCommand cmd = new SqlCommand("update tblclaim set status=@b where claimid=@c", con);
        cmd.Parameters.AddWithValue("@c", b.claimid);
        cmd.Parameters.AddWithValue("@b", b.status);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public void approveclaimadvrequest(BAL b)
    {
        SqlCommand cmd = new SqlCommand("update tblclaim set status=@a where claimid=@b", con);
        cmd.Parameters.AddWithValue("@b", b.claimid);
        cmd.Parameters.AddWithValue("@a", b.status);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public DataTable getlocation(BAL b)
    {
        SqlDataAdapter adp = new SqlDataAdapter("SELECT address,deptname from tblemployee where empid=@a", con);
        adp.SelectCommand.Parameters.AddWithValue("@a", b.empid);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        return dt;
    }
    public DataSet cancelgridfillleaverequest(BAL b)
    {
        SqlDataAdapter adp = new SqlDataAdapter("SELECT * from tblleavemaster where empid=@a and status!='approved'", con);
        adp.SelectCommand.Parameters.AddWithValue("@a", b.empid);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        return ds;
    }
}