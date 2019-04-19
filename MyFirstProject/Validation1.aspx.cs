using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp7Examples
{
    public partial class Validation1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtname.Focus();
            }
            txtname.Attributes.Add("onblur", "ValidatorValidate(rfvName)");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           

            // This if you have many validation controls and want to check it all one time
            //if(Page.IsValid)

            if (rfvName.IsValid && rfvCountry.IsValid)
            {
                // here we write the code of saving the information
                lblStatus.Text = "Data is saved to Database";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblStatus.Text = "Validation Failed , please check your data";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}