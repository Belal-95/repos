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

namespace WindowsFormDisconnect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlDataAdapter ada;
        DataSet ds;
        SqlCommand cmd;

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationSettings.AppSettings[0]);
            cmd = new SqlCommand();
            cmd.CommandText="select * from tblemployee";
            cmd.Connection = con;
            ada = new SqlDataAdapter();
            ada.SelectCommand = cmd;
            ds = new DataSet();
            ada.Fill(ds, "samp");
            int rowcount = ds.Tables["samp"].Rows.Count;
            for(int i=0;i<rowcount;i++)
            {
                comboBox1.Items.Add(ds.Tables[0].Rows[i][0]);
            }




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // dataGridView1.DataSource = null;
           // dataGridView1.Rows.Clear();
            string selectedid = comboBox1.SelectedItem.ToString();
            ada = new SqlDataAdapter("select * from tblemployee where eid =" + selectedid,con);
            ada.Fill(ds, "samp2");
            dataGridView1.DataSource = ds.Tables[1];
        }
    }
}
