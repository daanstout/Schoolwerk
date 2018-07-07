using ResourceGatherer.Entities;
using ResourceGatherer.Entities.MovingEntities;
using ResourceGatherer.Materials;
using ResourceGatherer.Util;
using ResourceGatherer.World.Tiles;
using ResourceGatherer.World.Graphs;
using ResourceGatherer.World.Grids;
using ResourceGatherer.World.UserInterface;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using ResourceGatherer.Buildings;

namespace ResourceGatherer.World {
    /// <summary>
    /// The GameWorld, it holds all the information for our pieces
    /// </summary>
    public sealed class GameWorld {
        /// <summary>
        /// The game width
        /// </summary>
        public readonly int gameWidth;
        /// <summary>
        /// The game height
        /// </summary>
        public readonly int gameHeight;

        /// <summary>
        /// An instance of the gameworld
        /// </summary>
        public static GameWorld instance;

        /// <summary>
        /// The collection of all the materials we have
        /// </summary>
        public MaterialCollector materialCollection;

        /// <summary>
        /// The graph of our world
        /// </summary>
        public Graph graph;
        /// <summary>
        /// The grid of our world
        /// </summary>
        public GridSystem grid;
        /// <summary>
        /// The tiles of our world
        /// </summary>
        public TileSystem tiles;

        /// <summary>
        /// The list of all entities on the map
        /// </summary>
        private List<BaseEntity> _entities;
        /// <summary>
        /// Public list of all entities
        /// </summary>
        private List<BaseEntity> entities {
            get {
                if (_entities == null)
                    _entities = new List<BaseEntity>();
                return _entities;
            }
        }

        private List<BaseBuilding> _buildings;
        public List<BaseBuilding> buildings {
            get {
                if (_buildings == null)
                    _buildings = new List<BaseBuilding>();
                return _buildings;
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
            graph = new Graph();
            grid = new GridSystem();
            tiles = new TileSystem();

            // Initializations for the tiles-, gridsystem and graph
            tiles.initTiles();
            grid.initGrid();

            // A temp NPC to test stuff with
            Gatherer npc = new Gatherer(new Vector2D(20, 100), // Position
                                                20, // Bounding Radius
                                                new Vector2D(0, 0), // Velocity
                                                80, // Max Speed
                                                Vector2D.Up, // Heading
                                                1, // Mass
                                                new Vector2D(15, 15), // Scale
                                                0.05f, // Turnrate
                                                10, // Max Force
                                                15, // Carry Capacity
                                                Material.NULLMATERIAL.id); // MatID

            //Gatherer npc2 = new Gatherer(new Vector2D(60, 100), // Position
            //                                    20, // Bounding Radius
            //                                    new Vector2D(0, 0), // Velocity
            //                                    80, // Max Speed
            //                                    Vector2D.Left, // Heading
            //                                    1, // Mass
            //                                    new Vector2D(15, 15), // Scale
            //                                    0.05f, // Turnrate
            //                                    10, // Max Force
            //                                    15, // Carry Capacity
            //                                    2); // MatID

            StorageBuilding storage = new StorageBuilding(new Vector2D(400, 200), new Vector2D(40, 40));

            graph.initGraph();
            tiles.AddResources();

            // Setting the path for the npc to follow
            //npc.path.Set(Path.GetPathTo(tiles.tiles[TileSystem.GetIndexOfTile(npc.position)], Material.WOOD));
            //npc2.path.Set(Path.GetPathTo(tiles.tiles[TileSystem.GetIndexOfTile(npc2.position)], Material.STONE));

            // Adding the npc to the world
            entities.Add(npc);
            //entities.Add(npc2);

            storage.SetEntranceEdge();

            buildings.Add(storage);
        }

        /// <summary>
        /// Updates the time and all entities that have been registered
        /// </summary>
        public void Update() {
            time.Update();

            if (_entities != null)
                for (int i = 0; i < entities.Count; i++)
                    entities[i].Update(Time.deltaTimeSeconds);
        }

        /// <summary>
        /// Draws all the entities and all paths present
        /// </summary>
        /// <param name="g">The graphics instance</param>
        public void RenderGame(Graphics g) {
            if (_entities != null) {
                for (int i = 0; i < entities.Count; i++) {
                    entities[i].Render(g);
                    g.DrawString(entities[i].GetDebug(), Fonts.font_debug, new SolidBrush(Color.Black), new PointF((entities[i].position + new Vector2D(entities[i].scale.x, 0)).x, entities[i].position.y));
                    if (entities[i] is MovingEntity m)
                        m.path.Render(g);
                }
            }
        }

        /// <summary>
        /// Draws the User Interface
        /// </summary>
        /// <param name="g">The graphics instance</param>
        public void RenderUI(Graphics g) {
            UI.Render(g);
        }

        /// <summary>
        /// Renders all tiles
        /// </summary>
        /// <param name="g"></param>
        public void GetBackground(Graphics g) {
            tiles.Render(g);
            foreach (BaseBuilding building in buildings)
                building.Render(g);
            //grid.Render(g);
        }
    }
}
