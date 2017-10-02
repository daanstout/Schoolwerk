using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_FactoryMethod.Characters {
    public class Stats {
        public enum hitDie {
            D4 = 4,
            D6 = 6,
            D8 = 8,
            D10 = 10,
            D12 = 12,
            D20 = 20
        }

        public static int getHitPoints(hitDie die, int level, int conMod) {
            int hitpoints = 0;
            hitpoints = (int)die + conMod;
            for (int i = 2; i <= level; i++) {
                hitpoints += ((int)die + 1) / 2 + conMod;
            }
            return hitpoints;
        }

        public static int getMod(int stat) {
            return (stat - 10) / 2;
        }

        public int strength;
        public int dexterity;
        public int constitution;
        public int wisdom;
        public int intelligence;
        public int charisma;

        public Stats(int strength, int dexterity, int constitution, int wisdom, int intelligence, int charisma) {
            this.strength = strength;
            this.dexterity = dexterity;
            this.constitution = constitution;
            this.wisdom = wisdom;
            this.intelligence = intelligence;
            this.charisma = charisma;
        }

        public override string ToString() {
            return String.Format("Str {0}\nDex {1}\nCon {2}\nWis {3}\nInt {4}\nCha {5}", strength, dexterity, constitution, wisdom, intelligence, charisma);
        }
    }
}
