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
            this.generatingBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.mazeButtonsPanel = new System.Windows.Forms.Panel();
            this.solveMazeButton = new System.Windows.Forms.Button();
            this.generateMazeButton = new System.Windows.Forms.Button();
            this.checkboxPanel = new System.Windows.Forms.Panel();
            this.showPositionCheckbox = new System.Windows.Forms.CheckBox();
            this.noDelayCheckBox = new System.Windows.Forms.CheckBox();
            this.pauseCheckBox = new System.Windows.Forms.CheckBox();
            this.showDistanceCheckbox = new System.Windows.Forms.CheckBox();
            this.algorithmSelectionPanel = new System.Windows.Forms.Panel();
            this.solvingAlgorithmComboBox = new System.Windows.Forms.ComboBox();
            this.solvingLabel = new System.Windows.Forms.Label();
            this.generationAlgorithmComboBox = new System.Windows.Forms.ComboBox();
            this.generationLabel = new System.Windows.Forms.Label();
            this.solvingBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.numericOptionsPanel = new System.Windows.Forms.Panel();
            this.mazeSizeNumeric = new System.Windows.Forms.NumericUpDown();
            this.mazeSizeLabel = new System.Windows.Forms.Label();
            this.timerIntervalNumeric = new System.Windows.Forms.NumericUpDown();
            this.intervalLabel = new System.Windows.Forms.Label();
            this.newMazePanel = new System.Windows.Forms.Panel();
            this.createMazeButton = new System.Windows.Forms.Button();
            this.mazeHeigthNumeric = new System.Windows.Forms.NumericUpDown();
            this.mazeHeightLabel = new System.Windows.Forms.Label();
            this.mazeWidthNumeric = new System.Windows.Forms.NumericUpDown();
            this.mazeWidthLabel = new System.Windows.Forms.Label();
            this.nextStepButton = new System.Windows.Forms.Button();
            this.aboutLabel = new System.Windows.Forms.Label();
            this.mazePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mazePictureBox)).BeginInit();
            this.mazeButtonsPanel.SuspendLayout();
            this.checkboxPanel.SuspendLayout();
            this.algorithmSelectionPanel.SuspendLayout();
            this.numericOptionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mazeSizeNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerIntervalNumeric)).BeginInit();
            this.newMazePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mazeHeigthNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mazeWidthNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // mazePanel
            // 
            this.mazePanel.AutoScroll = true;
            this.mazePanel.Controls.Add(this.mazePictureBox);
            this.mazePanel.Location = new System.Drawing.Point(13, 13);
            this.mazePanel.Name = "mazePanel";
            this.mazePanel.Size = new System.Drawing.Size(1029, 625);
            this.mazePanel.TabIndex = 0;
            // 
            // mazePictureBox
            // 
            this.mazePictureBox.BackColor = System.Drawing.Color.White;
            this.mazePictureBox.Location = new System.Drawing.Point(0, 0);
            this.mazePictureBox.Name = "mazePictureBox";
            this.mazePictureBox.Size = new System.Drawing.Size(1029, 625);
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
            // generatingBackgroundWorker
            // 
            this.generatingBackgroundWorker.WorkerSupportsCancellation = true;
            this.generatingBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.generatingBackgroundWorker_DoWork);
            this.generatingBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.generatingBackgroundWorker_RunWorkerCompleted);
            // 
            // mazeButtonsPanel
            // 
            this.mazeButtonsPanel.Controls.Add(this.solveMazeButton);
            this.mazeButtonsPanel.Controls.Add(this.generateMazeButton);
            this.mazeButtonsPanel.Location = new System.Drawing.Point(1048, 13);
            this.mazeButtonsPanel.Name = "mazeButtonsPanel";
            this.mazeButtonsPanel.Size = new System.Drawing.Size(100, 91);
            this.mazeButtonsPanel.TabIndex = 1;
            // 
            // solveMazeButton
            // 
            this.solveMazeButton.Enabled = false;
            this.solveMazeButton.Location = new System.Drawing.Point(3, 29);
            this.solveMazeButton.Name = "solveMazeButton";
            this.solveMazeButton.Size = new System.Drawing.Size(94, 23);
            this.solveMazeButton.TabIndex = 1;
            this.solveMazeButton.Text = "Solve Maze";
            this.solveMazeButton.UseVisualStyleBackColor = true;
            this.solveMazeButton.Click += new System.EventHandler(this.solveMazeButton_Click);
            // 
            // generateMazeButton
            // 
            this.generateMazeButton.Location = new System.Drawing.Point(3, 0);
            this.generateMazeButton.Name = "generateMazeButton";
            this.generateMazeButton.Size = new System.Drawing.Size(94, 23);
            this.generateMazeButton.TabIndex = 0;
            this.generateMazeButton.Text = "Generate Maze";
            this.generateMazeButton.UseVisualStyleBackColor = true;
            this.generateMazeButton.Click += new System.EventHandler(this.generateMazeButton_Click);
            // 
            // checkboxPanel
            // 
            this.checkboxPanel.Controls.Add(this.showPositionCheckbox);
            this.checkboxPanel.Controls.Add(this.noDelayCheckBox);
            this.checkboxPanel.Controls.Add(this.pauseCheckBox);
            this.checkboxPanel.Controls.Add(this.showDistanceCheckbox);
            this.checkboxPanel.Location = new System.Drawing.Point(1043, 108);
            this.checkboxPanel.Name = "checkboxPanel";
            this.checkboxPanel.Size = new System.Drawing.Size(123, 85);
            this.checkboxPanel.TabIndex = 2;
            // 
            // showPositionCheckbox
            // 
            this.showPositionCheckbox.AutoSize = true;
            this.showPositionCheckbox.Location = new System.Drawing.Point(3, 69);
            this.showPositionCheckbox.Name = "showPositionCheckbox";
            this.showPositionCheckbox.Size = new System.Drawing.Size(93, 17);
            this.showPositionCheckbox.TabIndex = 3;
            this.showPositionCheckbox.Text = "Show Position";
            this.showPositionCheckbox.UseVisualStyleBackColor = true;
            this.showPositionCheckbox.CheckedChanged += new System.EventHandler(this.showPositionCheckbox_CheckedChanged);
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
            // pauseCheckBox
            // 
            this.pauseCheckBox.AutoSize = true;
            this.pauseCheckBox.Location = new System.Drawing.Point(3, 23);
            this.pauseCheckBox.Name = "pauseCheckBox";
            this.pauseCheckBox.Size = new System.Drawing.Size(56, 17);
            this.pauseCheckBox.TabIndex = 1;
            this.pauseCheckBox.Text = "Pause";
            this.pauseCheckBox.UseVisualStyleBackColor = true;
            this.pauseCheckBox.CheckedChanged += new System.EventHandler(this.pauseCheckBox_CheckedChanged);
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
            this.showDistanceCheckbox.CheckedChanged += new System.EventHandler(this.showDistanceCheckbox_CheckedChanged);
            // 
            // algorithmSelectionPanel
            // 
            this.algorithmSelectionPanel.Controls.Add(this.solvingAlgorithmComboBox);
            this.algorithmSelectionPanel.Controls.Add(this.solvingLabel);
            this.algorithmSelectionPanel.Controls.Add(this.generationAlgorithmComboBox);
            this.algorithmSelectionPanel.Controls.Add(this.generationLabel);
            this.algorithmSelectionPanel.Location = new System.Drawing.Point(1046, 199);
            this.algorithmSelectionPanel.Name = "algorithmSelectionPanel";
            this.algorithmSelectionPanel.Size = new System.Drawing.Size(132, 89);
            this.algorithmSelectionPanel.TabIndex = 3;
            // 
            // solvingAlgorithmComboBox
            // 
            this.solvingAlgorithmComboBox.FormattingEnabled = true;
            this.solvingAlgorithmComboBox.Location = new System.Drawing.Point(5, 60);
            this.solvingAlgorithmComboBox.Name = "solvingAlgorithmComboBox";
            this.solvingAlgorithmComboBox.Size = new System.Drawing.Size(121, 21);
            this.solvingAlgorithmComboBox.TabIndex = 3;
            this.solvingAlgorithmComboBox.SelectedIndexChanged += new System.EventHandler(this.solvingAlgorithmComboBox_SelectedIndexChanged);
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
            // generationAlgorithmComboBox
            // 
            this.generationAlgorithmComboBox.FormattingEnabled = true;
            this.generationAlgorithmComboBox.Location = new System.Drawing.Point(5, 16);
            this.generationAlgorithmComboBox.Name = "generationAlgorithmComboBox";
            this.generationAlgorithmComboBox.Size = new System.Drawing.Size(121, 21);
            this.generationAlgorithmComboBox.TabIndex = 1;
            this.generationAlgorithmComboBox.SelectedIndexChanged += new System.EventHandler(this.generationAlgorithmComboBox_SelectedIndexChanged);
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
            // solvingBackgroundWorker
            // 
            this.solvingBackgroundWorker.WorkerSupportsCancellation = true;
            this.solvingBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.solvingBackgroundWorker_DoWork);
            this.solvingBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.solvingBackgroundWorker_RunWorkerCompleted);
            // 
            // numericOptionsPanel
            // 
            this.numericOptionsPanel.Controls.Add(this.mazeSizeNumeric);
            this.numericOptionsPanel.Controls.Add(this.mazeSizeLabel);
            this.numericOptionsPanel.Controls.Add(this.timerIntervalNumeric);
            this.numericOptionsPanel.Controls.Add(this.intervalLabel);
            this.numericOptionsPanel.Location = new System.Drawing.Point(1228, 13);
            this.numericOptionsPanel.Name = "numericOptionsPanel";
            this.numericOptionsPanel.Size = new System.Drawing.Size(130, 56);
            this.numericOptionsPanel.TabIndex = 4;
            // 
            // mazeSizeNumeric
            // 
            this.mazeSizeNumeric.Location = new System.Drawing.Point(88, 30);
            this.mazeSizeNumeric.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.mazeSizeNumeric.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.mazeSizeNumeric.Name = "mazeSizeNumeric";
            this.mazeSizeNumeric.Size = new System.Drawing.Size(36, 20);
            this.mazeSizeNumeric.TabIndex = 3;
            this.mazeSizeNumeric.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.mazeSizeNumeric.ValueChanged += new System.EventHandler(this.mazeSizeNumeric_ValueChanged);
            // 
            // mazeSizeLabel
            // 
            this.mazeSizeLabel.AutoSize = true;
            this.mazeSizeLabel.Location = new System.Drawing.Point(4, 32);
            this.mazeSizeLabel.Name = "mazeSizeLabel";
            this.mazeSizeLabel.Size = new System.Drawing.Size(76, 13);
            this.mazeSizeLabel.TabIndex = 2;
            this.mazeSizeLabel.Text = "Maze Size (px)";
            // 
            // timerIntervalNumeric
            // 
            this.timerIntervalNumeric.Location = new System.Drawing.Point(72, 3);
            this.timerIntervalNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.timerIntervalNumeric.Name = "timerIntervalNumeric";
            this.timerIntervalNumeric.Size = new System.Drawing.Size(52, 20);
            this.timerIntervalNumeric.TabIndex = 1;
            this.timerIntervalNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.timerIntervalNumeric.ValueChanged += new System.EventHandler(this.timerIntervalNumeric_ValueChanged);
            // 
            // intervalLabel
            // 
            this.intervalLabel.AutoSize = true;
            this.intervalLabel.Location = new System.Drawing.Point(4, 5);
            this.intervalLabel.Name = "intervalLabel";
            this.intervalLabel.Size = new System.Drawing.Size(64, 13);
            this.intervalLabel.TabIndex = 0;
            this.intervalLabel.Text = "Interval (ms)";
            // 
            // newMazePanel
            // 
            this.newMazePanel.Controls.Add(this.createMazeButton);
            this.newMazePanel.Controls.Add(this.mazeHeigthNumeric);
            this.newMazePanel.Controls.Add(this.mazeHeightLabel);
            this.newMazePanel.Controls.Add(this.mazeWidthNumeric);
            this.newMazePanel.Controls.Add(this.mazeWidthLabel);
            this.newMazePanel.Location = new System.Drawing.Point(1228, 76);
            this.newMazePanel.Name = "newMazePanel";
            this.newMazePanel.Size = new System.Drawing.Size(128, 114);
            this.newMazePanel.TabIndex = 5;
            // 
            // createMazeButton
            // 
            this.createMazeButton.Location = new System.Drawing.Point(6, 86);
            this.createMazeButton.Name = "createMazeButton";
            this.createMazeButton.Size = new System.Drawing.Size(110, 23);
            this.createMazeButton.TabIndex = 4;
            this.createMazeButton.Text = "Create New Maze";
            this.createMazeButton.UseVisualStyleBackColor = true;
            this.createMazeButton.Click += new System.EventHandler(this.createMazeButton_Click);
            // 
            // mazeHeigthNumeric
            // 
            this.mazeHeigthNumeric.Location = new System.Drawing.Point(4, 59);
            this.mazeHeigthNumeric.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.mazeHeigthNumeric.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.mazeHeigthNumeric.Name = "mazeHeigthNumeric";
            this.mazeHeigthNumeric.Size = new System.Drawing.Size(120, 20);
            this.mazeHeigthNumeric.TabIndex = 3;
            this.mazeHeigthNumeric.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // mazeHeightLabel
            // 
            this.mazeHeightLabel.AutoSize = true;
            this.mazeHeightLabel.Location = new System.Drawing.Point(3, 43);
            this.mazeHeightLabel.Name = "mazeHeightLabel";
            this.mazeHeightLabel.Size = new System.Drawing.Size(107, 13);
            this.mazeHeightLabel.TabIndex = 2;
            this.mazeHeightLabel.Text = "Maze Height (Nodes)";
            // 
            // mazeWidthNumeric
            // 
            this.mazeWidthNumeric.Location = new System.Drawing.Point(4, 20);
            this.mazeWidthNumeric.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.mazeWidthNumeric.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.mazeWidthNumeric.Name = "mazeWidthNumeric";
            this.mazeWidthNumeric.Size = new System.Drawing.Size(120, 20);
            this.mazeWidthNumeric.TabIndex = 1;
            this.mazeWidthNumeric.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // mazeWidthLabel
            // 
            this.mazeWidthLabel.AutoSize = true;
            this.mazeWidthLabel.Location = new System.Drawing.Point(3, 4);
            this.mazeWidthLabel.Name = "mazeWidthLabel";
            this.mazeWidthLabel.Size = new System.Drawing.Size(104, 13);
            this.mazeWidthLabel.TabIndex = 0;
            this.mazeWidthLabel.Text = "Maze Width (Nodes)";
            // 
            // nextStepButton
            // 
            this.nextStepButton.Location = new System.Drawing.Point(1235, 277);
            this.nextStepButton.Name = "nextStepButton";
            this.nextStepButton.Size = new System.Drawing.Size(75, 23);
            this.nextStepButton.TabIndex = 6;
            this.nextStepButton.Text = "Next Step";
            this.nextStepButton.UseVisualStyleBackColor = true;
            this.nextStepButton.Click += new System.EventHandler(this.nextStepButton_Click);
            // 
            // aboutLabel
            // 
            this.aboutLabel.AutoSize = true;
            this.aboutLabel.Location = new System.Drawing.Point(1052, 302);
            this.aboutLabel.MaximumSize = new System.Drawing.Size(132, 330);
            this.aboutLabel.Name = "aboutLabel";
            this.aboutLabel.Size = new System.Drawing.Size(35, 13);
            this.aboutLabel.TabIndex = 7;
            this.aboutLabel.Text = "label1";
            // 
            // MazeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.aboutLabel);
            this.Controls.Add(this.nextStepButton);
            this.Controls.Add(this.newMazePanel);
            this.Controls.Add(this.numericOptionsPanel);
            this.Controls.Add(this.algorithmSelectionPanel);
            this.Controls.Add(this.checkboxPanel);
            this.Controls.Add(this.mazeButtonsPanel);
            this.Controls.Add(this.mazePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MazeWindow";
            this.Text = "Maze";
            this.mazePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mazePictureBox)).EndInit();
            this.mazeButtonsPanel.ResumeLayout(false);
            this.checkboxPanel.ResumeLayout(false);
            this.checkboxPanel.PerformLayout();
            this.algorithmSelectionPanel.ResumeLayout(false);
            this.algorithmSelectionPanel.PerformLayout();
            this.numericOptionsPanel.ResumeLayout(false);
            this.numericOptionsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mazeSizeNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerIntervalNumeric)).EndInit();
            this.newMazePanel.ResumeLayout(false);
            this.newMazePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mazeHeigthNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mazeWidthNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mazePanel;
        private System.Windows.Forms.PictureBox mazePictureBox;
        private System.Windows.Forms.Timer algorithmTimer;
        private System.ComponentModel.BackgroundWorker generatingBackgroundWorker;
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
        private System.ComponentModel.BackgroundWorker solvingBackgroundWorker;
        private System.Windows.Forms.Button solveMazeButton;
        private System.Windows.Forms.Panel numericOptionsPanel;
        private System.Windows.Forms.NumericUpDown timerIntervalNumeric;
        private System.Windows.Forms.Label intervalLabel;
        private System.Windows.Forms.NumericUpDown mazeSizeNumeric;
        private System.Windows.Forms.Label mazeSizeLabel;
        private System.Windows.Forms.Panel newMazePanel;
        private System.Windows.Forms.Button createMazeButton;
        private System.Windows.Forms.NumericUpDown mazeHeigthNumeric;
        private System.Windows.Forms.Label mazeHeightLabel;
        private System.Windows.Forms.NumericUpDown mazeWidthNumeric;
        private System.Windows.Forms.Label mazeWidthLabel;
        private System.Windows.Forms.Button nextStepButton;
        private System.Windows.Forms.CheckBox showPositionCheckbox;
        private System.Windows.Forms.Label aboutLabel;
    }
}

