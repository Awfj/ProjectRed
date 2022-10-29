using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRed
{
    internal class Character : MovingObject
    {
        protected bool[] mInputs;
        protected bool[] mPrevInputs;

        public CharacterState mCurrentState = CharacterState.Stand;
        public float mJumpSpeed;
        public float mWalkSpeed;

        protected bool Released(KeyInput key)
        {
            return (!mInputs[(int)key] && mPrevInputs[(int)key]);
        }

        protected bool KeyState(KeyInput key)
        {
            return mInputs[(int)key];
        }

        protected bool Pressed(KeyInput key)
        {
            return (mInputs[(int)key] && !mPrevInputs[(int)key]);
        }

        public enum KeyInput
        {
            GoLeft = 0,
            GoRight,
            GoDown,
            Jump,
            Count
        }

        public enum CharacterState
        {
            Stand,
            Sit,
            Walk,
            Jump,
        }

        public void CharacterUpdate()
        {
            switch (mCurrentState)
            {
                case CharacterState.Stand:
                    break;
                case CharacterState.Sit:
                    break;
                case CharacterState.Walk:
                    break;
                case CharacterState.Jump:
                    break;
            }
        }
    }
}
