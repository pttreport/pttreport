using ptt_report.App_Code;
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
    public partial class patrolling : System.Web.UI.Page
    {
        CultureInfo ThCI = new System.Globalization.CultureInfo("th-TH");
        CultureInfo EngCI = new System.Globalization.CultureInfo("en-US");
        patrollingDLL Serv = new patrollingDLL();

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

                    if (HttpContext.Current.Session["assetapprove"].ToString() == "y")
                    {
                        btnApprove.Visible = true;
                    }
                    else
                    {
                        btnApprove.Visible = false;
                    }

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

            var exist = Serv.GetExistRep1(hddmas_rep_id.Value);
            if (exist.Rows.Count != 0)
            {
                hddpatolling_id.Value = exist.Rows[0]["id"].ToString();
                PatrollingAerialResult.Text = exist.Rows[0]["aerial_result"].ToString();
                PatrollingNote.Text = exist.Rows[0]["remark1"].ToString();
                PatrollingProblem.Text = exist.Rows[0]["problem"].ToString();
                PatrollingFormFeedback.Text = exist.Rows[0]["remark2"].ToString();
            }
            else
            {
                var init = Serv.InsertFirst_patoll(hddmas_rep_id.Value, "", "", "", "", "", "", "", "n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", EngCI));

                if (init.Rows.Count != 0)
                {
                    hddpatolling_id.Value = init.Rows[0]["id"].ToString();
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

        protected void PatrollingFormSaveSubmit_Click1(object sender, EventArgs e)
        {
            // TODO : save Patrolling
            if (PatrollingUpload.HasFile)
            {
                try
                {
                    string[] segments = PatrollingUpload.FileName.Split('.');
                    string fileExt = segments[segments.Length - 1];

                    string filename = "patoll_" + DateTime.Now.ToString("yyMMddHHssss");
                    PatrollingUpload.SaveAs(Server.MapPath("~/img_rep/") + filename + fileExt);

                    Serv.Update_File(Server.MapPath("~/img_rep/") + filename, "~/img_rep/" + filename, hddpatolling_id.Value);
                }
                catch (Exception ex)
                {
                    POPUPMSG("Upload status: The file could not be uploaded. The following error occured: " + ex.Message);
                    return;
                }

            }


            Serv.Update_info(PatrollingAerialResult.Text, PatrollingNote.Text, PatrollingProblem.Text, PatrollingFormFeedback.Text, HttpContext.Current.Session["assetusername"].ToString(),
                hddpatolling_id.Value, HttpContext.Current.Session["assetuserid"].ToString(), hddmas_rep_id.Value);

            POPUPMSG("บันทึกเรียบร้อย");

        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            PatrollingAerialResult.Text = "ในไตรมาศที่ 1 นั้นยังไม่มีแผนการบินลาดตระเวนตามแนวท่อก๊าซธรรมชาติ ซึ่งมีแผน 2 ครั้งต่อปี สำหรับปี พ.ศ. 2559 มีแผนสำรวจในช่วงเดือนมิ.ย. และช่วงเดือน พ.ย. ในพื้นที่เขต 1,2,3,5,6,8,9,10 และ 11";

            PatrollingNote.Text = "สำหรับเขตพื้นที่ 4 และ 7 และบาง Zone ที่ไม่สามารถบินสำรวจได้ จะใช้ผลการตรวจ Ground Patrolling เพื่อสำรวจก๊าซรั่วไหลแทน";
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            Serv.UpdateStatus_rep(hddmas_rep_id.Value, HttpContext.Current.Session["assetuserid"].ToString());
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

                        sel.Find.Text = "[imgb1]";
                        sel.Find.Execute(Replace: WdReplace.wdReplaceNone);
                        sel.Range.Select();
                        sel.InlineShapes.AddPicture(
                            FileName: img,
                            LinkToFile: false,
                            SaveWithDocument: true
                            );

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
                        axTable = sel.Tables.Add(app.Selection.Range, sub_da.Rows.Count, 6);
                        
                        axTable.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
                        axTable.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;

                        // This is For Header columns
                        for (int j = 1; j <= sub_da.Rows.Count; j++)
                        {
                            if (j == 1)
                            {
                                axTable.Cell(j, 1).Range.Text = "เขต";
                                axTable.Cell(j, 2).Range.Text = "เส้นท่อ,ตำแหน่ง";
                                axTable.Cell(j, 3).Range.Text = "ขุดซ่อมเนื่องจาก";
                                axTable.Cell(j, 4).Range.Text = "Length(m)";
                                axTable.Cell(j, 5).Range.Text = "% Actual";
                                axTable.Cell(j, 6).Range.Text = "Plan/Status";
                            }
                            else
                            {
                                axTable.Cell(j, 1).Range.Text = sub_da.Rows[j - 1]["dainfo1"].ToString();
                                axTable.Cell(j, 2).Range.Text = sub_da.Rows[j - 1]["dainfo2"].ToString();
                                axTable.Cell(j, 3).Range.Text = sub_da.Rows[j - 1]["dainfo3"].ToString();
                                axTable.Cell(j, 4).Range.Text = sub_da.Rows[j - 1]["dainfo4"].ToString();
                                axTable.Cell(j, 5).Range.Text = sub_da.Rows[j - 1]["dainfo5"].ToString();
                                axTable.Cell(j, 6).Range.Text = sub_da.Rows[j - 1]["dainfo6"].ToString();
                            }
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
                            Microsoft.Office.Interop.Word.Table axTable;

                            sel.Find.Text = "[table2]";
                            sel.Find.Execute(Replace: WdReplace.wdReplaceNone);
                            sel.Range.Select();
                            axTable = sel.Tables.Add(app.Selection.Range, soil_sub.Rows.Count, 4);

                            axTable.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
                            axTable.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;

                            for (int j = 1; j <= soil_sub.Rows.Count; j++)
                            {
                                if (j == 1)
                                {
                                    axTable.Cell(j, 1).Range.Text = "Region";
                                    axTable.Cell(j, 2).Range.Text = "เส้นท่อ,ตำแหน่ง";
                                    axTable.Cell(j, 3).Range.Text = "Progress";
                                    axTable.Cell(j, 4).Range.Text = "ผลการดำเนินงาน/สิ่งที่ไม่เป็นไปตามแผน/ปัญหาอุปสรรค/แนวทางแก้ไข";
                                }
                                else
                                {
                                    axTable.Cell(j, 1).Range.Text = soil_sub.Rows[j - 1]["d3"].ToString();
                                    axTable.Cell(j, 2).Range.Text = soil_sub.Rows[j - 1]["d4"].ToString();
                                    axTable.Cell(j, 3).Range.Text = soil_sub.Rows[j - 1]["d7"].ToString();
                                    axTable.Cell(j, 4).Range.Text = soil_sub.Rows[j - 1]["d8"].ToString();
                                }
                            }
                        }
                    }


                    string time = DateTime.Now.ToString("yyyy-MM-ddHHmmss", EngCI);

                    //************************************************

                    doc.SaveAs(Server.MapPath("~/gen_1/Quaterly_report_" + time + ".docx"));
                    doc.Close();

                    var x = Serv.InsertHistory(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", EngCI), HttpContext.Current.Session["assetusername"].ToString(), "Quaterly_report",
                        "~/gen_1/Quaterly_report_" + time + ".docx", "1", "");

                    hddfile_path.Value = "~/gen_1/Quaterly_report_" + time + ".docx";

                    if (x.Rows.Count != 0)
                    {
                        Serv.UpdateHistory(x.Rows[0]["id"].ToString(), "Quaterly_report_V" + x.Rows[0]["id"].ToString(), x.Rows[0]["id"].ToString());
                    }

                    POPUPMSG("บันทึกเรียบร้อย");
                }

            }
            finally
            {
                app.Quit();
            }
        }

        protected void btnHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/history_1.aspx");
        }
    }
}