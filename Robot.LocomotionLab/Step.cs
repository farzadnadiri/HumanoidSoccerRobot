using System;
using System.Linq;
using System.Xml.Linq;
using Robot.Environment;
using Robot.Utils;
using Robot.Utils.Interface;

namespace Robot.Locomotion
{
    public class Step : IStorable
    {

        public int Id
        {
            get;
            set;
        }

        public double Time
        {
            get;
            set;
        }

        public double Pause
        {
            get;
            set;
        }

        public bool Enable
        {
            set
            {
                if (!value)
                {
                    Angels.MakeDefault();
                    Pause = 0;
                    Time = 0;
                }
            }

            get
            {
                if (Time > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public Posture Angels
        {
            set;
            get;
        }

        public Step(int jointsCount, int id, double time = -1, double pause = 0)
        {
            Id = id;
            Time = time;
            Pause = pause;
            Angels = new Posture(jointsCount);
        }

        public Step(int id, double time, double pause, Posture position)
        {
            Id = id;
            Time = time;
            Pause = pause;
            Angels = new Posture(position);

        }

        public Step Copy()
        {
            return new Step(Id, Time, Pause, Angels);
        }

        public static void Exchange(Step first, Step second)
        {
            var temp = new Step(first.Id, first.Time, first.Pause, first.Angels);

            first.Time = second.Time;
            first.Pause = second.Pause;
            //first.Id = second.Id;
            for (int i = 0; i < first.Angels.Count; i++)
            {
                first.Angels[i] = second.Angels[i];
            }

            second.Time = temp.Time;
            second.Pause = temp.Pause;
            //second.Id = temp.Id;
            for (int i = 0; i < temp.Angels.Count; i++)
            {
                second.Angels[i] = temp.Angels[i];
            }
        }

        #region Save & Load

        public void Save(string path)
        {
            ToXml().Save(path);
        }

        public void Load(string path)
        {
            XDocument xmlDoc = XDocument.Load(path);
            var input = from step in xmlDoc.Descendants("Step")
                        let positions = step.Element("Position")
                        where positions != null
                        select new
                        {
                            ID = Convert.ToInt32(step.Attribute("ID").Value),
                            Time = Convert.ToDouble(step.Attribute("Time").Value),
                            Pause = Convert.ToDouble(step.Attribute("Pause").Value),
                            Positions = positions.Value
                        };
            var singleStep = input.Single();

            Id = singleStep.ID;
            Time = singleStep.Time;
            Pause = singleStep.Pause;

            string[] stringPositions = singleStep.Positions.Split(',');

            for (int i = 0; i < stringPositions.Length; i++)
            {
                Angels[i] = Convert.ToInt32(stringPositions[i]);
            }
        }

        public XElement ToXml()
        {
            string stepPositions = Utility.SerializeItems(Angels.ToArray(), ",");

            var xmldoc = new XElement("Step",
                                        new XAttribute("ID", String.Format("{0}", Id)),
                                        new XAttribute("Time", String.Format("{0}", Time)),
                                        new XAttribute("Pause", String.Format("{0}", Pause)),
                                        new XElement("Position", stepPositions)
              );
            return xmldoc;
        }

        #endregion

    }
}
