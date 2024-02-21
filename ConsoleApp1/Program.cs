using System;
using ConsoleApp1.Extensions;
using ConsoleApp1.Interfaces;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.Add2024Tests();

//get registered services
var serviceProvider = services.BuildServiceProvider();
var scope = serviceProvider.CreateScope();
var test = scope.ServiceProvider.GetService<ITest>();

test.Test();

Console.ReadLine();

