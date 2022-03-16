using Robot.IO;

namespace Robot.Environment.Interface
{
    public interface IHead
    {
        /// <summary>
        /// Get the Direction of Head
        /// </summary>
        double Direction { get; }

        /// <summary>
        /// Get or Set Pan Actuator
        /// </summary>
        IActuator Pan { set; get; }

        /// <summary>
        /// Get or Set Tilt Actuator 
        /// </summary>
        IActuator Tilt { set; get; }
    }
}