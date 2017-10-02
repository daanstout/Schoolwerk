using DnD_FactoryMethod.Characters;
using DnD_FactoryMethod.Characters.Class;
using DnD_FactoryMethod.Characters.Races;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_FactoryMethod.Factories {
    public class CharacterFactory : EntityFactory {

        public override Character createCharacter(string name, string race, string spec) {
            Character temp = new Character();

            temp.charName = name;

            switch (race) {
                case "Human":
                    temp.charRace = new Human();
                    break;
                case "Elf":
                    temp.charRace = new Elf();
                    break;
                case "Orc":
                    temp.charRace = new Orc();
                    break;
                case "Dwarf":
                    temp.charRace = new Dwarf();
                    break;
            }

            switch (spec) {
                case "Fighter":
                    temp.charClass = new Fighter(Stats.hitDie.D10);
                    break;
                case "Rogue":
                    temp.charClass = new Rogue(Stats.hitDie.D8);
                    break;
                case "Warlock":
                    temp.charClass = new Warlock(Stats.hitDie.D8);
                    break;
                case "Wizard":
                    temp.charClass = new Wizard(Stats.hitDie.D6);
                    break;
            }

            temp.charRace.adjustStats(ref temp.charStats);

            return temp;
        }
    }
}
