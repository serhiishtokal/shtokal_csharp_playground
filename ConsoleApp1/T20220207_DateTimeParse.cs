﻿using ConsoleApp1.Interfaces;
using System;

namespace ConsoleApp1
{
    public class T20220207_DateTimeParse : ITest
    {
        public void Test()
        {
            var k = DateTime.Parse("2022-03-06T23:59:59+01:00");
            Console.WriteLine(k);
        }
    }
}
