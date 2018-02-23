using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Entities {
    public class BaseEntity {
        public static int default_entity_type = -1;

        private static int ValidId;
        private static int NextValidId {
            get {
                return ++ValidId;
            }
        }

        private int entityId;
        private int entityType;
        private bool tag;

        public BaseEntity(int type) {
            entityId = NextValidId;
            entityType = type;
        }

        public int GetId() {
            return entityId;
        }
    }
}
