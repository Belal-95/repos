using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;

namespace WindowsFormsApp3
{
    public partial class Form1 : MaterialSkin .Controls .MaterialForm 
    {
        public Form1()
        {
            InitializeComponent();
            var skinmanager = MaterialSkinManager.Instance;
            skinmanager.AddFormToManage(this);
            skinmanager.Theme = MaterialSkinManager.Themes.DARK;
            skinmanager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void belalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("HELLO I AM BELAL");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'appData.PhoneBooks' table. You can move, or remove it, as needed.
            this.phoneBooksTableAdapter.Fill(this.appData.PhoneBooks);
            Edit(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Edit(true);
                appData.PhoneBooks.AddPhoneBooksRow(appData.PhoneBooks.NewPhoneBooksRow());
                phoneBooksBindingSource.MoveLast();
                textphonnumber.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    appData.PhoneBooks.RejectChanges();
            }
        }

        private void Edit(bool value)
        {
            textphonnumber.Enabled = value;
            textaddress.Enabled = value;
            textfullname.Enabled = value;
            textemail.Enabled = value;

        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            Edit(true);
            textphonnumber.Focus();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            Edit(false);
            phoneBooksBindingSource.ResetBindings(false);
        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            try
            {
                Edit(false );
                phoneBooksBindingSource.EndEdit();
                phoneBooksTableAdapter.Update(appData.PhoneBooks);
                dataGridView1.Refresh();
                textphonnumber.Focus();
                MessageBox.Show("your data has been successfully saved .","messege",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                appData.PhoneBooks.RejectChanges();
            }

        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)13)
            {
                if (MessageBox.Show("are you sure you want to delete this record", "messege", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    phoneBooksBindingSource.RemoveCurrent();
            }
        }
    }
}
