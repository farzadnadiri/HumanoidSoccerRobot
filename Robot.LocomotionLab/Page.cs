using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Robot.Utils;

namespace Robot.Locomotion
{
    public class Page
    {
        public int StepsPerPage
        {
            set;
            get;
        }

        public int Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public int Next
        {
            get;
            set;
        }
        public int Exit
        {
            get;
            set;
        }
        public int RepeatTime
        {
            get;
            set;
        }
        public double SpeedRate
        {
            get;
            set;
        }
        public int InertialForce
        {
            get;
            set;
        }
        public List<Step> Steps
        {
            get;
            set;
        }

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

        private readonly int _numberofJoints;

        private void Initialize()
        {
            Slops = new int[_numberofJoints];
            Margins = new int[_numberofJoints];
            for (int i = 0; i < _numberofJoints; i++)
            {
                Slops[i] = 16;
                Margins[i] = 1;
            }
        }

        public Page(int jointsCount,int id,int stepsPerPage)
        {
            StepsPerPage = stepsPerPage;
            _numberofJoints = jointsCount;
            Id = id;
            Name = String.Empty;
            Next = 0;
            Exit = 0;
            RepeatTime = 1;
            SpeedRate = 1;
            InertialForce = 0;
            Steps = new List<Step>();
            Initialize();
            for (int i = 0; i < StepsPerPage; i++)
            {
                Steps.Add(new Step(_numberofJoints,i + 1));
            }
        }

        public Page(int jointsCount,int id, string name, int next, int exit, int repeatTime, double speedRate, int inertialForce, List<Step> steps, int[] slops, int[] margins,int stepsPerPage)
        {
            StepsPerPage = stepsPerPage;
            _numberofJoints = jointsCount;
            Id = id;
            Name = name;
            Next = next;
            Exit = exit;
            RepeatTime = repeatTime;
            SpeedRate = speedRate;
            InertialForce = inertialForce;
            Steps = steps;
            Initialize();
            for (int i = 0; i < slops.Length; i++)
            {
                Slops[i] = slops[i];
                Margins[i] = margins[i];
            }
        }

        public void RemoveStep(int index)
        {
            if (index >= 0)
            {
                Steps[index].Enable = false;
                for (int i = index; i < StepsPerPage - 1; i++)
                {
                    Step.Exchange(Steps[i], Steps[i + 1]);
                }
            }
        }

        public XElement ToXml()
        {
            var xmlStepsList = new List<XElement>();
            for (int i = 0; i < StepsPerPage; i++)
            {
                xmlStepsList.Add(Steps[i].ToXml());
            }
            string slops = Utility.SerializeItems(Slops, ",");
            string margins = Utility.SerializeItems(Margins, ",");
            var xmlDoc = new XElement("Page",
                          new XAttribute("ID", String.Format("{0}",Id)),
                          new XAttribute("Name", Name),
                          new XAttribute("Next", String.Format("{0}", Next)),
                          new XAttribute("Exit", String.Format("{0}", Exit)),
                          new XAttribute("SpeedRate", String.Format("{0}", SpeedRate)),
                          new XAttribute("RepeatTime", String.Format("{0}", RepeatTime)),
                          new XElement("Slops", slops),
                          new XElement("Margins", margins),
 
// ReSharper disable CoVariantArrayConversion
                          new XElement("Steps", xmlStepsList.ToArray())
// ReSharper restore CoVariantArrayConversion
 
                        );
            return xmlDoc;

        }
    }
}
