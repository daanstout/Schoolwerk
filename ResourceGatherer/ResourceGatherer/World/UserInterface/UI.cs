using ResourceGatherer.Materials;
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
            GameWorld world = GameWorld.instance;

            int curX = 0;
            foreach (MaterialStack s in world.materialCollection.collection) {
                g.DrawImage(s.material.sprite, curX, 0);
                g.DrawString(s.count.ToString(), new Font("Arial", 11), new SolidBrush(Color.Black), curX + 25, 0);
                curX += maxWidth;
            }
        }
    }
}
