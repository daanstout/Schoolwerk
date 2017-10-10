using ScrollingGame.Utils;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Entity.Projectiles {
    public abstract class AProjectile : ABehaviour, IProjectile {
        public Vector2 direction;
        public float movementSpeed;
        public Vector2 location;
        public Vector2 size;
        public Color color;

        public AProjectile(Vector2 direction, float movementSpeed, Vector2 location, Vector2 size, Color color, bool doTick, bool doDraw) {
            this.direction = direction;
            this.movementSpeed = movementSpeed;
            this.location = location;
            this.size = size;
            this.color = color;
            this.doTick = doTick;
            this.doDraw = doDraw;
        }
    }
}
