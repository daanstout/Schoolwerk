using ResourceGatherer.Entities.EntityHelpers;
using ResourceGatherer.States;
using ResourceGatherer.Util;
using ResourceGatherer.World;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Entities {
    /// <summary>
    /// The moving entity class
    /// </summary>
    public abstract class MovingEntity : BaseEntity {
        /// <summary>
        /// The current velocity
        /// </summary>
        public Vector2D velocity;
        /// <summary>
        /// The current heading
        /// </summary>
        public Vector2D heading;
        /// <summary>
        /// The left side
        /// </summary>
        public Vector2D side { get; protected set; }

        /// <summary>
        /// The current path this entity follows
        /// </summary>
        public Path path;
        /// <summary>
        /// The vehicle the entity uses to move across the path
        /// </summary>
        public Vehicle vehicle;

        /// <summary>
        /// The mass of the entity
        /// </summary>
        public readonly float mass;
        /// <summary>
        /// The max speed of the entity
        /// </summary>
        public float maxSpeed;
        /// <summary>
        /// the max force the entity can endure
        /// </summary>
        public float maxForce;
        /// <summary>
        /// The max turn rate of the entity
        /// </summary>
        public float maxTurnRate;

        /// <summary>
        /// The position of this entity in the previous update
        /// </summary>
        public Vector2D oldPos;

        /// <summary>
        /// The current state of the entity
        /// </summary>
        public StateMachine state;

        /// <summary>
        /// The constructor for the entity
        /// </summary>
        /// <param name="pos">The position of the entity</param>
        /// <param name="rad">The bounding radius of the entity</param>
        /// <param name="vel">The velocity of the entity</param>
        /// <param name="maxSpd">The max speed of the entity</param>
        /// <param name="heading">The current heading of the entity</param>
        /// <param name="mass">The mass of the entity</param>
        /// <param name="scale">The scale of the entity</param>
        /// <param name="turnRate">The turn rate of the entity</param>
        /// <param name="maxForce">The max force the entity can endure</param>
        protected MovingEntity(Vector2D pos, float rad, Vector2D vel, float maxSpd, Vector2D heading, float mass, Vector2D scale, float turnRate, float maxForce) : base(0, pos, rad) {
            this.heading = heading;
            velocity = vel;
            this.mass = mass;
            side = this.heading.Perp();
            maxSpeed = maxSpd;
            maxTurnRate = turnRate;
            this.maxForce = maxForce;
            this.scale = scale;
            vehicle = new Vehicle(this);
            path = new Path();
            state = new StateMachine(this);

            currentGrid = GameWorld.instance.grid.RegisterEntity(this);
        }

        /// <summary>
        /// Updates the entity
        /// </summary>
        /// <param name="time_elapsed">The time since the last update</param>
        public override void Update(float time_elapsed) {
            vehicle.Update(time_elapsed);

            currentGrid = GameWorld.instance.grid.UpdateEntity(this, oldPos);
        }

        /// <summary>
        /// Checks wheter the speed is currently maxed out
        /// </summary>
        /// <returns>True if this is the case</returns>
        public bool IsSpeedMaxedOut() {
            return maxSpeed * maxSpeed > velocity.LengthSq();
        }

        /// <summary>
        /// The current speed of the entity
        /// </summary>
        /// <returns>The speed of the entity</returns>
        public float Speed() {
            return velocity.Length();
        }

        /// <summary>
        /// The speed of the entity without squaring it
        /// </summary>
        /// <returns>The unsquared speed of the entity</returns>
        public float SpeedSq() {
            return velocity.LengthSq();
        }

        /// <summary>
        /// Sets the heading of the entity
        /// </summary>
        /// <param name="newHeading">The new heading</param>
        public void SetHeading(Vector2D newHeading) {
            if (newHeading.LengthSq() - 1 >= 0.00001) {
                heading = newHeading;
                side = heading.Perp();
            }
        }

        /// <summary>
        /// Rotates the entity to a target direction
        /// </summary>
        /// <param name="target">The target to be rotated to</param>
        /// <returns>Returns true of it faces the target</returns>
        public bool RotateHeadingToFacePosition(Vector2D target) {
            Vector2D toTarget = Vector2D.Vec2DNormalize(target - position);

            float angle = (float)Math.Acos(heading.Dot(toTarget));

            if (angle < 0.1)
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

        /// <summary>
        /// Creates Debug Info
        /// </summary>
        /// <returns>A string with the important information</returns>
        public override string GetDebug() {
            return String.Format("{0}\nMass: {1}", base.GetDebug(), mass);
        }
    }
}
