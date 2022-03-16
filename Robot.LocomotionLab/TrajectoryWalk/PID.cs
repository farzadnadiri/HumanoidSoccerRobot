using System;

namespace Robot.Locomotion.TrajectoryWalk
{

    public class PID
    {
        public double Kp { set; get; }
        public double Kd { set; get; }
        public double Ki { set; get; }

        public double Max { set; get; }
        public double Min { set; get; }

        private double _preError;
        private double _integral;

        public double _error
            ;
        private double _derivative;

        private double Clamp(double value, double min, double max)
        {
            if (value > max)
                return max;
            if (value < min)
                return min;
            return value;
        }

        public double Calculate(double desiredPoint, double actualPoint, double dt)
        {
            /*
            * Pseudo code (source Wikipedia)
            * 
              previous_error = 0
              integral = 0 
              start:
              error = setpoint – PV [actual_position]
              integral = integral + error*dt
              derivative = (error - previous_error)/dt
              output = Kp*error + Ki*integral + Kd*derivative
              previous_error = error
              wait(dt)
              goto start
            */

            _error = desiredPoint - actualPoint;

            _integral = _integral + (_error * dt);
            _derivative = (_error - _preError) / dt;

            double output = (Kp * _error) + (Ki * _integral) + (Kd * _derivative);
            //output = Clamp(output, Min, Max);

            _preError = _error;
            return output;
        }
    }
}
