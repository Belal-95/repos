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
    public partial class playersINPUT : Form
    {
        public playersINPUT()
        {
            InitializeComponent();
        }
        bool m1 = false, m2 = false;
        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            string s = maskedTextBox1.Text;
            int v1, v2, v3, v4;

            char[] y1 = s.ToCharArray();
            try
            {
                v1 = (Int32)y1[15] - 48;
                v2 = (Int32)y1[16] - 48;
                v3 = (Int32)y1[17] - 48;
                v4 = (Int32)y1[18] - 48;

              

                //  MessageBox.Show($"v1={v1}  v2={v2}  v3={v3}  v4={v4}");



                int[] y = new int[4] { v1, v2, v3, v4 };


                bool b = false;
                for (int i = 0; i < 4; i++)
                {
                    if (b == true)
                        break;
                    for (int j = 0; j < 4; j++)
                    {
                        if (i == j)
                            continue;
                        if (y[i] == y[j] || y[i] == -16 || y[0] == -16 || y[1] == -16 || y[2] == -16 || y[3] == -16)
                        {

                            // Console.WriteLine("the digits cannot be duplicated ");
                            MessageBox.Show("the digits cannot be duplicated and you can not leave any place empty \n " +
                                "please choose other 4 digits number and the numbers should not be duplicated "
                                , "sorry ^_^ ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            maskedTextBox1.Clear();
                            maskedTextBox1.Focus();
                            m1 = false;
                            goto b;
                            //b = true;
                            //break;
                        }
                    }
                }
                m1 = true;
               // if (m1 == true && m2 == true)
                    button1.Enabled = true;
                button1.Focus();
            }
            catch
            { //goto b;
                button1.Enabled = false;
                m1 = false;
            }
        //  button1.Enabled = true;

        //------------------------------------------------------------ WAY 1 TO SEPERATE THE NUMBER TO 4 DIGITS
        // char[] y1 = s.ToCharArray();
        //if( y1[15] !='' && y1[16] != null && y1[17] != null && y1[18] != null)
        b:
            int x = 0;
        }




        int click = 1;
        // Form2 p1 = new Form2();
       public static player1 p1 = new player1();
        public static player2 p2 = new player2();



        private void button1_Click(object sender, EventArgs e)
        {
            int v1, v2, v3, v4;
            string s = maskedTextBox1.Text;


            //------------------------------------------------------------ WAY 1 TO SEPERATE THE NUMBER TO 4 DIGITS
            char[] y1 = s.ToCharArray();
            v1 = (Int32)y1[15] - 48;
            v2 = (Int32)y1[16] - 48;
            v3 = (Int32)y1[17] - 48;
            v4 = (Int32)y1[18] - 48;

            if (click == 1)
            {

                ConfigurationSettings.AppSettings.Set("1", $"{v1}");
                ConfigurationSettings.AppSettings.Set("2", $"{v2}");
                ConfigurationSettings.AppSettings.Set("3", $"{v3}");
                ConfigurationSettings.AppSettings.Set("4", $"{v4}");

                label1.Text = "player " + askingform.n2 + " please enter your number and do 'nt let the other player see it";
                click++;
                maskedTextBox1.Clear();
                maskedTextBox1.Focus();
            }
            else
            {

                ConfigurationSettings.AppSettings.Set("5", $"{v1}");
                ConfigurationSettings.AppSettings.Set("6", $"{v2}");
                ConfigurationSettings.AppSettings.Set("7", $"{v3}");
                ConfigurationSettings.AppSettings.Set("8", $"{v4}");

                p2.Show();
                p1.Show();

                foreach (Control c in p2.Controls)
                {
                    if(c is MaskedTextBox || c is Button)
                    c.Enabled = false;

                }
                this.Hide();

                
            }

        }

        private void playersINPUT_Load(object sender, EventArgs e)
        {
            label1.Text = "player " + askingform.n1 + " please enter your number and do 'nt let the other player see it";
            label2.Text = "player " + askingform.n2 + " please enter your number and do 'nt let the other player see it";
            button1.Enabled = false;

        }

        private void playersINPUT_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void maskedTextBox2_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
