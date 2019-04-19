using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp7Examples
{
    public partial class success : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page pp = PreviousPage;
            Control clr = pp.FindControl("textName");
            TextBox tb = (TextBox)clr;
            string name = tb.Text;
            Response.Write("Hello " + name + " welcome to the site");

            //// (OR) in one line
           // string name = ((TextBox)PreviousPage.FindControl("textName") ).Text;
          //  Response.Write("Hello " + name1 + " welcome to the site");

        }
    }
}