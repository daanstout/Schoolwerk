using ScrollingGame.Entity;
using ScrollingGame.Entity.Characters;
using ScrollingGame.Entity.Obstacles;
using ScrollingGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Gravity {
    public static class Gravity {
        private static List<EntityBase> _gravityList;

        public static List<EntityBase> gravityList {
            get {
                if (_gravityList == null)
                    _gravityList = new List<EntityBase>();
                return _gravityList;
            }
        }

        public static EntityBase subscribeToGravity {
            set {
                if (!gravityList.Contains(value))
                    gravityList.Add(value);
            }
        }

        public static EntityBase unsubscribeFromGravity {
            set {
                if (gravityList.Contains(value))
                    gravityList.Remove(value);
            }
        }

        public static void EnactGravity() {
            List<EntityBase> toUnsubscribe = new List<EntityBase>();
            foreach(EntityBase e in gravityList) {
                e.fallSpeed += e.entityMass * Singleton.gameGravity * Time.deltaTimeSeconds;
                foreach(Obstacle o in Singleton.currentLevel.obstacleList) {
                    if(e.location.Y + e.size.Y > o.location.Y && e.location.X + e.size.X > o.location.X && e.location.X < o.location.X + o.size.X && e.location.Y < o.location.Y + o.size.Y) {
                        e.fallSpeed = 0;
                        e.location.Y = o.location.Y - e.size.Y;
                        toUnsubscribe.Add(e);
                    }
                }
                //if(e.location.Y + e.size.Y > 500) {
                //    e.fallSpeed = 0;
                //    e.location.Y = 500 - e.size.Y;
                //    toUnsubscribe.Add(e);
                //}
            }
            foreach(EntityBase e in toUnsubscribe) {
                unsubscribeFromGravity = e;
            }
        }
    }
}
