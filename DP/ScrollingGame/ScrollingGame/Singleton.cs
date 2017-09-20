using ScrollingGame.Entity;
using ScrollingGame.Entity.Characters;
using ScrollingGame.Gravity;
using ScrollingGame.UI;
using ScrollingGame.Utils;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame {
    public static class Singleton {
        #region lazy variables
        private static List<IBehaviour> _tickables;
        private static List<IBehaviour> _removables;
        #endregion

        #region public lazy variables
        private static List<IBehaviour> tickables {
            get {
                if (_tickables == null)
                    _tickables = new List<IBehaviour>();
                return _tickables;
            }
        }

        private static List<IBehaviour> removables {
            get {
                if (_removables == null)
                    _removables = new List<IBehaviour>();
                return _removables;
            }
        }

        public static IBehaviour subscribeToTick {
            set {
                if (!tickables.Contains(value))
                    tickables.Add(value);
            }
        }

        public static IBehaviour unsubscribeFromTick {
            set {
                if (tickables.Contains(value))
                    removables.Add(value);
            }
        }

        public static IBehaviour loadNewBehaviour {
            set {
                value.onLoad();
                subscribeToTick = value;
            }
        }
        #endregion

        public static Game game;

        public static Player player = new Player(new Vector2(0, 450), new Vector2(15, 15), Color.Blue, true);

        public static Level currentLevel;

        public static bool gamePause = false;

        public static float gameGravity = 2;

        #region functions
        public static void Load() {
            _tickables = null;
            loadNewBehaviour = new Time();
            loadNewBehaviour = player;
            loadNewBehaviour = new PlayerUI();
            loadNewBehaviour = new PowerupUI();

            currentLevel.load();

            game.gameTimer.Start();

            Console.WriteLine("load");

            foreach (IBehaviour b in tickables) {
                b.onLoad();
            }
        }

        public static void Tick() {
            if (gamePause)
                return;

            game.gamePictureBox.Invalidate();
            GravitationalForce.EnactGravity();

            foreach (IBehaviour b in tickables)
                b.onUpdate();

            foreach (IBehaviour b in removables)
                tickables.Remove(b);

            _removables = new List<IBehaviour>();
        }

        public static void pauseGame(bool pause) {
            if (pause)
                foreach (IBehaviour b in tickables)
                    b.onPause();
            else
                foreach (IBehaviour b in tickables)
                    b.onResume();
        }

        public static void Draw(Graphics g) {
            foreach (IBehaviour b in tickables)
                b.onDraw(g);
        }
        #endregion
    }
}
