using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceGatherer.Util;
using ResourceGatherer.World;

namespace ResourceGatherer.Entities.MovingEntities {
    public class FriendlyNPC : MovingEntity {
        public FriendlyNPC(Vector2D pos, float rad, Vector2D vel, float maxSpd, Vector2D heading, float mass, Vector2D scale, float turnRate, float maxForce) : base(pos, rad, vel, maxSpd, heading, mass, scale, turnRate, maxForce) {
            path = new Path();
        }

        public override void Update(float time_elapsed) {
            base.Update(time_elapsed);
            //position += new Vector2D(maxSpeed * time_elapsed, 0);
            //position.WrapAround(GameWorld.instance.gameWidth, GameWorld.instance.gameHeight);
        }

        public override void Render(Graphics g) {
            g.FillRectangle(new SolidBrush(Color.Red), new RectangleF(position - (scale / 2), scale));
            try {
                g.DrawLine(new Pen(Color.Black), position, position + heading * 20);
            } catch {

            }
        }
    }
}
