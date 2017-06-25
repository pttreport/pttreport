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
    public partial class permitappendixH : System.Web.UI.Page
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
            var apdh = Serv.GetTPAppendixH(hddmas_rep_id.Value);

            if (apdh.Rows.Count != 0)
            {
                hddapdh_id.Value = apdh.Rows[0]["id"].ToString();
                AdphOpinion.Text = apdh.Rows[0]["opinion"].ToString();


                var sub = Serv.GetTPAppendixH_sub(hddapdh_id.Value);

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
                Serv.InsertTPAppendixH(hddmas_rep_id.Value, "");

                var apdhNew = Serv.GetTPAppendixH(hddmas_rep_id.Value);

                if (apdhNew.Rows.Count != 0)
                {
                    hddapdh_id.Value = apdhNew.Rows[0]["id"].ToString();

                    Serv.InsertTPAppendixH_sub(hddapdh_id.Value, "", "","");

                    var subNew = Serv.GetTPAppendixH_sub(hddapdh_id.Value);

                    if (subNew.Rows.Count != 0)
                    {
                        gv.DataSource = subNew;
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

        }

        protected void PermitFormSaveSubmit_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gv.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField hddid = (HiddenField)row.FindControl("hddid");

                    TextBox subroutecode = (TextBox)row.FindControl("subroutecode");

                    FileUpload subsecondhalfyear = (FileUpload)row.FindControl("subsecondhalfyear");

                    FileUpload subfirsthalfyear = (FileUpload)row.FindControl("subfirsthalfyear");

                    Serv.UpdateTPAppendixH_sub(hddapdh_id.Value, subroutecode.Text, subsecondhalfyear.FileName, subfirsthalfyear.FileName, hddid.Value);

                }
            }

            Serv.UpdateTPAppendixH(hddmas_rep_id.Value, AdphOpinion.Text, hddapdh_id.Value, HttpContext.Current.Session["assetuserid"].ToString());
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Serv.InsertTPAppendixH_sub(hddapdh_id.Value, "", "","");

            var sub = Serv.GetTPAppendixH_sub(hddapdh_id.Value);
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