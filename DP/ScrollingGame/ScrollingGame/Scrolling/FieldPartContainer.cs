using ScrollingGame.Entity.Obstacles;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Scrolling {
    public static class FieldPartContainer {
        private static readonly int fieldPartSize = 100;

        private static List<FieldPart> _fieldPartList;

        public static List<FieldPart> fieldPartList {
            get {
                if (_fieldPartList == null)
                    _fieldPartList = new List<FieldPart>();
                return _fieldPartList;
            }
        }

        public static void generateFieldParts() {
            for (float i = Singleton.currentLevel.levelLeft; i < Singleton.currentLevel.levelRight; i += fieldPartSize) {
                fieldPartList.Add(new FieldPart());
            }

            fillFieldParts();
        }

        private static void fillFieldParts() {
            foreach(Obstacle o in Singleton.currentLevel.obstacleList) {
                for(float i = o.location.X; i < o.location.X + o.size.X; i+= fieldPartSize) {
                    Console.WriteLine(fieldPartList.Count + " -> " + i);
                    fieldPartList[(int)(i / 100)].addEntity = o;
                    o.addFieldPart = getFieldPart((int)i);
                }
            }
        }

        public static FieldPart getFieldPart(int location) {
            if (location > Singleton.currentLevel.levelRight || location < Singleton.currentLevel.levelLeft)
                return null;

            return fieldPartList[location / 100];
        }
    }
}
