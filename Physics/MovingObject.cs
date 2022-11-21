using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static ProjectRed.Physics;

namespace ProjectRed
{
    public class MovingObject
    {
        public Vector2 oldPosition;
        public Vector2 position;

        public Vector2 oldSpeed;
        public Vector2 speed;

        public Vector2 scale;

        public AABB boundingBox;
        public Vector2 boundingBoxOffset;

        public bool pushedRightWall;
        public bool pushesRightWall;
        
        public bool pushedLeftWall;
        public bool pushesLeftWall;

        public bool wasOnGround;
        public bool onGround;

        public void UpdatePhysics()
        {
            oldPosition = position;
            oldSpeed = speed;

            wasOnGround = onGround;
            pushedRightWall = pushesRightWall;
            pushedLeftWall = pushesLeftWall;

            //mPosition += mSpeed * Time.deltaTIme;

            if (position.Y < 0.0f)
            {
                position.Y = 0.0f;
                onGround = true;
            }
            else onGround = false;

            boundingBox.center = position + boundingBoxOffset;
        }
    }
}
