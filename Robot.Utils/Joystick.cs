using System.Collections.Generic;
using SlimDX.DirectInput;


namespace Robot.Utils
{
    public class Joystick
    {

        private int _min;
        private int _max;
        private int _middle;
        private readonly List<DeviceInstance> _devicelist;
        private readonly DirectInput _input;
        private readonly SlimDX.DirectInput.Joystick _joyStick;
        private JoystickState _state;
        private bool[] _buttonState;
        private int _deviceindex;

        #region Properties
        public int Min
        {
            get { return _min; }
            set { _min = value; }
        }

        public int Max
        {
            get { return _max; }
            set { _max = value; }
        }

        public int Middle
        {
            get { return _middle; }
            set { _middle = value; }
        }

        public int DefultButtonCount
        {
            get;
            set;
        }

        public int DeviceIndex
        {
            get { return _deviceindex; }
            set
            {
                if (value >= 0)
                {
                    _deviceindex = value;
                }
            }
        }

        public bool Number1
        {
            get { return _buttonState[0]; }
        }

        public bool Number2
        {
            get { return _buttonState[1]; }
        }

        public bool Number3
        {
            get { return _buttonState[2]; }
        }

        public bool Number4
        {
            get { return _buttonState[3]; }
        }

        public bool L1
        {
            get { return _buttonState[4]; }
        }

        public bool R1
        {
            get { return _buttonState[5]; }
        }

        public bool L2
        {
            get { return _buttonState[6]; }
        }

        public bool R2
        {
            get { return _buttonState[7]; }
        }

        public bool StartButton
        {
            get { return _buttonState[9]; }
        }

        public bool StopButton
        {
            get { return _buttonState[8]; }
        }

        public bool Left
        {
            get
            {
                if (_state.X == _min && _state.Y == _middle)
                {
                    return true;
                }
                return false;
            }
        }

        public bool Right
        {
            get
            {
                if (_state.X == _max && _state.Y == _middle)
                {
                    return true;
                }
                return false;
            }
        }

        public bool Up
        {
            get
            {
                if (_state.Y == _min && _state.X == _middle)
                {
                    return true;
                }
                return false;
            }
        }

        public bool Down
        {
            get
            {
                if (_state.Y == _max && _state.X == _middle)
                {
                    return true;
                }
                return false;
            }
        }

        public bool UpperLeft
        {
            get
            {
                if (_state.X == _min && _state.Y == _min)
                {
                    return true;
                }
                return false;
            }
        }

        public bool UpperRight
        {
            get
            {
                if (_state.X == _max && _state.Y == _min)
                {
                    return true;
                }
                return false;
            }
        }

        public bool LowerLeft
        {
            get
            {
                if (_state.X == _min && _state.Y == _max)
                {
                    return true;
                }
                return false;
            }
        }

        public bool LowerRight
        {
            get
            {
                if (_state.X == _max && _state.Y == _max)
                {
                    return true;
                }
                return false;
            }
        }

        public bool Center
        {
            get
            {
                if (_state.X == _middle && _state.Y == _middle)
                {
                    return true;
                }
                return false;
            }
        }
        #endregion

        private readonly bool _initialized;
        public bool Initialized
        {
            get { return _initialized; }
        }



        public Joystick(int deviceIndex = 0, int max = 65535, int min = 0, int middle = 32511)
        {
            _devicelist = new List<DeviceInstance>();
            _state = new JoystickState();
            _input = new DirectInput();

            Max = max;
            Min = min;
            Middle = middle;
            DeviceIndex = deviceIndex;

            try
            {

                _devicelist.AddRange(_input.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AttachedOnly));
                _joyStick = new SlimDX.DirectInput.Joystick(_input, _devicelist[DeviceIndex].InstanceGuid);
                _joyStick.Acquire();
                _state = new JoystickState();
                _initialized = true;

            }
            catch
            {
                _initialized = false;
            }
        }

        public void UpdateState()
        {
            if (Initialized)
            {
                _joyStick.GetCurrentState(ref _state);
                _buttonState = _state.GetButtons();
            }
        }

    }
}
