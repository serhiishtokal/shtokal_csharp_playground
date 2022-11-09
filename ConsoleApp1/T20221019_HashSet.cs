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

    internal class T20221019_HashSet : ITest
    {


        public void Test()
        {
            HashSet<string> changedProperties = new HashSet<string>()
            { 
                "ggg",
                "hhhh",
                "kkk" 
            };

            var myClass = GetMyClass(changedProperties);
            changedProperties = null;
            foreach (var item in myClass.Items)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("*******");
            myClass = GetMyClass(changedProperties);
            changedProperties = null;
            foreach (var item in myClass.Items)
            {
                Console.WriteLine(item);
            }
        }

        public class MyClass
        {
            public IEnumerable<string> Items { get; set; }

            public MyClass(IEnumerable<string> myProperty)
            {
                Items = myProperty;
            }
        }

        MyClass GetMyClass(IEnumerable<string> vs)
        {
            return new MyClass(vs);
        }

    }
}
