using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Util {
    /// <summary>
    /// A C2DMatrix copied from Buckland
    /// </summary>
    public sealed class C2DMatrix {
        /// <summary>
        /// The matrix
        /// </summary>
        private float[,] matrix;

        /// <summary>
        /// Creatse a new identity matrix with a size of 3 by 3
        /// </summary>
        public C2DMatrix() {
            Identity();
        }

        /// <summary>
        /// Mutliplies the matrix with another matrix
        /// </summary>
        /// <param name="other">The matrix to be multiplied with</param>
        private void MatrixMultiply(C2DMatrix other) {
            C2DMatrix m = new C2DMatrix();
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    float value = 0;
                    for (int k = 0; k < 3; k++)
                        value += matrix[i, k] * other.matrix[k, j];
                    m.matrix[i, j] = value;
                }
            }
            matrix = m.matrix;
        }

        /// <summary>
        /// Creats a new 3 by 3 identity matrix
        /// </summary>
        public void Identity() {
            matrix = new float[3, 3];

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (i == j)
                        matrix[i, j] = 1;
                    else
                        matrix[i, j] = 0;
        }

        /// <summary>
        /// Translates a matrix over an X and a Y coördinate
        /// </summary>
        /// <param name="x">The X coördinate</param>
        /// <param name="y">The Y coördinate</param>
        public void Translate(float x, float y) {
            C2DMatrix mat = new C2DMatrix();

            mat.matrix[0, 2] = x;
            mat.matrix[1, 2] = y;

            MatrixMultiply(mat);
        }

        /// <summary>
        /// Scales the matrix
        /// </summary>
        /// <param name="xScale">The factor of the X-scaling</param>
        /// <param name="yScale">The factor of the Y-scaling</param>
        public void Scale(float xScale, float yScale) {
            C2DMatrix mat = new C2DMatrix();

            mat.matrix[0, 0] = xScale;
            mat.matrix[1, 1] = yScale;

            MatrixMultiply(mat);
        }

        /// <summary>
        /// Rotates a matrix over a value
        /// </summary>
        /// <param name="rotation">The number of degrees to be rotated with</param>
        public void Rotate(float rotation) {
            C2DMatrix mat = new C2DMatrix();

            float Sin = (float)Math.Sin(rotation);
            float Cos = (float)Math.Cos(rotation);

            mat.matrix[0, 0] = Cos;
            mat.matrix[1, 0] = -Sin;
            mat.matrix[0, 1] = Sin;
            mat.matrix[1, 1] = Cos;

            MatrixMultiply(mat);
        }

        /// <summary>
        /// Rotates a matrix based on a forward and a side angle
        /// </summary>
        /// <param name="forward">The forward vector</param>
        /// <param name="side">The side vector</param>
        public void Rotate(Vector2D forward, Vector2D side) {
            C2DMatrix mat = new C2DMatrix();

            mat.matrix[0, 0] = forward.x;
            mat.matrix[1, 0] = forward.y;
            mat.matrix[0, 1] = side.x;
            mat.matrix[1, 1] = side.y;

            MatrixMultiply(mat);
        }

        /// <summary>
        /// Transforms a vector through the matrix
        /// </summary>
        /// <param name="point">The point to be transformed</param>
        public void TransformVector2Ds(ref Vector2D point) {
            float tempX = (matrix[0, 0] * point.x) + (matrix[1, 0] * point.y) + matrix[2, 0];
            float tempY = (matrix[0, 1] * point.x) + (matrix[1, 1] * point.y) + matrix[2, 1];

            point.x = tempX;
            point.y = tempY;
        }
    }
}
