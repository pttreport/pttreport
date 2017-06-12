﻿using ptt_report.App_Code;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;

namespace ptt_report
{
    public partial class rbi : System.Web.UI.Page
    {
        CultureInfo ThCI = new System.Globalization.CultureInfo("th-TH");
        CultureInfo EngCI = new System.Globalization.CultureInfo("en-US");
        rbiDLL Serv = new rbiDLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Object objUserTheme = HttpContext.Current.Session["assetuserid"];
                if (objUserTheme == null)
                {
                    Response.Redirect("~/default.aspx");
                }
                else
                {
                    lbCustype.Text = HttpContext.Current.Session["repCustype"].ToString();

                    hddmas_rep_id.Value = HttpContext.Current.Session["repid"].ToString();

                    bind_default();
                }
            }
        }

        protected void bind_default()
        {
            var rep_doc = Serv.GetRep_HisALL();
            if (rep_doc.Rows.Count != 0)
            {
                hddfile_path.Value = rep_doc.Rows[0]["uri"].ToString();
            }

            var exist = Serv.GetExistRep(hddmas_rep_id.Value);

            if (exist.Rows.Count != 0)
            {
                hddrbi_id.Value = exist.Rows[0]["id"].ToString();
                txtplanwork.Text = exist.Rows[0]["cplanwork"].ToString();
                txtplanresult.Text = exist.Rows[0]["cprogressresult"].ToString();
                txtfuturePlan.Text = exist.Rows[0]["cfutureplan"].ToString();
                txtproblem.Text = exist.Rows[0]["cproblem"].ToString();
                txtRemark.Text = exist.Rows[0]["copinion"].ToString();
                txtplanwork2.Text = exist.Rows[0]["mplanwork"].ToString();
                txtplanresult2.Text = exist.Rows[0]["mprogressresult"].ToString();
                txtfuturePlan2.Text = exist.Rows[0]["mfutureplan"].ToString();
                txtproblem2.Text = exist.Rows[0]["mproblem"].ToString();
                txtRemark2.Text = exist.Rows[0]["mopinion"].ToString();

            }
            else
            {
                Serv.Inserttblrbi(hddmas_rep_id.Value, "", "","","","","","","","","");
            }

        }

        private void POPUPMSG(string msg)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("alert(\'");
            sb.Append(msg.Replace("\n", "\\n").Replace("\r", "").Replace("\'", "\\\'"));
            sb.Append("\');");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showalert", sb.ToString(), true);
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            Serv.Updatetblrbi_check(hddmas_rep_id.Value, txtplanwork.Text, txtplanresult.Text, txtfuturePlan.Text, txtproblem.Text, txtRemark.Text, hddrbi_id.Value, HttpContext.Current.Session["assetuserid"].ToString());
            POPUPMSG("บันทึกเรียบร้อย");
        }

        protected void btnsave2_Click(object sender, EventArgs e)
        {
            Serv.Updatetblrbi_repair(hddmas_rep_id.Value, txtplanwork2.Text, txtplanresult2.Text, txtfuturePlan2.Text, txtproblem2.Text, txtRemark2.Text, hddrbi_id.Value, HttpContext.Current.Session["assetuserid"].ToString());
            POPUPMSG("บันทึกเรียบร้อย");
        }
    }
}