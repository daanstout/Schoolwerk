using ResourceGatherer.Entities;
using ResourceGatherer.Util;
using ResourceGatherer.World.Tiles;
using ResourceGatherer.World.Graphs;
using ResourceGatherer.World.Grids;
using ResourceGatherer.Entities.MovingEntities;
using ResourceGatherer.Entities.StaticEntities;
using ResourceGatherer.Properties;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using ResourceGatherer.Materials;

namespace ResourceGatherer.World {
    public class GameWorld {
        public readonly int gameWidth;
        public readonly int gameHeight;

        public static GameWorld instance;

        private Graph graph;
        public GridSystem grid;
        public TileSystem tiles;

        private List<BaseEntity> _entites;
        private List<BaseEntity> entites {
            get {
                if (_entites == null)
                    _entites = new List<BaseEntity>();
                return _entites;
            }
        }

        private Time time;

        public GameWorld(int width, int height) {
            instance = this;

            gameWidth = width;
            gameHeight = height;

            time = new Time();
            graph = new Graph(this);
            grid = new GridSystem(this);
            tiles = new TileSystem(this);

            FriendlyNPC npc = new FriendlyNPC(new Vector2D(20, 100),
                                                20,
                                                new Vector2D(0, 0),
                                                10,
                                                Vector2D.Up,
                                                1,
                                                new Vector2D(15, 15),
                                                0.05f,
                                                10);

            tiles.initTiles();
            grid.initGrid();
            graph.initGraph();
            //tiles.Prepare();
            //npc.path.Set(Path.GetPathTo(tiles.tiles[tiles.GetIndexOfTile(npc.position)], tiles.tiles[500]));
            npc.path.Set(Path.GetPathTo(tiles.tiles[tiles.GetIndexOfTile(npc.position)], Material.STONE));

            entites.Add(npc);
        }

        public void Update() {
            time.Update();

            if (_entites != null)
                for (int i = 0; i < entites.Count; i++)
                    entites[i].Update(Time.deltaTimeSeconds);
        }

        public void Draw(Graphics g) {
            if (_entites != null)
                for (int i = 0; i < entites.Count; i++)
                    entites[i].Render(g);
        }

        public void GetBackground(Graphics g) {
            tiles.Render(g);
            grid.Render(g);
            foreach(BaseEntity b in entites) {
                if (b is MovingEntity m)
                    m.path.Render(g);
            }
        }
    }
}
