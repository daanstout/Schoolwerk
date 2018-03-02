﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceGatherer.Util;

namespace ResourceGatherer.Entities.MovingEntities {
    public class FriendlyNPC : MovingEntity {
        public FriendlyNPC(Vector2D pos, float rad, Vector2D vel, float maxSpd, Vector2D heading, float mass, Vector2D scale, float turnRate, float maxForce) : base(pos, rad, vel, maxSpd, heading, mass, scale, turnRate, maxForce) {

        }

        public override void Render(Graphics g) {
            Console.WriteLine("Draw");
            g.FillRectangle(new SolidBrush(Color.Red), new RectangleF(position.x, position.y, scale.x, scale.y));
        }
    }
}