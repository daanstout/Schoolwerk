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
        public Grid[] gameGrid;
        private int gridCount;

        private GameWorld world;

        public GridSystem(GameWorld world) {
            this.world = world;
        }

        public void initGrid() {
            gridCount = (world.gameWidth / Grid.GridWidth) * (world.gameHeight / Grid.GridHeight);
            gameGrid = new Grid[gridCount];

            float curX = 0, curY = 0;

            for (int i = 0; i < gridCount; i++) {
                gameGrid[i] = new Grid(new Vector2D(curX, curY));
                curX += Grid.GridWidth;
                if (curX >= world.gameWidth) {
                    curX = 0;
                    curY += Grid.GridHeight;
                }
            }
        }

        private int PositionToIndex(Vector2D pos) {
            if (pos == null)
                return 0;
            int index = 0;
            int gridsPerRow = world.gameWidth / Grid.GridWidth;

            index += (int)pos.x / Grid.GridWidth;
            index += ((int)pos.y / Grid.GridHeight) * gridsPerRow;

            return index >= gridCount ? gridCount : index;
        }

        public Vector2D GetGridPosition(Vector2D pos) {
            int idx = PositionToIndex(pos);
            //Console.WriteLine(pos + " - " + idx);
            return gameGrid[idx].position;
        }

        public void Render(Graphics g) {
            for (int i = 0; i < gridCount; i++) {
                g.DrawRectangle(new Pen(Color.Yellow), new Rectangle((int)gameGrid[i].position.x, (int)gameGrid[i].position.y, Grid.GridWidth, Grid.GridHeight));
            }
        }

        public void RegisterEntity(BaseEntity entity) {
            if (entity == null)
                return;

            int idx = PositionToIndex(entity.position);

            gameGrid[idx].entityList.Add(entity);
        }

        public void UpdateEntity(BaseEntity entity, Vector2D oldPos) {
            int newIdx = PositionToIndex(entity.position), oldIdx = PositionToIndex(oldPos);

            if (newIdx == oldIdx)
                return;

            gameGrid[oldIdx].entityList.Remove(entity);
            gameGrid[newIdx].entityList.Add(entity);
        }

        public void EmptyCells() {
            foreach (Grid g in gameGrid)
                g.entityList.Clear();
        }

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
