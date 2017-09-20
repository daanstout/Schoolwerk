using ScrollingGame.Gravity;
using ScrollingGame.Jump;
using ScrollingGame.Move;
using ScrollingGame.Utils;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Entity.Characters {
    public class Jumper : Character{

        public Jumper(Vector2 location, Vector2 size, Color color, bool tickable) : base(location, size, color, tickable) { }

        public override void onLoad() {
            base.onLoad();
            moveStrategy = new ConstJumpMove();
            jumpStrategy = new SimpleJump();
            entityMass = 1.5f;
        }

        public override void onUpdate() {
            base.onUpdate();
            moveStrategy.Move(this);
        }
    }
}
