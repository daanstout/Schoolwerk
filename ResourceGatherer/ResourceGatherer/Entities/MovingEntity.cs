using ResourceGatherer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Entities {
    public abstract class MovingEntity : BaseEntity {
        public Vector2D velocity;
        public Vector2D heading;
        public Vector2D side { get; protected set; }

        public readonly float mass;
        public float maxSpeed;
        public float maxForce;
        public float maxTurnRate;

        protected MovingEntity(Vector2D pos, float rad, Vector2D vel, float maxSpd, Vector2D heading, float mass, Vector2D scale, float turnRate, float maxForce) : base(0, pos, rad) {
            this.heading = heading;
            velocity = vel;
            this.mass = mass;
            side = this.heading.Perp();
            maxSpeed = maxSpd;
            maxTurnRate = turnRate;
            this.maxForce = maxForce;
            this.scale = scale;
        }

        public bool IsSpeedMaxedOut() {
            return maxSpeed * maxSpeed > velocity.LengthSq();
        }

        public float Speed() {
            return velocity.Length();
        }

        public float SpeedSq() {
            return velocity.LengthSq();
        }

        public void SetHeading(Vector2D newHeading) {
            if (newHeading.LengthSq() - 1 >= 0.00001) {
                heading = newHeading;
                side = heading.Perp();
            }
        }

        public bool RotateHeadingToFacePosition(Vector2D target) {
            Vector2D toTarget = Vector2D.Vec2DNormalize(target - position);

            float angle = (float)Math.Acos(heading.Dot(toTarget));

            if (angle < 0.00001)
                return true;

            if (angle > maxTurnRate)
                angle = maxTurnRate;

            C2DMatrix RotationMatrix = new C2DMatrix();

            RotationMatrix.Rotate(angle * heading.Sign(toTarget));
            RotationMatrix.TransformVector2Ds(ref heading);
            RotationMatrix.TransformVector2Ds(ref velocity);

            side = heading.Perp();

            return false;
        }
    }
}
