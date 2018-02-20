using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thievery.Utils;
using Thievery.World;

namespace Thievery {
    public static class GameEngine {
        #region Booleans
        private static bool _runGame = false;
        public static bool runGame {
            get {
                return _runGame;
            }
        }

        private static volatile bool _isDrawing = false;
        public static bool isDrawing {
            get {
                return _isDrawing;
            }
            set {
                _isDrawing = value;
            }
        }

        private static volatile bool _doDraw = false;
        public static bool doDraw {
            get {
                return _doDraw;
            }
            set {
                _doDraw = value;
            }
        }
        #endregion

        public static GameWorld game;

        public static void StartEngine() {
            game = new GameWorld();

            Time.Init();

            _runGame = true;

            while (_runGame) {
                while (_isDrawing) { }
                _doDraw = true;
                Update();
            }
        }

        public static void StopEngine() {
            _runGame = false;
        }

        private static void Update() {
            Time.Update();
            game.Update();
        }

        public static void Draw(Graphics e) {
            if (game != null)
                game.Draw(e);
            else
                Console.WriteLine("empty");
        }
    }
}
