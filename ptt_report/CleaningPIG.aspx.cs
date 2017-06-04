using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ptt_report
{
    public partial class CleaningPIG : System.Web.UI.Page
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

        protected void btnDEl_Click(object sender, EventArgs e)
        {

        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            txtRoutecode.Text = "RC0290";
            txtDimeter.Text = "24";
            txtPipeline.Text = "Splan-ERP";
            txtPlanning.Text = "1 มกราคม 2560";

            txtResult_work.Text = "รท. และเขตปฏิบัติการที่เกี่ยวข้อง สามารถ run Cleaning PIG ได้ทั้งสิ้น 10 ลูก รวม 5 เส้นท่อ โดยปรับแผนแก้ไขตามความเหมาะสมกับ\r\nระบบการรับ-จ่ายก๊าซ และข้อจำกัดต่างๆ (Constrain Condition) โดย รท. ได้บันทึกผลข้อมูล";

            txtF_Routecode.Text = "RC0290";
            txtF_Dimeter.Text = "24";
            txtF_Pipeline.Text = "Splan-ERP";
            txtF_Planning.Text = "1 มกราคม 2560";
        }
    }
}