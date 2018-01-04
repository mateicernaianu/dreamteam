namespace mps_proiect
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.axShockwaveFlash1 = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.infoCommands = new System.Windows.Forms.Button();
            this.aboutMona = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.richTextBox1.Location = new System.Drawing.Point(25, 207);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(498, 149);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // axShockwaveFlash1
            // 
            this.axShockwaveFlash1.Enabled = true;
            this.axShockwaveFlash1.Location = new System.Drawing.Point(765, 202);
            this.axShockwaveFlash1.Name = "axShockwaveFlash1";
            this.axShockwaveFlash1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axShockwaveFlash1.OcxState")));
            this.axShockwaveFlash1.Size = new System.Drawing.Size(192, 192);
            this.axShockwaveFlash1.TabIndex = 6;
            // 
            // infoCommands
            // 
            this.infoCommands.Location = new System.Drawing.Point(441, 6);
            this.infoCommands.Name = "infoCommands";
            this.infoCommands.Size = new System.Drawing.Size(104, 23);
            this.infoCommands.TabIndex = 7;
            this.infoCommands.Text = "How to use";
            this.infoCommands.UseVisualStyleBackColor = true;
            this.infoCommands.Click += new System.EventHandler(this.infoCommands_Click);
            // 
            // aboutMona
            // 
            this.aboutMona.Location = new System.Drawing.Point(3, 6);
            this.aboutMona.Name = "aboutMona";
            this.aboutMona.Size = new System.Drawing.Size(104, 23);
            this.aboutMona.TabIndex = 8;
            this.aboutMona.Text = "About Mona";
            this.aboutMona.UseVisualStyleBackColor = true;
            this.aboutMona.Click += new System.EventHandler(this.aboutMona_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::mps_proiect.Properties.Resources.dreamteam;
            this.pictureBox1.Location = new System.Drawing.Point(160, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(226, 195);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(557, 368);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.aboutMona);
            this.Controls.Add(this.infoCommands);
            this.Controls.Add(this.axShockwaveFlash1);
            this.Controls.Add(this.richTextBox1);
            this.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Mona";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private AxShockwaveFlashObjects.AxShockwaveFlash axShockwaveFlash1;
        private System.Windows.Forms.Button infoCommands;
        private System.Windows.Forms.Button aboutMona;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

