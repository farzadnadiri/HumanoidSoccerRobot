using System;
using System.Linq;
using System.Xml.Linq;
using Robot.Utils;

namespace Robot.Locomotion
{
    public class WalkEnginSetting
    {
        #region Properties

        public int[] Slops
        {
            set;
            get;
        }
        public int[] Margins
        {
            set;
            get;
        }
        public double X
        {
            set;
            get;
        }
        public double Y
        {
            set;
            get;
        }
        public double Z
        {
            set;
            get;
        }
        public double Yaw
        {
            set;
            get;
        }
        public double PhaseTime
        {
            set;
            get;
        }
        public double StepLength
        {
            set;
            get;
        }
        #endregion

        #region Constructors

        private const int DefaultSlop = 32;
        private const int DefaultMargin = 1;
        private void Initialize()
        {

            //Slops = new int[Robot.Body.Joints.Count];
            //Margins = new int[Robot.Body.Joints.Count];
            //for (int i = 0; i < Robot.Body.Joints.Count; i++)
           // {
           //     Slops[i] = DefaultSlop;
           //     Margins[i] = DefaultMargin;
           // }
        }
        public WalkEnginSetting()
        {
            Initialize();
        }
        public WalkEnginSetting(double x, double y, double z, double yaw, double phaseTime, double stepLength)
        {
            Initialize();
            X = x;
            Y = y;
            Z = z;
            Yaw = yaw;
            PhaseTime = phaseTime;
            StepLength = stepLength;
        }
        #endregion

        #region Save & Load Functions
        public void Save(string path)
        {
            string slopstring=Utility.SerializeItems(Slops, ",");
            string marginstring = Utility.SerializeItems(Margins, ",");
            var rootNode = new XElement("WalkEnginSetting",
                new XAttribute("X", X),
                new XAttribute("Y", Y),
                new XAttribute("Z", Z),
                new XAttribute("Yaw", Yaw),
                new XAttribute("PhaseTime", PhaseTime),
                new XAttribute("StepLength", StepLength),
                new XElement("Slops",slopstring),
                new XElement("Margins",marginstring)
                );
            rootNode.Save(path);
        }

        public  void Load(string path)
        {
            XDocument rootNode = XDocument.Load(path);
            var query = from step in rootNode.Descendants("WalkEnginSetting")
                        let tempSlops = step.Element("Slops")
                        where tempSlops != null
                        let tempMargins = step.Element("Margins")
                        where tempMargins != null
                        select new
                        {
                            x = Convert.ToDouble(step.Attribute("X").Value),
                            y = Convert.ToDouble(step.Attribute("Y").Value),
                            z = Convert.ToDouble(step.Attribute("Z").Value),
                            yaw = Convert.ToDouble(step.Attribute("Yaw").Value),
                            phaseTime = Convert.ToDouble(step.Attribute("PhaseTime").Value),
                            stepLength = Convert.ToDouble(step.Attribute("StepLength").Value),
                            slops=tempSlops.Value,
                            margins=tempMargins.Value
                        };
            var input = query.Single();
            X = input.x;
            Y = input.y;
            Z = input.z;
            Yaw = input.yaw;
            PhaseTime = input.phaseTime;
            StepLength = input.stepLength;

            Slops = Utility.DeserializeItems(input.slops, ',');
            Margins = Utility.DeserializeItems(input.margins, ',');
        }
        #endregion

        public void Apply()
        {
            //WalkEngin.X = X;
            //WalkEngin.Y = Y;
            //WalkEngin.Z = Z;
            //WalkEngin.Yaw = Yaw;
            //WalkEngin.PhaseTime = PhaseTime;
            //WalkEngin.StepLength = StepLength;
            //for (int i = 0; i < Robot.Body.Joints.Count; i++)
            //{
            //    Robot.Body[i].Slop = Slops[i];
            //    Robot.Body[i].Margin = Margins[i];
            //}
            //Robot.Body.ApplySlopMargin();
        }

        public void GetCurrentSetting()
        {
            //X = WalkEngin.X;
            //Y = WalkEngin.Y;
            //Z = WalkEngin.Z;
            //Yaw = WalkEngin.Yaw;
            //PhaseTime = WalkEngin.PhaseTime;
            //StepLength = WalkEngin.StepLength;
        }
    }
}
