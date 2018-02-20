using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thievery.Behaviours {
    public abstract class ABase : IUpdatable, IDrawable {
        public bool doTick = true;
        public bool doDraw = true;

        public abstract void Update();
        public abstract void Draw(Graphics e);
    }
}
