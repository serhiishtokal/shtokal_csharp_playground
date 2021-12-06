using ConsoleApp1.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;



namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ITest k = new T20211206_SortedDictionaryJsonSerialization();
            k.Test();

            Console.ReadLine();
        }

        private static void DictionaryToJson()
        {
                var students = new Dictionary<string, string>()
            {
                { "EN", "costam"},
                { "PL", "Cośtam2" }
            };

            students["KK"] = "fdfdf";

            var k = JsonConvert.SerializeObject(students);
        }

        private static bool NullEqualsZeroTest()
        {
           return null==0;
        }

        public static void JsonTest()
        {
            string v = "{ \"DE\":\"\", \"EN\":\"Inspection: Equipment: Indoor air condition units check\", \"HR\":\"Pregled: Oprema: Provjera klima uređaja u zatvorenom prostoru\", \"PL\":\"\"}";

            var jObject = JObject.Parse(v);




        }


    }
}
