using DnD_FactoryMethod.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_FactoryMethod.Characters.Class {
    public class Wizard : Specialization {
        public Wizard(Stats.hitDie hitdie, Color color) : base("Wizard", Resources.Staff, hitdie, color) { }
    }
}
