using ResourceGatherer.Entities;
using ResourceGatherer.Util;
using ResourceGatherer.Materials;
using ResourceGatherer.World.Tiles;
using ResourceGatherer.World.Graphs;
using ResourceGatherer.World.Grids;
using ResourceGatherer.World.UserInterface;
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

namespace ResourceGatherer.World {
    /// <summary>
    /// The GameWorld, it holds all the information for our pieces
    /// </summary>
    public class GameWorld {
        /// <summary>
        /// The game width
        /// </summary>
        public readonly int gameWidth;
        /// <summary>
        /// The game height
        /// </summary>
        public readonly int gameHeight;

        // An instance of the gameworld
        public static GameWorld instance;

        /// <summary>
        /// The collection of all the materials we have
        /// </summary>
        public MaterialCollector materialCollection;

        /// <summary>
        /// The graph of our world
        /// </summary>
        private Graph graph;
        /// <summary>
        /// The grid of our world
        /// </summary>
        public GridSystem grid;
        /// <summary>
        /// The tiles of our world
        /// </summary>
        public TileSystem tiles;

        // The list of all entities on the map
        private List<BaseEntity> _entites;
        /// <summary>
        /// Public list of all entities
        /// </summary>
        private List<BaseEntity> entites {
            get {
                if (_entites == null)
                    _entites = new List<BaseEntity>();
                return _entites;
            }
        }

        /// <summary>
        /// Instance of the time class
        /// </summary>
        private Time time;

        /// <summary>
        /// Constructor for the GameWorld class
        /// </summary>
        /// <param name="width">The width of the world</param>
        /// <param name="height">The height of the world</param>
        public GameWorld(int width, int height) {
            instance = this;

            gameWidth = width;
            gameHeight = height;

            // Init the time, graph, grid- and tilessystem
            time = new Time();
            materialCollection = new MaterialCollector(true);
            graph = new Graph(this);
            grid = new GridSystem(this);
            tiles = new TileSystem(this);

            // Initializations for the tiles-, gridsystem and graph
            tiles.initTiles();
            grid.initGrid();
            graph.initGraph();

            // A temp NPC to test stuff with
            Gatherer npc = new Gatherer(new Vector2D(20, 100), // Position
                                                20, // Bounding Radius
                                                new Vector2D(0, 0), // Velocity
                                                40, // Max Speed
                                                Vector2D.Up, // Heading
                                                1, // Mass
                                                new Vector2D(15, 15), // Scale
                                                0.05f, // Turnrate
                                                10, // Max Force
                                                15, // Carry Capacity
                                                1); // MatID

            Gatherer npc2 = new Gatherer(new Vector2D(60, 100), // Position
                                                20, // Bounding Radius
                                                new Vector2D(0, 0), // Velocity
                                                40, // Max Speed
                                                Vector2D.Left, // Heading
                                                1, // Mass
                                                new Vector2D(15, 15), // Scale
                                                0.05f, // Turnrate
                                                10, // Max Force
                                                15, // Carry Capacity
                                                2); // MatID

            // Setting the path for the npc to follow
            npc.path.Set(Path.GetPathTo(tiles.tiles[tiles.GetIndexOfTile(npc.position)], Material.WOOD));
            npc2.path.Set(Path.GetPathTo(tiles.tiles[tiles.GetIndexOfTile(npc2.position)], Material.STONE));

            // Adding the npc to the world
            entites.Add(npc);
            entites.Add(npc2);
        }

        /// <summary>
        /// Updates the time and all entities that have been registered
        /// </summary>
        public void Update() {
            time.Update();

            if (_entites != null)
                for (int i = 0; i < entites.Count; i++)
                    entites[i].Update(Time.deltaTimeSeconds);
        }

        /// <summary>
        /// Draws all the entities and all paths present
        /// </summary>
        /// <param name="g">The graphics instance</param>
        public void RenderGame(Graphics g) {
            if (_entites != null)
                for (int i = 0; i < entites.Count; i++)
                    entites[i].Render(g);
            foreach (BaseEntity b in entites)
                if (b is MovingEntity m)
                    m.path.Render(g);
        }

        /// <summary>
        /// Draws the User Interface
        /// </summary>
        /// <param name="g">The graphics instance</param>
        public void RenderUI(Graphics g) {
            UI.Render(g);
        }

        /// <summary>
        /// Renders all tiles and, atm, the grid
        /// </summary>
        /// <param name="g"></param>
        public void GetBackground(Graphics g) {
            tiles.Render(g);
            grid.Render(g);
        }
    }
}
