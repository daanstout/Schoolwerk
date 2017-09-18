using ScrollingGame.Entity.Characters;
using ScrollingGame.Gravity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Jump {
    public class TripleJump : AJump{
        private static float jumpStrength = 2;
        public UInt16 tripleJump = 0;

        public override void Jump(Character c) {
            if (c.entityFloor == null) {
                if (tripleJump >= 3) {
                    return;
                }
            }
            tripleJump++;
            c.entityFloor = null;
            c.fallSpeed = -jumpStrength;
            base.Jump(c);
        }
    }
}
