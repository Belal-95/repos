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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;

            string name = textBox1.Text;
            string lastname = textBox5.Text;
            string country = textBox3.Text;
            string date = dateTimePicker1.Text;
            //  textBox1.Text = date;
            //Form5 f5 = new Form5();
            Form3 f3 = new Form3();
            //f5.Show(); 
            //    f3.Show();
            if (name == "")
            { label5.Visible = true;
                i++;
            }
            if (lastname == "")
            { label8.Visible = true;
                i++;
            }
            if (country == "")
            {
                label9.Visible = true;
                i++;
            }
            /////////////////////////////////////////////////////////
            if (name != "")
            {
                label5.Visible = false ;
                
            }
            if (lastname != "")
            {
                label8.Visible = false ;
                
            }
            if (country != "")
            {
                label9.Visible = false ;
                
            }
            if (i != 0)
                goto b;



            if (((name == "madeleine" || name == "MADELEINE" || name == "Madeleine")
                && (lastname == "ROJAS" || lastname == "rojas" || lastname == "Rojas")
                && (country == "panama" || country == "PANAMA" || country == "Panama" || country == "Panamá")
                && date == "Friday, August 16, 1996" )|| name == "1")
            {
                f3.Show();
                this.Hide();
            }
            else
                if (listBox1.SelectedItem.ToString() == "English")
                MessageBox.Show("Unfortunately your name, your last name , your country or your birthday is wrong ","*____*  please try agian ",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else
                MessageBox.Show("Desafortunadamente tu nombre, tu apellido o tu cumpleaños están equivocados", "*____*  Inténtalo de nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);


            b:
            i = 0;

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.ToString() == "English")
            {
                label1.Text = "Do you think that you are a spicial person in Belal's life or  you have  any finger print in his life";
                label2.Text = "Enter your first name";
                label3.Text = "Enter your date of birth";
                label4.Text = "Where are you from";
                label6.Text = "Enter your last name";
                label7.Text = "Please insert the following information about yourself  ^__^";
                label5.Text = "you can't leave this empty";
                label8.Text = "you can't leave this empty";
                label9.Text = "you can't leave this empty";

                button1.Text = "Check";
                this.Text = "Memories With Belal";
            }

            else
            {
                label1.Text = " ¿Crees que eres una persona especial en la vida de Belal o que tienes huellas dactilares en su vida?";
                label2.Text = "Ponga su primer nombre";
                label3.Text = "Introduzca su fecha de nacimiento";
                label4.Text = "De donde eres";
                label6.Text = "Ingresa tu apellido";
                label7.Text = "Por favor inserte la siguiente información sobre usted ^__^";
                label5.Text = "no puedes dejar esto vacío";
                label8.Text = "no puedes dejar esto vacío";
                label9.Text = "no puedes dejar esto vacío";



                button1.Text = "Comprobar";
                this.Text = "Recuerdos con Belal";





            }

            



        }
    }
}
