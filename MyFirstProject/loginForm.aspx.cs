using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp7Examples
{
    public partial class loginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            textName.Focus();
            //Response.Write("IsPostBack =" + IsPostBack);
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            if (textName.Text == "belal" && textPwd.Text == "12345")
                lblStatus.Text = "valid user";
            else
                lblStatus.Text = "username or password are wrong";

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            textPwd.Text = textName.Text = "" ;
            textName.Focus();
        }
    }
}