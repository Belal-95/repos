using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp7Examples
{
    public partial class Validation3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cvDateLTD.ValueToCompare = DateTime.Now.ToShortDateString();
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtdate.Text = Calendar1.SelectedDate.ToShortDateString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            { //implement logic for saving data
            }
        }
    }
}