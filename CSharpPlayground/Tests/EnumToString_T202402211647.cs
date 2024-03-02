using System;
using CSharpPlayground.Interfaces;

namespace CSharpPlayground.Tests;

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