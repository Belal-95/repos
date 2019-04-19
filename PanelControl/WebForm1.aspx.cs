using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PanelControl
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlagent.Visible = true;
            pnlcustomer.Visible = false;
        }

        protected void btnagent_Click(object sender, EventArgs e)
        {
            pnlagent.Visible = true;
            pnlcustomer.Visible = false;
        }
    }
}