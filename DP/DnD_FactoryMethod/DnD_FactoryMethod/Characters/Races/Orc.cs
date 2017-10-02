using DnD_FactoryMethod.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_FactoryMethod.Characters.Races {
    public class Orc : Race{
        public Orc() : base("Orc", Resources.Orc){

        }

        public override void adjustStats(ref Stats stats) {
            stats.strength += 2;
        }
    }
}
