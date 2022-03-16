namespace Robot.Locomotion.TrajectoryWalk
{
    public class NewControl
    {
        private bool _isFirst;
        private double _previousValue;

        public double GyroError { set; get; }
        public double GetGyroError(double measuredValue)
        {
            if (_isFirst)
            {
                _isFirst = false;
                _previousValue = measuredValue;
                return 0;
            }
            var error = measuredValue - _previousValue;
            GyroError = error;
            _previousValue = measuredValue;
            return error;
        }

        //public double GetGyroError(double measuredValue, double dt)
        //{
        //    if (_isFirst)
        //    {
        //        _isFirst = false;
        //        _previousValue = measuredValue;
        //        return 0;
        //    }
        //    var error = measuredValue - _previousValue;

        //    _derivative = (error - _preError) / dt;

        //    _preError = error;
        //    GyroError = error;
        //    _previousValue = measuredValue;

        //    Out = Kp * _error + Kd * _derivative;
        //    return Out;
        //}
    }
}
