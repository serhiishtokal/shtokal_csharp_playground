using System;
using CSharpPlayground.Interfaces;

namespace CSharpPlayground.ArchivedTests
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
