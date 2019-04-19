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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.ToString() == "English")
            {
                label1.Text = "Congratulations you have successfully passed the first step";
                label2.Text = "What is one of the nicknames that he used to call you?";
                label3.Text = "what is the most animal that you used to mentione or talk about usually?";
              //  label4.Text = "What is one of the neck nicknames that he used to call you?";
                radioButtondog.Text = "dog";
                radioButtonelephant.Text = "elephant";
                radioButtonhorse.Text = "horse";
                radioButtonrabbit.Text = "rabbit";
                label5.Text = "choose 3 countries you have traveled to since you knew him including your country";
                label6.Text = "choose 3 countries he has traveled to since he knew you including his country";
                label4.Text = "you can't leave this empty";


                checkBox1.Text = "China";
                checkBox2.Text = "Panama";
                checkBox3.Text = "Turkey";
                checkBox4.Text = "US";
                checkBox5.Text = "Syria";
                checkBox6.Text = "India";
                checkBox7.Text = "Saudi Arabia";
                checkBox8.Text = "Sudan";
                button1.Text = "Submit";
                this.Text = "Welcome Madeleine ^ __ ^"; 

            }


            else
            {
                label1.Text = "Felicidades, ha pasado con éxito el primer paso";
                label2.Text = "¿Cuál es uno de los apodos con los que solía llamarte?";
                label3.Text = "¿Cuál es el mayor animal que solías mencionar o sobre el que hablas habitualmente?";
               // label4.Text = "¿Cuál es uno de los apodos del cuello que solía llamarte?";
                radioButtondog.Text = "perro";
                radioButtonelephant.Text = "elefante";
                radioButtonhorse.Text = "caballo";
                radioButtonrabbit.Text = "Conejo";
                label5.Text = "elige 3 países a los que has viajado desde que lo conocías, incluido tu país";
                label6.Text = "Elija 3 países a los que ha viajado desde que lo conocía, incluido su país.";
                label4.Text = "no puedes dejar esto vacío";


                checkBox1.Text = "China";
                checkBox2.Text = "Panamá";
                checkBox3.Text = "Turquía";
                checkBox4.Text = "NOS";
                checkBox5.Text = "Siria";
                checkBox6.Text = "India";
                checkBox7.Text = "Arabia Saudita";
                checkBox8.Text = "Sudán";
                button1.Text = "Enviar";
                this.Text = "Bienvenido Madeleine ^ __ ^";



            }




        }
        Form5 f5 = new Form5();
        prefinal br = new prefinal();
        LASTQUEST L1 = new LASTQUEST();
        private void button1_Click(object sender, EventArgs e)
        {
            

            string s1 = textBox1.Text;

            if (s1 == "")
            { 
     label4.Visible = true;
                
                goto bb;
            }


            if (s1 != "")
                label4.Visible = false;

            bool b1, b2, b3, b4, b5, b6, b7, b8;
            b1  = checkBox1.Checked;
            b2 = checkBox2.Checked;
            b3 = checkBox3.Checked;
            b4 = checkBox4.Checked;
            b5 = checkBox5.Checked;
            b6 = checkBox6.Checked;
            b7 = checkBox7.Checked;
            b8 = checkBox8.Checked;


            if (((s1 == "hermosa" || s1 == "HERMOSA" || s1 == " mi hermosa" || s1 == "MI HERMOSA" ||
                s1 == "made" || s1 == "MADE" || s1 == "Made" || s1 == "mado" || s1 == "beatiful"
                    || s1 == "bunny" || s1 == "rabbit" || s1 == "RABBIT") &&
                (b1 == true && b2 == true && b4 == true && b5 == true && b6 == true && b8 == true && b7 == false && b3 == false)
                && (radioButtonrabbit.Checked == true)) || s1=="1")

            {
                L1.Show();
                //  br.Show();
              //  this.Hide();
            }



            //MessageBox.Show("successful");

            else
                if (listBox1.SelectedIndex == 1)
                MessageBox.Show(" Desafortunadamente las informaciones que ha ingresado son incorrectas \n por favor, inténtalo de nuevo ", "que te pasa Madeleine", MessageBoxButtons.OK);


            else
                MessageBox.Show("Unfortunately the informations that you have entered are wrong \n try again please  ", "what is wrong with you Madeleine", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            bb:
            textBox1 .Focus();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = 0;
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
