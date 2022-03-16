using System;
using Robot.Environment.Interface;

namespace Robot.Locomotion.TrajectoryWalk
{
    public class Kinematics
    {
        public double ThighLength;// = 198.0; //mm
        public double CalfLength;// = 200.0; //mm
        public double AnkleLength;// = 45.0;//mm
        public double LegLength;

        public Kinematics(IBody body)
        {
            ThighLength = body.ThighLength;
            CalfLength = body.CalfLength;
            AnkleLength = body.AnkleLength;
            LegLength = body.LegLength;
        }

        public bool ComputeIk(ref double[] output, double x, double y, double z, double a, double b, double c)
        {
            var Tad = new Matrix3D();
            var Tda = new Matrix3D();
            var Tcd = new Matrix3D();
            var Tdc = new Matrix3D();
            var Tac = new Matrix3D();
            var vec = new Vector3D();
            double _Rac, _Acos, _Atan, _k, _l, _m, _n, _s, _c, _theta;


            Tad.SetTransform(new Point3D(x, y, z - LegLength), new Vector3D(a * 180.0 / Math.PI, b * 180.0 / Math.PI, c * 180.0 / Math.PI));

            vec.X = x + Tad.M[2] * AnkleLength;
            vec.Y = y + Tad.M[6] * AnkleLength;
            vec.Z = (z - LegLength) + Tad.M[10] * AnkleLength;

            // Get Knee

            _Rac = vec.Length;
            _Acos = Math.Acos((_Rac * _Rac - ThighLength * ThighLength - CalfLength * CalfLength) / (2 * ThighLength * CalfLength));
            if (Double.IsNaN(_Acos))
                return false;
            output[3] = _Acos;

            // Get Ankle Roll
            Tda = Tad;
            if (Tda.Inverse() == false)
                return false;
            _k = Math.Sqrt(Tda.M[7] * Tda.M[7] + Tda.M[11] * Tda.M[11]);
            _l = Math.Sqrt(Tda.M[7] * Tda.M[7] + (Tda.M[11] - AnkleLength) * (Tda.M[11] - AnkleLength));
            _m = (_k * _k - _l * _l - AnkleLength * AnkleLength) / (2 * _l * AnkleLength);
            if (_m > 1.0)
                _m = 1.0;
            else if (_m < -1.0)
                _m = -1.0;
            _Acos = Math.Acos(_m);
            if (Double.IsNaN(_Acos))
                return false;
            if (Tda.M[7] < 0.0)
                output[5] = -_Acos;
            else
                output[5] = _Acos;

            // Get Hip Yaw
            Tcd.SetTransform(new Point3D(0, 0, -AnkleLength), new Vector3D(output[5] * 180.0 / Math.PI, 0, 0));
            Tdc = Tcd;
            if (Tdc.Inverse() == false)
                return false;
            Tac = Tad * Tdc;
            _Atan = Math.Atan2(-Tac.M[1], Tac.M[5]);
            if (Double.IsInfinity(_Atan))
                return false;
            output[0] = _Atan;

            // Get Hip Roll
            _Atan = Math.Atan2(Tac.M[9], -Tac.M[1] * Math.Sin(output[0]) + Tac.M[5] * Math.Cos(output[0]));
            if (Double.IsInfinity(_Atan))
                return false;
            output[1] = _Atan;

            // Get Hip Pitch and Ankle Pitch
            _Atan = Math.Atan2(Tac.M[2] * Math.Cos(output[0]) + Tac.M[6] * Math.Sin(output[0]), Tac.M[0] * Math.Cos(output[0]) + Tac.M[4] * Math.Sin(output[0]));
            if (Double.IsInfinity(_Atan))
                return false;
            _theta = _Atan;
            _k = Math.Sin(output[3]) * CalfLength;
            _l = -ThighLength - Math.Cos(output[3]) * CalfLength;
            _m = Math.Cos(output[0]) * vec.X + Math.Sin(output[0]) * vec.Y;
            _n = Math.Cos(output[1]) * vec.Z + Math.Sin(output[0]) * Math.Sin(output[1]) * vec.X - Math.Cos(output[0]) * Math.Sin(output[1]) * vec.Y;
            _s = (_k * _n + _l * _m) / (_k * _k + _l * _l);
            _c = (_n - _k * _s) / _l;
            _Atan = Math.Atan2(_s, _c);
            if (Double.IsInfinity(_Atan))
                return false;
            output[2] = _Atan;
            output[4] = _theta - output[3] - output[2];

            return true;
        }
    }
}
