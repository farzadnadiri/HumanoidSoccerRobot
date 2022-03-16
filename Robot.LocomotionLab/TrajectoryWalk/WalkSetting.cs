
using System;
using System.Linq;
using System.Xml.Linq;
using Robot.Utils;
using Robot.Utils.Interface;

namespace Robot.Locomotion.TrajectoryWalk
{
    public class WalkSetting : IStorable
    {
        public double XAmplitude;
        public double YAmplitude;
        public double ZAmplitude;
        public double AAmplitude;

        public double DoubleStanceRatio;
        public double FowardBackwardRatio;

        public double YSwapAmplitude;
        public double ZSwapAmplitude;

        public double XOffset;
        public double YOffset;
        public double ZOffset;
        public double AOffset;



        public void Save(string path)
        {
            var xmldoc = new XElement("WalkSetting",
             new XAttribute("XAmplitude", String.Format("{0}", XAmplitude)),
             new XAttribute("YAmplitude", String.Format("{0}", YAmplitude)),
             new XAttribute("ZAmplitude", String.Format("{0}", ZAmplitude)),
             new XAttribute("AAmplitude", String.Format("{0}", AAmplitude)),

             new XAttribute("DoubleStanceRatio", String.Format("{0}", DoubleStanceRatio)),
             new XAttribute("FowardBackwardRatio", String.Format("{0}", FowardBackwardRatio)),
             new XAttribute("YSwapAmplitude", String.Format("{0}", YSwapAmplitude)),
             new XAttribute("ZSwapAmplitude", String.Format("{0}", ZSwapAmplitude)),

             new XAttribute("XOffset", String.Format("{0}", XOffset)),
             new XAttribute("YOffset", String.Format("{0}", YOffset)),
             new XAttribute("ZOffset", String.Format("{0}", ZOffset)),
             new XAttribute("AOffset", String.Format("{0}", AOffset))

             );

            xmldoc.Save(path);
        }

        public void Load(string path)
        {
            XDocument rootNode = XDocument.Load(path);
            var query = from step in rootNode.Descendants("WalkSetting")
                        select new
                        {
                            XAmplitude = Convert.ToDouble(step.Attribute("XAmplitude").Value),
                            YAmplitude = Convert.ToDouble(step.Attribute("YAmplitude").Value),
                            ZAmplitude = Convert.ToDouble(step.Attribute("ZAmplitude").Value),
                            AAmplitude = Convert.ToDouble(step.Attribute("AAmplitude").Value),

                            DoubleStanceRatio = Convert.ToDouble(step.Attribute("DoubleStanceRatio").Value),
                            FowardBackwardRatio = Convert.ToDouble(step.Attribute("FowardBackwardRatio").Value),
                            YSwapAmplitude = Convert.ToDouble(step.Attribute("YSwapAmplitude").Value),
                            ZSwapAmplitude = Convert.ToDouble(step.Attribute("ZSwapAmplitude").Value),

                            XOffset = Convert.ToDouble(step.Attribute("XOffset").Value),
                            YOffset = Convert.ToDouble(step.Attribute("YOffset").Value),
                            ZOffset = Convert.ToDouble(step.Attribute("ZOffset").Value),
                            AOffset = Convert.ToDouble(step.Attribute("AOffset").Value),
                        };

            var input = query.Single();

            XAmplitude = input.XAmplitude;
            YAmplitude = input.YAmplitude;
            ZAmplitude = input.ZAmplitude;
            AAmplitude = input.AAmplitude;

            DoubleStanceRatio = input.DoubleStanceRatio;
            FowardBackwardRatio = input.FowardBackwardRatio;
            YSwapAmplitude = input.YSwapAmplitude;
            ZSwapAmplitude = input.ZSwapAmplitude;

            XOffset = input.XOffset;
            YOffset = input.YOffset;
            ZOffset = input.ZOffset;
            AOffset = input.AOffset;

        }
    }
}
