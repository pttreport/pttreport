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
    public partial class permitilipig : System.Web.UI.Page
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
            var ilipig = Serv.GetTPILIPIG(hddmas_rep_id.Value);

            if (ilipig.Rows.Count != 0)
            {
                hddtpilipig_id.Value = ilipig.Rows[0]["id"].ToString();

                PermitILIPigEML.Text = ilipig.Rows[0]["externalmetalloss"].ToString();

                PermitILIPigIML.Text = ilipig.Rows[0]["internalmetalloss"].ToString();

                PermitILIPigMD.Text = ilipig.Rows[0]["mechanicaldamage"].ToString();

                PermitILIPigRemark.Text = ilipig.Rows[0]["remark"].ToString();

                PermitILIPigNote.Text = ilipig.Rows[0]["opinion"].ToString();

            }
            else
            {
                Serv.Inserttpilipig(hddmas_rep_id.Value, "","","","","");

                var ilipigNew = Serv.GetTPILIPIG(hddmas_rep_id.Value);

                if (ilipigNew.Rows.Count != 0)
                    hddtpilipig_id.Value = ilipigNew.Rows[0]["id"].ToString();
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

        private void POPUPMSG(string msg)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("alert(\'");
            sb.Append(msg.Replace("\n", "\\n").Replace("\r", "").Replace("\'", "\\\'"));
            sb.Append("\');");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showalert", sb.ToString(), true);
        }

        protected void PermitILIPigFormSaveSubmit_Click(object sender, EventArgs e)
        {
            Serv.Updatetpilipig(hddmas_rep_id.Value, PermitILIPigEML.Text, PermitILIPigIML.Text, PermitILIPigMD.Text, PermitILIPigRemark.Text, PermitILIPigNote.Text,hddtpilipig_id.Value, HttpContext.Current.Session["assetuserid"].ToString());

            POPUPMSG("บันทึกเรียบร้อย");
        }
    }
}