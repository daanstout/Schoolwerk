using ResourceGatherer.Entities;
using ResourceGatherer.Util;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.World.Grids {
    public sealed class Grid {
        /// <summary>
        /// The width of a grid
        /// </summary>
        public static readonly int GridWidth = 100;
        /// <summary>
        /// The height of a grid
        /// </summary>
        public static readonly int GridHeight = 100;

        /// <summary>
        /// The position of the grid
        /// </summary>
        public Vector2D position;

        /// <summary>
        /// A list of all entities in the grid. Do not call this variable! use entityList instead
        /// </summary>
        private List<BaseEntity> _entityList;
        /// <summary>
        /// A list of all entities in the grid
        /// </summary>
        public List<BaseEntity> entityList {
            get {
                if (_entityList == null)
                    _entityList = new List<BaseEntity>();
                return _entityList;
            }
        }

        /// <summary>
        /// The amount of entities in the grid
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
        /// Constructor of the grid
        /// </summary>
        /// <param name="pos">THe position of the grid</param>
        public Grid(Vector2D pos) {
            position = pos;
        }
    }
}
