﻿using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class T20221109_AsyncIenumerable : ITest
    {
        public void Test()
        {
            Method().Wait();
        }

        public async Task Method()
        {
            var items = Method2();

            //var enumerator = items.GetAsyncEnumerator();
            //await enumerator.MoveNextAsync();
            //await enumerator.MoveNextAsync();
            //await enumerator.MoveNextAsync();

            await foreach (var item in items)
            {
                Console.WriteLine(item + "kk");
            }
        }


        public async IAsyncEnumerable<string> Method2()
        {
            //await Task.Delay(300);

            for (int i = 0; i < 3; i++)
            {
                await Task.Delay(300);
                var istr = i.ToString();
                yield return istr;

                Console.WriteLine($"{i} after yield" );
            }
        }

    }
}
