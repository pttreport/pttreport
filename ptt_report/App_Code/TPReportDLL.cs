using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ptt_report.App_Code
{
    public class tpreportDLL
    {
        public DataTable GetRep_year()
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " select distinct(year) from tblquarter_rep order by year desc ; ";

            objConn.ConnectionString = ConfigurationManager.ConnectionStrings["dbptt_repConnectionString"].ConnectionString;
            var _with1 = objCmd;
            _with1.Connection = objConn;
            _with1.CommandText = strSQL;
            _with1.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;

            dtAdapter.Fill(ds);
            dt = ds.Tables[0];

            dtAdapter = null;
            objConn.Close();
            objConn = null;

            return dt;
        }

        public DataTable GetRep_quarter()
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " select distinct(quarter) from tblquarter_rep order by quarter desc ; ";

            objConn.ConnectionString = ConfigurationManager.ConnectionStrings["dbptt_repConnectionString"].ConnectionString;
            var _with1 = objCmd;
            _with1.Connection = objConn;
            _with1.CommandText = strSQL;
            _with1.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;

            dtAdapter.Fill(ds);
            dt = ds.Tables[0];

            dtAdapter = null;
            objConn.Close();
            objConn = null;

            return dt;
        }
        public DataTable GetRep_cus_type()
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " select distinct(cus_type) from tblquarter_rep; ";

            objConn.ConnectionString = ConfigurationManager.ConnectionStrings["dbptt_repConnectionString"].ConnectionString;
            var _with1 = objCmd;
            _with1.Connection = objConn;
            _with1.CommandText = strSQL;
            _with1.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;

            dtAdapter.Fill(ds);
            dt = ds.Tables[0];

            dtAdapter = null;
            objConn.Close();
            objConn = null;

            return dt;
        }
        public DataTable GetRep_status()
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " select distinct(status) from tblquarter_rep; ";

            objConn.ConnectionString = ConfigurationManager.ConnectionStrings["dbptt_repConnectionString"].ConnectionString;
            var _with1 = objCmd;
            _with1.Connection = objConn;
            _with1.CommandText = strSQL;
            _with1.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;

            dtAdapter.Fill(ds);
            dt = ds.Tables[0];

            dtAdapter = null;
            objConn.Close();
            objConn = null;

            return dt;
        }
        public DataTable GetRep_list(string cus_type, string year, string quarter, string status)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " select * from tblquarter_rep where cus_type like '%" + cus_type + "%' ";

            if (year != "")
            {
                strSQL += " and year = '" + year + "' ";
            }
            if (quarter != "")
            {
                strSQL += " and quarter = '" + quarter + "' ";
            }
            if (status != "")
            {
                strSQL += " and status = '" + status + "'  ";
            }



            objConn.ConnectionString = ConfigurationManager.ConnectionStrings["dbptt_repConnectionString"].ConnectionString;
            var _with1 = objCmd;
            _with1.Connection = objConn;
            _with1.CommandText = strSQL;
            _with1.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;

            dtAdapter.Fill(ds);
            dt = ds.Tables[0];

            dtAdapter = null;
            objConn.Close();
            objConn = null;

            return dt;
        }

        public void delete_tblquarter_rep(string id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " delete tblquarter_rep where id = '" + id + "' ";


            objConn.ConnectionString = ConfigurationManager.ConnectionStrings["dbptt_repConnectionString"].ConnectionString;
            objConn.Open();
            var _with1 = objCmd;
            _with1.Connection = objConn;
            _with1.CommandText = strSQL;
            _with1.CommandType = CommandType.Text;

            objCmd.ExecuteNonQuery();

            dtAdapter = null;
            objConn.Close();
            objConn = null;

        }

        public DataTable GetTPPermit(string tp_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " select * from tppermit where tp_rep_id =  '" + tp_id + "' ";

            objConn.ConnectionString = ConfigurationManager.ConnectionStrings["dbptt_repConnectionString"].ConnectionString;
            var _with1 = objCmd;
            _with1.Connection = objConn;
            _with1.CommandText = strSQL;
            _with1.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;

            dtAdapter.Fill(ds);
            dt = ds.Tables[0];

            dtAdapter = null;
            objConn.Close();
            objConn = null;

            return dt;
        }

        public DataTable Inserttppermit(string tp_rep_id, string gaspipemaintain, string projectname, string pipepath, string cerfno)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " insert into tppermit(tp_rep_id,gaspipemaintain,projectname,pipepath,cerfno) " +
                    " values('" +

                    tp_rep_id + "','"
                    + gaspipemaintain + "','"
                    + projectname + "','"
                    + pipepath + "','"
                    + cerfno +

                    "'); select @@IDENTITY as id; ";

            objConn.ConnectionString = ConfigurationManager.ConnectionStrings["dbptt_repConnectionString"].ConnectionString;

            var _with1 = objCmd;
            _with1.Connection = objConn;
            _with1.CommandText = strSQL;
            _with1.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;

            dtAdapter.Fill(ds);
            dt = ds.Tables[0];

            dtAdapter = null;
            objConn.Close();
            objConn = null;

            return dt;
        }

        public void Updatetppermit(string tp_rep_id, string gaspipemaintain, string projectname, string pipepath, string cerfno, string id, string update_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " update tppermit set gaspipemaintain = '" + gaspipemaintain +
                "',projectname = '" + projectname +
                "',pipepath = '" + pipepath +
                "',cerfno = '" + cerfno +
                "' " +
                " where tp_rep_id = '" + tp_rep_id + "' and id = '" + id + "'; ";

            objConn.ConnectionString = ConfigurationManager.ConnectionStrings["dbptt_repConnectionString"].ConnectionString;
            objConn.Open();
            var _with1 = objCmd;
            _with1.Connection = objConn;
            _with1.CommandText = strSQL;
            _with1.CommandType = CommandType.Text;

            objCmd.ExecuteNonQuery();

            dtAdapter = null;
            objConn.Close();
            objConn = null;

        }

        public DataTable GetTPExecutiveSummary(string tp_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " select * from tpexecutivesummary where tp_rep_id =  '" + tp_id + "' ";

            objConn.ConnectionString = ConfigurationManager.ConnectionStrings["dbptt_repConnectionString"].ConnectionString;
            var _with1 = objCmd;
            _with1.Connection = objConn;
            _with1.CommandText = strSQL;
            _with1.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;

            dtAdapter.Fill(ds);
            dt = ds.Tables[0];

            dtAdapter = null;
            objConn.Close();
            objConn = null;

            return dt;
        }

        public DataTable Inserttpexecutivesummary(string tp_rep_id, string detail)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " insert into tpexecutivesummary(tp_rep_id,detail) " +
                    " values('" +

                    tp_rep_id + "','"
                    + detail +

                    "'); select @@IDENTITY as id; ";

            objConn.ConnectionString = ConfigurationManager.ConnectionStrings["dbptt_repConnectionString"].ConnectionString;

            var _with1 = objCmd;
            _with1.Connection = objConn;
            _with1.CommandText = strSQL;
            _with1.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;

            dtAdapter.Fill(ds);
            dt = ds.Tables[0];

            dtAdapter = null;
            objConn.Close();
            objConn = null;

            return dt;
        }

        public void Updatetpexecutivesummary(string tp_rep_id, string detail, string id, string update_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " update tpexecutivesummary set detail = '" + detail +

                "' " +
                " where tp_rep_id = '" + tp_rep_id + "' and id = '" + id + "'; ";

            objConn.ConnectionString = ConfigurationManager.ConnectionStrings["dbptt_repConnectionString"].ConnectionString;
            objConn.Open();
            var _with1 = objCmd;
            _with1.Connection = objConn;
            _with1.CommandText = strSQL;
            _with1.CommandType = CommandType.Text;

            objCmd.ExecuteNonQuery();

            dtAdapter = null;
            objConn.Close();
            objConn = null;

        }

        public DataTable GetTPPatrolling(string tp_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " select * from tppatrolling where tp_rep_id =  '" + tp_id + "' ";

            objConn.ConnectionString = ConfigurationManager.ConnectionStrings["dbptt_repConnectionString"].ConnectionString;
            var _with1 = objCmd;
            _with1.Connection = objConn;
            _with1.CommandText = strSQL;
            _with1.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;

            dtAdapter.Fill(ds);
            dt = ds.Tables[0];

            dtAdapter = null;
            objConn.Close();
            objConn = null;

            return dt;
        }

        public DataTable InserttpPatrolling(string tp_rep_id, string gasdetector, string gassiteamount, string gassitedetail, string labelandstealamount, string labelandstealdetail, string testpostdamageamount, string testpostdamagedetail, string scourareaamount, string scourareadetail, string buildingpipepathamount, string buildingpipepathdetail, string rovfreespanamount, string rovfreespandetail, string opinion)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " insert into tppatrolling(tp_rep_id,gasdetector,gassiteamount,gassitedetail,labelandstealamount,labelandstealdetail,testpostdamageamount,testpostdamagedetail,scourareaamount,scourareadetail,buildingpipepathamount,buildingpipepathdetail,rovfreespanamount,rovfreespandetail,opinion) " +
                    " values('" 
                    
                    + tp_rep_id + "','"
                    + gasdetector + "','"
                    + gassiteamount + "','"
                    + gassitedetail + "','"
                    + labelandstealamount + "','"
                    + labelandstealdetail + "','"
                    + testpostdamageamount + "','"
                    + testpostdamagedetail + "','"
                    + scourareaamount + "','"
                    + scourareadetail + "','"
                    + buildingpipepathamount + "','"
                    + buildingpipepathdetail + "','"
                    + rovfreespanamount + "','"
                    + rovfreespandetail + "','"
                    + opinion +

                    "'); select @@IDENTITY as id; ";

            objConn.ConnectionString = ConfigurationManager.ConnectionStrings["dbptt_repConnectionString"].ConnectionString;

            var _with1 = objCmd;
            _with1.Connection = objConn;
            _with1.CommandText = strSQL;
            _with1.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;

            dtAdapter.Fill(ds);
            dt = ds.Tables[0];

            dtAdapter = null;
            objConn.Close();
            objConn = null;

            return dt;
        }

        public void UpdatetpPatrolling(string tp_rep_id, string gasdetector, string gassiteamount, string gassitedetail, string labelandstealamount, string labelandstealdetail, string testpostdamageamount, string testpostdamagedetail, string scourareaamount, string scourareadetail, string buildingpipepathamount, string buildingpipepathdetail, string rovfreespanamount, string rovfreespandetail, string opinion, string id, string update_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " update tppatrolling set gasdetector = '" + gasdetector +

                "',gassiteamount = '" + gassiteamount +
                "',gassitedetail = '" + gassitedetail +
                "',labelandstealamount = '" + labelandstealamount +

                                "',labelandstealdetail = '" + labelandstealdetail +
                "',testpostdamageamount = '" + testpostdamageamount +
                "',testpostdamagedetail = '" + testpostdamagedetail +

                                "',scourareaamount = '" + scourareaamount +
                "',scourareadetail = '" + scourareadetail +
                "',buildingpipepathamount = '" + buildingpipepathamount +

                                "',buildingpipepathdetail = '" + buildingpipepathdetail +
                "',rovfreespanamount = '" + rovfreespanamount +
                "',rovfreespandetail = '" + rovfreespandetail +


                                "',opinion = '" + opinion +
                "' " +
                " where tp_rep_id = '" + tp_rep_id + "' and id = '" + id + "'; ";

            objConn.ConnectionString = ConfigurationManager.ConnectionStrings["dbptt_repConnectionString"].ConnectionString;
            objConn.Open();
            var _with1 = objCmd;
            _with1.Connection = objConn;
            _with1.CommandText = strSQL;
            _with1.CommandType = CommandType.Text;

            objCmd.ExecuteNonQuery();

            dtAdapter = null;
            objConn.Close();
            objConn = null;

        }


        public DataTable GetTPCP(string tp_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " select * from tpcp where tp_rep_id =  '" + tp_id + "' ";

            objConn.ConnectionString = ConfigurationManager.ConnectionStrings["dbptt_repConnectionString"].ConnectionString;
            var _with1 = objCmd;
            _with1.Connection = objConn;
            _with1.CommandText = strSQL;
            _with1.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;

            dtAdapter.Fill(ds);
            dt = ds.Tables[0];

            dtAdapter = null;
            objConn.Close();
            objConn = null;

            return dt;
        }

        public DataTable InserttpCP(string tp_rep_id, string cipsdetail, string cipsopinion, string dcvgdetail, string dcvgopinion, string ptsdetail, string ptsopinion, string rovdetail, string rovopinion)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " insert into tpcp(tp_rep_id,cipsdetail,cipsopinion,dcvgdetail,dcvgopinion,ptsdetail,ptsopinion,rovdetail,rovopinion) " +
                    " values('"

                    + tp_rep_id + "','"
                    + cipsdetail + "','"
                    + cipsopinion + "','"
                    + dcvgdetail + "','"
                    + dcvgopinion + "','"
                    + ptsdetail + "','"
                    + ptsopinion + "','"
                    + rovdetail + "','"
                    + rovopinion +

                    "'); select @@IDENTITY as id; ";

            objConn.ConnectionString = ConfigurationManager.ConnectionStrings["dbptt_repConnectionString"].ConnectionString;

            var _with1 = objCmd;
            _with1.Connection = objConn;
            _with1.CommandText = strSQL;
            _with1.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;

            dtAdapter.Fill(ds);
            dt = ds.Tables[0];

            dtAdapter = null;
            objConn.Close();
            objConn = null;

            return dt;
        }

        public void UpdatetpCP(string tp_rep_id, string cipsdetail, string cipsopinion, string dcvgdetail, string dcvgopinion, string ptsdetail, string ptsopinion, string rovdetail, string rovopinion, string id, string update_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " update tpcp set cipsdetail = '" + cipsdetail +

                "',cipsopinion = '" + cipsopinion +
                "',dcvgdetail = '" + dcvgdetail +
                "',dcvgopinion = '" + dcvgopinion +

                                "',ptsdetail = '" + ptsdetail +
                "',ptsopinion = '" + ptsopinion +
                "',rovdetail = '" + rovdetail +

                                "',rovopinion = '" + rovopinion +

                "' " +
                " where tp_rep_id = '" + tp_rep_id + "' and id = '" + id + "'; ";

            objConn.ConnectionString = ConfigurationManager.ConnectionStrings["dbptt_repConnectionString"].ConnectionString;
            objConn.Open();
            var _with1 = objCmd;
            _with1.Connection = objConn;
            _with1.CommandText = strSQL;
            _with1.CommandType = CommandType.Text;

            objCmd.ExecuteNonQuery();

            dtAdapter = null;
            objConn.Close();
            objConn = null;

        }


    }
}