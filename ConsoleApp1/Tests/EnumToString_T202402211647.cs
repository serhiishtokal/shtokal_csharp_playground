using System;
using ConsoleApp1.Interfaces;

namespace ConsoleApp1.Tests;

public class EnumToString_T202402211647 : ITest
{
    private enum MyEnum
    {
                       SomeValue,
                       SomeOtherValue
    }
    
    public void Test()
    {
        const MyEnum k = MyEnum.SomeValue;
        Console.WriteLine(k);
    }
}