using System;
using Robot.Utils;
using Math = System.Math;

namespace Robot.IO
{
    public class Actuator : IActuator
    {
        private const int SecondPerMinute = 60;
        private const int DegreePerRound = 360;
        private object _key;

        private readonly DynamixelBus _bus;

        /// <summary>
        /// Dynamixel Actuator Object
        /// </summary>
        /// <param name="bus">Actuator Bus</param>
        /// <param name="id">Actuator ID</param>
        /// <param name="model">Actuator Model</param>
        /// <param name="autoflush"></param>
        public Actuator(DynamixelBus bus, int id, Model model, bool autoflush = false)
        {
            _key = new object();

            _bus = bus;
            _specification = DataSheet.GetSpecification(model);
            _id = id;
            _model = model;
            _center = Convert.ToInt32(_specification.PositionResolution / 2);

            _degreePerDynamixel = _specification.AngleResolution / ((double)_specification.PositionResolution);
            _dynamixelPerDegree = _specification.PositionResolution / ((double)_specification.AngleResolution);
            _angleBoundary = new Range<double>(-(_specification.AngleResolution / 2), +(_specification.AngleResolution / 2));
            _speedBoundary = new Range<int>(1, _specification.SpeedResolution - 1);
            _positionBoundary = new Range<int>(0, _specification.PositionResolution - 1);
            _autoFlush = autoflush;
            _position = _center; // Not tested

            _readOnly = false;
        }

        public Actuator(DynamixelBus bus, int id, string name, int offset, Model model, Range<int> positionBoundary, bool autoflush = false)
        {
            _key = new object();

            _bus = bus;
            _name = name;
            _offset = offset;
            _specification = DataSheet.GetSpecification(model);
            _id = id;
            _model = model;
            _center = Convert.ToInt32(_specification.PositionResolution / 2);

            _degreePerDynamixel = _specification.AngleResolution / ((double)_specification.PositionResolution);
            _dynamixelPerDegree = _specification.PositionResolution / ((double)_specification.AngleResolution);
            _angleBoundary = new Range<double>(-(_specification.AngleResolution / 2), +(_specification.AngleResolution / 2));
            _speedBoundary = new Range<int>(1, _specification.SpeedResolution - 1);
            _positionBoundary = positionBoundary;
            _autoFlush = autoflush;
            _position = _center; // Not tested
        }


        private readonly Model _model;
        private string _name;

        public virtual string Name
        {
            get
            {
                lock (_key)
                {
                    return _name;
                }
            }
            set
            {
                lock (_key)
                {
                    _name = value;
                }
            }
        }

        /// <summary>
        /// Actuator Model
        /// </summary>
        public virtual Model Model
        {
            get
            {
                lock (_key)
                {
                    return _model;
                }
            }
        }

        private readonly Specification _specification;

        /// <summary>
        /// Actuator Specifications
        /// </summary>
        public Specification Specification
        {
            get
            {
                lock (_key)
                {
                    return _specification;
                }
            }
        }


        private bool _readOnly;
        public virtual bool ReadOnly
        {
            get
            {
                lock (_key)
                {
                    return _readOnly;
                }
            }

            set
            {
                lock (_key)
                {
                    _readOnly = value;
                }
            }
        }

        private Range<int> _positionBoundary;
        /// <summary>
        /// Get or Set Position Boundary of Actuator.
        /// </summary>
        public virtual Range<int> PositionBoundary
        {
            set
            {
                lock (_key)
                {
                    if (value.Max < _specification.PositionResolution && value.Min >= 0)
                    {
                        _positionBoundary = value;
                        AngleBounadry.Max = PositionToAngle(value.Max);
                        AngleBounadry.Min = PositionToAngle(value.Min);
                    }
                }
            }
            get
            {
                lock (_key)
                {
                    return _positionBoundary;
                }
            }
        }

