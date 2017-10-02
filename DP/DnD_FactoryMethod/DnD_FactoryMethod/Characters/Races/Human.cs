using DnD_FactoryMethod.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_FactoryMethod.Characters.Races {
    public class Human : Race{

        public Human() : base("Human", Resources.Human){

        }

        public static Image Resouces { get; }

        public override void adjustStats(ref Stats stats) {
            stats.strength += 1;
            stats.dexterity += 1;
            stats.constitution += 1;
            stats.intelligence += 1;
            stats.wisdom += 1;
            stats.charisma += 1;
        }
    }
}
