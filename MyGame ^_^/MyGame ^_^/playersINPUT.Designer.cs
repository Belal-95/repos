namespace MyGame____
{
    partial class playersINPUT
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
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.maskedTextBox1.Location = new System.Drawing.Point(200, 83);
            this.maskedTextBox1.Mask = "               0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.PasswordChar = '*';
            this.maskedTextBox1.Size = new System.Drawing.Size(159, 24);
            this.maskedTextBox1.TabIndex = 1;
            this.maskedTextBox1.ValidatingType = typeof(int);
            this.maskedTextBox1.TextChanged += new System.EventHandler(this.maskedTextBox1_TextChanged);
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.maskedTextBox2.Location = new System.Drawing.Point(200, 164);
            this.maskedTextBox2.Mask = "               0000";
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.PasswordChar = '*';
            this.maskedTextBox2.Size = new System.Drawing.Size(159, 24);
            this.maskedTextBox2.TabIndex = 2;
            this.maskedTextBox2.ValidatingType = typeof(int);
            this.maskedTextBox2.Visible = false;
            this.maskedTextBox2.TextChanged += new System.EventHandler(this.maskedTextBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "player one please enter your number and do\'nt let the other player see it";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(358, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "player two please enter your number and do\'nt let the other player see it";
            this.label2.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(227, 191);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "SUBMIT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // playersINPUT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 250);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maskedTextBox2);
            this.Controls.Add(this.maskedTextBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "playersINPUT";
            this.Text = "playersINPUT";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.playersINPUT_FormClosed);
            this.Load += new System.EventHandler(this.playersINPUT_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}