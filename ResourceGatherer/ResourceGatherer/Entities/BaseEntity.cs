using ResourceGatherer.Util;
using ResourceGatherer.World.Grids;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Entities {
    /// <summary>
    /// The base entity class
    /// </summary>
    public abstract class BaseEntity {
        /// <summary>
        /// The default entity type, used if none is given
        /// </summary>
        public static readonly Entity_Types default_entity_type = Entity_Types.default_entity_type;

        /// <summary>
        /// An enumeration of all entity types
        /// </summary>
        public enum Entity_Types {
            default_entity_type = -1,
            
            // STATIC ENTITIES:
            WOOD,
            STONE,

            // Moving Entities
            GATHERER
        }

        /// <summary>
        /// The last given valid id
        /// </summary>
        private static int validId;
        /// <summary>
        /// Gets the next valid id
        /// </summary>
        private static int nextValidId {
            get {
                return ++validId;
            }
        }

        /// <summary>
        /// The entity ID
        /// </summary>
        public readonly int entityId;
        /// <summary>
        /// The entity type
        /// </summary>
        public Entity_Types entityType { get; protected set; }
        /// <summary>
        /// Whether the entity is tagged
        /// </summary>
        public bool tag { get; protected set; }

        /// <summary>
        /// The position of the entity
        /// </summary>
        public Vector2D position;
        /// <summary>
        /// The scale of the entity
        /// </summary>
        public Vector2D scale { get; protected set; }
        /// <summary>
        /// The bounding radius of the entity
        /// </summary>
        public float boundingRadius;
        /// <summary>
        /// The sprite of the entity
        /// </summary>
        public Bitmap sprite;

        /// <summary>
        /// The index of the grid the entity currently resides in
        /// </summary>
        public int currentGrid;

        /// <summary>
        /// A basic constructor for the base entity
        /// </summary>
        protected BaseEntity() {
            entityId = nextValidId;
            boundingRadius = 0;
            position = new Vector2D();
            scale = new Vector2D(1, 1);
            entityType = default_entity_type;
            tag = false;
        }

        /// <summary>
        /// A basic constructor that asks for the entity type
        /// </summary>
        /// <param name="type">The type of the entity</param>
        protected BaseEntity(Entity_Types type) {
            entityId = nextValidId;
            boundingRadius = 0;
            position = new Vector2D();
            scale = new Vector2D(1, 1);
            entityType = type;
            tag = false;
        }

        /// <summary>
        /// A constructor for the entity
        /// </summary>
        /// <param name="type">THe type of the entity</param>
        /// <param name="pos">The positino of the entity</param>
        /// <param name="boundRad">The bounding radius of the entity</param>
        protected BaseEntity(Entity_Types type, Vector2D pos, float boundRad) {
            entityId = nextValidId;
            boundingRadius = boundRad;
            position = pos;
            scale = new Vector2D(1, 1);
            entityType = type;
            tag = false;
        }

        /// <summary>
        /// A constructor that can force an id upon an entity
        /// </summary>
        /// <param name="type">The type of the entity</param>
        /// <param name="forcedId">The id this entity has to use</param>
        protected BaseEntity(Entity_Types type, int forcedId) {
            entityId = forcedId;
            boundingRadius = 0;
            position = new Vector2D();
            scale = new Vector2D(1, 1);
            entityType = type;
            tag = false;
        }

        /// <summary>
        /// Updates the entity
        /// </summary>
        /// <param name="time_elapsed">The time since the last update</param>
        public virtual void Update(float time_elapsed) { }

        /// <summary>
        /// Draws the entity
        /// </summary>
        /// <param name="g">An instance of the graphics</param>
        public virtual void Render(Graphics g) { }

        /// <summary>
        /// Allows the entity to write something, currently unused
        /// </summary>
        public virtual void Write() { }

        /// <summary>
        /// Creates Debug Info
        /// </summary>
        /// <returns>A string with the important information</returns>
        public virtual string GetDebug() {
            return String.Format("ID: {0}\nTypeID: {1}", entityId, entityType);
        }

        /// <summary>
        /// Tags the entity
        /// </summary>
        public void Tag() {
            tag = true;
        }

        /// <summary>
        /// Untags the entity
        /// </summary>
        public void UnTag() {
            tag = false;
        }

        /// <summary>
        /// Sets the scale of the entity, also increasing the bounding radius
        /// </summary>
        /// <param name="val">The new value</param>
        public void SetScale(Vector2D val) {
            boundingRadius *= (val.x > val.y ? val.x : val.y) / (scale.x > scale.y ? scale.x : scale.y);
            scale = val;
        }

        /// <summary>
        /// Sets the scale of the entity, also increasing the bounding radius
        /// </summary>
        /// <param name="val">The new value</param>
        public void SetScale(float val) {
            boundingRadius *= val / (scale.x > scale.y ? scale.x : scale.y);
            scale = new Vector2D(val, val);
        }

        /// <summary>
        /// Sets the entity type
        /// </summary>
        /// <param name="newType">The new type of the entity</param>
        public void SetEntityType(Entity_Types newType) {
            entityType = newType;
        }
    }
}
