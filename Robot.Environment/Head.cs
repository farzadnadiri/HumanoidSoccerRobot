using Robot.Environment.Interface;
using Robot.IO;
using Robot.Utils;

namespace Robot.Environment
{
    public class Head : IHead
    {

        public Head(IActuator pan, IActuator tilt)
        {
            Pan = pan;
            Tilt = tilt;
        }

        public Head(DynamixelBus bus,int panId, Model panModel, int tiltId, Model tiltModel)
        {
            Pan = new Actuator(bus,panId, panModel);
            Tilt = new Actuator(bus,tiltId, tiltModel);
        }

        public Head(DynamixelBus bus,int panId, Model panModel, int tiltId, Model tiltModel, Range<int> panBounday, Range<int> tiltBounday)
        {
            Pan = new Actuator(bus,panId, panModel);
            Tilt = new Actuator(bus,tiltId, tiltModel);
            Pan.PositionBoundary = panBounday;
            Tilt.PositionBoundary = tiltBounday;

        }

        public double Direction
        {
            get { return Pan.Angle; }
        }

        public IActuator Pan
        {
            set;
            get;
        }

        public IActuator Tilt
        {
            set;
            get;
        }

    }
}
