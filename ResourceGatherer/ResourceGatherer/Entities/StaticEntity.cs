using ResourceGatherer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Entities {
    public abstract class StaticEntity : BaseEntity {
        public int quantity { get; protected set; }

        protected StaticEntity() : base() { }

        protected StaticEntity(int type, Vector2D pos, int boundRad, int qty) : base(type, pos, boundRad) {
            quantity = qty;
        }

        public void Increase() {
            quantity++;
        }

        public void Increase(int amount) {
            quantity += amount;
        }

        public void Decrease() {
            quantity--;
        }

        public void Decrease(int amount) {
            quantity -= amount;
        }
    }
}
