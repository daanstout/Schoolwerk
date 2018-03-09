using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Materials {
    public class MaterialStack {
        public Material material;
        public int count;

        public MaterialStack() { }

        public MaterialStack(Material mat) {
            material = mat;
            count = 1;
        }

        public MaterialStack(Material mat, int count) {
            material = mat;
            this.count = count;
        }
    }
}
