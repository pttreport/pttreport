using ptt_report.App_Code;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ptt_report
{
    public partial class reptmp_add : System.Web.UI.Page
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

                    bind_default();
                }
            }
        }

        protected void bind_default()
        {
            var x = Serv.GetRep_tmp();
            if(x.Rows.Count != 0)
            {
                hddTmpid.Value = x.Rows[0]["id"].ToString();
                lbFileName.Text = x.Rows[0]["report_name"].ToString();
                hddfile_path.Value = x.Rows[0]["file_path"].ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int version = 0;

            var x = Serv.GetVersion_repType(ddlRepType.SelectedValue);
            if (x.Rows.Count != 0)
            {
                version = Convert.ToInt32(x.Rows[0]["version"].ToString()) + 1;
            }
            else
            {
                version = 1;
            }

            if (FileUpload1.HasFile)
            {
                string filename = Path.GetFileName(FileUpload1.FileName);
                FileUpload1.SaveAs(Server.MapPath("~/doc_tmp/") + filename);

                Serv.Update_TMP_REP();

                Serv.Insert_TMP_REP(ddlRepType.SelectedValue, ddlRepType.SelectedItem.Text + " Template V." + version, Server.MapPath("~/doc_tmp/") + filename, "~/doc_tmp/" + filename, HttpContext.Current.Session["assetusername"].ToString(),
                    DateTime.Now.ToString("yyyy-MM-dd", EngCI), HttpContext.Current.Session["assetusername"].ToString(), Convert.ToString(version), "y");

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('บันทึกเรียบร้อย');window.location ='reptmp.aspx';", true);

            }
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            Response.Redirect(hddfile_path.Value);
        }
    }
}