using ScrollingGame.Entity.Characters;
using ScrollingGame.Entity.Obstacles;
using ScrollingGame.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Move {
    public class SimpleMove : AFixedScreenMove {
        public override void Move(Character c) {
            base.Move(c);

            //Singleton.player.location += Player.Movement * Player.PlayerMovementSpeed * Time.deltaTimeSeconds + new Vector2(0, Singleton.player.fallSpeed);
            Vector2 movement = c.characterDirection * c.characterMovement * Time.deltaTimeSeconds;
            Console.WriteLine(c.characterDirection + " - - " + c.characterMovement + " - - " + Time.deltaTimeSeconds);

            if (movement.X > 0)
                c.lookDirection = Vector2.Right;
            else if (movement.X < 0)
                c.lookDirection = Vector2.Left;

            Console.WriteLine(movement);

            //c.location += movement;

            

            foreach (Obstacle o in Singleton.currentLevel.obstacleList) {
                if(c.location.Y < o.location.Y + o.size.Y && c.location.Y + c.size.Y > o.location.Y) {
                    if(c.location.X < o.location.X + o.size.X && c.location.X + c.size.X > o.location.X) {
                        if(movement.X > 0 && c.location.X - movement.X * 2 + c.size.X > o.location.X) {
                            c.location.X = o.location.X - c.size.X;
                        }else if(movement.X < 0 && c.location.X + movement.X * 2 < o.location.X + o.size.X) {
                            c.location.X = o.location.X + o.size.X;
                        }
                    }
                }
            }
            c.location += new Vector2(0, c.fallSpeed);
        }
    }
}
