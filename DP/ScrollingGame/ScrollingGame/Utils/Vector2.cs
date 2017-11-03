using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Utils {
    public class Vector2 {
        public float X;
        public float Y;

        public static readonly Vector2 Zero = new Vector2(0, 0);
        public static readonly Vector2 Up = new Vector2(0, -1);
        public static readonly Vector2 Down = new Vector2(0, 1);
        public static readonly Vector2 Left = new Vector2(-1, 0);
        public static readonly Vector2 Right = new Vector2(1, 0);

        public Vector2(float X, float Y) {
            this.X = X;
            this.Y = Y;
        }

        public Vector2(float X) {
            this.X = X;
        }

        public Vector2() { }

        public Vector2 normalized {
            get {
                float x, y;

                if (X > 1)
                    x = 1;
                else if (X < -1)
                    x = -1;
                else
                    x = X;

                if (Y > 1)
                    y = 1;
                else if (Y < -1)
                    y = -1;
                else
                    y = Y;

                return new Vector2(x, y);
            }
        }

        public float getDistanceTo(Vector2 other) {
            float X = Math.Abs(this.X - other.X);
            float Y = Math.Abs(this.Y - other.Y);
            return (float)Math.Sqrt(X * X + Y * Y);
        }

        public override string ToString() {
            return String.Format("[X = {0}; Y = {1}]", X, Y);
        }

        public static Vector2 operator +(Vector2 a, Vector2 b) {
            return new Vector2(a.X + b.X, a.Y + b.Y);
        }

        public static Vector2 operator -(Vector2 a, Vector2 b) {
            return new Vector2(a.X - b.X, a.Y - b.Y);
        }

        public static Vector2 operator *(Vector2 a, int b) {
            return new Vector2(a.X * b, a.Y * b);
        }

        public static Vector2 operator *(Vector2 a, float b) {
            return new Vector2((a.X * b), (a.Y * b));
        }

        public static Vector2 operator /(Vector2 a, float b) {
            return new Vector2(a.X / b, a.Y / b);
        }

        public static implicit operator Point(Vector2 v) {
            return new Point((int)v.X, (int)v.Y);
        }

        public static implicit operator Vector2(Point p) {
            return new Vector2(p.X, p.Y);
        }

        public static implicit operator PointF(Vector2 v) {
            return new PointF(v.X, v.Y);
        }

        public static implicit operator Vector2(PointF p) {
            return new Vector2(p.X, p.Y);
        }

        public static implicit operator Size(Vector2 v) {
            return new Size((int)v.X, (int)v.Y);
        }

        public static implicit operator Vector2(Size s) {
            return new Vector2(s.Height, s.Width);
        }
    }
}
