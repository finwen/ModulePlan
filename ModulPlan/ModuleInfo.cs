using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModulPlan
{
    public enum ModuleNorm
    {
        Unknown = 0,
        N_RE = 1,
        AmericaN = 2,
    }

    public enum ModuleLayout
    {
        Unknown = 0,
        Rectangle ,
        Curve, 
        Custom, 
    }

    public enum ModuleType
    {
        Unknown = 0,
        Line = 1,
        Junction, 
        Turntable, 
        Station,
        Yard,
        Crossover,
    }

    [Flags] public enum ModuleAttribute
    {
        Unknown = 0,
        GoodsStation,
        PassengerStation, 
        Industry,
        Mine,

    }

    public class ModuleInfo
    {
        public string Id;
        public string Owner;
        public string Name;
        public string Sign;
        public ModuleNorm ModuleNorm;
        public ModuleLayout ModuleLayout;
        public ModuleType ModuleType;
        public ModuleAttribute ModuleAttribute;

        public Joint[] Joints;

        public int Length;
        public int Width;
        public float Angle;
        public float Radius;


        public ModuleInfo()
        {
        }


        /// <summary>
        /// Parse json text tp module class
        /// </summary>
        /// <param name="jtext"></param>
        /// <returns></returns>
        public bool Parse(string jtext)
        {
            JObject jo = JObject.Parse(jtext);

            if (jo == null)
                return false;


            Id = jo["id"].Str();
            Owner = jo["owner"].Str();
            Name = jo["name"].Str();
            Sign = jo["sign"].Str();

            string modulenormstr = jo["modulenorm"].StrNull();
            string moduleLayoutstr = jo["moduleLayout"].StrNull();
            string moduleTypestr = jo["moduleType"].StrNull();
            string ModuleAttributestr = jo["ModuleAttribute"].StrNull();

            Length = jo["length"].Int();
            Width = jo["width"].Int();
            Radius = jo["radius"].Int();
            Angle = jo["angle"].Float();

            Joints = jo["joints"]?.ToObject<Joint[]>(); // may be Null

            ModuleNorm = ModuleNormStr2Enum(modulenormstr);
            ModuleLayout = ModuleLayoutStr2Enum(moduleLayoutstr);
            ModuleType = ModuleTypeStr2Enum(moduleTypestr);
            ModuleAttribute = ModuleAttributeStr2Enum(ModuleAttributestr);



            return true;
        }

        private static Dictionary<string, ModuleNorm> ModuleNormStr2EnumLookup;
        public static ModuleNorm ModuleNormStr2Enum(string star)
        {
            if (star == null)
                return ModuleNorm.Unknown;

            if (ModuleNormStr2EnumLookup == null)
            {
                ModuleNormStr2EnumLookup = new Dictionary<string, ModuleNorm>(StringComparer.InvariantCultureIgnoreCase);
                foreach (ModuleNorm atm in Enum.GetValues(typeof(ModuleNorm)))
                {
                    ModuleNormStr2EnumLookup[atm.ToString().Replace("_", "")] = atm;
                }

                // Extra stavningsalternativ
                ModuleNormStr2EnumLookup["amN"] = ModuleNorm.AmericaN;
            }

            var searchstr = star.Replace("_", "").Replace(" ", "").Replace("-", "").ToLower();

            if (ModuleNormStr2EnumLookup.ContainsKey(searchstr))
                return ModuleNormStr2EnumLookup[searchstr];

            return ModuleNorm.Unknown;
        }


        private static Dictionary<string, ModuleLayout> ModuleLayoutStr2EnumLookup;
        public static ModuleLayout ModuleLayoutStr2Enum(string star)
        {
            if (star == null)
                return ModuleLayout.Unknown;

            if (ModuleLayoutStr2EnumLookup == null)
            {
                ModuleLayoutStr2EnumLookup = new Dictionary<string, ModuleLayout>(StringComparer.InvariantCultureIgnoreCase);
                foreach (ModuleLayout atm in Enum.GetValues(typeof(ModuleLayout)))
                {
                    ModuleLayoutStr2EnumLookup[atm.ToString().Replace("_", "")] = atm;
                }

                // Extra stavningsalternativ
                ModuleLayoutStr2EnumLookup["Rect"] = ModuleLayout.Rectangle;

            }

            var searchstr = star.Replace("_", "").Replace(" ", "").Replace("-", "").ToLower();

            if (ModuleLayoutStr2EnumLookup.ContainsKey(searchstr))
                return ModuleLayoutStr2EnumLookup[searchstr];

            return ModuleLayout.Unknown;
        }


        private static Dictionary<string, ModuleType> ModuleTypeStr2EnumLookup;

        public static ModuleType ModuleTypeStr2Enum(string star)
        {
            if (star == null)
                return ModuleType.Unknown;

            if (ModuleTypeStr2EnumLookup == null)
            {
                ModuleTypeStr2EnumLookup = new Dictionary<string, ModuleType>(StringComparer.InvariantCultureIgnoreCase);
                foreach (ModuleType atm in Enum.GetValues(typeof(ModuleType)))
                {
                    ModuleTypeStr2EnumLookup[atm.ToString().Replace("_", "")] = atm;
                }
            }

            var searchstr = star.Replace("_", "").Replace(" ", "").Replace("-", "").ToLower();

            if (ModuleTypeStr2EnumLookup.ContainsKey(searchstr))
                return ModuleTypeStr2EnumLookup[searchstr];

            return ModuleType.Unknown;
        }


        private static Dictionary<string, ModuleAttribute> ModuleAttributeStr2EnumLookup;
        public static ModuleAttribute ModuleAttributeStr2Enum(string star)
        {
            if (star == null)
                return ModuleAttribute.Unknown;

            if (ModuleAttributeStr2EnumLookup == null)
            {
                ModuleAttributeStr2EnumLookup = new Dictionary<string, ModuleAttribute>(StringComparer.InvariantCultureIgnoreCase);
                foreach (ModuleAttribute atm in Enum.GetValues(typeof(ModuleAttribute)))
                {
                    ModuleAttributeStr2EnumLookup[atm.ToString().Replace("_", "")] = atm;
                }

                // Extra stavningsalternativ
                ModuleAttributeStr2EnumLookup["Goods"] = ModuleAttribute.GoodsStation;
                ModuleAttributeStr2EnumLookup["Passenger"] = ModuleAttribute.PassengerStation;
            }

            var searchstr = star.Replace("_", "").Replace(" ", "").Replace("-", "").ToLower();

            if (ModuleAttributeStr2EnumLookup.ContainsKey(searchstr))
                return ModuleAttributeStr2EnumLookup[searchstr];

            return ModuleAttribute.Unknown;
        }


    }
}
