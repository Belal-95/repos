using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsConnectToDatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        void getalldata()
        {
            cmd = new SqlCommand("select * from tblEmployee", con);
            dr=cmd.ExecuteReader();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationSettings.AppSettings["sqlcon"]);
            con.Open();
            getalldata();
            label1.Text = dr.GetName(0);
            label2.Text = dr.GetName(1);
            label3.Text = dr.GetName(2);
            con.Close();
           
        }
    }
}
