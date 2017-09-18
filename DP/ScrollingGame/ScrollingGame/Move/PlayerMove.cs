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
            base.Move(c);

            //Singleton.player.location += Player.Movement * Player.PlayerMovementSpeed * Time.deltaTimeSeconds + new Vector2(0, Singleton.player.fallSpeed);
            c.location += Player.Movement * c.characterMovement * Time.deltaTimeSeconds + new Vector2(0, c.fallSpeed);

            foreach (Obstacle o in Singleton.currentLevel.obstacleList) {
                if(c.location.Y < o.location.Y + o.size.Y && c.location.Y + c.size.Y > o.location.Y) {
                    float movement = (Player.Movement * c.characterMovement * Time.deltaTimeSeconds + new Vector2(0, c.fallSpeed)).X;
                    if(c.location.X < o.location.X + o.size.X && c.location.X + c.size.X > o.location.X) {
                        if(movement > 0) {
                            c.location.X = o.location.X - c.size.X;
                        }else if(movement < 0) {
                            c.location.X = o.location.X + o.size.X;
                        }
                    }
                }
            }

            


            
        }
    }
}
