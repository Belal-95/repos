using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace MyFirstProject
{
    public partial class StudentsDetailsTable : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=Server;Database=belal1;Integrated Security=yes");
            cmd.Connection = con;
            if (!IsPostBack)
                loadData();

        }

        private void loadData()
        {
            cmd.CommandText = "select * from student order by name";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet

        }
    }
}