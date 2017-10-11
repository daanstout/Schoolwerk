using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Utils {
    public class GameScroller : IObserver {
        Subject subj;
        float spareRoom = 100;

        public GameScroller() {
            subj = Singleton.player.playerMoveSubject;
            subj.attach = this;
        }

        public void Update() {
            if(Singleton.player.location.X + Singleton.player.size.X - Singleton.gameXLocation > Global.Game_Right - spareRoom) {
                //Console.WriteLine("To Far");
                Console.Write(Global.Game_Right + " - " + spareRoom + " - " + Singleton.player.location.X + " + " + Singleton.player.size.X + " = ");
                //Singleton.gameXLocation = Global.Game_Right - spareRoom - Singleton.player.location.X + Singleton.player.size.X;
                float shove = Global.Game_Right - spareRoom - Singleton.player.location.X + Singleton.player.size.X;
                Console.WriteLine(shove);
            }
        }
    }
}
