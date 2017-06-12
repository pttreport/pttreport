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
    public partial class otherProject : System.Web.UI.Page
    {
        CultureInfo ThCI = new System.Globalization.CultureInfo("th-TH");
        CultureInfo EngCI = new System.Globalization.CultureInfo("en-US");
        otherprojectsDLL Serv = new otherprojectsDLL();

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

                    hddmas_rep_id.Value = HttpContext.Current.Session["repid"].ToString();

                    bind_default();
                }
            }
        }

        protected void bind_default()
        {
            var rep_doc = Serv.GetRep_HisALL();
            if (rep_doc.Rows.Count != 0)
            {
                hddfile_path.Value = rep_doc.Rows[0]["uri"].ToString();
            }

            var exist = Serv.GetExistRep(hddmas_rep_id.Value);

            if (exist.Rows.Count != 0)
            {
                hddop_id.Value = exist.Rows[0]["id"].ToString();

                var sub1 = Serv.GetExistRep_sub(hddop_id.Value,"1");

                if (sub1.Rows.Count != 0)
                {
                    op1.Value = sub1.Rows[0]["id"].ToString();
                    txtProjectName1.Text = sub1.Rows[0]["projectname"].ToString();
                    txtProjectPlan1.Text = sub1.Rows[0]["planwork"].ToString();
                    txtProjectResult1.Text = sub1.Rows[0]["workresult"].ToString();
                    txtProjectPlan_future1.Text = sub1.Rows[0]["futureplan"].ToString();
                    txtProject_problem1.Text = sub1.Rows[0]["problem"].ToString();
                    txtremark1.Text = sub1.Rows[0]["opinion"].ToString();
                }
                else
                {
                    Serv.Inserttblother_projects_sub(hddop_id.Value, "1", "", "", "", "", "", "");
                }

                var sub2 = Serv.GetExistRep_sub(hddop_id.Value, "2");

                if (sub2.Rows.Count != 0)
                {
                    op2.Value = sub2.Rows[0]["id"].ToString();
                    txtProjectName2.Text = sub2.Rows[0]["projectname"].ToString();
                    txtProjectPlan2.Text = sub2.Rows[0]["planwork"].ToString();
                    txtProjectResult2.Text = sub2.Rows[0]["workresult"].ToString();
                    txtProjectPlan_future2.Text = sub2.Rows[0]["futureplan"].ToString();
                    txtProject_problem2.Text = sub2.Rows[0]["problem"].ToString();
                    txtremark2.Text = sub2.Rows[0]["opinion"].ToString();

                    divOther2.Visible = true;
                }

                var sub3 = Serv.GetExistRep_sub(hddop_id.Value, "3");

                if (sub3.Rows.Count != 0)
                {
                    op3.Value = sub3.Rows[0]["id"].ToString();
                    txtProjectName3.Text = sub3.Rows[0]["projectname"].ToString();
                    txtProjectPlan3.Text = sub3.Rows[0]["planwork"].ToString();
                    txtProjectResult3.Text = sub3.Rows[0]["workresult"].ToString();
                    txtProjectPlan_future3.Text = sub3.Rows[0]["futureplan"].ToString();
                    txtProject_problem3.Text = sub3.Rows[0]["problem"].ToString();
                    txtremark3.Text = sub3.Rows[0]["opinion"].ToString();

                    divOther3.Visible = true;
                }

                var sub4 = Serv.GetExistRep_sub(hddop_id.Value, "4");

                if (sub4.Rows.Count != 0)
                {

                    op4.Value = sub4.Rows[0]["id"].ToString();
                    txtProjectName4.Text = sub4.Rows[0]["projectname"].ToString();
                    txtProjectPlan4.Text = sub4.Rows[0]["planwork"].ToString();
                    txtProjectResult4.Text = sub4.Rows[0]["workresult"].ToString();
                    txtProjectPlan_future4.Text = sub4.Rows[0]["futureplan"].ToString();
                    txtProject_problem4.Text = sub4.Rows[0]["problem"].ToString();
                    txtremark4.Text = sub4.Rows[0]["opinion"].ToString();

                    divOther4.Visible = true;
                }

                var sub5 = Serv.GetExistRep_sub(hddop_id.Value, "5");

                if (sub5.Rows.Count != 0)
                {
                    op5.Value = sub5.Rows[0]["id"].ToString();
                    txtProjectName5.Text = sub5.Rows[0]["projectname"].ToString();
                    txtProjectPlan5.Text = sub5.Rows[0]["planwork"].ToString();
                    txtProjectResult5.Text = sub5.Rows[0]["workresult"].ToString();
                    txtProjectPlan_future5.Text = sub5.Rows[0]["futureplan"].ToString();
                    txtProject_problem5.Text = sub5.Rows[0]["problem"].ToString();
                    txtremark5.Text = sub5.Rows[0]["opinion"].ToString();

                    divOther5.Visible = true;
                }

            }
            else
            {
                var cp = Serv.Inserttblother_projects(hddmas_rep_id.Value);

                if (cp.Rows.Count != 0)
                {
                    hddop_id.Value = cp.Rows[0]["id"].ToString();
                    Serv.Inserttblother_projects_sub(hddop_id.Value,"1","","","","","","");

                }


                
            }

        }

        protected void btnImport_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddOtherPro_Click(object sender, EventArgs e)
        {
            if(divOther1.Visible == true && divOther2.Visible == false)
            {
                divOther2.Visible = true;

                Serv.Inserttblother_projects_sub(hddop_id.Value, "2", "", "", "", "", "", "");
            }
            else if (divOther2.Visible == true && divOther3.Visible == false)
            {
                divOther3.Visible = true;

                Serv.Inserttblother_projects_sub(hddop_id.Value, "3", "", "", "", "", "", "");
            }
            else if (divOther3.Visible == true && divOther4.Visible == false)
            {
                divOther4.Visible = true;

                Serv.Inserttblother_projects_sub(hddop_id.Value, "4", "", "", "", "", "", "");
            }
            else if (divOther4.Visible == true && divOther5.Visible == false)
            {
                divOther5.Visible = true;

                Serv.Inserttblother_projects_sub(hddop_id.Value, "5", "", "", "", "", "", "");
            }
        }

        protected void btnsave1_Click(object sender, EventArgs e)
        {
            Serv.Updatetblother_projects_sub(hddop_id.Value,"1", txtProjectName1.Text, txtProjectPlan1.Text, txtProjectResult1.Text, txtProjectPlan_future1.Text, txtProject_problem1.Text, txtremark1.Text, op1.Value);
            POPUPMSG("บันทึกเรียบร้อย");
        }

        protected void btnsave5_Click(object sender, EventArgs e)
        {
            Serv.Updatetblother_projects_sub(hddop_id.Value, "5", txtProjectName5.Text, txtProjectPlan5.Text, txtProjectResult5.Text, txtProjectPlan_future5.Text, txtProject_problem5.Text, txtremark5.Text, op5.Value);
            POPUPMSG("บันทึกเรียบร้อย");
        }

        protected void btnsave4_Click(object sender, EventArgs e)
        {
            Serv.Updatetblother_projects_sub(hddop_id.Value, "4", txtProjectName4.Text, txtProjectPlan4.Text, txtProjectResult4.Text, txtProjectPlan_future4.Text, txtProject_problem4.Text, txtremark4.Text, op4.Value);
            POPUPMSG("บันทึกเรียบร้อย");
        }

        protected void btnsave3_Click(object sender, EventArgs e)
        {
            Serv.Updatetblother_projects_sub(hddop_id.Value, "3", txtProjectName3.Text, txtProjectPlan3.Text, txtProjectResult3.Text, txtProjectPlan_future3.Text, txtProject_problem3.Text, txtremark3.Text, op3.Value);
            POPUPMSG("บันทึกเรียบร้อย");
        }

        protected void btnsave2_Click(object sender, EventArgs e)
        {
            Serv.Updatetblother_projects_sub(hddop_id.Value, "2", txtProjectName2.Text, txtProjectPlan2.Text, txtProjectResult2.Text, txtProjectPlan_future2.Text, txtProject_problem2.Text, txtremark2.Text, op2.Value);
            POPUPMSG("บันทึกเรียบร้อย");
        }

        private void POPUPMSG(string msg)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("alert(\'");
            sb.Append(msg.Replace("\n", "\\n").Replace("\r", "").Replace("\'", "\\\'"));
            sb.Append("\');");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showalert", sb.ToString(), true);
        }
    }
}