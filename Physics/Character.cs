using SharpDX.Direct2D1.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRed
{
    internal class Character : MovingObject
    {
        protected bool[] inputs;
        protected bool[] prevInputs;

        public CharacterState currentState = CharacterState.Stand;
        public float jumpSpeed;
        public float walkSpeed;

        protected bool Released(KeyInput key)
        {
            return (!inputs[(int)key] && prevInputs[(int)key]);
        }

        protected bool KeyState(KeyInput key)
        {
            return inputs[(int)key];
        }

        protected bool Pressed(KeyInput key)
        {
            return (inputs[(int)key] && !prevInputs[(int)key]);
        }

        public enum KeyInput
        {
            GoLeft = 'A',
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
            switch (currentState)
            {
                case CharacterState.Stand:
                    speed = Vector2.Zero;
                    break;
                case CharacterState.Sit:
                    break;
                case CharacterState.Walk:
                    if (KeyState(KeyInput.GoRight) == KeyState(KeyInput.GoLeft))
                    {
                        currentState = CharacterState.Stand;
                        speed = Vector2.Zero;
                        break;
                    }
                    else if (KeyState(KeyInput.GoRight))
                    {
                        if (pushesRightWall)
                            speed.X = 0.0f;
                        else
                            speed.X = walkSpeed;
                        scale.X = -Math.Abs(scale.X);
                    }
                    else if (KeyState(KeyInput.GoLeft))
                    {
                        if (pushesLeftWall)
                            speed.X = 0.0f;
                        else
                            speed.X = -walkSpeed;
                        scale.X = Math.Abs(scale.X);
                    }
                    break;
                case CharacterState.Jump:
                    break;
            }
        }
        public void CharacterInit(bool[] inpus, bool[] prevInputs)
        {

        }
    }
}
