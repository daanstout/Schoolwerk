using ResourceGatherer.Entities.EntityHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Util.SteeringBehaviours{
    public interface ISteering {
        Vector2D ApplySteering(Vehicle vehicle);
    }
}
