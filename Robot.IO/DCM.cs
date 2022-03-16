
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Thread = Robot.Utils.Thread;

namespace Robot.IO
{
    public class DCM
    {
        private object _key;
        private List<IActuator> _actuatorList;
        private Thread _updateLoop;
        private DynamixelBus _bus;

        public int Interval
        {
            set
            {
                lock (_key)
                {
                    _updateLoop.Interval = value;
                }
            }
            get
            {
                lock (_key)
                {
                    return _updateLoop.Interval;
                }
            }
        }

        public bool Enable
        {
            set
            {
                lock (_key)
                {
                    if (value)
                    {
                        if (!_updateLoop.IsEnable)
                        {
                            _updateLoop.Start();
                        }
                    }
                    else
                    {
                        if (_updateLoop.IsEnable)
                        {
                            _updateLoop.Stop(false, false);
                        }
                    }
                }
            }
            get
            {
                lock (_key)
                {
                    return _updateLoop.IsEnable;
                }
            }
        }

        public DCM(DynamixelBus bus, int interval = 10)
        {
            _bus = bus;
            _key = new object();
            _actuatorList = new List<IActuator>();
            _updateLoop = new Thread(UpdateCallBack, ThreadPriority.Highest, interval);
        }

        public DCM(DynamixelBus bus, IEnumerable<IActuator> devices, int interval = 10)
        {
            _bus = bus;
            _key = new object();
            _actuatorList = new List<IActuator>();
            _updateLoop = new Thread(UpdateCallBack, ThreadPriority.Highest, interval);

            lock (_key)
            {
                foreach (IActuator actuator in devices)
                {
                    _actuatorList.Add(actuator);
                }
            }
        }

        public void Add(IActuator actuator)
        {
            lock (_key)
            {
                _actuatorList.Add(actuator);
            }
        }

        public void AddRange(IEnumerable<IActuator> devices)
        {
            lock (_key)
            {
                foreach (IActuator actuator in devices)
                {
                    _actuatorList.Add(actuator);
                }
            }
        }

        public void Remove(IActuator actuator)
        {
            lock (_key)
            {
                _actuatorList.Remove(actuator);
            }
        }

        private void UpdateCallBack()
        {
            if ((_bus != null) && (_actuatorList != null) && (_actuatorList.Capacity > 0))
            {
                _bus.SetSpeedPosition(_actuatorList);
            }

        }
    }
}
