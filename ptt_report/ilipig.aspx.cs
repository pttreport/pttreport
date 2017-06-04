using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ptt_report
{
    public partial class ilipig : System.Web.UI.Page
    {
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
                }
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
    }
}