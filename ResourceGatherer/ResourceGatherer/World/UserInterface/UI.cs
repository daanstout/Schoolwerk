using ResourceGatherer.Materials;
using ResourceGatherer.Util;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.World.UserInterface {
    /// <summary>
    /// Draws the User Interface
    /// </summary>
    public static class UI {
        /// <summary>
        /// The max height of a module
        /// </summary>
        private static readonly int maxHeight = 20;
        /// <summary>
        /// The max width of a module
        /// </summary>
        private static readonly int maxWidth = 50;

        /// <summary>
        /// Draws the User Interface
        /// </summary>
        /// <param name="g">The graphics instance</param>
        public static void Render(Graphics g) {
            int curX = 0;
            foreach (MaterialStack s in GameWorld.instance.materialCollection.collection) {
                g.DrawImage(s.material.sprite, curX, 0);
                g.DrawString(s.count.ToString(), Fonts.font_user_interface, new SolidBrush(Color.Black), curX + 25, 0);
                curX += maxWidth;
            }   
        }
    }
}
