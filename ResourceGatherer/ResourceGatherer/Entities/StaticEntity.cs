using ResourceGatherer.Util;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Entities {
    /// <summary>
    /// A static, non-moving entity
    /// </summary>
    public abstract class StaticEntity : BaseEntity {
        /// <summary>
        /// A simple constructor for the static entity
        /// </summary>
        protected StaticEntity() : base() { }

        /// <summary>
        /// A basic constructor for the static entity
        /// </summary>
        /// <param name="type">The entity type</param>
        /// <param name="pos">The position of the entity</param>
        /// <param name="boundRad">The bounding radius of the entity</param>
        protected StaticEntity(Entity_Types type, Vector2D pos, int boundRad) : base(type, pos, boundRad) { }
    }
}
