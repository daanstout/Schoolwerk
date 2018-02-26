using ResourceGatherer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Entities {
    public class MovingEntity : BaseEntity {
        protected Vector2D velocity;
        protected Vector2D heading;
        protected Vector2D side;

        protected float mass;
        protected float maxSpeed;
        protected float maxForce;
        protected float maxTurnRate;

        public MovingEntity(Vector2D pos, float rad, Vector2D vel, float maxSpd, Vector2D heading, float mass, Vector2D scale, float turnRate, float maxForce) : base(0, pos, rad) {
            this.heading = heading;
            velocity = vel;
            this.mass = mass;
            side = this.heading.Perp();
            maxSpeed = maxSpd;
            maxTurnRate = turnRate;
            this.maxForce = maxForce;
            this.scale = scale;
        }

        public Vector2D Velocity() {
            return velocity;
        }

        public void SetVelocity(Vector2D newVel) {
            velocity = newVel;
        }

        public float Mass() {
            return mass;
        }

        public Vector2D Side() {
            return side;
        }

        public float MaxSpeed() {
            return maxSpeed;
        }

        public void SetMaxSpeed(float newSpd) {
            maxSpeed = newSpd;
        }

        public double MaxForce() {
            return maxForce;
        }

        public void SetMaxForce(float newForce) {
            maxForce = newForce;
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

        public Vector2D Heading() {
            return heading;
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

        public float MaxTurnRate() {
            return maxTurnRate;
        }

        public void SetMaxTurnRate(float val) {
            maxTurnRate = val;
        }
    }
}
