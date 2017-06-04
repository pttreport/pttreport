using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ptt_report
{
    public partial class piping : System.Web.UI.Page
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
            lbm131.Text = "18";
            lbm132.Text = "18";

            lbm221.Text = "2";
            lbm222.Text = "2";
            lbm231.Text = "14";
            lbm232.Text = "14";
            lbm251.Text = "16";
            lbm252.Text = "16";

            lbm311.Text = "7";
            lbm312.Text = "7";

            txtRegion.Text = "1";
            txtstation.Text = "BV3";

            txtRegion2.Text = "1";
            txtCoatingCondition.Text = "Local Disbonding";
            txtstation2.Text = "BV3";
            txtCorrosion.Text = "No corrosion";

            txtRegion3.Text = "1";
            txtPipeSup.Text = "Moderate";
            txtstation3.Text = "BV3";
            txtCorrosion2.Text = "No corrosion";

            txtRegion4.Text = "1";
            txtCoating4.Text = "Moderate";
            txtstation4.Text = "BV3";
            txtCorrosion4.Text = "No corrosion";

            txtRegion5.Text = "1";
            txtInsulation.Text = "Moderate";
            txtstation5.Text = "BV3";
            txtCorrosion5.Text = "No corrosion";

            txtRegion6.Text = "1";
            txtInspection.Text = "Soil to Air";
            txtCMStation.Text = "ABPR1";
            txtdate.Text = "20/03/2017";

            lbm131_.Text = "18";
            lbm132_.Text = "18";

            lbm221_.Text = "2";
            lbm222_.Text = "2";
            lbm231_.Text = "14";
            lbm232_.Text = "14";
            lbm251_.Text = "16";
            lbm252_.Text = "16";

            lbm311_.Text = "7";
            lbm312_.Text = "7";
        }
    }
}