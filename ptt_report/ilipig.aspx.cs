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
    public partial class ilipig : System.Web.UI.Page
    {

        CultureInfo ThCI = new System.Globalization.CultureInfo("th-TH");
        CultureInfo EngCI = new System.Globalization.CultureInfo("en-US");
        ilipigDLL Serv = new ilipigDLL();


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
                hddip_id.Value = exist.Rows[0]["id"].ToString();
                txtRoutecode.Text = exist.Rows[0]["pwroutecode"].ToString();
                txtDimeter.Text = exist.Rows[0]["pwdimeter"].ToString();
                txtPipeline.Text = exist.Rows[0]["pwpipelinesection"].ToString();
                txtNumberOfPig.Text = exist.Rows[0]["pwnumberpig"].ToString();
                txtPlanning.Text = exist.Rows[0]["pwplaning"].ToString();

                txtRoutecode2.Text = exist.Rows[0]["wroutecode"].ToString();
                txtPipelineSection2.Text = exist.Rows[0]["wpipelinesection"].ToString();
                txtResult2.Text = exist.Rows[0]["wresult"].ToString();

                txtF_Routecode.Text = exist.Rows[0]["froutecode"].ToString();
                txtF_Dimeter.Text = exist.Rows[0]["fdimeter"].ToString();
                txtF_Pipeline.Text = exist.Rows[0]["fpipelinesection"].ToString();
                txtF_NumberOfPig.Text = exist.Rows[0]["fnumberpig"].ToString();
                txtF_Planning.Text = exist.Rows[0]["fplaning"].ToString();

                txtProblem.Text = exist.Rows[0]["problem"].ToString();
                txtComment.Text = exist.Rows[0]["opinion"].ToString();

            }
            else
            {
                Serv.Inserttblili_pig(hddmas_rep_id.Value, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");             
            }

        }

        protected void lnkBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/QuarterlyReport.aspx");
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            txtRoutecode.Text = "RC0290";
            txtDimeter.Text = "24";
            txtPipeline.Text = "Splan-ERP";
            txtPlanning.Text = "1 มกราคม 2560";

            txtRoutecode2.Text = "RC0290";
            txtPipelineSection2.Text = "BKT-ERP";

            txtF_Routecode.Text = "RC0290";
            txtF_Dimeter.Text = "24";
            txtF_Pipeline.Text = "Splan-ERP";
            txtF_Planning.Text = "1 มกราคม 2560";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            Serv.Updatetblili_pig(hddmas_rep_id.Value, txtRoutecode.Text, txtDimeter.Text, txtPipeline.Text, txtNumberOfPig.Text, txtPlanning.Text,txtRoutecode2.Text, txtPipelineSection2.Text, txtResult2.Text, txtF_Routecode.Text, txtF_Dimeter.Text, txtF_Pipeline.Text, txtF_NumberOfPig.Text, txtF_Planning.Text, txtProblem.Text, txtComment.Text, hddip_id.Value, HttpContext.Current.Session["assetuserid"].ToString());

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