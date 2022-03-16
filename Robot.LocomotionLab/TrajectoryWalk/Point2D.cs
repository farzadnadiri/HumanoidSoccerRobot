using System;

namespace Robot.Locomotion.TrajectoryWalk
{
    class Point2D
    {
        public double X { set; get; }
        public double Y { set; get; }
     

        public Point2D()
        {
            X = 0;
            Y = 0;
        }

        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point2D(Point2D point)
        {
            X = point.X;
            Y = point.Y;
        }

        public static double Distance(Point2D pt1, Point2D pt2)
        {
            double x = pt1.X - pt2.X;
            double y = pt1.Y - pt2.Y;
            return Math.Sqrt(x * x + y * y);
        }

        public static Point2D operator +(Point2D a, Point2D point)
        {
            return new Point2D(a.X + point.X, a.Y + point.Y);
        }

        public static Point2D operator -(Point2D a, Point2D point)
        {
            return new Point2D(a.X - point.X, a.Y - point.Y);
        }

        public static Point2D operator +(Point2D a, double value)
        {
            return new Point2D(a.X + value, a.Y + value);
        }

        public static Point2D operator -(Point2D a, double value)
        {
            return new Point2D(a.X - value, a.Y - value);
        }

        public static Point2D operator *(Point2D a, double value)
        {
            return new Point2D(a.X * value, a.Y * value);
        }

        public static Point2D operator /(Point2D a, double value)
        {
            return new Point2D(a.X / value, a.Y / value);
        }
    }
}
