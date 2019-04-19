using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp7Examples
{
    public partial class Validation6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (RequiredFieldValidator1.IsValid && RequiredFieldValidator2.IsValid)
                Response.Write("Agent login succeeded ");
            else
                Response.Write("Agent login failed ");

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (RequiredFieldValidator3.IsValid && RequiredFieldValidator4.IsValid)
                Response.Write("Customer login succeeded ");
            else
                Response.Write("Customer login failed ");
        }
    }
}