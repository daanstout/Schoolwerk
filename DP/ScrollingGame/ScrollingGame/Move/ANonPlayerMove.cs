using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScrollingGame.Entity.Characters;

namespace ScrollingGame.Move {
    public abstract class ANonPlayerMove : IMoveStrategy {
        public virtual void Move(Character c) {
            if (c.entityFloor != null) {
                if (c.location.X > c.entityFloor.location.X + c.entityFloor.size.X && c.location.X + c.size.X > c.entityFloor.location.X && c.location.Y + c.size.Y >= c.entityFloor.location.Y) {
                    Gravity.GravitationalForce.subscribeToGravity = c;
                } else if (c.location.X < c.entityFloor.location.X + c.entityFloor.size.X && c.location.X + c.size.X < c.entityFloor.location.X && c.location.Y + c.size.Y >= c.entityFloor.location.Y) {
                    Gravity.GravitationalForce.subscribeToGravity = c;
                }
            }
        }
    }
}
