using ScrollingGame.Entity;
using ScrollingGame.Entity.Characters;
using ScrollingGame.Gravity;
using ScrollingGame.Scrolling;
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
        private static List<IBehaviour> _addables;
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

        private static List<IBehaviour> addables {
            get {
                if (_addables == null)
                    _addables = new List<IBehaviour>();
                return _addables;
            }
        }


        public static IBehaviour subscribeToTick {
            set {
                if (!tickables.Contains(value) && !addables.Contains(value) && !removables.Contains(value))
                    addables.Add(value);
            }
        }

        public static IBehaviour unsubscribeFromTick {
            set {
                if ((tickables.Contains(value) || addables.Contains(value)) && !removables.Contains(value))
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

        public static Player newPlayer {
            get {
                return new Player(new Vector2(600, 450), new Vector2(15, 15), Color.Blue, true, true, 100);
            }
        }

        public static Player player;

        public static Level currentLevel;

        public static bool gamePause = false;

        public static float gameGravity = 2;

        public static float gameXLocation = 0;

        private static GameScroller gameScroller;

        #region functions
        public static void Load() {
            _tickables = null;
            _removables = null;
            _addables = null;
            loadNewBehaviour = new Time();
            loadNewBehaviour = player = newPlayer;
            loadNewBehaviour = new PlayerUI();
            loadNewBehaviour = new PowerupUI();

            gameScroller = new GameScroller();

            gameXLocation = 0;

            currentLevel.load();

            FieldPartContainer.generateFieldParts();

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
                //if (b.doTick)
                    b.onUpdate();

            foreach (IBehaviour b in addables)
                tickables.Add(b);

            foreach (IBehaviour b in removables)
                tickables.Remove(b);

            _addables = new List<IBehaviour>();
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
            foreach (IBehaviour b in tickables) {
                if (b.doDraw)
                    b.onDraw(g);
            }
        }
        #endregion
    }
}
