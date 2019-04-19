using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp7Examples
{
    public partial class Validations2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!IsPostBack)
            //Calendar1.Visible = false;
            rvDate.MinimumValue = DateTime.Now.ToShortDateString();
            rvDate.MaximumValue = DateTime.Now.AddDays(90).ToShortDateString();
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtDate.Text = Calendar1.SelectedDate.ToShortDateString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                // write the logic here
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            txtAge.Text = txtDate.Text = txtName.Text = "";
            txtName.Focus();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible)
                Calendar1.Visible = false;
            else
                Calendar1.Visible = true;
        }
    }
}