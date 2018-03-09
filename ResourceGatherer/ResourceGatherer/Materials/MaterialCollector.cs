using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Materials {
    public class MaterialCollector {
        public List<MaterialStack> collection { get; private set; }

        public MaterialCollector() {
            collection = new List<MaterialStack>();
        }

        /// <summary>
        /// Adds materials to the collection
        /// </summary>
        /// <param name="mat">The material to be added</param>
        /// <param name="count">The amount to be added</param>
        public void AddMaterial(Material mat, int count) {
            foreach(MaterialStack stack in collection) {
                if(stack.material.id == mat.id) {
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
        /// <returns>Returns -1 if there wasn't enough, 0 if the material wasn't present and 1 if there was enough</returns>
        public int RemoveMaterial(Material mat, int count) {
            foreach(MaterialStack stack in collection) {
                if(stack.material.id == mat.id) {
                    stack.count -= count;
                    if (stack.count < 0)
                        return -1;
                    else
                        return 1;
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
            foreach(MaterialStack stack in collection) {
                if (stack.material.id == mat.id)
                    return stack.count;
            }
            return 0;
        }
    }
}
