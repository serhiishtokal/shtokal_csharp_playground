using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace ConsoleApp1
{
    public class T20211202_JsonDeSerialization : ITest
    {
        public HashSet<string> StringsHashSet { get; set; } = new HashSet<string>(5);
        public void Test()
        {
            StringsHashSet.Add("11,1\"\",");
            StringsHashSet.Add("2,2\"\",");
            StringsHashSet.Add("33,3\"\",");
            StringsHashSet.Add("4\"\",");
            StringsHashSet.Add("5\"\",");
            StringsHashSet.Add("6\"\",");


           var k =   JsonSerializer.Serialize(StringsHashSet);
           var newStringsHashSet = JsonSerializer.Deserialize<HashSet<string>>(k);

            Console.WriteLine(k);

        }
    }
}
