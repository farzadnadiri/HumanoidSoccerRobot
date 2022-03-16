using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Robot.Environment.Interface;
using Robot.IO;
using Robot.Utils;

namespace Robot.Environment
{
    public class Body : IBody
    {
        private readonly DynamixelBus _bus;

        private object _key;

        public static class JointIndex
        {
            public const int RightArmPitch = 0;
            public const int LeftArmPitch = 1;

            public const int RightArmRoll = 2;
            public const int LeftArmRoll = 3;

            public const int RightElbow = 4;
            public const int LeftElbow = 5;

            public const int RightHipYaw = 6;
            public const int LeftHipYaw = 7;

            public const int RightHipRoll = 8;
            public const int LeftHipRoll = 9;

            public const int RightHipPitch = 10;
            public const int LeftHipPitch = 11;

            public const int RightKnee = 12;
            public const int LeftKnee = 13;

            public const int RightAnklePitch = 14;
            public const int LeftAnklePitch = 15;

            public const int RightAnkleRoll = 16;
            public const int LeftAnkleRoll = 17;

            public const int Waist = 18;

        }

        private readonly Posture _standStyle;
        public Posture StandStyle
        {
            set
            {
                lock (_key)
                {
                    for (int i = 0; i < Joints.Count; i++)
                    {
                        _standStyle[i] = value[i];
                    }
                }
            }
            get
            {
                lock (_key)
                {
                    return _standStyle;
                }
            }
        }

        public double ThighLength
        {
            get;
            private set;
        }

        public double CalfLength
        {
            get;
            private set;
        }

        public double AnkleLength
        {
            get;
            private set;
        }

        public double LegLength
        {
            get { return ThighLength + CalfLength + AnkleLength; }
        }

        public double Height
        {
            get;
            private set;
        }

        public IActuator this[int i]
        {
            get
            {
                lock (_key)
                {
                    return Joints[i];
                }
            }
        }

        private List<IActuator> _joints;
        public List<IActuator> Joints
        {
            get
            {
                lock (_key)
                {
                    return _joints;
                }
            }
        }

        public IActuator RightArmPitch
        {

            get
            {
                lock (_key)
                {
                    return Joints[JointIndex.RightArmPitch];
                }
            }
        }

        public IActuator LeftArmPitch
        {
            get
            {
                lock (_key)
                {
                    return Joints[JointIndex.LeftArmPitch];
                }
            }
        }

        public IActuator RightArmRoll
        {
            get
            {
                lock (_key)
                {
                    return Joints[JointIndex.RightArmRoll];
                }
            }
        }

        public IActuator LeftArmRoll
        {
            get
            {
                lock (_key)
                {
                    return Joints[JointIndex.LeftArmRoll];
                }
            }
        }

        public IActuator RightElbow
        {
            get
            {
                lock (_key)
                {
                    return Joints[JointIndex.RightElbow];
                }
            }
        }

        public IActuator LeftElbow
        {
            get
            {
                lock (_key)
                {
                    return Joints[JointIndex.LeftElbow];
                }
            }
        }

        public IActuator RightHipYaw
        {
            get
            {
                lock (_key)
                {
                    return Joints[JointIndex.RightHipYaw];
                }
            }
        }

        public IActuator LeftHipYaw
        {
            get
            {
                lock (_key)
                {
                    return Joints[JointIndex.LeftHipYaw];
                }
            }
        }

        public IActuator RightHipPitch
        {
            get
            {
                lock (_key)
                {
                    return Joints[JointIndex.RightHipPitch];
                }
            }
        }

        public IActuator LeftHipPitch
        {
            get
            {
                lock (_key)
                {
                    return Joints[JointIndex.LeftHipPitch];
                }
            }
        }

        public IActuator RightHipRoll
        {
            get
            {
                lock (_key)
                {
                    return Joints[JointIndex.RightHipRoll];
                }
            }
        }

        public IActuator LeftHipRoll
        {
            get
            {
                lock (_key)
                {
                    return Joints[JointIndex.LeftHipRoll];
                }
            }
        }

        public IActuator RightKnee
        {
            get
            {
                lock (_key)
                {
                    return Joints[JointIndex.RightKnee];
                }
            }
        }

        public IActuator LeftKnee
        {
            get
            {
                lock (_key)
                {
                    return Joints[JointIndex.LeftKnee];
                }
            }
        }

        public IActuator RightAnklePitch
        {
            get
            {
                lock (_key)
                {
                    return Joints[JointIndex.RightAnklePitch];
                }
            }
        }

        public IActuator LeftAnklePitch
        {
            get
            {
                lock (_key)
                {
                    return Joints[JointIndex.LeftAnklePitch];
                }
            }
        }

        public IActuator RightAnkleRoll
        {
            get
            {
                lock (_key)
                {
                    return Joints[JointIndex.RightAnkleRoll];
                }
            }
        }

        public IActuator LeftAnkleRoll
        {
            get
            {
                lock (_key)
                {
                    return Joints[JointIndex.LeftAnkleRoll];
                }
            }
        }

        public IActuator Waist
        {
            get
            {
                lock (_key)
                {
                    return Joints[JointIndex.Waist];
                }
            }
        }

