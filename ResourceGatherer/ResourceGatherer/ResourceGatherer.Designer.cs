﻿namespace ResourceGatherer {
    partial class ResourceGatherer {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.gameWorldPicturebox = new System.Windows.Forms.PictureBox();
            this.worldTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gameWorldPicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // gameWorldPicturebox
            // 
            this.gameWorldPicturebox.BackColor = System.Drawing.Color.Green;
            this.gameWorldPicturebox.Location = new System.Drawing.Point(12, 12);
            this.gameWorldPicturebox.Name = "gameWorldPicturebox";
            this.gameWorldPicturebox.Size = new System.Drawing.Size(800, 600);
            this.gameWorldPicturebox.TabIndex = 0;
            this.gameWorldPicturebox.TabStop = false;
            this.gameWorldPicturebox.Paint += new System.Windows.Forms.PaintEventHandler(this.gameWorldPicturebox_Paint);
            // 
            // worldTimer
            // 
            this.worldTimer.Interval = 1;
            this.worldTimer.Tick += new System.EventHandler(this.worldTimer_Tick);
            // 
            // ResourceGatherer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 749);
            this.Controls.Add(this.gameWorldPicturebox);
            this.Name = "ResourceGatherer";
            this.Text = "Resource Gatherer";
            ((System.ComponentModel.ISupportInitialize)(this.gameWorldPicturebox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox gameWorldPicturebox;
        private System.Windows.Forms.Timer worldTimer;
    }
}