        private Range<int> _speedBoundary;
        /// <summary>
        /// Get or Set Speed Boundary of Actuator.
        /// </summary>
        public virtual Range<int> SpeedBoundary
        {
            set
            {
                lock (_key)
                {
                    if (value.Max < _specification.SpeedResolution && value.Min >= 0)
                    {
                        _speedBoundary = value;
                    }
                }
            }
            get
            {
                lock (_key)
                {
                    return _speedBoundary;
                }
            }
        }

        private bool _autoFlush;
        /// <summary>
        /// Get or Set AutoFlush 
        /// </summary>
        public virtual bool AutoFlush
        {
            set
            {
                lock (_key)
                {
                    _autoFlush = value;
                }
            }
            get
            {
                lock (_key)
                {
                    return _autoFlush;
                }
            }
        }

        private int _position;
        /// <summary>
        /// Get or Set Position 
        /// </summary>
        public virtual int Position
        {
            set
            {
                // TODO : Bug Prone Validation Scheme
                if (_readOnly) return;
                lock (_key)
                {
                    _position = PositionBoundary.Validate(value);
                    if (AutoFlush)
                    {
                        _bus.SetGoalPosition(Id, RealPosition);
                        _enable = true;
                    }
                }
            }
            get
            {

                lock (_key)
                {
                    return _position;
                }
            }
        }

        /// <summary>
        /// Get or Set Real Position (without Offset) of Actuator. 
        /// </summary>
        public virtual int RealPosition
        {
            set
            {
                if (_readOnly) return;
                lock (_key)
                {
                    _position = PositionBoundary.Validate(value - Offset);
                    if (AutoFlush)
                    {
                        _bus.SetGoalPosition(Id, RealPosition);
                        _enable = true;
                    }
                }
            }

            get
            {
                lock (_key)
                {
                    return PositionBoundary.Validate(_position + Offset);
                }
            }
        }

        private int _speed;
        /// <summary>
        /// Get or Set Speed of Actuator
        /// </summary>
        public virtual int Speed
        {
            set
            {
                if (_readOnly) return;
                lock (_key)
                {
                    _speed = SpeedBoundary.Validate(value);
                    if (AutoFlush)
                    {
                        _bus.SetSpeed(Id, _speed);
                    }
                }
            }
            get
            {
                lock (_key)
                {
                    return _speed;
                }
            }
        }

        private Range<double> _angleBoundary;
        /// <summary>
        /// Get or Set Position Boundaries by Degree . 
        /// </summary>
        public virtual Range<double> AngleBounadry
        {
            set
            {
                if (_readOnly) return;
                lock (_key)
                {
                    if (value.Min < -(_specification.AngleResolution / 2) ||
                        value.Max > -(_specification.AngleResolution / 2))
                    {
                        return;
                    }
                    _angleBoundary = value;
                    PositionBoundary.Max = AngleToPosition(value.Max);
                    PositionBoundary.Min = AngleToPosition(value.Min);
                }
            }
            get
            {
                lock (_key)
                {
                    return _angleBoundary;
                }
            }
        }

        /// <summary>
        /// Get or Set Position of Actuator by Degree .
        /// </summary>
        public virtual double Angle
        {
            set
            {
                if (_readOnly) return;
                lock (_key)
                {
                    Position = AngleToPosition(AngleBounadry.Validate(value));
                }
            }
            get
            {
                lock (_key)
                {
                    return PositionToAngle(Position);
                }
            }
        }

        private int _id;
        /// <summary>
        /// Get or Set Actuator ID .
        /// </summary>
        public virtual int Id
        {
            set
            {
                if (_readOnly) return;
                lock (_key)
                {
                    if (value <= 0 || value > 254) return;
                    _bus.SetId(Id, value);
                    _id = value;
                }
            }
            get
            {
                lock (_key)
                {
                    return _id;
                }
            }
        }

