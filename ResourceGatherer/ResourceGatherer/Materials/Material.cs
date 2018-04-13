using ResourceGatherer.Properties;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Materials {
    /// <summary>
    /// Materials class
    /// </summary>
    public sealed class Material {
        // STATIC MATERIALS
        /// <summary>
        /// Instance of the NULL material. this material counts as all materials and will always return true when compared to another material
        /// </summary>
        public static Material NULLMATERIAL = new Material(Materials.NULL.ToString(), null, 0);
        /// <summary>
        /// Instance of the WOOD material
        /// </summary>
        public static Material WOOD = new Material(Materials.WOOD.ToString(), Resources.Wood_01);
        /// <summary>
        /// Instance of the STONE material
        /// </summary>
        public static Material STONE = new Material(Materials.STONE.ToString(), Resources.Stone_01);

        /// <summary>
        /// An enum of all the materials
        /// </summary>
        private enum Materials {
            NULL = 0,
            WOOD,
            STONE
        }

        /// <summary>
        /// The last given valid id
        /// </summary>
        private static int ID;
        /// <summary>
        /// Gets the next valid id
        /// </summary>
        private static int NextValidID {
            get {
                return ++ID;
            }
        }

        private static Material[] materialList = new Material[3] { NULLMATERIAL, WOOD, STONE };

        /// <summary>
        /// Translates an ID to a material
        /// </summary>
        /// <param name="ID">The ID of the material</param>
        /// <returns>Returns the material with the given ID</returns>
        public static Material IDToMaterial(int ID) {
            return materialList[ID];
        }

        /// <summary>
        /// The name of the material
        /// </summary>
        public readonly string name;
        /// <summary>
        /// The ID of the material
        /// </summary>
        public readonly int id;

        /// <summary>
        /// The material sprite
        /// </summary>
        public readonly Bitmap sprite;

        /// <summary>
        /// The constructor of the material
        /// </summary>
        /// <param name="name">The name of the material</param>
        private Material(string name, Bitmap sprite) {
            this.name = name;
            id = NextValidID;
            this.sprite = sprite;
        }

        private Material(string name, Bitmap sprite, int forcedId) {
            this.name = name;
            id = forcedId;
            this.sprite = sprite;
        }

        /// <summary>
        /// Checks whether the 2 materials are equal
        /// </summary>
        /// <param name="obj">The other material</param>
        /// <returns>True of they are equal</returns>
        public override bool Equals(object obj) {
            var material = obj as Material;
            if (material == null)
                return false;
            else if (material.id == 0 || id == 0)
                return true;
            else
                return id == material.id;
        }

        /// <summary>
        /// Gets a hashcode for the material
        /// </summary>
        /// <returns>The hashcode</returns>
        public override int GetHashCode() {
            return 1877310944 + id.GetHashCode();
        }

        /// <summary>
        /// Overrides the ToString Function
        /// </summary>
        /// <returns>The material name</returns>
        public override string ToString() {
            return name;
        }
    }
}
