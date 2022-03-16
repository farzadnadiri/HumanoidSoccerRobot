using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Robot.Locomotion.TrajectoryWalk
{
    public class LERP
    {
        
        public double DO_LERP(double v0, double v1, double t)
        {
            return (1 - t) * v0 + t * v1;
        }
    }
}
