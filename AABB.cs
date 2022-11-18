using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRed
{
    //public struct AABB
    public class AABB
    {
        public Vector2 center;
        public Vector2 halfSize;

        public AABB(Vector2 center, Vector2 halfSize)
        {
            this.center = center;
            this.halfSize = halfSize;
        }

        public bool Overlaps(AABB other)
        {
            if (Math.Abs(center.X - other.center.X) > halfSize.X + other.halfSize.X ||
                Math.Abs(center.Y - other.center.Y) > halfSize.Y + other.halfSize.Y)
            {
                return false;
            }
            return true;
        }
    }
}
