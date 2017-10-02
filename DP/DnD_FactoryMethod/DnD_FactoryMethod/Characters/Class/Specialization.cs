using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_FactoryMethod.Characters.Class {
    public class Specialization {
        public string className;
        public Stats.hitDie hitdie;
        public Color color;
        public Image image;

        protected Specialization(string className, Image image, Stats.hitDie hitdie, Color color) {
            this.className = className;
            this.image = image;
            this.hitdie = hitdie;
            this.color = color;
        }

        public override string ToString() {
            return className;
        }
    }
}
