using ResourceGatherer.Drawers.TileDrawers;
using ResourceGatherer.World;
using ResourceGatherer.World.Tiles;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResourceGatherer {
    public partial class ResourceGatherer : Form {
        /// <summary>
        /// Instance of the game world
        /// </summary>
        public GameWorld gameWorld;

        /// <summary>
        /// Public instance of our window
        /// </summary>
        public static ResourceGatherer instance;

        /// <summary>
        /// A bool on whether we want to show the verteces
        /// </summary>
        bool showVerteces = false;

        /// <summary>
        /// Public constructor for our window
        /// </summary>
        public ResourceGatherer() {
            instance = this;

            InitializeComponent();

            BaseTile.SetTileDrawer(new SimpleTileDrawer());

            gameWorld = new GameWorld(800, 600);

            RedrawBackground();

            worldTimer.Enabled = true;
        }

        private void worldTimer_Tick(object sender, EventArgs e) {
            gameWorld.Update();

            gameWorldPicturebox.Invalidate();
            UIPictureBox.Invalidate();
        }

        private void gameWorldPicturebox_Paint(object sender, PaintEventArgs e) {
            base.OnPaint(e);
            {
                gameWorld.RenderGame(e.Graphics);
            }
        }

        /// <summary>
        /// Redraws the background and sets it as image on the picturebox
        /// </summary>
        public void RedrawBackground() {
            Bitmap bg = new Bitmap(gameWorld.gameWidth, gameWorld.gameHeight);

            Graphics g = Graphics.FromImage(bg);

            gameWorld.GetBackground(g);

            gameWorldPicturebox.Image = bg;
        }

        private void vertecesButton_Click(object sender, EventArgs e) {
            showVerteces = !showVerteces;
            if (showVerteces) {
                BaseTile.SetTileDrawer(new VertexDrawer());
                vertecesButton.Text = "Hide Verteces";
            } else {
                BaseTile.SetTileDrawer(new SimpleTileDrawer());
                vertecesButton.Text = "Show Verteces";
            }

            RedrawBackground();
        }

        private void redrawBackgroundButton_Click(object sender, EventArgs e) {
            RedrawBackground();
        }

        private void newWorldButton_Click(object sender, EventArgs e) {
            worldTimer.Enabled = false;

            gameWorld = new GameWorld(800, 600);

            RedrawBackground();

            worldTimer.Enabled = true;
        }

        private void UIPictureBox_Paint(object sender, PaintEventArgs e) {
            base.OnPaint(e);
            {
                gameWorld.RenderUI(e.Graphics);
            }
        }
    }
}
