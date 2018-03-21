using ResourceGatherer.Materials;
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
    public class MaterialEntity : StaticEntity {
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
        public MaterialEntity(Entity_Types type, Vector2D pos, int boundRad, int qty) : base(type, pos, boundRad) {
            quantity = qty;
            SetMaterial(type);
        }

        /// <summary>
        /// Sets the sprite of the entity
        /// </summary>
        /// <param name="type">What entity it is</param>
        private void SetMaterial(Entity_Types type) {
            switch (type) {
                case Entity_Types.WOOD:
                    material = Material.WOOD;
                    break;
                case Entity_Types.STONE:
                    material = Material.STONE;
                    break;
            }
            sprite = material.sprite;
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

        /// <summary>
        /// Creates a stack of the material it holds
        /// </summary>
        /// <returns>The newly created stack</returns>
        public MaterialStack GetStack() {
            return new MaterialStack(material, quantity);
        }
    }
}
