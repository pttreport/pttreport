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

                    Serv.Inserttblexternalcorrosion_sub_cathodicresult(hddec_id.Value,"","","","");

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

                    Serv.Inserttblexternalcorrosion_sub_cipsstatus(hddec_id.Value,"","","");

                    var subCIPSStatus =  Serv.GetExistRep_sub_cipsstatus(hddec_id.Value);

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

                    Serv.Inserttblexternalcorrosion_sub_cipsstatus_activity(hddec_id.Value,"","","","");

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

        protected void btncreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/create_quar_rep.aspx");
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            HiddenField hddrepid = (HiddenField)row.FindControl("hddrepid");

            //Serv.delete_tblquarter_rep(hddrepid.Value);
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
                    TextBox gvCIPSStatusActivityManage = (TextBox)row.FindControl("gvCIPSStatusActivityManage");

                    Serv.Updatetblexternalcorrosion_sub_cipsstatus_activity(hddec_id.Value, gvCIPSStatusActivityActivity.Text, gvCIPSStatusActivityProgress.Text, gvCIPSStatusActivityEstimatePlan.Text, gvCIPSStatusActivityManage.Text, HddCIPSStatusActivityId.Value);
                }
            }

            Serv.Updatetblexternal_corrosion(hddmas_rep_id.Value, ECResultBox.Text, ECPSPercent.Text, ECBBIPercent.Text, ECRIPercent.Text, ECIJPercent.Text, "", "", "", "", ECFuturePlanBox.Text, ECProblemBox.Text, ECFormFeedbackBox.Text, hddec_id.Value, HttpContext.Current.Session["assetuserid"].ToString());

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

        protected void btndal_Click(object sender, EventArgs e)
        {

        }
    }
}