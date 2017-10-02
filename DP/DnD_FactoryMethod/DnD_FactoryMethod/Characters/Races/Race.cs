using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_FactoryMethod.Characters.Races{
    public class Race {
        public readonly string raceName;
        public Image image;

        protected Race(string raceName, Image image) {
            this.raceName = raceName;
            this.image = image;
        }

        public virtual void adjustStats(ref Stats stats) { }

        public override string ToString() {
            return raceName;
        }
    }
}
