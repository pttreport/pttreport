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
    public partial class permitpatrolling : System.Web.UI.Page
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
            var patrolling = Serv.GetTPPatrolling(hddmas_rep_id.Value);

            if (patrolling.Rows.Count != 0)
            {
                hddtpprotrolling_id.Value = patrolling.Rows[0]["id"].ToString();

                PermitPatrolGasDetector.Text = patrolling.Rows[0]["gasdetector"].ToString();
                PermitPatrolWorkNearPipe.Text = patrolling.Rows[0]["gassiteamount"].ToString();
                PermitPatrolWorkNearPipeNote.Text = patrolling.Rows[0]["gassitedetail"].ToString();
                PermitPatrolNotiLabelAmount.Text = patrolling.Rows[0]["labelandstealamount"].ToString();
                PermitPatrolNotiLabelNote.Text = patrolling.Rows[0]["labelandstealdetail"].ToString();
                PermitPatrolTestPostAmount.Text = patrolling.Rows[0]["testpostdamageamount"].ToString();
                PermitPatrolTestPostNote.Text = patrolling.Rows[0]["testpostdamagedetail"].ToString();


                PermitPatrolAreaScourPipeAmount.Text = patrolling.Rows[0]["scourareaamount"].ToString();
                PermitPatrolAreadScourNote.Text = patrolling.Rows[0]["scourareadetail"].ToString();
                PermitPatrolPoachAmount.Text = patrolling.Rows[0]["buildingpipepathamount"].ToString();
                PermitPatrolPoachNote.Text = patrolling.Rows[0]["buildingpipepathdetail"].ToString();
                PermitPatrolROVAmount.Text = patrolling.Rows[0]["rovfreespanamount"].ToString();
                PermitPatrolROVNote.Text = patrolling.Rows[0]["rovfreespandetail"].ToString();
                PermitPatrolFeedback.Text = patrolling.Rows[0]["opinion"].ToString();

            }
            else
            {
                Serv.InserttpPatrolling(hddmas_rep_id.Value,"","","","","","","","","","","","","","");

                var protrollingNew = Serv.GetTPPatrolling(hddmas_rep_id.Value);

                if (protrollingNew.Rows.Count != 0)
                    hddtpprotrolling_id.Value = protrollingNew.Rows[0]["id"].ToString();

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
            PermitPatrolGasDetector.Text = "ไม่พบการรั่วไหล";
            PermitPatrolWorkNearPipe.Text = "64";
            PermitPatrolNotiLabelAmount.Text = "6";
            PermitPatrolTestPostAmount.Text = "3";
            PermitPatrolAreaScourPipeAmount.Text = "4";
            PermitPatrolAreadScourNote.Text = "เป็นเส้นท่อ RC400 จำนวน 2 จุด, RC0650 จำนวน 2จุด โดยทุกจุดยังคงมีความเสี่ยงต่ำ จึงคอยเฝ้าระวัง เพื่อไม่ให้เกิดผลกระทบต่อท่อส่งก๊าซธรรมชาติ";
            PermitPatrolPoachAmount.Text = "2";
            PermitPatrolROVAmount.Text = "10";
        }

        protected void PermitFormSaveSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void PermitPatrolFormSaveSubmit_Click(object sender, EventArgs e)
        {
            Serv.UpdatetpPatrolling(hddmas_rep_id.Value, PermitPatrolGasDetector.Text, PermitPatrolWorkNearPipe.Text, PermitPatrolWorkNearPipeNote.Text, PermitPatrolNotiLabelAmount.Text, PermitPatrolNotiLabelNote.Text, PermitPatrolTestPostAmount.Text, PermitPatrolTestPostNote.Text, PermitPatrolAreaScourPipeAmount.Text, PermitPatrolAreadScourNote.Text, PermitPatrolPoachAmount.Text, PermitPatrolPoachNote.Text, PermitPatrolROVAmount.Text, PermitPatrolROVNote.Text, PermitPatrolFeedback.Text, hddtpprotrolling_id.Value, HttpContext.Current.Session["assetuserid"].ToString());
        }
    }
}