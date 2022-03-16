
using System;

namespace Robot.Locomotion.TrajectoryWalk
{
    public class Point3D
    {
        public double X { set; get; }
        public double Y { set; get; }
        public double Z { set; get; }

        public Point3D()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point3D(Point3D point)
        {
            X = point.X;
            Y = point.Y;
            Z = point.Z;
        }

        public static double Distance(Point3D pt1, Point3D pt2)
        {
            double x = pt1.X - pt2.X;
            double y = pt1.Y - pt2.Y;
            double z = pt1.Z - pt2.Z;
            return Math.Sqrt(x * x + y * y + z * z);
        }

        public static Point3D operator +(Point3D a, Point3D point)
        {
            return new Point3D(a.X + point.X, a.Y + point.Y, a.Z + point.Z);
        }

        public static Point3D operator -(Point3D a, Point3D point)
        {
            return new Point3D(a.X - point.X, a.Y - point.Y, a.Z - point.Z);
        }

        public static Point3D operator +(Point3D a, double value)
        {
            return new Point3D(a.X + value, a.Y + value, a.Z + value);
        }

        public static Point3D operator -(Point3D a, double value)
        {
            return new Point3D(a.X - value, a.Y - value, a.Z - value);
        }

        public static Point3D operator *(Point3D a, double value)
        {
            return new Point3D(a.X * value, a.Y * value, a.Z * value);
        }

        public static Point3D operator /(Point3D a, double value)
        {
            return new Point3D(a.X / value, a.Y / value, a.Z / value);
        }
    }
}
