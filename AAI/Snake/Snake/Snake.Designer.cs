namespace Snake {
    partial class Snake {
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
            this.snakePictureBox = new System.Windows.Forms.PictureBox();
            this.longestPathButton = new System.Windows.Forms.Button();
            this.longestPathLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.snakePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // snakePictureBox
            // 
            this.snakePictureBox.Location = new System.Drawing.Point(12, 12);
            this.snakePictureBox.Name = "snakePictureBox";
            this.snakePictureBox.Size = new System.Drawing.Size(260, 205);
            this.snakePictureBox.TabIndex = 0;
            this.snakePictureBox.TabStop = false;
            // 
            // longestPathButton
            // 
            this.longestPathButton.Location = new System.Drawing.Point(12, 226);
            this.longestPathButton.Name = "longestPathButton";
            this.longestPathButton.Size = new System.Drawing.Size(102, 23);
            this.longestPathButton.TabIndex = 1;
            this.longestPathButton.Text = "Longest Path";
            this.longestPathButton.UseVisualStyleBackColor = true;
            // 
            // longestPathLabel
            // 
            this.longestPathLabel.AutoSize = true;
            this.longestPathLabel.Location = new System.Drawing.Point(120, 231);
            this.longestPathLabel.Name = "longestPathLabel";
            this.longestPathLabel.Size = new System.Drawing.Size(69, 13);
            this.longestPathLabel.TabIndex = 2;
            this.longestPathLabel.Text = "Longest path";
            // 
            // Snake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.longestPathLabel);
            this.Controls.Add(this.longestPathButton);
            this.Controls.Add(this.snakePictureBox);
            this.Name = "Snake";
            this.Text = "Snake";
            ((System.ComponentModel.ISupportInitialize)(this.snakePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox snakePictureBox;
        private System.Windows.Forms.Button longestPathButton;
        private System.Windows.Forms.Label longestPathLabel;
    }
}

