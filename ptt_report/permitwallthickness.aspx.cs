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
    public partial class permitwallthickness : System.Web.UI.Page
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
            var rep_wtn = Serv.GetTPwtn(hddmas_rep_id.Value);

            if (rep_wtn.Rows.Count != 0)
            {
                hddwn_id.Value = rep_wtn.Rows[0]["id"].ToString();

                PermitWallThicknessResult.Text = rep_wtn.Rows[0]["checkresult"].ToString();

                wtnpipe.Text = rep_wtn.Rows[0]["pipe"].ToString();

                wtnstation.Text = rep_wtn.Rows[0]["station"].ToString();

                wtnpipeposition.Text = rep_wtn.Rows[0]["pipeposition"].ToString();

                wtnopinion.Text = rep_wtn.Rows[0]["opinion"].ToString();

                var sub = Serv.GetTPwtn_sub(hddwn_id.Value);

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
               var wtn = Serv.Inserttpwtm(hddmas_rep_id.Value,"","","","","");

                if (wtn.Rows.Count != 0)
                {
                    hddwn_id.Value = wtn.Rows[0]["id"].ToString();

                    Serv.Inserttpwtn_sub(hddwn_id.Value,"","","","","","","");

                    var sub = Serv.GetTPwtn_sub(hddwn_id.Value);

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
            wtnopinion.Text = "ท่อก๊าซดังกล่าว ส่วนใหญ่ยังคงมีความหนาท่อในระดับปกติ ทั้งนี้พบท่อที่มีการสูญเสียเนื้อเหล็กอย่างมีนัยสำคัญดังนี้";
        }

        protected void PermitFormSaveSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Serv.Inserttpwtn_sub(hddwn_id.Value, "","","","","","","");

            var sub = Serv.GetTPwtn_sub(hddwn_id.Value);
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

        protected void PermitFormSaveSubmit_Click1(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gv.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField hddid = (HiddenField)row.FindControl("hddid");

                    TextBox bvstation = (TextBox)row.FindControl("subbvstation");

                    TextBox routecode = (TextBox)row.FindControl("subroutecode");

                    TextBox inspectiondate = (TextBox)row.FindControl("subinspectiondate");

                    TextBox point = (TextBox)row.FindControl("subpoint");

                    TextBox diameter = (TextBox)row.FindControl("subdiameter");

                    TextBox tavg = (TextBox)row.FindControl("subtavg");

                    TextBox tmin = (TextBox)row.FindControl("subtmin");

                    Serv.Updatetpwtn_sub(hddwn_id.Value,bvstation.Text,routecode.Text, inspectiondate.Text,point.Text, diameter.Text, tavg.Text,tmin.Text, hddid.Value);
                }
            }

            Serv.Updatetpwtn(hddmas_rep_id.Value, PermitWallThicknessResult.Text, wtnpipe.Text, wtnstation.Text, wtnpipeposition.Text, wtnopinion.Text, hddwn_id.Value, HttpContext.Current.Session["assetuserid"].ToString());

        }
    }
}