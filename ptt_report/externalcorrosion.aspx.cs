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
    public partial class externalcorrosion : System.Web.UI.Page
    {
        CultureInfo ThCI = new System.Globalization.CultureInfo("th-TH");
        CultureInfo EngCI = new System.Globalization.CultureInfo("en-US");
        externalcorrosionDLL Serv = new externalcorrosionDLL();

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
                hddec_id.Value = exist.Rows[0]["id"].ToString();
                ECResultBox.Text = exist.Rows[0]["workresult"].ToString();
                ECPSPercent.Text = exist.Rows[0]["pspotentialsurvey"].ToString();
                ECBBIPercent.Text = exist.Rows[0]["bondboxinspection"].ToString();
                ECRIPercent.Text = exist.Rows[0]["rectifierispection"].ToString();
                ECIJPercent.Text = exist.Rows[0]["insulatingjoint"].ToString();
                //ECResultBox.Text = exist.Rows[0]["d1"].ToString();
                //ECResultBox.Text = exist.Rows[0]["d1"].ToString();
                //ECResultBox.Text = exist.Rows[0]["d1"].ToString();
                //ECResultBox.Text = exist.Rows[0]["d1"].ToString();
                ECFuturePlanBox.Text = exist.Rows[0]["planworkfuture"].ToString();
                ECProblemBox.Text = exist.Rows[0]["problem"].ToString();
                ECFormFeedbackBox.Text = exist.Rows[0]["opinion"].ToString();

                var subCathodic = Serv.GetExistRep_sub_cathodicresult(hddec_id.Value);

                if (subCathodic.Rows.Count != 0)
                {
                    gvCathodic.DataSource = subCathodic;
                    gvCathodic.DataBind();
                }
                else
                {
                    gvCathodic.DataSource = null;
                    gvCathodic.DataBind();
                }

                var subCIPSStatus = Serv.GetExistRep_sub_cipsstatus(hddec_id.Value);

                if (subCIPSStatus.Rows.Count != 0)
                {
                    gvCIPSStatus.DataSource = subCIPSStatus;
                    gvCIPSStatus.DataBind();
                }
                else
                {
                    gvCIPSStatus.DataSource = null;
                    gvCIPSStatus.DataBind();
                }

                var subCIPSStatusActivity = Serv.GetExistRep_sub_cipsstatus_activity(hddec_id.Value);

                if (subCIPSStatusActivity.Rows.Count != 0)
                {
                    gvCIPSStatusActivity.DataSource = subCIPSStatusActivity;
                    gvCIPSStatusActivity.DataBind();
                }
                else
                {
                    gvCIPSStatusActivity.DataSource = null;
                    gvCIPSStatusActivity.DataBind();
                }
            }
            else
            {
                var ec = Serv.Inserttblexternal_corrosion(hddmas_rep_id.Value, "", "", "", "", "", "", "", "", "", "", "", "");

                if (ec.Rows.Count != 0)
                {
                    hddec_id.Value = ec.Rows[0]["id"].ToString();

                    Serv.Inserttblexternalcorrosion_sub_cathodicresult(hddec_id.Value, "", "", "", "");

                    var subCathodic = Serv.GetExistRep_sub_cathodicresult(hddec_id.Value);

                    if (subCathodic.Rows.Count != 0)
                    {
                        gvCathodic.DataSource = subCathodic;
                        gvCathodic.DataBind();
                    }
                    else
                    {
                        gvCathodic.DataSource = null;
                        gvCathodic.DataBind();
                    }

                    Serv.Inserttblexternalcorrosion_sub_cipsstatus(hddec_id.Value, "", "", "");

                    var subCIPSStatus = Serv.GetExistRep_sub_cipsstatus(hddec_id.Value);

                    if (subCIPSStatus.Rows.Count != 0)
                    {
                        gvCIPSStatus.DataSource = subCIPSStatus;
                        gvCIPSStatus.DataBind();
                    }
                    else
                    {
                        gvCIPSStatus.DataSource = null;
                        gvCIPSStatus.DataBind();
                    }

                    Serv.Inserttblexternalcorrosion_sub_cipsstatus_activity(hddec_id.Value, "", "", "", "");

                    var subCIPSStatusActivity = Serv.GetExistRep_sub_cipsstatus_activity(hddec_id.Value);

                    if (subCIPSStatusActivity.Rows.Count != 0)
                    {
                        gvCIPSStatusActivity.DataSource = subCIPSStatusActivity;
                        gvCIPSStatusActivity.DataBind();
                    }
                    else
                    {
                        gvCIPSStatusActivity.DataSource = null;
                        gvCIPSStatusActivity.DataBind();
                    }
                }
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



        protected void ECFormSaveSubmit_Click(object sender, EventArgs e)
        {
            if (ECECRFileUpload.HasFile)
            {
                try
                {
                    string[] segments = ECECRFileUpload.FileName.Split('.');
                    string fileExt = segments[segments.Length - 1];

                    string filename = "ex_coro_ECECR" + DateTime.Now.ToString("yyMMddHHssss");
                    ECECRFileUpload.SaveAs(Server.MapPath("~/img_rep/") + filename + "." + fileExt);

                    Serv.Update_File1(Server.MapPath("~/img_rep/") + filename, "~/img_rep/" + filename + "." + fileExt, hddec_id.Value);
                }
                catch (Exception ex)
                {
                    POPUPMSG("Upload status: The file could not be uploaded. The following error occured: " + ex.Message);
                    return;
                }

            }

            if (CCDRFileUpload.HasFile)
            {
                try
                {
                    string[] segments = CCDRFileUpload.FileName.Split('.');
                    string fileExt = segments[segments.Length - 1];

                    string filename = "ex_coro_CCDRF" + DateTime.Now.ToString("yyMMddHHssss");
                    CCDRFileUpload.SaveAs(Server.MapPath("~/img_rep/") + filename + "." + fileExt);

                    Serv.Update_File2(Server.MapPath("~/img_rep/") + filename, "~/img_rep/" + filename + "." + fileExt, hddec_id.Value);
                }
                catch (Exception ex)
                {
                    POPUPMSG("Upload status: The file could not be uploaded. The following error occured: " + ex.Message);
                    return;
                }

            }

            foreach (GridViewRow row in gvCathodic.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField HddCathodicId = (HiddenField)row.FindControl("HddCathodicId");
                    TextBox gvCathodicMonth = (TextBox)row.FindControl("gvCathodicMonth");
                    TextBox gvCathodicInspectionType = (TextBox)row.FindControl("gvCathodicInspectionType");
                    TextBox gvCathodicRegion = (TextBox)row.FindControl("gvCathodicRegion");
                    TextBox gvCathodicProgress = (TextBox)row.FindControl("gvCathodicProgress");

                    Serv.Updatetblexternalcorrosion_sub_cathodicresult(hddec_id.Value, gvCathodicMonth.Text, gvCathodicInspectionType.Text, gvCathodicRegion.Text, gvCathodicProgress.Text, HddCathodicId.Value);

                }
            }

            foreach (GridViewRow row in gvCIPSStatus.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {

                    HiddenField HddCIPSStatusId = (HiddenField)row.FindControl("HddCIPSStatusId");
                    TextBox gvCIPSStatusRouteCode = (TextBox)row.FindControl("gvCIPSStatusRouteCode");
                    TextBox gvCIPSStatusPipeLineName = (TextBox)row.FindControl("gvCIPSStatusPipeLineName");
                    TextBox gvCIPSStatusStatus = (TextBox)row.FindControl("gvCIPSStatusStatus");

                    Serv.Updatetblexternalcorrosion_sub_cipsstatus(hddec_id.Value, gvCIPSStatusRouteCode.Text, gvCIPSStatusPipeLineName.Text, gvCIPSStatusStatus.Text, HddCIPSStatusId.Value);

                }
            }

            foreach (GridViewRow row in gvCIPSStatusActivity.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField HddCIPSStatusActivityId = (HiddenField)row.FindControl("HddCIPSStatusActivityId");
                    TextBox gvCIPSStatusActivityActivity = (TextBox)row.FindControl("gvCIPSStatusActivityActivity");
                    TextBox gvCIPSStatusActivityProgress = (TextBox)row.FindControl("gvCIPSStatusActivityProgress");
                    TextBox gvCIPSStatusActivityEstimatePlan = (TextBox)row.FindControl("gvCIPSStatusActivityEstimatePlan");
                    //TextBox gvCIPSStatusActivityManage = (TextBox)row.FindControl("gvCIPSStatusActivityManage");

                    Serv.Updatetblexternalcorrosion_sub_cipsstatus_activity(hddec_id.Value, gvCIPSStatusActivityActivity.Text, gvCIPSStatusActivityProgress.Text, gvCIPSStatusActivityEstimatePlan.Text,
                        "", HddCIPSStatusActivityId.Value);
                }
            }



            Serv.Updatetblexternal_corrosion(hddmas_rep_id.Value, ECResultBox.Text, ECPSPercent.Text, ECBBIPercent.Text, ECRIPercent.Text, ECIJPercent.Text, ECFuturePlanBox.Text, ECProblemBox.Text, ECFormFeedbackBox.Text, hddec_id.Value, HttpContext.Current.Session["assetuserid"].ToString());


            POPUPMSG("บันทึกเรียบร้อย");
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {

        }

        protected void ECCDSS2Create_Click(object sender, EventArgs e)
        {
            Serv.Inserttblexternalcorrosion_sub_cipsstatus_activity(hddec_id.Value, "", "", "", "");

            var subCIPSStatusActivity = Serv.GetExistRep_sub_cipsstatus_activity(hddec_id.Value);

            if (subCIPSStatusActivity.Rows.Count != 0)
            {
                gvCIPSStatusActivity.DataSource = subCIPSStatusActivity;
                gvCIPSStatusActivity.DataBind();
            }
            else
            {
                gvCIPSStatusActivity.DataSource = null;
                gvCIPSStatusActivity.DataBind();
            }
        }

        protected void ECCRCreate_Click(object sender, EventArgs e)
        {
            Serv.Inserttblexternalcorrosion_sub_cathodicresult(hddec_id.Value, "", "", "", "");

            var subCathodic = Serv.GetExistRep_sub_cathodicresult(hddec_id.Value);

            if (subCathodic.Rows.Count != 0)
            {
                gvCathodic.DataSource = subCathodic;
                gvCathodic.DataBind();
            }
            else
            {
                gvCathodic.DataSource = null;
                gvCathodic.DataBind();
            }
        }

        protected void ECCDSSCreate_Click(object sender, EventArgs e)
        {
            Serv.Inserttblexternalcorrosion_sub_cipsstatus(hddec_id.Value, "", "", "");

            var subCIPSStatus = Serv.GetExistRep_sub_cipsstatus(hddec_id.Value);

            if (subCIPSStatus.Rows.Count != 0)
            {
                gvCIPSStatus.DataSource = subCIPSStatus;
                gvCIPSStatus.DataBind();
            }
            else
            {
                gvCIPSStatus.DataSource = null;
                gvCIPSStatus.DataBind();
            }
        }


        protected void btndal1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            HiddenField hddrepid = (HiddenField)row.FindControl("HddCathodicId");


            Serv.Del_tblexternalcorrosion_sub_cathodicresult(hddrepid.Value);

            var subCathodic = Serv.GetExistRep_sub_cathodicresult(hddec_id.Value);

            if (subCathodic.Rows.Count != 0)
            {
                gvCathodic.DataSource = subCathodic;
                gvCathodic.DataBind();
            }
            else
            {
                gvCathodic.DataSource = null;
                gvCathodic.DataBind();
            }
            ////
        }

        protected void btndal2_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            HiddenField hddrepid = (HiddenField)row.FindControl("HddCIPSStatusId");

            Serv.Del_tblexternalcorrosion_sub_cipsstatus(hddrepid.Value);

            var subCIPSStatus = Serv.GetExistRep_sub_cipsstatus(hddec_id.Value);

            if (subCIPSStatus.Rows.Count != 0)
            {
                gvCIPSStatus.DataSource = subCIPSStatus;
                gvCIPSStatus.DataBind();
            }
            else
            {
                gvCIPSStatus.DataSource = null;
                gvCIPSStatus.DataBind();
            }
        }

        protected void btnApprove_Click1(object sender, EventArgs e)
        {
            Serv.UpdateStatus_rep(hddmas_rep_id.Value, HttpContext.Current.Session["assetuserid"].ToString());

        }

        protected void btnHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/history_1.aspx?param=1&quarterrepid=" + hddmas_rep_id.Value);
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (hddfile_path.Value != "")
            {
                Response.Redirect(hddfile_path.Value);
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

                    //do this for each keyword you want to replace.
                    var sel = app.Selection;
                    var rep_a = Serv.GetExistRep0(hddmas_rep_id.Value);
                    if (rep_a.Rows.Count != 0)
                    {
                        sel.Find.Text = "[qx]";
                        sel.Find.Replacement.Text = HttpContext.Current.Session["repQuar"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[yx]";
                        sel.Find.Replacement.Text = HttpContext.Current.Session["repYear"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        //=======================================================================================

                        sel.Find.Text = "[qa0]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["partolling_info1"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa1]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["partolling_info2"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa2]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["partolling_info3"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa3]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["rov_info1"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa4]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["rov_info2"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa5]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["rov_info3"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa6]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["da_info1"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa7]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["da_info2"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa8]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["da_info3"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa9]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["erosion_info1"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa10]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["erosion_info2"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa11]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["erosion_info3"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa12]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["subsite_info1"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa13]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["subsite_info2"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa14]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["subsite_info3"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa15]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["exterCorr_info1"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa16]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["exterCorr_info2"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa17]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["exterCorr_info3"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa18]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["exterCorr_info4"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa19]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["interCorr_info1"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa20]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["interCorr_info2"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa21]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["interCorr_info3"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa22]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["interCorr_info4"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa23]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["da2_info1"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa24]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["da2_info2"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa25]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["da2_info3"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa26]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["offshore_info1"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa27]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["offshore_info2"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa28]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["offshore_info3"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa29]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["offshore2_info1"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa30]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["offshore2_info2"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa31]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["offshore2_info3"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        var executive = Serv.GetExecutiveOtherRep0(rep_a.Rows[0]["id"].ToString());
                        if (executive.Rows.Count != 0)
                        {
                            if (executive.Rows.Count == 5)
                            {
                                sel.Find.Text = "[qa32]";
                                sel.Find.Replacement.Text = executive.Rows[0]["project_name"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa33]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info1"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa34]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info2"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa35]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info3"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa36]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info1"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa37]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info2"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa38]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info3"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa39]";
                                sel.Find.Replacement.Text = executive.Rows[2]["other_info1"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa40]";
                                sel.Find.Replacement.Text = executive.Rows[2]["other_info2"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa41]";
                                sel.Find.Replacement.Text = executive.Rows[2]["other_info3"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);



                            }
                            else if (executive.Rows.Count == 4)
                            {
                                sel.Find.Text = "[qa32]";
                                sel.Find.Replacement.Text = executive.Rows[0]["project_name"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa33]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info1"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa34]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info2"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa35]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info3"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa36]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info1"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa37]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info2"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa38]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info3"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa39]";
                                sel.Find.Replacement.Text = executive.Rows[2]["other_info1"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa40]";
                                sel.Find.Replacement.Text = executive.Rows[2]["other_info2"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa41]";
                                sel.Find.Replacement.Text = executive.Rows[2]["other_info3"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            }
                            else if (executive.Rows.Count == 3)
                            {
                                sel.Find.Text = "[qa32]";
                                sel.Find.Replacement.Text = executive.Rows[0]["project_name"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa33]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info1"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa34]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info2"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa35]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info3"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa36]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info1"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa37]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info2"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa38]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info3"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa39]";
                                sel.Find.Replacement.Text = executive.Rows[2]["other_info1"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa40]";
                                sel.Find.Replacement.Text = executive.Rows[2]["other_info2"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa41]";
                                sel.Find.Replacement.Text = executive.Rows[2]["other_info3"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);


                            }
                            else if (executive.Rows.Count == 2)
                            {
                                sel.Find.Text = "[qa32]";
                                sel.Find.Replacement.Text = executive.Rows[0]["project_name"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa33]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info1"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa34]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info2"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa35]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info3"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa36]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info1"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa37]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info2"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa38]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info3"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa39]";
                                sel.Find.Replacement.Text = "";
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa40]";
                                sel.Find.Replacement.Text = "";
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa41]";
                                sel.Find.Replacement.Text = "";
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            }
                            else if (executive.Rows.Count == 1)
                            {
                                sel.Find.Text = "[qa32]";
                                sel.Find.Replacement.Text = executive.Rows[0]["project_name"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa33]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info1"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa34]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info2"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa35]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info3"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa36]";
                                sel.Find.Replacement.Text = "";
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa37]";
                                sel.Find.Replacement.Text = "";
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa38]";
                                sel.Find.Replacement.Text = "";
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa39]";
                                sel.Find.Replacement.Text = "";
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa40]";
                                sel.Find.Replacement.Text = "";
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa41]";
                                sel.Find.Replacement.Text = "";
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            }
                        }
                    }


                    var rep_b = Serv.GetExistRep1(hddmas_rep_id.Value);
                    if (rep_b.Rows.Count != 0)
                    {
                        var img = Server.MapPath(rep_b.Rows[0]["groung_img_path"].ToString());
                        if (rep_b.Rows[0]["groung_img_path"].ToString() != "")
                        {
                            sel.Find.Text = "[imgb1]";
                            sel.Find.Execute(Replace: WdReplace.wdReplaceNone);
                            sel.Range.Select();
                            sel.InlineShapes.AddPicture(
                                FileName: img,
                                LinkToFile: false,
                                SaveWithDocument: true
                                );
                        }


                        sel.Find.Text = "[b2]";
                        sel.Find.Replacement.Text = rep_b.Rows[0]["aerial_result"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[b3]";
                        sel.Find.Replacement.Text = rep_b.Rows[0]["remark1"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[b4]";
                        sel.Find.Replacement.Text = rep_b.Rows[0]["problem"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                    }

                    //===================================== DA ========================================

                    var da = Serv.GetExistRep2(hddmas_rep_id.Value);
                    if (da.Rows.Count != 0)
                    {

                        sel.Find.Text = "[c7]";
                        sel.Find.Replacement.Text = da.Rows[0]["dainfo11"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[c8]";
                        sel.Find.Replacement.Text = da.Rows[0]["dainfo12"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[c9]";
                        sel.Find.Replacement.Text = da.Rows[0]["dainfo13"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[c10]";
                        sel.Find.Replacement.Text = da.Rows[0]["dainfo14"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[c11]";
                        sel.Find.Replacement.Text = da.Rows[0]["dainfo21"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[c12]";
                        sel.Find.Replacement.Text = da.Rows[0]["dainfo22"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[c13]";
                        sel.Find.Replacement.Text = da.Rows[0]["dainfo23"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[c14]";
                        sel.Find.Replacement.Text = da.Rows[0]["dainfo24"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[c16]";
                        sel.Find.Replacement.Text = da.Rows[0]["dainfo1"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                    }

                    var sub_da = Serv.GetDARep_sub(da.Rows[0]["id"].ToString());
                    if (sub_da.Rows.Count != 0)
                    {
                        Microsoft.Office.Interop.Word.Table axTable;

                        sel.Find.Text = "[table1]";
                        sel.Find.Execute(Replace: WdReplace.wdReplaceNone);
                        sel.Range.Select();
                        axTable = sel.Tables.Add(app.Selection.Range, sub_da.Rows.Count + 1, 6);

                        axTable.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
                        axTable.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;

                        axTable.Cell(1, 1).Range.Text = "เขต";
                        axTable.Cell(1, 2).Range.Text = "เส้นท่อ,ตำแหน่ง";
                        axTable.Cell(1, 3).Range.Text = "ขุดซ่อมเนื่องจาก";
                        axTable.Cell(1, 4).Range.Text = "Length(m)";
                        axTable.Cell(1, 5).Range.Text = "% Actual";
                        axTable.Cell(1, 6).Range.Text = "Plan/Status";

                        int start_row = 2;
                        // This is For Header columns
                        for (int j = 0; j <= sub_da.Rows.Count - 1; j++)
                        {
                            axTable.Cell(start_row, 1).Range.Text = sub_da.Rows[j]["dainfo1"].ToString();
                            axTable.Cell(start_row, 2).Range.Text = sub_da.Rows[j]["dainfo2"].ToString();
                            axTable.Cell(start_row, 3).Range.Text = sub_da.Rows[j]["dainfo3"].ToString();
                            axTable.Cell(start_row, 4).Range.Text = sub_da.Rows[j]["dainfo4"].ToString();
                            axTable.Cell(start_row, 5).Range.Text = sub_da.Rows[j]["dainfo5"].ToString();
                            axTable.Cell(start_row, 6).Range.Text = sub_da.Rows[j]["dainfo6"].ToString();

                            start_row++;
                        }

                    }

                    //=================================================================================

                    //============================= Soil =============================================

                    var soil = Serv.GetExistRep3(hddmas_rep_id.Value);
                    if (soil.Rows.Count != 0)
                    {
                        sel.Find.Text = "[d1]";
                        sel.Find.Replacement.Text = soil.Rows[0]["d1"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[d2]";
                        sel.Find.Replacement.Text = soil.Rows[0]["d2"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[d9]";
                        sel.Find.Replacement.Text = soil.Rows[0]["d9"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[d10]";
                        sel.Find.Replacement.Text = soil.Rows[0]["d10"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[d11]";
                        sel.Find.Replacement.Text = soil.Rows[0]["d11"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        var soil_sub = Serv.GetExistRep3_sub(soil.Rows[0]["id"].ToString());
                        if (soil_sub.Rows.Count != 0)
                        {
                            Microsoft.Office.Interop.Word.Table axTable2;

                            sel.Find.Text = "[table2]";
                            sel.Find.Execute(Replace: WdReplace.wdReplaceNone);
                            sel.Range.Select();
                            axTable2 = sel.Tables.Add(app.Selection.Range, soil_sub.Rows.Count + 1, 4);

                            axTable2.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
                            axTable2.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;

                            axTable2.Cell(1, 1).Range.Text = "Region";
                            axTable2.Cell(1, 2).Range.Text = "เส้นท่อ,ตำแหน่ง";
                            axTable2.Cell(1, 3).Range.Text = "Progress";
                            axTable2.Cell(1, 4).Range.Text = "ผลการดำเนินงาน/สิ่งที่ไม่เป็นไปตามแผน/ปัญหาอุปสรรค/แนวทางแก้ไข";

                            int start_row = 2;

                            for (int j = 0; j <= soil_sub.Rows.Count - 1; j++)
                            {
                                axTable2.Cell(start_row, 1).Range.Text = soil_sub.Rows[j]["d3"].ToString();
                                axTable2.Cell(start_row, 2).Range.Text = soil_sub.Rows[j]["d4"].ToString();
                                axTable2.Cell(start_row, 3).Range.Text = soil_sub.Rows[j]["d7"].ToString();
                                axTable2.Cell(start_row, 4).Range.Text = soil_sub.Rows[j]["d8"].ToString();

                                start_row = start_row + 1;
                            }
                        }
                    }

                    #region E
                    ///=========================== E ==============================
                    ///
                    var exist = Serv.GetExistRep4(hddmas_rep_id.Value);
                    if (exist.Rows.Count != 0)
                    {

                        sel.Find.Text = "[e7]";
                        sel.Find.Replacement.Text = exist.Rows[0]["progressresult"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[e8]";
                        sel.Find.Replacement.Text = exist.Rows[0]["futureplan"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);


                        sel.Find.Text = "[e9]";
                        sel.Find.Replacement.Text = exist.Rows[0]["problem"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        var sub = Serv.GetExistRep4_sub(soil.Rows[0]["id"].ToString());
                        if (sub.Rows.Count != 0)
                        {
                            Microsoft.Office.Interop.Word.Table axTable2;

                            sel.Find.Text = "[table3]";
                            sel.Find.Execute(Replace: WdReplace.wdReplaceNone);
                            sel.Range.Select();
                            axTable2 = sel.Tables.Add(app.Selection.Range, sub.Rows.Count + 1, 5);

                            axTable2.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
                            axTable2.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;

                            axTable2.Cell(1, 1).Range.Text = "Region";
                            axTable2.Cell(1, 2).Range.Text = "Station";
                            axTable2.Cell(1, 3).Range.Text = "Action";
                            axTable2.Cell(1, 4).Range.Text = "Progress";
                            axTable2.Cell(1, 5).Range.Text = "ผลการดำเนินงาน/สิ่งที่ไม่เป็นไปตามแผน/ปัญหาอุปสรรค/แนวทางแก้ไข";

                            int start_row = 2;

                            for (int j = 0; j <= sub.Rows.Count - 1; j++)
                            {
                                axTable2.Cell(start_row, 1).Range.Text = sub.Rows[j]["area"].ToString();
                                axTable2.Cell(start_row, 2).Range.Text = sub.Rows[j]["station"].ToString() + " " + sub.Rows[j]["pipe"].ToString();
                                axTable2.Cell(start_row, 3).Range.Text = sub.Rows[j]["action"].ToString();
                                axTable2.Cell(start_row, 4).Range.Text = sub.Rows[j]["progress"].ToString();
                                axTable2.Cell(start_row, 5).Range.Text = sub.Rows[j]["remark"].ToString();

                                start_row = start_row + 1;
                            }
                        }
                    }
                    #endregion

                    #region F
                    var rov = Serv.GetExistRep5(hddmas_rep_id.Value);
                    if (rov.Rows.Count != 0)
                    {
                        sel.Find.Text = "[f1]";
                        sel.Find.Replacement.Text = rov.Rows[0]["planwork"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[f2]";
                        sel.Find.Replacement.Text = rov.Rows[0]["workresult"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[f3]";
                        sel.Find.Replacement.Text = rov.Rows[0]["planworkfuture"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[f4]";
                        sel.Find.Replacement.Text = rov.Rows[0]["problem"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                    }
                    #endregion

                    #region G
                    var exist_g = Serv.GetExistRep6(hddmas_rep_id.Value);
                    if (exist_g.Rows.Count != 0)
                    {
                        sel.Find.Text = "[g1]";
                        sel.Find.Replacement.Text = exist_g.Rows[0]["planwork"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[g2]";
                        sel.Find.Replacement.Text = exist_g.Rows[0]["workresult"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[g3]";
                        sel.Find.Replacement.Text = exist_g.Rows[0]["planworkfuture"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[g4]";
                        sel.Find.Replacement.Text = exist_g.Rows[0]["problem"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                    }
                    #endregion

                    #region h
                    var exist_h = Serv.GetExistRep(hddmas_rep_id.Value);
                    if (exist_h.Rows.Count != 0)
                    {
                        sel.Find.Text = "[h1]";
                        sel.Find.Replacement.Text = exist_h.Rows[0]["workresult"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[h2]";
                        sel.Find.Replacement.Text = exist_h.Rows[0]["pspotentialsurvey"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[h3]";
                        sel.Find.Replacement.Text = exist_h.Rows[0]["bondboxinspection"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[h4]";
                        sel.Find.Replacement.Text = exist_h.Rows[0]["rectifierispection"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[h5]";
                        sel.Find.Replacement.Text = exist_h.Rows[0]["insulatingjoint"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);


                        var subCIPSStatus = Serv.GetExistRep_sub_cipsstatus(exist_h.Rows[0]["id"].ToString());

                        if (subCIPSStatus.Rows.Count != 0)
                        {
                            Microsoft.Office.Interop.Word.Table axTable2;

                            sel.Find.Text = "[table4]";
                            sel.Find.Execute(Replace: WdReplace.wdReplaceNone);
                            sel.Range.Select();
                            sel.Find.Forward = true;
                            axTable2 = sel.Tables.Add(app.Selection.Range, subCIPSStatus.Rows.Count + 1, 3);

                            axTable2.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
                            axTable2.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;

                            axTable2.Cell(1, 1).Range.Text = "Route Code";
                            axTable2.Cell(1, 2).Range.Text = "Pipeline name";
                            axTable2.Cell(1, 3).Range.Text = "สถานะ";

                            int start_row = 2;

                            for (int j = 0; j <= subCIPSStatus.Rows.Count - 1; j++)
                            {
                                axTable2.Cell(start_row, 1).Range.Text = subCIPSStatus.Rows[j]["routecode"].ToString();
                                axTable2.Cell(start_row, 2).Range.Text = subCIPSStatus.Rows[j]["pipelinename"].ToString();
                                axTable2.Cell(start_row, 3).Range.Text = subCIPSStatus.Rows[j]["status"].ToString();

                                start_row = start_row + 1;
                            }
                        }

                        var image_h13 = Server.MapPath(exist_h.Rows[0]["ecresultfilepath"].ToString());
                        if (exist_h.Rows[0]["ecresultfilepath"].ToString() != "")
                        {
                            sel.Find.Text = "[h13]";
                            sel.Find.Execute(Replace: WdReplace.wdReplaceNone);
                            sel.Range.Select();
                            sel.Find.Forward = true;
                            sel.InlineShapes.AddPicture(
                                FileName: image_h13,
                                LinkToFile: false,
                                SaveWithDocument: true
                                );
                        }


                        var image_h14 = Server.MapPath(exist_h.Rows[0]["cdresultfilepath"].ToString());
                        if (exist_h.Rows[0]["cdresultfilepath"].ToString() != "")
                        {
                            sel.Find.Text = "[h14]";
                            sel.Find.Execute(Replace: WdReplace.wdReplaceNone);
                            sel.Range.Select();
                            sel.Find.Forward = true;
                            sel.InlineShapes.AddPicture(
                                FileName: image_h14,
                                LinkToFile: false,
                                SaveWithDocument: true
                                );
                        }



                        var subCIPSStatusActivity = Serv.GetExistRep_sub_cipsstatus_activity(exist_h.Rows[0]["id"].ToString());

                        if (subCIPSStatusActivity.Rows.Count != 0)
                        {
                            Microsoft.Office.Interop.Word.Table axTable3;

                            sel.Find.Text = "[table5]";
                            sel.Find.Execute(Replace: WdReplace.wdReplaceNone);
                            sel.Range.Select();
                            sel.Find.Forward = true;
                            axTable3 = sel.Tables.Add(app.Selection.Range, subCIPSStatusActivity.Rows.Count + 1, 3);

                            axTable3.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
                            axTable3.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;

                            axTable3.Cell(1, 1).Range.Text = "Active";
                            axTable3.Cell(1, 2).Range.Text = "แผนดำเนินการ";
                            axTable3.Cell(1, 3).Range.Text = "คาดการเสร็จสิ้น";

                            int start_row = 2;

                            for (int j = 0; j <= subCIPSStatusActivity.Rows.Count - 1; j++)
                            {
                                axTable3.Cell(start_row, 1).Range.Text = subCIPSStatusActivity.Rows[j]["activity"].ToString();
                                axTable3.Cell(start_row, 2).Range.Text = subCIPSStatusActivity.Rows[j]["progress"].ToString();
                                axTable3.Cell(start_row, 3).Range.Text = subCIPSStatusActivity.Rows[j]["estimateplan"].ToString();

                                start_row = start_row + 1;
                            }
                        }


                        sel.Find.Text = "[h15]";
                        sel.Find.Replacement.Text = exist_h.Rows[0]["planworkfuture"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[h19]";
                        sel.Find.Replacement.Text = exist_h.Rows[0]["problem"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        //var subCathodic = Serv.GetExistRep_sub_cathodicresult(exist_h.Rows[0]["id"].ToString());

                        //if (subCathodic.Rows.Count != 0)
                        //{
                        //    gvCathodic.DataSource = subCathodic;
                        //    gvCathodic.DataBind();
                        //}









                    }


                    #endregion
                    #region i
                    var exist_i = Serv.GetExistRep_i(hddmas_rep_id.Value);
                    if (exist_i.Rows.Count != 0)
                    {
                        sel.Find.Text = "[i1]";
                        sel.Find.Replacement.Text = exist_i.Rows[0]["planwork"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        //txtRoutecode.Text = exist_i.Rows[0]["pwroutecode"].ToString();
                        //txtDimeter.Text = exist_i.Rows[0]["pwdimeter"].ToString();
                        //txtPipeline.Text = exist_i.Rows[0]["pwpipelinesection"].ToString();
                        //txtNumberOfPig.Text = exist_i.Rows[0]["pwnumberpig"].ToString();
                        //txtPlanning.Text = exist_i.Rows[0]["pwplaning"].ToString();

                        sel.Find.Text = "[i7]";
                        sel.Find.Replacement.Text = exist_i.Rows[0]["planwork"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        var subPig = Serv.GetExistRep_sub_pigresult(exist_i.Rows[0]["id"].ToString());

                        if (subPig.Rows.Count != 0)
                        {
                            Microsoft.Office.Interop.Word.Table axTable2;

                            sel.Find.Text = "[table6]";
                            sel.Find.Execute(Replace: WdReplace.wdReplaceNone);
                            sel.Range.Select();
                            axTable2 = sel.Tables.Add(app.Selection.Range, subPig.Rows.Count + 1, 2);


                            int start_row = 1;

                            for (int j = 0; j <= subPig.Rows.Count - 1; j++)
                            {
                                axTable2.Cell(start_row, 1).Range.Text = subPig.Rows[j]["routecode"].ToString() + " " + subPig.Rows[j]["sectionlength"].ToString();
                                axTable2.Cell(start_row, 2).Range.Text = subPig.Rows[j]["status"].ToString();

                                start_row = start_row + 1;
                            }
                        }


                        sel.Find.Text = "[i11]";
                        sel.Find.Replacement.Text = exist_i.Rows[0]["notethat"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[i12]";
                        sel.Find.Replacement.Text = exist_i.Rows[0]["froutecode"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[i13]";
                        sel.Find.Replacement.Text = exist_i.Rows[0]["fdimeter"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[i14]";
                        sel.Find.Replacement.Text = exist_i.Rows[0]["fpipelinesection"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[i15]";
                        sel.Find.Replacement.Text = exist_i.Rows[0]["fnumberpig"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[i16]";
                        sel.Find.Replacement.Text = exist_i.Rows[0]["fplaning"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[i17]";
                        sel.Find.Replacement.Text = exist_i.Rows[0]["problem"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);



                        var subReplan = Serv.GetExistRep_sub_replan(exist_i.Rows[0]["id"].ToString());

                        if (subReplan.Rows.Count != 0)
                        {
                            Microsoft.Office.Interop.Word.Table axTable2;

                            sel.Find.Text = "[table8]";
                            sel.Find.Execute(Replace: WdReplace.wdReplaceNone);
                            sel.Range.Select();
                            axTable2 = sel.Tables.Add(app.Selection.Range, subReplan.Rows.Count + 1, 3);

                            axTable2.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
                            axTable2.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;

                            axTable2.Cell(1, 1).Range.Text = "เส้นท่อ";
                            axTable2.Cell(1, 2).Range.Text = "ปรับแผน";
                            axTable2.Cell(1, 3).Range.Text = "รายละเอียด";

                            int start_row = 2;

                            for (int j = 0; j <= subReplan.Rows.Count - 1; j++)
                            {
                                axTable2.Cell(start_row, 1).Range.Text = subReplan.Rows[j]["routecode"].ToString();
                                axTable2.Cell(start_row, 2).Range.Text = subReplan.Rows[j]["replan"].ToString();
                                axTable2.Cell(start_row, 3).Range.Text = subReplan.Rows[j]["detail"].ToString();

                                start_row = start_row + 1;
                            }
                        }

                    }
                    #endregion

                    #region j
                    var exist_j = Serv.GetExistRep_j(hddmas_rep_id.Value);

                    if (exist_j.Rows.Count != 0)
                    {
                        Microsoft.Office.Interop.Word.Table axTable2;

                        sel.Find.Text = "[table9]";
                        sel.Find.Execute(Replace: WdReplace.wdReplaceNone);
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Range.Select();
                        axTable2 = sel.Tables.Add(app.Selection.Range, 3, 18);

                        axTable2.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
                        axTable2.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;

                        axTable2.Cell(1, 1).Merge(axTable2.Cell(2, 1));
                        axTable2.Cell(1, 2).Merge(axTable2.Cell(2, 2));
                        axTable2.Cell(1, 3).Merge(axTable2.Cell(2, 3));
                        axTable2.Cell(1, 4).Merge(axTable2.Cell(2, 4));
                        axTable2.Cell(1, 5).Merge(axTable2.Cell(2, 5));

                        axTable2.Cell(1, 6).Merge(axTable2.Cell(1, 7));
                        axTable2.Cell(1, 6).Merge(axTable2.Cell(1, 8));
                        axTable2.Cell(1, 6).Merge(axTable2.Cell(1, 9));
                        axTable2.Cell(1, 6).Merge(axTable2.Cell(1, 10));
                        axTable2.Cell(1, 6).Merge(axTable2.Cell(1, 7));

                        axTable2.Cell(1, 7).Merge(axTable2.Cell(2, 18));


                        axTable2.Cell(1, 1).Range.Text = "No.";
                        axTable2.Cell(1, 2).Range.Text = "Route Code";
                        axTable2.Cell(1, 3).Range.Text = "ID";
                        axTable2.Cell(1, 4).Range.Text = "Pipeline Section";
                        axTable2.Cell(1, 5).Range.Text = "Launch";
                        axTable2.Cell(1, 6).Range.Text = "ปี " + DateTime.Now.ToString("yyyy", EngCI);

                        axTable2.Cell(1, 7).Range.Text = "Actual จำนวนลูก";

                        axTable2.Cell(2, 6).Range.Text = "Jan";
                        axTable2.Cell(2, 7).Range.Text = "Feb";
                        axTable2.Cell(2, 8).Range.Text = "Mar";
                        axTable2.Cell(2, 9).Range.Text = "Apr";
                        axTable2.Cell(2, 10).Range.Text = "May";
                        axTable2.Cell(2, 11).Range.Text = "Jun";
                        axTable2.Cell(2, 12).Range.Text = "Jul";
                        axTable2.Cell(2, 13).Range.Text = "Aug";
                        axTable2.Cell(2, 14).Range.Text = "Sep";
                        axTable2.Cell(2, 15).Range.Text = "Oct";
                        axTable2.Cell(2, 16).Range.Text = "Nov";
                        axTable2.Cell(2, 17).Range.Text = "Dec";

                        axTable2.Cell(3, 1).Range.Text = "1";
                        axTable2.Cell(3, 2).Range.Text = exist_j.Rows[0]["pwroutecode"].ToString();
                        axTable2.Cell(3, 3).Range.Text = exist_j.Rows[0]["pwdimeter"].ToString();
                        axTable2.Cell(3, 4).Range.Text = exist_j.Rows[0]["pwpipelinesection"].ToString();
                        axTable2.Cell(3, 18).Range.Text = exist_j.Rows[0]["pwnumberpig"].ToString();

                        if (exist_j.Rows[0]["pwplaning"].ToString().Contains("มกราคม"))
                        {
                            axTable2.Cell(3, 6).Range.Shading.BackgroundPatternColor = WdColor.wdColorPink;
                        }
                        else if (exist_j.Rows[0]["pwplaning"].ToString().Contains("กุมภา"))
                        {
                            axTable2.Cell(3, 7).Range.Shading.BackgroundPatternColor = WdColor.wdColorPink;
                        }
                        else if (exist_j.Rows[0]["pwplaning"].ToString().Contains("มีนา"))
                        {
                            axTable2.Cell(3, 8).Range.Shading.BackgroundPatternColor = WdColor.wdColorPink;
                        }
                        else if (exist_j.Rows[0]["pwplaning"].ToString().Contains("เมษา"))
                        {
                            axTable2.Cell(3, 9).Range.Shading.BackgroundPatternColor = WdColor.wdColorPink;
                        }
                        else if (exist_j.Rows[0]["pwplaning"].ToString().Contains("พฤษภา"))
                        {
                            axTable2.Cell(3, 10).Range.Shading.BackgroundPatternColor = WdColor.wdColorPink;
                        }
                        else if (exist_j.Rows[0]["pwplaning"].ToString().Contains("มีนา"))
                        {
                            axTable2.Cell(3, 11).Range.Shading.BackgroundPatternColor = WdColor.wdColorPink;
                        }
                        else if (exist_j.Rows[0]["pwplaning"].ToString().Contains("กรก"))
                        {
                            axTable2.Cell(3, 12).Range.Shading.BackgroundPatternColor = WdColor.wdColorPink;
                        }
                        else if (exist_j.Rows[0]["pwplaning"].ToString().Contains("สิงหา"))
                        {
                            axTable2.Cell(3, 13).Range.Shading.BackgroundPatternColor = WdColor.wdColorPink;
                        }
                        else if (exist_j.Rows[0]["pwplaning"].ToString().Contains("กันยา"))
                        {
                            axTable2.Cell(3, 14).Range.Shading.BackgroundPatternColor = WdColor.wdColorPink;
                        }
                        else if (exist_j.Rows[0]["pwplaning"].ToString().Contains("ตุลา"))
                        {
                            axTable2.Cell(3, 15).Range.Shading.BackgroundPatternColor = WdColor.wdColorPink;
                        }
                        else if (exist_j.Rows[0]["pwplaning"].ToString().Contains("พฤศจิ"))
                        {
                            axTable2.Cell(3, 16).Range.Shading.BackgroundPatternColor = WdColor.wdColorPink;
                        }
                        else if (exist_j.Rows[0]["pwplaning"].ToString().Contains("ธันวา"))
                        {
                            axTable2.Cell(3, 17).Range.Shading.BackgroundPatternColor = WdColor.wdColorPink;
                        }


                        Microsoft.Office.Interop.Word.Table axTable3;

                        sel.Find.Text = "[table10]";
                        sel.Find.Execute(Replace: WdReplace.wdReplaceNone);
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Range.Select();
                        axTable3 = sel.Tables.Add(app.Selection.Range, 2, 2);

                        axTable3.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
                        axTable3.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;

                        axTable3.Cell(1, 1).Range.Text = "เส้นท่อ";
                        axTable3.Cell(1, 2).Range.Text = "ผลการดำเนินงาน";


                        axTable3.Cell(2, 1).Range.Text = exist_j.Rows[0]["wroutecode"].ToString() + " " + exist_j.Rows[0]["wpipelinesection"].ToString();
                        axTable3.Cell(2, 2).Range.Text = exist_j.Rows[0]["wresult"].ToString();


                        sel.Find.Text = "[j9]";
                        sel.Find.Replacement.Text = exist_j.Rows[0]["froutecode"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[j10]";
                        sel.Find.Replacement.Text = exist_j.Rows[0]["fdimeter"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[j11]";
                        sel.Find.Replacement.Text = exist_j.Rows[0]["fpipelinesection"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[j12]";
                        sel.Find.Replacement.Text = exist_j.Rows[0]["fnumberpig"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[j13]";
                        sel.Find.Replacement.Text = exist_j.Rows[0]["fplaning"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[j14]";
                        sel.Find.Replacement.Text = exist_j.Rows[0]["problem"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                    }
                    #endregion

                    #region K
                    var exist_k = Serv.GetExistRep_k(hddmas_rep_id.Value);

                    if (exist_k.Rows.Count != 0)
                    {
                        sel.Find.Text = "[k1]";
                        sel.Find.Replacement.Text = exist_k.Rows[0]["detail"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);
                    }
                    #endregion

                    #region L
                    var exist_L = Serv.GetExistRep_L(hddmas_rep_id.Value);
                    if (exist_L.Rows.Count != 0)
                    {
                        var sub_piping1 = Serv.Get_tbl_piping_qurter_plan1(exist_L.Rows[0]["id"].ToString());
                        if (sub_piping1.Rows.Count != 0)
                        {
                            sel.Find.Text = "[l1]";
                            sel.Find.Replacement.Text = sub_piping1.Rows[0]["l1"].ToString().Replace("\r\n", "\v");
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            sel.Find.Text = "[l21]";
                            sel.Find.Replacement.Text = sub_piping1.Rows[0]["l2"].ToString().Replace("\r\n", "\v");
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            sel.Find.Text = "[l22]";
                            sel.Find.Replacement.Text = sub_piping1.Rows[1]["l2"].ToString().Replace("\r\n", "\v");
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            sel.Find.Text = "[l23]";
                            sel.Find.Replacement.Text = sub_piping1.Rows[2]["l2"].ToString().Replace("\r\n", "\v");
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            sel.Find.Text = "[l331]";
                            sel.Find.Replacement.Text = "18";
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            sel.Find.Text = "[l332]";
                            sel.Find.Replacement.Text = "18";
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            string xl = "0";
                            string wl = "0";

                            xl = "3";
                            wl = "3";

                            for (int i = 0; i <= 9; i++)
                            {
                                if (Convert.ToString(i) != xl)
                                {
                                    sel.Find.Text = "[l" + wl + "" + i + "1]";
                                    sel.Find.Replacement.Text = "";
                                    sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                    sel.Find.Forward = true;
                                    sel.Find.Format = false;
                                    sel.Find.MatchCase = false;
                                    sel.Find.MatchWholeWord = false;
                                    sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                    sel.Find.Text = "[l" + wl + "" + i + "2]";
                                    sel.Find.Replacement.Text = "";
                                    sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                    sel.Find.Forward = true;
                                    sel.Find.Format = false;
                                    sel.Find.MatchCase = false;
                                    sel.Find.MatchWholeWord = false;
                                    sel.Find.Execute(Replace: WdReplace.wdReplaceAll);
                                }
                            }

                            sel.Find.Text = "[l421]";
                            sel.Find.Replacement.Text = "2";
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            sel.Find.Text = "[l422]";
                            sel.Find.Replacement.Text = "2";
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            xl = "2";
                            wl = "4";

                            for (int i = 0; i <= 9; i++)
                            {
                                if (Convert.ToString(i) != xl)
                                {
                                    sel.Find.Text = "[l" + wl + "" + i + "1]";
                                    sel.Find.Replacement.Text = "";
                                    sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                    sel.Find.Forward = true;
                                    sel.Find.Format = false;
                                    sel.Find.MatchCase = false;
                                    sel.Find.MatchWholeWord = false;
                                    sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                    sel.Find.Text = "[l" + wl + "" + i + "2]";
                                    sel.Find.Replacement.Text = "";
                                    sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                    sel.Find.Forward = true;
                                    sel.Find.Format = false;
                                    sel.Find.MatchCase = false;
                                    sel.Find.MatchWholeWord = false;
                                    sel.Find.Execute(Replace: WdReplace.wdReplaceAll);
                                }
                            }

                            sel.Find.Text = "[l511]";
                            sel.Find.Replacement.Text = "2";
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            sel.Find.Text = "[l512]";
                            sel.Find.Replacement.Text = "2";
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            xl = "1";
                            wl = "5";

                            for (int i = 0; i <= 9; i++)
                            {
                                if (Convert.ToString(i) != xl)
                                {
                                    sel.Find.Text = "[l" + wl + "" + i + "1]";
                                    sel.Find.Replacement.Text = "";
                                    sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                    sel.Find.Forward = true;
                                    sel.Find.Format = false;
                                    sel.Find.MatchCase = false;
                                    sel.Find.MatchWholeWord = false;
                                    sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                    sel.Find.Text = "[l" + wl + "" + i + "2]";
                                    sel.Find.Replacement.Text = "";
                                    sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                    sel.Find.Forward = true;
                                    sel.Find.Format = false;
                                    sel.Find.MatchCase = false;
                                    sel.Find.MatchWholeWord = false;
                                    sel.Find.Execute(Replace: WdReplace.wdReplaceAll);
                                }
                            }

                        }

                        var sub_piping2 = Serv.Get_tbl_piping_qurter_plan2(exist_L.Rows[0]["id"].ToString());
                        if (sub_piping2.Rows.Count != 0)
                        {

                            sel.Find.Text = "[l10]";
                            sel.Find.Replacement.Text = sub_piping2.Rows[0]["l30"].ToString().Replace("\r\n", "\v");
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            sel.Find.Text = "[l021]";
                            sel.Find.Replacement.Text = sub_piping2.Rows[0]["l31"].ToString().Replace("\r\n", "\v");
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            sel.Find.Text = "[l022]";
                            sel.Find.Replacement.Text = sub_piping2.Rows[1]["l31"].ToString().Replace("\r\n", "\v");
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            sel.Find.Text = "[l023]";
                            sel.Find.Replacement.Text = sub_piping2.Rows[2]["l31"].ToString().Replace("\r\n", "\v");
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            sel.Find.Text = "[l0331]";
                            sel.Find.Replacement.Text = "18";
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            sel.Find.Text = "[l0332]";
                            sel.Find.Replacement.Text = "18";
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            string xl = "0";
                            string wl = "0";

                            xl = "3";
                            wl = "3";

                            for (int i = 0; i <= 9; i++)
                            {
                                if (Convert.ToString(i) != xl)
                                {
                                    sel.Find.Text = "[l0" + wl + "" + i + "1]";
                                    sel.Find.Replacement.Text = "";
                                    sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                    sel.Find.Forward = true;
                                    sel.Find.Format = false;
                                    sel.Find.MatchCase = false;
                                    sel.Find.MatchWholeWord = false;
                                    sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                    sel.Find.Text = "[l0" + wl + "" + i + "2]";
                                    sel.Find.Replacement.Text = "";
                                    sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                    sel.Find.Forward = true;
                                    sel.Find.Format = false;
                                    sel.Find.MatchCase = false;
                                    sel.Find.MatchWholeWord = false;
                                    sel.Find.Execute(Replace: WdReplace.wdReplaceAll);
                                }
                            }

                            sel.Find.Text = "[l0421]";
                            sel.Find.Replacement.Text = "2";
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            sel.Find.Text = "[l0422]";
                            sel.Find.Replacement.Text = "2";
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            xl = "2";
                            wl = "4";

                            for (int i = 0; i <= 9; i++)
                            {
                                if (Convert.ToString(i) != xl)
                                {
                                    sel.Find.Text = "[l0" + wl + "" + i + "1]";
                                    sel.Find.Replacement.Text = "";
                                    sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                    sel.Find.Forward = true;
                                    sel.Find.Format = false;
                                    sel.Find.MatchCase = false;
                                    sel.Find.MatchWholeWord = false;
                                    sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                    sel.Find.Text = "[l0" + wl + "" + i + "2]";
                                    sel.Find.Replacement.Text = "";
                                    sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                    sel.Find.Forward = true;
                                    sel.Find.Format = false;
                                    sel.Find.MatchCase = false;
                                    sel.Find.MatchWholeWord = false;
                                    sel.Find.Execute(Replace: WdReplace.wdReplaceAll);
                                }
                            }

                            sel.Find.Text = "[l0511]";
                            sel.Find.Replacement.Text = "2";
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            sel.Find.Text = "[l0512]";
                            sel.Find.Replacement.Text = "2";
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            xl = "1";
                            wl = "5";

                            for (int i = 0; i <= 9; i++)
                            {
                                if (Convert.ToString(i) != xl)
                                {
                                    sel.Find.Text = "[l0" + wl + "" + i + "1]";
                                    sel.Find.Replacement.Text = "";
                                    sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                    sel.Find.Forward = true;
                                    sel.Find.Format = false;
                                    sel.Find.MatchCase = false;
                                    sel.Find.MatchWholeWord = false;
                                    sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                    sel.Find.Text = "[l0" + wl + "" + i + "2]";
                                    sel.Find.Replacement.Text = "";
                                    sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                    sel.Find.Forward = true;
                                    sel.Find.Format = false;
                                    sel.Find.MatchCase = false;
                                    sel.Find.MatchWholeWord = false;
                                    sel.Find.Execute(Replace: WdReplace.wdReplaceAll);
                                }
                            }
                        }

                        var sub6 = Serv.GetSub6(exist_L.Rows[0]["id"].ToString());
                        if (sub6.Rows.Count != 0)
                        {
                            Microsoft.Office.Interop.Word.Table axTable2;

                            sel.Find.Text = "[table11]";
                            sel.Find.Execute(Replace: WdReplace.wdReplaceNone);
                            sel.Range.Select();
                            axTable2 = sel.Tables.Add(app.Selection.Range, sub6.Rows.Count + 1, 4);

                            axTable2.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
                            axTable2.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;

                            axTable2.Cell(1, 1).Range.Text = "Region";
                            axTable2.Cell(1, 2).Range.Text = "Inspection";
                            axTable2.Cell(1, 3).Range.Text = "CM Sattion";
                            axTable2.Cell(1, 4).Range.Text = "Date";

                            int start_row = 2;

                            for (int j = 0; j <= sub6.Rows.Count - 1; j++)
                            {
                                axTable2.Cell(start_row, 1).Range.Text = sub6.Rows[j]["l26"].ToString();
                                axTable2.Cell(start_row, 2).Range.Text = sub6.Rows[j]["l27"].ToString();
                                axTable2.Cell(start_row, 3).Range.Text = sub6.Rows[j]["l28"].ToString();
                                axTable2.Cell(start_row, 3).Range.Text = sub6.Rows[j]["l29"].ToString();

                                start_row = start_row + 1;
                            }

                        }
                    }
                    #endregion

                    #region M
                    var exist_M = Serv.GetExistRep_M(hddmas_rep_id.Value);

                    if (exist_M.Rows.Count != 0)
                    {
                        sel.Find.Text = "[m1]";
                        sel.Find.Replacement.Text = exist_M.Rows[0]["cplanwork"].ToString();
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[m2]";
                        sel.Find.Replacement.Text = exist_M.Rows[0]["cprogressresult"].ToString();
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[m3]";
                        sel.Find.Replacement.Text = exist_M.Rows[0]["cfutureplan"].ToString();
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[m4]";
                        sel.Find.Replacement.Text = exist_M.Rows[0]["cproblem"].ToString();
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[m5]";
                        sel.Find.Replacement.Text = exist_M.Rows[0]["mplanwork"].ToString();
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[m6]";
                        sel.Find.Replacement.Text = exist_M.Rows[0]["mprogressresult"].ToString();
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[m7]";
                        sel.Find.Replacement.Text = exist_M.Rows[0]["mfutureplan"].ToString();
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[m8]";
                        sel.Find.Replacement.Text = exist_M.Rows[0]["mproblem"].ToString();
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);


                    }
                    #endregion

                    #region G
                    var exist_G = Serv.GetExistRep_G(hddmas_rep_id.Value);
                    if (exist_G.Rows.Count != 0)
                    {
                        var sub_other = Serv.GetExistRep_sub_G(exist_G.Rows[0]["id"].ToString());
                        if (sub_other.Rows.Count != 0)
                        {
                            Microsoft.Office.Interop.Word.Table axTable2;

                            sel.Find.Text = "[table12]";
                            sel.Find.Execute(Replace: WdReplace.wdReplaceNone);
                            sel.Range.Select();
                            axTable2 = sel.Tables.Add(app.Selection.Range, sub_other.Rows.Count * 10, 1);


                            int start_row = 1;

                            for (int j = 0; j <= sub_other.Rows.Count - 1; j++)
                            {
                                axTable2.Cell(start_row, 1).Range.Text = "1.7." + (j + 2);
                                axTable2.Cell(start_row, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                start_row = start_row + 1;
                                axTable2.Cell(start_row, 1).Range.Text = "\t" + sub_other.Rows[j]["projectname"].ToString();
                                axTable2.Cell(start_row, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                                start_row = start_row + 1;
                                axTable2.Cell(start_row, 1).Range.Text = "1.7." + (j + 2) + ".1 แผนงาน";
                                axTable2.Cell(start_row, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                start_row = start_row + 1;
                                axTable2.Cell(start_row, 1).Range.Text = "\t" + sub_other.Rows[j]["planwork"].ToString();
                                axTable2.Cell(start_row, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                                start_row = start_row + 1;
                                axTable2.Cell(start_row, 1).Range.Text = "1.7." + (j + 2) + ".2 ผลการดำเนินงาน";
                                axTable2.Cell(start_row, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                start_row = start_row + 1;
                                axTable2.Cell(start_row, 1).Range.Text = "\t" + sub_other.Rows[j]["workresult"].ToString();
                                axTable2.Cell(start_row, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                                start_row = start_row + 1;
                                axTable2.Cell(start_row, 1).Range.Text = "1.7." + (j + 2) + ".3 การดำเนินงานในอนาคต";
                                axTable2.Cell(start_row, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                start_row = start_row + 1;
                                axTable2.Cell(start_row, 1).Range.Text = "\t" + sub_other.Rows[j]["futureplan"].ToString();
                                axTable2.Cell(start_row, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                                start_row = start_row + 1;
                                axTable2.Cell(start_row, 1).Range.Text = "1.7." + (j + 2) + ".4 ปัญหาอุปสรรค์ (ถ้ามี)";
                                axTable2.Cell(start_row, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                start_row = start_row + 1;
                                axTable2.Cell(start_row, 1).Range.Text = "\t" + sub_other.Rows[j]["problem"].ToString();
                                axTable2.Cell(start_row, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;


                                start_row = start_row + 1;
                            }
                        }
                    }
                    #endregion

                    string time = DateTime.Now.ToString("yyyy-MM-ddHHmmss", EngCI);

                    //************************************************

                    doc.SaveAs(Server.MapPath("~/gen_1/Quaterly_report_" + time + ".docx"));
                    doc.Close();

                    var x = Serv.InsertHistory(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", EngCI), HttpContext.Current.Session["assetusername"].ToString(), "Quaterly_report",
                        "~/gen_1/Quaterly_report_" + time + ".docx", "1", "", hddmas_rep_id.Value);

                    hddfile_path.Value = "~/gen_1/Quaterly_report_" + time + ".docx";

                    if (x.Rows.Count != 0)
                    {
                        Serv.UpdateHistory(x.Rows[0]["id"].ToString(), "Quaterly_report_V" + x.Rows[0]["id"].ToString(), x.Rows[0]["id"].ToString(), hddmas_rep_id.Value);
                    }

                    POPUPMSG("บันทึกเรียบร้อย");
                }

            }
            finally
            {
                app.Quit();
            }
        }

        protected void btndal3_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            HiddenField hddrepid = (HiddenField)row.FindControl("HddCIPSStatusActivityId");

            Serv.Deletetblexternalcorrosion_sub_cipsstatus_activity(hddrepid.Value);
            
            var subCIPSStatusActivity = Serv.GetExistRep_sub_cipsstatus_activity(hddec_id.Value);

            if (subCIPSStatusActivity.Rows.Count != 0)
            {
                gvCIPSStatusActivity.DataSource = subCIPSStatusActivity;
                gvCIPSStatusActivity.DataBind();
            }
            else
            {
                gvCIPSStatusActivity.DataSource = null;
                gvCIPSStatusActivity.DataBind();
            }
        }
    }
}