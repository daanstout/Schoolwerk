using ResourceGatherer.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Entities.EntityHelpers {
    public class Vehicle {
        private MovingEntity parent;

        public Vehicle(MovingEntity parent) {
            this.parent = parent;
        }

        public void Update(float time_elapsed) {
            if(parent.path.Count > 0) {
                if(parent.position.Distance(parent.path.current) < 1) {
                    if (!parent.path.GoNext())
                        return;
                }
                if (parent.RotateHeadingToFacePosition(parent.path.current)) {
                    parent.position += parent.heading * parent.maxSpeed * time_elapsed;
                }
            }
        }
    }
}
