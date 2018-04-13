using ResourceGatherer.Entities.StaticEntities;
using ResourceGatherer.Materials;
using ResourceGatherer.Util.Datastructures;
using ResourceGatherer.World;
using ResourceGatherer.World.Graphs;
using ResourceGatherer.World.Tiles;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Util {
    /// <summary>
    /// The Path class, This holds mutliple waypoints which become a path for an entity
    /// </summary>
    public sealed class Path {
        /// <summary>
        /// The list of vectors
        /// </summary>
        private List<Vector2D> waypoints;
        /// <summary>
        /// A random used for random paths
        /// </summary>
        private static Random rand = new Random();

        /// <summary>
        /// The current waypoint. This is null if there is no current waypoint
        /// </summary>
        public Vector2D current {
            get {
                if (waypoints != null) {
                    if (waypoints.Count > 0)
                        return waypoints[0];
                    else
                        return null;
                } else
                    return null;
            }
        }
        /// <summary>
        /// The last waypoint. This is null if there is no last waypoint
        /// </summary>
        public Vector2D end {
            get {
                if (waypoints != null)
                    if (waypoints.Count > 0)
                        return waypoints[waypoints.Count - 1];
                    else
                        return null;
                else
                    return null;
            }
        }

        /// <summary>
        /// Checks whether the path is finished
        /// </summary>
        public bool isFinished {
            get {
                return Count == 0;
            }
        }

        /// <summary>
        /// How many waypoints there are. Use this over waypoints.Count
        /// </summary>
        public int Count {
            get {
                if (waypoints == null)
                    return 0;
                else
                    return waypoints.Count;
            }
        }

        /// <summary>
        /// Emtpy constructor
        /// </summary>
        public Path() : this(new List<Vector2D>()) { }

        /// <summary>
        /// Initializes the waypoint list
        /// </summary>
        /// <param name="path">An existing list of vectors</param>
        public Path(List<Vector2D> path) {
            waypoints = path;
        }

        /// <summary>
        /// Creates a random path
        /// </summary>
        private void RandomPath() {
            for (int i = 0; i < 10; i++) {
                waypoints.Add(new Vector2D(rand.Next(0, 800), rand.Next(0, 600)));
            }
        }

        /// <summary>
        /// Goes to the next waypoint
        /// </summary>
        /// <returns>Returns false if there is no next waypoint</returns>
        public bool GoNext() {
            if (waypoints != null) {
                if (waypoints.Count > 0)
                    waypoints.RemoveAt(0);
                return waypoints.Count > 0;
            }
            return false;
        }

        /// <summary>
        /// Adds a waypoint to the end of the list
        /// </summary>
        /// <param name="point">The Vector2D location of the point</param>
        public void AddWaypoint(Vector2D point) {
            waypoints.Add(point);
        }

        /// <summary>
        /// Adds a waypoint to the end of the list
        /// </summary>
        /// <param name="point">The Vertex of the point</param>
        public void AddWaypoint(Vertex point) {
            waypoints.Add(point.parentTile.position);
        }

        /// <summary>
        /// Adds a waypoint to the end of the list
        /// </summary>
        /// <param name="point">The tile of the point</param>
        public void AddWaypoint(BaseTile point) {
            waypoints.Add(point.position);
        }

        /// <summary>
        /// Adds a waypoint to the start of the list
        /// </summary>
        /// <param name="point">The Vector2D of the point</param>
        public void AddWaypointFront(Vector2D point) {
            waypoints.Insert(0, point);
        }

        /// <summary>
        /// Adds a waypoint to the start of the list
        /// </summary>
        /// <param name="point">The Vertex of the point</param>
        public void AddWaypointFront(Vertex point) {
            waypoints.Insert(0, point.parentTile.position + new Vector2D(BaseTile.tileWidth / 2, BaseTile.tileHeight / 2));
        }

        /// <summary>
        /// Adds a waypoint to the start of the list
        /// </summary>
        /// <param name="point">The tile of the point</param>
        public void AddWaypointFront(BaseTile point) {
            waypoints.Insert(0, point.position);
        }

        /// <summary>
        /// Draws the path
        /// </summary>
        /// <param name="g">The graphics instance</param>
        public void Render(Graphics g) {
            for (int i = 0; i < waypoints.Count - 1; i++)
                g.DrawLine(new Pen(Color.Blue), waypoints[i], waypoints[i + 1]);
        }

        /// <summary>
        /// Sets a path from another path
        /// </summary>
        /// <param name="path"></param>
        public void Set(Path path) {
            waypoints = path.waypoints;
        }

        /// <summary>
        /// Sets the path based on a list of vectors
        /// </summary>
        /// <param name="path"></param>
        public void Set(List<Vector2D> path) {
            waypoints = path;
        }

        /// <summary>
        /// Clears the waypoints
        /// </summary>
        public void Clear() {
            waypoints.Clear();
        }

        /// <summary>
        /// Gets a path from the given position to the target position. Uses A*
        /// </summary>
        /// <param name="pos">The start tile</param>
        /// <param name="target">The target tile</param>
        /// <returns>A list of vectors to the target</returns>
        public static Path GetPathTo(BaseTile pos, BaseTile target) {
            Path p = new Path();

            if (pos.tileVertex == null)
                return p;

            TileSystem.Prepare(ResourceGatherer.instance.gameWorld.tiles.tiles);

            PriorityQueue<Vertex> q = new PriorityQueue<Vertex>();

            pos.tileVertex.dist = 0;
            pos.tileVertex.Scratch = true;

            q.Insert(pos.tileVertex, Heuristics(pos.position, target.position));

            Vertex current;

            while (!q.isEmpty) {
                current = q.GetHighestPriority();

                if (current == null)
                    continue;

                if (current.parentTile.position == target.position) {
                    Vertex icurrent = current;
                    while (icurrent.prev != null) {
                        p.AddWaypointFront(icurrent);
                        icurrent = icurrent.prev;
                    }
                    return p;
                }

                foreach (Edge e in current.adj) {
                    if (e.destination.dist >= current.dist + e.cost) {
                        e.destination.prev = current;
                        e.destination.dist = current.dist + e.cost;
                        if (!e.destination.Scratch) {
                            e.destination.Scratch = true;
                            q.Insert(e.destination, (int)e.destination.dist + Heuristics(e.destination.parentTile.position, target.position));
                        }
                    }
                }
            }

            return p;
        }

        /// <summary>
        /// Returns a heuristic distance between 2 points
        /// </summary>
        /// <param name="a">Point a</param>
        /// <param name="b">Point b</param>
        /// <returns>the estimated distance between 2 points</returns>
        private static int Heuristics(Vector2D a, Vector2D b) => (int)Math.Abs((a.x / BaseTile.tileWidth) - (b.x / BaseTile.tileWidth)) + (int)Math.Abs((a.y / BaseTile.tileHeight) - (b.y / BaseTile.tileHeight));

        /// <summary>
        /// Gets a path from the given position to the nearest target material. Uses Dijkstra
        /// </summary>
        /// <param name="pos">The start tile</param>
        /// <param name="mat">The material looked for</param>
        /// <returns>A path with the list of vectors</returns>
        public static Path GetPathTo(BaseTile pos, Material mat) {
            Path p = new Path();

            if (pos.tileVertex == null)
                return p;

            TileSystem.Prepare(GameWorld.instance.tiles.tiles);

            PriorityQueue<Vertex> q = new PriorityQueue<Vertex>();

            pos.tileVertex.dist = 0;
            pos.tileVertex.Scratch = true;

            q.Insert(pos.tileVertex, pos.tileVertex.dist);

            Vertex current;

            while (!q.isEmpty) {
                current = q.GetHighestPriority();

                if (current == null)
                    continue;

                foreach (MaterialEntity m in current.parentTile.entityList) {
                    if (m.material.Equals(mat)) {
                        Vertex icurrent = current.prev;
                        p.AddWaypointFront(current);
                        if (icurrent != null)
                            while (icurrent.prev != null) {
                                p.AddWaypointFront(icurrent);
                                icurrent = icurrent.prev;
                            }
                        return p;
                    }
                }

                foreach (Edge e in current.adj) {
                    if (e.destination.dist >= current.dist + e.cost) {
                        e.destination.prev = current;
                        e.destination.dist = current.dist + e.cost;
                        if (!e.destination.Scratch) {
                            e.destination.Scratch = true;
                            q.Insert(e.destination, e.destination.dist);
                        }
                    }
                }
            }

            return p;
        }
    }
}
