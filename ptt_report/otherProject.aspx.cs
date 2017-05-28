using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ptt_report
{
    public partial class otherProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnImport_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddOtherPro_Click(object sender, EventArgs e)
        {
            if(divOther1.Visible == true && divOther2.Visible == false)
            {
                divOther2.Visible = true;
            }
            else if (divOther2.Visible == true && divOther3.Visible == false)
            {
                divOther3.Visible = true;
            }
            else if (divOther3.Visible == true && divOther4.Visible == false)
            {
                divOther4.Visible = true;
            }
            else if (divOther4.Visible == true && divOther5.Visible == false)
            {
                divOther5.Visible = true;
            }
        }

        protected void btnsave1_Click(object sender, EventArgs e)
        {

        }

        protected void btnsave5_Click(object sender, EventArgs e)
        {

        }

        protected void btnsave4_Click(object sender, EventArgs e)
        {

        }

        protected void btnsave3_Click(object sender, EventArgs e)
        {

        }

        protected void btnsave2_Click(object sender, EventArgs e)
        {

        }
    }
}