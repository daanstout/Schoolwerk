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
    public class Character : Entity{
        public IJumpStrategy jumpStrategy;
        public IMoveStrategy moveStrategy;

        public float characterMass;

        public bool isGrounded {
            get {

            }
        }

        public Character(Vector2 location, Vector2 size, Color color, bool tickable) : base(location, size, color, tickable) {

        }

        public override void onUpdate(long delta) {
            base.onUpdate(delta);
            //moveStrategy.Move(this);
        }
    }
}
