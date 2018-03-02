using ResourceGatherer.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Entities {
    public abstract class BaseEntity {
        public static int default_entity_type = -1;

        public enum Entity_types {
            // STATIC ENTITIES:
            WOOD,
            STONE
        }

        private static int ValidId;
        private static int NextValidId {
            get {
                return ++ValidId;
            }
        }

        public readonly int entityId;
        public int entityType { get; protected set; }
        public bool tag { get; protected set; }

        public Vector2D position;
        public Vector2D scale { get; protected set; }
        public float boundingRadius;
        public Bitmap sprite;

        protected BaseEntity() {
            entityId = NextValidId;
            boundingRadius = 0;
            position = new Vector2D();
            scale = new Vector2D(1, 1);
            entityType = default_entity_type;
            tag = false;
        }

        protected BaseEntity(int type) {
            entityId = NextValidId;
            boundingRadius = 0;
            position = new Vector2D();
            scale = new Vector2D(1, 1);
            entityType = type;
            tag = false;
        }

        protected BaseEntity(int type, Vector2D pos, float boundRad) {
            entityId = NextValidId;
            boundingRadius = boundRad;
            position = pos;
            scale = new Vector2D(1, 1);
            entityType = type;
            tag = false;
        }

        protected BaseEntity(int type, int forcedId) {
            entityId = forcedId;
            boundingRadius = 0;
            position = new Vector2D();
            scale = new Vector2D(1, 1);
            entityType = type;
            tag = false;
        }

        public virtual void Update(float time_elapsed) { }

        public virtual void Render(Graphics g) { }

        public virtual void Write() { }

        public void Tag() {
            tag = true;
        }

        public void UnTag() {
            tag = false;
        }

        public void SetScale(Vector2D val) {
            boundingRadius *= (val.x > val.y ? val.x : val.y) / (scale.x > scale.y ? scale.x : scale.y);
            scale = val;
        }

        public void SetScale(float val) {
            boundingRadius *= val / (scale.x > scale.y ? scale.x : scale.y);
            scale = new Vector2D(val, val);
        }

        public void SetEntityType(int newType) {
            entityType = newType;
        }
    }
}
