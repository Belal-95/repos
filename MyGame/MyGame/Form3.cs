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
    public partial class Form3 : Form
    {
        private Button button1;
        private PictureBox pictureBox1;
        private Button button2;

        public Form3()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(37, 312);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "<";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(903, 312);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = ">";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pictureBox1.Location = new System.Drawing.Point(118, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(779, 511);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form3
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1001, 546);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.Name = "Form3";
            this.Text = "WLCOME REN SHU YU (任舒羽)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        int n = 1;
        private void Form3_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.image1;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          //  pictureBox1.Image = Properties.Resources.image1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (n == 2)
            {
                pictureBox1.Image = Properties.Resources.image1;
                n--;
            }

          else  if (n == 3)
            {
                pictureBox1.Image = Properties.Resources.image2;
                n--;
            }
            else if (n == 4)
            {
                pictureBox1.Image = Properties.Resources.image3;
                n--;
            }
            else if (n == 5)
            {
                pictureBox1.Image = Properties.Resources.image4;
                n--;
            }
            else if (n == 6)
            {
                pictureBox1.Image = Properties.Resources.image5;
                n--;
            }
            else if (n == 7)
            {
                pictureBox1.Image = Properties.Resources.image6;
                n--;
            }
            else if (n == 8)
            {
                pictureBox1.Image = Properties.Resources.image7;
                n--;
              //  button2.Enabled = true;

            }
            else if (n == 9)
            {
                pictureBox1.Image = Properties.Resources.image8;
                n--;
                button2.Enabled = true;

            }
            //else if (n == 9)
            //{
            //    pictureBox1.Image = Properties.Resources.image8;
            //    n--;
            //}
            if (n == 1)
            {
                button1.Enabled = false;
            }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            if (n == 1)
            {
                pictureBox1.Image = Properties.Resources.image2;
                n++;
                button1.Enabled = true;
            }
          else  if (n == 2)
            {
                pictureBox1.Image = Properties.Resources.image3;
                n++;
            }
            else if (n == 3)
            {
                pictureBox1.Image = Properties.Resources.image4;
                n++;
            }
            else if (n == 4)
            {
                pictureBox1.Image = Properties.Resources.image5;
                n++;
            }
            else if (n == 5)
            {
                pictureBox1.Image = Properties.Resources.image6;
                n++;
            }
            else if (n == 6)
            {
                pictureBox1.Image = Properties.Resources.image7;
                n++;
            }
            else if (n == 7)
            {
                pictureBox1.Image = Properties.Resources.image8;
                n++;
            }
            else if (n == 8)
            {
                pictureBox1.Image = Properties.Resources.image9;
                n++;
            }
            if (n == 9)
            {
                button2.Enabled = false;
            }
            }

        //private void Form3_Leave(object sender, EventArgs e)
        //{
        //    Form5 f5 = new Form5();
        //    f5.Close();
        // //   Application.Exit(f5);
        //}

        //private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    Form5 f5 = new Form5();
        //    f5.Close();
        //}

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Close();
            Application.Exit();
        }
    }
}
