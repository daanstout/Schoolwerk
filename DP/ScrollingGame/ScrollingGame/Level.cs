using ScrollingGame.Entity.Characters;
using ScrollingGame.Entity.Obstacles;
using ScrollingGame.Items;
using ScrollingGame.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame {
    public class Level {
        private List<Obstacle> _obstacleList;
        private List<Character> _characterList;
        private List<AItem> _itemList;

        private Vector2 levelSize;

        public float levelLeft { get => levelSize.X; set => levelSize.X = value; }
        public float levelRight { get => levelSize.Y; set => levelSize.Y = value; }

        public List<Obstacle> obstacleList {
            get {
                if (_obstacleList == null)
                    _obstacleList = new List<Obstacle>();
                return _obstacleList;
            }
        }

        public Obstacle addObstacle {
            set {
                if (!obstacleList.Contains(value))
                    obstacleList.Add(value);
            }
        }


        public List<Character> characterList {
            get {
                if (_characterList == null)
                    _characterList = new List<Character>();
                return _characterList;
            }
        }

        public List<Character> characterListPlayer {
            get {
                List<Character> temp = new List<Character>();
                temp.Add(Singleton.player);
                temp.AddRange(characterList);
                return temp;
            }
        }

        public Character addCharacter {
            set {
                if (value is Player)
                    return;
                if (!characterList.Contains(value))
                    characterList.Add(value);
            }
        }


        public List<AItem> itemList {
            get {
                if (_itemList == null)
                    _itemList = new List<AItem>();
                return _itemList;
            }
        }

        public AItem addItem {
            set {
                if (!itemList.Contains(value))
                    itemList.Add(value);
            }
        }


        public Level(int gravity) {
            Singleton.gameGravity = gravity;
        }

        public void load() {
            setLevelSize();

            foreach (Obstacle o in obstacleList)
                if (o.doTick || o.doDraw)
                    Singleton.loadNewBehaviour = o;
            foreach (Character c in characterList)
                if (c.doTick || c.doDraw)
                    Singleton.loadNewBehaviour = c;
            foreach (AItem i in itemList)
                Singleton.loadNewBehaviour = i;
        }

        private void setLevelSize() {
            levelSize = Vector2.Zero;

            foreach (Obstacle o in obstacleList)
                if (o.doTick || o.doDraw)
                    if (o.location.X < levelLeft)
                        levelLeft = o.location.X;
                    else if (o.location.X + o.size.X > levelRight)
                        levelRight = o.location.X + o.size.X;

            foreach (Character c in characterList)
                if (c.doTick || c.doDraw)
                    if (c.location.X < levelLeft)
                        levelLeft = c.location.X;
                    else if (c.location.X + c.size.X > levelRight)
                        levelRight = c.location.X + c.size.X;

            foreach (AItem i in itemList)
                if (i.doTick || i.doDraw)
                    if (i.location.X < levelLeft)
                        levelLeft = i.location.X;
                    else if (i.location.X + i.radius > levelRight)
                        levelRight = i.location.X + i.radius;

            Console.WriteLine(levelSize);
        }
    }
}
