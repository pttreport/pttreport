﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ptt_report.App_Code
{
    public class pironspDLL
    {

        public DataTable GetExistRep(string master_rep_id)
        {
            return null;
        }

        public DataTable GetPIROffSPPipeline(string pir_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " select * from pironsp_pipeline where pir_id =  '" + pir_id + "' ";

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

        public DataTable Insertpiroffsp_pipeline(string pir_id, string startupyear, string designpresure, string station, string maop, string length, string wallthickness, string materialspec, string designlife, string externalcoating, string cathodicprotection, string op, string ot, string gfr, string lastilipig, string crusedforrem, string proboffailure, string assessmentdate, string overallremainlife, string remainlife, string overalldesignlife, string inspectionyear, string b31gpsi, string burstpressure, string erf, string opinion)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " insert into piroffsp_pipeline(pir_id,startupyear,designpresure,station,maop,length,wallthickness, materialspec, designlife,externalcoating,cathodicprotection,op,ot,gfr,lastilipig,crusedforrem,     proboffailure, assessmentdate,overallremainlife,remainlife,overalldesignlife,inspectionyear,b31gpsi,burstpressure,erf,opinion) " +
                    " values('" +

                    pir_id + "','"
                    + startupyear + "','"
                    + designpresure + "','"
                    + station + "','"
                    + maop + "','"
                    + length + "','"
                    + wallthickness + "','"
                    + materialspec + "','"
                    + designlife + "','"
                    + externalcoating + "','"
                    + cathodicprotection + "','"
                    + op + "','"
                    + ot + "','"
                    + gfr + "','"
                    + lastilipig + "','"
                    + crusedforrem + "','"
                    + proboffailure + "','"
                    + materialspec + "','"
                    + assessmentdate + "','"
                    + overallremainlife + "','"
                    + remainlife + "','"
                    + overalldesignlife + "','"
                    + inspectionyear + "','"
                    + b31gpsi + "','"
                    + burstpressure + "','"
                    + erf + "','"
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

        public void Updatepiroffsp_pipeline(string pir_id, string startupyear, string designpresure, string station, string maop, string length, string wallthickness, string materialspec, string designlife, string externalcoating, string cathodicprotection, string op, string ot, string gfr, string lastilipig, string crusedforrem, string proboffailure, string assessmentdate, string overallremainlife, string remainlife, string overalldesignlife, string inspectionyear, string b31gpsi, string burstpressure, string erf, string opinion, string id, string update_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " update piroffsp_pipeline set startupyear = '" + startupyear +
                "',designpresure = '" + designpresure +
                "',station = '" + station +
                "',maop = '" + maop +
                "',length = '" + length +
                "',wallthickness = '" + wallthickness +
                "',materialspec = '" + materialspec +
                "',designlife = '" + designlife +
                "',externalcoating = '" + externalcoating +
                "',cathodicprotection = '" + cathodicprotection +
                "',op = '" + op +
                "',ot = '" + ot +
                "',gfr = '" + gfr +


                "',lastilipig = '" + lastilipig +
                "',crusedforrem = '" + crusedforrem +
                "',proboffailure = '" + proboffailure +
                "',assessmentdate = '" + assessmentdate +
                "',overallremainlife = '" + overallremainlife +
                "',remainlife = '" + remainlife +
                "',overalldesignlife = '" + overalldesignlife +
                "',inspectionyear = '" + inspectionyear +
                "',b31gpsi = '" + b31gpsi +
                "',burstpressure = '" + burstpressure +
                "',erf = '" + erf +



                "',opinion = '" + opinion +
                "' " +
                " where pir_id = '" + pir_id + "' and id = '" + id + "'; ";

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

        public DataTable GetPIROnSUInternelCorrosionControlSystem(string pir_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " select * from piroff_iccs where pir_id =  '" + pir_id + "' ";

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

        public DataTable Insertpiroffsp_iccs(string pir_id, string ci, string cicomment, string cc, string cccomment, string cp, string cpcomment, string opinion)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " insert into piroffsp_iccs(pir_id,ci,cicomment,cc,cccomment,cp,cpcomment, opinion) " +
                    " values('" +

                    pir_id + "','"
                    + ci + "','"
                    + cicomment + "','"
                    + cc + "','"
                    + cccomment + "','"
                    + cp + "','"
                    + cpcomment + "','"
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


        public void Updatepiroffsp_iccs(string pir_id, string ci, string cicomment, string cc, string cccomment, string cp, string cpcomment, string opinion, string id, string update_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " update piroffsp_iccs set ci = '" + ci +
                "',cicomment = '" + cicomment +
                "',cc = '" + cc +
                "',cccomment = '" + cccomment +
                "',cp = '" + cp +
                "',cpcomment = '" + cpcomment +
                "',opinion = '" + opinion +
                "' " +
                " where pir_id = '" + pir_id + "' and id = '" + id + "'; ";

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


        public DataTable GetPIROffSPLastestMaintainanceActivity(string pir_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " select * from piroffsp_lma where pir_id =  '" + pir_id + "' ";

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


        public DataTable Insertpiroffsp_lma(string pir_id, string yearofcips, string yearofmfl, string yearofgeo, string opinion)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " insert into piroffsp_lma(pir_id,yearofcips,yearofmfl,yearofgeo,opinion) " +
                    " values('" +

                    pir_id + "','"
                    + yearofcips + "','"
                    + yearofmfl + "','"
                    + yearofgeo + "','"
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



        public void Updatepiroffsp_lma(string pir_id, string yearofcips, string yearofmfl, string yearofgeo, string opinion, string id, string update_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            string strSQL = null;

            strSQL = " update piroffsp_lma set yearofcips = '" + yearofcips +
                "',yearofmfl = '" + yearofmfl +
                "',yearofgeo = '" + yearofgeo +
                "',opinion = '" + opinion +
                "' " +
                " where pir_id = '" + pir_id + "' and id = '" + id + "'; ";

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



        public DataTable GetPIROffSP_ecra(string pir_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " select * from piroffsp_ecra where pir_id =  '" + pir_id + "' ";

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


        public DataTable Insertpiroffsp_ecra(string pir_id, string summaryresult, string cp, string ecdmp, string ecrp, string detail, string mflpresult, string opinion)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " insert into piroffsp_ecra(pir_id,summaryresult,cp,ecdmp,ecrp, detail,mflpresult,opinion) " +
                    " values('" +

                    pir_id + "','"
                    + summaryresult + "','"
                    + cp + "','"
                    + ecdmp + "','"
                    + ecrp + "','"
                    + detail + "','"
                    + mflpresult + "','"
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


        public void Updatepiroffsp_ecra(string pir_id, string summaryresult, string cp, string ecdmp, string ecrp, string detail, string mflpresult, string opinion, string id, string update_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " update piroffsp_ecra set summaryresult = '" + summaryresult +
                "',cp = '" + cp +
                "',ecdmp = '" + ecdmp +
                "',ecrp = '" + ecrp +
                "',detail = '" + detail +
                "',mflpresult = '" + mflpresult +
                "',opinion = '" + opinion +
                "' " +
                " where pir_id = '" + pir_id + "' and id = '" + id + "'; ";

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

        public DataTable GetPIROffSP_icra(string pir_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " select * from piroffsp_icra where pir_id =  '" + pir_id + "' ";

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


        public DataTable Insertpiroffsp_icra(string pir_id, string sumresult, string wcm, string icmp, string icrp, string detail, string opinion)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " insert into piroffsp_icra(pir_id,sumresult,wcm,icmp, icrp,detail,opinion) " +
                    " values('" +

                    pir_id + "','"
                    + sumresult + "','"
                    + wcm + "','"
                    + icmp + "','"
                    + icrp + "','"
                    + detail + "','"
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

        public void Updatepiroffsp_icra(string pir_id, string sumresult, string wcm, string icmp, string icrp, string detail, string opinion, string id, string update_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " update piroffsp_icra set sumresult = '" + sumresult +
                "',wcm = '" + wcm +
                "',icmp = '" + icmp +
                "',icrp = '" + opinion +
                "',detail = '" + detail +
                "',opinion = '" + opinion +
                "' " +
                " where pir_id = '" + pir_id + "' and id = '" + id + "'; ";

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


        public DataTable GetPIROffSPMechanical(string pir_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " select * from piroffsp_md where pir_id =  '" + pir_id + "' ";

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


        public DataTable Insertpironsu_md(string pir_id, string summaryresult, string ccd, string dent, string detail, string manualdetail, string opinion)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " insert into piroffsp_md(pir_id,summaryresult,ccd,activitylevel,detail, opinion) " +
                    " values('" +

                    pir_id + "','"
                    + summaryresult + "','"
                    + ccd + "','"
                    + dent + "','"
                    + detail + "','"
                    + manualdetail + "','"
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


        public void Updatepiroffsp_md(string pir_id, string summaryresult, string ccd, string dent, string detail, string manualdetail, string opinion, string id, string update_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " update piroffsp_md set summaryresult = '" + summaryresult +
                "',ccd = '" + ccd +
                "',dent = '" + dent +
                "',detail = '" + detail +
                "',manualdetail = '" + manualdetail +
                "',opinion = '" + opinion +
                "' " +
                " where pir_id = '" + pir_id + "' and id = '" + id + "'; ";

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



        public DataTable GetPIROffSP_fsra(string pir_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " select * from piroffsp_fsra where pir_id =  '" + pir_id + "' ";

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


        public DataTable Insertpiroffsp_fsra(string pir_id, string sumresult, string detail, string opinion)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " insert into piroffsp_fsra(pir_id,sumresult,eps,detail, opinion) " +
                                 " values('" +

                                 pir_id + "','"
                                 + sumresult + "','"
                                 + detail + "','"
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


        public void Updatepiroffsp_fsra(string pir_id, string sumresult, string detail, string opinion, string id, string update_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " update piroffsp_fsra set sumresult = '" + sumresult +
                             "',detail = '" + detail +
                             "',opinion = '" + opinion +
                             "' " +
                             " where pir_id = '" + pir_id + "' and id = '" + id + "'; ";

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


        public DataTable GetPIROffLeakage(string pir_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " select * from piroffsp_leakage where pir_id =  '" + pir_id + "' ";

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


        public DataTable Insertpiroffsp_leakage(string pir_id, string sumresult, string lsp, string lplem, string llr, string detail, string opinion)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " insert into piroffsp_leakage(pir_id,sumresult, lsp, lplem, llr,detail, opinion) " +
                                 " values('" +

                                 pir_id + "','"
                                 + sumresult + "','"
                                 +lsp + "','"
                                 +lplem + "','"
                                 +llr + "','"
                                 + detail + "','"
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


        public void Updatepiroffsp_leakage(string pir_id, string sumresult, string lsp, string lplem, string llr, string detail, string opinion, string id, string update_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " update pironsu_prh set sumresult = '" + sumresult +
                        "',lsp = '" + lsp +
                        "',lplem = '" + lplem +
                        "',llr = '" + llr +
                        "',detail = '" + detail +
                        "',opinion = '" + opinion +
                        "' " +
                            " where pir_id = '" + pir_id + "' and id = '" + id + "'; ";

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


        public DataTable GetPIROffprh(string pir_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " select * from piroffsp_prh where pir_id =  '" + pir_id + "' ";

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


        public DataTable Insertpiroffsp_prh(string pir_id, string sumresult,string detail, string opinion)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " insert into piroffsp_prh(pir_id,sumresult,detail, opinion) " +
                                 " values('" +

                                 pir_id + "','"
                                 + sumresult + "','"
                                 + detail + "','"
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


        public void Updatepiroffsp_prh(string pir_id, string sumresult, string detail, string opinion, string id, string update_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " update piroffsp_prh set sumresult = '" + sumresult +
                        "',detail = '" + detail +
                        "',opinion = '" + opinion +
                        "' " +
                            " where pir_id = '" + pir_id + "' and id = '" + id + "'; ";

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

        public DataTable GetPIROffSPRecommedation(string pir_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " select * from piroffsp_comment where pir_id =  '" + pir_id + "' ";

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


        public DataTable Insertpiroffsp_comment(string pir_id, string detail, string opinion)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " insert into piroffsp_comment(pir_id,detail, opinion) " +
                    " values('" +

                    pir_id + "','"
                    + detail + "','"
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


        public void Updatepiroffsp_comment(string pir_id, string detail, string opinion, string id, string update_id)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " update piroffsp_comment set detail = '" + detail +
                "',opinion = '" + opinion +
                "' " +
                " where pir_id = '" + pir_id + "' and id = '" + id + "'; ";

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