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

            generationAlgorithmComboBox.Items.Add("Random Generation");
            //generationAlgorithmComboBox.Items.Add("Recursive Generation");

            solvingAlgorithmComboBox.Items.Add("A*");
            solvingAlgorithmComboBox.Items.Add("Backtracking");
            solvingAlgorithmComboBox.Items.Add("Greedy Best First");

            maze = new Maze(30, 20);

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

        private void generatinBackgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
            maze.GenerateMaze();
        }

        private void generateMazeButton_Click(object sender, EventArgs e) {
            generateMazeButton.Enabled = solveMazeButton.Enabled = false;

            generatinBackgroundWorker.RunWorkerAsync();
        }

        private void noDelayCheckBox_CheckedChanged(object sender, EventArgs e) {
            Global.noDelay = noDelayCheckBox.Checked;
        }

        private void generationAlgorithmComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            switch (generationAlgorithmComboBox.SelectedIndex) {
                case 0:
                    maze.SetGeneratingAlgorithm(new RandomGeneratingAlgorithm());
                    break;
                case 1:
                    maze.SetGeneratingAlgorithm(new RecursiveGeneratingAlgorithm());
                    break;
            }
        }

        private void solvingAlgorithmComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            switch (solvingAlgorithmComboBox.SelectedIndex) {
                case 0:
                    maze.SetSolvingAlgorithm(new AStarSolvingAlgorithm());
                    break;
                case 1:
                    maze.SetSolvingAlgorithm(new BacktrackingSolvingAlgorithm());
                    break;
                case 2:
                    maze.SetSolvingAlgorithm(new GreedyBestFirstSolvingAlgorithm());
                    break;
            }

            if (maze.maze.IsMaze())
                solveMazeButton.Enabled = true;
        }

        private void solvingBackgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
            maze.SolveMaze();
        }

        private void solveMazeButton_Click(object sender, EventArgs e) {
            solveMazeButton.Enabled = generateMazeButton.Enabled = false;

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
            Global.showDistance = showDistanceCheckbox.Checked;
        }
        #endregion

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

            solveMazeButton.Enabled = false;

            generateMazeButton.Enabled = true;
        }

        private void nextStepButton_Click(object sender, EventArgs e) {
            Global.doStep = true;

            mazePictureBox.Invalidate();
        }

        private void generatinBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            solveMazeButton.Enabled = generateMazeButton.Enabled = true;
        }

        private void solvingBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            generateMazeButton.Enabled = true;

            solveMazeButton.Enabled = false;
        }
    }
}
