using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thievery.Behaviours;
using Thievery.Properties;

namespace Thievery.World.Tiles {
    public class GameTile : IDrawable{
        private Bitmap tileSprite;
        private Point location;

        public GameTile(Bitmap sprite, Point loc) {
            tileSprite = sprite;
            location = loc;
        }

        public void Draw(Graphics e) {
            Console.WriteLine("Draw");
            e.DrawImage(tileSprite, location);
        }
    }
}
