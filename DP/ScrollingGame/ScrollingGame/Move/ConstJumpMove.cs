using ScrollingGame.Entity.Characters;
using ScrollingGame.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Move {
    public class ConstJumpMove : ANonFixedScreenMove{
        public override void Move(Character c) {
            base.Move(c);
            c.location.Y += c.characterMovement * Time.deltaTimeSeconds + c.fallSpeed;
            c.jumpStrategy.Jump(c);
        }
    }
}
