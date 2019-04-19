using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoriesWithBelal
{
    public partial class LASTQUEST : Form
    {
        public LASTQUEST()
        {
            InitializeComponent();
        }
        prefinal br1= new prefinal();
        Form3 f33 = new Form3();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "m" || textBox1.Text == "M")
            {
                br1.Show();
                f33.Hide();
                this.Hide();
            }
            else
                this.Hide();

        }
    }
}
