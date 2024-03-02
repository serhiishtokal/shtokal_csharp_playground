using ConsoleApp1.Extensions;
using ConsoleApp1.Interfaces;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddAllAsyncTests();

//get registered services
var serviceProvider = services.BuildServiceProvider();
var scope = serviceProvider.CreateScope();

var test = scope.ServiceProvider.GetService<IAsyncTest>()!;
await test.TestAsync();


