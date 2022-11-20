using Microsoft.Xna.Framework;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRed
{
    internal class FrameSelector
    {
        internal List<Rectangle> frames;
        private float fps;
        internal int currentFrameID;
        private bool loopBack;

        internal FrameSelector(float fps, List<Rectangle> frames, bool loop = true)
        {
            this.fps = fps;
            this.frames = frames;
            currentFrameID = 0;
            loopBack = loop;
        }
        internal Rectangle GetFrame(ref float dt)
        {
            if (dt > fps)
            {
                dt = 0;
                currentFrameID++;

                if (currentFrameID >= frames.Count && loopBack)
                {
                    currentFrameID = 0;
                }
            }
            return frames[currentFrameID];
        }
    }
}
