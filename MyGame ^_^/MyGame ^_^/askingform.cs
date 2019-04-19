using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame____
{
    public partial class askingform : Form
    {
        public askingform()
        {
            InitializeComponent();
        }

        playersINPUT plin = new playersINPUT();
        Form2 f = new Form2();
     public static  player1 p1 = new player1();
     public static player2 p2 = new player2();
       public static string n1, n2;


        private void button1_Click(object sender, EventArgs e)
        {
           
            n1 = textBox1.Text;
            n2 = textBox2.Text;
            if (radioButton1.Checked == true)
            {
                f.Show();
                this.Hide();
            }
            else
            {
                //p1.Show();
                //p2.Show();
               
                plin.Show();
                this.Hide();
            }
           
            
            //ConfigurationSettings.AppSettings.Set("10", textBox1.Text);
            //ConfigurationSettings.AppSettings.Set("11", $"{textBox2.Text}");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            if (radioButton1.Checked == false)
            {
                label2.Text = "player1 name";
                textBox1.Visible = true;
                label2.Visible = true;
                textBox2.Visible = true;
                label3.Visible = true;
            }
            else
            {
                label2.Text = "Enter your name";
                textBox1.Visible = true;
                label2.Visible = true;
                textBox2.Visible = false;
                label3.Visible = false;

            }




        }

        private void askingform_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            if (radioButton2.Checked == true)
            {
                textBox1.Visible = true;
                label2.Visible = true;
                textBox2.Visible = true;
                label3.Visible = true;
            }
            else
            {
                textBox1.Visible = true;
                label2.Visible = true;
                textBox2.Visible = false;
                label3.Visible = false;
            }
        }
    }
}
