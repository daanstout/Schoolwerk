using ScrollingGame.Entity.Characters;
using ScrollingGame.Entity.Obstacles;
using ScrollingGame.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Move {
    public class PlayerMove : AMove {
        public override void Move(Character c) {
            //Singleton.player.location += Player.Movement * Player.PlayerMovementSpeed * Time.deltaTimeSeconds + new Vector2(0, Singleton.player.fallSpeed);
            c.location += Player.Movement * Player.PlayerMovementSpeed * Time.deltaTimeSeconds + new Vector2(0, c.fallSpeed);

            base.Move(c);


            
        }
    }
}
