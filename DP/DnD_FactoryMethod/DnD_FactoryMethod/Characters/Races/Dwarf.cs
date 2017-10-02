using DnD_FactoryMethod.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_FactoryMethod.Characters.Races {
    public class Dwarf : Race{
        public Dwarf() : base("Dwarf", Resources.Dwarf){

        }

        public override void adjustStats(ref Stats stats) {
            stats.constitution += 2;
        }
    }
}
