using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModulPlan
{
    enum ModuleNorm
    {
        Unknown = 0,
        N_RE = 1,
        AmericaN = 2,
    }

    enum ModuleLayout
    {
        Rect = 0,
        Curve = 1,
        Custom = 2, 
    }

    enum ModuleType
    {
        Line = 1,
        Junction, 
        Turntable, 
        Station,
        Yard,
        Crossover,
    }

    enum ModuleAttribute
    {
        GoodsStation,
        PassengerStation, 
        Industry,
        Mine,

    }

    public class Module
    {
        string id;
        string owner;
        string Name;
        string Sign;
        ModuleNorm moduleNorm;
        ModuleLayout moduleLayout;
        ModuleType moduleType;
        ModuleAttribute moduleAttribute;

        List<Joint> joints;

        int length;
        int width;
        float angle;
        float radius;


    }
}
