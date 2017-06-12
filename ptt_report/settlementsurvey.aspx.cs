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
    public partial class settlementsurvey : System.Web.UI.Page
    {
        CultureInfo ThCI = new System.Globalization.CultureInfo("th-TH");
        CultureInfo EngCI = new System.Globalization.CultureInfo("en-US");
        settlementsurveyDLL Serv = new settlementsurveyDLL();
        

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

            var exist = Serv.GetExistRep4(hddmas_rep_id.Value);
            if (exist.Rows.Count != 0)
            {
                hddss_id.Value = exist.Rows[0]["id"].ToString();
                SSResultBox.Text = exist.Rows[0]["progressresult"].ToString();
                SSFuturePlan.Text = exist.Rows[0]["futureplan"].ToString();
                SSProblemBox.Text = exist.Rows[0]["problem"].ToString();
                SSFormFeedbackBox.Text = exist.Rows[0]["opinion"].ToString();

                var sub = Serv.GetExistRep4_sub(hddss_id.Value);
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
                var ss = Serv.Inserttblsettlement_survey(hddmas_rep_id.Value, "", "", "", "");
                if (ss.Rows.Count != 0)
                {
                    hddss_id.Value = ss.Rows[0]["id"].ToString();

                    Serv.Inserttblsettlement_survey_sub(hddss_id.Value, "", "", "", "", "", "");

                    var sub = Serv.GetExistRep4_sub(hddss_id.Value);
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

        protected void SSFormSaveSubmit_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gv.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField hddid = (HiddenField)row.FindControl("hddid");
                    TextBox area = (TextBox)row.FindControl("subarea");
                    TextBox pipe = (TextBox)row.FindControl("subpipe");
                    TextBox station = (TextBox)row.FindControl("substation");
                    TextBox action = (TextBox)row.FindControl("subaction");
                    TextBox progress = (TextBox)row.FindControl("subprogress");
                    TextBox remark = (TextBox)row.FindControl("subremark");

                    Serv.Updatetblsettlement_survey_sub(hddss_id.Value, area.Text, pipe.Text, station.Text, action.Text, progress.Text, remark.Text, hddid.Value);

                }
            }

            Serv.Updatetblsettlement_survey(hddmas_rep_id.Value,SSResultBox.Text,SSFuturePlan.Text,SSProblemBox.Text,SSFormFeedbackBox.Text, hddss_id.Value, HttpContext.Current.Session["assetuserid"].ToString());

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

        protected void SSWorkPlanAddNewPlan_Click(object sender, EventArgs e)
        {
            Serv.Inserttblsettlement_survey_sub(hddss_id.Value, "", "", "", "", "", "");

            var sub = Serv.GetExistRep4_sub(hddss_id.Value);
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

        protected void btnImport_Click(object sender, EventArgs e)
        {

        }

        protected void btndal_Click(object sender, EventArgs e)
        {

        }

        protected void gv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}