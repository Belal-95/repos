using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp7Examples
{
    public partial class Validations5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void cvMobileOrEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (txtmobile.Text.Trim().Length == 0 && txtemail.Text.Trim().Length == 0)
                args.IsValid = false;
            else
                args.IsValid = true;
        }

        protected void cvComments_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (txtcomments.Text.Length < 50)
                args.IsValid = false;
            else
                args.IsValid = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            txtcomments.Text = txtemail.Text = txtmobile.Text = txtname.Text = "";
            txtname.Focus();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // save data logic

        }
    }
}