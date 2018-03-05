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
                gameGrid[i] = new Grid(world, new Vector2D(curX, curY));
                curX += Grid.GridWidth;
                if (curX >= world.gameWidth) {
                    curX = 0;
                    curY += Grid.GridHeight;
                }
            }
        }

        private int PositionToIndex(Vector2D pos) {
            int index = 0, gridsPerRow = Grid.GridWidth / world.gameWidth;

            index += (int)pos.x / Grid.GridWidth;
            index += ((int)pos.y / Grid.GridHeight) * gridsPerRow;

            return index >= gridCount ? gridCount : index;
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
    }
}
