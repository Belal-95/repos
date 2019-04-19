namespace WindowsFormsApp3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textphonnumber = new System.Windows.Forms.TextBox();
            this.textfullname = new System.Windows.Forms.TextBox();
            this.textemail = new System.Windows.Forms.TextBox();
            this.textsearch = new System.Windows.Forms.TextBox();
            this.textaddress = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnnew = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.phoneNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneBooksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.appData = new WindowsFormsApp3.AppData();
            this.phoneBooksTableAdapter = new WindowsFormsApp3.AppDataTableAdapters.PhoneBooksTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phoneBooksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "phon number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "full name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "address ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "search ";
            // 
            // textphonnumber
            // 
            this.textphonnumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.phoneBooksBindingSource, "PhoneNumber", true));
            this.textphonnumber.Location = new System.Drawing.Point(229, 74);
            this.textphonnumber.Name = "textphonnumber";
            this.textphonnumber.Size = new System.Drawing.Size(212, 20);
            this.textphonnumber.TabIndex = 6;
            // 
            // textfullname
            // 
            this.textfullname.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.phoneBooksBindingSource, "FullName", true));
            this.textfullname.Location = new System.Drawing.Point(229, 110);
            this.textfullname.Name = "textfullname";
            this.textfullname.Size = new System.Drawing.Size(212, 20);
            this.textfullname.TabIndex = 7;
            // 
            // textemail
            // 
            this.textemail.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.phoneBooksBindingSource, "Email", true));
            this.textemail.Location = new System.Drawing.Point(229, 144);
            this.textemail.Name = "textemail";
            this.textemail.Size = new System.Drawing.Size(212, 20);
            this.textemail.TabIndex = 8;
            // 
            // textsearch
            // 
            this.textsearch.Location = new System.Drawing.Point(229, 214);
            this.textsearch.Name = "textsearch";
            this.textsearch.Size = new System.Drawing.Size(212, 20);
            this.textsearch.TabIndex = 10;
            // 
            // textaddress
            // 
            this.textaddress.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.phoneBooksBindingSource, "Adress", true));
            this.textaddress.Location = new System.Drawing.Point(229, 178);
            this.textaddress.Name = "textaddress";
            this.textaddress.Size = new System.Drawing.Size(212, 20);
            this.textaddress.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.phoneNumberDataGridViewTextBoxColumn,
            this.fullNameDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.adressDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.phoneBooksBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 238);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(530, 150);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // btnnew
            // 
            this.btnnew.Location = new System.Drawing.Point(285, 394);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(75, 23);
            this.btnnew.TabIndex = 12;
            this.btnnew.Text = "new";
            this.btnnew.UseVisualStyleBackColor = true;
            this.btnnew.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnedit
            // 
            this.btnedit.Location = new System.Drawing.Point(366, 394);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(75, 23);
            this.btnedit.TabIndex = 13;
            this.btnedit.Text = "edit";
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(447, 394);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 23);
            this.btncancel.TabIndex = 14;
            this.btncancel.Text = "cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(528, 394);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 15;
            this.btnsave.Text = "save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // phoneNumberDataGridViewTextBoxColumn
            // 
            this.phoneNumberDataGridViewTextBoxColumn.DataPropertyName = "PhoneNumber";
            this.phoneNumberDataGridViewTextBoxColumn.HeaderText = "PhoneNumber";
            this.phoneNumberDataGridViewTextBoxColumn.Name = "phoneNumberDataGridViewTextBoxColumn";
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            this.fullNameDataGridViewTextBoxColumn.DataPropertyName = "FullName";
            this.fullNameDataGridViewTextBoxColumn.HeaderText = "FullName";
            this.fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            this.fullNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.Width = 150;
            // 
            // adressDataGridViewTextBoxColumn
            // 
            this.adressDataGridViewTextBoxColumn.DataPropertyName = "Adress";
            this.adressDataGridViewTextBoxColumn.HeaderText = "Adress";
            this.adressDataGridViewTextBoxColumn.Name = "adressDataGridViewTextBoxColumn";
            this.adressDataGridViewTextBoxColumn.Width = 150;
            // 
            // phoneBooksBindingSource
            // 
            this.phoneBooksBindingSource.DataMember = "PhoneBooks";
            this.phoneBooksBindingSource.DataSource = this.appData;
            // 
            // appData
            // 
            this.appData.DataSetName = "AppData";
            this.appData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // phoneBooksTableAdapter
            // 
            this.phoneBooksTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 444);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.btnnew);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textsearch);
            this.Controls.Add(this.textaddress);
            this.Controls.Add(this.textemail);
            this.Controls.Add(this.textfullname);
            this.Controls.Add(this.textphonnumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "telephone diary";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phoneBooksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textphonnumber;
        private System.Windows.Forms.TextBox textfullname;
        private System.Windows.Forms.TextBox textemail;
        private System.Windows.Forms.TextBox textsearch;
        private System.Windows.Forms.TextBox textaddress;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnnew;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnsave;
        private AppData appData;
        private System.Windows.Forms.BindingSource phoneBooksBindingSource;
        private AppDataTableAdapters.PhoneBooksTableAdapter phoneBooksTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn adressDataGridViewTextBoxColumn;
    }
}

