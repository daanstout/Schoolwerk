using ScrollingGame.Entity.Characters;
using ScrollingGame.Entity.Obstacles;
using ScrollingGame.Utils;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScrollingGame {
    public partial class Game : Form {
        private enum dirs {
            W = 1,
            S = 2,
            A = 4,
            D = 8
        }

        public Game() {
            InitializeComponent();

            Singleton.game = this;

            CreateTestLevel();
        }

        public void gamePictureBox_Paint(object sender, PaintEventArgs e) {
            base.OnPaint(e);
            {
                Singleton.Draw(e.Graphics);
            }
        }

        private void gameStart() {
            Singleton.Load();
        }

        private void gameTimer_Tick(object sender, EventArgs e) {
            Singleton.Tick();
        }

        private void CreateTestLevel() {
            Level temp = new Level();
            temp.addObstale = new Obstacle(new Vector2(100, 100), new Vector2(20, 20), Color.Green, false);
            temp.addObstale = new Obstacle(new Vector2(300, 100), new Vector2(20, 20), Color.Black, false);
            temp.addObstale = new Obstacle(new Vector2(200, 100), new Vector2(20, 20), Color.Black, false);
            temp.addObstale = new Obstacle(new Vector2(0, 500), new Vector2(Global.width - 1, 20), Color.Red, false);
            temp.addObstale = new Obstacle(new Vector2(100, 470), new Vector2(100, 30), Color.Orange, false);
            Singleton.currentLevel = temp;
            gameStart();
        }

        private void Game_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.W:
                    Player.buttons[0] = true;
                    break;
                case Keys.S:
                    Player.buttons[1] = true;
                    break;
                case Keys.A:
                    Player.buttons[2] = true;
                    break;
                case Keys.D:
                    Player.buttons[3] = true;
                    break;
                case Keys.Space:
                    Singleton.player.jumpStrategy.Jump(Singleton.player);
                    break;
            }
        }

        private void Game_KeyUp(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.W:
                    Player.buttons[0] = false;
                    break;
                case Keys.S:
                    Player.buttons[1] = false;
                    break;
                case Keys.A:
                    Player.buttons[2] = false;
                    break;
                case Keys.D:
                    Player.buttons[3] = false;
                    break;

            }
        }
    }
}
