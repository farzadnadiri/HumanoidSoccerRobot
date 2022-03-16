
namespace Robot.Environment
{
    public class Posture
    {
        private readonly int[] _angels;
        public int this[int i]
        {
            set { _angels[i] = value; }
            get { return _angels[i]; }
        }

        public int Count
        {
            get { return _angels.Length; }
        }

        public Posture(int jointsCount)
        {
            _angels = new int[jointsCount];
            MakeDefault();
        }

        public Posture(Posture a)
        {
            _angels = new int[a.Count];
            MakeDefault();
            for (int i = 0; i < a.Count; i++)
            {
                _angels[i] = a[i];
            }
        }

        public Posture(int[] a)
        {
            _angels = new int[a.Length];
            MakeDefault();
            for (int i = 0; i < a.Length; i++)
            {
                _angels[i] = a[i];
            }
        }

        private const int DefaultAngle = 0;
        public void MakeDefault()
        {
            for (int i = 0; i < _angels.Length; i++)
            {
                _angels[i] = DefaultAngle;
            }
        }

        public void Mirror()
        {
            for (int i = 0; i < _angels.Length - 1; i += 2)
            {
                int delta1 = _angels[i];
                int delta2 = _angels[i + 1];
                _angels[i] = -delta2;
                _angels[i + 1] = -delta1;
            }
        }
        public int[] ToArray()
        {
            return _angels;
        }
    }
}
