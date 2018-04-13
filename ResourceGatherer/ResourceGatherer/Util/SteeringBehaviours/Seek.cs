using ResourceGatherer.Entities.EntityHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Util.SteeringBehaviours {
    public sealed class Seek : ISteering {
        public Vector2D ApplySteering(Vehicle vehicle) {
            Vector2D dir = vehicle.parent.path.current - vehicle.parent.position;
            dir.Normalize();
            return dir;
        }
    }
}
