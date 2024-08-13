using System;

namespace Dotnet.DependencyInjection;

internal sealed class DefaultGreetService(IWriter writer) : IGreetService
{
    public string Greet(string name)
    {
        var greeting = $"Hello, {name}!";

        writer.WriteLine(greeting);

        return greeting;
    }
}
