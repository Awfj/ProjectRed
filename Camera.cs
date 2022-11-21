using Microsoft.Xna.Framework;

namespace ProjectRed
{
    internal class Camera
    {
        internal float Zoom { get; set; }
        internal Matrix Transform { get; set; }
        internal Vector2 position;
        internal int LeftRestrict { get; private set; }

        internal Camera()
        {
            Zoom = 2.0f;
            position = Vector2.Zero;
            LeftRestrict = 0;
        }

        internal Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        internal void UpdateLoopPosition(Rectangle mario)
        {
            position.X = mario.Left - Constants.viewWidth / (2 * Zoom);
            position.Y = 0;
            if (position.X <= LeftRestrict) position.X = LeftRestrict;
            LeftRestrict = (int)position.X;
        }

        internal void Update()
        {
            Transform = Matrix.CreateTranslation(-position.X, -position.Y, 0) * 
                Matrix.CreateScale(new Vector3(Zoom, Zoom, 1));
        }
    }
}
