using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ptt_report.App_Code
{
    public class ilipigDLL
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

            strSQL = " select * from tblili_pig where quarter_rep_id = '"
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

        public DataTable Inserttblili_pig(string quarter_rep_id, string pwroutecode, string pwdimeter, string pwpipelinesection, string pwnumberpig, string pwplaning, string wroutecode, string wpipelinesection, string wresult, string froutecode, string fdimeter, string fpipelinesection, string fnumberpig, string fplaning, string problem, string opinion)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " insert into tblili_pig(quarter_rep_id,pwroutecode,pwdimeter,pwpipelinesection,pwnumberpig,pwplaning,wroutecode,wpipelinesection,wresult,froutecode,fdimeter, fpipelinesection,fnumberpig,fplaning,problem,opinion) " +
                    " values('" +

                    quarter_rep_id + "','"
                    + pwroutecode + "','"
                    + pwdimeter + "','"
                    + pwpipelinesection + "','"
                    + pwnumberpig + "','"
                    + pwplaning + "','"
                    + wroutecode + "','"
                    + wpipelinesection + "','"
                    + wresult + "','"
                    + froutecode + "','"
                    + fdimeter + "','"
                    + fpipelinesection + "','"
                    + fnumberpig + "','"
                    + fplaning + "','"
                    + problem + "','"
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


        public void Updatetblili_pig(string quarter_rep_id,  string pwroutecode, string pwdimeter, string pwpipelinesection, string pwnumberpig, string pwplaning, string wroutecode, string wpipelinesection, string wresult, string froutecode, string fdimeter, string fpipelinesection, string fnumberpig, string fplaning, string problem, string opinion, string id, string update_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            string strSQL = null;

            strSQL = " update tblili_pig set "+
                "pwroutecode = '" + pwroutecode +
                "',pwdimeter = '" + pwdimeter +
                "',pwpipelinesection = '" + pwpipelinesection +
                "',pwnumberpig = '" + pwnumberpig +
                "',pwplaning = '" + pwplaning +
                "',wroutecode = '" + wroutecode +
                "',wpipelinesection = '" + wpipelinesection +
                "',wresult = '" + wresult +
                "',froutecode = '" + froutecode +
                "',fdimeter = '" + fdimeter +
                "',fpipelinesection = '" + fpipelinesection +
                "',fnumberpig = '" + fnumberpig +
                "',fplaning = '" + fplaning +
                "',problem = '" + problem +
                "',opinion = '" + opinion +

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