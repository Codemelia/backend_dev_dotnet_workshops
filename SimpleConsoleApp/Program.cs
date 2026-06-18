// Main class

// Dependency injection of interface service
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddSingleton<IExampleService, ExampleService>();

var serviceProvider = services.BuildServiceProvider();

Console.WriteLine(">>>My first .NET project: Simple Calculator");

Console.WriteLine(">>> Input your name: ");

string name = Console.ReadLine() ?? string.Empty;

Console.WriteLine($">>> Hello, {name}!");

Console.WriteLine(">>> Testing dependency injection");

// Testing injected service
string result1 = serviceProvider.GetService<IExampleService>()?.performAddition(3, 5) ?? "";
string result2 = serviceProvider.GetService<IExampleService>()?.performAddition(4, 2) ??  "";
string result3 = serviceProvider.GetService<IExampleService>()?.performAddition(6, 7) ?? "";

Console.WriteLine(result1);
Console.WriteLine(result2);
Console.WriteLine(result3);