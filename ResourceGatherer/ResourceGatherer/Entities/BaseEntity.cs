using ResourceGatherer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Entities {
    public abstract class BaseEntity {
        public static int default_entity_type = -1;

        private static int ValidId;
        private static int NextValidId {
            get {
                return ++ValidId;
            }
        }

        private int entityId;
        private int entityType;
        private bool tag;

        protected Vector2D position;
        protected Vector2D scale;
        protected float boundingRadius;

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

        public virtual void Update(double time_elapsed) { }

        public virtual void Render() { }

        public virtual void Write() { }

        public Vector2D Position() {
            return position;
        }

        public void SetPosition(Vector2D newPos) {
            position = newPos;
        }

        public float BoundingRadius() {
            return boundingRadius;
        }

        public void SetBoundingRadius(float r) {
            boundingRadius = r;
        }

        public int Id() {
            return entityId;
        }

        public bool isTagged() {
            return tag;
        }

        public void Tag() {
            tag = true;
        }

        public void UnTag() {
            tag = false;
        }

        public Vector2D Scale() {
            return scale;
        }

        public void SetScale(Vector2D val) {
            boundingRadius *= (val.x > val.y ? val.x : val.y) / (scale.x > scale.y ? scale.x : scale.y);
            scale = val;
        }

        public void SetScale(float val) {
            boundingRadius *= val / (scale.x > scale.y ? scale.x : scale.y);
            scale = new Vector2D(val, val);
        }

        public int EntityType() {
            return entityType;
        }

        public void SetEntityType(int newType) {
            entityType = newType;
        }
    }
}
