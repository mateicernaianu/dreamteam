﻿namespace mps_proiect
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
            this.btnEnable = new System.Windows.Forms.Button();
            this.btnDisable = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.testButtonPlay = new System.Windows.Forms.Button();
            this.testButtonStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEnable
            // 
            this.btnEnable.Location = new System.Drawing.Point(12, 267);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(134, 23);
            this.btnEnable.TabIndex = 0;
            this.btnEnable.Text = "Enable Voice Control";
            this.btnEnable.UseVisualStyleBackColor = true;
            this.btnEnable.Click += new System.EventHandler(this.btnEnable_Click);
            // 
            // btnDisable
            // 
            this.btnDisable.Enabled = false;
            this.btnDisable.Location = new System.Drawing.Point(256, 267);
            this.btnDisable.Name = "btnDisable";
            this.btnDisable.Size = new System.Drawing.Size(128, 23);
            this.btnDisable.TabIndex = 1;
            this.btnDisable.Text = "Disable Voice Control";
            this.btnDisable.UseVisualStyleBackColor = true;
            this.btnDisable.Click += new System.EventHandler(this.btnDisable_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 1);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(372, 260);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "-Log-";
            // 
            // testButtonPlay
            // 
            this.testButtonPlay.Location = new System.Drawing.Point(432, 61);
            this.testButtonPlay.Name = "testButtonPlay";
            this.testButtonPlay.Size = new System.Drawing.Size(75, 23);
            this.testButtonPlay.TabIndex = 3;
            this.testButtonPlay.Text = "button1";
            this.testButtonPlay.UseVisualStyleBackColor = true;
            this.testButtonPlay.Click += new System.EventHandler(this.testButtonPlay_Click);
            // 
            // testButtonStop
            // 
            this.testButtonStop.Location = new System.Drawing.Point(432, 103);
            this.testButtonStop.Name = "testButtonStop";
            this.testButtonStop.Size = new System.Drawing.Size(75, 23);
            this.testButtonStop.TabIndex = 4;
            this.testButtonStop.Text = "button1";
            this.testButtonStop.UseVisualStyleBackColor = true;
            this.testButtonStop.Click += new System.EventHandler(this.testButtonStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 377);
            this.Controls.Add(this.testButtonStop);
            this.Controls.Add(this.testButtonPlay);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnDisable);
            this.Controls.Add(this.btnEnable);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEnable;
        private System.Windows.Forms.Button btnDisable;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button testButtonPlay;
        private System.Windows.Forms.Button testButtonStop;
    }
}

