﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ptt_report.App_Code
{
    public class t_p_repDLL
    {
        public DataTable GetRep_year()
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " select distinct(year) from tblt_p_rep order by year desc ; ";

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

        public DataTable GetRep_permit()
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " select distinct(permit) from tblt_p_rep order by permit desc ; ";

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

        public DataTable GetRep_list(string year, string permit)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strSQL = null;

            strSQL = " select * from tblt_p_rep where permit like '%" + permit + "%' ";

            if (year != "")
            {
                strSQL += " and year = '" + year + "' ";
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



    }
}