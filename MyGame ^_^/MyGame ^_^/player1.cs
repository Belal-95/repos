﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyGame____
{
    public partial class player1 : Form
    {
        public player1()
        {
            InitializeComponent();
        }

      public  int click = 1;
      //  askingform ask = new askingform();


        private void label1_Click(object sender, EventArgs e)
        {
            //  MessageBox.Show(ConfigurationSettings.AppSettings[0] + ConfigurationSettings.AppSettings[1] +
            //     ConfigurationSettings.AppSettings[2] + ConfigurationSettings.AppSettings[3]);

            maskedTextBox1.Text = ConfigurationSettings.AppSettings[0] + ConfigurationSettings.AppSettings[1] +
               ConfigurationSettings.AppSettings[2] + ConfigurationSettings.AppSettings[3];
        }

        private void player1_Load(object sender, EventArgs e)
        {
            // label2.Text = ConfigurationSettings.AppSettings["name1"];

            //SqlConnection con = new SqlConnection("server=.;Database=MyGame;Integrated Security=yes");
            //con.Open();
            //SqlCommand cmd = new SqlCommand("update player_1 set number =''  where id=1", con);
            //cmd.ExecuteNonQuery();
            //con.Close();
            if (askingform.n1 == "")
                askingform.n1 = " player1";
            this.Text = askingform.n1;
            label2.Text = askingform.n1 + " it is your turn now ";

            //int i = 1;
            //Control c = new Control();
            //foreach (Control c in this.Controls)
            //{
            //    if (c is TextBox)
            //        c.Name = "text" + i;
            //    i++;
            //}


            // int x1, x2, x3, x4, c = 0;
            //// int v1 = 0, v2 = 0, v3 = 0, v4 = 0, xx = 0, oo = 0;

            // Random rnd = new Random();
            // x1 = rnd.Next(10);
            // x2 = rnd.Next(10);
            // while (x2 == x1)
            //     x2 = rnd.Next(10);

            // x3 = rnd.Next(10);
            // while (x3 == x1 || x3 == x2)
            //     x3 = rnd.Next(10);

            // x4 = rnd.Next(10);
            // while (x4 == x1 || x4 == x2 || x4 == x3)
            //     x4 = rnd.Next(10);

            // //int[] x = new int[4];
            // //x[0] = x1;
            // //x[1] = x2;
            // //x[2] = x3;
            // //x[3] = x4;

            // ConfigurationSettings.AppSettings.Set("1", $"{x1}");
            // ConfigurationSettings.AppSettings.Set("2", $"{x2}");
            // ConfigurationSettings.AppSettings.Set("3", $"{x3}");
            // ConfigurationSettings.AppSettings.Set("4", $"{x4}");
            // MessageBox.Show(ConfigurationSettings.AppSettings[0]+ ConfigurationSettings.AppSettings[1]+
            //     ConfigurationSettings.AppSettings[2]+ ConfigurationSettings.AppSettings[3]);

            //text1.Text = ConfigurationSettings.AppSettings["9"];
            //text2.Text = ConfigurationSettings.AppSettings["10"];
            //text3.Text = ConfigurationSettings.AppSettings["11"];
            //text4.Text = ConfigurationSettings.AppSettings["12"];




        }
        //int k=1;
        private void callplayer2(player2 p2)
        {
            p2.Show();

        }

        private void xo(int x, int o, Control t)
        {
            if (o == 0 && x == 0)
                t.Text = "\t----";
            else
            {
                String ss = "", kk = "";
                for (int i = 0; i < o; i++)
                    ss = ss + "o";

                for (int i = 0; i < x; i++)
                    kk = kk + "x";
                t.Text = $"\t{ss}" + kk;
            }
        }

        private void player1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


      
       /////////////////////////////////////////////////////////////////////////////////////////////////////
      
        void setthetextboxes()
        {
            MessageBox.Show("................................................................");
            int i = 9;
            ConfigurationSettings.AppSettings.Set($"{i}", text1.Text);
            MessageBox.Show("text box" + (i - 8) + "  " + ConfigurationSettings.AppSettings[$"{i}"]);
            i++;
            ConfigurationSettings.AppSettings.Set($"{i}", text2.Text);
            i++;
            ConfigurationSettings.AppSettings.Set($"{i}", text3.Text);
            i++;
            ConfigurationSettings.AppSettings.Set($"{i}", text4.Text);
            i++;
            ConfigurationSettings.AppSettings.Set($"{i}", text5.Text);
            i++;
            ConfigurationSettings.AppSettings.Set($"{i}", text6.Text);
            i++;
            ConfigurationSettings.AppSettings.Set($"{i}", text7.Text);
            i++;
            ConfigurationSettings.AppSettings.Set($"{i}", text8.Text);
            i++;
            ConfigurationSettings.AppSettings.Set($"{i}", text9.Text);
            i++;
            ConfigurationSettings.AppSettings.Set($"{i}", text10.Text);
            i++;
            ConfigurationSettings.AppSettings.Set($"{i}", text11.Text);
            i++;
            ConfigurationSettings.AppSettings.Set($"{i}", text12.Text);
            i++;
            ConfigurationSettings.AppSettings.Set($"{i}", text13.Text);
            i++;
            ConfigurationSettings.AppSettings.Set($"{i}", text14.Text);
            i++;
            ConfigurationSettings.AppSettings.Set($"{i}", text15.Text);
            i++;
            ConfigurationSettings.AppSettings.Set($"{i}", text16.Text);
            i++;
            ConfigurationSettings.AppSettings.Set($"{i}", text17.Text);
            i++;
            ConfigurationSettings.AppSettings.Set($"{i}", text18.Text);
            i++;
            ConfigurationSettings.AppSettings.Set($"{i}", text19.Text);
            i++;
            ConfigurationSettings.AppSettings.Set($"{i}", text20.Text);
            i++;
            ConfigurationSettings.AppSettings.Set($"{i}", text21.Text);
            i++;
            ConfigurationSettings.AppSettings.Set($"{i}", text22.Text);
            i++;
            ConfigurationSettings.AppSettings.Set($"{i}", text23.Text);
            i++;
            ConfigurationSettings.AppSettings.Set($"{i}", text24.Text);
            i++;
            ConfigurationSettings.AppSettings.Set($"{i}", text25.Text);
            i++;
            ConfigurationSettings.AppSettings.Set($"{i}", text26.Text);
            i++;
            ConfigurationSettings.AppSettings.Set($"{i}", text27.Text);
            i++;
            ConfigurationSettings.AppSettings.Set($"{i}", text28.Text);
            i++;
            ConfigurationSettings.AppSettings.Set($"{i}", text29.Text);
            i++;
            ConfigurationSettings.AppSettings.Set($"{i}", text30.Text);
            //foreach (Control c in this.Controls)
            //{
            //    if (c is TextBox)
            //    {
            //        ConfigurationSettings.AppSettings.Set($"{i}", c.Text);
            //        i++;
            //    }
            //    //   MessageBox.Show("text box" + (i-8) + "  " + ConfigurationSettings.AppSettings["9"]);
            //    //   i++;
            //}
            //i = 9;
            //MessageBox.Show("text box" + (i - 8) + "  " + ConfigurationSettings.AppSettings[$"{i}"]);
            //MessageBox.Show("text box" + (i - 8) + "  " + ConfigurationSettings.AppSettings[$"{i+1}"]);
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////



        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //if(k==1)
            //{
            //    int x1, x2, x3, x4, c = 0;

              player2 pl2 = new player2();

            if (click == 1)
            {

                

                //int x1, x2, x3, x4;


                //Random rnd = new Random();
                //x1 = rnd.Next(10);
                //x2 = rnd.Next(10);
                //while (x2 == x1)
                //    x2 = rnd.Next(10);

                //x3 = rnd.Next(10);
                //while (x3 == x1 || x3 == x2)
                //    x3 = rnd.Next(10);

                //x4 = rnd.Next(10);
                //while (x4 == x1 || x4 == x2 || x4 == x3)
                //    x4 = rnd.Next(10);



                //ConfigurationSettings.AppSettings.Set("1", $"{x1}");
                //ConfigurationSettings.AppSettings.Set("2", $"{x2}");
                //ConfigurationSettings.AppSettings.Set("3", $"{x3}");
                //ConfigurationSettings.AppSettings.Set("4", $"{x4}");
                ////  MessageBox.Show(ConfigurationSettings.AppSettings[0] + ConfigurationSettings.AppSettings[1] +
                ////     ConfigurationSettings.AppSettings[2] + ConfigurationSettings.AppSettings[3]);
            }


            int v1 = 0, v2 = 0, v3 = 0, v4 = 0, xx = 0, oo = 0;






            string s = maskedTextBox1.Text;


            //------------------------------------------------------------ WAY 1 TO SEPERATE THE NUMBER TO 4 DIGITS
            char[] y1 = s.ToCharArray();
            v1 = (Int32)y1[15] - 48;
            v2 = (Int32)y1[16] - 48;
            v3 = (Int32)y1[17] - 48;
            v4 = (Int32)y1[18] - 48;











            //------------------------------------------------------------ WAY 1 FINISH

            //------------------------------------------------------------ WAY 2 TO SEPERATE THE NUMBER TO 4 DIGITS
            //  string s1 = string.Copy(s);
            //  string g1 = s.Remove(1);

            ////  MessageBox.Show("g1 = " + g1);

            //  v1 = Int32.Parse(g1);



            //  string k2 = s.Remove(0, 1);

            //  string g2 = k2.Remove(1);

            //  v2 = Int32.Parse(g2);


            //  string k3 = s.Remove(0, 2);

            //  string g3 = k3.Remove(1);

            //  v3 = Int32.Parse(g3);



            //  string k4 = s.Remove(0, 3);


            //  v4 = Int32.Parse(k4);

            //------------------------------------------------------------ WAY 2 FINISH 

            int[] y = new int[4] { v1, v2, v3, v4 };


            //bool b = false;
            //for (int i = 0; i < 4; i++)
            //{
            //    if (b == true)
            //        break;
            //    for (int j = 0; j < 4; j++)
            //    {
            //        if (i == j)
            //            continue;
            //        if (y[i] == y[j])
            //        {

            //           // Console.WriteLine("the digits cannot be duplicated ");
            //          // MessageBox.Show("the digits cannot be duplicated",)
            //            goto belal;
            //            b = true;
            //            break;
            //        }
            //    }
            //}



            int[] x = new int[4];
            x[0] = Int32.Parse(ConfigurationSettings.AppSettings["5"]);
            x[1] = Int32.Parse(ConfigurationSettings.AppSettings["6"]);
            x[2] = Int32.Parse(ConfigurationSettings.AppSettings["7"]);
            x[3] = Int32.Parse(ConfigurationSettings.AppSettings["8"]);



            //int b = y[0] ;
            //MessageBox.Show("" + y[0] + y[1] + y[2] + y[3] + b);
            //MessageBox.Show($"  {y[0]} + {y[1]} + {y[2]} + {y[3]} + {b}");


            for (int i = 0; i < 4; i++)
            {
                if (x[i] == y[i])
                    xx++;
                for (int j = 0; j < 4; j++)
                {
                    if (i == j)
                        continue;
                    if (x[i] == y[j])
                        oo++;

                }
            }

            //  MessageBox.Show($"you got {xx} x and {oo} o ");


            // char[] y = new char[4];
            //
            // char[] y = s.ToCharArray();
            // int b = y[0];
            // MessageBox.Show(" + y[0]+ y[1] + y[2] + y[3]+b ");
            // //MessageBox.Show("" + s[1] + s[2] + s[3] + s[4]);
            //// MessageBox.Show(s);


            // char[] y1 = new char[4];
            // s = maskedTextBox1.Text;

            //char[] y1 = s.ToCharArray();
            //int b = (Int32)y1[0] - 48;
            //MessageBox.Show("" + y1[0] + y1[1] + y1[2] + y1[3] + b);
            //MessageBox.Show($"  {y1[0]} + {y1[1]} + {y1[2]} + {y1[3]} + {b}");

            if (click == 1)
            {

                text1.Text = s;
                //text2.Text= $"you got {xx} x and { oo}  o ";//way 1
                xo(xx, oo, text2);//way 2
            }
            if (click == 2)
            {
                text3.Text = s;
                // text4.Text = $"you got {xx} x and { oo}  o ";
                xo(xx, oo, text4);
            }
            if (click == 3)
            {
                text5.Text = s;
                //text6.Text = $"you got {xx} x and { oo}  o ";
                xo(xx, oo, text6);
            }
            if (click == 4)
            {
                text7.Text = s;
                //text8.Text = $"you got {xx} x and { oo}  o ";
                xo(xx, oo, text8);
            }
            if (click == 5)
            {
                text9.Text = s;
                //text10.Text = $"you got {xx} x and { oo}  o ";
                xo(xx, oo, text10);
            }
            if (click == 6)
            {
                text11.Text = s;
                //text12.Text = $"you got {xx} x and { oo}  o ";
                xo(xx, oo, text12);
            }
            if (click == 7)
            {
                text13.Text = s;
                //text14.Text = $"you got {xx} x and { oo}  o ";
                xo(xx, oo, text14);
            }
            if (click == 8)
            {
                text15.Text = s;
                //text16.Text = $"you got {xx} x and { oo}  o ";
                xo(xx, oo, text16);
            }
            if (click == 9)
            {
                text17.Text = s;
                //text18.Text = $"you got {xx} x and { oo}  o ";
                xo(xx, oo, text18);
            }
            if (click == 10)
            {
                text19.Text = s;
                //text20.Text = $"you got {xx} x and { oo}  o ";
                xo(xx, oo, text20);
            }
            if (click == 11)
            {
                text21.Text = s;
                // text22.Text = $"you got {xx} x and { oo}  o ";
                xo(xx, oo, text22);
            }
            if (click == 12)
            {
                text23.Text = s;
                // text24.Text = $"you got {xx} x and { oo}  o ";
                xo(xx, oo, text24);
            }
            if (click == 13)
            {
                text25.Text = s;
                // text26.Text = $"you got {xx} x and { oo}  o ";
                xo(xx, oo, text26);
            }
            if (click == 14)
            {
                text27.Text = s;
                // text28.Text = $"you got {xx} x and { oo}  o ";
                xo(xx, oo, text28);
            }
            if (click == 15)
            {
                text29.Text = s;
                // text30.Text = $"you got {xx} x and { oo}  o ";
                xo(xx, oo, text30);
            }
            if (click == 16)
            {
                text31.Text = s;
                // text32.Text = $"you got {xx} x and { oo}  o ";
                xo(xx, oo, text32);
            }



            if (xx == 4)
            {
                DialogResult dt = MessageBox.Show($"congradulations {askingform.n1} you have known the number by {click} times \n it is the last chance for {askingform.n2}"
                    , $"^_^ it is the last chance for {askingform.n2} "
                    , MessageBoxButtons.OK);

                // click = -1;


                //if (dt == DialogResult.Yes)
                //{
                //    foreach (Control c in this.Controls)
                //    {
                //        if (c is TextBox)
                //            c.Text = "";
                //        click = 0;
                //        //Form2 f2 = new Form2();
                //        //f2.Load();
                //    }
                //}
                //else
                //{
                //    Application.Exit();
                //}
                playersINPUT.p2.zz = true;
            }
            click++;

      //  belal:

            maskedTextBox1.Clear();
            maskedTextBox1.Focus();
            //  setthetextboxes();
            //callplayer2(pl2);
            //  pl2.Show();
            //   this.Hide();
            foreach (Control c in this.Controls)
                c.Enabled = false;
            label2.Text = askingform.n1;
            playersINPUT.p2.lable1set();
            foreach (Control c in playersINPUT.p2.Controls)
            {
                c.Enabled = true;
                if (c is Button)
                    c.Enabled = false;
                if (c is MaskedTextBox)
                    c.Focus();
            }
            
        }
      public  void lable1set()
        { label2.Text = askingform.n1 + " it is your turn now"; }


        private void maskedTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            //  MessageBox.Show("zzzzzzzzzzzzzz");
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
                            goto b;
                            //b = true;
                            //break;
                        }
                    }
                }
                button1.Enabled = true;
                button1.Focus();
            }
            catch
            { //goto b;
                button1.Enabled = false;
            }
        //  button1.Enabled = true;

        //------------------------------------------------------------ WAY 1 TO SEPERATE THE NUMBER TO 4 DIGITS
        // char[] y1 = s.ToCharArray();
        //if( y1[15] !='' && y1[16] != null && y1[17] != null && y1[18] != null)
        b:
            int x = 0;
        }

        private void n(object sender, EventArgs e)
        {

        }
    }
}
