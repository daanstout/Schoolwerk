using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Les2 {
    public partial class Form1 : Form {
        Square square;
        AxisX xAxis;
        AxisY yAxis;

        public Form1() {
            InitializeComponent();

            square = new Square(Color.Blue);
            xAxis = new AxisX(100);
            yAxis = new AxisY(100);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e) {
            base.OnPaint(e);
            {
                square.Draw(e.Graphics, square.vb);
                xAxis.Draw(e.Graphics, xAxis.vb);
                yAxis.Draw(e.Graphics, yAxis.vb);
            }
        }
    }
}
