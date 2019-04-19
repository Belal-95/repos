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
    public partial class finall : Form
    {
        public finall()
        {
            InitializeComponent();
        }

        Image[] im1 = new Image[]{Properties.Resources.images_1,
            Properties.Resources.images_2,Properties.Resources.images_3,
            Properties.Resources.images_4,Properties.Resources.images_5,
            Properties.Resources.images_6,Properties.Resources.images_7,
            Properties.Resources.images_8,Properties.Resources.images_9,
            Properties.Resources.images_10,Properties.Resources.images_11,
            Properties.Resources.images_12,Properties.Resources.images_13,
            Properties.Resources.images_14,Properties.Resources.images_15,
            Properties.Resources.images_16,Properties.Resources.images_17,
            Properties.Resources.images_18,Properties.Resources.images_19,
            Properties.Resources.images_20,Properties.Resources.images_21,
            Properties.Resources.images_22,Properties.Resources.images_23,
            Properties.Resources.images_24,Properties.Resources.images_25,
            Properties.Resources.images_26,Properties.Resources.images_27,
            Properties.Resources.images_28,Properties.Resources.images_29,
            Properties.Resources.images_30,Properties.Resources.images_31,
            Properties.Resources.images_32,Properties.Resources.images_33,
            Properties.Resources.images_34,Properties.Resources.images_35,
            Properties.Resources.images_36,Properties.Resources.images_37,
            Properties.Resources.images_38,Properties.Resources.images_39,
            Properties.Resources.images_40,Properties.Resources.images_41,
            Properties.Resources.images_42,Properties.Resources.images_43,
            Properties.Resources.images_44,Properties.Resources.images_45,
            Properties.Resources.images_46,Properties.Resources.images_47,
            Properties.Resources.images_48,Properties.Resources.images_49,
            Properties.Resources.images_50,Properties.Resources.images_51,
            Properties.Resources.images_52,Properties.Resources.images_53,
            Properties.Resources.images_54,Properties.Resources.images_55,
            Properties.Resources.images_56,
            Properties.Resources.images_57,Properties.Resources.images_58,
            Properties.Resources.images_59,Properties.Resources.images_60,
            Properties.Resources.images_61,
            Properties.Resources.images_62,Properties.Resources.images_63
           
            };


        private void finall_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.images_1;
        }
        //private  void InitializeComponent()
        //{



        //}
        int n = 1;
        private void button1_Click(object sender, EventArgs e)
        {

            pictureBox1.Image = im1[n - 2];

            if (n == im1.Length)
           
                button2.Enabled = true;
            n--;
            if (n == 1)
            {
                button1.Enabled = false;
            }

            //if (n == 2)
            //{
            //    pictureBox1.Image = Properties.Resources.WhatsApp_Image_2017_08_12_at_5_20_47_PM;
            //    n--;
            //}

            //else if (n == 3)
            //{
            //    pictureBox1.Image = Properties.Resources.image51;
            //    n--;
            //    button2.Enabled = true;
            //}
            //else if (n == 4)
            //{
            //    pictureBox1.Image = Properties.Resources.image3;
            //    n--;
            //}
            //else if (n == 5)
            //{
            //    pictureBox1.Image = Properties.Resources.image4;
            //    n--;
            //}
            //else if (n == 6)
            //{
            //    pictureBox1.Image = Properties.Resources.image5;
            //    n--;
            //}
            //else if (n == 7)
            //{
            //    pictureBox1.Image = Properties.Resources.image6;
            //    n--;
            //}
            //else if (n == 8)
            //{
            //    pictureBox1.Image = Properties.Resources.image7;
            //    n--;
            //    button2.Enabled = true;

            //}
            //else if (n == 9)
            //{
            //    pictureBox1.Image = Properties.Resources.image8;
            //    n--;
            //}
            //if (n == 1)
            //{
            //    button1.Enabled = false;
            //    button2.Enabled = true;
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {

            pictureBox1.Image = im1[n];

            if (n == 1)
           
                button1.Enabled = true;

            n++;
            if (n == im1.Length)
            {
                button2.Enabled = false;
            }
            //if (n == 1)
            //{
            //    pictureBox1.Image = Properties.Resources.image51;
            //    n++;
            //    button1.Enabled = true;
            //}
            //if (n == 2)
            //{
            //    button2.Enabled = false;
            //}
            //else if (n == 2)
            //{
            //    pictureBox1.Image = Properties.Resources.image3;
            //    n++;
            //}
            //else if (n == 3)
            //{
            //    pictureBox1.Image = Properties.Resources.image4;
            //    n++;
            //}
            //else if (n == 4)
            //{
            //    pictureBox1.Image = Properties.Resources.image5;
            //    n++;
            //}
            //else if (n == 5)
            //{
            //    pictureBox1.Image = Properties.Resources.image6;
            //    n++;
            //}
            //else if (n == 6)
            //{
            //    pictureBox1.Image = Properties.Resources.image7;
            //    n++;
            //}
            //else if (n == 7)
            //{
            //    pictureBox1.Image = Properties.Resources.image8;
            //    n++;
            //}
            //if (n == 8)
            //{
            //    button2.Enabled = false;
            //}
        }


    }
}
