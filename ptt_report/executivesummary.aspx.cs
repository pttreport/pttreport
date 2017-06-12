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
using System.IO;
using Microsoft.Office.Interop.Word;

namespace ptt_report
{
    public partial class executivesummary : System.Web.UI.Page
    {
        CultureInfo ThCI = new System.Globalization.CultureInfo("th-TH");
        CultureInfo EngCI = new System.Globalization.CultureInfo("en-US");
        executivesummaryDLL Serv = new executivesummaryDLL();

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

                    if (HttpContext.Current.Session["assetapprove"].ToString() == "y")
                    {
                        btnApprove.Visible = true;
                    }
                    else
                    {
                        btnApprove.Visible = false;
                    }

                }
            }
        }

        protected void bind_default()
        {
            var rep_doc = Serv.GetRep_HisALL();
            if(rep_doc.Rows.Count != 0)
            {
                hddfile_path.Value = rep_doc.Rows[0]["uri"].ToString();
            }

            var exist_rep = Serv.GetExistRep(hddmas_rep_id.Value);
            if (exist_rep.Rows.Count != 0)
            {
                hddexecutivesummary_id.Value = exist_rep.Rows[0]["id"].ToString();

                patrolingPercent.Text = exist_rep.Rows[0]["partolling_info1"].ToString();
                BasicAnalysis.Text = exist_rep.Rows[0]["partolling_info2"].ToString();
                PatrollingObstruction.Text = exist_rep.Rows[0]["partolling_info3"].ToString();
                PatrollingFeedback.Text = exist_rep.Rows[0]["partolling_info4"].ToString();

                RovPercent.Text = exist_rep.Rows[0]["rov_info1"].ToString();
                RovAnalysis.Text = exist_rep.Rows[0]["rov_info2"].ToString();
                RovObstruction.Text = exist_rep.Rows[0]["rov_info3"].ToString();
                RovFeedback.Text = exist_rep.Rows[0]["rov_info4"].ToString();

                DigPercent.Text = exist_rep.Rows[0]["da_info1"].ToString();
                DigAnalysis.Text = exist_rep.Rows[0]["da_info2"].ToString();
                DigObstruction.Text = exist_rep.Rows[0]["da_info3"].ToString();
                DigFeedback.Text = exist_rep.Rows[0]["da_info4"].ToString();

                ErosionPercent.Text = exist_rep.Rows[0]["erosion_info1"].ToString();
                ErosionAnalysis.Text = exist_rep.Rows[0]["erosion_info2"].ToString();
                ErosionObstruction.Text = exist_rep.Rows[0]["erosion_info3"].ToString();
                ErosionFeedback.Text = exist_rep.Rows[0]["erosion_info4"].ToString();

                SubsidePercent.Text = exist_rep.Rows[0]["subsite_info1"].ToString();
                SubsideAnalysis.Text = exist_rep.Rows[0]["subsite_info2"].ToString();
                SubsideObstruction.Text = exist_rep.Rows[0]["subsite_info3"].ToString();
                SubsideFeedback.Text = exist_rep.Rows[0]["subsite_info4"].ToString();

                CPSystemPercent.Text = exist_rep.Rows[0]["exterCorr_info1"].ToString();
                CIPSPercent.Text = exist_rep.Rows[0]["exterCorr_info2"].ToString();
                ECAnalysis.Text = exist_rep.Rows[0]["exterCorr_info3"].ToString();
                ECObstruction.Text = exist_rep.Rows[0]["exterCorr_info4"].ToString();
                ECFeedback.Text = exist_rep.Rows[0]["exterCorr_info5"].ToString();

                ICCPIGPercent.Text = exist_rep.Rows[0]["interCorr_info1"].ToString();
                ICILIPIGPercent.Text = exist_rep.Rows[0]["interCorr_info2"].ToString();
                ICAnalysis.Text = exist_rep.Rows[0]["interCorr_info3"].ToString();
                ICObstruction.Text = exist_rep.Rows[0]["interCorr_info4"].ToString();
                ICFeedback.Text = exist_rep.Rows[0]["interCorr_info5"].ToString();

                MTPGPercent.Text = exist_rep.Rows[0]["da2_info1"].ToString();
                MTPGAnalysis.Text = exist_rep.Rows[0]["da2_info2"].ToString();
                MTPGObstruction.Text = exist_rep.Rows[0]["da2_info3"].ToString();
                MTPGFeedback.Text = exist_rep.Rows[0]["da2_info4"].ToString();

                OffShorePipePercent.Text = exist_rep.Rows[0]["offshore_info1"].ToString();
                OffShorePipeAnalysis.Text = exist_rep.Rows[0]["offshore_info2"].ToString();
                OffShorePipeObstruction.Text = exist_rep.Rows[0]["offshore_info3"].ToString();
                OffShorePipeFeedback.Text = exist_rep.Rows[0]["offshore_info4"].ToString();

                OffShoreBasePercent.Text = exist_rep.Rows[0]["offshore2_info1"].ToString();
                OffShoreBaseAnalysis.Text = exist_rep.Rows[0]["offshore2_info2"].ToString();
                OffShoreBaseObstruction.Text = exist_rep.Rows[0]["offshore2_info3"].ToString();
                OffShoreBaseFeedback.Text = exist_rep.Rows[0]["offshore2_info4"].ToString();

                var executive = Serv.GetExecutiveOtherRep(hddexecutivesummary_id.Value);
                if (executive.Rows.Count != 0)
                {
                    if (executive.Rows.Count == 5)
                    {
                        OtherProjectFormTable5.Visible = true;
                        OtherProjectFormTable4.Visible = true;
                        OtherProjectFormTable3.Visible = true;
                        OtherProjectFormTable2.Visible = true;
                        OtherProjectFormTable1.Visible = true;

                        hdd_idother1.Value = executive.Rows[0]["id"].ToString();
                        hdd_idother2.Value = executive.Rows[1]["id"].ToString();
                        hdd_idother3.Value = executive.Rows[2]["id"].ToString();
                        hdd_idother4.Value = executive.Rows[3]["id"].ToString();
                        hdd_idother5.Value = executive.Rows[4]["id"].ToString();

                        txtother_info1.Text = executive.Rows[0]["project_name"].ToString();
                        txtother_info2.Text = executive.Rows[0]["other_info1"].ToString();
                        txtother_info3.Text = executive.Rows[0]["other_info2"].ToString();
                        txtother_info4.Text = executive.Rows[0]["other_info3"].ToString();
                        txtother_info5.Text = executive.Rows[0]["other_info4"].ToString();

                        txtother_info12.Text = executive.Rows[1]["project_name"].ToString();
                        txtother_info22.Text = executive.Rows[1]["other_info1"].ToString();
                        txtother_info32.Text = executive.Rows[1]["other_info2"].ToString();
                        txtother_info42.Text = executive.Rows[1]["other_info3"].ToString();
                        txtother_info52.Text = executive.Rows[1]["other_info4"].ToString();

                        txtother_info13.Text = executive.Rows[2]["project_name"].ToString();
                        txtother_info23.Text = executive.Rows[2]["other_info1"].ToString();
                        txtother_info33.Text = executive.Rows[2]["other_info2"].ToString();
                        txtother_info43.Text = executive.Rows[2]["other_info3"].ToString();
                        txtother_info53.Text = executive.Rows[2]["other_info4"].ToString();

                        txtother_info14.Text = executive.Rows[3]["project_name"].ToString();
                        txtother_info24.Text = executive.Rows[3]["other_info1"].ToString();
                        txtother_info34.Text = executive.Rows[3]["other_info2"].ToString();
                        txtother_info44.Text = executive.Rows[3]["other_info3"].ToString();
                        txtother_info54.Text = executive.Rows[3]["other_info4"].ToString();

                        txtother_info15.Text = executive.Rows[4]["project_name"].ToString();
                        txtother_info25.Text = executive.Rows[4]["other_info1"].ToString();
                        txtother_info35.Text = executive.Rows[4]["other_info2"].ToString();
                        txtother_info45.Text = executive.Rows[4]["other_info3"].ToString();
                        txtother_info55.Text = executive.Rows[4]["other_info4"].ToString();


                    }
                    else if (executive.Rows.Count == 4)
                    {
                        OtherProjectFormTable4.Visible = true;
                        OtherProjectFormTable3.Visible = true;
                        OtherProjectFormTable2.Visible = true;
                        OtherProjectFormTable1.Visible = true;

                        hdd_idother1.Value = executive.Rows[0]["id"].ToString();
                        hdd_idother2.Value = executive.Rows[1]["id"].ToString();
                        hdd_idother3.Value = executive.Rows[2]["id"].ToString();
                        hdd_idother4.Value = executive.Rows[3]["id"].ToString();

                        txtother_info1.Text = executive.Rows[0]["project_name"].ToString();
                        txtother_info2.Text = executive.Rows[0]["other_info1"].ToString();
                        txtother_info3.Text = executive.Rows[0]["other_info2"].ToString();
                        txtother_info4.Text = executive.Rows[0]["other_info3"].ToString();
                        txtother_info5.Text = executive.Rows[0]["other_info4"].ToString();

                        txtother_info12.Text = executive.Rows[1]["project_name"].ToString();
                        txtother_info22.Text = executive.Rows[1]["other_info1"].ToString();
                        txtother_info32.Text = executive.Rows[1]["other_info2"].ToString();
                        txtother_info42.Text = executive.Rows[1]["other_info3"].ToString();
                        txtother_info52.Text = executive.Rows[1]["other_info4"].ToString();

                        txtother_info13.Text = executive.Rows[2]["project_name"].ToString();
                        txtother_info23.Text = executive.Rows[2]["other_info1"].ToString();
                        txtother_info33.Text = executive.Rows[2]["other_info2"].ToString();
                        txtother_info43.Text = executive.Rows[2]["other_info3"].ToString();
                        txtother_info53.Text = executive.Rows[2]["other_info4"].ToString();

                        txtother_info14.Text = executive.Rows[3]["project_name"].ToString();
                        txtother_info24.Text = executive.Rows[3]["other_info1"].ToString();
                        txtother_info34.Text = executive.Rows[3]["other_info2"].ToString();
                        txtother_info44.Text = executive.Rows[3]["other_info3"].ToString();
                        txtother_info54.Text = executive.Rows[3]["other_info4"].ToString();

                    }
                    else if (executive.Rows.Count == 3)
                    {
                        OtherProjectFormTable3.Visible = true;
                        OtherProjectFormTable2.Visible = true;
                        OtherProjectFormTable1.Visible = true;

                        hdd_idother1.Value = executive.Rows[0]["id"].ToString();
                        hdd_idother2.Value = executive.Rows[1]["id"].ToString();
                        hdd_idother3.Value = executive.Rows[2]["id"].ToString();

                        txtother_info1.Text = executive.Rows[0]["project_name"].ToString();
                        txtother_info2.Text = executive.Rows[0]["other_info1"].ToString();
                        txtother_info3.Text = executive.Rows[0]["other_info2"].ToString();
                        txtother_info4.Text = executive.Rows[0]["other_info3"].ToString();
                        txtother_info5.Text = executive.Rows[0]["other_info4"].ToString();

                        txtother_info12.Text = executive.Rows[1]["project_name"].ToString();
                        txtother_info22.Text = executive.Rows[1]["other_info1"].ToString();
                        txtother_info32.Text = executive.Rows[1]["other_info2"].ToString();
                        txtother_info42.Text = executive.Rows[1]["other_info3"].ToString();
                        txtother_info52.Text = executive.Rows[1]["other_info4"].ToString();

                        txtother_info13.Text = executive.Rows[2]["project_name"].ToString();
                        txtother_info23.Text = executive.Rows[2]["other_info1"].ToString();
                        txtother_info33.Text = executive.Rows[2]["other_info2"].ToString();
                        txtother_info43.Text = executive.Rows[2]["other_info3"].ToString();
                        txtother_info53.Text = executive.Rows[2]["other_info4"].ToString();


                    }
                    else if (executive.Rows.Count == 2)
                    {
                        OtherProjectFormTable2.Visible = true;
                        OtherProjectFormTable1.Visible = true;

                        hdd_idother1.Value = executive.Rows[0]["id"].ToString();
                        hdd_idother2.Value = executive.Rows[1]["id"].ToString();

                        txtother_info1.Text = executive.Rows[0]["project_name"].ToString();
                        txtother_info2.Text = executive.Rows[0]["other_info1"].ToString();
                        txtother_info3.Text = executive.Rows[0]["other_info2"].ToString();
                        txtother_info4.Text = executive.Rows[0]["other_info3"].ToString();
                        txtother_info5.Text = executive.Rows[0]["other_info4"].ToString();

                        txtother_info12.Text = executive.Rows[1]["project_name"].ToString();
                        txtother_info22.Text = executive.Rows[1]["other_info1"].ToString();
                        txtother_info32.Text = executive.Rows[1]["other_info2"].ToString();
                        txtother_info42.Text = executive.Rows[1]["other_info3"].ToString();
                        txtother_info52.Text = executive.Rows[1]["other_info4"].ToString();

                    }
                    else if (executive.Rows.Count == 1)
                    {
                        OtherProjectFormTable1.Visible = true;

                        hdd_idother1.Value = executive.Rows[0]["id"].ToString();

                        txtother_info1.Text = executive.Rows[0]["project_name"].ToString();
                        txtother_info2.Text = executive.Rows[0]["other_info1"].ToString();
                        txtother_info3.Text = executive.Rows[0]["other_info2"].ToString();
                        txtother_info4.Text = executive.Rows[0]["other_info3"].ToString();
                        txtother_info5.Text = executive.Rows[0]["other_info4"].ToString();
                    }
                }


            }
            else
            {
                var create_new = Serv.InsertExecutive_selectid(hddmas_rep_id.Value, "", "", "", "", "", "", "",
                    "", "", "", "", "", "", "", "", "", "", "", "",
                    "", "", "", "", "", "", "", "", "", "", "",
                    "", "", "", "", "", "", "", "", "", "", "",
                    "", "", "", "", "");

                if (create_new.Rows.Count != 0)
                {
                    hddexecutivesummary_id.Value = create_new.Rows[0]["id"].ToString();
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


        protected void PatrollingFormSubmit_Click(object sender, EventArgs e)
        {
            // TODO : insert all of data to DB
            Serv.Update_info1(patrolingPercent.Text, BasicAnalysis.Text, PatrollingObstruction.Text, PatrollingFeedback.Text, hddmas_rep_id.Value, hddexecutivesummary_id.Value, HttpContext.Current.Session["assetuserid"].ToString());
            POPUPMSG("บันทึกเรียบร้อย");

        }

        protected void RovFormSubmit_Click(object sender, EventArgs e)
        {
            // TODO : insert all of data to DB
            Serv.Update_info2(RovPercent.Text, RovAnalysis.Text, RovObstruction.Text, RovFeedback.Text, hddmas_rep_id.Value, hddexecutivesummary_id.Value, HttpContext.Current.Session["assetuserid"].ToString());
            POPUPMSG("บันทึกเรียบร้อย");
        }

        protected void DigFormSubmit_Click(object sender, EventArgs e)
        {
            // TODO : insert all of data to DB
            Serv.Update_info3(DigPercent.Text, DigAnalysis.Text, DigObstruction.Text, DigFeedback.Text, hddmas_rep_id.Value, hddexecutivesummary_id.Value, HttpContext.Current.Session["assetuserid"].ToString());
            POPUPMSG("บันทึกเรียบร้อย");
        }

        protected void ErosionFormSubmit_Click(object sender, EventArgs e)
        {
            // TODO : insert all of data to DB
            Serv.Update_info4(ErosionPercent.Text, ErosionAnalysis.Text, ErosionObstruction.Text, ErosionFeedback.Text, hddmas_rep_id.Value, hddexecutivesummary_id.Value, HttpContext.Current.Session["assetuserid"].ToString());
            POPUPMSG("บันทึกเรียบร้อย");
        }

        protected void SubsideFormSubmit_Click(object sender, EventArgs e)
        {
            // TODO : insert all of data to DB
            Serv.Update_info5(SubsidePercent.Text, SubsideAnalysis.Text, SubsideObstruction.Text, SubsideFeedback.Text, hddmas_rep_id.Value, hddexecutivesummary_id.Value, HttpContext.Current.Session["assetuserid"].ToString());
            POPUPMSG("บันทึกเรียบร้อย");
        }

        protected void ECFormSubmit_Click(object sender, EventArgs e)
        {
            Serv.Update_info6(CPSystemPercent.Text, CIPSPercent.Text, ECAnalysis.Text, ECObstruction.Text, ECFeedback.Text, hddmas_rep_id.Value, hddexecutivesummary_id.Value, HttpContext.Current.Session["assetuserid"].ToString());
            POPUPMSG("บันทึกเรียบร้อย");
            // TODO : insert all of data to DB
        }

        protected void ICFormSubmit_Click(object sender, EventArgs e)
        {
            // TODO : insert all of data to DB
            Serv.Update_info7(ICCPIGPercent.Text, ICILIPIGPercent.Text, ICAnalysis.Text, ICObstruction.Text, ICFeedback.Text, hddmas_rep_id.Value, hddexecutivesummary_id.Value, HttpContext.Current.Session["assetuserid"].ToString());
            POPUPMSG("บันทึกเรียบร้อย");
        }

        protected void MTPGFormSubmit_Click(object sender, EventArgs e)
        {
            // TODO : insert all of data to DB
            Serv.Update_info8(MTPGPercent.Text, MTPGAnalysis.Text, MTPGObstruction.Text, MTPGFeedback.Text, hddmas_rep_id.Value, hddexecutivesummary_id.Value, HttpContext.Current.Session["assetuserid"].ToString());
            POPUPMSG("บันทึกเรียบร้อย");
        }

        protected void OffShorePipeFormSubmit_Click(object sender, EventArgs e)
        {
            Serv.Update_info9(OffShorePipePercent.Text, OffShorePipeAnalysis.Text, OffShorePipeObstruction.Text, OffShorePipeFeedback.Text, hddmas_rep_id.Value, hddexecutivesummary_id.Value, HttpContext.Current.Session["assetuserid"].ToString());
            POPUPMSG("บันทึกเรียบร้อย");
        }

        protected void OffShoreBaseFormSubmit_Click(object sender, EventArgs e)
        {
            Serv.Update_info10(OffShoreBasePercent.Text, OffShoreBaseAnalysis.Text, OffShoreBaseObstruction.Text, OffShoreBaseFeedback.Text, hddmas_rep_id.Value, hddexecutivesummary_id.Value, HttpContext.Current.Session["assetuserid"].ToString());
            POPUPMSG("บันทึกเรียบร้อย");
        }

        protected void AddOtherProject_Click(object sender, EventArgs e)
        {
            if (OtherProjectFormTable1.Visible == false)
            {
                OtherProjectFormTable1.Visible = true;
            }
            else if (OtherProjectFormTable2.Visible == false)
            {
                OtherProjectFormTable2.Visible = true;
            }
            else if (OtherProjectFormTable3.Visible == false)
            {
                OtherProjectFormTable3.Visible = true;
            }
            else if (OtherProjectFormTable4.Visible == false)
            {
                OtherProjectFormTable4.Visible = true;
            }
            else if (OtherProjectFormTable5.Visible == false)
            {
                OtherProjectFormTable5.Visible = true;
            }
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            patrolingPercent.Text = "24";
            DigPercent.Text = "55";
            DigAnalysis.Text = "แผนงานขุดซ่อม\r\nILI: ขุดแล้ว\r\nDCVG:ขุดแล้ว\r\nอื่นๆ, ขุดแล้ว";

            CPSystemPercent.Text = "28";
            CIPSPercent.Text = "8";
            ICCPIGPercent.Text = "41";
            ICILIPIGPercent.Text = "0";
            MTPGPercent.Text = "33";
        }

        protected void btndelother1_Click(object sender, EventArgs e)
        {
            OtherProjectFormTable1.Visible = false;
            if (hdd_idother1.Value != "")
            {
                //delete
                Serv.DeleteOtherPro(hddexecutivesummary_id.Value, hdd_idother1.Value);
            }
        }

        protected void btnSaveOther1_Click(object sender, EventArgs e)
        {
            if (hdd_idother1.Value == "")
            {
                //insert
                var insert = Serv.InsertOtherProject(hddexecutivesummary_id.Value, txtother_info1.Text, txtother_info2.Text, txtother_info3.Text, txtother_info4.Text, txtother_info5.Text);
                if (insert.Rows.Count != 0)
                {
                    hdd_idother1.Value = insert.Rows[0]["id"].ToString();
                }
            }
            else
            {
                //update
                Serv.UpdateOtherPro(hdd_idother1.Value, hddexecutivesummary_id.Value, txtother_info1.Text, txtother_info2.Text, txtother_info3.Text, txtother_info4.Text, txtother_info5.Text);
            }
        }

        protected void btnSaveOther2_Click(object sender, EventArgs e)
        {
            if (hdd_idother2.Value == "")
            {
                //insert
                var insert = Serv.InsertOtherProject(hddexecutivesummary_id.Value, txtother_info12.Text, txtother_info22.Text, txtother_info32.Text, txtother_info42.Text, txtother_info52.Text);
                if (insert.Rows.Count != 0)
                {
                    hdd_idother2.Value = insert.Rows[0]["id"].ToString();
                }
            }
            else
            {
                //update
                Serv.UpdateOtherPro(hdd_idother2.Value, hddexecutivesummary_id.Value, txtother_info12.Text, txtother_info22.Text, txtother_info32.Text, txtother_info42.Text, txtother_info52.Text);
            }
        }

        protected void btnSaveOther3_Click(object sender, EventArgs e)
        {
            if (hdd_idother3.Value == "")
            {
                //insert
                var insert = Serv.InsertOtherProject(hddexecutivesummary_id.Value, txtother_info13.Text, txtother_info23.Text, txtother_info33.Text, txtother_info43.Text, txtother_info53.Text);
                if (insert.Rows.Count != 0)
                {
                    hdd_idother3.Value = insert.Rows[0]["id"].ToString();
                }
            }
            else
            {
                //update
                Serv.UpdateOtherPro(hdd_idother3.Value, hddexecutivesummary_id.Value, txtother_info13.Text, txtother_info23.Text, txtother_info33.Text, txtother_info43.Text, txtother_info53.Text);
            }
        }

        protected void btnSaveOther4_Click(object sender, EventArgs e)
        {
            if (hdd_idother4.Value == "")
            {
                //insert
                var insert = Serv.InsertOtherProject(hddexecutivesummary_id.Value, txtother_info14.Text, txtother_info24.Text, txtother_info34.Text, txtother_info44.Text, txtother_info54.Text);
                if (insert.Rows.Count != 0)
                {
                    hdd_idother4.Value = insert.Rows[0]["id"].ToString();
                }
            }
            else
            {
                //update
                Serv.UpdateOtherPro(hdd_idother4.Value, hddexecutivesummary_id.Value, txtother_info14.Text, txtother_info24.Text, txtother_info34.Text, txtother_info44.Text, txtother_info54.Text);
            }
        }

        protected void btnSaveOther5_Click(object sender, EventArgs e)
        {
            if (hdd_idother5.Value == "")
            {
                //insert
                var insert = Serv.InsertOtherProject(hddexecutivesummary_id.Value, txtother_info15.Text, txtother_info25.Text, txtother_info35.Text, txtother_info45.Text, txtother_info55.Text);
                if (insert.Rows.Count != 0)
                {
                    hdd_idother5.Value = insert.Rows[0]["id"].ToString();
                }
            }
            else
            {
                //update
                Serv.UpdateOtherPro(hdd_idother5.Value, hddexecutivesummary_id.Value, txtother_info15.Text, txtother_info25.Text, txtother_info35.Text, txtother_info45.Text, txtother_info55.Text);
            }
        }

        protected void btndelother2_Click(object sender, EventArgs e)
        {
            OtherProjectFormTable2.Visible = false;
            if (hdd_idother2.Value != "")
            {
                //delete
                Serv.DeleteOtherPro(hddexecutivesummary_id.Value, hdd_idother2.Value);
            }
        }

        protected void btndelother3_Click(object sender, EventArgs e)
        {
            OtherProjectFormTable3.Visible = false;
            if (hdd_idother3.Value != "")
            {
                //delete
                Serv.DeleteOtherPro(hddexecutivesummary_id.Value, hdd_idother3.Value);
            }
        }

        protected void btndelother4_Click(object sender, EventArgs e)
        {
            OtherProjectFormTable4.Visible = false;
            if (hdd_idother4.Value != "")
            {
                //delete
                Serv.DeleteOtherPro(hddexecutivesummary_id.Value, hdd_idother4.Value);
            }
        }

        protected void btndelother5_Click(object sender, EventArgs e)
        {
            OtherProjectFormTable5.Visible = false;
            if (hdd_idother5.Value != "")
            {
                //delete
                Serv.DeleteOtherPro(hddexecutivesummary_id.Value, hdd_idother5.Value);
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
                    var rep_a = Serv.GetExistRep(hddmas_rep_id.Value);
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
                        sel.Find.Replacement.Text = rep_a.Rows[0]["partolling_info1"].ToString().Replace("\r\n","\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa1]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["partolling_info2"].ToString().Replace("\r\n","\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa2]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["partolling_info3"].ToString().Replace("\r\n","\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa3]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["rov_info1"].ToString().Replace("\r\n","\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa4]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["rov_info2"].ToString().Replace("\r\n","\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa5]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["rov_info3"].ToString().Replace("\r\n","\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa6]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["da_info1"].ToString().Replace("\r\n","\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa7]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["da_info2"].ToString().Replace("\r\n","\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa8]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["da_info3"].ToString().Replace("\r\n","\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa9]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["erosion_info1"].ToString().Replace("\r\n","\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa10]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["erosion_info2"].ToString().Replace("\r\n","\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa11]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["erosion_info3"].ToString().Replace("\r\n","\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa12]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["subsite_info1"].ToString().Replace("\r\n","\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa13]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["subsite_info2"].ToString().Replace("\r\n","\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa14]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["subsite_info3"].ToString().Replace("\r\n","\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa15]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["exterCorr_info1"].ToString().Replace("\r\n","\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa16]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["exterCorr_info2"].ToString().Replace("\r\n","\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa17]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["exterCorr_info3"].ToString().Replace("\r\n","\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa18]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["exterCorr_info4"].ToString().Replace("\r\n","\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa19]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["interCorr_info1"].ToString().Replace("\r\n","\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa20]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["interCorr_info2"].ToString().Replace("\r\n","\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa21]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["interCorr_info3"].ToString().Replace("\r\n","\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa22]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["interCorr_info4"].ToString().Replace("\r\n","\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa23]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["da2_info1"].ToString().Replace("\r\n","\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa24]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["da2_info2"].ToString().Replace("\r\n","\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa25]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["da2_info3"].ToString().Replace("\r\n","\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa26]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["offshore_info1"].ToString().Replace("\r\n","\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa27]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["offshore_info2"].ToString().Replace("\r\n","\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa28]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["offshore_info3"].ToString().Replace("\r\n","\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa29]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["offshore2_info1"].ToString().Replace("\r\n","\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa30]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["offshore2_info2"].ToString().Replace("\r\n","\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa31]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["offshore2_info3"].ToString().Replace("\r\n","\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        var executive = Serv.GetExecutiveOtherRep(hddexecutivesummary_id.Value);
                        if (executive.Rows.Count != 0)
                        {
                            if (executive.Rows.Count == 5)
                            {
                                sel.Find.Text = "[qa32]";
                                sel.Find.Replacement.Text = executive.Rows[0]["project_name"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa33]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info1"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa34]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info2"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa35]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info3"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa36]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info1"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa37]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info2"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa38]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info3"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa39]";
                                sel.Find.Replacement.Text = executive.Rows[2]["other_info1"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa40]";
                                sel.Find.Replacement.Text = executive.Rows[2]["other_info2"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa41]";
                                sel.Find.Replacement.Text = executive.Rows[2]["other_info3"].ToString().Replace("\r\n","\v");
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
                                sel.Find.Replacement.Text = executive.Rows[0]["project_name"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa33]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info1"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa34]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info2"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa35]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info3"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa36]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info1"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa37]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info2"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa38]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info3"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa39]";
                                sel.Find.Replacement.Text = executive.Rows[2]["other_info1"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa40]";
                                sel.Find.Replacement.Text = executive.Rows[2]["other_info2"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa41]";
                                sel.Find.Replacement.Text = executive.Rows[2]["other_info3"].ToString().Replace("\r\n","\v");
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
                                sel.Find.Replacement.Text = executive.Rows[0]["project_name"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa33]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info1"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa34]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info2"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa35]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info3"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa36]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info1"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa37]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info2"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa38]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info3"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa39]";
                                sel.Find.Replacement.Text = executive.Rows[2]["other_info1"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa40]";
                                sel.Find.Replacement.Text = executive.Rows[2]["other_info2"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa41]";
                                sel.Find.Replacement.Text = executive.Rows[2]["other_info3"].ToString().Replace("\r\n","\v");
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
                                sel.Find.Replacement.Text = executive.Rows[0]["project_name"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa33]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info1"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa34]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info2"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa35]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info3"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa36]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info1"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa37]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info2"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa38]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info3"].ToString().Replace("\r\n","\v");
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
                                sel.Find.Replacement.Text = executive.Rows[0]["project_name"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa33]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info1"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa34]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info2"].ToString().Replace("\r\n","\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa35]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info3"].ToString().Replace("\r\n","\v");
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

        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (hddfile_path.Value != "")
            {
                Response.Redirect(hddfile_path.Value);
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            Serv.UpdateStatus_rep(hddmas_rep_id.Value, HttpContext.Current.Session["assetuserid"].ToString());
        }
    }
}