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
    public class Material {
        // STATIC MATERIALS
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

        /// <summary>
        /// Translates an ID to a material
        /// </summary>
        /// <param name="ID">The ID of the material</param>
        /// <returns>Returns the material with the given ID</returns>
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

        /// <summary>
        /// The name of the material
        /// </summary>
        public readonly string name;
        /// <summary>
        /// The ID of the material
        /// </summary>
        public readonly int id;

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

        /// <summary>
        /// Checks whether the 2 materials are equal
        /// </summary>
        /// <param name="obj">The other material</param>
        /// <returns>True of they are equal</returns>
        public override bool Equals(object obj) {
            var material = obj as Material;
            return material != null &&
                   id == material.id;
        }

        /// <summary>
        /// Gets a hashcode for the material
        /// </summary>
        /// <returns>The hashcode</returns>
        public override int GetHashCode() {
            return 1877310944 + id.GetHashCode();
        }
    }
}
