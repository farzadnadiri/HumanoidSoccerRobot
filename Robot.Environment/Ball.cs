using System.Drawing;
using Robot.Environment.Color;

namespace Robot.Environment
{
    public class Ball
    {
        public Point Location;
        public int FoundTime { set; get; }
        public int LostTime
        {
            set;
            get;
        }

        public ColorSpace Color
        {
            set;
            get;
        }
        public ColorSpace Color2
        {
            set;
            get;
        }
        public ColorSpace Color3
        {
            set;
            get;
        }
        public ColorSpace Color4
        {
            set;
            get;
        }

        public bool IsDetected { 
            set;
            get;
        }
        public int Size
        {
            set;
            get;
        }

        public int Distance
        {
            set;
            get;
        }
        public Ball()
        {
            Color = new ColorSpace();
            Color2 = new ColorSpace();
            Color3 = new ColorSpace();
            Color4 = new ColorSpace();
        }

        public Ball(string path)
        {
            Color = new ColorSpace(path);
        }

    }
}
