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
using Microsoft.Office.Interop.Word;

namespace ptt_report
{
    public partial class permitappendixB : System.Web.UI.Page
    {
        CultureInfo ThCI = new System.Globalization.CultureInfo("th-TH");
        CultureInfo EngCI = new System.Globalization.CultureInfo("en-US");
        QuarterlyReportDLL QServ = new QuarterlyReportDLL();
        tpreportDLL Serv = new tpreportDLL();

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
                    //lbCustype.Text = HttpContext.Current.Session["repCustype"].ToString();
                    hddmas_rep_id.Value = HttpContext.Current.Session["repid"].ToString();
                    bind_default();
                    bind_list();
                }
            }
        }

        protected void bind_default()
        {
            var apdb = Serv.GetTPAppendixB(hddmas_rep_id.Value);

            if (apdb.Rows.Count != 0)
            {
                hddapdb_id.Value = apdb.Rows[0]["id"].ToString();
                ApdbOpinion.Text = apdb.Rows[0]["opinion"].ToString();

                var sub = Serv.GetTPAppendixB_sub(hddapdb_id.Value);

                if (sub.Rows.Count != 0)
                {
                    gv.DataSource = sub;
                    gv.DataBind();
                }
                else
                {
                    gv.DataSource = null;
                    gv.DataBind();
                }


            }
            else
            {

                Serv.InsertTPAppendixB(hddmas_rep_id.Value, "");
                var apdbNew = Serv.GetTPAppendixB(hddmas_rep_id.Value);

                if (apdbNew.Rows.Count != 0)
                {
                    hddapdb_id.Value = apdbNew.Rows[0]["id"].ToString();

                    Serv.InsertTPAppendixB_sub(hddapdb_id.Value, "", "", "", "", "", "", "", "");

                    var subNew = Serv.GetTPAppendixB_sub(hddapdb_id.Value);

                    if (subNew.Rows.Count != 0)
                    {
                        gv.DataSource = subNew;
                        gv.DataBind();
                    }
                    else
                    {
                        gv.DataSource = null;
                        gv.DataBind();
                    }

                }

            }
        }

        protected void bind_list()
        {

        }

        protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind_list();
        }

        protected void ddlquarter_SelectedIndexChanged(object sender, EventArgs e)
        {

            bind_list();
        }

        protected void ddlcustype_SelectedIndexChanged(object sender, EventArgs e)
        {

            bind_list();
        }

        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

            bind_list();
        }

        protected void GridView_rep_list_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.bind_list();
        }

        protected void btncreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/create_quar_rep.aspx");
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            HiddenField hddrepid = (HiddenField)row.FindControl("hddrepid");

            Serv.delete_tblquarter_rep(hddrepid.Value);

            bind_list();

        }

        protected void btnmanage_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            HiddenField hddrepid = (HiddenField)row.FindControl("hddrepid");
            HiddenField hddyear = (HiddenField)row.FindControl("hddyear");
            HiddenField hddquarter = (HiddenField)row.FindControl("hddquarter");
            HiddenField hddcustype = (HiddenField)row.FindControl("hddcustype");

            HttpContext.Current.Session["repid"] = hddrepid.Value;
            HttpContext.Current.Session["repYear"] = hddyear.Value ;
            HttpContext.Current.Session["repQuar"] = hddquarter.Value;
            HttpContext.Current.Session["repCustype"] = hddcustype.Value;

            Response.Redirect("~/Execut_sum.aspx");
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {

        }

        protected void PermitFormSaveSubmit_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gv.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField hddid = (HiddenField)row.FindControl("hddid");

                    TextBox subroutecode = (TextBox)row.FindControl("subroutecode");

                    TextBox subbuildingwork = (TextBox)row.FindControl("subbuildingwork");

                    TextBox subscour = (TextBox)row.FindControl("subscour");

                    TextBox sublabel = (TextBox)row.FindControl("sublabel");

                    TextBox subtestpost = (TextBox)row.FindControl("subtestpost");

                    TextBox subtrespass = (TextBox)row.FindControl("subtrespass");

                    TextBox subgasleak = (TextBox)row.FindControl("subgasleak");

                    TextBox subabnormal = (TextBox)row.FindControl("subabnormal");

                    Serv.UpdateTPAppendixB_sub(hddapdb_id.Value, subroutecode.Text, subbuildingwork.Text, subscour.Text, sublabel.Text, subtestpost.Text, subtrespass.Text, subgasleak.Text, subabnormal.Text, hddid.Value);


                }
            }

            Serv.UpdateTPAppendixB(hddmas_rep_id.Value, ApdbOpinion.Text, hddapdb_id.Value, HttpContext.Current.Session["assetuserid"].ToString());

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Serv.InsertTPAppendixB_sub(hddapdb_id.Value, "", "", "", "", "", "", "", "");

            var sub = Serv.GetTPAppendixB_sub(hddapdb_id.Value);
            if (sub.Rows.Count != 0)
            {
                gv.DataSource = sub;
                gv.DataBind();
            }
            else
            {
                gv.DataSource = null;
                gv.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/history_2.aspx?param=2&tprepid=" + hddmas_rep_id.Value);
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            var historyObj = Serv.GetHistoryLinkById(hddmas_rep_id.Value);

            if (historyObj.Rows.Count != 0)
            {
                Response.Redirect(historyObj.Rows[0]["uri"].ToString());
            }
        }

        protected void btnSaveVer_Click(object sender, EventArgs e)
        {
            var app = new Application();
            try
            {
                var rep_tmp = Serv.GetTempRep();
                if (rep_tmp.Rows.Count != 0)
                {
                    //This code creates a document based on the specified template.
                    var doc = app.Documents.Add(Server.MapPath(rep_tmp.Rows[0]["file_path"].ToString()), Visible: false);
                    doc.Activate();

                    var sel = app.Selection;

                    #region A
                    var permit = Serv.GetTPPermit(hddmas_rep_id.Value);
                    if (permit.Rows.Count != 0)
                    {
                        sel.Find.Text = "[a1]";
                        sel.Find.Replacement.Text = permit.Rows[0]["gaspipemaintain"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[a2]";
                        sel.Find.Replacement.Text = permit.Rows[0]["projectname"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[a3]";
                        sel.Find.Replacement.Text = permit.Rows[0]["pipepath"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[a4]";
                        sel.Find.Replacement.Text = permit.Rows[0]["cerfno"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);
                    }
                    #endregion

                    #region B
                    var es = Serv.GetTPExecutiveSummary(hddmas_rep_id.Value);
                    if (es.Rows.Count != 0)
                    {
                        sel.Find.Text = "[b1]";
                        sel.Find.Replacement.Text = es.Rows[0]["detail"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);
                    }
                    #endregion

                    #region c
                    var patrolling = Serv.GetTPPatrolling(hddmas_rep_id.Value);

                    if (patrolling.Rows.Count != 0)
                    {

                        sel.Find.Text = "[c1]";
                        sel.Find.Replacement.Text = patrolling.Rows[0]["gasdetector"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);


                        sel.Find.Text = "[c2]";
                        sel.Find.Replacement.Text = patrolling.Rows[0]["gassiteamount"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[c3]";
                        sel.Find.Replacement.Text = patrolling.Rows[0]["gassitedetail"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[c4]";
                        sel.Find.Replacement.Text = patrolling.Rows[0]["labelandstealamount"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);


                        sel.Find.Text = "[c5]";
                        sel.Find.Replacement.Text = patrolling.Rows[0]["labelandstealdetail"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);


                        sel.Find.Text = "[c6]";
                        sel.Find.Replacement.Text = patrolling.Rows[0]["testpostdamageamount"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[c7]";
                        sel.Find.Replacement.Text = patrolling.Rows[0]["testpostdamagedetail"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);


                        sel.Find.Text = "[c8]";
                        sel.Find.Replacement.Text = patrolling.Rows[0]["scourareaamount"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);


                        sel.Find.Text = "[c9]";
                        sel.Find.Replacement.Text = patrolling.Rows[0]["scourareadetail"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);


                        sel.Find.Text = "[c10]";
                        sel.Find.Replacement.Text = patrolling.Rows[0]["buildingpipepathamount"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);


                        sel.Find.Text = "[c11]";
                        sel.Find.Replacement.Text = patrolling.Rows[0]["buildingpipepathdetail"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);


                        sel.Find.Text = "[c12]";
                        sel.Find.Replacement.Text = patrolling.Rows[0]["rovfreespanamount"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[c13]";
                        sel.Find.Replacement.Text = patrolling.Rows[0]["rovfreespandetail"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);


                    }
                    #endregion



                    string time = DateTime.Now.ToString("yyyy-MM-ddHHmmss", EngCI);

                    //************************************************

                    doc.SaveAs(Server.MapPath("~/gen_1/TP_report_" + time + ".docx"));
                    doc.Close();

                    var x = Serv.InsertHistory(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", EngCI), HttpContext.Current.Session["assetusername"].ToString(), "TP_report",
                        "~/gen_1/TP_report_" + time + ".docx", "2", "", hddmas_rep_id.Value);

                    hddfile_path.Value = "~/gen_1/TP_report_" + time + ".docx";

                    if (x.Rows.Count != 0)
                    {
                        Serv.UpdateHistory(x.Rows[0]["id"].ToString(), "TP_report_V" + x.Rows[0]["id"].ToString(), x.Rows[0]["id"].ToString());
                    }

                    POPUPMSG("บันทึกเรียบร้อย");
                }

            }
            finally
            {
                app.Quit();
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

    }
}