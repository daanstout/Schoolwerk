using ResourceGatherer.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.World {
    public class GameWorld {
        public readonly int gameWidth;
        public readonly int gameHeight;

        public GameWorld(int width, int height) {
            gameWidth = width;
            gameHeight = height;

            for(int i = 0; i < 10; i++) {
                BaseEntity e = new BaseEntity(5);
                Console.WriteLine(e.GetId());
            }
        }

        public void Update() {

        }

        public void Draw(Graphics g) {

        }
    }
}
