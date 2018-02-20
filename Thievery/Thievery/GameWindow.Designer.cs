namespace Thievery {
    partial class GameWindow {
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
            this.gamePictureBox = new System.Windows.Forms.PictureBox();
            this.drawingBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.gameBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.gamePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // gamePictureBox
            // 
            this.gamePictureBox.BackColor = System.Drawing.Color.White;
            this.gamePictureBox.Location = new System.Drawing.Point(12, 12);
            this.gamePictureBox.Name = "gamePictureBox";
            this.gamePictureBox.Size = new System.Drawing.Size(800, 600);
            this.gamePictureBox.TabIndex = 0;
            this.gamePictureBox.TabStop = false;
            this.gamePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.gamePictureBox_Paint);
            // 
            // drawingBackgroundWorker
            // 
            this.drawingBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.drawingBackgroundWorker_DoWork);
            // 
            // gameBackgroundWorker
            // 
            this.gameBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.gameBackgroundWorker_DoWork);
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.Controls.Add(this.gamePictureBox);
            this.Name = "GameWindow";
            this.Text = "Thievery";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameWindow_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gamePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox gamePictureBox;
        private System.ComponentModel.BackgroundWorker drawingBackgroundWorker;
        private System.ComponentModel.BackgroundWorker gameBackgroundWorker;
    }
}

