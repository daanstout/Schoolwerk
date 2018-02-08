using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesOpgaven {
    public class Matrix {
        public float[,] matrix;
        public int rows;
        public int columns;

        public Matrix() {
            matrix = Identity().matrix;
            rows = 2;
            columns = 2;
        }

        public Matrix(int rows, int columns) {
            matrix = new float[rows, columns];

            this.rows = rows;
            this.columns = columns;
        }

        public Matrix(Vector2 v) {
            matrix = new float[2, 2];

            rows = 2;
            columns = 1;

            matrix[0, 0] = v.x;
            matrix[1, 0] = v.y;
        }

        public static Matrix Identity() {
            Matrix m = new Matrix(2, 2);
            m.matrix[0, 0] = 1;
            m.matrix[1, 1] = 1;

            return m;
        }

        public static Matrix operator +(Matrix a, Matrix b) {
            if (a.columns != b.columns && a.rows != b.columns)
                return null;
            Matrix m = new Matrix(a.rows, b.columns);
            for(int i = 0; i < m.rows; i++) {
                for(int j = 0; j < m.columns; j++) {
                    m.matrix[i, j] = a.matrix[i, j] + b.matrix[i, j];
                }
            }

            return m;
        }

        public static Matrix operator -(Matrix a, Matrix b) {
            if (a.columns != b.columns && a.rows != b.columns)
                return null;
            Matrix m = new Matrix(a.rows, b.columns);
            for (int i = 0; i < m.rows; i++) {
                for (int j = 0; j < m.columns; j++) {
                    m.matrix[i, j] = a.matrix[i, j] - b.matrix[i, j];
                }
            }

            return m;
        }

        public static Matrix operator *(Matrix a, float b) {
            Matrix m = new Matrix(a.rows, a.columns);
            for(int i = 0; i < m.rows; i++) {
                for(int j = 0; j < m.columns; j++) {
                    m.matrix[i, j] = a.matrix[i, j] * b;
                }
            }
            return m;
        }

        public static Matrix operator *(float a, Matrix b) {
            return b * a;
        }

        public static Vector2 operator *(Matrix a, Vector2 b) {
            return (a * new Matrix(b)).ToVector();
        }

        public static Matrix operator *(Matrix a, Matrix b) {
            if (a.columns != b.rows)
                return null;
            Matrix m = new Matrix(a.rows, b.columns);

            return m;
        }

        public override string ToString() {
            string s = "";

            for(int i = 0; i < rows; i++) {
                s += "{";
                for (int j = 0; j < columns; j++)
                    s += matrix[i, j] + ", ";
                s += "}\n";
            }

            return s;
        }

        public Vector2 ToVector() {
            return new Vector2(matrix[0, 0], matrix[1, 0]);
        }
    }
}
