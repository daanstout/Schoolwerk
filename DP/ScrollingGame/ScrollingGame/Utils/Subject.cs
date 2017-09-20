using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Utils {
    public abstract class Subject {
        private List<IObserver> _observerList;

        private List<IObserver> observerList {
            get {
                if (_observerList == null)
                    _observerList = new List<IObserver>();
                return _observerList;
            }
        }

        public IObserver attach {
            set {
                if (!observerList.Contains(value))
                    observerList.Add(value);
            }
        }

        public IObserver detach {
            set {
                if (observerList.Contains(value))
                    observerList.Remove(value);
            }
        }

        public void Notify() {
            foreach (IObserver o in observerList)
                o.Update();
        }
    }
}
