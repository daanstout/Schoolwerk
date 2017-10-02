using DnD_FactoryMethod.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_FactoryMethod.Characters.Races {
    public class Elf : Race{
        public Elf() : base("Elf", Resources.Elf){

        }

        public override void adjustStats(ref Stats stats) {
            stats.dexterity += 2;
        }
    }
}
