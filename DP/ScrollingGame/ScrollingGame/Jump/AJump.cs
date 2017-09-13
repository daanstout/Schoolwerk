using ScrollingGame.Entity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Jump {
    public abstract class AJump : ABehaviour, IJumpStrategy {
        public bool isJumping;

        public void Jump() {

        }
    }
}