        private int _slop;
        /// <summary>
        /// Get or Set Actuator Slop
        /// Caution : Only For AX,RX and EX series ! 
        /// </summary>
        public int Slop
        {
            set
            {
                if (_readOnly) return;
                lock (_key)
                {
                    if (value == 2 || value == 4 || value == 8 || value == 16 || value == 32 || value == 64 ||
                        value == 128)
                    {
                        _slop = value;
                        if (AutoFlush)
                        {
                            _bus.SetCcwComplianceSlop(_id, _slop);
                            _bus.SetCwComplianceSlop(_id, _slop);
                        }
                    }
                }
            }
            get { return _slop; }
        }

        private int _margin;
        /// <summary>
        /// Get or Set Actuator Margin
        /// Caution : Only For AX,RX and EX series ! 
        /// </summary>
        public int Margin
        {
            set
            {
                if (_readOnly) return;
                lock (_key)
                {
                    _margin = Range<int>.Validate(value, 1, 255);
                    if (AutoFlush)
                    {
                        _bus.SetCwComplianceMargin(_id, _margin);
                        _bus.SetCcwComplianceMargin(_id, _margin);
                    }
                }
            }
            get
            {
                lock (_key)
                {
                    return _margin;
                }
            }
        }

        private int _p;
        public int P
        {
            set
            {
                if (_readOnly) return;
                lock (_key)
                {
                    _p = Range<int>.Validate(value, 1, 255);
                    if (AutoFlush)
                    {
                        _bus.SetP(_id, _p);
                    }
                }
            }
            get
            {
                lock (_key)
                {
                    return _p;
                }
            }
        }

        private int _i;
        public int I
        {
            set
            {
                if (_readOnly) return;
                lock (_key)
                {
                    _i = Range<int>.Validate(value, 1, 255);
                    if (AutoFlush)
                    {
                        _bus.SetI(_id, _i);
                    }
                }
            }
            get
            {
                lock (_key)
                {
                    return _i;
                }
            }
        }

        private int _d;
        public int D
        {
            set
            {
                if (_readOnly) return;
                lock (_key)
                {
                    _d = Range<int>.Validate(value, 1, 255);
                    if (AutoFlush)
                    {
                        _bus.SetD(_id, _d);
                    }
                }
            }
            get
            {
                lock (_key)
                {
                    return _d;
                }
            }

        }

        private int _offset;
        /// <summary>
        /// Get or Set Position Offset of Actuator.
        /// </summary>
        public virtual int Offset
        {
            set
            {
                if (_readOnly) return;
                lock (_key)
                {
                    _offset = value;
                    if (AutoFlush)
                    {
                        _bus.SetGoalPosition(Id, RealPosition);
                    }
                }
            }

            get
            {
                lock (_key)
                {
                    return _offset;
                }
            }
        }

        private bool _enable;
        /// <summary>
        /// Enable or Disable Actuator.
        /// </summary>
        public virtual bool Enable
        {
            set
            {
                if (_readOnly) return;
                lock (_key)
                {
                    if (_enable == value)
                    {
                        return;
                    }
                    _enable = value;
                    if (value)
                    {
                        _bus.TurnOnActuator(Id);
                        ReadCurrentState();
                    }
                    else
                    {
                        _bus.TurnOffActuator(Id);
                    }
                }
            }
            get
            {
                lock (_key)
                {
                    return _enable;
                }
            }
        }

        private readonly int _center;
        public virtual int Center
        {

            get
            {
                lock (_key)
                {
                    return _center;
                }
            }
        }

        private readonly double _degreePerDynamixel;
        public virtual double DegreePerDynamixel
        {
            get
            {
                lock (_key)
                {
                    return _degreePerDynamixel;
                }
            }
        }

        private readonly double _dynamixelPerDegree;
        public virtual double DynamixelPerDegree
        {
            get
            {
                lock (_key)
                {
                    return _dynamixelPerDegree;
                }
            }
        }

