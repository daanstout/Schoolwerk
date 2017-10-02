namespace DnD_FactoryMethod {
    partial class DnDMainForm {
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
            this.raceComboBox = new System.Windows.Forms.ComboBox();
            this.classComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.characterPictureBox = new System.Windows.Forms.PictureBox();
            this.CharacterLevelNumeric = new System.Windows.Forms.NumericUpDown();
            this.characterStatsPictureBox = new System.Windows.Forms.PictureBox();
            this.CharacterNameTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.characterPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CharacterLevelNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterStatsPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // raceComboBox
            // 
            this.raceComboBox.FormattingEnabled = true;
            this.raceComboBox.Location = new System.Drawing.Point(13, 39);
            this.raceComboBox.Name = "raceComboBox";
            this.raceComboBox.Size = new System.Drawing.Size(121, 23);
            this.raceComboBox.Sorted = true;
            this.raceComboBox.TabIndex = 0;
            // 
            // classComboBox
            // 
            this.classComboBox.FormattingEnabled = true;
            this.classComboBox.Location = new System.Drawing.Point(13, 68);
            this.classComboBox.Name = "classComboBox";
            this.classComboBox.Size = new System.Drawing.Size(121, 23);
            this.classComboBox.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Create Character";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // characterPictureBox
            // 
            this.characterPictureBox.Location = new System.Drawing.Point(272, 6);
            this.characterPictureBox.Name = "characterPictureBox";
            this.characterPictureBox.Size = new System.Drawing.Size(259, 578);
            this.characterPictureBox.TabIndex = 3;
            this.characterPictureBox.TabStop = false;
            this.characterPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.characterPictureBox_Paint);
            // 
            // CharacterLevelNumeric
            // 
            this.CharacterLevelNumeric.Location = new System.Drawing.Point(14, 126);
            this.CharacterLevelNumeric.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.CharacterLevelNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CharacterLevelNumeric.Name = "CharacterLevelNumeric";
            this.CharacterLevelNumeric.Size = new System.Drawing.Size(120, 20);
            this.CharacterLevelNumeric.TabIndex = 5;
            this.CharacterLevelNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CharacterLevelNumeric.ValueChanged += new System.EventHandler(this.CharacterLevelNumeric_ValueChanged);
            // 
            // characterStatsPictureBox
            // 
            this.characterStatsPictureBox.Location = new System.Drawing.Point(12, 152);
            this.characterStatsPictureBox.Name = "characterStatsPictureBox";
            this.characterStatsPictureBox.Size = new System.Drawing.Size(120, 247);
            this.characterStatsPictureBox.TabIndex = 6;
            this.characterStatsPictureBox.TabStop = false;
            this.characterStatsPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.characterStatsPictureBox_Paint);
            // 
            // CharacterNameTextBox
            // 
            this.CharacterNameTextBox.Location = new System.Drawing.Point(13, 13);
            this.CharacterNameTextBox.Name = "CharacterNameTextBox";
            this.CharacterNameTextBox.Size = new System.Drawing.Size(119, 20);
            this.CharacterNameTextBox.TabIndex = 7;
            // 
            // DnDMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 596);
            this.Controls.Add(this.CharacterNameTextBox);
            this.Controls.Add(this.characterStatsPictureBox);
            this.Controls.Add(this.CharacterLevelNumeric);
            this.Controls.Add(this.characterPictureBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.classComboBox);
            this.Controls.Add(this.raceComboBox);
            this.Font = new System.Drawing.Font("Bookman Old Style", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DnDMainForm";
            this.Text = "DnD Character Creator";
            ((System.ComponentModel.ISupportInitialize)(this.characterPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CharacterLevelNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterStatsPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox raceComboBox;
        private System.Windows.Forms.ComboBox classComboBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox characterPictureBox;
        private System.Windows.Forms.NumericUpDown CharacterLevelNumeric;
        private System.Windows.Forms.PictureBox characterStatsPictureBox;
        private System.Windows.Forms.TextBox CharacterNameTextBox;
    }
}

