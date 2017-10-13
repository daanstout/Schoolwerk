using ScrollingGame.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Scrolling {
    public class FieldPart {
        private List<IBehaviour> _entityList;

        //public readonly float partPosition

        public List<IBehaviour> entityList {
            get {
                if (_entityList == null)
                    _entityList = new List<IBehaviour>();
                return _entityList;
            }
        }

        public IBehaviour addEntity {
            set {
                if (!entityList.Contains(value)) {

                    entityList.Add(value);
                }
            }
        }

        public IBehaviour removeEntity {
            set {
                if (entityList.Contains(value))
                    entityList.Remove(value);
            }
        }
    }
}
