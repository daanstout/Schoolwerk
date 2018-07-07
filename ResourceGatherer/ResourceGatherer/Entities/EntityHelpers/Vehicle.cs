using ResourceGatherer.Util;
using ResourceGatherer.Util.SteeringBehaviours;
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
        public MovingEntity parent;

        private List<ISteering> steeringFactors;

        public ISteering addSteeringFactor {
            set {
                if (!steeringFactors.Contains(value))
                    steeringFactors.Add(value);
            }
        }

        /// <summary>
        /// The constructor of the vehicle class
        /// </summary>
        /// <param name="parent">The parent entity</param>
        public Vehicle(MovingEntity parent) {
            this.parent = parent;

            steeringFactors = new List<ISteering>();
        }

        /// <summary>
        /// The Update funcion moves the entity along their path
        /// </summary>
        /// <param name="time_elapsed">The time since the last update</param>
        public void Update(float time_elapsed) {
            if (parent.path.Count > 0) {
                if (parent.position.Distance(parent.path.current) < 1)
                    if (!parent.path.GoNext())
                        return;

                Vector2D target = Vector2D.Zero;

                foreach (ISteering force in steeringFactors) {
                    target += force.ApplySteering(this);
                    if (target.Length() >= parent.maxForce)
                        break;
                }

                target += parent.position;

                if (parent.RotateHeadingToFacePosition(target)) {
                    parent.oldPos = parent.position;
                    parent.position += parent.heading * parent.maxSpeed * time_elapsed;
                }
            }
        }
    }
}
