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
        public string type;
        JointType Jointtype;

        // If different from standard
        public int width;
        public int xOffset;
        public int yOffset;
        public float angle;
    }
}
