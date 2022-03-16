using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;
using Robot.Environment;
using Robot.Environment.Interface;
using Robot.Utils;
using Robot.Utils.Interface;

namespace Robot.Locomotion
{
    public class MotionManager : IStorable
    {
        public enum Motion
        {
            LeftKick,
            RightKick,
            FrontStand,
            BackStand,
            LeftBlock,
            RightBlock,
            GameLost,
            GameWon,
        }


        private readonly IBody _body;
        private readonly object _key;
        private bool _enable;


        public List<Page> Pages
        {
            set;
            get;
        }

        public int NumberOfPages
        {
            get;
            set;
        }

        public int StepsPerPage
        {
            set;
            get;
        }



        public bool IsRunning
        {
            get
            {
                return _enable;
            }
        }

        public MotionManager(IBody body)
        {
            //TODO : Save and Load Configuration + Motion Indexes !  
            _key = new object();
            _body = body;
            _enable = false;
            Pages = new List<Page>();
            NumberOfPages = 40;
            StepsPerPage = 7;
            ClearPages();
        }

        private BackgroundWorker _backgroundWorker;
        public void PlayMotionAsync(int index)
        {
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += (delegate { PlayMotion(index); });
            _backgroundWorker.RunWorkerAsync();
        }

        public void PlayMotion(int pageIndex)
        {
            lock (_key)
            {
                _enable = true;
                PlayPage(pageIndex);
                _enable = false;
            }
        }

        public void PlayMotion(int pageIndex, int speed)
        {
            lock (_key)
            {
                _enable = true;
                PlayPage(pageIndex, speed);
                _enable = false;
            }
        }


        public void PlayMotion(Motion motion)
        {
            //TODO : Specify Index For Each Motion ! 

        }

        private void PlayPage(int index)
        {
            for (int i = 0; i < Pages[index].RepeatTime; i++)
            {
                for (int j = 0; j < StepsPerPage; j++)
                {
                    if (Pages[index].Steps[j].Enable)
                    {
                        if (!_enable)
                        {
                            return;
                        }
                        PlayStep(index, j);
                    }
                }
            }
            if (Pages[index].Next != 0)
            {
                PlayPage(Pages[index].Next - 1);
            }
        }

        private void PlayPage(int index, int speed)
        {
            for (int i = 0; i < Pages[index].RepeatTime; i++)
            {
                for (int j = 0; j < StepsPerPage; j++)
                {
                    if (Pages[index].Steps[j].Enable)
                    {
                        if (!_enable)
                        {
                            return;
                        }
                        PlayStep(index, j, speed);
                    }
                }
            }
            if (Pages[index].Next != 0)
            {
                PlayPage(Pages[index].Next - 1, speed);
            }
        }

        private double _time;
        private double _pause;
        private int _delay;
        public void PlayStep(int pageIndex, int stepIndex)
        {
            _time = Pages[pageIndex].Steps[stepIndex].Time;
            _pause = Pages[pageIndex].Steps[stepIndex].Pause;
            for (int i = 0; i < _body.Joints.Count; i++)
            {
                _body[i].MoveToAngle(_time, Pages[pageIndex].Steps[stepIndex].Angels[i]);
            }
            _body.ApplySpeedPositions();
            _delay = (int)((_time + _pause) * 1000);
            System.Threading.Thread.Sleep(_delay);
        }



        public void PlayStep(int pageIndex, int stepIndex, int speed)
        {
            for (int i = 0; i < _body.Joints.Count; i++)
            {
                _body[i].MoveToAngle(speed, Pages[pageIndex].Steps[stepIndex].Angels[i]);
                // _body[i].MoveToAngle(_time, Pages[pageIndex].Steps[stepIndex].Angels[i]);
            }
            _body.ApplySpeedPositions();
            _delay = (int)((_time + _pause) * 1000);
            System.Threading.Thread.Sleep(_delay);
        }


        public void PlayStep(Step step, int speed)
        {
            for (int i = 0; i < _body.Joints.Count; i++)
            {
                _body[i].MoveToAngle(speed, step.Angels[i]);
                // _body[i].MoveToAngle(_time, Pages[pageIndex].Steps[stepIndex].Angels[i]);
            }
            _body.ApplySpeedPositions();
            _delay = (int)((_time + _pause) * 1000);
            System.Threading.Thread.Sleep(_delay);
        }

        public void StopMotion()
        {
            _enable = false;
        }

        public void ClearPages()
        {
            Pages.Clear();
            for (int i = 0; i < NumberOfPages; i++)
            {
                Pages.Add(new Page(_body.Joints.Count, i + 1, StepsPerPage));
            }
        }

        public void Load(string path)
        {
            Pages.Clear();
            XDocument xmlDoc = XDocument.Load(path);
            var pagesQuery = from page in xmlDoc.Descendants("Page")
                             select new
                             {
                                 ID = page.Attribute("ID").Value,
                                 Name = page.Attribute("Name").Value,
                                 Next = page.Attribute("Next").Value,
                                 Exit = page.Attribute("Exit").Value,
                                 SpeedRate = page.Attribute("SpeedRate").Value,
                                 RepeatTime = page.Attribute("RepeatTime").Value,
                                 slops = page.Element("Slops").Value,
                                 margins = page.Element("Margins").Value,
                                 Steps = page.Descendants("Steps").Single().Descendants("Step")
                             };
            int pageCounter = pagesQuery.Count();

            for (int i = 0; i < pageCounter; i++)
            {
                var singlePage = pagesQuery.Single(x => x.ID == (i + 1).ToString());
                var stepsQuery = from step in singlePage.Steps
                                 select new
                                 {
                                     ID = step.Attribute("ID").Value,
                                     Time = step.Attribute("Time").Value,
                                     Pause = step.Attribute("Pause").Value,
                                     Positions = step.Element("Position").Value
                                 };

                List<Step> newsteps = new List<Step>();
                for (int j = 0; j < StepsPerPage; j++)
                {
                    var positions = new int[_body.Joints.Count];
                    var singleStep = stepsQuery.Single(y => y.ID == (j + 1).ToString());
                    var stringPositions = singleStep.Positions.Split(',');

                    for (int k = 0; k < _body.Joints.Count; k++)
                    {
                        positions[k] = Convert.ToInt32(stringPositions[k]);
                    }

                    newsteps.Add(new Step(Convert.ToInt32(singleStep.ID),
                                          Convert.ToDouble(singleStep.Time), Convert.ToDouble(singleStep.Pause), new Posture(positions)));

                }

                var slops = Utility.DeserializeItems(singlePage.slops, ',');
                var margins = Utility.DeserializeItems(singlePage.margins, ',');

                Pages.Add(new Page(_body.Joints.Count, Convert.ToInt32(singlePage.ID), singlePage.Name,
                    Convert.ToInt32(singlePage.Next), Convert.ToInt32(singlePage.Exit),
                    Convert.ToInt32(singlePage.RepeatTime), Convert.ToDouble(singlePage.SpeedRate), 1, newsteps, slops, margins, StepsPerPage));
            }
        }

        public void Save(string path)
        {

            var xmlPagesList = new List<XElement>();
            for (int i = 0; i < NumberOfPages; i++)
            {
                xmlPagesList.Add(Pages[i].ToXml());
            }
            var xmldoc = new XElement("Pages", xmlPagesList.ToArray());
            xmldoc.Save(path);
        }
    }
}
