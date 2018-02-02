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

            maze = new Maze(30, 20);

            mazePictureBox.Invalidate();

            generatinBackgroundWorker.RunWorkerAsync();
        }
        #endregion

        #region Events
        private void mazePictureBox_Paint(object sender, PaintEventArgs e) {
            base.OnPaint(e);
            {
                maze.Draw(e.Graphics);
            }
        }
        #endregion

        private void algorithmTimer_Tick(object sender, EventArgs e) {
            mazePictureBox.Invalidate();

            Global.doStep = true;
        }

        private void generatinBackgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
            maze.GenerateMaze();
        }
    }
}
