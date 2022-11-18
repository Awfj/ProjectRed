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
        public Vector2 mOldPosition;
        public Vector2 mPosition;

        public Vector2 mOldSpeed;
        public Vector2 mSpeed;

        public Vector2 mScale;

        public AABB mAABB;
        public Vector2 mAABBOffset;

        public bool mPushedRightWall;
        public bool mPushesRightWall;
        
        public bool mPushedLeftWall;
        public bool mPushesLeftWall;

        public bool mWasOnGround;
        public bool mOnGround;

        public bool mWasOnCeiling;
        public bool mArCeiing;

        public void UpdatePhysics()
        {
            mOldPosition = mPosition;
            mOldSpeed = mSpeed;

            mWasOnGround = mOnGround;
            mPushedRightWall = mPushesRightWall;
            mPushedLeftWall = mPushesLeftWall;

            //mPosition += mSpeed * Time.deltaTIme;

            if (mPosition.Y < 0.0f)
            {
                mPosition.Y = 0.0f;
                mOnGround = true;
            }
            else mOnGround = false;

            mAABB.center = mPosition + mAABBOffset;
        }
    }
}
