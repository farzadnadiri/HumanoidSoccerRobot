using System.Collections.Generic;
using Robot.IO;
using Robot.Utils.Interface;

namespace Robot.Environment.Interface
{
    public interface IBody
    {

        Posture StandStyle
        {
            set;
            get;
        }

        /// <summary>
        /// Get Height of Thigh(Upper Leg) Link 
        /// </summary>
        double ThighLength { get; }

        /// <summary>
        /// Get Height of Crus(Lower Leg) Link 
        /// </summary>
        double CalfLength { get; }
        double AnkleLength { get; }
        double LegLength { get; }

        /// <summary>
        /// Get or Set Height of Body
        /// </summary>
        double Height { get; }

        /// <summary>
        /// List of All Joints 
        /// </summary>
        List<IActuator> Joints { get; }

        /// <summary>
        /// Right Arm Pitch Joint
        /// </summary>
        IActuator RightArmPitch { get; }

        /// <summary>
        /// Left Arm Pitch Joint
        /// </summary>
        IActuator LeftArmPitch { get; }

        /// <summary>
        /// Right Arm Roll Joint
        /// </summary>
        IActuator RightArmRoll { get; }

        /// <summary>
        /// Left Arm Roll Joint
        /// </summary>
        IActuator LeftArmRoll { get; }

        /// <summary>
        /// Right Elbow Joint
        /// </summary>
        IActuator RightElbow { get; }

        /// <summary>
        /// Left Elbow Joint
        /// </summary>
        IActuator LeftElbow { get; }

        /// <summary>
        /// Right Hip Yaw Joint
        /// </summary>
        IActuator RightHipYaw { get; }

        /// <summary>
        /// Left Hip Yaw Joint
        /// </summary>
        IActuator LeftHipYaw { get; }

        /// <summary>
        /// Right Hip Pitch Joint
        /// </summary>
        IActuator RightHipPitch { get; }

        /// <summary>
        /// Left Hip Pitch Joint
        /// </summary>
        IActuator LeftHipPitch { get; }

        /// <summary>
        /// Right Hip Roll Joint
        /// </summary>
        IActuator RightHipRoll { get; }

        /// <summary>
        /// Left Hip Roll Joint
        /// </summary>
        IActuator LeftHipRoll { get; }

        /// <summary>
        /// Right Knee Joint
        /// </summary>
        IActuator RightKnee { get; }

        /// <summary>
        /// Left Knee Joint
        /// </summary>
        IActuator LeftKnee { get; }

        /// <summary>
        /// Right Ankle Pitch Joint
        /// </summary>
        IActuator RightAnklePitch { get; }

        /// <summary>
        /// Left Ankle Pitch Joint
        /// </summary>
        IActuator LeftAnklePitch { get; }

        /// <summary>
        /// Right Ankle Roll Joint
        /// </summary>
        IActuator RightAnkleRoll { get; }

        /// <summary>
        /// Left Ankle Roll Joint
        /// </summary>
        IActuator LeftAnkleRoll { get; }

        /// <summary>
        /// Waist Joint
        /// </summary>
        IActuator Waist { get; }
        IActuator this[int i] { get; }
        void ApplySpeedPositions();
        void ApplySlopMargin();
        void ApplyPositions();
        void ApplySpeeds();
        void ApplySlops();
        void ApplyMargins();

        void HomogenizeSpeeds(int speed = 1023);

        void SetStandStyle(Posture style);
        void Save(string path);
        void Load(DynamixelBus bus, string path);
    }
}