using DnD_FactoryMethod.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_FactoryMethod.Characters.Class {
    public class Warlock : Specialization {
        public Warlock(Stats.hitDie hitdie) : base("Warlock", Resources.EvilStaff, hitdie) { }
    }
}
