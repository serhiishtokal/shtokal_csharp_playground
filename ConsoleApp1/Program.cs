using ConsoleApp1.Automapper;
using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ITest k = new T20230322_BuiltInSerialization();
            k.Test();

            Console.ReadLine();
        }
    }
}
