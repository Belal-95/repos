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
    public partial class Form5 : Form
    {
        private Button button1;
        private PictureBox pictureBox1;
        private Button button2;

        public Form5()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(62, 367);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 21);
            this.button1.TabIndex = 0;
            this.button1.Text = "<";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1222, 367);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 21);
            this.button2.TabIndex = 1;
            this.button2.Text = ">";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pictureBox1.Location = new System.Drawing.Point(146, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1070, 683);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form5
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1354, 733);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form5";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        int n = 1;

        Image[] im = new Image[]{Properties.Resources.image1,
            Properties.Resources.image2,Properties.Resources.image3,
            Properties.Resources.image4,Properties.Resources.image5,
            Properties.Resources.image6,Properties.Resources.image7,
            Properties.Resources.image8,Properties.Resources.image9,
            Properties.Resources.image10,Properties.Resources.image11,
            Properties.Resources.image12,Properties.Resources.image13,
            Properties.Resources.image14,Properties.Resources.image15,
            Properties.Resources.image16,Properties.Resources.image17,
            Properties.Resources.image18,Properties.Resources.image19,
            Properties.Resources.image20,Properties.Resources.image21,
            Properties.Resources.image22,Properties.Resources.image23,
            Properties.Resources.image24,Properties.Resources.image25,
            Properties.Resources.image26,Properties.Resources.image27,
            Properties.Resources.image28,Properties.Resources.image29,
            Properties.Resources.image30,Properties.Resources.image31,
            Properties.Resources.image32,Properties.Resources.image33,
            Properties.Resources.image34,Properties.Resources.image35,
            Properties.Resources.image36,Properties.Resources.image37,
            Properties.Resources.image38,Properties.Resources.image39,
            Properties.Resources.image40,Properties.Resources.image41,
            Properties.Resources.image42,Properties.Resources.image43,
            Properties.Resources.image44,Properties.Resources.image45,
            Properties.Resources.image46,Properties.Resources.image47,
            Properties.Resources.image48,Properties.Resources.image49,
            Properties.Resources.image50,Properties.Resources.image51,
            Properties.Resources.image52,Properties.Resources.image53,
            Properties.Resources.image54,Properties.Resources.image55,
            Properties.Resources.image56,
            Properties.Resources.image57,Properties.Resources.image58,
            Properties.Resources.image59,Properties.Resources.image60,
            Properties.Resources.image61,
            Properties.Resources.image62,Properties.Resources.image63,
            Properties.Resources.image64,Properties.Resources.image65,
            };

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
            

            pictureBox1.Image = im[n-2];
           

            //  if (n == 2)
            //  {
            //      pictureBox1.Image = Properties.Resources.image1;
            //      n--;
            //  }

            //else  if (n == 3)
            //  {
            //      pictureBox1.Image = Properties.Resources.image2;
            //      n--;
            //  }
            //  else if (n == 4)
            //  {
            //      pictureBox1.Image = Properties.Resources.image3;
            //      n--;
            //  }
            //  else if (n == 5)
            //  {
            //      pictureBox1.Image = Properties.Resources.image4;
            //      n--;
            //  }
            //  else if (n == 6)
            //  {
            //      pictureBox1.Image = Properties.Resources.image5;
            //      n--;
            //  }
            //  else if (n == 7)
            //  {
            //      pictureBox1.Image = Properties.Resources.image6;
            //      n--;
            //  }
               if (n == im.Length)
            {
            //    pictureBox1.Image = Properties.Resources.image7;
            //    n--;
                button2.Enabled = true;

                 }
            //  else if (n == 9)
            //  {
            //      pictureBox1.Image = Properties.Resources.image8;
            //      n--;

            //  }

            n--;
            if (n == 1)
            {
                button1.Enabled = false;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            pictureBox1.Image = im[n];
            
            if (n == 1)
            {
              //  pictureBox1.Image = Properties.Resources.image2;
            //    n++;
                button1.Enabled = true;
            }
            //else  if (n == 2)
            //  {
            //      pictureBox1.Image = Properties.Resources.image3;
            //      n++;
            //  }
            //  else if (n == 3)
            //  {
            //      pictureBox1.Image = Properties.Resources.image4;
            //      n++;
            //  }
            //  else if (n == 4)
            //  {
            //      pictureBox1.Image = Properties.Resources.image5;
            //      n++;
            //  }
            //  else if (n == 5)
            //  {
            //      pictureBox1.Image = Properties.Resources.image6;
            //      n++;
            //  }
            //  else if (n == 6)
            //  {
            //      pictureBox1.Image = Properties.Resources.image7;
            //      n++;
            //  }
            //  else if (n == 7)
            //  {
            //      pictureBox1.Image = Properties.Resources.image8;
            //      n++;
            //  }

            n++;
            if (n == im.Length)
            {
                button2.Enabled = false;
            }
           
        }
    }
}
