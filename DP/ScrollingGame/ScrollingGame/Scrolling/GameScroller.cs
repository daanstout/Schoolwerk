using ScrollingGame.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Scrolling {
    public class GameScroller : IObserver {
        Subject subj;
        float spareRoom = 100;

        public GameScroller() {
            subj = Singleton.player.playerMoveSubject;
            subj.attach = this;
        }

        public void Update() {
            if (Singleton.player.location.X + Singleton.player.size.X - Singleton.gameXLocation > Global.Game_Right - spareRoom) {
                Singleton.gameXLocation = Math.Abs(Global.Game_Right - spareRoom - (Singleton.player.location.X + Singleton.player.size.X));
            } else if (Singleton.player.location.X - Singleton.gameXLocation < spareRoom) {
                Singleton.gameXLocation = Math.Abs(spareRoom - Singleton.player.location.X);
                if (Singleton.gameXLocation < 0)
                    Singleton.gameXLocation = 0;
            }
        }
    }
}
