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
    public partial class allvideos : Form
    {
        public allvideos()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lockedaway l1 = new lockedaway();
            l1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            closer c1 = new closer();
           c1.Show();
        }
    }
}
