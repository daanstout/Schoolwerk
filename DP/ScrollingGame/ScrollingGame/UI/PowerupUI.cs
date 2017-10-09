using ScrollingGame.Items;
using ScrollingGame.Utils;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScrollingGame.UI {
    public class PowerupUI : ABehaviour, IObserver {
        Subject subj;

        public PowerupUI() {
            subj = Singleton.player.pSubject;
            subj.attach = this;
            doDraw = true;
        }

        public override void onLoad() {
            subj = Singleton.player.pSubject;
            subj.attach = this;
            doDraw = true;
        }

        public void Update() {
            Console.WriteLine("HALLO!");
            if(Singleton.player.itemList.Count > 0) {
                Console.WriteLine("HALLO!");
                Singleton.subscribeToTick = this;
            }else if(Singleton.player.itemList.Count == 0) {
                Singleton.unsubscribeFromTick = this;
            }
        }

        public override void onDraw(Graphics g) {
            int baseY = 5;
            foreach(AItem i in Singleton.player.itemList) {
                g.DrawString(i.itemName + ": " + Math.Round(i.remainingDuration, 2), Fonts.getFont("Arial", 8), Fonts.getSolidBrush(Color.Black), new Vector2(200, baseY));
                baseY += 12;
            }
        }
    }
}
