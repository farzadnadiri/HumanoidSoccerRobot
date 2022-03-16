using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Robot.IO
{
    public static class DataSheet
    {
        private static readonly Dictionary<string, Specification> Products;
        static DataSheet()
        {

            Products = new Dictionary<string, Specification>();
            Load("Config/Dynamixel.xml");
        }


        public static string GetModelString(Model model)
        {
            if (model == Model.Ax12A)
            {
                return "AX-12";
            }
            if (model == Model.Ax12W)
            {
                return "AX-12W";
            }
            if (model == Model.Ax18)
            {
                return "AX-18";
            }

            if (model == Model.Rx24F)
            {
                return "RX-24F";
            }
            if (model == Model.Rx28)
            {
                return "RX-28";
            }
            if (model == Model.Rx64)
            {
                return "RX-64";
            }
            if (model == Model.Mx28)
            {
                return "MX-28";
            }
            if (model == Model.Mx64)
            {
                return "MX-64";
            }
            if (model == Model.Mx106)
            {
                return "MX-106";
            }
            return null;
        }
        public static Model GetModel(string model)
        {
            if (model == "AX-12")
            {
                return Model.Ax12A;
            }
            if (model == "AX-12W")
            {
                return Model.Ax12W;
            }
            if (model == "AX-18")
            {
                return Model.Ax18;
            }
            if (model == "RX-24F")
            {
                return Model.Rx24F;
            }
            if (model == "RX-28")
            {
                return Model.Rx28;
            }
            if (model == "RX-64")
            {
                return Model.Rx64;
            }
            if (model == "MX-28")
            {
                return Model.Mx28;
            }
            if (model == "MX-64")
            {
                return Model.Mx64;
            }
            if (model == "MX-106")
            {
                return Model.Mx106;
            }
            return Model.Unknown;
        }

        public static Specification GetSpecification(Model model)
        {
            switch (model)
            {
                case Model.Ax12A:
                    return Products["AX-12"].Copy();
                case Model.Ax12W:
                    return Products["AX-12W"].Copy();
                case Model.Ax18:
                    return Products["AX-18"].Copy();
                case Model.Rx24F:
                    return Products["RX-24F"].Copy();
                case Model.Rx28:
                    return Products["RX-28"].Copy();
                case Model.Rx64:
                    return Products["RX-64"].Copy();
                case Model.Mx28:
                    return Products["MX-28"].Copy();
                case Model.Mx64:
                    return Products["MX-64"].Copy();
                case Model.Mx106:
                    return Products["MX-106"].Copy();
                case Model.Ex106:
                    return Products["EX-106"].Copy();

                default:
                    return null;
            }
        }
        private static void Load(string path)
        {
            XDocument doc = XDocument.Load(path);
            var list = from item in doc.Descendants("Specifications").Descendants("Actuator")
                       select new
                      {
                          model = item.Attribute("Model").Value,
                          rpm = Convert.ToDouble(item.Attribute("Rpm").Value),
                          positionResolution = Convert.ToInt32(item.Attribute("PositionResolution").Value),
                          speedResolution = Convert.ToInt32(item.Attribute("SpeedResolution").Value),
                          angleResolution = Convert.ToInt32(item.Attribute("AngleResolution").Value)
                      };
            foreach (var item in list)
            {
                Products.Add(item.model, new Specification(item.rpm, item.positionResolution, item.speedResolution, item.angleResolution));
            }
        }
    }

}
