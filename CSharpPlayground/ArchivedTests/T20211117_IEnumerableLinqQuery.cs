using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CSharpPlayground.ArchivedTests
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
            var threadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"Where1 {x} {threadId}");
            //System.Threading.Thread.Sleep(5*1000);
            
            //Console.WriteLine($"Where1 {x} after sleep");
            return x > 2;
        }

        public bool Where2(int x)
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"Where2 {x} {threadId}");
            return x < 6;
        }

        public int Select(int x)
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"Select {x} {threadId}");
            return x * 100;
        }
    }
}
