using ResourceGatherer.Materials;
using ResourceGatherer.Properties;
using ResourceGatherer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Entities.StaticEntities {
    /// <summary>
    /// An static entity that has a material
    /// </summary>
    public class MaterialEntity : StaticEntity{
        /// <summary>
        /// The material this entity represents
        /// </summary>
        public Material material;

        /// <summary>
        /// The amount of the material the entity contains
        /// </summary>
        public int quantity { get; protected set; }

        /// <summary>
        /// The constructor for this entity
        /// </summary>
        /// <param name="type">The type of entity, can be found in the enumeration</param>
        /// <param name="pos">The position of the entity</param>
        /// <param name="boundRad">The bounding radius of the entity</param>
        /// <param name="qty">The amount of the material the entity has</param>
        public MaterialEntity(Entity_types type, Vector2D pos, int boundRad, int qty) : base((int)type, pos, boundRad) {
            quantity = qty;
            SetSprite(type);
        }

        /// <summary>
        /// Sets the sprite of the entity
        /// </summary>
        /// <param name="type">What entity it is</param>
        private void SetSprite(Entity_types type) {
            switch (type) {
                case Entity_types.WOOD:
                    material = Material.WOOD;
                    sprite = Resources.Wood_01;
                    break;
                case Entity_types.STONE:
                    material = Material.STONE;
                    sprite = Resources.Stone_01;
                    break;
            }
        }

        /// <summary>
        /// Increases the quantity by 1
        /// </summary>
        public void Increase() {
            quantity++;
        }

        /// <summary>
        /// Increases the quantity
        /// </summary>
        /// <param name="amount">The amount to be increased by</param>
        public void Increase(int amount) {
            quantity += amount;
        }

        /// <summary>
        /// Decreases the quantity by 1
        /// </summary>
        public void Decrease() {
            quantity--;
        }

        /// <summary>
        /// Decreases the quantity
        /// </summary>
        /// <param name="amount">The amount to be decreased by</param>
        public void Decrease(int amount) {
            quantity -= amount;
        }
    }
}
