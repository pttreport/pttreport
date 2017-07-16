﻿
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using ptt_report.App_Code;
using System.Web.UI.WebControls;
using System.Text;

namespace ptt_report
{
    public partial class create_t_p_rep : System.Web.UI.Page
    {
        CultureInfo ThCI = new System.Globalization.CultureInfo("th-TH");
        CultureInfo EngCI = new System.Globalization.CultureInfo("en-US");
        create_tp_repDLL Serv = new create_tp_repDLL();

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
                }
            }
        }
        protected void bind_default()
        {
            int y = Convert.ToInt32(DateTime.Now.ToString("yyyy", EngCI));
            for (int i = 0; i <= 3; i++)
            {
                y = y + i;
                ddlyear.Items.Insert(i, new ListItem(Convert.ToString(y), Convert.ToString(y)));
            }
                        
        }

        protected void btnselect_Click(object sender, EventArgs e)
        {

            // Check Exsit or not

            if (Serv.CheckExistingTPRep(ddlyear.Text, tpPermit.Text))
            {
                POPUPMSG("ธพ Report ของปี " + ddlyear.Text + " Permit : " + tpPermit.Text + " ได้เคยถูกสร้างไว้แล้ว");
            }
            else {
                Serv.inserttbl_tp_Rep(ddlyear.Text, tpPermit.Text, "Assign", "Assign", "Assign", "Assign", "Assign", "Assign", "Assign", "Assign", "Assign", "Assign", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", EngCI), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", EngCI), HttpContext.Current.Session["assetuserid"].ToString(), HttpContext.Current.Session["assetuserid"].ToString());

                POPUPMSG("ธพ Report Year = " + ddlyear.Text + " Permit = " + tpPermit.Text + " ได้ถูกสร้าง");

                Response.Redirect("~/t_p_rep.aspx");
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            
        }

        private void POPUPMSG(string msg)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("alert(\'");
            sb.Append(msg.Replace("\n", "\\n").Replace("\r", "").Replace("\'", "\\\'"));
            sb.Append("\');");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showalert", sb.ToString(), true);
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/t_p_rep.aspx");
        }
    }
}