using System;
using Robot.Environment.Interface;

namespace Robot.Locomotion
{
    public class Kinematics
    {
        private double _x2;
        private double _y2;
        private double _z2;
        private double _x3;
        private double _z3;
        private double _destinationFoot;
        private double _alpha;
        private double _beta1;
        private double _beta2;
        private readonly double _upperLegLinkLength;
        private readonly double _lowerLegLinkLength;

        private object _key;


        public Kinematics(IBody body)
        {
            _upperLegLinkLength = body.ThighLength / 10;
            _lowerLegLinkLength = body.CalfLength / 10;
            _key = new object();
        }

        public Kinematics(double upperlink, double lowerlink)
        {
            _upperLegLinkLength = upperlink;
            _lowerLegLinkLength = lowerlink;
            _key = new object();
        }

        public double HipYaw
        {
            get;
            private set;
        }

        public double HipRoll
        {
            get;
            private set;
        }

        public double AnkleRoll
        {
            get;
            private set;
        }
        public double HipPitch
        {
            get;
            private set;
        }

        public double Knee
        {
            get;
            private set;
        }

        public double AnklePitch
        {
            get;
            private set;
        }


        public void Foot(double x1, double y1, double z1, double yaw)
        {
            lock (_key)
            {
                HipYaw = yaw;

                _x2 = (x1 * Utils.Math.Cos(yaw)) + (y1 * Utils.Math.Sin(yaw));
                _y2 = (x1 * Utils.Math.Sin(yaw)) + (y1 * Utils.Math.Cos(yaw));
                _z2 = z1;

                HipRoll = Utils.Math.ArcTan(_y2 / _z2);
                AnkleRoll = HipRoll;

                _x3 = _x2;

                _z3 = Math.Sqrt(Math.Pow(_y2, 2) + Math.Pow(_z2, 2));
                _destinationFoot = Math.Sqrt(Math.Pow(_z3, 2) + Math.Pow(_x3, 2));

                _alpha = Utils.Math.ArcTan(_x3 / _z3);
                _beta1 = Utils.Math.ArcCos(_destinationFoot / (2 * _upperLegLinkLength));
                _beta2 = Utils.Math.ArcSin((_lowerLegLinkLength / _upperLegLinkLength) * Utils.Math.Sin(_beta1));

                HipPitch = _alpha + _beta1;
                Knee = -(_beta1 + _beta2);
                AnklePitch = -(-_alpha + _beta2);
            }
        }
    }
}
