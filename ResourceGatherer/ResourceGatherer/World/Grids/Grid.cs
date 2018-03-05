using ResourceGatherer.Entities;
using ResourceGatherer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.World.Grids {
    public class Grid {
        public static readonly int GridWidth = 100;
        public static readonly int GridHeight = 100;

        private GameWorld world;

        public Vector2D position;

        private List<BaseEntity> _entityList;
        public List<BaseEntity> entityList {
            get {
                if (_entityList == null)
                    _entityList = new List<BaseEntity>();
                return _entityList;
            }
        }

        public int entityCount {
            get {
                if (_entityList == null)
                    return 0;
                else
                    return _entityList.Count;
            }
        }

        public Grid(GameWorld world, Vector2D pos) {
            this.world = world;
            position = pos;
        }
    }
}