        /// <summary>
        /// Determine whether the Actuator is alive or not .
        /// </summary>
        /// <returns></returns>
        public virtual bool Ping()
        {
            lock (_key)
            {
                return _bus.Ping(Id);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual bool ValidateModel()
        {
            lock (_key)
            {
                return _bus.GetModelNumber(Id) == (int)Model;
            }
        }

        /// <summary>
        /// Flush the Actuator Buffer.
        /// </summary>
        public virtual void Flush()
        {
            if (_readOnly) return;
            lock (_key)
            {
                _bus.SetGoalPosition(Id, RealPosition);
                _bus.SetSpeed(Id, Speed);
            }
        }

        /// <summary>
        /// Read Current State of Actuator. 
        /// </summary>
        public virtual void ReadCurrentState()
        {
            if (_readOnly) return; //TODO : Readonly Return Read ?!!!
            lock (_key)
            {
                RealPosition = _bus.GetGoalPoistion(Id);
                Speed = _bus.GetSpeed(Id);
            }
        }

        /// <summary>
        /// Move to position in specific time.
        /// </summary>
        /// <param name="time"></param>
        /// <param name="position"></param>
        /// <param name="relative"></param>
        public virtual void MoveToPosition(double time, int position, bool relative = false)
        {
            if (_readOnly) return;
            lock (_key)
            {
                try
                {
                    if (relative)
                    {
                        position = Position + position;
                    }
                    double temp = ((position - Position + Offset) / time) *
                                  Convert.ToDouble((DegreePerDynamixel) / DegreePerRound) * SecondPerMinute *
                                  (Convert.ToDouble(_specification.SpeedResolution / _specification.Rpm));
                    Speed = Math.Abs(Convert.ToInt32(Math.Round(temp)));
                    Position = position;

                }
                catch
                {

                }
            }
        }

        /// <summary>
        /// Move to position with specific speed.
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="position"></param>
        /// <param name="relative"></param>
        public virtual void MoveToPosition(int speed, int position, bool relative = false)
        {
            if (_readOnly) return;
            lock (_key)
            {
                if (relative)
                {
                    position = Position + position;
                }

                Speed = speed;
                Position = position;
            }
        }

        /// <summary>
        /// Move to Angle in specific time.
        /// </summary>
        /// <param name="time"></param>
        /// <param name="angle"></param>
        /// <param name="relative"></param>
        public virtual void MoveToAngle(double time, double angle, bool relative = false)
        {
            if (_readOnly) return;
            lock (_key)
            {
                if (relative)
                {
                    angle = Angle + angle;
                }
                angle = AngleBounadry.Validate(angle);
                MoveToPosition(time, AngleToPosition(angle));
            }
        }

        /// <summary>
        /// Move to Angle with specific speed.
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="angle"></param>
        /// <param name="relative"></param>
        public virtual void MoveToAngle(int speed, double angle, bool relative = false)
        {
            if (_readOnly) return;
            lock (_key)
            {
                if (relative)
                {
                    angle = angle + Angle;
                }
                Speed = speed;
                Angle = angle;
            }
        }

        /// <summary>
        /// Convert Angle To Raw Position.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual int AngleToPosition(double value)
        {
            lock (_key)
            {
                if (value >= 0)
                {
                    return Convert.ToInt32(Center + (Math.Abs(value) * DynamixelPerDegree));
                }
                return Convert.ToInt32(Center - (Math.Abs(value) * DynamixelPerDegree));
            }
        }

        /// <summary>
        /// Convert Position To Angle.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public virtual double PositionToAngle(int position)
        {

            lock (_key)
            {
                if (position > Center)
                {
                    return Math.Abs(position - Center) * DegreePerDynamixel;
                }

                return -(Math.Abs(position - Center) * DegreePerDynamixel);
            }
        }

        /// <summary>
        /// Get Dynamixel Actuator model.
        /// </summary>
        /// <param name="bus"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Model GetModel(DynamixelBus bus, int id)
        {
            return (Model)bus.GetModelNumber(id);
        }
    }
}


