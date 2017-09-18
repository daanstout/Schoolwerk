using ScrollingGame.Entity.Obstacles;
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
    public class Character : EntityBase{
        public IJumpStrategy jumpStrategy;
        public IMoveStrategy moveStrategy;

        public float characterMovement;

        public Character(Vector2 location, Vector2 size, Color color, bool tickable) : base(location, size, color, tickable) {

        }

        public override void onUpdate() {
            base.onUpdate();
            //moveStrategy.Move(this);
        }
    }
}
