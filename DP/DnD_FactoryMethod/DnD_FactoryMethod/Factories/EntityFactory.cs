using DnD_FactoryMethod.Characters;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_FactoryMethod.Factories {
    public abstract class EntityFactory {
        public abstract Character createCharacter(string name, string race, string spec);
    }
}
