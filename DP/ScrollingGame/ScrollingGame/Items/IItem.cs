using ScrollingGame.Entity.Characters;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Items {
    public interface IItem {
        void onPickUp(Character c, float duration);
        void onExpire(Character c);
    }
}
