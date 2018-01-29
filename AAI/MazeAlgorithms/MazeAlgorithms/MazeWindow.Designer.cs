namespace MazeAlgorithms {
    partial class maze {
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
            this.mazePanel = new System.Windows.Forms.Panel();
            this.mazePictureBox = new System.Windows.Forms.PictureBox();
            this.mazePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mazePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mazePanel
            // 
            this.mazePanel.Controls.Add(this.mazePictureBox);
            this.mazePanel.Location = new System.Drawing.Point(13, 13);
            this.mazePanel.Name = "mazePanel";
            this.mazePanel.Size = new System.Drawing.Size(1033, 536);
            this.mazePanel.TabIndex = 0;
            // 
            // mazePictureBox
            // 
            this.mazePictureBox.Location = new System.Drawing.Point(0, 0);
            this.mazePictureBox.Name = "mazePictureBox";
            this.mazePictureBox.Size = new System.Drawing.Size(1033, 536);
            this.mazePictureBox.TabIndex = 0;
            this.mazePictureBox.TabStop = false;
            this.mazePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.mazePictureBox_Paint);
            // 
            // maze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.mazePanel);
            this.Name = "maze";
            this.Text = "Maze";
            this.mazePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mazePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mazePanel;
        private System.Windows.Forms.PictureBox mazePictureBox;
    }
}

