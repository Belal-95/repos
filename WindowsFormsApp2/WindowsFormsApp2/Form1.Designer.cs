namespace WindowsFormsApp2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.axRealAudio1 = new AxRealAudioObjects.AxRealAudio();
            this.vlc = new AxAXVLC.AxVLCPlugin2();
            ((System.ComponentModel.ISupportInitialize)(this.axRealAudio1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlc)).BeginInit();
            this.SuspendLayout();
            // 
            // axRealAudio1
            // 
            this.axRealAudio1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axRealAudio1.Enabled = true;
            this.axRealAudio1.Location = new System.Drawing.Point(57, 73);
            this.axRealAudio1.Name = "axRealAudio1";
            this.axRealAudio1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axRealAudio1.OcxState")));
            this.axRealAudio1.Size = new System.Drawing.Size(477, 112);
            this.axRealAudio1.TabIndex = 0;
            // 
            // vlc
            // 
            this.vlc.Enabled = true;
            this.vlc.Location = new System.Drawing.Point(157, 209);
            this.vlc.Name = "vlc";
            this.vlc.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("vlc.OcxState")));
            this.vlc.Size = new System.Drawing.Size(320, 240);
            this.vlc.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 488);
            this.Controls.Add(this.vlc);
            this.Controls.Add(this.axRealAudio1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axRealAudio1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxRealAudioObjects.AxRealAudio axRealAudio1;
        private AxAXVLC.AxVLCPlugin2 vlc;
    }
}

