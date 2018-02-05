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

            solvingAlgorithmComboBox.Items.Add("A*");
            solvingAlgorithmComboBox.Items.Add("Backtracking");

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
            }
        }

        private void solvingBackgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
            maze.SolveMaze();
        }

        private void solveMazeButton_Click(object sender, EventArgs e) {
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
    }
}
