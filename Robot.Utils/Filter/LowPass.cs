
namespace Robot.Probabilistics.Filter
{
    public class LowPass
    {
        private double _previousValue;
        public double Gain
        {
            set;
            get;
        }

        private bool _isFirst;
        public LowPass(double gain)
        {
            Gain = gain;
            _isFirst = true;
        }

        public void Reset()
        {
            _isFirst = true;
        }
        public double Apply(double input)
        {

            if (_isFirst)
            {
                _isFirst = false;
                _previousValue = input;
                return 0;
            }

            _previousValue = Gain * input + (1 - Gain) * _previousValue;

            return _previousValue;
        }
    }
}
