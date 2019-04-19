namespace MemoriesWithBelal
{
    partial class allvideos
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkViolet;
            this.button1.Font = new System.Drawing.Font("Tahoma", 11F);
            this.button1.ForeColor = System.Drawing.Color.Yellow;
            this.button1.Location = new System.Drawing.Point(228, 573);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(229, 60);
            this.button1.TabIndex = 0;
            this.button1.Text = "Closer - The Chainsmokers";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkViolet;
            this.button2.Font = new System.Drawing.Font("Tahoma", 11F);
            this.button2.ForeColor = System.Drawing.Color.Yellow;
            this.button2.Location = new System.Drawing.Point(925, 107);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(224, 60);
            this.button2.TabIndex = 1;
            this.button2.Text = "Locked Away ";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // allvideos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MemoriesWithBelal.Properties.Resources.images_63;
            this.ClientSize = new System.Drawing.Size(1354, 733);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "allvideos";
            this.Text = "allvideos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}