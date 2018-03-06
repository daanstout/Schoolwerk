using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Util {
    public class Vector2D {
        public float x;
        public float y;

        public Vector2D() {
            x = y = 0.0f;
        }

        public Vector2D(Vector2D vec) {
            x = vec.x;
            y = vec.y;
        }

        public Vector2D(float a, float b) {
            x = a;
            y = b;
        }

        public void SetZero() {
            x = y = 0.0f;
        }

        public bool isZero() {
            return x == 0 && y == 0;
        }

        public float Length() {
            return (float)Math.Sqrt(x * x + y * y);
        }

        public float LengthSq() {
            return (x * x + y * y);
        }

        public float Dot(Vector2D other) {
            return x * other.x + y * other.y;
        }

        public void Normalize() {
            float vectorLength = Length();
            x /= vectorLength;
            y /= vectorLength;
        }

        public int Sign(Vector2D other) {
            if (y * other.x > x * other.y)
                return -1;
            else
                return 1;
        }

        public Vector2D Perp() {
            return new Vector2D(-y, x);
        }

        public void Truncate(float max) {
            if (Length() > max) {
                Normalize();

                x *= max;
                y *= max;
            }
        }

        public float Distance(Vector2D other) {
            float dx = other.x - x;
            float dy = other.y - y;

            return (float)Math.Sqrt(dy * dy + dx * dx);
        }

        public float DistanceSq(Vector2D other) {
            float dx = other.x - x;
            float dy = other.y - y;

            return (dy * dy + dx * dx);
        }

        public void Reflect(Vector2D norm) {
            Vector2D result = new Vector2D(this);
            result += 2 * Dot(norm) * norm.GetReverse();
            x = result.x;
            y = result.y;
        }

        public Vector2D GetReverse() {
            return new Vector2D(-x, -y);
        }

        public void WrapAround(int maxX, int maxY) {
            if (x > maxX)
                x = 0;
            if (x < 0)
                x = maxX;

            if (y > maxY)
                y = 0;
            if (y < 0)
                y = maxY;
        }

        public bool NotInsideRegion(Vector2D top_left, Vector2D bot_rgt) {
            return (x < top_left.x) || (x > bot_rgt.x) || (y < top_left.y) || (y > bot_rgt.y);
        }

        public bool InsideRegion(Vector2D top_left, Vector2D bot_rgt) {
            return !((x < top_left.x) || (x > bot_rgt.x) || (y < top_left.y) || (y > bot_rgt.y));
        }

        public bool isSecondInFOVOfFirst(Vector2D posFirst, Vector2D facingFirst, Vector2D posSecond, float fov) {
            Vector2D toTarget = Vec2DNormalize(posSecond - posFirst);

            return facingFirst.Dot(toTarget) >= Math.Cos(fov / 2);
        }

        public static Vector2D Vec2DNormalize(Vector2D v) {
            Vector2D vec = v;

            float vector_length = vec.Length();

            vec.x /= vector_length;
            vec.y /= vector_length;

            return vec;
        }

        public static float Vec2DDistance(Vector2D v1, Vector2D v2) {
            float ySep = v2.y - v1.y;
            float xSep = v2.x - v1.x;

            return (float)Math.Sqrt(ySep * ySep + xSep * xSep);
        }

        public static float Vec2DDistanceSq(Vector2D v1, Vector2D v2) {
            float ySep = v2.y - v1.y;
            float xSep = v2.x - v1.x;

            return ySep * ySep + xSep * xSep;
        }

        public static float Vec2DLength(Vector2D v) {
            return (float)Math.Sqrt(v.x * v.x + v.y * v.y);
        }

        public static float Vec2DLengthSq(Vector2D v) {
            return v.x * v.x + v.y * v.y;
        }

        public static Vector2D operator +(Vector2D a, Vector2D b) {
            return new Vector2D(a.x + b.x, a.y + b.y);
        }

        public static Vector2D operator -(Vector2D a, Vector2D b) {
            return new Vector2D(a.x - b.x, a.y - b.y);
        }

        public static Vector2D operator *(Vector2D v, float f) {
            return new Vector2D(v.x * f, v.y * f);
        }
        public static Vector2D operator *(float f, Vector2D v) {
            return new Vector2D(v.x * f, v.y * f);
        }

        public static Vector2D operator /(Vector2D v, float f) {
            return new Vector2D(v.x / f, v.y / f);
        }

        public static Vector2D operator /(float f, Vector2D v) {
            return new Vector2D(v.x / f, v.y / f);
        }

        public static implicit operator Point(Vector2D v) {
            return new Point((int)v.x, (int)v.y);
        }

        public static implicit operator Vector2D(Point p) {
            return new Vector2D(p.X, p.Y);
        }

        public static implicit operator PointF(Vector2D v) {
            return new PointF(v.x, v.y);
        }

        public static implicit operator Vector2D(PointF p) {
            return new Vector2D(p.X, p.Y);
        }

        public static implicit operator Size(Vector2D v) {
            return new Size((int)v.x, (int)v.y);
        }

        public static implicit operator Vector2D(Size s) {
            return new Vector2D(s.Width, s.Height);
        }

        public static implicit operator SizeF(Vector2D v) {
            return new SizeF(v.x, v.y);
        }

        public static readonly Vector2D Up = new Vector2D(0, -1);
        public static readonly Vector2D Right = new Vector2D(1, 0);
        public static readonly Vector2D Down = new Vector2D(0, 1);
        public static readonly Vector2D Left = new Vector2D(-1, 0);
        public static readonly Vector2D Zero = new Vector2D(0, 0);

        public override bool Equals(object obj) {
            if (obj == null)
                return false;
            else if (obj is Vector2D v)
                return (x.Equals(v.x) && y.Equals(v.y));
            else
                return false;
        }

        public override int GetHashCode() {
            var hashCode = 1502939027;
            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + y.GetHashCode();
            return hashCode;
        }

        public override string ToString() {
            return String.Format("[{0}, {1}]", x, y);
        }
    }
}
