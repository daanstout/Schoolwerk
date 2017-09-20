using ScrollingGame.Gravity;
using ScrollingGame.Items;
using ScrollingGame.Jump;
using ScrollingGame.Move;
using ScrollingGame.Utils;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Entity.Characters {
    public class Player : Character {
        public PlayerSubject pSubject;

        private List<AItem> _itemList;

        public List<AItem> itemList {
            get {
                if (_itemList == null)
                    _itemList = new List<AItem>();
                return _itemList;
            }
        }

        public AItem addItem {
            set {
                if (!itemList.Contains(value)) {
                    itemList.Add(value);
                    pSubject.Notify();
                }
            }
        }

        public static bool[] buttons = new bool[4];
        public static Vector2 Movement {
            get {
                Vector2 temp = Vector2.Zero;
                //if (buttons[0])
                //    temp += Vector2.Up;
                //if (buttons[1])
                //    temp += Vector2.Down;
                if (buttons[2])
                    temp += Vector2.Left;
                if (buttons[3])
                    temp += Vector2.Right;
                return temp;
            }
        }

        //public static float PlayerMovementSpeed = 100;
        public Player(Vector2 location, Vector2 size, Color color, bool tickable) : base(location, size, color, tickable) {
            pSubject = new PlayerSubject();
        }

        public override void onUpdate() {
            base.onUpdate();
            moveStrategy.Move(this);

            List<AItem> remove = new List<AItem>();
            foreach (AItem i in itemList) {
                i.remainingDuration -= Time.deltaTimeSeconds;
                if(i.remainingDuration <= 0) {
                    i.onExpire(this);
                    remove.Add(i);
                }
            }
            foreach (AItem i in remove)
                itemList.Remove(i);
        }

        public override void onLoad() {
            base.onLoad();
            moveStrategy = new PlayerMove();
            jumpStrategy = new SimpleJump();
            entityMass = 2;
            characterMovement = 100;
            GravitationalForce.subscribeToGravity = this;
        }
    }
}
