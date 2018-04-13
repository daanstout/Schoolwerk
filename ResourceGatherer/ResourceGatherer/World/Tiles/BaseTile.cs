using ResourceGatherer.Drawers.TileDrawers;
using ResourceGatherer.Entities.StaticEntities;
using ResourceGatherer.Util;
using ResourceGatherer.World.Graphs;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.World.Tiles {
    /// <summary>
    /// The Base Tile class
    /// </summary>
    public abstract class BaseTile {
        /// <summary>
        /// The width of a tile
        /// </summary>
        public static readonly int tileWidth = 20;
        /// <summary>
        /// The height of a tile
        /// </summary>
        public static readonly int tileHeight = 20;

        /// <summary>
        /// The sprite for the tile
        /// </summary>
        public Bitmap sprite;
        /// <summary>
        /// The position of the tile on the game world
        /// </summary>
        public Vector2D position;
        /// <summary>
        /// The vertex of the tile if it has one
        /// </summary>
        public Vertex tileVertex;

        /// <summary>
        /// Creates a rectangle from the position
        /// </summary>
        public RectangleF vertexRectangle {
            get {
                return new RectangleF(position.x + (tileWidth / 3), position.y + (tileHeight / 3), tileWidth - (tileWidth / 3 * 2), tileHeight - (tileHeight / 3 * 2));
            }
        }

        /// <summary>
        /// A boolean to show whether the tile can be walked upon
        /// </summary>
        public bool isWalkable;
        /// <summary>
        /// Allows diagonal movement to and from the tile
        /// </summary>
        public bool allowDiagonal;

        /// <summary>
        /// A list of all the entities
        /// </summary>
        private List<MaterialEntity> _entityList;
        /// <summary>
        /// A public list of all the entities
        /// </summary>
        public List<MaterialEntity> entityList {
            get {
                if (_entityList == null)
                    _entityList = new List<MaterialEntity>();
                return _entityList;
            }
        }

        /// <summary>
        /// Counts all the entities on the tile, should be used over entityList.Count
        /// </summary>
        public int entityCount {
            get {
                if (_entityList == null)
                    return 0;
                else
                    return _entityList.Count;
            }
        }

        /// <summary>
        /// THe tile drawer used when the tile needs to be drawn
        /// </summary>
        private static ITileDrawer tileDrawer;

        /// <summary>
        /// Creates a base tile from a position
        /// </summary>
        /// <param name="pos">The position of the tile</param>
        protected BaseTile(Vector2D pos) {
            position = pos;
        }

        /// <summary>
        /// Draws the tile using the tile drawer
        /// </summary>
        /// <param name="g">The graphics instance</param>
        public void Render(Graphics g) {
            tileDrawer.Draw(g, this);
        }

        /// <summary>
        /// If the tile is null and not walkable, create a new one
        /// </summary>
        public void CreateTileVertex() {
            if (tileVertex == null && isWalkable)
                tileVertex = new Vertex(position.ToString(), this);
        }

        /// <summary>
        /// Destroy the tile, setting it to null
        /// </summary>
        public void DestroyTileVertex() {
            tileVertex = null;
        }

        /// <summary>
        /// Sets the tile drawer
        /// </summary>
        /// <param name="drawer">The new drawer that should be used</param>
        public static void SetTileDrawer(ITileDrawer drawer) {
            tileDrawer = drawer;
        }

        /// <summary>
        /// Checks whether the tilevertex has the other tile as a registered neighbour
        /// </summary>
        /// <param name="other"></param>
        /// <returns>Whether they are neighbours</returns>
        public bool HasAdjacent(BaseTile other) {
            foreach (Edge e in tileVertex.adj)
                if (e.destination.parentTile == other)
                    return true;

            return false;
        }

        /// <summary>
        /// Creates a river from the current tile
        /// </summary>
        /// <returns>A new TileRiver</returns>
        public TileRiver GetRiverTile() {
            return new TileRiver(position);
        }

        /// <summary>
        /// Adds an entity to the tile
        /// </summary>
        /// <param name="entity"></param>
        public void AddEntityToTile(MaterialEntity entity) {
            if (!entityList.Contains(entity))
                entityList.Add(entity);
        }

        /// <summary>
        /// Checks whether the other tile is the same as this tile
        /// </summary>
        /// <param name="obj">The other tile</param>
        /// <returns>returns whether they are equal</returns>
        public override bool Equals(object obj) {
            var tile = obj as BaseTile;
            return tile != null &&
                   EqualityComparer<Vector2D>.Default.Equals(position, tile.position) &&
                   isWalkable == tile.isWalkable &&
                   EqualityComparer<List<MaterialEntity>>.Default.Equals(_entityList, tile._entityList);
        }

        /// <summary>
        /// Gets a hashcode
        /// </summary>
        /// <returns>the hashcode</returns>
        public override int GetHashCode() {
            var hashCode = 978046299;
            hashCode = hashCode * -1521134295 + EqualityComparer<Vector2D>.Default.GetHashCode(position);
            hashCode = hashCode * -1521134295 + isWalkable.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<MaterialEntity>>.Default.GetHashCode(_entityList);
            return hashCode;
        }
    }
}
