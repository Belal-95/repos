using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f2 = new MyGame.Form3();

            //Application.Run(new Form2());
            string s1 = textBox1.Text;
            string s2 = textBox2.Text;
            if ((s1 == "任舒羽" || s1 == "ren shu yu") && (s2 == "renbel" || s2 == "RENBEL"))
                f2.Show();
            //      || s1=="REN SHU YU" || s1=="belal"||s1=="BELAL")



            else
            {
                MessageBox.Show("wrong username or password try again you should write your username and the password correctly to log in");
                textBox1.Text = null;
                textBox2.Text = null;

            }
        }
    }
}
