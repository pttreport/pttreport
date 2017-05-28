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
    public partial class executivesummary : System.Web.UI.Page
    {
        CultureInfo ThCI = new System.Globalization.CultureInfo("th-TH");
        CultureInfo EngCI = new System.Globalization.CultureInfo("en-US");
        QuarterlyReportDLL Serv = new QuarterlyReportDLL();

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
                    bind_default();
                    bind_list();
                }
            }
        }

        protected void bind_default()
        {

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

        protected void PatrollingFormSubmit_Click(object sender, EventArgs e)
        {
            // TODO : insert all of data to DB
            
        }

        protected void RovFormSubmit_Click(object sender, EventArgs e)
        {
            // TODO : insert all of data to DB
        }

        protected void DigFormSubmit_Click(object sender, EventArgs e)
        {
            // TODO : insert all of data to DB
        }

        protected void ErosionFormSubmit_Click(object sender, EventArgs e)
        {
            // TODO : insert all of data to DB
        }

        protected void SubsideFormSubmit_Click(object sender, EventArgs e)
        {
            // TODO : insert all of data to DB
        }

        protected void ECFormSubmit_Click(object sender, EventArgs e)
        {
            // TODO : insert all of data to DB
        }

        protected void ICFormSubmit_Click(object sender, EventArgs e)
        {
            // TODO : insert all of data to DB
        }

        protected void MTPGFormSubmit_Click(object sender, EventArgs e)
        {
            // TODO : insert all of data to DB
        }

        protected void AddOtherProject_Click(object sender, EventArgs e)
        {
            // TODO : insert all of data to DB
            int currentIndex = OtherProjectList.Rows.Count + 1;
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            cell.Text = OtherProjectForm(currentIndex);
            cell.ID = "OtherProjectFormContent" + currentIndex;
            row.ID = "OtherProjectForm" + currentIndex;
            row.Cells.Add(cell);

            OtherProjectList.Rows.Add(row);
        }

        private string OtherProjectForm(int index)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table>");
            sb.Append("<tr><th colspan='2'>Other Project <asp:Button ID='OtherProjectDelete" + index +"' runat='server' Text='Delete'/></th></tr>");
            sb.Append("<tr><td>ซื้อโครงการ  : </td><td class='auto-style1'><asp:TextBox ID='OtherProjectName" + index +"' runat='server' Width='270px'></asp:TextBox></td></tr>");
            sb.Append("<tr><td>ความครบถ้วนตามแผนงาน  : </td><td class='auto-style1'><asp:TextBox ID='OtherProjectPercent" + index +"' runat='server' Width='27px'></asp:TextBox> % </td></tr>");
            sb.Append("<tr><td>ผลสรุปวิเคราะห์เบื้องต้น : </td>");
            sb.Append("<td class='auto-style1'>");
            sb.Append("<textarea id='OtherProjectAnalysis"+ index +"' runat='server' rows='2' aria-multiline='True' aria-multiselectable='False' draggable='false'></textarea>");
            sb.Append("</td></tr>");
            sb.Append("<tr><td>ประเด็นปัญหา / อุปสรรค์ : </td><td class='auto-style1'>");
            sb.Append("<textarea id='OtherProjectObstruction" + index +"' runat='server' aria-multiline='True' aria-multiselectable='False' draggable='false' cols='20' rows='2'></textarea>");
            sb.Append("</td></tr>");
            sb.Append("<tr><td>ความเห็น : </td>");
            sb.Append("<td class='auto-style1'><textarea cols='20' rows='2' runat='server' id='OtherProjectFeedback" + index +"'></textarea></td></tr>");
            sb.Append("<tr><td><asp:Button ID='OtherProjectFormSubmit" + index +"' runat='server' Text='Save'/></td><td class='auto-style1'></td></tr>");
            sb.Append("</table>");
            return sb.ToString();
        }
    }
}