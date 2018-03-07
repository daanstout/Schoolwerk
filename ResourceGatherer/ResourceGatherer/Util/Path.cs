using ResourceGatherer.Entities;
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
    public class Path {
        private List<Vector2D> waypoints;

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

        public bool isFinished {
            get {
                return Count == 0;
            }
        }

        public int Count {
            get {
                if (waypoints == null)
                    return 0;
                else
                    return waypoints.Count;
            }
        }

        public Path() : this(new List<Vector2D>()) { }

        public Path(List<Vector2D> path) {
            waypoints = path;
            //RandomPath();
        }

        private void RandomPath() {
            Random rand = new Random();
            for (int i = 0; i < 10; i++) {
                waypoints.Add(new Vector2D(rand.Next(0, 800), rand.Next(0, 600)));
            }
        }

        public bool GoNext() {
            waypoints.RemoveAt(0);
            return waypoints.Count > 0;
        }

        public void AddWaypoint(Vector2D point) {
            waypoints.Add(point);
        }

        public void AddWaypoint(Vertex point) {
            waypoints.Add(point.parentTile.position);
        }

        public void AddWaypoint(BaseTile point) {
            waypoints.Add(point.position);
        }

        public void AddWaypointFront(Vector2D point) {
            waypoints.Insert(0, point);
        }

        public void AddWaypointFront(Vertex point) {
            waypoints.Insert(0, point.parentTile.position + new Vector2D(BaseTile.tileWidth / 2, BaseTile.tileHeight / 2));
        }

        public void AddWaypointFront(BaseTile point) {
            waypoints.Insert(0, point.position);
        }

        public void Render(Graphics g) {
            for (int i = 0; i < waypoints.Count - 1; i++)
                g.DrawLine(new Pen(Color.Blue), waypoints[i], waypoints[i + 1]);
        }

        public void Set(Path path) {
            waypoints = path.waypoints;
        }

        public void Set(List<Vector2D> path) {
            waypoints = path;
        }

        public void Clear() {
            waypoints.Clear();
        }

        public static Path GetPathTo(BaseTile pos, BaseTile target) {
            Path p = new Path();
            //TileSystem.Prepare();
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

        private static int Heuristics(Vector2D a, Vector2D b) {
            return (int)Math.Abs(a.x - b.x) + (int)Math.Abs(a.y - b.y);
        }

        public static Path GetPathTo(BaseTile pos, Material mat) {
            Path p = new Path();

            TileSystem.Prepare(GameWorld.instance.tiles.tiles);

            Datastructures.Queue<Vertex> q = new Datastructures.Queue<Vertex>();

            pos.tileVertex.dist = 0;
            pos.tileVertex.Scratch = true;

            q.Enqueue(pos.tileVertex);

            Vertex current;

            while (!q.isEmpty) {
                current = q.Dequeue();

                if (current == null)
                    continue;

                foreach (StaticEntity s in current.parentTile.entityList) {
                    if (s is MaterialEntity m) {
                        if (m.material.id == mat.id) {
                            Vertex icurrent = current.prev;
                            p.AddWaypointFront(current);
                            Console.WriteLine(m.position);
                            Console.WriteLine(current.parentTile.position);
                            while (icurrent.prev != null) {
                                p.AddWaypointFront(icurrent);
                                icurrent = icurrent.prev;
                            }
                            return p;
                        }
                    }
                }

                foreach (Edge e in current.adj) {
                    if (e.destination.dist >= current.dist + e.cost) {
                        e.destination.prev = current;
                        e.destination.dist = current.dist + e.cost;
                        if (!e.destination.Scratch) {
                            e.destination.Scratch = true;
                            q.Enqueue(e.destination);
                        }
                    }
                }
            }

            return p;
        }
    }
}
