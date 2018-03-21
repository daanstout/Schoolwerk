using ResourceGatherer.Entities;
using ResourceGatherer.Util;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.World.Grids {
    public class GridSystem {
        /// <summary>
        /// A list of all the grids
        /// </summary>
        public Grid[] gameGrid;
        /// <summary>
        /// The amount of grids in the system
        /// </summary>
        private int gridCount;

        /// <summary>
        /// Constructor for the GridSystem
        /// </summary>
        public GridSystem() { }

        /// <summary>
        /// Initializes the grid system
        /// </summary>
        public void initGrid() {
            gridCount = (GameWorld.instance.gameWidth / Grid.GridWidth) * (GameWorld.instance.gameHeight / Grid.GridHeight);
            gameGrid = new Grid[gridCount];

            float curX = 0, curY = 0;

            for (int i = 0; i < gridCount; i++) {
                gameGrid[i] = new Grid(new Vector2D(curX, curY));
                curX += Grid.GridWidth;
                if (curX >= GameWorld.instance.gameWidth) {
                    curX = 0;
                    curY += Grid.GridHeight;
                }
            }
        }

        /// <summary>
        /// Converts a position to an index
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        private int PositionToIndex(Vector2D pos) {
            if (pos == null)
                return 0;
            int index = 0;
            int gridsPerRow = GameWorld.instance.gameWidth / Grid.GridWidth;

            index += (int)pos.x / Grid.GridWidth;
            index += ((int)pos.y / Grid.GridHeight) * gridsPerRow;

            return index >= gridCount ? gridCount : index;
        }

        /// <summary>
        /// Gets the position of the grid
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public Vector2D GetGridPosition(Vector2D pos) {
            int idx = PositionToIndex(pos);
            return gameGrid[idx].position;
        }

        public Vector2D GetGridPosition(int index) {
            return gameGrid[index].position;
        }

        /// <summary>
        /// Draws the grid
        /// </summary>
        /// <param name="g"></param>
        public void Render(Graphics g) {
            for (int i = 0; i < gridCount; i++) {
                g.DrawRectangle(new Pen(Color.Yellow), new Rectangle((int)gameGrid[i].position.x, (int)gameGrid[i].position.y, Grid.GridWidth, Grid.GridHeight));
            }
        }

        /// <summary>
        /// Registers an entity
        /// </summary>
        /// <param name="entity">The entity to be registered</param>
        /// <returns>Returns the index of the grid it is put in, or -1 if the entity was 0</returns>
        public int RegisterEntity(BaseEntity entity) {
            if (entity == null)
                return -1;

            int idx = PositionToIndex(entity.position);

            gameGrid[idx].entityList.Add(entity);

            return idx;
        }

        /// <summary>
        /// Updates an entity and changes the grid it is in if needed
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <param name="oldPos">The previous position of the entity</param>
        /// <returns>Returns the new index of the entity</returns>
        public int UpdateEntity(BaseEntity entity, Vector2D oldPos) {
            int newIdx = PositionToIndex(entity.position), oldIdx = PositionToIndex(oldPos);

            if (newIdx == oldIdx)
                return newIdx;

            gameGrid[oldIdx].entityList.Remove(entity);
            gameGrid[newIdx].entityList.Add(entity);

            return newIdx;
        }

        /// <summary>
        /// Empties all the grid of all the entities
        /// </summary>
        public void EmptyCells() {
            foreach (Grid g in gameGrid)
                g.entityList.Clear();
        }

        /// <summary>
        /// Creates a list of all neighbours that are within range of the entity
        /// </summary>
        /// <param name="targetPos">The point from which it should calculate</param>
        /// <param name="queryRad">The radius of the circle used in calculations</param>
        /// <returns>A list of entities close enough to the targetposition</returns>
        public List<BaseEntity> CalculateNeighbours(Vector2D targetPos, float queryRad) {
            Rectangle targetRect = new Rectangle(targetPos - new Vector2D(queryRad, queryRad), new Vector2D(queryRad * 2, queryRad * 2));

            List<BaseEntity> foundNeighbours = new List<BaseEntity>();

            foreach (Grid grid in gameGrid) {
                Rectangle gridRectangle = new Rectangle(grid.position, new Vector2D(Grid.GridWidth, Grid.GridHeight));
                if (targetRect.IntersectsWith(gridRectangle)) {
                    if (grid.entityCount > 0) {
                        foreach (BaseEntity entity in grid.entityList) {
                            if (Vector2D.Vec2DDistanceSq(entity.position, targetPos) < queryRad * queryRad)
                                foundNeighbours.Add(entity);
                        }
                    }
                }
            }

            return foundNeighbours;
        }
    }
}
