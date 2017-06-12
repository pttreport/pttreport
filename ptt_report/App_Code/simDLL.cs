using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ptt_report.App_Code
{
    public class simDLL
    {
        public DataTable GetExistRep0(string master_rep_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " select * from tblExecutive_summary where quarter_rep_id = '"
                + master_rep_id + "' ";

            objConn.ConnectionString = ConfigurationManager
                .ConnectionStrings["dbptt_repConnectionString"].ConnectionString;

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

        public DataTable GetExistRep(string master_rep_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " select * from tblsim where quarter_rep_id = '"
                + master_rep_id + "' ";

            objConn.ConnectionString = ConfigurationManager
                .ConnectionStrings["dbptt_repConnectionString"].ConnectionString;

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


        public DataTable GetRep_HisALL()
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " select top(1) * from tbl_history_rep where rep_type ='1' order by version desc  ; ";

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

        public DataTable Inserttblsim(string quarter_rep_id, string aplanwork, string aprogressresult, string afutureplan, string aproblem, string aopinion, string mplanwork, string mprogressresult, string mfutureplan, string mproblem, string mopinion)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " insert into tblsim(quarter_rep_id,aplanwork,aprogressresult,afutureplan,aproblem,aopinion,mplanwork,mprogressresult,mfutureplan,mproblem,mopinion) " +
                    " values('" +

                    quarter_rep_id + "','"
                    + aplanwork + "','"
                    + aprogressresult + "','"
                    + afutureplan + "','"
                    + aproblem + "','"
                    + aopinion + "','"
                    + mplanwork + "','"
                    + mprogressresult + "','"
                    + mfutureplan + "','"
                    + mproblem + "','"
                    + mopinion +

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


        public void Updatetblsim_check(string quarter_rep_id, string aplanwork, string aprogressresult, string afutureplan, string aproblem, string aopinion, string id, string update_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            string strSQL = null;

            strSQL = " update tblsim set " +
                "aplanwork = '" + aplanwork +
                "',aprogressresult = '" + aprogressresult +
                "',afutureplan = '" + afutureplan +
                "',aproblem = '" + aproblem +
                "',aopinion = '" + aopinion +
                "' " +
                " where quarter_rep_id = '" + quarter_rep_id + "' and id = '" + id + "'; " +

                    " update tblquarter_rep set status = 'In Process', pm_cm_status = 'In Process',update_date = getdate(),update_id = '"
                    + update_id +
                    "' where id = '" + quarter_rep_id + "';  ";

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

        public void Updatetblsim_repair(string quarter_rep_id, string mplanwork, string mprogressresult, string mfutureplan, string mproblem, string mopinion, string id, string update_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            string strSQL = null;

            strSQL = " update tblsim set " +
                "mplanwork = '" + mplanwork +
                "',mprogressresult = '" + mprogressresult +
                "',mfutureplan = '" + mfutureplan +
                "',mproblem = '" + mproblem +
                "',mopinion = '" + mopinion +
                "' " +
                " where quarter_rep_id = '" + quarter_rep_id + "' and id = '" + id + "'; " +

                    " update tblquarter_rep set status = 'In Process', pm_cm_status = 'In Process',update_date = getdate(),update_id = '"
                    + update_id +
                    "' where id = '" + quarter_rep_id + "';  ";

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