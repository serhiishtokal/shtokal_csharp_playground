using ConsoleApp1.Interfaces;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
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
