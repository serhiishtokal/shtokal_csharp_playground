using ConsoleApp1.Automapper;
using ConsoleApp1.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;



namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ITest k = new T20221019_HashSet();
            k.Test();

            Console.ReadLine();
        }
    }
}
