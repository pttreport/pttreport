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
    public partial class ChemicalThreatment : System.Web.UI.Page
    {
        CultureInfo ThCI = new System.Globalization.CultureInfo("th-TH");
        CultureInfo EngCI = new System.Globalization.CultureInfo("en-US");
        chemicaltreatmentDLL Serv = new chemicaltreatmentDLL();

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
                hddct_id.Value = exist.Rows[0]["id"].ToString();
                txtdetail.Text = exist.Rows[0]["detail"].ToString();
                txtComment.Text = exist.Rows[0]["opinion"].ToString();
            }
            else
            {
                Serv.Inserttblchemical_treatment(hddmas_rep_id.Value, "", "");
            }
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {

        }

        protected void lnkBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/QuarterlyReport.aspx");
        }

        private void POPUPMSG(string msg)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("alert(\'");
            sb.Append(msg.Replace("\n", "\\n").Replace("\r", "").Replace("\'", "\\\'"));
            sb.Append("\');");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showalert", sb.ToString(), true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Serv.Updatetblchemical_treatment(hddmas_rep_id.Value, txtdetail.Text, txtComment.Text, hddct_id.Value, HttpContext.Current.Session["assetuserid"].ToString());

            POPUPMSG("บันทึกเรียบร้อย");
        }
    }
}