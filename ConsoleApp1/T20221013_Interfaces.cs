using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //internal class T20221013_Interfaces
    //{
    //    public SubProperty MyProperty { get; set; }
    //}

    internal class T20221013_Interfaces : ITest
    {


        public void Test()
        {
            var k = new GGG(666);
            var ik = k as IGGG;


            Console.WriteLine(ik);
        }

        class GGG
        {
            public int MyProperty { get; set; }

            public GGG(int myProperty)
            {
                MyProperty = myProperty;
            }
        }

        interface IGGG
        {
            public int MyProperty { get; set; }
        }
    }
}
