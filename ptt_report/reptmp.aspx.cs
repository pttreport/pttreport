using ptt_report.App_Code;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ptt_report
{
    public partial class reptmp : System.Web.UI.Page
    {
        CultureInfo ThCI = new System.Globalization.CultureInfo("th-TH");
        CultureInfo EngCI = new System.Globalization.CultureInfo("en-US");
        reptmpDLL Serv = new reptmpDLL();
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
                    ddlRepType.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Quarterly Report", "1"));
                    ddlRepType.Items.Insert(1, new System.Web.UI.WebControls.ListItem("ธพ. Report", "2"));
                    ddlRepType.Items.Insert(2, new System.Web.UI.WebControls.ListItem("Pipeline Integrity Report", "3"));
                }
            }
        }
        
        protected void bing_rep_tmp()
        {

        }

        protected void btnAddTmp_Click(object sender, EventArgs e)
        {

        }
    }
}