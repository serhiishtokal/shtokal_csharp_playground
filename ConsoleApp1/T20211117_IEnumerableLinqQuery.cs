using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class T20211117_IEnumerableLinqQuery
    {
        public void Test()
        {
            var list = new List<int>() { 1, 2, 3, 4 };

            var k1 = list.Where(Where1);

            var k2 = k1.Where(Where2);

            var k3 = k2.Select(Select);

            var k4 = k3.ToList();
            Console.WriteLine();
        }

        public bool Where1(int x)
        {
            Console.WriteLine("Where1");
            return x > 2;
        }

        public bool Where2(int x)
        {
            Console.WriteLine("Where2");
            return x < 6;
        }

        public int Select(int x)
        {
            Console.WriteLine("Select");
            return x * 100;
        }
    }
}
