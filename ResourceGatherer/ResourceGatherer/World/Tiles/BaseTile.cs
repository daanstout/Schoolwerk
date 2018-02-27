using ResourceGatherer.Drawers.TileDrawers;
using ResourceGatherer.Entities;
using ResourceGatherer.Util;
using ResourceGatherer.World.Graphs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.World.Tiles {
    public class BaseTile {
        public static int tileWidth = 20;
        public static int tileHeight = 20;

        public Bitmap sprite;
        public Vector2D position;
        public Vertex tileVertex;

        public RectangleF vertexRectangle {
            get {
                return new RectangleF(position.x + 7, position.y + 7, tileWidth - 14, tileHeight - 14);
            }
        }

        public bool isWalkable = true;

        private List<StaticEntity> _entityList;
        public List<StaticEntity> entityList {
            get {
                if (_entityList == null)
                    _entityList = new List<StaticEntity>();
                return _entityList;
            }
        }

        private static ITileDrawer tileDrawer;

        public BaseTile(Vector2D pos) {
            position = pos;
        }

        public void Render(Graphics g) {
            tileDrawer.Draw(g, this);
        }

        public void CreateTileVertex() {
            if (tileVertex == null)
                tileVertex = new Vertex(position.ToString(), this);
        }

        public void DestroyTileVertex() {
            tileVertex = null;
        }

        public static void SetTileDrawer(ITileDrawer drawer) {
            tileDrawer = drawer;
        }

        public bool HasAdjacent(BaseTile other) {
            foreach (Edge e in tileVertex.adj)
                if (e.destination.parentTile == other)
                    return true;

            return false;
        }
    }
}
