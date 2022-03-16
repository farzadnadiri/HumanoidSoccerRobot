using System;

namespace Robot.Locomotion.TrajectoryWalk
{
    public class Vector3D
    {
        public double X { set; get; }
        public double Y { set; get; }
        public double Z { set; get; }

        public double Length
        {
            get
            {
                return Math.Sqrt(X*X + Y*Y + Z*Z);
            }
        }

        public Vector3D()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Vector3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public Vector3D(Point3D point1, Point3D point2)
        {
            X = point2.X - point1.X;
            Y = point2.Y - point1.Y;
            Z = point2.Z - point1.Z;
        }

        public Vector3D(Vector3D vector)
        {
            X = vector.X;
            Y = vector.Y;
            Z = vector.Z;
        }

        public void Normalize()
        {
            var length = Length;

            X = X / length;
            Y = Y / length;
            Z = Z / length;
        }

        public double Dot(Vector3D vector)
        {
            return (X * vector.X + Y * vector.Y + Z * vector.Z);
        }

        public Vector3D Cross(Vector3D vector)
        {
            return new Vector3D(
                Y * vector.Z - Z * vector.Y,
                Z * vector.X - X * vector.Z,
                X * vector.Y - Y * vector.X
                );
        }

        public double AngleBetween(Vector3D vector)
        {

            return Math.Acos((X * vector.X + Y * vector.Y + Z * vector.Z) / (Length * vector.Length)) * (180.0 / 3.141592);
        }

        public double AngleBetween(Vector3D vector, Vector3D axis)
        {
            double angle = AngleBetween(vector);
            Vector3D cross = Cross(vector);
            if (cross.Dot(axis) < 0.0)
                angle *= -1.0;

            return angle;
        }


        public static Vector3D operator +(Vector3D a, Vector3D vector)
        {
            return new Vector3D(a.X + vector.X, a.Y + vector.Y, a.Z + vector.Z);
        }

        public static Vector3D operator -(Vector3D a, Vector3D vector)
        {
            return new Vector3D(a.X - vector.X, a.Y - vector.Y, a.Z - vector.Z);
        }

        public static Vector3D operator +(Vector3D a, double value)
        {
            return new Vector3D(a.X + value, a.Y + value, a.Z + value);
        }

        public static Vector3D operator -(Vector3D a, double value)
        {
            return new Vector3D(a.X - value, a.Y - value, a.Z - value);
        }

        public static Vector3D operator *(Vector3D a, double value)
        {
            return new Vector3D(a.X * value, a.Y * value, a.Z * value);
        }

        public static Vector3D operator /(Vector3D a, double value)
        {
            return new Vector3D(a.X / value, a.Y / value, a.Z / value);
        }


    }
}
