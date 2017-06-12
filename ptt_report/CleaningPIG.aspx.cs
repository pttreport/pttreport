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

namespace ptt_report
{
    public partial class CleaningPIG : System.Web.UI.Page
    {
        CultureInfo ThCI = new System.Globalization.CultureInfo("th-TH");
        CultureInfo EngCI = new System.Globalization.CultureInfo("en-US");
        cleaningPigDLL Serv = new cleaningPigDLL();

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
                hddcp_id.Value = exist.Rows[0]["id"].ToString();
                txtworkplan.Text = exist.Rows[0]["planwork"].ToString();
                txtRoutecode.Text = exist.Rows[0]["pwroutecode"].ToString();
                txtDimeter.Text = exist.Rows[0]["pwdimeter"].ToString();
                txtPipeline.Text = exist.Rows[0]["pwpipelinesection"].ToString();
                txtNumberOfPig.Text = exist.Rows[0]["pwnumberpig"].ToString();
                txtPlanning.Text = exist.Rows[0]["pwplaning"].ToString();
                txtResult_work.Text = exist.Rows[0]["workingresult"].ToString();
                txtRemark.Text = exist.Rows[0]["notethat"].ToString();
                txtF_Routecode.Text = exist.Rows[0]["froutecode"].ToString();
                txtF_Dimeter.Text = exist.Rows[0]["fdimeter"].ToString();
                txtF_Pipeline.Text = exist.Rows[0]["fpipelinesection"].ToString();
                txtF_NumberOfPig.Text = exist.Rows[0]["fnumberpig"].ToString();
                txtF_Planning.Text = exist.Rows[0]["fplaning"].ToString();
                txtProblem.Text = exist.Rows[0]["problem"].ToString();
                txtComment.Text = exist.Rows[0]["opinion"].ToString();

                var subPig = Serv.GetExistRep_sub_pigresult(hddcp_id.Value);

                if (subPig.Rows.Count != 0)
                {
                    gvPigResult.DataSource = subPig;
                    gvPigResult.DataBind();
                }
                else
                {
                    gvPigResult.DataSource = null;
                    gvPigResult.DataBind();
                }

                var subReplan = Serv.GetExistRep_sub_replan(hddcp_id.Value);

                if (subReplan.Rows.Count != 0)
                {
                    gvReplan.DataSource = subReplan;
                    gvReplan.DataBind();
                }
                else
                {
                    gvReplan.DataSource = null;
                    gvReplan.DataBind();
                }

            }
            else
            {
                var cp = Serv.Inserttblcleaning_pig(hddmas_rep_id.Value,"","", "", "", "", "", "", "", "", "", "", "", "", "","");

                if (cp.Rows.Count != 0)
                {
                    hddcp_id.Value = cp.Rows[0]["id"].ToString();

                    Serv.Inserttblcleaningpig_sub_pigresult(hddcp_id.Value,"","","");

                    var subPig = Serv.GetExistRep_sub_pigresult(hddcp_id.Value);

                    if (subPig.Rows.Count != 0)
                    {
                        gvPigResult.DataSource = subPig;
                        gvPigResult.DataBind();
                    }
                    else
                    {
                        gvPigResult.DataSource = null;
                        gvPigResult.DataBind();
                    }

                    Serv.Inserttblcleaningpig_sub_replan(hddcp_id.Value, "", "", "");

                    var subReplan = Serv.GetExistRep_sub_replan(hddcp_id.Value);

                    if (subReplan.Rows.Count != 0)
                    {
                        gvReplan.DataSource = subReplan;
                        gvReplan.DataBind();
                    }
                    else
                    {
                        gvReplan.DataSource = null;
                        gvReplan.DataBind();
                    }
                }
            }
        }

        protected void lnkBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/QuarterlyReport.aspx");
        }

        protected void btnDEl_Click(object sender, EventArgs e)
        {

        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            txtRoutecode.Text = "RC0290";
            txtDimeter.Text = "24";
            txtPipeline.Text = "Splan-ERP";
            txtPlanning.Text = "1 มกราคม 2560";

            txtResult_work.Text = "รท. และเขตปฏิบัติการที่เกี่ยวข้อง สามารถ run Cleaning PIG ได้ทั้งสิ้น 10 ลูก รวม 5 เส้นท่อ โดยปรับแผนแก้ไขตามความเหมาะสมกับ\r\nระบบการรับ-จ่ายก๊าซ และข้อจำกัดต่างๆ (Constrain Condition) โดย รท. ได้บันทึกผลข้อมูล";

            txtF_Routecode.Text = "RC0290";
            txtF_Dimeter.Text = "24";
            txtF_Pipeline.Text = "Splan-ERP";
            txtF_Planning.Text = "1 มกราคม 2560";
        }

        protected void btnCreate2_Click(object sender, EventArgs e)
        {
            Serv.Inserttblcleaningpig_sub_replan(hddcp_id.Value, "", "", "");

            var subReplan = Serv.GetExistRep_sub_replan(hddcp_id.Value);

            if (subReplan.Rows.Count != 0)
            {
                gvReplan.DataSource = subReplan;
                gvReplan.DataBind();
            }
            else
            {
                gvReplan.DataSource = null;
                gvReplan.DataBind();
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Serv.Inserttblcleaningpig_sub_pigresult(hddcp_id.Value, "", "", "");

            var subPig = Serv.GetExistRep_sub_pigresult(hddcp_id.Value);

            if (subPig.Rows.Count != 0)
            {
                gvPigResult.DataSource = subPig;
                gvPigResult.DataBind();
            }
            else
            {
                gvPigResult.DataSource = null;
                gvPigResult.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            foreach (GridViewRow row in gvPigResult.Rows)
            {
                HiddenField hddid = (HiddenField)row.FindControl("hddpigresultid");
                TextBox routecode = (TextBox)row.FindControl("txtGridRoute");
                TextBox sectionlength = (TextBox)row.FindControl("txtSelectLength");
                TextBox status = (TextBox)row.FindControl("txtGridStatus");

                Serv.Updatetblcleaningpig_sub_pigresult(hddcp_id.Value, routecode.Text,sectionlength.Text,status.Text, hddid.Value);


            }

            foreach (GridViewRow row in gvReplan.Rows)
            {
                HiddenField hddid = (HiddenField)row.FindControl("hddreplanid");
                TextBox routecode = (TextBox)row.FindControl("txtGridRoute");
                TextBox replan = (TextBox)row.FindControl("txtReplan");
                TextBox status = (TextBox)row.FindControl("txtGridStatus");

                Serv.Updatetblcleaningpig_sub_replan(hddcp_id.Value, routecode.Text, replan.Text, status.Text, hddid.Value);

            }

            Serv.Updatetblcleaning_pig(hddmas_rep_id.Value, txtworkplan.Text, txtRoutecode.Text, txtDimeter.Text, txtPipeline.Text, txtNumberOfPig.Text, txtPlanning.Text, txtResult_work.Text, txtRemark.Text, txtF_Routecode.Text, txtF_Dimeter.Text, txtF_Pipeline.Text, txtF_NumberOfPig.Text, txtF_Planning.Text, txtProblem.Text, txtComment.Text, hddcp_id.Value, HttpContext.Current.Session["assetuserid"].ToString());

            POPUPMSG("บันทึกเรียบร้อย");
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