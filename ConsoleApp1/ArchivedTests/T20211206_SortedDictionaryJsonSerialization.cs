using System;
using System.Collections.Generic;
using System.Text.Json;
using ConsoleApp1.Interfaces;

namespace ConsoleApp1.ArchivedTests
{
    public class T20211206_SortedDictionaryJsonSerialization : ITest
    {
        public void Test()
        {
            var dict = new SortedDictionary<string, string>()
            {
                { "Z", "fff" },
                { "Y", "fff" },
                { "R", "fff" },
                { "A", "fff" },
            };
            var strDict =  dict.ToJsonString();
            var dict2 = strDict.ToSortedDictionary<SortedDictionary<string,string>>();
            var strDict2 = dict.ToJsonString();

            var hashSet = new HashSet<string>(new[] { "fddf", "fdfdfdf" } );
            var hashSetJson = JsonSerializer.Serialize(hashSet);
            Console.WriteLine(strDict);
        }
    }

    public static class DictionaryExtensions_T20211206
    {
        //ordering 
        public static string ToJsonString<T>(this T sortedDictionary) where T : IDictionary<string, string>
        {
            return JsonSerializer.Serialize(sortedDictionary);
        }
    }

    public static class StringExtensions_T20211206
    {
        //ordering 
        public static T ToSortedDictionary<T>(this string json) where T : class, IDictionary<string, string>
        {
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
