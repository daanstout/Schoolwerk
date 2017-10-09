using ScrollingGame.Entity;
using ScrollingGame.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ScrollingGame.UI {
    public class PlayerUI : ABehaviour{
        public PlayerUI() {
            doDraw = true;
        }

        public override void onLoad() {
            doDraw = true;
        }

        public override void onDraw(Graphics g) {
            g.DrawRectangle(Fonts.getPen(Color.Black), new Rectangle(Global.UI_Top, Global.UI_Left, Global.UI_Right - 1, Global.UI_Bottom - 1));

            g.DrawRectangle(Fonts.getPen(Color.Black), new Rectangle(5, 5, 30, 30));
            g.FillRectangle(Fonts.getSolidBrush(Singleton.player.color), new Rectangle(10, 10, 20, 20));
            g.DrawString("Player 1", Fonts.getFont("arial", 20), Fonts.getSolidBrush(Color.Black), new Vector2(40, 4));
        }
    }
}
