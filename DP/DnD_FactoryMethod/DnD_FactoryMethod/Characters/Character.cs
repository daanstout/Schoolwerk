using DnD_FactoryMethod.Characters.Class;
using DnD_FactoryMethod.Characters.Races;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_FactoryMethod.Characters {
    public class Character {
        public string charName;
        public Stats charStats;
        public Race charRace;
        public Specialization charClass;

        public Character() {
            charStats = new Stats(10, 10, 10, 10, 10, 10);
        }

        public override string ToString() {
            return charName + " - " + charRace + " - " + charClass + "\n" + charStats;
        }
    }
}
