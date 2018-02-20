using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thievery.Utils;

namespace Thievery {
    public partial class GameWindow : Form {
        private Tester test;

        public GameWindow() {
            InitializeComponent();

            gameBackgroundWorker.RunWorkerAsync();
            drawingBackgroundWorker.RunWorkerAsync();
        }

        private void gameBackgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
            GameEngine.StartEngine();
        }

        private void drawingBackgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
            while (GameEngine.runGame) {
                while (!GameEngine.doDraw) { }
                GameEngine.doDraw = false;
                gamePictureBox.Invalidate();
            }
        }

        private void gamePictureBox_Paint(object sender, PaintEventArgs e) {
            base.OnPaint(e);
            {
                GameEngine.isDrawing = true;

                GameEngine.Draw(e.Graphics);

                GameEngine.isDrawing = false;
            }
        }

        private void GameWindow_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.A:
                    test = new Tester(new PointF(0, 300), new SizeF(20, 20), 30);
                    GameEngine.game.addTickable = test;
                    break;
                case Keys.R:
                    GameEngine.game.removeTickable = test;
                    break;
                case Keys.Escape:
                    GameEngine.StopEngine();
                    break;
            }
        }
    }
}
