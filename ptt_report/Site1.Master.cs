using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ptt_report
{
    public partial class Site1 : System.Web.UI.MasterPage
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
                lbname.Text = HttpContext.Current.Session["assetfname"].ToString() + " " + HttpContext.Current.Session["assetlname"].ToString();
                lbposision.Text = HttpContext.Current.Session["assetposision"].ToString();
                lbrole.Text = HttpContext.Current.Session["assetrole"].ToString();

                if (HttpContext.Current.Session["asset_who"].ToString() == "ptt")
                {
                    lnkChange_Password.Visible = false;
                }
                else
                {
                    lnkChange_Password.Visible = true;

                }
            }
        }

        protected void btnusermanage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/usermanagement.aspx");
        }

        protected void btnQuarReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/QuarterlyReport.aspx");
        }

        protected void lnkChange_Password_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/changePassword.aspx");
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Clear();
            Response.Redirect("~/Default.aspx");
        }


        protected void btnRepTem_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/reptmp.aspx");
        }
    }
}