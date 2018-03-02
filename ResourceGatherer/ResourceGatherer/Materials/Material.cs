﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Materials {
    public class Material {
        // STATIC MATERIALS
        public static Material WOOD = new Material(Materials.WOOD.ToString());
        public static Material STONE = new Material(Materials.STONE.ToString());

        public enum Materials {
            WOOD,
            STONE
        }

        private int ID;
        private int NextValidID {
            get {
                return ++ID;
            }
        }


        public string name;
        public int id;

        public Material() : this("") {

        }

        public Material(string name) {
            this.name = name;
            id = NextValidID;
        }
    }
}