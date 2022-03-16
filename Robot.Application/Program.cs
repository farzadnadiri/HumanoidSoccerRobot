using System;
using System.Diagnostics;
using System.Threading;
using Robot.Behavior;
using Robot.IO;

namespace Robot.Application
{
    static class Program
    {
       
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Process.GetCurrentProcess().PriorityBoostEnabled = true;
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            Console.WriteLine("1 - Vision laboratory");
            Console.WriteLine("2 - Motion Manager");
            Console.WriteLine("3 - Configuration Manager");
            Console.WriteLine("4 - Mpu Control ===> Test Form");
            Console.WriteLine("5 - Initialize Usb2Dynamixel");
            Console.WriteLine("6 - Start Behavior Control");
            Console.WriteLine("7 - Stop Behavior Control");
            Console.WriteLine("8 - Behavior Config");
            Console.WriteLine("9 - Start Behavior Control");
            Console.WriteLine("0 - Stop Behavior Control");
           
            var Robot = new Robot();
            
            while (true)
            {
                var inputKey = Console.ReadKey();
                switch (inputKey.Key)
                {
                    case ConsoleKey.D1:
                        Robot.VisionLab.ShowDialog();
                        break;
                    case ConsoleKey.D2:
                        Robot.MotionEditor.ShowDialog();
                        break;
                    case ConsoleKey.D3:
                        Robot.ConfigurationManager.ShowDialog();
                        break;
                    case ConsoleKey.D4:
                    
                        break;
                    case ConsoleKey.D5:
                        break;
                    case ConsoleKey.D6:
                        break;
                    case ConsoleKey.D8:
                            var x = new BehaviorConfig(Robot.BehaviorControl , Robot.ControllUnit);
                            x.ShowDialog();
                        break;

                    case ConsoleKey.D9:

                        Robot.BehaviorControl.Start();
                        break;
                    case ConsoleKey.D0:
                        Robot.BehaviorControl.Stop();
                        break;
                }

                Thread.Sleep(100);
            }

            // ReSharper disable FunctionNeverReturns
        }
        // ReSharper restore FunctionNeverReturns

    }
}

