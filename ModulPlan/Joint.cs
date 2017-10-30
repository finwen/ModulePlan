using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModulPlan
{
    public enum JointType
    {
        None,
        Single,
        Double,
    }

    public class Joint
    {
        JointType type;

        // If different from standard
        int width;
        int xOffset;
        int yOffset;
        float angle;
    }
}
