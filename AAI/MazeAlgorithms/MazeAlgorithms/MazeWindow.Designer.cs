namespace MazeAlgorithms {
    partial class MazeWindow {
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
            this.mazePanel = new System.Windows.Forms.Panel();
            this.mazePictureBox = new System.Windows.Forms.PictureBox();
            this.algorithmTimer = new System.Windows.Forms.Timer(this.components);
            this.generatinBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.mazeButtonsPanel = new System.Windows.Forms.Panel();
            this.generateMazeButton = new System.Windows.Forms.Button();
            this.checkboxPanel = new System.Windows.Forms.Panel();
            this.showDistanceCheckbox = new System.Windows.Forms.CheckBox();
            this.pauseCheckBox = new System.Windows.Forms.CheckBox();
            this.noDelayCheckBox = new System.Windows.Forms.CheckBox();
            this.algorithmSelectionPanel = new System.Windows.Forms.Panel();
            this.generationLabel = new System.Windows.Forms.Label();
            this.generationAlgorithmComboBox = new System.Windows.Forms.ComboBox();
            this.solvingLabel = new System.Windows.Forms.Label();
            this.solvingAlgorithmComboBox = new System.Windows.Forms.ComboBox();
            this.mazePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mazePictureBox)).BeginInit();
            this.mazeButtonsPanel.SuspendLayout();
            this.checkboxPanel.SuspendLayout();
            this.algorithmSelectionPanel.SuspendLayout();
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
            this.mazePictureBox.BackColor = System.Drawing.Color.White;
            this.mazePictureBox.Location = new System.Drawing.Point(0, 0);
            this.mazePictureBox.Name = "mazePictureBox";
            this.mazePictureBox.Size = new System.Drawing.Size(1033, 536);
            this.mazePictureBox.TabIndex = 0;
            this.mazePictureBox.TabStop = false;
            this.mazePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.mazePictureBox_Paint);
            // 
            // algorithmTimer
            // 
            this.algorithmTimer.Enabled = true;
            this.algorithmTimer.Interval = 25;
            this.algorithmTimer.Tick += new System.EventHandler(this.algorithmTimer_Tick);
            // 
            // generatinBackgroundWorker
            // 
            this.generatinBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.generatinBackgroundWorker_DoWork);
            // 
            // mazeButtonsPanel
            // 
            this.mazeButtonsPanel.Controls.Add(this.generateMazeButton);
            this.mazeButtonsPanel.Location = new System.Drawing.Point(1067, 12);
            this.mazeButtonsPanel.Name = "mazeButtonsPanel";
            this.mazeButtonsPanel.Size = new System.Drawing.Size(82, 91);
            this.mazeButtonsPanel.TabIndex = 1;
            // 
            // generateMazeButton
            // 
            this.generateMazeButton.Location = new System.Drawing.Point(3, 0);
            this.generateMazeButton.Name = "generateMazeButton";
            this.generateMazeButton.Size = new System.Drawing.Size(75, 23);
            this.generateMazeButton.TabIndex = 0;
            this.generateMazeButton.Text = "Generate";
            this.generateMazeButton.UseVisualStyleBackColor = true;
            this.generateMazeButton.Click += new System.EventHandler(this.generateMazeButton_Click);
            // 
            // checkboxPanel
            // 
            this.checkboxPanel.Controls.Add(this.noDelayCheckBox);
            this.checkboxPanel.Controls.Add(this.pauseCheckBox);
            this.checkboxPanel.Controls.Add(this.showDistanceCheckbox);
            this.checkboxPanel.Location = new System.Drawing.Point(1057, 109);
            this.checkboxPanel.Name = "checkboxPanel";
            this.checkboxPanel.Size = new System.Drawing.Size(101, 63);
            this.checkboxPanel.TabIndex = 2;
            // 
            // showDistanceCheckbox
            // 
            this.showDistanceCheckbox.AutoSize = true;
            this.showDistanceCheckbox.Location = new System.Drawing.Point(3, 0);
            this.showDistanceCheckbox.Name = "showDistanceCheckbox";
            this.showDistanceCheckbox.Size = new System.Drawing.Size(98, 17);
            this.showDistanceCheckbox.TabIndex = 0;
            this.showDistanceCheckbox.Text = "Show Distance";
            this.showDistanceCheckbox.UseVisualStyleBackColor = true;
            // 
            // pauseCheckBox
            // 
            this.pauseCheckBox.AutoSize = true;
            this.pauseCheckBox.Location = new System.Drawing.Point(3, 23);
            this.pauseCheckBox.Name = "pauseCheckBox";
            this.pauseCheckBox.Size = new System.Drawing.Size(56, 17);
            this.pauseCheckBox.TabIndex = 1;
            this.pauseCheckBox.Text = "Pause";
            this.pauseCheckBox.UseVisualStyleBackColor = true;
            // 
            // noDelayCheckBox
            // 
            this.noDelayCheckBox.AutoSize = true;
            this.noDelayCheckBox.Location = new System.Drawing.Point(3, 46);
            this.noDelayCheckBox.Name = "noDelayCheckBox";
            this.noDelayCheckBox.Size = new System.Drawing.Size(70, 17);
            this.noDelayCheckBox.TabIndex = 2;
            this.noDelayCheckBox.Text = "No Delay";
            this.noDelayCheckBox.UseVisualStyleBackColor = true;
            this.noDelayCheckBox.CheckedChanged += new System.EventHandler(this.noDelayCheckBox_CheckedChanged);
            // 
            // algorithmSelectionPanel
            // 
            this.algorithmSelectionPanel.Controls.Add(this.solvingAlgorithmComboBox);
            this.algorithmSelectionPanel.Controls.Add(this.solvingLabel);
            this.algorithmSelectionPanel.Controls.Add(this.generationAlgorithmComboBox);
            this.algorithmSelectionPanel.Controls.Add(this.generationLabel);
            this.algorithmSelectionPanel.Location = new System.Drawing.Point(1048, 178);
            this.algorithmSelectionPanel.Name = "algorithmSelectionPanel";
            this.algorithmSelectionPanel.Size = new System.Drawing.Size(132, 89);
            this.algorithmSelectionPanel.TabIndex = 3;
            // 
            // generationLabel
            // 
            this.generationLabel.AutoSize = true;
            this.generationLabel.Location = new System.Drawing.Point(13, 0);
            this.generationLabel.Name = "generationLabel";
            this.generationLabel.Size = new System.Drawing.Size(98, 13);
            this.generationLabel.TabIndex = 0;
            this.generationLabel.Text = "Generation Method";
            // 
            // generationAlgorithmComboBox
            // 
            this.generationAlgorithmComboBox.FormattingEnabled = true;
            this.generationAlgorithmComboBox.Location = new System.Drawing.Point(5, 16);
            this.generationAlgorithmComboBox.Name = "generationAlgorithmComboBox";
            this.generationAlgorithmComboBox.Size = new System.Drawing.Size(121, 21);
            this.generationAlgorithmComboBox.TabIndex = 1;
            this.generationAlgorithmComboBox.SelectedIndexChanged += new System.EventHandler(this.generationAlgorithmComboBox_SelectedIndexChanged);
            // 
            // solvingLabel
            // 
            this.solvingLabel.AutoSize = true;
            this.solvingLabel.Location = new System.Drawing.Point(16, 44);
            this.solvingLabel.Name = "solvingLabel";
            this.solvingLabel.Size = new System.Drawing.Size(81, 13);
            this.solvingLabel.TabIndex = 2;
            this.solvingLabel.Text = "Solving Method";
            // 
            // solvingAlgorithmComboBox
            // 
            this.solvingAlgorithmComboBox.FormattingEnabled = true;
            this.solvingAlgorithmComboBox.Location = new System.Drawing.Point(5, 60);
            this.solvingAlgorithmComboBox.Name = "solvingAlgorithmComboBox";
            this.solvingAlgorithmComboBox.Size = new System.Drawing.Size(121, 21);
            this.solvingAlgorithmComboBox.TabIndex = 3;
            // 
            // MazeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.algorithmSelectionPanel);
            this.Controls.Add(this.checkboxPanel);
            this.Controls.Add(this.mazeButtonsPanel);
            this.Controls.Add(this.mazePanel);
            this.Name = "MazeWindow";
            this.Text = "Maze";
            this.mazePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mazePictureBox)).EndInit();
            this.mazeButtonsPanel.ResumeLayout(false);
            this.checkboxPanel.ResumeLayout(false);
            this.checkboxPanel.PerformLayout();
            this.algorithmSelectionPanel.ResumeLayout(false);
            this.algorithmSelectionPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mazePanel;
        private System.Windows.Forms.PictureBox mazePictureBox;
        private System.Windows.Forms.Timer algorithmTimer;
        private System.ComponentModel.BackgroundWorker generatinBackgroundWorker;
        private System.Windows.Forms.Panel mazeButtonsPanel;
        private System.Windows.Forms.Button generateMazeButton;
        private System.Windows.Forms.Panel checkboxPanel;
        private System.Windows.Forms.CheckBox noDelayCheckBox;
        private System.Windows.Forms.CheckBox pauseCheckBox;
        private System.Windows.Forms.CheckBox showDistanceCheckbox;
        private System.Windows.Forms.Panel algorithmSelectionPanel;
        private System.Windows.Forms.ComboBox solvingAlgorithmComboBox;
        private System.Windows.Forms.Label solvingLabel;
        private System.Windows.Forms.ComboBox generationAlgorithmComboBox;
        private System.Windows.Forms.Label generationLabel;
    }
}