        public const int DefaultJointCount = 19;

        public Body(DynamixelBus bus, double height, double thighLength, double calfLength, double ankleLength)
        {
            _key = new object();
            _standStyle = new Posture(DefaultJointCount);
            _bus = bus;
            Height = height;

            ThighLength = thighLength;
            CalfLength = calfLength;
            AnkleLength = ankleLength;

            _joints = new List<IActuator>();
            for (int i = 0; i < DefaultJointCount; i++)
            {
                _joints.Add(new Actuator(bus, i + 1, Model.Rx64));
                _joints[i].Name = String.Format("Joint{0}", i + 1);
            }

        }

        public Body(DynamixelBus bus, string configPath)
        {
            _key = new object();
            _bus = bus;
            _joints = new List<IActuator>();
            Load(bus, configPath); // TODO : Load Kinematics Related Parameters of Body 


            _standStyle = new Posture(Joints.Count);
        }

        public void ApplySpeedPositions()
        {
            lock (_key)
            {
                _bus.SetSpeedPosition(Joints);
            }
        }

        public void ApplySlopMargin()
        {
            lock (_key)
            {
                _bus.SetSlopMargin(Joints);
            }
        }

        public void ApplyPositions()
        {
            lock (_key)
            {
                _bus.SetPositions(Joints);
            }
        }

        public void ApplySpeeds()
        {
            lock (_key)
            {
                _bus.SetSpeeds(Joints);
            }
        }

        public void ApplySlops()
        {
            lock (_key)
            {
                _bus.SetSlops(Joints);
            }
        }

        public void ApplyMargins()
        {
            lock (_key)
            {
                _bus.SetMargins(Joints);
            }
        }

        public void HomogenizeSpeeds(int speed = 1023)
        {
            lock (_key)
            {
                int jointCount = Joints.Count;
                for (int i = 0; i < jointCount; i++)
                {
                    Joints[i].Speed = speed;
                }
            }
        }

        public void SetStandStyle(Posture style)
        {
            lock (_key)
            {
                for (int i = 0; i < Joints.Count; i++)
                {
                    Joints[i].Angle = style[i];
                    StandStyle[i] = style[i];
                }
            }
        }

        public void ApplyStandStyle()
        {
            lock (_key)
            {
                for (int i = 0; i < Joints.Count; i++)
                {
                    Joints[i].Angle = StandStyle[i];

                }
            }
        }

        public void Save(string path)
        {
            lock (_key)
            {
                var list = new List<XElement>();

                var inverseElement = new XElement("InverseKinematics",
                    new XAttribute("ThighLength", ThighLength),
                    new XAttribute("CalfLength", CalfLength),
                    new XAttribute("AnkleLength", AnkleLength)
                    );

                list.Add(inverseElement);
                for (int i = 0; i < Joints.Count; i++)
                {
                    list.Add(new XElement("Joint",
                        new XAttribute("Model", DataSheet.GetModelString(Joints[i].Model)),
                        new XAttribute("ID", Joints[i].Id),
                        new XAttribute("Name", Joints[i].Name),
                        new XAttribute("Offset", Joints[i].Offset),
                        new XAttribute("Slop", Joints[i].Slop),
                        new XAttribute("Margin", Joints[i].Margin),
                        new XAttribute("MinPosition", Joints[i].PositionBoundary.Min),
                        new XAttribute("MaxPosition", Joints[i].PositionBoundary.Max)
                        ));
                }




                var doc = new XElement("Body", list.ToArray());
                doc.Save(path);
            }
        }

        public void Load(DynamixelBus bus, string path)
        {
            lock (_key)
            {
                Joints.Clear();
                XDocument doc = XDocument.Load(path);
                var joints = from item in doc.Descendants("Body").Descendants("Joint")
                             select new
                             {
                                 model = item.Attribute("Model").Value,
                                 id = Convert.ToInt32(item.Attribute("ID").Value),
                                 name = item.Attribute("Name").Value,
                                 offset = Convert.ToInt32(item.Attribute("Offset").Value),
                                 slop = Convert.ToInt32(item.Attribute("Slop").Value),
                                 margin = Convert.ToInt32(item.Attribute("Margin").Value),
                                 minpos = Convert.ToInt32(item.Attribute("MinPosition").Value),
                                 maxpos = Convert.ToInt32(item.Attribute("MaxPosition").Value)

                             };
                foreach (var joint in joints)
                {
                    Joints.Add(new Actuator(bus, joint.id, joint.name, joint.offset, DataSheet.GetModel(joint.model),
                        new Range<int>(joint.minpos, joint.maxpos)));
                }

                var kinematics = from item in doc.Descendants("Body").Descendants("InverseKinematics")
                                 select new
                                 {
                                     ankleLength = Convert.ToDouble(item.Attribute("AnkleLength").Value),
                                     thighLength = Convert.ToDouble(item.Attribute("ThighLength").Value),
                                     calfLength = Convert.ToInt32(item.Attribute("CalfLength").Value),
                                 };
                if (kinematics.Any())
                {
                    var item = kinematics.First();
                    ThighLength = item.thighLength;
                    CalfLength = item.calfLength;
                    AnkleLength = item.ankleLength;
                }

            }
        }
    }
}
