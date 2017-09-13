﻿using ScrollingGame.Entity;
using ScrollingGame.Entity.Characters;
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
        #endregion

        #region public lazy variables
        private static List<IBehaviour> tickables {
            get {
                if (_tickables == null)
                    _tickables = new List<IBehaviour>();
                return _tickables;
            }
        }

        public static IBehaviour subscribeToTick {
            set {
                if (!tickables.Contains(value))
                    tickables.Add(value);
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
            subscribeToTick = new Time();
            subscribeToTick = player;

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
            Gravity.Gravity.EnactGravity();

            foreach (IBehaviour b in tickables)
                b.onUpdate(Time.deltaTimeMillis);
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
