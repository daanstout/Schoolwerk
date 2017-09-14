using ScrollingGame.Entity;
using ScrollingGame.Entity.Characters;
using ScrollingGame.Entity.Obstacles;
using ScrollingGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Move {
    public abstract class AMove : IMoveStrategy {

        public virtual void Move(Character c) {
            foreach (Obstacle o in Singleton.currentLevel.obstacleList) {
                //if (c.location.X + c.size.X > o.location.X && c.location.X < o.location.X + o.size.X && c.location.Y + c.size.Y > o.location.Y && c.location.Y < o.location.Y + o.size.Y) {
                //    float movementVector = (Vector2.Right * Player.PlayerMovementSpeed * Time.deltaTimeSeconds).X;
                //    if (c.location.X + c.size.X - movementVector < o.location.X) {
                //        c.location.X = o.location.X - c.size.X;
                //    }else if(c.location.X + movementVector > o.location.X + o.size.X) {
                //        c.location.X = o.location.X + o.size.X;
                //    }


                //    //Console.WriteLine(c.location.X + " + " + c.size.X + " > " + o.location.X + " && " + c.location.X + " < " + o.location.X + " + " + o.size.X + " && " + c.location.Y + " + " + c.size.Y + " > " + o.location.Y + " && " + c.location.Y + " < " + o.location.Y + " + " + o.size.Y);
                //    //c.location.X = o.location.X - c.size.X;
                //    Console.WriteLine("1");
                //}// else if (c.location.X < o.location.X + o.size.X && c.location.X + c.size.X > o.location.X && c.location.Y + c.size.Y > o.location.Y && c.location.Y < o.location.Y + o.size.Y) {
                 //    c.location.X = o.location.X + o.size.X;
                 //    Console.WriteLine("2");
                 //}
                 //c.location += Player.Movement * Player.PlayerMovementSpeed * Time.deltaTimeSeconds + new Vector2(0, c.fallSpeed);


                if (c.location.X > o.location.X + o.size.X && c.location.X + c.size.X > o.location.X && c.location.Y + c.size.Y > o.location.Y && c.location.Y < o.location.Y + o.size.Y)
                    Gravity.Gravity.subscribeToGravity = c;
                else if (c.location.X < o.location.X + o.size.X && c.location.X + c.size.X < o.location.X && c.location.Y + c.size.Y > o.location.Y && c.location.Y < o.location.Y + o.size.Y)
                    Gravity.Gravity.subscribeToGravity = c;
            }
        }
    }
}
