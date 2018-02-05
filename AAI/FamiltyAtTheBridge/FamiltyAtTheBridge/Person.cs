using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamiltyAtTheBridge {
    public class Person {
        public int speed;
        public bool crossed;

        public Person(int speed) {
            this.speed = speed;
            crossed = false;
        }
    }
}
