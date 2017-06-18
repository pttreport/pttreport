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
    public partial class permitcp : System.Web.UI.Page
    {
        CultureInfo ThCI = new System.Globalization.CultureInfo("th-TH");
        CultureInfo EngCI = new System.Globalization.CultureInfo("en-US");
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
                    hddmas_rep_id.Value = "99";
                    bind_default();
                    bind_list();
                }
            }
        }

        protected void bind_default()
        {

            var cp = Serv.GetTPCP(hddmas_rep_id.Value);

            if (cp.Rows.Count != 0)
            {
                hddtpcp_id.Value = cp.Rows[0]["id"].ToString();
                PermitCPCIPSDetailBox.Text = cp.Rows[0]["cipsdetail"].ToString();
                PermitCPCIPSNoteBox.Text = cp.Rows[0]["cipsopinion"].ToString();
                PermitCPDCVGDetailBox.Text = cp.Rows[0]["dcvgdetail"].ToString();
                PermitCPDCVGNoteBox.Text = cp.Rows[0]["dcvgopinion"].ToString();
                PermitCPPTSDetailBox.Text = cp.Rows[0]["ptsdetail"].ToString();
                PermitCPPTSNoteBox.Text = cp.Rows[0]["ptsopinion"].ToString();
                PermitCPROVDetailBox.Text = cp.Rows[0]["rovdetail"].ToString();
                PermitCPROVNoteBox.Text = cp.Rows[0]["rovopinion"].ToString();

            }
            else
            {
                Serv.InserttpCP(hddmas_rep_id.Value, "","","","","","","","");

                var cpNew = Serv.GetTPCP(hddmas_rep_id.Value);

                if (cpNew.Rows.Count != 0)
                    hddtpcp_id.Value = cpNew.Rows[0]["id"].ToString();
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

        }

        protected void PermitCPFormSaveSubmit_Click(object sender, EventArgs e)
        {
            Serv.UpdatetpCP(hddmas_rep_id.Value, PermitCPCIPSDetailBox.Text,
                            PermitCPCIPSNoteBox.Text,
                            PermitCPDCVGDetailBox.Text,
                            PermitCPDCVGNoteBox.Text,
                            PermitCPPTSDetailBox.Text,
                            PermitCPPTSNoteBox.Text,
                            PermitCPROVDetailBox.Text,
                            PermitCPROVNoteBox.Text,
                            hddtpcp_id.Value, HttpContext.Current.Session["assetuserid"].ToString());
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