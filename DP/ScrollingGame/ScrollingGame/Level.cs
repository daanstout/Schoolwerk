using ScrollingGame.Entity.Characters;
using ScrollingGame.Entity.Obstacles;
using ScrollingGame.Items;

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

        public List<Obstacle> obstacleList {
            get {
                if (_obstacleList == null)
                    _obstacleList = new List<Obstacle>();
                return _obstacleList;
            }
        }

        public Obstacle addObstale {
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


        public Level() { }

        public void load() {
            foreach (Obstacle o in obstacleList)
                if (o.doTick || o.doDraw)
                    Singleton.loadNewBehaviour = o;
            foreach (Character c in characterList)
                if (c.doTick || c.doDraw)
                    Singleton.loadNewBehaviour = c;
            foreach (AItem i in itemList)
                Singleton.loadNewBehaviour = i;
        }
    }
}
