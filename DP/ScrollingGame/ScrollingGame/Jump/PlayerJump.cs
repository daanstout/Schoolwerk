using ScrollingGame.Entity.Characters;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Jump {
    public class PlayerJump : AJump{
        private static float jumpStrength = 2;

        public override void Jump(Character c) {
            if (c.fallSpeed != 0)
                return;
            c.fallSpeed -= jumpStrength;
            Gravity.Gravity.subscribeToGravity = c;
        }
    }
}
