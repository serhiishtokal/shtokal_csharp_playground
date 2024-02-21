using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.ArchivedTests
{
    public class T20210908_ListTake
    {
        public static void Test()
        {
            var list = new List<int>() { 1, 2, 3 };
            var k = list.Take(5);
        }
    }
}
