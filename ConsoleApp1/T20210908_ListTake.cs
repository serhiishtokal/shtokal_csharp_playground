using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
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
