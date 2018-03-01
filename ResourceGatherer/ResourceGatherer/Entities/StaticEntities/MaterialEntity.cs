using ResourceGatherer.Materials;
using ResourceGatherer.Properties;
using ResourceGatherer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Entities.StaticEntities {
    public class MaterialEntity : StaticEntity{
        public Material material;

        public MaterialEntity(Entity_types type, Vector2D pos, int boundRad, int qty) : base((int)type, pos, boundRad, qty) {
            SetSprite(type);
        }

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
    }
}
