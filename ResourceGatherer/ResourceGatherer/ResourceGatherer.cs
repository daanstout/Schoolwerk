using ResourceGatherer.World;
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
        GameWorld gameWorld;

        public ResourceGatherer() {
            InitializeComponent();

            gameWorld = new GameWorld(800, 600);
        }

        private void worldTimer_Tick(object sender, EventArgs e) {
            gameWorld.Update();

            gameWorldPicturebox.Invalidate();
        }

        private void gameWorldPicturebox_Paint(object sender, PaintEventArgs e) {
            gameWorld.Draw(e.Graphics);
        }
    }
}
