using MazeAlgorithms.Algorithms.Generating;
using MazeAlgorithms.Algorithms.Solving;
using MazeAlgorithms.MazeMain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeAlgorithms {
    public partial class MazeWindow : Form {
        #region Variables
        public Maze maze;
        #endregion

        #region Constructors
        public MazeWindow() {
            InitializeComponent();

            generationAlgorithmComboBox.Items.Add("Hunt and Kill");
            generationAlgorithmComboBox.Items.Add("Kruskal's");
            generationAlgorithmComboBox.Items.Add("Prim's");
            generationAlgorithmComboBox.Items.Add("Recursive");
            generationAlgorithmComboBox.Items.Add("Recursive Backtracker");

            solvingAlgorithmComboBox.Items.Add("A*");
            solvingAlgorithmComboBox.Items.Add("Backtracking");
            solvingAlgorithmComboBox.Items.Add("Breadth First");
            solvingAlgorithmComboBox.Items.Add("Dead End Filling");
            solvingAlgorithmComboBox.Items.Add("Depth First");
            solvingAlgorithmComboBox.Items.Add("Greedy Best First");
            solvingAlgorithmComboBox.Items.Add("Person Simulator");
            solvingAlgorithmComboBox.Items.Add("Right Hand");
            solvingAlgorithmComboBox.Items.Add("QLearning");

            maze = new Maze((int)mazeWidthNumeric.Value, (int)mazeHeigthNumeric.Value);

            // Update settings from the form on startup.
            maze.UpdateSolvingDrawMethod(showDistanceCheckbox.Checked);
            if (pauseCheckBox.Checked)
                algorithmTimer.Enabled = false;
            else
                algorithmTimer.Enabled = true;
            Global.noDelay = noDelayCheckBox.Checked;
            Global.showPosition = showPositionCheckbox.Checked;
            maze.SetGeneratingAlgorithm(generationAlgorithmComboBox.SelectedIndex);
            maze.SetSolvingAlgorithm(solvingAlgorithmComboBox.SelectedIndex);
            algorithmTimer.Interval = (int)timerIntervalNumeric.Value;
            Global.squareSize = (int)mazeSizeNumeric.Value;

            aboutLabel.Text = maze.GetAbout();

            mazePictureBox.Invalidate();
        }
        #endregion

        #region Events
        private void mazePictureBox_Paint(object sender, PaintEventArgs e) {
            base.OnPaint(e);
            {
                Global.isDrawing = true;
                maze.Draw(e.Graphics);
                Global.isDrawing = false;
            }
        }

        private void algorithmTimer_Tick(object sender, EventArgs e) {
            mazePictureBox.Invalidate();

            Global.doStep = true;
        }

        private void generatingBackgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
            maze.GenerateMaze();
        }

        private void generateMazeButton_Click(object sender, EventArgs e) {
            generateMazeButton.Enabled = solveMazeButton.Enabled = generationAlgorithmComboBox.Enabled = false;

            generatingBackgroundWorker.RunWorkerAsync();
        }

        private void noDelayCheckBox_CheckedChanged(object sender, EventArgs e) {
            Global.noDelay = noDelayCheckBox.Checked;
        }

        private void generationAlgorithmComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            maze.SetGeneratingAlgorithm(generationAlgorithmComboBox.SelectedIndex);

            aboutLabel.Text = maze.GetAbout();

            mazePictureBox.Invalidate();
        }

        private void solvingAlgorithmComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            maze.SetSolvingAlgorithm(solvingAlgorithmComboBox.SelectedIndex);

            if (maze.isMaze)
                solveMazeButton.Enabled = true;
            else
                solveMazeButton.Enabled = false;

            aboutLabel.Text = maze.GetAbout();

            mazePictureBox.Invalidate();
        }

        private void solvingBackgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
            maze.SolveMaze();
        }

        private void solveMazeButton_Click(object sender, EventArgs e) {
            solveMazeButton.Enabled = generateMazeButton.Enabled = solvingAlgorithmComboBox.Enabled = false;

            solvingBackgroundWorker.RunWorkerAsync();

            mazePictureBox.Invalidate();
        }

        private void pauseCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (pauseCheckBox.Checked)
                algorithmTimer.Enabled = false;
            else
                algorithmTimer.Enabled = true;
        }

        private void showDistanceCheckbox_CheckedChanged(object sender, EventArgs e) {
            //Global.showDistance = showDistanceCheckbox.Checked;
            maze.UpdateSolvingDrawMethod(showDistanceCheckbox.Checked);
        }

        private void timerIntervalNumeric_ValueChanged(object sender, EventArgs e) {
            if (timerIntervalNumeric.Value == 0)
                Global.noDelay = true;
            else {
                Global.noDelay = false;
                algorithmTimer.Interval = (int)timerIntervalNumeric.Value;
            }
        }

        private void mazeSizeNumeric_ValueChanged(object sender, EventArgs e) {
            Global.squareSize = (int)mazeSizeNumeric.Value;
        }

        private void createMazeButton_Click(object sender, EventArgs e) {
            maze = new Maze((int)mazeWidthNumeric.Value, (int)mazeHeigthNumeric.Value);

            int width = maze.width * Global.squareSize;
            int height = maze.height * Global.squareSize;

            mazePictureBox.Width = width > mazePanel.Width ? width : mazePanel.Width;
            mazePictureBox.Height = height > mazePanel.Height ? height : mazePanel.Height;

            maze.SetSolvingAlgorithm(solvingAlgorithmComboBox.SelectedIndex);
            maze.SetGeneratingAlgorithm(generationAlgorithmComboBox.SelectedIndex);

            solveMazeButton.Enabled = false;

            generateMazeButton.Enabled = true;
        }

        private void nextStepButton_Click(object sender, EventArgs e) {
            Global.doStep = true;

            mazePictureBox.Invalidate();
        }

        private void generatingBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            solveMazeButton.Enabled = generateMazeButton.Enabled = generationAlgorithmComboBox.Enabled = true;
        }

        private void solvingBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            generateMazeButton.Enabled = solvingAlgorithmComboBox.Enabled = true;

            solveMazeButton.Enabled = false;
        }

        private void showPositionCheckbox_CheckedChanged(object sender, EventArgs e) {
            Global.showPosition = showPositionCheckbox.Checked;
        }
        #endregion
    }
}
