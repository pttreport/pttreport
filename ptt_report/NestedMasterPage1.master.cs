using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ptt_report
{
    public partial class NestedMasterPage1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Object objUserTheme = HttpContext.Current.Session["assetuserid"];
            if (objUserTheme == null)
            {
                Response.Redirect("~/default.aspx");
            }
            else
            {
                lbYear.Text = HttpContext.Current.Session["repYear"].ToString();
                lbQuarter.Text = HttpContext.Current.Session["repQuar"].ToString();
            }
        }

        protected void lnkExecut_sum_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Execut_sum.aspx");
        }

        protected void lnkPatrolling_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ilipig.aspx");

        }

        protected void lnkDirectAsset_Click(object sender, EventArgs e)
        {

        }

        protected void lnkSett_Click(object sender, EventArgs e)
        {

        }

        protected void lnkROV_Click(object sender, EventArgs e)
        {

        }

        protected void lnkFreeSpan_Click(object sender, EventArgs e)
        {

        }

        protected void lnkExternalCorrosion_Click(object sender, EventArgs e)
        {

        }

        protected void lnkCleaningPIG_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CleaningPIG.aspx");
        }

        protected void lnkILIPIG_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ilipig.aspx");
        }

        protected void lnkChemicalThreatment_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ChemicalThreatment.aspx");
        }

        protected void lnkPiping_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/piping.aspx");
        }

        protected void lnkRBI_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/rbi.aspx");
        }

        protected void lnkSIM_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/sim.aspx");
        }

        protected void lnkOtherProjects_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/otherProject.aspx");
        }
    }
}