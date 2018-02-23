using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Util {
    public class Vector2D {
        float x;
        float y;

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

        public void Zero() {
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


        public static Vector2D operator +(Vector2D a, Vector2D b) {
            return new Vector2D(a.x + b.x, a.y + b.y);
        }

        //public static Vector2D operator +=(Vector2D a) {
        //    x += a.x;
        //    y += a.y;

        //    return this;
        //}

        public static Vector2D operator *(Vector2D v, float f) {
            return new Vector2D(v.x * f, v.y * f);
        }
        public static Vector2D operator *(float f, Vector2D v) {
            return new Vector2D(v.x * f, v.y * f);
        }
    }
}
