using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Materials {
    public class Material {
        // STATIC MATERIALS
        public static Material WOOD = new Material(Materials.WOOD.ToString());
        public static Material STONE = new Material(Materials.STONE.ToString());

        private enum Materials {
            WOOD,
            STONE
        }

        private static int ID;
        private static int NextValidID {
            get {
                return ++ID;
            }
        }

        public static Material IDToMaterial(int ID) {
            switch (ID) {
                case 1:
                    return WOOD;
                case 2:
                    return STONE;
                default:
                    return null;
            }
        }

        public string name;
        public readonly int id;

        private Material() : this("") {

        }

        private Material(string name) {
            this.name = name;
            id = NextValidID;
        }

        public override bool Equals(object obj) {
            var material = obj as Material;
            return material != null &&
                   id == material.id;
        }

        public override int GetHashCode() {
            return 1877310944 + id.GetHashCode();
        }
    }
}
