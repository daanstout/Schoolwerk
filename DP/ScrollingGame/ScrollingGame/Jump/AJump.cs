using ScrollingGame.Entity;
using ScrollingGame.Entity.Characters;
using ScrollingGame.Gravity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Jump {
    public abstract class AJump : ABehaviour, IJumpStrategy {
        public bool isJumping;

        public virtual void Jump(Character c) {
            GravitationalForce.subscribeToGravity = c;
        }
    }
}
