using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Materials {
    public sealed class MaterialCollector {
        /// <summary>
        /// A list of all the materials in the collection
        /// </summary>
        public List<MaterialStack> collection { get; private set; }

        /// <summary>
        /// The total count of all the materials in the collection
        /// </summary>
        public int totalCount {
            get {
                int count = 0;
                foreach (MaterialStack m in collection)
                    count += m.count;
                return count;
            }
        }

        /// <summary>
        /// The constructor. It initializes the list
        /// </summary>
        public MaterialCollector() {
            collection = new List<MaterialStack>();
        }

        /// <summary>
        /// Constructs a new set and autofills it with every material
        /// </summary>
        /// <param name="autoFill">Whether it should autofill the set as well, If this is false, just use the simple constructor</param>
        public MaterialCollector(bool autoFill) : this() {
            if (autoFill) {
                collection.Add(new MaterialStack(Material.WOOD));
                collection.Add(new MaterialStack(Material.STONE));
            }
        }

        /// <summary>
        /// Adds materials to the collection
        /// </summary>
        /// <param name="mat">The stack of materials to add</param>
        public void AddMaterial(MaterialStack mat) {
            foreach (MaterialStack stack in collection) {
                if (stack.material.id == mat.material.id) {
                    stack.count += mat.count;
                    return;
                }
            }
            collection.Add(mat);
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
        /// Gets how much a material is in the collection
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

        /// <summary>
        /// Allows 2 collections to be added together
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static MaterialCollector operator +(MaterialCollector a, MaterialCollector b) {
            foreach (MaterialStack stack in b.collection) {
                a.AddMaterial(stack.material, stack.count);
            }

            return a;
        }

        /// <summary>
        /// Overrides the ToString function
        /// </summary>
        /// <returns>Prints all the materials in the string</returns>
        public override string ToString() {
            string s = "";
            foreach (MaterialStack stack in collection)
                s = String.Format("{0}\n{1}", s, stack);
            return s;
        }

        /// <summary>
        /// Clears the collection
        /// </summary>
        public void Clear() {
            collection.Clear();
        }
    }
}
