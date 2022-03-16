namespace Robot.IO
{
    public class Specification
    {
        public int PositionResolution
        {
            set;
            get;
        }
        public int SpeedResolution
        {
            set;
            get;
        }
        public int AngleResolution
        {
            set;
            get;
        }
        public double Rpm
        {
            set;
            get;
        }
        public Specification(double rpm, int positionResolution, int speedResolution, int angleResolution)
        {
            Rpm = rpm;
            PositionResolution = positionResolution;
            SpeedResolution = speedResolution;
            AngleResolution = angleResolution;
        }
        public Specification Copy()
        {
            return new Specification(Rpm, PositionResolution, SpeedResolution, AngleResolution);
        }
    }
}
