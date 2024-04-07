﻿namespace NeuralNet
{
    partial class MainWindow
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
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            this.pictureBoxPaint = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.trainNetworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.successRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adjustNetowrkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPaint)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 120F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(307, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 187);
            this.label1.TabIndex = 1;
            // 
            // buttonClear
            // 
            this.buttonClear.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClear.ForeColor = System.Drawing.Color.White;
            this.buttonClear.Location = new System.Drawing.Point(340, 259);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(121, 32);
            this.buttonClear.TabIndex = 2;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // pictureBoxPaint
            // 
            this.pictureBoxPaint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPaint.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBoxPaint.Location = new System.Drawing.Point(12, 34);
            this.pictureBoxPaint.Name = "pictureBoxPaint";
            this.pictureBoxPaint.Size = new System.Drawing.Size(256, 258);
            this.pictureBoxPaint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPaint.TabIndex = 3;
            this.pictureBoxPaint.TabStop = false;
            this.pictureBoxPaint.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxPaint_MouseDown);
            this.pictureBoxPaint.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxPaint_MouseMove);
            this.pictureBoxPaint.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxPaint_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trainNetworkToolStripMenuItem,
            this.lToolStripMenuItem,
            this.successRateToolStripMenuItem,
            this.adjustNetowrkToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1297, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // trainNetworkToolStripMenuItem
            // 
            this.trainNetworkToolStripMenuItem.Name = "trainNetworkToolStripMenuItem";
            this.trainNetworkToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.trainNetworkToolStripMenuItem.Text = "Train Network";
            this.trainNetworkToolStripMenuItem.Click += new System.EventHandler(this.trainNetworkToolStripMenuItem_Click);
            // 
            // lToolStripMenuItem
            // 
            this.lToolStripMenuItem.Name = "lToolStripMenuItem";
            this.lToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.lToolStripMenuItem.Text = "Load Image";
            this.lToolStripMenuItem.Click += new System.EventHandler(this.lToolStripMenuItem_Click);
            // 
            // successRateToolStripMenuItem
            // 
            this.successRateToolStripMenuItem.Name = "successRateToolStripMenuItem";
            this.successRateToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.successRateToolStripMenuItem.Text = "Success Rate";
            this.successRateToolStripMenuItem.Click += new System.EventHandler(this.successRateToolStripMenuItem_Click);
            // 
            // adjustNetowrkToolStripMenuItem
            // 
            this.adjustNetowrkToolStripMenuItem.Name = "adjustNetowrkToolStripMenuItem";
            this.adjustNetowrkToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.adjustNetowrkToolStripMenuItem.Text = "Adjust Netowrk";
            this.adjustNetowrkToolStripMenuItem.Click += new System.EventHandler(this.adjustNetowrkToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1297, 303);
            this.Controls.Add(this.pictureBoxPaint);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Number Identifier";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPaint)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.PictureBox pictureBoxPaint;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem trainNetworkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem successRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adjustNetowrkToolStripMenuItem;
    }
}