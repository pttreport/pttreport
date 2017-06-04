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
    public partial class directassessment : System.Web.UI.Page
    {
        CultureInfo ThCI = new System.Globalization.CultureInfo("th-TH");
        CultureInfo EngCI = new System.Globalization.CultureInfo("en-US");
        QuarterlyReportDLL Serv = new QuarterlyReportDLL();

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
                    bind_default();
                    bind_list();
                }
            }
        }

        protected void bind_default()
        {

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

        protected void DAFormSaveSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            DADistrictPlanText1.Text = "5";
            DADistrictPlanText2.Text = "5";
            DADistrictPlanText3.Text = "5";
            DADistrictPlanText4.Text = "5";
            DADistrictPlanText5.Text = "5";

            DAPipePositionPlanText1.Text = "RC4000, KP.217+318";
            DAPipePositionPlanText2.Text = "RC4000, KP.217+318";
            DAPipePositionPlanText3.Text = "RC4000, KP.217+318";
            DAPipePositionPlanText4.Text = "RC4000, KP.217+318";
            DAPipePositionPlanText5.Text = "RC4000, KP.217+318";

            DADigPlanText1.Text = "Bistering defect";
            DADigPlanText2.Text = "Bistering defect";
            DADigPlanText3.Text = "Bistering defect";
            DADigPlanText4.Text = "Bistering defect";
            DADigPlanText5.Text = "Bistering defect";

            DALengthPlanText1.Text = "5";
            DALengthPlanText2.Text = "5";
            DALengthPlanText3.Text = "5";
            DALengthPlanText4.Text = "5";
            DALengthPlanText5.Text = "5";

            DAActualPlanText1.Text = "60";
            DAActualPlanText2.Text = "60";
            DAActualPlanText3.Text = "60";
            DAActualPlanText4.Text = "60";
            DAActualPlanText5.Text = "60";

            DADistrictResultText.Text = "5";
            DARCResultText.Text = "RC4000";
            DAHoleResultText.Text = "12";
            DANoteResultText.Text = "ดำเนินการจัดจ้างเสร็จแล้ว";

            DAMonthFutureText.Text = "เมษายน";
            DARCFutureText.Text = "RC4000";
            DAHoleFutureText.Text = "10";
        }
    }
}