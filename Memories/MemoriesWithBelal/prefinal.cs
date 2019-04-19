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
    public partial class prefinal : Form
    {
        public prefinal()
        {
            InitializeComponent();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            finall fi = new finall();
            fi.Show();
        }
       // Form5 f5 = new Form5();
        private void button1_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }
       
        private void button4_Click(object sender, EventArgs e)
        {
            vidGoogleDrive vid = new vidGoogleDrive();
            vid.Show();
        }

        private void prefinal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
      //fingerPrints f1 = new fingerPrints();
        private void button2_Click(object sender, EventArgs e)
        {
            

        }
        private void button5_Click(object sender, EventArgs e)
        {
            allvideos a1 = new allvideos();

            a1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            fingerPrints f1 = new fingerPrints();
            f1.Show();
        }
    }
}
