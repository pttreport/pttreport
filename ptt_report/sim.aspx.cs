using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ptt_report
{
    public partial class sim : System.Web.UI.Page
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
        protected void btnImport_Click(object sender, EventArgs e)
        {

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {

        }

        protected void btnsave2_Click(object sender, EventArgs e)
        {

        }



    }
}