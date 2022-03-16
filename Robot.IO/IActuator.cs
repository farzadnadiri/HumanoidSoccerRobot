using Robot.Utils;

namespace Robot.IO
{
    public interface IActuator
    {
        /// <summary>
        /// Actuator Name
        /// </summary>
        string Name { set; get; }

        /// <summary>
        /// Actuator Model
        /// </summary>
        Model Model { get; }

        /// <summary>
        /// Actuator Specifications
        /// </summary>
        Specification Specification { get; }

        /// <summary>
        /// Get or Set Position Boundary of Actuator.
        /// </summary>
        Range<int> PositionBoundary { set; get; }

        /// <summary>
        /// Get or Set Speed Boundary of Actuator.
        /// </summary>
        Range<int> SpeedBoundary { set; get; }

        /// <summary>
        /// Get or Set AutoFlush 
        /// </summary>
        bool AutoFlush { set; get; }

        /// <summary>
        /// Get or Set Position 
        /// </summary>
        int Position { set; get; }

        /// <summary>
        /// Get or Set Real Position (without Offset) of Actuator. 
        /// </summary>
        int RealPosition { set; get; }

        /// <summary>
        /// Get or Set Speed of Actuator
        /// </summary>
        int Speed { set; get; }

        /// <summary>
        /// Get or Set Position Boundaries by Degree . 
        /// </summary>
        Range<double> AngleBounadry { set; get; }

        /// <summary>
        /// Get or Set Position of Actuator by Degree .
        /// </summary>
        double Angle { set; get; }

        /// <summary>
        /// Get or Set Actuator ID .
        /// </summary>
        int Id { set; get; }

        /// <summary>
        /// Get or Set Actuator Slop
        /// Caution : Only For AX,RX and EX series ! 
        /// </summary>
        int Slop { set; get; }

        /// <summary>
        /// Get or Set Actuator Margin
        /// Caution : Only For AX,RX and EX series ! 
        /// </summary>
        int Margin { set; get; }


        /// <summary>
        /// Get or Set Actuator Margin
        /// Caution : Only For MX series !  
        /// </summary>
        int P { set; get; }

        /// <summary>
        /// Get or Set Actuator Margin
        /// Caution : Only For MX series !  
        /// </summary>
        int I { set; get; }

        /// <summary>
        /// Get or Set Actuator Margin
        /// Caution : Only For MX series !
        /// </summary>
        int D { set; get; }

        /// <summary>
        /// Get or Set Position Offset of Actuator.
        /// </summary>
        int Offset { set; get; }

        /// <summary>
        /// Enable or Disable Actuator.
        /// </summary>
        bool Enable { set; get; }


        /// <summary>
        /// ReadOnly. No Write!
        /// </summary>
        bool ReadOnly { set; get; }

        int Center { get; }

        /// <summary>
        /// Determine whether the Actuator is alive or not .
        /// </summary>
        /// <returns></returns>
        bool Ping();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool ValidateModel();

        /// <summary>
        /// Flush the Actuator Buffer.
        /// </summary>
        void Flush();

        /// <summary>
        /// Read Current State of Actuator. 
        /// </summary>
        void ReadCurrentState();

        /// <summary>
        /// Move to position in specific time.
        /// </summary>
        /// <param name="time"></param>
        /// <param name="position"></param>
        /// <param name="relative"></param>
        void MoveToPosition(double time, int position, bool relative = false);

        /// <summary>
        /// Move to position with specific speed.
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="position"></param>
        /// <param name="relative"></param>
        void MoveToPosition(int speed, int position, bool relative = false);

        /// <summary>
        /// Move to Angle in specific time.
        /// </summary>
        /// <param name="time"></param>
        /// <param name="angle"></param>
        /// <param name="relative"></param>
        void MoveToAngle(double time, double angle, bool relative = false);

        /// <summary>
        /// Move to Angle with specific speed.
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="angle"></param>
        /// <param name="relative"></param>
        void MoveToAngle(int speed, double angle, bool relative = false);

        /// <summary>
        /// Convert Angle To Raw Position.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        int AngleToPosition(double value);

        /// <summary>
        /// Convert Position To Angle.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        double PositionToAngle(int position);
    }
}