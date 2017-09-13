using ScrollingGame.Entity.Characters;
using ScrollingGame.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Move {
    public class PlayerMove : AMove{
        public override void Move(Character c) {
            Singleton.player.location += Player.Movement * Player.PlayerMovementSpeed * Time.deltaTimeSeconds;
        }
    }
}
