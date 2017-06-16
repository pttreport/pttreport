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
using Microsoft.Office.Interop.Word;

namespace ptt_report
{
    public partial class pironshoreunpig : System.Web.UI.Page
    {
        CultureInfo ThCI = new System.Globalization.CultureInfo("th-TH");
        CultureInfo EngCI = new System.Globalization.CultureInfo("en-US");
        pironsuDLL Serv = new pironsuDLL();

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
                }
            }
        }

        protected void bind_default()
        {
            var pipeline = Serv.GetPIROnSUPipeline(hddmas_rep_id.Value);
            if (pipeline.Rows.Count != 0)
            {
                pipeline_id.Value = pipeline.Rows[0]["id"].ToString();
                TextBox1.Text = pipeline.Rows[0]["startupyear"].ToString();
                TextBox2.Text = pipeline.Rows[0]["designpresure"].ToString();
                TextBox3.Text = pipeline.Rows[0]["station"].ToString();
                TextBox4.Text = pipeline.Rows[0]["maop"].ToString();
                TextBox5.Text = pipeline.Rows[0]["wallthickness"].ToString();
                TextBox6.Text = pipeline.Rows[0]["materialspec"].ToString();
                TextBox7.Text = pipeline.Rows[0]["designlife"].ToString();
                TextBox8.Text = pipeline.Rows[0]["externalcoating"].ToString();
                TextBox9.Text = pipeline.Rows[0]["cathodicprotection"].ToString();
                TextBox10.Text = pipeline.Rows[0]["op"].ToString();
                TextBox11.Text = pipeline.Rows[0]["ot"].ToString();
                TextBox12.Text = pipeline.Rows[0]["gfr"].ToString();
                TextBox13.Text = pipeline.Rows[0]["opinion"].ToString();


            }
            else
            {
                Serv.Insertpironsu_pipeline(hddmas_rep_id.Value,"","","","","","","","","","","","","","");


                var pipelineNew = Serv.GetPIROnSUPipeline(hddmas_rep_id.Value);

                if (pipelineNew.Rows.Count != 0)
                {
                    pipeline_id.Value = pipelineNew.Rows[0]["id"].ToString();
                }

            }



        }


        private void POPUPMSG(string msg)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("alert(\'");
            sb.Append(msg.Replace("\n", "\\n").Replace("\r", "").Replace("\'", "\\\'"));
            sb.Append("\');");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showalert", sb.ToString(), true);
        }

        protected void PatrollingFormSaveSubmit_Click1(object sender, EventArgs e)
        {


        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (hddfile_path.Value != "")
            {
                Response.Redirect(hddfile_path.Value);
            }
        }


        protected void btnHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/history_1.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Serv.Updatepironsu_pipeline(hddmas_rep_id.Value, TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, "", TextBox5.Text, TextBox6.Text, TextBox7.Text, TextBox8.Text, TextBox9.Text, TextBox10.Text, TextBox11.Text, TextBox12.Text, TextBox13.Text, pipeline_id.Value, HttpContext.Current.Session["assetuserid"].ToString());
        }
    }
}