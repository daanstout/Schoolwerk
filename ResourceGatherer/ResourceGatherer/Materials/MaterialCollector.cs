using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Materials {
    public class MaterialCollector {
        /// <summary>
        /// A list of all the materials in the collection
        /// </summary>
        public List<MaterialStack> collection { get; private set; }

        /// <summary>
        /// The constructor. It initializes the list
        /// </summary>
        public MaterialCollector() {
            collection = new List<MaterialStack>();
        }

        public MaterialCollector(bool autoFill) : this(){
            if (autoFill) {
                collection.Add(new MaterialStack(Material.WOOD, 0));
                collection.Add(new MaterialStack(Material.STONE, 0));
            }
        }

        /// <summary>
        /// Adds materials to the collection
        /// </summary>
        /// <param name="mat">The material to be added</param>
        /// <param name="count">The amount to be added</param>
        public void AddMaterial(Material mat, int count) {
            foreach (MaterialStack stack in collection) {
                if (stack.material.id == mat.id) {
                    stack.count += count;
                    return;
                }
            }
            collection.Add(new MaterialStack(mat, count));
        }

        /// <summary>
        /// Removes materials from the collection
        /// </summary>
        /// <param name="mat">The material to be removed</param>
        /// <param name="count">The amount to be removed</param>
        /// <returns>Returns -1 if there wasn't enough, 0 if the material wasn't present and the stack count if there was enough</returns>
        public int RemoveMaterial(Material mat, int count) {
            foreach (MaterialStack stack in collection) {
                if (stack.material.id == mat.id) {
                    stack.count -= count;
                    if (stack.count < 0)
                        return -1;
                    else
                        return stack.count;
                }
            }
            return 0;
        }

        /// <summary>
        /// Gets how much a material is in the collectino
        /// </summary>
        /// <param name="mat">The material requested</param>
        /// <returns>The amount the material is present</returns>
        public int GetCount(Material mat) {
            foreach (MaterialStack stack in collection)
                if (stack.material.id == mat.id)
                    return stack.count;
            return 0;
        }

        /// <summary>
        /// Checks if the material is in the stack
        /// </summary>
        /// <param name="mat">The material to be checked for</param>
        /// <returns>True if the material is in the stack</returns>
        public bool HasMaterial(Material mat) {
            foreach (MaterialStack stack in collection)
                if (stack.material.id == mat.id)
                    return true;
            return false;
        }
    }
}
