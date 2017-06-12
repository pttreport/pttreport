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
    public partial class rov : System.Web.UI.Page
    {
        CultureInfo ThCI = new System.Globalization.CultureInfo("th-TH");
        CultureInfo EngCI = new System.Globalization.CultureInfo("en-US");
        rovDLL Serv = new rovDLL();

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

            var exist = Serv.GetExistRep5(hddmas_rep_id.Value);
            if (exist.Rows.Count != 0)
            {
                hddrov_id.Value = exist.Rows[0]["id"].ToString();
                ROVWorkPlanBox.Text = exist.Rows[0]["planwork"].ToString();
                ROVResultBox.Text = exist.Rows[0]["workresult"].ToString();
                ROVFuturePlanBox.Text = exist.Rows[0]["planworkfuture"].ToString();
                ROVProblemBox.Text = exist.Rows[0]["problem"].ToString();
                ROVFormFeedbackBox.Text = exist.Rows[0]["opinion"].ToString();
            }
            else
            {
                Serv.Inserttblrov(hddmas_rep_id.Value, "", "", "", "","");
            }

        }


        protected void btncreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/create_quar_rep.aspx");
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

        protected void ROVFormSaveSubmit_Click(object sender, EventArgs e)
        {
            Serv.Updatetblrov(hddmas_rep_id.Value,
                ROVWorkPlanBox.Text,
                ROVResultBox.Text,
                ROVFuturePlanBox.Text,
                ROVProblemBox.Text,
                ROVFormFeedbackBox.Text, 
                hddrov_id.Value, 
                HttpContext.Current.Session["assetuserid"].ToString());

            POPUPMSG("บันทึกเรียบร้อย");
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {

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