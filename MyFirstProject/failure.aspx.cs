using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp7Examples
{
    public partial class failure : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Name = Request.QueryString["Name"];
            Response.Write("Hello " + Name + " your credentials are invalid");
        }
    }
}