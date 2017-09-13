using ScrollingGame.Entity.Characters;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Jump {
    public interface IJumpStrategy {
        void Jump(Character c);
    }
}
