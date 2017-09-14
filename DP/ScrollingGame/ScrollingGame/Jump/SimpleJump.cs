using ScrollingGame.Entity.Characters;
using ScrollingGame.Gravity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Jump {
    public class SimpleJump : AJump{
        private static float jumpStrength = 2;

        public override void Jump(Character c) {
            if (c.fallSpeed != 0)
                return;
            c.fallSpeed -= jumpStrength;
            GravitationalForce.subscribeToGravity = c;
        }
    }
}
