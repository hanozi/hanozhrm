using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class BAL
{
	public BAL()
	{	
	}
    public int empid { get; set; }
    public string usertype { get; set; }
    public string empname { get; set; }
    public string deptname { get; set; }
    public string designation { get; set; }
    public DateTime doj { get; set; }
    public DateTime dob { get; set; }
    public string email { get; set; }
    public Int64 mobile { get; set; }
    public string gender { get; set; }
    public string maritalstatus { get; set; }
    public string address { get; set; }
    public int zipcode { get; set; }
    public string state { get; set; }
    public string country { get; set; }
    public string label { get; set; }
    public string password { get; set; }
    public int shiftid { get; set; }
    public DateTime shiftchangefrom { get; set; }
    public DateTime shiftchangeto { get; set; }
    public string reason { get; set; }
    public string status { get; set; }
    public int leaveid { get; set; }
    public string leavetype { get; set; }
    public string leaveduration { get; set; }
    public string fromdate { get; set; }
    public string todate { get; set; }
    public int ushiftid { get; set; }
    public string date { get; set; }
    public int count { get; set; }
    public int leavemerge { get; set; }
    public int shiftmerge { get; set; }
    public int maxid { get; set; }
    public int pl { get; set; }
    public DateTime bdate { get; set; }
    public string shiftname { get; set; }
    public string intime { get; set; }
    public string outtime { get; set; }
    public int correctionid { get; set; }
    public int attrequestid { get; set; }
    public int regularisationid { get; set; }
    public string request { get; set; }
    public string actualtime { get; set; }
    public string descr { get; set; }
    public string category { get; set; }
    public string totalhrs { get; set; }
    public int expid { get; set; }
    public string type { get; set; }
    public int amount { get; set; }
    public string remarks { get; set; }
    public string paidstatus { get; set; }
    public string image { get; set; }
    public string advfor { get; set; }
    public int claimedamount { get; set; }
    public int advid { get; set; }
    public int claimid { get; set; }
    public string adjustments { get; set; }

    public void logincheck(BAL b)
    {
        DAL d = new DAL();
        d.logincheck(b);
    }
    public void forgotpassword(BAL b)
    {
        DAL d = new DAL();
        d.forgotpassword(b);
    }
    public void changepassword(BAL b)
    {
        DAL d = new DAL();
        d.changepassword(b);
    }
    public void addemployee(BAL b)
    {
        DAL d = new DAL();
        d.addemployee(b);
    }
    public void deleteemployee(BAL b)
    {
        DAL d = new DAL();
        d.deleteemployee(b);
    }
    public void updateemployee(BAL b)
    {
        DAL d = new DAL();
        d.updateemployee(b);
    }
    public DataSet gridfillshiftrequest(BAL b)
    {
        DAL d = new DAL();
        return d.gridfillshiftrequest(b);
    }
    public void addshiftrequest(BAL b)
    {
        DAL d = new DAL();
        d.addshiftrequest(b);
    }
    public DataSet gridfilldeleteemployee(BAL b)
    {
        DAL d = new DAL();
        return d.gridfilldeleteemployee(b);
    }
    public DataSet gridfillleaverequest(BAL b)
    {
        DAL d = new DAL();
        return d.gridfillleaverequest(b);
    }
    public void addleaverequest(BAL b)
    {
        DAL d = new DAL();
        d.addleaverequest(b);
    }
    public void cancelleaverequest(BAL b)
    {
        DAL d = new DAL();
        d.cancelleaverequest(b);
    }
    public DataTable gridfillleavebalance(BAL b)
    {
        DAL d = new DAL();
        return d.gridfillleavebalance(b);
    }
    public DataTable gridfillmanageshiftrequest(BAL b)
    {
        DAL d = new DAL();
        return d.gridfillmanageshiftrequest(b);
    }
    public void rejectshiftrequest(BAL b)
    {
        DAL d = new DAL();
        d.rejectshiftrequest(b);
    }
    public void approveshiftrequest(BAL b)
    {
        DAL d = new DAL();
        d.approveshiftrequest(b);
    }
    public DataSet gridfillshiftrequestlist(BAL b)
    {
        DAL d = new DAL();
        return d.gridfillshiftrequestlist(b);
    }
    public DataTable gridfillmanageleaveapplication(BAL b)
    {
        DAL d = new DAL();
        return d.gridfillmanageleaveapplication(b);
    }
    public void rejectleaverequest(BAL b)
    {
        DAL d = new DAL();
        d.rejectleaverequest(b);
    }
    public void approveleaverequest(BAL b)
    {
        DAL d = new DAL();
        d.approveleaverequest(b);
    }
    public DataSet gridfillleaverequestlist(BAL b)
    {
        DAL d = new DAL();
        return d.gridfillleaverequestlist(b);
    }
    public DataSet gridfillthought(BAL b)
    {
        DAL d = new DAL();
        return d.gridfillthought(b);
    }
    public DataTable gridfillshowlrequest(BAL b)
    {
        DAL d = new DAL();
        return d.gridfillshowlrequest(b);
    }
    public DataTable gridfillshowsrequest(BAL b)
    {
        DAL d = new DAL();
        return d.gridfillshowsrequest(b);
    }
    public DataTable gridfillcorrectionrequest(BAL b)
    {
        DAL d = new DAL();
        return d.gridfillcorrectionrequest(b);
    }
    public void addcorrectionrequest(BAL b)
    {
        DAL d = new DAL();
        d.addcorrectionrequest(b);
    }
    public DataTable gridfillregularisationrequest(BAL b)
    {
        DAL d = new DAL();
        return d.gridfillregularisationrequest(b);
    }
    public void addregularisationrequest(BAL b)
    {
        DAL d = new DAL();
        d.addregularisationrequest(b);
    }
    public DataTable gridfillmanagecorrectionrequest(BAL b)
    {
        DAL d = new DAL();
        return d.gridfillmanagecorrectionrequest(b);
    }
    public void rejectcorrectionrequest(BAL b)
    {
        DAL d = new DAL();
        d.rejectcorrectionrequest(b);
    }
    public void approvecorrectionrequestin(BAL b)
    {
        DAL d = new DAL();
        d.approvecorrectionrequestin(b);
    }
    public void approvecorrectionrequestout(BAL b)
    {
        DAL d = new DAL();
        d.approvecorrectionrequestout(b);
    }
    public DataTable gridfillmanageregularisationrequest(BAL b)
    {
        DAL d = new DAL();
        return d.gridfillmanageregularisationrequest(b);
    }
    public void rejectregularisationrequest(BAL b)
    {
        DAL d = new DAL();
        d.rejectregularisationrequest(b);
    }
    public void approveregularisationrequest(BAL b)
    {
        DAL d = new DAL();
        d.approveregularisationrequest(b);
    }
    public DataTable gridfillattrequest(BAL b)
    {
        DAL d = new DAL();
        return d.gridfillattrequest(b);
    }
    public void addattrequest(BAL b)
    {
        DAL d = new DAL();
        d.addattrequest(b);
    }
    public DataTable gridfillmanageattrequest(BAL b)
    {
        DAL d = new DAL();
        return d.gridfillmanageattrequest(b);
    }
    public void rejectattrequest(BAL b)
    {
        DAL d = new DAL();
        d.rejectattrequest(b);
    }
    public void approveattrequest(BAL b)
    {
        DAL d = new DAL();
        d.approveattrequest(b);
    }
    public DataSet gridfillcorrectionrequestlist(BAL b)
    {
        DAL d = new DAL();
        return d.gridfillcorrectionrequestlist(b);
    }
    public DataSet gridfillregularisationrequestlist(BAL b)
    {
        DAL d = new DAL();
        return d.gridfillregularisationrequestlist(b);
    }
    public DataSet gridfillattrequestlist(BAL b)
    {
        DAL d = new DAL();
        return d.gridfillattrequestlist(b);
    }
    public DataSet gridfillexpensesrequest(BAL b)
    {
        DAL d = new DAL();
        return d.gridfillexpensesrequest(b);
    }
    public DataSet gridfillexpensesrequestlist(BAL b)
    {
        DAL d = new DAL();
        return d.gridfillexpensesrequestlist(b);
    }
    public void expenserequest(BAL b)
    {
        DAL d = new DAL();
        d.expenserequest(b);
    }
    public DataTable gridfillmanageexpenserequest(BAL b)
    {
        DAL d = new DAL();
        return d.gridfillmanageexpenserequest(b);
    }
    public void rejectexpenserequest(BAL b)
    {
        DAL d = new DAL();
        d.rejectexpenserequest(b);
    }
    public void approveexpenserequest(BAL b)
    {
        DAL d = new DAL();
        d.approveexpenserequest(b);
    }
    public DataSet gridfilladvancerequisition(BAL b)
    {
        DAL d = new DAL();
        return d.gridfilladvancerequisition(b);
    }
    public DataSet gridfilladvancerequisitionlist(BAL b)
    {
        DAL d = new DAL();
        return d.gridfilladvancerequisitionlist(b);
    }
    public string addadvancerequisition(BAL b)
    {
        DAL d = new DAL();
        return d.addadvancerequisition(b);
    }
    public DataTable gridfillmanageadvancerequest(BAL b)
    {
        DAL d = new DAL();
        return d.gridfillmanageadvancerequest(b);
    }
    public void rejectadvancerequisition(BAL b)
    {
        DAL d = new DAL();
        d.rejectadvancerequisition(b);
    }
    public void approveadvancerequisition(BAL b)
    {
        DAL d = new DAL();
        d.approveadvancerequisition(b);
    }
    public DataTable gridfillclaimrequest(BAL b)
    {
        DAL d = new DAL();
        return d.gridfillclaimrequest(b);
    }
    public void addclaimrequest(BAL b)
    {
        DAL d = new DAL();
        d.addclaimrequest(b);
    }
    public DataTable gridfillmanageclaimadvrequest(BAL b)
    {
        DAL d = new DAL();
        return d.gridfillmanageclaimadvrequest(b);
    }
    public void rejectclaimadvrequest(BAL b)
    {
        DAL d = new DAL();
        d.rejectclaimadvrequest(b);
    }
    public void approveclaimadvrequest(BAL b)
    {
        DAL d = new DAL();
        d.approveclaimadvrequest(b);
    }
    public DataTable getlocation(BAL b)
    {
        DAL d = new DAL();
        return d.getlocation(b);
    }
    public DataSet cancelgridfillleaverequest(BAL b)
    {
        DAL d = new DAL();
        return d.cancelgridfillleaverequest(b);
    }
}