
namespace Robot.Probabilistics.Filter
{
    public class Kalman
    {
        public double A { set; get; } // state transition model
        public double B { set; get; } // control-input model - No Model ! 
        public double Q { set; get; } // process noise covariance 
        public double R { set; get; } // measurment noise covariance 
        public double H { set; get; } // observation model
        public double P { set; get; } // Error Covariance

        private double _k;
        private double _x;

        public Kalman(double initialValue, double a, double h, double p, double q, double r)
        {
            A = a;
            H = h;
            P = p;
            Q = q;
            R = r;
            _x = initialValue;
        }

        public double Apply(double z)
        {

            //time update - prediction

            _x = A * _x;
            P = A * P * A + Q;

            //measurement update - correction

            _k = P * H / (H * P * H + R);
            _x = _x + _k * (z - H * _x);
            P = (1 - _k * H) * P;

            return _x;
        }

    }
}
