using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp7Examples
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                textName.Focus();
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            if (textName.Text == "belal" && textPwd.Text == "12345")
                Server.Transfer("~/success.aspx");
            else
                Response.Redirect("~/failure.aspx?Name=" +textName.Text);
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            textPwd.Text = textName.Text = "";
            textName.Focus();
        }
    }
}