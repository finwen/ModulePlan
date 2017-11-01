using ModulPlan;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitTest
{
    
    public class TestModuleFiles
    {
        string TestDataPath;

        [SetUp]
        public void InitTestData()
        {
            string dir = System.AppDomain.CurrentDomain.BaseDirectory;

            string[] importPaths =
            {
                Path.Combine(dir, @"TestData"),
                Path.Combine(dir, @"..\TestData"),
                Path.Combine(dir, @"..\..\TestData"),
                Path.Combine(dir, @"..\..\..\TestData"),
            };

            TestDataPath = importPaths.FirstOrDefault(Directory.Exists);
        }


        [Test]
        public void ModuleNormStr2Enum()
        {
            Assert.AreEqual(ModuleNorm.Unknown, ModuleInfo.ModuleNormStr2Enum(null));
            Assert.AreEqual(ModuleNorm.Unknown, ModuleInfo.ModuleNormStr2Enum(""));
            Assert.AreEqual(ModuleNorm.Unknown, ModuleInfo.ModuleNormStr2Enum("Fel"));

            Assert.AreEqual(ModuleNorm.N_RE, ModuleInfo.ModuleNormStr2Enum("N-RE"));
            Assert.AreEqual(ModuleNorm.N_RE, ModuleInfo.ModuleNormStr2Enum("N-Re"));
            Assert.AreEqual(ModuleNorm.N_RE, ModuleInfo.ModuleNormStr2Enum("NRE"));
            Assert.AreNotEqual(ModuleNorm.N_RE, ModuleInfo.ModuleNormStr2Enum("NREB"));


            Assert.AreEqual(ModuleNorm.AmericaN, ModuleInfo.ModuleNormStr2Enum("american"));
            Assert.AreEqual(ModuleNorm.AmericaN, ModuleInfo.ModuleNormStr2Enum("amN"));
            Assert.AreEqual(ModuleNorm.AmericaN, ModuleInfo.ModuleNormStr2Enum("amn"));
        }

        [Test]
        public void ModuleLayoutStr2Enum()
        {
            Assert.AreEqual(ModuleLayout.Unknown, ModuleInfo.ModuleLayoutStr2Enum(null));
            Assert.AreEqual(ModuleLayout.Curve, ModuleInfo.ModuleLayoutStr2Enum("Curve"));
            Assert.AreEqual(ModuleLayout.Rectangle, ModuleInfo.ModuleLayoutStr2Enum("Rect"));
            Assert.AreEqual(ModuleLayout.Rectangle, ModuleInfo.ModuleLayoutStr2Enum("Rectangle"));
            Assert.AreEqual(ModuleLayout.Custom, ModuleInfo.ModuleLayoutStr2Enum("Custom"));

        }


        [Test]
        public void ModuleTypeStr2Enum()
        {
            Assert.AreEqual(ModuleType.Unknown, ModuleInfo.ModuleTypeStr2Enum(null));
            Assert.AreEqual(ModuleType.Crossover, ModuleInfo.ModuleTypeStr2Enum("crossover"));
            Assert.AreEqual(ModuleType.Junction, ModuleInfo.ModuleTypeStr2Enum("junction"));
            Assert.AreEqual(ModuleType.Line, ModuleInfo.ModuleTypeStr2Enum("Line"));
            Assert.AreEqual(ModuleType.Station, ModuleInfo.ModuleTypeStr2Enum("station"));
            Assert.AreEqual(ModuleType.Turntable, ModuleInfo.ModuleTypeStr2Enum("turntable"));
            Assert.AreEqual(ModuleType.Yard, ModuleInfo.ModuleTypeStr2Enum("yard"));
        }

        [Test]
        public void ModuleAttributeStr2Enum()
        {
            Assert.AreEqual(ModuleAttribute.Unknown, ModuleInfo.ModuleAttributeStr2Enum(null));
            Assert.AreEqual(ModuleAttribute.GoodsStation, ModuleInfo.ModuleAttributeStr2Enum("Goods"));
            Assert.AreEqual(ModuleAttribute.GoodsStation, ModuleInfo.ModuleAttributeStr2Enum("Goodsstation"));
            Assert.AreEqual(ModuleAttribute.PassengerStation, ModuleInfo.ModuleAttributeStr2Enum("Passenger"));
            Assert.AreEqual(ModuleAttribute.PassengerStation, ModuleInfo.ModuleAttributeStr2Enum("PassengerStation"));
            Assert.AreEqual(ModuleAttribute.Industry, ModuleInfo.ModuleAttributeStr2Enum("Industry"));
            Assert.AreEqual(ModuleAttribute.Mine, ModuleInfo.ModuleAttributeStr2Enum("Mine"));

        }


        [Test]
        public void ParseModule1()
        {
            string file = Path.Combine(TestDataPath + "\\Modules\\RoWah001.json");

            string jtext = File.ReadAllText(file);

            ModuleInfo mod = new ModuleInfo();

            Assert.IsTrue(mod.Parse(jtext));


            Assert.AreEqual("RoWah001", mod.Id, "Id");
            Assert.AreEqual("Robert Wahlström", mod.Owner, "Owner");
            Assert.AreEqual("Klinten 1", mod.Name, "Name");
            Assert.AreEqual("", mod.Sign, "Sign");
            Assert.AreEqual(ModuleNorm.N_RE, mod.ModuleNorm, "ModuleNorm");
            Assert.AreEqual(ModuleLayout.Rectangle, mod.ModuleLayout, "ModuleLayout");
            Assert.AreEqual(ModuleType.Line, mod.ModuleType, "ModuleType");
            Assert.AreEqual(ModuleAttribute.Unknown, mod.ModuleAttribute, "ModuleAttribute");

        }





    }
}
