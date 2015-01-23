using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DoozyEngine.Utils
{
    public class RectangleUtils
    {
        public static Rectangle Multiply(Rectangle prime, int factor)
        {
            prime.X *= factor;
            prime.Y *= factor;
            prime.Height *= factor;
            prime.Width *= factor;

            return prime;
        }

        public static bool VectorIntersects(Vector2 vector, Rectangle prime)
        {
            if (vector.X >= prime.X && vector.X <= (prime.X + prime.Width) &&
                    vector.Y >= prime.Y && vector.Y <= (prime.Y + prime.Height))
                return true;
            return false;
        }

    }
}
