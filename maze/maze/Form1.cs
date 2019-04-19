using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace maze
{


    public partial class Form1 : Form
    {
        SqlConnection connection;
        string connectionString;

        public Form1()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["maze.Properties.Settings.ConnectionString"].ConnectionString;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            conn();
        }

        public void conn()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM MazeTable", connection))
            { 
            DataTable dt = new DataTable();
              adapter.Fill(dt);

                listBox1.DisplayMember = "deposit";
                listBox1.ValueMember = "Id";
                listBox1.DataSource = MazeTable;
           // connection.Open();


        }
        }

    }
}
