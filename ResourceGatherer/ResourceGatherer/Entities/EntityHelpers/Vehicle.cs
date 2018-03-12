using ResourceGatherer.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Entities.EntityHelpers {
    /// <summary>
    /// A vehicle class that can be used by moving entities as helpers
    /// </summary>
    public class Vehicle {
        /// <summary>
        /// The parent entity
        /// </summary>
        private MovingEntity parent;

        /// <summary>
        /// The constructor of the vehicle class
        /// </summary>
        /// <param name="parent">The parent entity</param>
        public Vehicle(MovingEntity parent) {
            this.parent = parent;
        }

        /// <summary>
        /// The Update funcion moves the entity along their path
        /// </summary>
        /// <param name="time_elapsed">The time since the last update</param>
        public void Update(float time_elapsed) {
            if(parent.path.Count > 0) {
                if (parent.position.Distance(parent.path.current) < 1) {
                    if (!parent.path.GoNext())
                        return;
                }
                if (parent.RotateHeadingToFacePosition(parent.path.current)) {
                    parent.oldPos = parent.position;
                    parent.position += parent.heading * parent.maxSpeed * time_elapsed;
                }
            }
        }
    }
}
