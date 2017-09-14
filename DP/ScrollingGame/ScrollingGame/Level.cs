using ScrollingGame.Entity.Characters;
using ScrollingGame.Entity.Obstacles;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame {
    public class Level {
        private List<Obstacle> _obstacleList;
        private List<Character> _characterList;

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


        public Level() { }

        public void load() {
            foreach (Obstacle o in obstacleList)
                if (o.tickable)
                    Singleton.loadNewBehaviour = o;
            foreach (Character c in characterList)
                if (c.tickable)
                    Singleton.loadNewBehaviour = c;
        }
    }
}
