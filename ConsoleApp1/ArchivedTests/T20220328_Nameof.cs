using System;
using System.IO;
using ConsoleApp1.Interfaces;

namespace ConsoleApp1.ArchivedTests
{
    //internal class T20220328_Nameof
    //{
    //    public SubProperty MyProperty { get; set; }
    //}

    internal class T20220328_Nameof : ITest
    {
        public void Test()
        {
            //var k = nameof(SubProperty.MyProperty.MyProperty);
            //Test4();
            Test2();
        }

        public void Test2()
        {
            string path = "fdfdsfsdf.";
            var extension = Path.GetExtension(path);
        }

        public void Test3()
        {
            var k = TimeSpan.FromMinutes(21);
            var j = k.ToString();
        }

        public void Test4()
        {
            //(0,0) default
            (int OriginTimeMinutes, int CurrentTimeMinutes) updateDevicesTimeOfUsage;

        }
        public void Test5()
        {
            var k = (DayOfWeek)(((6 + 1) + 7) % 7);


        }

        public void Test7()
        {
            DateTime? k1 = null;
            DateTime? k2 = DateTime.Now;

            k1 = k1.HasValue 
                ? k2<=k1?k2:k1
                : k2;


            var b = k1.HasValue && (k2.HasValue ? k1 >= k2 : true);
        }


    }

    internal class SubProperty
    {
        public SubSubProperty MyProperty { get; set; }
    }
    internal class SubSubProperty
    {
        public int MyProperty { get; set; }
    }

}
