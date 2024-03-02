using System;
using System.Collections.Generic;
using CSharpPlayground.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CSharpPlayground.ArchivedTests
{
    //internal class T20221013_Interfaces
    //{
    //    public SubProperty MyProperty { get; set; }
    //}

    internal class T20220813_Json : ITest
    {
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
            return null == 0;
        }

        public static void JsonTest()
        {
            string v = "{ \"DE\":\"\", \"EN\":\"Inspection: Equipment: Indoor air condition units check\", \"HR\":\"Pregled: Oprema: Provjera klima uređaja u zatvorenom prostoru\", \"PL\":\"\"}";

            var jObject = JObject.Parse(v);
        }

        public void Test()
        {
            throw new NotImplementedException();
        }
    }
}
