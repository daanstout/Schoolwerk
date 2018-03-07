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
        public GameWorld gameWorld;

        public static ResourceGatherer instance;

        bool showVerteces = false;

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
        }

        private void gameWorldPicturebox_Paint(object sender, PaintEventArgs e) {
            base.OnPaint(e);
            {
                gameWorld.Draw(e.Graphics);
            }
        }

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
    }
}
