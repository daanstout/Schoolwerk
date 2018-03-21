using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Materials {
    /// <summary>
    /// A stack of a material, makes for easier counting
    /// </summary>
    public sealed class MaterialStack {
        /// <summary>
        /// The material in this stack
        /// </summary>
        public Material material;
        /// <summary>
        /// The amount the material is in a stack
        /// </summary>
        public int count;

        /// <summary>
        /// Constructor with a material with a count of 0
        /// </summary>
        /// <param name="mat">The material</param>
        public MaterialStack(Material mat) : this(mat, 0) { }

        /// <summary>
        /// Full constructor that allows the user to both select the material and input an amount
        /// </summary>
        /// <param name="mat">The material</param>
        /// <param name="count">The amount</param>
        public MaterialStack(Material mat, int count) {
            material = mat;
            this.count = count;
        }

        /// <summary>
        /// Overrides the ToString function
        /// </summary>
        /// <returns>The material with the count</returns>
        public override string ToString() {
            return String.Format("{0}: {1}", material, count);
        }
    }
}
