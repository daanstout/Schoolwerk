using ScrollingGame.Entity;
using ScrollingGame.Entity.Characters;
using ScrollingGame.Entity.Obstacles;
using ScrollingGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Move {
    public abstract class AMove : IMoveStrategy {

        public virtual void Move(Character c) {
            if (c.location.X <= Global.left) {
                c.location.X = Global.left;
            } else if (c.location.X + c.size.X >= Global.right) {
                c.location.X = Global.right - c.size.X;
            }

            if (c.location.Y <= Global.top) {
                c.location.Y = Global.top;
            } else if (c.location.Y + c.size.Y >= Global.bottom) {
                c.location.Y = Global.bottom - c.size.Y;
            }

            if (c.entityFloor != null) {
                if (c.location.X > c.entityFloor.location.X + c.entityFloor.size.X && c.location.X + c.size.X > c.entityFloor.location.X && c.location.Y + c.size.Y >= c.entityFloor.location.Y) {
                    Gravity.GravitationalForce.subscribeToGravity = c;
                } else if (c.location.X < c.entityFloor.location.X + c.entityFloor.size.X && c.location.X + c.size.X < c.entityFloor.location.X && c.location.Y + c.size.Y >= c.entityFloor.location.Y) {
                    Gravity.GravitationalForce.subscribeToGravity = c;
                }
            }

            //foreach (Obstacle o in Singleton.currentLevel.obstacleList) {

            //}
        }
    }
}
