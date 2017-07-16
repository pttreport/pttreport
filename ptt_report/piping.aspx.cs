using Microsoft.Office.Interop.Word;
using ptt_report.App_Code;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ptt_report
{
    public partial class piping : System.Web.UI.Page
    {
        CultureInfo ThCI = new System.Globalization.CultureInfo("th-TH");
        CultureInfo EngCI = new System.Globalization.CultureInfo("en-US");
        pipingDLL Serv = new pipingDLL();
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

            var exist = Serv.GetExistRep_L(hddmas_rep_id.Value);
            if (exist.Rows.Count != 0)
            {
                hddpiping_id.Value = exist.Rows[0]["id"].ToString();
                txtComment.Text = exist.Rows[0]["opinion"].ToString();


                var sub_piping1 = Serv.Get_tbl_piping_qurter_plan1(hddpiping_id.Value);
                if (sub_piping1.Rows.Count != 0)
                {
                    for (int i = 0; i <= sub_piping1.Rows.Count - 1; i++)
                    {
                        if (i == 0)
                        {
                            lbQuarter.Text = sub_piping1.Rows[i]["l1"].ToString();
                            lbM1.Text = sub_piping1.Rows[i]["l2"].ToString();

                            if (sub_piping1.Rows[i]["type"].ToString() == "1")
                            {
                                lbm111.Text = sub_piping1.Rows[i]["l3"].ToString();
                                lbm112.Text = sub_piping1.Rows[i]["l4"].ToString();
                            }
                            else if (sub_piping1.Rows[i]["type"].ToString() == "2")
                            {
                                lbm121.Text = sub_piping1.Rows[i]["l3"].ToString();
                                lbm122.Text = sub_piping1.Rows[i]["l4"].ToString();
                            }
                            else if (sub_piping1.Rows[i]["type"].ToString() == "3")
                            {
                                lbm131.Text = sub_piping1.Rows[i]["l3"].ToString();
                                lbm132.Text = sub_piping1.Rows[i]["l4"].ToString();
                            }
                            else if (sub_piping1.Rows[i]["type"].ToString() == "4")
                            {
                                lbm141.Text = sub_piping1.Rows[i]["l3"].ToString();
                                lbm142.Text = sub_piping1.Rows[i]["l4"].ToString();
                            }
                            else if (sub_piping1.Rows[i]["type"].ToString() == "5")
                            {
                                lbm151.Text = sub_piping1.Rows[i]["l3"].ToString();
                                lbm152.Text = sub_piping1.Rows[i]["l4"].ToString();
                            }
                            else if (sub_piping1.Rows[i]["type"].ToString() == "6")
                            {
                                lbm161.Text = sub_piping1.Rows[i]["l3"].ToString();
                                lbm162.Text = sub_piping1.Rows[i]["l4"].ToString();
                            }
                            else if (sub_piping1.Rows[i]["type"].ToString() == "7")
                            {
                                lbm171.Text = sub_piping1.Rows[i]["l3"].ToString();
                                lbm172.Text = sub_piping1.Rows[i]["l4"].ToString();
                            }
                            else if (sub_piping1.Rows[i]["type"].ToString() == "8")
                            {
                                lbm181.Text = sub_piping1.Rows[i]["l3"].ToString();
                                lbm182.Text = sub_piping1.Rows[i]["l4"].ToString();
                            }
                            else if (sub_piping1.Rows[i]["type"].ToString() == "9")
                            {
                                lbm191.Text = sub_piping1.Rows[i]["l3"].ToString();
                                lbm192.Text = sub_piping1.Rows[i]["l4"].ToString();
                            }
                            else if (sub_piping1.Rows[i]["type"].ToString() == "10")
                            {
                                lbm101.Text = sub_piping1.Rows[i]["l3"].ToString();
                                lbm102.Text = sub_piping1.Rows[i]["l4"].ToString();
                            }

                        }
                        else if (i == 1)
                        {
                            lbQuarter.Text = sub_piping1.Rows[i]["l1"].ToString();
                            lbM2.Text = sub_piping1.Rows[i]["l2"].ToString();

                            if (sub_piping1.Rows[i]["type"].ToString() == "1")
                            {
                                lbm211.Text = sub_piping1.Rows[i]["l3"].ToString();
                                lbm212.Text = sub_piping1.Rows[i]["l4"].ToString();
                            }
                            else if (sub_piping1.Rows[i]["type"].ToString() == "2")
                            {
                                lbm221.Text = sub_piping1.Rows[i]["l3"].ToString();
                                lbm222.Text = sub_piping1.Rows[i]["l4"].ToString();
                            }
                            else if (sub_piping1.Rows[i]["type"].ToString() == "3")
                            {
                                lbm231.Text = sub_piping1.Rows[i]["l3"].ToString();
                                lbm232.Text = sub_piping1.Rows[i]["l4"].ToString();
                            }
                            else if (sub_piping1.Rows[i]["type"].ToString() == "4")
                            {
                                lbm241.Text = sub_piping1.Rows[i]["l3"].ToString();
                                lbm242.Text = sub_piping1.Rows[i]["l4"].ToString();
                            }
                            else if (sub_piping1.Rows[i]["type"].ToString() == "5")
                            {
                                lbm251.Text = sub_piping1.Rows[i]["l3"].ToString();
                                lbm252.Text = sub_piping1.Rows[i]["l4"].ToString();
                            }
                            else if (sub_piping1.Rows[i]["type"].ToString() == "6")
                            {
                                lbm261.Text = sub_piping1.Rows[i]["l3"].ToString();
                                lbm262.Text = sub_piping1.Rows[i]["l4"].ToString();
                            }
                            else if (sub_piping1.Rows[i]["type"].ToString() == "7")
                            {
                                lbm271.Text = sub_piping1.Rows[i]["l3"].ToString();
                                lbm272.Text = sub_piping1.Rows[i]["l4"].ToString();
                            }
                            else if (sub_piping1.Rows[i]["type"].ToString() == "8")
                            {
                                lbm281.Text = sub_piping1.Rows[i]["l3"].ToString();
                                lbm282.Text = sub_piping1.Rows[i]["l4"].ToString();
                            }
                            else if (sub_piping1.Rows[i]["type"].ToString() == "9")
                            {
                                lbm291.Text = sub_piping1.Rows[i]["l3"].ToString();
                                lbm292.Text = sub_piping1.Rows[i]["l4"].ToString();
                            }
                            else if (sub_piping1.Rows[i]["type"].ToString() == "10")
                            {
                                lbm201.Text = sub_piping1.Rows[i]["l3"].ToString();
                                lbm202.Text = sub_piping1.Rows[i]["l4"].ToString();
                            }

                        }
                        else if (i == 2)
                        {
                            lbQuarter.Text = sub_piping1.Rows[i]["l1"].ToString();
                            lbM3.Text = sub_piping1.Rows[i]["l2"].ToString();

                            if (sub_piping1.Rows[i]["type"].ToString() == "1")
                            {
                                lbm311.Text = sub_piping1.Rows[i]["l3"].ToString();
                                lbm312.Text = sub_piping1.Rows[i]["l4"].ToString();
                            }
                            else if (sub_piping1.Rows[i]["type"].ToString() == "2")
                            {
                                lbm321.Text = sub_piping1.Rows[i]["l3"].ToString();
                                lbm322.Text = sub_piping1.Rows[i]["l4"].ToString();
                            }
                            else if (sub_piping1.Rows[i]["type"].ToString() == "3")
                            {
                                lbm331.Text = sub_piping1.Rows[i]["l3"].ToString();
                                lbm332.Text = sub_piping1.Rows[i]["l4"].ToString();
                            }
                            else if (sub_piping1.Rows[i]["type"].ToString() == "4")
                            {
                                lbm341.Text = sub_piping1.Rows[i]["l3"].ToString();
                                lbm342.Text = sub_piping1.Rows[i]["l4"].ToString();
                            }
                            else if (sub_piping1.Rows[i]["type"].ToString() == "5")
                            {
                                lbm351.Text = sub_piping1.Rows[i]["l3"].ToString();
                                lbm352.Text = sub_piping1.Rows[i]["l4"].ToString();
                            }
                            else if (sub_piping1.Rows[i]["type"].ToString() == "6")
                            {
                                lbm361.Text = sub_piping1.Rows[i]["l3"].ToString();
                                lbm362.Text = sub_piping1.Rows[i]["l4"].ToString();
                            }
                            else if (sub_piping1.Rows[i]["type"].ToString() == "7")
                            {
                                lbm371.Text = sub_piping1.Rows[i]["l3"].ToString();
                                lbm372.Text = sub_piping1.Rows[i]["l4"].ToString();
                            }
                            else if (sub_piping1.Rows[i]["type"].ToString() == "8")
                            {
                                lbm381.Text = sub_piping1.Rows[i]["l3"].ToString();
                                lbm382.Text = sub_piping1.Rows[i]["l4"].ToString();
                            }
                            else if (sub_piping1.Rows[i]["type"].ToString() == "9")
                            {
                                lbm391.Text = sub_piping1.Rows[i]["l3"].ToString();
                                lbm392.Text = sub_piping1.Rows[i]["l4"].ToString();
                            }
                            else if (sub_piping1.Rows[i]["type"].ToString() == "10")
                            {
                                lbm301.Text = sub_piping1.Rows[i]["l3"].ToString();
                                lbm302.Text = sub_piping1.Rows[i]["l4"].ToString();
                            }

                        }
                    }
                }

                var sub_piping2 = Serv.Get_tbl_piping_qurter_plan2(hddpiping_id.Value);
                if (sub_piping2.Rows.Count != 0)
                {
                    for (int i = 0; i <= sub_piping2.Rows.Count - 1; i++)
                    {
                        if (i == 0)
                        {
                            lbQuarter2.Text = sub_piping2.Rows[i]["l30"].ToString();
                            lbM1_.Text = sub_piping2.Rows[i]["l31"].ToString();

                            if (sub_piping2.Rows[i]["type"].ToString() == "1")
                            {
                                lbm111_.Text = sub_piping2.Rows[i]["l32"].ToString();
                                lbm112_.Text = sub_piping2.Rows[i]["l33"].ToString();
                            }
                            else if (sub_piping2.Rows[i]["type"].ToString() == "2")
                            {
                                lbm121_.Text = sub_piping2.Rows[i]["l32"].ToString();
                                lbm122_.Text = sub_piping2.Rows[i]["l33"].ToString();
                            }
                            else if (sub_piping2.Rows[i]["type"].ToString() == "3")
                            {
                                lbm131_.Text = sub_piping2.Rows[i]["l32"].ToString();
                                lbm132_.Text = sub_piping2.Rows[i]["l33"].ToString();
                            }
                            else if (sub_piping2.Rows[i]["type"].ToString() == "4")
                            {
                                lbm141_.Text = sub_piping2.Rows[i]["l32"].ToString();
                                lbm142_.Text = sub_piping2.Rows[i]["l33"].ToString();
                            }
                            else if (sub_piping2.Rows[i]["type"].ToString() == "5")
                            {
                                lbm151_.Text = sub_piping2.Rows[i]["l32"].ToString();
                                lbm152_.Text = sub_piping2.Rows[i]["l33"].ToString();
                            }
                            else if (sub_piping2.Rows[i]["type"].ToString() == "6")
                            {
                                lbm161_.Text = sub_piping2.Rows[i]["l32"].ToString();
                                lbm162_.Text = sub_piping2.Rows[i]["l33"].ToString();
                            }
                            else if (sub_piping2.Rows[i]["type"].ToString() == "7")
                            {
                                lbm171_.Text = sub_piping2.Rows[i]["l32"].ToString();
                                lbm172_.Text = sub_piping2.Rows[i]["l33"].ToString();
                            }
                            else if (sub_piping2.Rows[i]["type"].ToString() == "8")
                            {
                                lbm181_.Text = sub_piping2.Rows[i]["l32"].ToString();
                                lbm182_.Text = sub_piping2.Rows[i]["l33"].ToString();
                            }
                            else if (sub_piping2.Rows[i]["type"].ToString() == "9")
                            {
                                lbm191_.Text = sub_piping2.Rows[i]["l32"].ToString();
                                lbm192_.Text = sub_piping2.Rows[i]["l33"].ToString();
                            }
                            else if (sub_piping2.Rows[i]["type"].ToString() == "10")
                            {
                                lbm101_.Text = sub_piping2.Rows[i]["l32"].ToString();
                                lbm102_.Text = sub_piping2.Rows[i]["l33"].ToString();
                            }

                        }
                        else if (i == 1)
                        {
                            lbQuarter2.Text = sub_piping2.Rows[i]["l30"].ToString();
                            lbM2_.Text = sub_piping2.Rows[i]["l31"].ToString();

                            if (sub_piping2.Rows[i]["type"].ToString() == "1")
                            {
                                lbm211_.Text = sub_piping2.Rows[i]["l32"].ToString();
                                lbm212_.Text = sub_piping2.Rows[i]["l33"].ToString();
                            }
                            else if (sub_piping2.Rows[i]["type"].ToString() == "2")
                            {
                                lbm221_.Text = sub_piping2.Rows[i]["l32"].ToString();
                                lbm222_.Text = sub_piping2.Rows[i]["l33"].ToString();
                            }
                            else if (sub_piping2.Rows[i]["type"].ToString() == "3")
                            {
                                lbm231_.Text = sub_piping2.Rows[i]["l32"].ToString();
                                lbm232_.Text = sub_piping2.Rows[i]["l33"].ToString();
                            }
                            else if (sub_piping2.Rows[i]["type"].ToString() == "4")
                            {
                                lbm241_.Text = sub_piping2.Rows[i]["l32"].ToString();
                                lbm242_.Text = sub_piping2.Rows[i]["l33"].ToString();
                            }
                            else if (sub_piping2.Rows[i]["type"].ToString() == "5")
                            {
                                lbm251_.Text = sub_piping2.Rows[i]["l32"].ToString();
                                lbm252_.Text = sub_piping2.Rows[i]["l33"].ToString();
                            }
                            else if (sub_piping2.Rows[i]["type"].ToString() == "6")
                            {
                                lbm261_.Text = sub_piping2.Rows[i]["l32"].ToString();
                                lbm262_.Text = sub_piping2.Rows[i]["l33"].ToString();
                            }
                            else if (sub_piping2.Rows[i]["type"].ToString() == "7")
                            {
                                lbm271_.Text = sub_piping2.Rows[i]["l32"].ToString();
                                lbm272_.Text = sub_piping2.Rows[i]["l33"].ToString();
                            }
                            else if (sub_piping2.Rows[i]["type"].ToString() == "8")
                            {
                                lbm281_.Text = sub_piping2.Rows[i]["l32"].ToString();
                                lbm282_.Text = sub_piping2.Rows[i]["l33"].ToString();
                            }
                            else if (sub_piping2.Rows[i]["type"].ToString() == "9")
                            {
                                lbm291_.Text = sub_piping2.Rows[i]["l32"].ToString();
                                lbm292_.Text = sub_piping2.Rows[i]["l33"].ToString();
                            }
                            else if (sub_piping2.Rows[i]["type"].ToString() == "10")
                            {
                                lbm201_.Text = sub_piping2.Rows[i]["l32"].ToString();
                                lbm202_.Text = sub_piping2.Rows[i]["l33"].ToString();
                            }

                        }
                        else if (i == 2)
                        {
                            lbQuarter2.Text = sub_piping2.Rows[i]["l30"].ToString();
                            lbM3_.Text = sub_piping2.Rows[i]["l31"].ToString();

                            if (sub_piping2.Rows[i]["type"].ToString() == "1")
                            {
                                lbm311_.Text = sub_piping2.Rows[i]["l32"].ToString();
                                lbm312_.Text = sub_piping2.Rows[i]["l33"].ToString();
                            }
                            else if (sub_piping2.Rows[i]["type"].ToString() == "2")
                            {
                                lbm321_.Text = sub_piping2.Rows[i]["l32"].ToString();
                                lbm322_.Text = sub_piping2.Rows[i]["l33"].ToString();
                            }
                            else if (sub_piping2.Rows[i]["type"].ToString() == "3")
                            {
                                lbm331_.Text = sub_piping2.Rows[i]["l32"].ToString();
                                lbm332_.Text = sub_piping2.Rows[i]["l33"].ToString();
                            }
                            else if (sub_piping2.Rows[i]["type"].ToString() == "4")
                            {
                                lbm341_.Text = sub_piping2.Rows[i]["l32"].ToString();
                                lbm342_.Text = sub_piping2.Rows[i]["l33"].ToString();
                            }
                            else if (sub_piping2.Rows[i]["type"].ToString() == "5")
                            {
                                lbm351_.Text = sub_piping2.Rows[i]["l32"].ToString();
                                lbm352_.Text = sub_piping2.Rows[i]["l33"].ToString();
                            }
                            else if (sub_piping2.Rows[i]["type"].ToString() == "6")
                            {
                                lbm361_.Text = sub_piping2.Rows[i]["l32"].ToString();
                                lbm362_.Text = sub_piping2.Rows[i]["l33"].ToString();
                            }
                            else if (sub_piping2.Rows[i]["type"].ToString() == "7")
                            {
                                lbm371_.Text = sub_piping2.Rows[i]["l32"].ToString();
                                lbm372_.Text = sub_piping2.Rows[i]["l33"].ToString();
                            }
                            else if (sub_piping2.Rows[i]["type"].ToString() == "8")
                            {
                                lbm381_.Text = sub_piping2.Rows[i]["l32"].ToString();
                                lbm382_.Text = sub_piping2.Rows[i]["l33"].ToString();
                            }
                            else if (sub_piping2.Rows[i]["type"].ToString() == "9")
                            {
                                lbm391_.Text = sub_piping2.Rows[i]["l32"].ToString();
                                lbm392_.Text = sub_piping2.Rows[i]["l33"].ToString();
                            }
                            else if (sub_piping2.Rows[i]["type"].ToString() == "10")
                            {
                                lbm301_.Text = sub_piping2.Rows[i]["l32"].ToString();
                                lbm302_.Text = sub_piping2.Rows[i]["l33"].ToString();
                            }

                        }
                    }
                }

                var sub1 = Serv.GetSub1(hddpiping_id.Value);
                if (sub1.Rows.Count != 0)
                {
                    txtRegion.Text = sub1.Rows[0]["l5"].ToString();
                    txtAVG.Text = sub1.Rows[0]["l6"].ToString();
                    txtstation.Text = sub1.Rows[0]["l9"].ToString();
                    txtmin.Text = sub1.Rows[0]["l7"].ToString();
                    txtCorr.Text = sub1.Rows[0]["l8"].ToString();

                }

                var sub2 = Serv.GetSub2(hddpiping_id.Value);
                if (sub2.Rows.Count != 0)
                {
                    txtRegion2.Text = sub2.Rows[0]["l10"].ToString();
                    txtCoatingCondition.Text = sub2.Rows[0]["l11"].ToString();
                    txtstation2.Text = sub2.Rows[0]["l13"].ToString();
                    txtCorrosion.Text = sub2.Rows[0]["l12"].ToString();
                }

                var sub3 = Serv.GetSub3(hddpiping_id.Value);
                if (sub3.Rows.Count != 0)
                {
                    txtRegion3.Text = sub3.Rows[0]["l14"].ToString();
                    txtPipeSup.Text = sub3.Rows[0]["l15"].ToString();
                    txtstation3.Text = sub3.Rows[0]["l17"].ToString();
                    txtCorrosion2.Text = sub3.Rows[0]["l16"].ToString();

                }

                var sub4 = Serv.GetSub4(hddpiping_id.Value);
                if (sub4.Rows.Count != 0)
                {
                    txtRegion4.Text = sub4.Rows[0]["l18"].ToString();
                    txtCoating4.Text = sub4.Rows[0]["l19"].ToString();
                    txtstation4.Text = sub4.Rows[0]["l21"].ToString();
                    txtCorrosion4.Text = sub4.Rows[0]["l20"].ToString();
                }

                var sub5 = Serv.GetSub5(hddpiping_id.Value);
                if (sub5.Rows.Count != 0)
                {
                    txtRegion5.Text = sub5.Rows[0]["l22"].ToString();
                    txtInsulation.Text = sub5.Rows[0]["l23"].ToString();
                    txtstation5.Text = sub5.Rows[0]["l25"].ToString();
                    txtCorrosion5.Text = sub5.Rows[0]["l24"].ToString();

                }

                var sub6 = Serv.GetSub6(hddpiping_id.Value);
                if (sub6.Rows.Count != 0)
                {
                    txtRegion6.Text = sub6.Rows[0]["l26"].ToString();
                    txtInspection.Text = sub6.Rows[0]["l27"].ToString();
                    txtCMStation.Text = sub6.Rows[0]["l28"].ToString();
                    txtdate.Text = sub6.Rows[0]["l29"].ToString();

                }
            }
            else
            {
                var x = Serv.Insert_tbl_piping(hddmas_rep_id.Value, "");
                if (x.Rows.Count != 0)
                {
                    hddpiping_id.Value = x.Rows[0]["id"].ToString();
                }
            }
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {

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

            lbQuarter.Text = "Quarter 1";
            lbQuarter2.Text = "Quarter 2";

            lbM1.Text = "Jan";
            lbM2.Text = "Feb";
            lbM3.Text = "Mar";

            lbM1_.Text = "Arp";
            lbM2_.Text = "May";
            lbM3_.Text = "Jun";

            lbm131.Text = "18";
            lbm132.Text = "18";

            lbm221.Text = "2";
            lbm222.Text = "2";


            lbm311.Text = "7";
            lbm312.Text = "7";


            lbm131_.Text = "18";
            lbm132_.Text = "18";

            lbm221_.Text = "2";
            lbm222_.Text = "2";


            lbm311_.Text = "7";
            lbm312_.Text = "7";
        }
        private void POPUPMSG(string msg)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("alert(\'");
            sb.Append(msg.Replace("\n", "\\n").Replace("\r", "").Replace("\'", "\\\'"));
            sb.Append("\');");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showalert", sb.ToString(), true);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Serv.Truncate_tbl_piping_qurter_plan();
            Serv.Truncate_tbl_piping_sub();

            Serv.Update_tbl_piping(txtComment.Text, hddpiping_id.Value, HttpContext.Current.Session["assetuserid"].ToString(), hddmas_rep_id.Value);

            Serv.Insert_tbl_piping_qurter_plan1(hddpiping_id.Value, lbQuarter.Text, lbM1.Text, lbm131.Text, lbm132.Text, "3");
            Serv.Insert_tbl_piping_qurter_plan1(hddpiping_id.Value, lbQuarter.Text, lbM2.Text, lbm221.Text, lbm222.Text, "2");
            Serv.Insert_tbl_piping_qurter_plan1(hddpiping_id.Value, lbQuarter.Text, lbM3.Text, lbm311.Text, lbm312.Text, "1");

            Serv.Insert_tbl_piping_qurter_plan2(hddpiping_id.Value, lbQuarter2.Text, lbM1_.Text, lbm131_.Text, lbm132_.Text, "3");
            Serv.Insert_tbl_piping_qurter_plan2(hddpiping_id.Value, lbQuarter2.Text, lbM2_.Text, lbm221_.Text, lbm222_.Text, "2");
            Serv.Insert_tbl_piping_qurter_plan2(hddpiping_id.Value, lbQuarter2.Text, lbM3_.Text, lbm311_.Text, lbm312_.Text, "1");

            Serv.Insert_tbl_piping_sub1(hddpiping_id.Value, txtRegion.Text, txtAVG.Text, txtmin.Text, txtCorr.Text, txtstation.Text);
            Serv.Insert_tbl_piping_sub2(hddpiping_id.Value, txtRegion2.Text, txtCoatingCondition.Text, txtCorrosion.Text, txtstation.Text);
            Serv.Insert_tbl_piping_sub3(hddpiping_id.Value, txtRegion3.Text, txtPipeSup.Text, txtCorrosion2.Text, txtstation3.Text);
            Serv.Insert_tbl_piping_sub4(hddpiping_id.Value, txtRegion4.Text, txtCoating4.Text, txtCorrosion4.Text, txtstation4.Text);
            Serv.Insert_tbl_piping_sub5(hddpiping_id.Value, txtRegion5.Text, txtInsulation.Text, txtCorrosion5.Text, txtstation5.Text);
            Serv.Insert_tbl_piping_sub6(hddpiping_id.Value, txtRegion6.Text, txtInspection.Text, txtCMStation.Text, txtdate.Text);


            POPUPMSG("บันทึกเรียบร้อย");
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            Serv.UpdateStatus_rep(hddmas_rep_id.Value, HttpContext.Current.Session["assetuserid"].ToString());
        }

        protected void btnHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/history_1.aspx?param=1&quarterrepid=" + hddmas_rep_id.Value);
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (hddfile_path.Value != "")
            {
                Response.Redirect(hddfile_path.Value);
            }
        }

        protected void btnSaveVer_Click(object sender, EventArgs e)
        {
            var app = new Application();
            try
            {
                var rep_tmp = Serv.GetTempRep();
                if (rep_tmp.Rows.Count != 0)
                {
                    //This code creates a document based on the specified template.
                    var doc = app.Documents.Add(Server.MapPath(rep_tmp.Rows[0]["file_path"].ToString()), Visible: false);

                    doc.Activate();

                    //do this for each keyword you want to replace.
                    var sel = app.Selection;
                    var rep_a = Serv.GetExistRep0(hddmas_rep_id.Value);
                    if (rep_a.Rows.Count != 0)
                    {
                        sel.Find.Text = "[qx]";
                        sel.Find.Replacement.Text = HttpContext.Current.Session["repQuar"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[yx]";
                        sel.Find.Replacement.Text = HttpContext.Current.Session["repYear"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        //=======================================================================================

                        sel.Find.Text = "[qa0]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["partolling_info1"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa1]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["partolling_info2"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa2]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["partolling_info3"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa3]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["rov_info1"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa4]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["rov_info2"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa5]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["rov_info3"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa6]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["da_info1"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa7]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["da_info2"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa8]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["da_info3"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa9]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["erosion_info1"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa10]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["erosion_info2"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa11]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["erosion_info3"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa12]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["subsite_info1"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa13]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["subsite_info2"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa14]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["subsite_info3"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa15]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["exterCorr_info1"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa16]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["exterCorr_info2"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa17]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["exterCorr_info3"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa18]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["exterCorr_info4"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa19]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["interCorr_info1"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa20]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["interCorr_info2"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa21]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["interCorr_info3"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa22]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["interCorr_info4"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa23]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["da2_info1"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa24]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["da2_info2"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa25]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["da2_info3"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa26]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["offshore_info1"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa27]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["offshore_info2"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa28]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["offshore_info3"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa29]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["offshore2_info1"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa30]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["offshore2_info2"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[qa31]";
                        sel.Find.Replacement.Text = rep_a.Rows[0]["offshore2_info3"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        var executive = Serv.GetExecutiveOtherRep0(rep_a.Rows[0]["id"].ToString());
                        if (executive.Rows.Count != 0)
                        {
                            if (executive.Rows.Count == 5)
                            {
                                sel.Find.Text = "[qa32]";
                                sel.Find.Replacement.Text = executive.Rows[0]["project_name"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa33]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info1"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa34]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info2"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa35]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info3"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa36]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info1"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa37]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info2"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa38]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info3"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa39]";
                                sel.Find.Replacement.Text = executive.Rows[2]["other_info1"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa40]";
                                sel.Find.Replacement.Text = executive.Rows[2]["other_info2"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa41]";
                                sel.Find.Replacement.Text = executive.Rows[2]["other_info3"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);



                            }
                            else if (executive.Rows.Count == 4)
                            {
                                sel.Find.Text = "[qa32]";
                                sel.Find.Replacement.Text = executive.Rows[0]["project_name"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa33]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info1"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa34]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info2"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa35]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info3"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa36]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info1"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa37]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info2"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa38]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info3"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa39]";
                                sel.Find.Replacement.Text = executive.Rows[2]["other_info1"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa40]";
                                sel.Find.Replacement.Text = executive.Rows[2]["other_info2"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa41]";
                                sel.Find.Replacement.Text = executive.Rows[2]["other_info3"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            }
                            else if (executive.Rows.Count == 3)
                            {
                                sel.Find.Text = "[qa32]";
                                sel.Find.Replacement.Text = executive.Rows[0]["project_name"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa33]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info1"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa34]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info2"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa35]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info3"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa36]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info1"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa37]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info2"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa38]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info3"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa39]";
                                sel.Find.Replacement.Text = executive.Rows[2]["other_info1"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa40]";
                                sel.Find.Replacement.Text = executive.Rows[2]["other_info2"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa41]";
                                sel.Find.Replacement.Text = executive.Rows[2]["other_info3"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);


                            }
                            else if (executive.Rows.Count == 2)
                            {
                                sel.Find.Text = "[qa32]";
                                sel.Find.Replacement.Text = executive.Rows[0]["project_name"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa33]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info1"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa34]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info2"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa35]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info3"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa36]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info1"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa37]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info2"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa38]";
                                sel.Find.Replacement.Text = executive.Rows[1]["other_info3"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa39]";
                                sel.Find.Replacement.Text = "";
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa40]";
                                sel.Find.Replacement.Text = "";
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa41]";
                                sel.Find.Replacement.Text = "";
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            }
                            else if (executive.Rows.Count == 1)
                            {
                                sel.Find.Text = "[qa32]";
                                sel.Find.Replacement.Text = executive.Rows[0]["project_name"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa33]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info1"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa34]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info2"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa35]";
                                sel.Find.Replacement.Text = executive.Rows[0]["other_info3"].ToString().Replace("\r\n", "\v");
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa36]";
                                sel.Find.Replacement.Text = "";
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa37]";
                                sel.Find.Replacement.Text = "";
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa38]";
                                sel.Find.Replacement.Text = "";
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa39]";
                                sel.Find.Replacement.Text = "";
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa40]";
                                sel.Find.Replacement.Text = "";
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                sel.Find.Text = "[qa41]";
                                sel.Find.Replacement.Text = "";
                                sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                sel.Find.Forward = true;
                                sel.Find.Format = false;
                                sel.Find.MatchCase = false;
                                sel.Find.MatchWholeWord = false;
                                sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            }
                        }
                    }


                    var rep_b = Serv.GetExistRep1(hddmas_rep_id.Value);
                    if (rep_b.Rows.Count != 0)
                    {
                        var img = Server.MapPath(rep_b.Rows[0]["groung_img_path"].ToString());
                        if (rep_b.Rows[0]["groung_img_path"].ToString() != "")
                        {
                            sel.Find.Text = "[imgb1]";
                            sel.Find.Execute(Replace: WdReplace.wdReplaceNone);
                            sel.Range.Select();
                            sel.InlineShapes.AddPicture(
                                FileName: img,
                                LinkToFile: false,
                                SaveWithDocument: true
                                );
                        }


                        sel.Find.Text = "[b2]";
                        sel.Find.Replacement.Text = rep_b.Rows[0]["aerial_result"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[b3]";
                        sel.Find.Replacement.Text = rep_b.Rows[0]["remark1"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[b4]";
                        sel.Find.Replacement.Text = rep_b.Rows[0]["problem"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                    }

                    //===================================== DA ========================================

                    var da = Serv.GetExistRep2(hddmas_rep_id.Value);
                    if (da.Rows.Count != 0)
                    {

                        sel.Find.Text = "[c7]";
                        sel.Find.Replacement.Text = da.Rows[0]["dainfo11"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[c8]";
                        sel.Find.Replacement.Text = da.Rows[0]["dainfo12"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[c9]";
                        sel.Find.Replacement.Text = da.Rows[0]["dainfo13"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[c10]";
                        sel.Find.Replacement.Text = da.Rows[0]["dainfo14"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[c11]";
                        sel.Find.Replacement.Text = da.Rows[0]["dainfo21"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[c12]";
                        sel.Find.Replacement.Text = da.Rows[0]["dainfo22"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[c13]";
                        sel.Find.Replacement.Text = da.Rows[0]["dainfo23"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[c14]";
                        sel.Find.Replacement.Text = da.Rows[0]["dainfo24"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[c16]";
                        sel.Find.Replacement.Text = da.Rows[0]["dainfo1"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                    }

                    var sub_da = Serv.GetDARep_sub(da.Rows[0]["id"].ToString());
                    if (sub_da.Rows.Count != 0)
                    {
                        Microsoft.Office.Interop.Word.Table axTable;

                        sel.Find.Text = "[table1]";
                        sel.Find.Execute(Replace: WdReplace.wdReplaceNone);
                        sel.Range.Select();
                        axTable = sel.Tables.Add(app.Selection.Range, sub_da.Rows.Count + 1, 6);

                        axTable.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
                        axTable.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;

                        axTable.Cell(1, 1).Range.Text = "เขต";
                        axTable.Cell(1, 2).Range.Text = "เส้นท่อ,ตำแหน่ง";
                        axTable.Cell(1, 3).Range.Text = "ขุดซ่อมเนื่องจาก";
                        axTable.Cell(1, 4).Range.Text = "Length(m)";
                        axTable.Cell(1, 5).Range.Text = "% Actual";
                        axTable.Cell(1, 6).Range.Text = "Plan/Status";

                        int start_row = 2;
                        // This is For Header columns
                        for (int j = 0; j <= sub_da.Rows.Count - 1; j++)
                        {
                            axTable.Cell(start_row, 1).Range.Text = sub_da.Rows[j]["dainfo1"].ToString();
                            axTable.Cell(start_row, 2).Range.Text = sub_da.Rows[j]["dainfo2"].ToString();
                            axTable.Cell(start_row, 3).Range.Text = sub_da.Rows[j]["dainfo3"].ToString();
                            axTable.Cell(start_row, 4).Range.Text = sub_da.Rows[j]["dainfo4"].ToString();
                            axTable.Cell(start_row, 5).Range.Text = sub_da.Rows[j]["dainfo5"].ToString();
                            axTable.Cell(start_row, 6).Range.Text = sub_da.Rows[j]["dainfo6"].ToString();

                            start_row++;
                        }

                    }

                    //=================================================================================

                    //============================= Soil =============================================

                    var soil = Serv.GetExistRep3(hddmas_rep_id.Value);
                    if (soil.Rows.Count != 0)
                    {
                        sel.Find.Text = "[d1]";
                        sel.Find.Replacement.Text = soil.Rows[0]["d1"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[d2]";
                        sel.Find.Replacement.Text = soil.Rows[0]["d2"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[d9]";
                        sel.Find.Replacement.Text = soil.Rows[0]["d9"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[d10]";
                        sel.Find.Replacement.Text = soil.Rows[0]["d10"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[d11]";
                        sel.Find.Replacement.Text = soil.Rows[0]["d11"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        var soil_sub = Serv.GetExistRep3_sub(soil.Rows[0]["id"].ToString());
                        if (soil_sub.Rows.Count != 0)
                        {
                            Microsoft.Office.Interop.Word.Table axTable2;

                            sel.Find.Text = "[table2]";
                            sel.Find.Execute(Replace: WdReplace.wdReplaceNone);
                            sel.Range.Select();
                            axTable2 = sel.Tables.Add(app.Selection.Range, soil_sub.Rows.Count + 1, 4);

                            axTable2.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
                            axTable2.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;

                            axTable2.Cell(1, 1).Range.Text = "Region";
                            axTable2.Cell(1, 2).Range.Text = "เส้นท่อ,ตำแหน่ง";
                            axTable2.Cell(1, 3).Range.Text = "Progress";
                            axTable2.Cell(1, 4).Range.Text = "ผลการดำเนินงาน/สิ่งที่ไม่เป็นไปตามแผน/ปัญหาอุปสรรค/แนวทางแก้ไข";

                            int start_row = 2;

                            for (int j = 0; j <= soil_sub.Rows.Count - 1; j++)
                            {
                                axTable2.Cell(start_row, 1).Range.Text = soil_sub.Rows[j]["d3"].ToString();
                                axTable2.Cell(start_row, 2).Range.Text = soil_sub.Rows[j]["d4"].ToString();
                                axTable2.Cell(start_row, 3).Range.Text = soil_sub.Rows[j]["d7"].ToString();
                                axTable2.Cell(start_row, 4).Range.Text = soil_sub.Rows[j]["d8"].ToString();

                                start_row = start_row + 1;
                            }
                        }
                    }

                    #region E
                    ///=========================== E ==============================
                    ///
                    var exist = Serv.GetExistRep4(hddmas_rep_id.Value);
                    if (exist.Rows.Count != 0)
                    {

                        sel.Find.Text = "[e7]";
                        sel.Find.Replacement.Text = exist.Rows[0]["progressresult"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[e8]";
                        sel.Find.Replacement.Text = exist.Rows[0]["futureplan"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);


                        sel.Find.Text = "[e9]";
                        sel.Find.Replacement.Text = exist.Rows[0]["problem"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        var sub = Serv.GetExistRep4_sub(soil.Rows[0]["id"].ToString());
                        if (sub.Rows.Count != 0)
                        {
                            Microsoft.Office.Interop.Word.Table axTable2;

                            sel.Find.Text = "[table3]";
                            sel.Find.Execute(Replace: WdReplace.wdReplaceNone);
                            sel.Range.Select();
                            axTable2 = sel.Tables.Add(app.Selection.Range, sub.Rows.Count + 1, 5);

                            axTable2.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
                            axTable2.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;

                            axTable2.Cell(1, 1).Range.Text = "Region";
                            axTable2.Cell(1, 2).Range.Text = "Station";
                            axTable2.Cell(1, 3).Range.Text = "Action";
                            axTable2.Cell(1, 4).Range.Text = "Progress";
                            axTable2.Cell(1, 5).Range.Text = "ผลการดำเนินงาน/สิ่งที่ไม่เป็นไปตามแผน/ปัญหาอุปสรรค/แนวทางแก้ไข";

                            int start_row = 2;

                            for (int j = 0; j <= sub.Rows.Count - 1; j++)
                            {
                                axTable2.Cell(start_row, 1).Range.Text = sub.Rows[j]["area"].ToString();
                                axTable2.Cell(start_row, 2).Range.Text = sub.Rows[j]["station"].ToString() + " " + sub.Rows[j]["pipe"].ToString();
                                axTable2.Cell(start_row, 3).Range.Text = sub.Rows[j]["action"].ToString();
                                axTable2.Cell(start_row, 4).Range.Text = sub.Rows[j]["progress"].ToString();
                                axTable2.Cell(start_row, 5).Range.Text = sub.Rows[j]["remark"].ToString();

                                start_row = start_row + 1;
                            }
                        }
                    }
                    #endregion

                    #region F
                    var rov = Serv.GetExistRep5(hddmas_rep_id.Value);
                    if (rov.Rows.Count != 0)
                    {
                        sel.Find.Text = "[f1]";
                        sel.Find.Replacement.Text = rov.Rows[0]["planwork"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[f2]";
                        sel.Find.Replacement.Text = rov.Rows[0]["workresult"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[f3]";
                        sel.Find.Replacement.Text = rov.Rows[0]["planworkfuture"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[f4]";
                        sel.Find.Replacement.Text = rov.Rows[0]["problem"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                    }
                    #endregion

                    #region G
                    var exist_g = Serv.GetExistRep6(hddmas_rep_id.Value);
                    if (exist_g.Rows.Count != 0)
                    {
                        sel.Find.Text = "[g1]";
                        sel.Find.Replacement.Text = exist_g.Rows[0]["planwork"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[g2]";
                        sel.Find.Replacement.Text = exist_g.Rows[0]["workresult"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[g3]";
                        sel.Find.Replacement.Text = exist_g.Rows[0]["planworkfuture"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[g4]";
                        sel.Find.Replacement.Text = exist_g.Rows[0]["problem"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                    }
                    #endregion

                    #region h
                    var exist_h = Serv.GetExistRep_h(hddmas_rep_id.Value);
                    if (exist_h.Rows.Count != 0)
                    {
                        sel.Find.Text = "[h1]";
                        sel.Find.Replacement.Text = exist_h.Rows[0]["workresult"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[h2]";
                        sel.Find.Replacement.Text = exist_h.Rows[0]["pspotentialsurvey"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[h3]";
                        sel.Find.Replacement.Text = exist_h.Rows[0]["bondboxinspection"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[h4]";
                        sel.Find.Replacement.Text = exist_h.Rows[0]["rectifierispection"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[h5]";
                        sel.Find.Replacement.Text = exist_h.Rows[0]["insulatingjoint"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);


                        var subCIPSStatus = Serv.GetExistRep_sub_cipsstatus(exist_h.Rows[0]["id"].ToString());

                        if (subCIPSStatus.Rows.Count != 0)
                        {
                            Microsoft.Office.Interop.Word.Table axTable2;

                            sel.Find.Text = "[table4]";
                            sel.Find.Execute(Replace: WdReplace.wdReplaceNone);
                            sel.Range.Select();
                            sel.Find.Forward = true;
                            axTable2 = sel.Tables.Add(app.Selection.Range, subCIPSStatus.Rows.Count + 1, 3);

                            axTable2.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
                            axTable2.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;

                            axTable2.Cell(1, 1).Range.Text = "Route Code";
                            axTable2.Cell(1, 2).Range.Text = "Pipeline name";
                            axTable2.Cell(1, 3).Range.Text = "สถานะ";

                            int start_row = 2;

                            for (int j = 0; j <= subCIPSStatus.Rows.Count - 1; j++)
                            {
                                axTable2.Cell(start_row, 1).Range.Text = subCIPSStatus.Rows[j]["routecode"].ToString();
                                axTable2.Cell(start_row, 2).Range.Text = subCIPSStatus.Rows[j]["pipelinename"].ToString();
                                axTable2.Cell(start_row, 3).Range.Text = subCIPSStatus.Rows[j]["status"].ToString();

                                start_row = start_row + 1;
                            }
                        }

                        var image_h13 = Server.MapPath(exist_h.Rows[0]["ecresultfilepath"].ToString());
                        if (exist_h.Rows[0]["ecresultfilepath"].ToString() != "")
                        {
                            sel.Find.Text = "[h13]";
                            sel.Find.Execute(Replace: WdReplace.wdReplaceNone);
                            sel.Range.Select();
                            sel.Find.Forward = true;
                            sel.InlineShapes.AddPicture(
                                FileName: image_h13,
                                LinkToFile: false,
                                SaveWithDocument: true
                                );
                        }


                        var image_h14 = Server.MapPath(exist_h.Rows[0]["cdresultfilepath"].ToString());
                        if (exist_h.Rows[0]["cdresultfilepath"].ToString() != "")
                        {
                            sel.Find.Text = "[h14]";
                            sel.Find.Execute(Replace: WdReplace.wdReplaceNone);
                            sel.Range.Select();
                            sel.Find.Forward = true;
                            sel.InlineShapes.AddPicture(
                                FileName: image_h14,
                                LinkToFile: false,
                                SaveWithDocument: true
                                );
                        }
                        


                        var subCIPSStatusActivity = Serv.GetExistRep_sub_cipsstatus_activity(exist_h.Rows[0]["id"].ToString());

                        if (subCIPSStatusActivity.Rows.Count != 0)
                        {
                            Microsoft.Office.Interop.Word.Table axTable3;

                            sel.Find.Text = "[table5]";
                            sel.Find.Execute(Replace: WdReplace.wdReplaceNone);
                            sel.Range.Select();
                            sel.Find.Forward = true;
                            axTable3 = sel.Tables.Add(app.Selection.Range, subCIPSStatusActivity.Rows.Count + 1, 3);

                            axTable3.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
                            axTable3.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;

                            axTable3.Cell(1, 1).Range.Text = "Active";
                            axTable3.Cell(1, 2).Range.Text = "แผนดำเนินการ";
                            axTable3.Cell(1, 3).Range.Text = "คาดการเสร็จสิ้น";

                            int start_row = 2;

                            for (int j = 0; j <= subCIPSStatusActivity.Rows.Count - 1; j++)
                            {
                                axTable3.Cell(start_row, 1).Range.Text = subCIPSStatusActivity.Rows[j]["activity"].ToString();
                                axTable3.Cell(start_row, 2).Range.Text = subCIPSStatusActivity.Rows[j]["progress"].ToString();
                                axTable3.Cell(start_row, 3).Range.Text = subCIPSStatusActivity.Rows[j]["estimateplan"].ToString();

                                start_row = start_row + 1;
                            }
                        }


                        sel.Find.Text = "[h15]";
                        sel.Find.Replacement.Text = exist_h.Rows[0]["planworkfuture"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[h19]";
                        sel.Find.Replacement.Text = exist_h.Rows[0]["problem"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        //var subCathodic = Serv.GetExistRep_sub_cathodicresult(exist_h.Rows[0]["id"].ToString());

                        //if (subCathodic.Rows.Count != 0)
                        //{
                        //    gvCathodic.DataSource = subCathodic;
                        //    gvCathodic.DataBind();
                        //}

                    }


                    #endregion

                    #region i
                    var exist_i = Serv.GetExistRep_i(hddmas_rep_id.Value);
                    if (exist_i.Rows.Count != 0)
                    {
                        sel.Find.Text = "[i1]";
                        sel.Find.Replacement.Text = exist_i.Rows[0]["planwork"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        //txtRoutecode.Text = exist_i.Rows[0]["pwroutecode"].ToString();
                        //txtDimeter.Text = exist_i.Rows[0]["pwdimeter"].ToString();
                        //txtPipeline.Text = exist_i.Rows[0]["pwpipelinesection"].ToString();
                        //txtNumberOfPig.Text = exist_i.Rows[0]["pwnumberpig"].ToString();
                        //txtPlanning.Text = exist_i.Rows[0]["pwplaning"].ToString();

                        sel.Find.Text = "[i7]";
                        sel.Find.Replacement.Text = exist_i.Rows[0]["planwork"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        var subPig = Serv.GetExistRep_sub_pigresult(exist_i.Rows[0]["id"].ToString());

                        if (subPig.Rows.Count != 0)
                        {
                            Microsoft.Office.Interop.Word.Table axTable2;

                            sel.Find.Text = "[table6]";
                            sel.Find.Execute(Replace: WdReplace.wdReplaceNone);
                            sel.Range.Select();
                            axTable2 = sel.Tables.Add(app.Selection.Range, subPig.Rows.Count + 1, 2);

                            int start_row = 1;

                            for (int j = 0; j <= subPig.Rows.Count - 1; j++)
                            {
                                axTable2.Cell(start_row, 1).Range.Text = subPig.Rows[j]["routecode"].ToString() + " " + subPig.Rows[j]["sectionlength"].ToString();
                                axTable2.Cell(start_row, 2).Range.Text = subPig.Rows[j]["status"].ToString();

                                start_row = start_row + 1;
                            }
                        }


                        sel.Find.Text = "[i11]";
                        sel.Find.Replacement.Text = exist_i.Rows[0]["notethat"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[i12]";
                        sel.Find.Replacement.Text = exist_i.Rows[0]["froutecode"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[i13]";
                        sel.Find.Replacement.Text = exist_i.Rows[0]["fdimeter"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[i14]";
                        sel.Find.Replacement.Text = exist_i.Rows[0]["fpipelinesection"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[i15]";
                        sel.Find.Replacement.Text = exist_i.Rows[0]["fnumberpig"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[i16]";
                        sel.Find.Replacement.Text = exist_i.Rows[0]["fplaning"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[i17]";
                        sel.Find.Replacement.Text = exist_i.Rows[0]["problem"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);



                        var subReplan = Serv.GetExistRep_sub_replan(exist_i.Rows[0]["id"].ToString());

                        if (subReplan.Rows.Count != 0)
                        {
                            Microsoft.Office.Interop.Word.Table axTable2;

                            sel.Find.Text = "[table8]";
                            sel.Find.Execute(Replace: WdReplace.wdReplaceNone);
                            sel.Range.Select();
                            axTable2 = sel.Tables.Add(app.Selection.Range, subReplan.Rows.Count + 1, 3);

                            axTable2.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
                            axTable2.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;

                            axTable2.Cell(1, 1).Range.Text = "เส้นท่อ";
                            axTable2.Cell(1, 2).Range.Text = "ปรับแผน";
                            axTable2.Cell(1, 3).Range.Text = "รายละเอียด";

                            int start_row = 2;

                            for (int j = 0; j <= subReplan.Rows.Count - 1; j++)
                            {
                                axTable2.Cell(start_row, 1).Range.Text = subReplan.Rows[j]["routecode"].ToString();
                                axTable2.Cell(start_row, 2).Range.Text = subReplan.Rows[j]["replan"].ToString();
                                axTable2.Cell(start_row, 3).Range.Text = subReplan.Rows[j]["detail"].ToString();

                                start_row = start_row + 1;
                            }
                        }

                    }
                    #endregion

                    #region j
                    var exist_j = Serv.GetExistRep_j(hddmas_rep_id.Value);

                    if (exist_j.Rows.Count != 0)
                    {
                        Microsoft.Office.Interop.Word.Table axTable2;

                        sel.Find.Text = "[table9]";
                        sel.Find.Execute(Replace: WdReplace.wdReplaceNone);
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Range.Select();
                        axTable2 = sel.Tables.Add(app.Selection.Range, 3, 18);

                        axTable2.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
                        axTable2.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;

                        axTable2.Cell(1, 1).Merge(axTable2.Cell(2, 1));
                        axTable2.Cell(1, 2).Merge(axTable2.Cell(2, 2));
                        axTable2.Cell(1, 3).Merge(axTable2.Cell(2, 3));
                        axTable2.Cell(1, 4).Merge(axTable2.Cell(2, 4));
                        axTable2.Cell(1, 5).Merge(axTable2.Cell(2, 5));

                        axTable2.Cell(1, 6).Merge(axTable2.Cell(1, 7));
                        axTable2.Cell(1, 6).Merge(axTable2.Cell(1, 8));
                        axTable2.Cell(1, 6).Merge(axTable2.Cell(1, 9));
                        axTable2.Cell(1, 6).Merge(axTable2.Cell(1, 10));
                        axTable2.Cell(1, 6).Merge(axTable2.Cell(1, 7));

                        axTable2.Cell(1, 7).Merge(axTable2.Cell(2, 18));


                        axTable2.Cell(1, 1).Range.Text = "No.";
                        axTable2.Cell(1, 2).Range.Text = "Route Code";
                        axTable2.Cell(1, 3).Range.Text = "ID";
                        axTable2.Cell(1, 4).Range.Text = "Pipeline Section";
                        axTable2.Cell(1, 5).Range.Text = "Launch";
                        axTable2.Cell(1, 6).Range.Text = "ปี " + DateTime.Now.ToString("yyyy", EngCI);

                        axTable2.Cell(1, 7).Range.Text = "Actual จำนวนลูก";

                        axTable2.Cell(2, 6).Range.Text = "Jan";
                        axTable2.Cell(2, 7).Range.Text = "Feb";
                        axTable2.Cell(2, 8).Range.Text = "Mar";
                        axTable2.Cell(2, 9).Range.Text = "Apr";
                        axTable2.Cell(2, 10).Range.Text = "May";
                        axTable2.Cell(2, 11).Range.Text = "Jun";
                        axTable2.Cell(2, 12).Range.Text = "Jul";
                        axTable2.Cell(2, 13).Range.Text = "Aug";
                        axTable2.Cell(2, 14).Range.Text = "Sep";
                        axTable2.Cell(2, 15).Range.Text = "Oct";
                        axTable2.Cell(2, 16).Range.Text = "Nov";
                        axTable2.Cell(2, 17).Range.Text = "Dec";

                        axTable2.Cell(3, 1).Range.Text = "1";
                        axTable2.Cell(3, 2).Range.Text = exist_j.Rows[0]["pwroutecode"].ToString();
                        axTable2.Cell(3, 3).Range.Text = exist_j.Rows[0]["pwdimeter"].ToString();
                        axTable2.Cell(3, 4).Range.Text = exist_j.Rows[0]["pwpipelinesection"].ToString();
                        axTable2.Cell(3, 18).Range.Text = exist_j.Rows[0]["pwnumberpig"].ToString();

                        if (exist_j.Rows[0]["pwplaning"].ToString().Contains("มกราคม"))
                        {
                            axTable2.Cell(3, 6).Range.Shading.BackgroundPatternColor = WdColor.wdColorPink;
                        }
                        else if (exist_j.Rows[0]["pwplaning"].ToString().Contains("กุมภา"))
                        {
                            axTable2.Cell(3, 7).Range.Shading.BackgroundPatternColor = WdColor.wdColorPink;
                        }
                        else if (exist_j.Rows[0]["pwplaning"].ToString().Contains("มีนา"))
                        {
                            axTable2.Cell(3, 8).Range.Shading.BackgroundPatternColor = WdColor.wdColorPink;
                        }
                        else if (exist_j.Rows[0]["pwplaning"].ToString().Contains("เมษา"))
                        {
                            axTable2.Cell(3, 9).Range.Shading.BackgroundPatternColor = WdColor.wdColorPink;
                        }
                        else if (exist_j.Rows[0]["pwplaning"].ToString().Contains("พฤษภา"))
                        {
                            axTable2.Cell(3, 10).Range.Shading.BackgroundPatternColor = WdColor.wdColorPink;
                        }
                        else if (exist_j.Rows[0]["pwplaning"].ToString().Contains("มีนา"))
                        {
                            axTable2.Cell(3, 11).Range.Shading.BackgroundPatternColor = WdColor.wdColorPink;
                        }
                        else if (exist_j.Rows[0]["pwplaning"].ToString().Contains("กรก"))
                        {
                            axTable2.Cell(3, 12).Range.Shading.BackgroundPatternColor = WdColor.wdColorPink;
                        }
                        else if (exist_j.Rows[0]["pwplaning"].ToString().Contains("สิงหา"))
                        {
                            axTable2.Cell(3, 13).Range.Shading.BackgroundPatternColor = WdColor.wdColorPink;
                        }
                        else if (exist_j.Rows[0]["pwplaning"].ToString().Contains("กันยา"))
                        {
                            axTable2.Cell(3, 14).Range.Shading.BackgroundPatternColor = WdColor.wdColorPink;
                        }
                        else if (exist_j.Rows[0]["pwplaning"].ToString().Contains("ตุลา"))
                        {
                            axTable2.Cell(3, 15).Range.Shading.BackgroundPatternColor = WdColor.wdColorPink;
                        }
                        else if (exist_j.Rows[0]["pwplaning"].ToString().Contains("พฤศจิ"))
                        {
                            axTable2.Cell(3, 16).Range.Shading.BackgroundPatternColor = WdColor.wdColorPink;
                        }
                        else if (exist_j.Rows[0]["pwplaning"].ToString().Contains("ธันวา"))
                        {
                            axTable2.Cell(3, 17).Range.Shading.BackgroundPatternColor = WdColor.wdColorPink;
                        }


                        Microsoft.Office.Interop.Word.Table axTable3;

                        sel.Find.Text = "[table10]";
                        sel.Find.Execute(Replace: WdReplace.wdReplaceNone);
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Range.Select();
                        axTable3 = sel.Tables.Add(app.Selection.Range, 2, 2);

                        axTable3.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
                        axTable3.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;

                        axTable3.Cell(1, 1).Range.Text = "เส้นท่อ";
                        axTable3.Cell(1, 2).Range.Text = "ผลการดำเนินงาน";


                        axTable3.Cell(2, 1).Range.Text = exist_j.Rows[0]["wroutecode"].ToString() + " " + exist_j.Rows[0]["wpipelinesection"].ToString();
                        axTable3.Cell(2, 2).Range.Text = exist_j.Rows[0]["wresult"].ToString();


                        sel.Find.Text = "[j9]";
                        sel.Find.Replacement.Text = exist_j.Rows[0]["froutecode"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[j10]";
                        sel.Find.Replacement.Text = exist_j.Rows[0]["fdimeter"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[j11]";
                        sel.Find.Replacement.Text = exist_j.Rows[0]["fpipelinesection"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[j12]";
                        sel.Find.Replacement.Text = exist_j.Rows[0]["fnumberpig"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[j13]";
                        sel.Find.Replacement.Text = exist_j.Rows[0]["fplaning"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[j14]";
                        sel.Find.Replacement.Text = exist_j.Rows[0]["problem"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                    }
                    #endregion

                    #region K
                    var exist_k = Serv.GetExistRep_k(hddmas_rep_id.Value);

                    if (exist_k.Rows.Count != 0)
                    {
                        sel.Find.Text = "[k1]";
                        sel.Find.Replacement.Text = exist_k.Rows[0]["detail"].ToString().Replace("\r\n", "\v");
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);
                    }
                    #endregion

                    #region L
                    var exist_L = Serv.GetExistRep_L(hddmas_rep_id.Value);
                    if (exist_L.Rows.Count != 0)
                    {
                        var sub_piping1 = Serv.Get_tbl_piping_qurter_plan1(exist_L.Rows[0]["id"].ToString());
                        if (sub_piping1.Rows.Count != 0)
                        {
                            sel.Find.Text = "[l1]";
                            sel.Find.Replacement.Text = sub_piping1.Rows[0]["l1"].ToString().Replace("\r\n", "\v");
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            sel.Find.Text = "[l21]";
                            sel.Find.Replacement.Text = sub_piping1.Rows[0]["l2"].ToString().Replace("\r\n", "\v");
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            sel.Find.Text = "[l22]";
                            sel.Find.Replacement.Text = sub_piping1.Rows[1]["l2"].ToString().Replace("\r\n", "\v");
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            sel.Find.Text = "[l23]";
                            sel.Find.Replacement.Text = sub_piping1.Rows[2]["l2"].ToString().Replace("\r\n", "\v");
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            sel.Find.Text = "[l331]";
                            sel.Find.Replacement.Text = "18";
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            sel.Find.Text = "[l332]";
                            sel.Find.Replacement.Text = "18";
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            string xl = "0";
                            string wl = "0";

                            xl = "3";
                            wl = "3";

                            for (int i = 0; i <= 9; i++)
                            {
                                if (Convert.ToString(i) != xl)
                                {
                                    sel.Find.Text = "[l" + wl + "" + i + "1]";
                                    sel.Find.Replacement.Text = "";
                                    sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                    sel.Find.Forward = true;
                                    sel.Find.Format = false;
                                    sel.Find.MatchCase = false;
                                    sel.Find.MatchWholeWord = false;
                                    sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                    sel.Find.Text = "[l" + wl + "" + i + "2]";
                                    sel.Find.Replacement.Text = "";
                                    sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                    sel.Find.Forward = true;
                                    sel.Find.Format = false;
                                    sel.Find.MatchCase = false;
                                    sel.Find.MatchWholeWord = false;
                                    sel.Find.Execute(Replace: WdReplace.wdReplaceAll);
                                }
                            }

                            sel.Find.Text = "[l421]";
                            sel.Find.Replacement.Text = "2";
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            sel.Find.Text = "[l422]";
                            sel.Find.Replacement.Text = "2";
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            xl = "2";
                            wl = "4";

                            for (int i = 0; i <= 9; i++)
                            {
                                if (Convert.ToString(i) != xl)
                                {
                                    sel.Find.Text = "[l" + wl + "" + i + "1]";
                                    sel.Find.Replacement.Text = "";
                                    sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                    sel.Find.Forward = true;
                                    sel.Find.Format = false;
                                    sel.Find.MatchCase = false;
                                    sel.Find.MatchWholeWord = false;
                                    sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                    sel.Find.Text = "[l" + wl + "" + i + "2]";
                                    sel.Find.Replacement.Text = "";
                                    sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                    sel.Find.Forward = true;
                                    sel.Find.Format = false;
                                    sel.Find.MatchCase = false;
                                    sel.Find.MatchWholeWord = false;
                                    sel.Find.Execute(Replace: WdReplace.wdReplaceAll);
                                }
                            }

                            sel.Find.Text = "[l511]";
                            sel.Find.Replacement.Text = "2";
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            sel.Find.Text = "[l512]";
                            sel.Find.Replacement.Text = "2";
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            xl = "1";
                            wl = "5";

                            for (int i = 0; i <= 9; i++)
                            {
                                if (Convert.ToString(i) != xl)
                                {
                                    sel.Find.Text = "[l" + wl + "" + i + "1]";
                                    sel.Find.Replacement.Text = "";
                                    sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                    sel.Find.Forward = true;
                                    sel.Find.Format = false;
                                    sel.Find.MatchCase = false;
                                    sel.Find.MatchWholeWord = false;
                                    sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                    sel.Find.Text = "[l" + wl + "" + i + "2]";
                                    sel.Find.Replacement.Text = "";
                                    sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                    sel.Find.Forward = true;
                                    sel.Find.Format = false;
                                    sel.Find.MatchCase = false;
                                    sel.Find.MatchWholeWord = false;
                                    sel.Find.Execute(Replace: WdReplace.wdReplaceAll);
                                }
                            }

                        }

                        var sub_piping2 = Serv.Get_tbl_piping_qurter_plan2(exist_L.Rows[0]["id"].ToString());
                        if (sub_piping2.Rows.Count != 0)
                        {

                            sel.Find.Text = "[l10]";
                            sel.Find.Replacement.Text = sub_piping2.Rows[0]["l30"].ToString().Replace("\r\n", "\v");
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            sel.Find.Text = "[l021]";
                            sel.Find.Replacement.Text = sub_piping2.Rows[0]["l31"].ToString().Replace("\r\n", "\v");
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            sel.Find.Text = "[l022]";
                            sel.Find.Replacement.Text = sub_piping2.Rows[1]["l31"].ToString().Replace("\r\n", "\v");
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            sel.Find.Text = "[l023]";
                            sel.Find.Replacement.Text = sub_piping2.Rows[2]["l31"].ToString().Replace("\r\n", "\v");
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            sel.Find.Text = "[l0331]";
                            sel.Find.Replacement.Text = "18";
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            sel.Find.Text = "[l0332]";
                            sel.Find.Replacement.Text = "18";
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            string xl = "0";
                            string wl = "0";

                            xl = "3";
                            wl = "3";

                            for (int i = 0; i <= 9; i++)
                            {
                                if (Convert.ToString(i) != xl)
                                {
                                    sel.Find.Text = "[l0" + wl + "" + i + "1]";
                                    sel.Find.Replacement.Text = "";
                                    sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                    sel.Find.Forward = true;
                                    sel.Find.Format = false;
                                    sel.Find.MatchCase = false;
                                    sel.Find.MatchWholeWord = false;
                                    sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                    sel.Find.Text = "[l0" + wl + "" + i + "2]";
                                    sel.Find.Replacement.Text = "";
                                    sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                    sel.Find.Forward = true;
                                    sel.Find.Format = false;
                                    sel.Find.MatchCase = false;
                                    sel.Find.MatchWholeWord = false;
                                    sel.Find.Execute(Replace: WdReplace.wdReplaceAll);
                                }
                            }

                            sel.Find.Text = "[l0421]";
                            sel.Find.Replacement.Text = "2";
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            sel.Find.Text = "[l0422]";
                            sel.Find.Replacement.Text = "2";
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            xl = "2";
                            wl = "4";

                            for (int i = 0; i <= 9; i++)
                            {
                                if (Convert.ToString(i) != xl)
                                {
                                    sel.Find.Text = "[l0" + wl + "" + i + "1]";
                                    sel.Find.Replacement.Text = "";
                                    sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                    sel.Find.Forward = true;
                                    sel.Find.Format = false;
                                    sel.Find.MatchCase = false;
                                    sel.Find.MatchWholeWord = false;
                                    sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                    sel.Find.Text = "[l0" + wl + "" + i + "2]";
                                    sel.Find.Replacement.Text = "";
                                    sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                    sel.Find.Forward = true;
                                    sel.Find.Format = false;
                                    sel.Find.MatchCase = false;
                                    sel.Find.MatchWholeWord = false;
                                    sel.Find.Execute(Replace: WdReplace.wdReplaceAll);
                                }
                            }

                            sel.Find.Text = "[l0511]";
                            sel.Find.Replacement.Text = "2";
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            sel.Find.Text = "[l0512]";
                            sel.Find.Replacement.Text = "2";
                            sel.Find.Wrap = WdFindWrap.wdFindContinue;
                            sel.Find.Forward = true;
                            sel.Find.Format = false;
                            sel.Find.MatchCase = false;
                            sel.Find.MatchWholeWord = false;
                            sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                            xl = "1";
                            wl = "5";

                            for (int i = 0; i <= 9; i++)
                            {
                                if (Convert.ToString(i) != xl)
                                {
                                    sel.Find.Text = "[l0" + wl + "" + i + "1]";
                                    sel.Find.Replacement.Text = "";
                                    sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                    sel.Find.Forward = true;
                                    sel.Find.Format = false;
                                    sel.Find.MatchCase = false;
                                    sel.Find.MatchWholeWord = false;
                                    sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                                    sel.Find.Text = "[l0" + wl + "" + i + "2]";
                                    sel.Find.Replacement.Text = "";
                                    sel.Find.Wrap = WdFindWrap.wdFindContinue;
                                    sel.Find.Forward = true;
                                    sel.Find.Format = false;
                                    sel.Find.MatchCase = false;
                                    sel.Find.MatchWholeWord = false;
                                    sel.Find.Execute(Replace: WdReplace.wdReplaceAll);
                                }
                            }
                        }

                        var sub6 = Serv.GetSub6(exist_L.Rows[0]["id"].ToString());
                        if (sub6.Rows.Count != 0)
                        {
                            Microsoft.Office.Interop.Word.Table axTable2;

                            sel.Find.Text = "[table11]";
                            sel.Find.Execute(Replace: WdReplace.wdReplaceNone);
                            sel.Range.Select();
                            axTable2 = sel.Tables.Add(app.Selection.Range, sub6.Rows.Count + 1, 4);

                            axTable2.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
                            axTable2.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;

                            axTable2.Cell(1, 1).Range.Text = "Region";
                            axTable2.Cell(1, 2).Range.Text = "Inspection";
                            axTable2.Cell(1, 3).Range.Text = "CM Sattion";
                            axTable2.Cell(1, 4).Range.Text = "Date";

                            int start_row = 2;

                            for (int j = 0; j <= sub6.Rows.Count - 1; j++)
                            {
                                axTable2.Cell(start_row, 1).Range.Text = sub6.Rows[j]["l26"].ToString();
                                axTable2.Cell(start_row, 2).Range.Text = sub6.Rows[j]["l27"].ToString();
                                axTable2.Cell(start_row, 3).Range.Text = sub6.Rows[j]["l28"].ToString();
                                axTable2.Cell(start_row, 3).Range.Text = sub6.Rows[j]["l29"].ToString();

                                start_row = start_row + 1;
                            }

                        }
                    }
                    #endregion

                    #region M
                    var exist_M = Serv.GetExistRep_M(hddmas_rep_id.Value);

                    if (exist_M.Rows.Count != 0)
                    {
                        sel.Find.Text = "[m1]";
                        sel.Find.Replacement.Text = exist_M.Rows[0]["cplanwork"].ToString();
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[m2]";
                        sel.Find.Replacement.Text = exist_M.Rows[0]["cprogressresult"].ToString();
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[m3]";
                        sel.Find.Replacement.Text = exist_M.Rows[0]["cfutureplan"].ToString();
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[m4]";
                        sel.Find.Replacement.Text = exist_M.Rows[0]["cproblem"].ToString();
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[m5]";
                        sel.Find.Replacement.Text = exist_M.Rows[0]["mplanwork"].ToString();
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[m6]";
                        sel.Find.Replacement.Text = exist_M.Rows[0]["mprogressresult"].ToString();
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[m7]";
                        sel.Find.Replacement.Text = exist_M.Rows[0]["mfutureplan"].ToString();
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);

                        sel.Find.Text = "[m8]";
                        sel.Find.Replacement.Text = exist_M.Rows[0]["mproblem"].ToString();
                        sel.Find.Wrap = WdFindWrap.wdFindContinue;
                        sel.Find.Forward = true;
                        sel.Find.Format = false;
                        sel.Find.MatchCase = false;
                        sel.Find.MatchWholeWord = false;
                        sel.Find.Execute(Replace: WdReplace.wdReplaceAll);


                    }
                    #endregion

                    #region G
                    var exist_G = Serv.GetExistRep_G(hddmas_rep_id.Value);
                    if (exist_G.Rows.Count != 0)
                    {
                        var sub_other = Serv.GetExistRep_sub_G(exist_G.Rows[0]["id"].ToString());
                        if (sub_other.Rows.Count != 0)
                        {
                            Microsoft.Office.Interop.Word.Table axTable2;

                            sel.Find.Text = "[table12]";
                            sel.Find.Execute(Replace: WdReplace.wdReplaceNone);
                            sel.Range.Select();
                            axTable2 = sel.Tables.Add(app.Selection.Range, sub_other.Rows.Count * 10, 1);


                            int start_row = 1;

                            for (int j = 0; j <= sub_other.Rows.Count - 1; j++)
                            {
                                axTable2.Cell(start_row, 1).Range.Text = "1.7." + (j + 2);
                                axTable2.Cell(start_row, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                start_row = start_row + 1;
                                axTable2.Cell(start_row, 1).Range.Text = "\t" + sub_other.Rows[j]["projectname"].ToString();
                                axTable2.Cell(start_row, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                                start_row = start_row + 1;
                                axTable2.Cell(start_row, 1).Range.Text = "1.7." + (j + 2) + ".1 แผนงาน";
                                axTable2.Cell(start_row, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                start_row = start_row + 1;
                                axTable2.Cell(start_row, 1).Range.Text = "\t" + sub_other.Rows[j]["planwork"].ToString();
                                axTable2.Cell(start_row, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                                start_row = start_row + 1;
                                axTable2.Cell(start_row, 1).Range.Text = "1.7." + (j + 2) + ".2 ผลการดำเนินงาน";
                                axTable2.Cell(start_row, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                start_row = start_row + 1;
                                axTable2.Cell(start_row, 1).Range.Text = "\t" + sub_other.Rows[j]["workresult"].ToString();
                                axTable2.Cell(start_row, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                                start_row = start_row + 1;
                                axTable2.Cell(start_row, 1).Range.Text = "1.7." + (j + 2) + ".3 การดำเนินงานในอนาคต";
                                axTable2.Cell(start_row, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                start_row = start_row + 1;
                                axTable2.Cell(start_row, 1).Range.Text = "\t" + sub_other.Rows[j]["futureplan"].ToString();
                                axTable2.Cell(start_row, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                                start_row = start_row + 1;
                                axTable2.Cell(start_row, 1).Range.Text = "1.7." + (j + 2) + ".4 ปัญหาอุปสรรค์ (ถ้ามี)";
                                axTable2.Cell(start_row, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                start_row = start_row + 1;
                                axTable2.Cell(start_row, 1).Range.Text = "\t" + sub_other.Rows[j]["problem"].ToString();
                                axTable2.Cell(start_row, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;


                                start_row = start_row + 1;
                            }
                        }
                    }
                    #endregion

                    string time = DateTime.Now.ToString("yyyy-MM-ddHHmmss", EngCI);

                    //************************************************

                    doc.SaveAs(Server.MapPath("~/gen_1/Quaterly_report_" + time + ".docx"));
                    doc.Close();

                    var x = Serv.InsertHistory(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", EngCI), HttpContext.Current.Session["assetusername"].ToString(), "Quaterly_report",
                        "~/gen_1/Quaterly_report_" + time + ".docx", "1", "", hddmas_rep_id.Value);

                    hddfile_path.Value = "~/gen_1/Quaterly_report_" + time + ".docx";

                    if (x.Rows.Count != 0)
                    {
                        Serv.UpdateHistory(x.Rows[0]["id"].ToString(), "Quaterly_report_V" + x.Rows[0]["id"].ToString(), x.Rows[0]["id"].ToString(), hddmas_rep_id.Value);
                    }

                    POPUPMSG("บันทึกเรียบร้อย");
                }

            }
            finally
            {
                app.Quit();
            }
        }



    }
}