using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thievery.Behaviours;
using Thievery.Properties;
using Thievery.Utils;
using Thievery.World.Tiles;

namespace Thievery.World {
    public class GameWorld : IUpdatable, IDrawable {
        #region Tickables
        private List<ABase> _tickables;
        private volatile List<ABase> _removeTickables;
        private volatile List<ABase> _addTickables;

        private List<ABase> tickables {
            get {
                if (_tickables == null)
                    _tickables = new List<ABase>();
                return _tickables;
            }
        }

        private List<ABase> removeTickables {
            get {
                if (_removeTickables == null)
                    _removeTickables = new List<ABase>();
                return _removeTickables;
            }
        }

        private List<ABase> addTickables {
            get {
                if (_addTickables == null)
                    _addTickables = new List<ABase>();
                return _addTickables;
            }
        }


        public ABase addTickable {
            set {
                if (!tickables.Contains(value) && !addTickables.Contains(value)) {
                    addTickables.Add(value);
                }
            }
        }

        public ABase removeTickable {
            set {
                if (tickables.Contains(value) && !removeTickables.Contains(value))
                    removeTickables.Add(value);
            }
        }
        #endregion

        private GameTile[,] board;

        public GameWorld() {
            board = new GameTile[1, 30];
            for (int i = 0; i < 30; i++) {
                board[0, i] = new GameTile(Resources.Path___Crossing_N_E_S_W, new Point(400, i * 20));
            }
        }

        public void Update() {
            try {
                foreach (ABase b in addTickables) {
                    if (b != null)
                        tickables.Add(b);
                }
            } catch (InvalidOperationException e) {
                Console.WriteLine("Error with adding new tickable: " + e);
            }

            _addTickables = null;

            ValidateList<ABase>(ref _tickables);

            foreach (ABase b in tickables)
                if (b != null)
                    if (b.doTick)
                        b.Update();

            foreach (ABase b in removeTickables)
                if (b != null)
                    tickables.Remove(b);

            _removeTickables = null;
        }

        public void Draw(Graphics e) {
            foreach (ABase b in tickables)
                if (b != null)
                    if (b.doDraw)
                        b.Draw(e);

            foreach (GameTile t in board)
                if (t != null)
                    t.Draw(e);
                else
                    Console.WriteLine("oh");
        }

        private bool ValidateList<T>(ref List<T> list) {
            if (list == null)
                return false;

            List<T> invalids = new List<T>();

            foreach (T item in list)
                if (item == null)
                    invalids.Add(item);

            foreach (T item in invalids)
                list.Remove(item);

            return true;
        }
    }
}
